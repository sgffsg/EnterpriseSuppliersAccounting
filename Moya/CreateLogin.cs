using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Moya
{
    public partial class CreateLogin : Form
    {
        public CreateLogin()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable datatable;
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
        private void CreateLogin_Load(object sender, EventArgs e)
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
            dateTimePicker1.Text = DateTime.Today.ToString();
        }
        private void CreateLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

            Entry f = new Entry();
            f.Show();
            connection.Close();

        }
        //////////////////Взаимодействие///////////////////
        public void write(string kto, string deistvie, string deistv_object)
        {
            dateTimePicker2.Text = DateTime.Now.ToString();

            string sql = "USE moya;" +
              "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + kto + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker2.Text + "');";

            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        //////////////////Проверки///////////////////
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Фамилия не может содержать цифры");
                errorProvider1.SetError(textBox4, "Должно быть строкой");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Имя не может содержать цифры");
                errorProvider1.SetError(textBox3, "Должно быть строкой");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Отчество не может содержать цифры");
                errorProvider1.SetError(textBox5, "Должно быть строкой");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        public bool Check_void()
        {
            string CreateLogin = textBox1.Text;
            int error_count = 0;
            errorProvider1.Clear();
            adapter = new MySqlDataAdapter("SELECT `Уровень Доступа` FROM `пользователи` WHERE `Логин` = '" + CreateLogin + "'", connection);
            datatable = new DataTable();
            adapter.Fill(datatable);
            if (datatable.Rows.Count <= 0)
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
                if (textBox3.Text == "" || textBox3.Text == " ")
                {
                    errorProvider1.SetError(textBox3, "Не может быть пустым");
                    error_count = 1;
                }
                if (textBox4.Text == "" || textBox4.Text == " ")
                {
                    errorProvider1.SetError(textBox4, "Не может быть пустым");
                    error_count = 1;
                }
                if (textBox5.Text == "" || textBox5.Text == " ")
                {
                    errorProvider1.SetError(textBox5, "Не может быть пустым");
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
            else
            {
                errorProvider1.SetError(textBox1, "Указанный логин уже занят");
                MessageBox.Show("Запись уже существует");
                return false;
            }
        }
        //////////////////Действия///////////////////
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
        private void create_account(object sender, EventArgs e)
        {
            if (Check_void() == true)
            {
                string CreateLogin = textBox1.Text;
                string CreatePasswd = Crypting(textBox2.Text);
                string CreateI = textBox3.Text;
                string CreateF = textBox4.Text;
                string CreateO = textBox5.Text;
               
                string CreateDr = dateTimePicker1.Text;
                string Pass = CreatePasswd;

                string sql = "USE moya;" +
                         "INSERT INTO `moya`.`пользователи` (`Фамилия`, `Имя`, `Отчество`,`Логин`, `Пароль`, `Уровень Доступа`,`День Рождения`) VALUES('" + CreateF + "', '" + CreateI + "','" + CreateO + "','" + CreateLogin + "', '" + Pass + "', '0','" + CreateDr + "');";

                errorProvider1.Clear();
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись выполнена");


                name = "Система";
                action = "Создание Учетной Записи";
                action_object = "Система";
                write(name, action, action_object);

                this.Close();
            }
        }

        //////////////////Переходы///////////////////

        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
