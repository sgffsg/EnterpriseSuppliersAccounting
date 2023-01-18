using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class FastIzm : Form
    {
        public FastIzm()
        {
            InitializeComponent();
        }

        public String InboxData = String.Empty;
        MySqlConnection connection;
        MySqlCommand cmd;
        string name;
        string action;
        string action_object;
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
        private void FastIzm_Load(object sender, EventArgs e)
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
        }
        private void FastIzm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }



        //////////////////Проверки///////////////////
        public bool Check_void()
        {
            int error_count = 0;
            errorProvider1.Clear();
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Поля не одинаковы!");
                errorProvider1.SetError(textBox1, "Поля не одинаковы!");
                errorProvider1.SetError(textBox2, "Поля не одинаковы!");
                error_count = 1;
                return false;
            }
            else
            {
                if (textBox1.Text == "" || textBox1.Text == " ")
                {

                    errorProvider1.SetError(textBox1, "Не может быть пустым");
                    error_count = 1;
                }
                if (textBox2.Text == "" || textBox2.Text == " ")
                {

                    errorProvider1.SetError(textBox2, "Не может быть пустым");
                    error_count = 1;
                }
                if (error_count != 0)
                {
                    MessageBox.Show("Вы не заполнили все поля!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //////////////////Взаимодействие///////////////////
        public void write(string deistvie, string deistv_object)
        {
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;
            dateTimePicker1.Text = DateTime.Now.ToString();
            name = "Гл. Администратор " + user;
            string sql = "USE moya;" +
              "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker1.Text + "');";

            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        //////////////////Действия///////////////////
        private void confirm(object sender, EventArgs e)
        {
            if (Check_void() == true)
            {
                
                string Pass = textBox1.Text;
                string sql = "Update `moya`.`пользователи` set " +
                $"`Пароль` = '{Crypting(textBox1.Text)}'  " +
                "WHERE(`idПользователя` = '1')";

                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();

                action = "Обновление пароля";
                action_object = "Пароль Гл. Администатора";
                write(action, action_object);

                Entry f = new Entry();
                f.Show();
                this.Close();

            }
        }
        //////////////////Переход///////////////////





        

        
    }
}
