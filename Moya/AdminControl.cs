using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class AdminControl : Form
    {
        public String InboxData = String.Empty;
        MySqlConnection connection;
        MySqlCommand cmd;
        string name;
        string action;
        string action_object;
        public AdminControl()
        {
            InitializeComponent();
        }
        string ServerTest;
        string PortTest;
        string UserTest;
        string PassTest;
        string Source;
        string Znach;
        public string DeCrypting(string value)
        {
            string hash = "f0xle@rn";
            byte[] data = Convert.FromBase64String(value);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    value = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return value;
        }
    private void AdminControl_Load(object sender, EventArgs e)
        {
            string[] arStr = File.ReadAllLines("settings.txt");
            ServerTest = DeCrypting(arStr[0]);
            PortTest = DeCrypting(arStr[1]);
            UserTest = DeCrypting(arStr[2]);
            PassTest = DeCrypting(arStr[3]);
            Source = arStr[5];
            Znach = arStr[6];
            try
            {
                string config = "server=" + ServerTest + ";port=" + PortTest + ";userid=" + UserTest + ";password=" + PassTest + ";database=moya;sslmode=none";
                connection = new MySqlConnection(config);
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Не удалось установить соединение С БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            spData.Text = Convert.ToString(System.DateTime.Today.ToLongDateString());

        }

        private void AdminControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        

        


        //////////////////Действия///////////////////

        private void users_control(object sender, EventArgs e)
        {
            RootAdmin f = new RootAdmin();
            f.Show();
            this.Close();
        }

        private void recovery_bd(object sender, EventArgs e)
        {
            string path = null;
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Source;
                dialog.Filter = "Файлы Базы Данных(*.sql)|*.sql";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SafeFileName;
                    string cmd = "/C " + "\"\"C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\\mysql.exe\" -h" + ServerTest + "  -u" + UserTest + " -p" + PassTest + "  moya < \"" + Source + "\\" + path + "\"\"";
                    cmd.Replace("\\\\", "\\");
                    Process.Start("cmd.exe", cmd);
                }
            }
        }

        public string Crypting(string value)
        {
            string hash = "f0xle@rn";
            byte[] data = UTF8Encoding.UTF8.GetBytes(value);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    value = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return value;
        }

        private void backup(object sender, EventArgs e)
        {
           
            string[] arStr = File.ReadAllLines("settings.txt");
            ServerTest = DeCrypting(arStr[0]);
            PortTest = DeCrypting(arStr[1]);
            UserTest = DeCrypting(arStr[2]);
            PassTest = DeCrypting(arStr[3]);
            Source = arStr[5];
            Znach = arStr[6];

            int z = int.Parse(Znach);
            string writePath = "settings.txt";

            string cmd = "/C " + "\"\"C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\\mysqldump.exe\" -h" + ServerTest + " -P" + "3306" + "  -u" + UserTest + " -p" + PassTest + " moya > \"" + Source + "\\" + z + "_dump.sql\"\"";
            Process.Start("cmd.exe", cmd);
            z += 1;
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(Crypting(ServerTest));
                sw.WriteLine(Crypting(PortTest));
                sw.WriteLine(Crypting(UserTest));
                sw.WriteLine(Crypting(PassTest));
                sw.WriteLine(0);
                sw.WriteLine(Source);
                sw.WriteLine(z);

            }
            
            action = "Резервное копирование БД";
            action_object = "Система";
            write(action, action_object);
            MessageBox.Show("Резервное копирование успешно выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //////////////////Взаимодействие///////////////////
        public void write(string deistvie, string deistv_object)
        {
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;
            dateTimePicker1.Text = DateTime.Now.ToString();

            name = "Администратор " + user;
            string sql = "USE moya;" +
                "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker1.Text + "');";

            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        //////////////////Переходы///////////////////


        private void exit(object sender, EventArgs e)
        {
            action = "Выход из Учетной Записи";
            action_object = "Система";
            write(action, action_object);
            Entry f = new Entry();
            f.Show();
            this.Close();
        }

        private void выйтиИзУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entry f = new Entry();
            f.Show();
            action = "Выход из Учетной Записи";
            action_object = "Система";
            write(action, action_object);
            this.Close();
        }

        private void изменитьДанныеУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserData form = new UserData();
            form.Owner = this;
            action = "Просмотр данных учетной Записи";
            action_object = "Система";
            write(action, action_object);
            if (form.ShowDialog() == DialogResult.Yes)
            {

                this.Show();

            }
            else
            {
                this.Show();
            }
        }

        private void sCPBD30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramm f = new AboutProgramm();
            f.ShowDialog();
        }
    }
}
