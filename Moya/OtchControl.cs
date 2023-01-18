using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class OtchControl : Form
    {
        public OtchControl()
        {
            InitializeComponent();
        }
        public String InboxData = String.Empty;
        MySqlConnection connection;
        MySqlCommand cmd;
        string name;
        string action;
        string action_object;
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
        private void OtchControl_Load(object sender, EventArgs e)
        {
            string[] arStr = File.ReadAllLines("settings.txt");
            string ServerTest = DeCrypting(arStr[0]);
            string PortTest = DeCrypting(arStr[1]);
            string UserTest = DeCrypting(arStr[2]);
            string PassTest = DeCrypting(arStr[3]);

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
        private void OtchControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }


        //////////////////Взаимодействие///////////////////
        public void write(string deistvie, string deistv_object)
        {
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;
            dateTimePicker1.Text = DateTime.Now.ToString();

            name = "Руководитель " + user;

            string sql = "USE moya;" +
            "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker1.Text + "');";

            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        //////////////////Переходы///////////////////
        private void выйтиИзУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entry f = new Entry();
            f.Show();
            action = "Выход из Учетной Записи";
            action_object = "Система";
            write(action, action_object);
            this.Close();
        }

        private void exit(object sender, EventArgs e)
        {
            action = "Выход из Учетной Записи";
            action_object = "Система";
            write(action, action_object);
            Entry f = new Entry();
            f.Show();
            this.Close();
        }





        private void chart_otch(object sender, EventArgs e)
        {
            DataBank.otch = 1; 
            Chart_otchet f = new Chart_otchet();
            f.Show();
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
