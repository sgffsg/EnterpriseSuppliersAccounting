using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Moya
{
    public partial class UserData : Form
    {
        public UserData()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable datatable;
        int primarykey;

        
        private void UserData_Load(object sender, EventArgs e)
        {
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;
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

            if (res == "1")
            {
                dolgn.Text = "Администратор " + user;
            }
            if (res == "2")
            {
                dolgn.Text = "Читатель " + user;
            }
            if (res == "3")
            {
                dolgn.Text = "Менеджер " + user;
            }
            if (res == "4")
            {
                dolgn.Text = "Старший Менеджер " + user;
            }
            if (res == "5")
            {
                dolgn.Text = "Руководитель " + user;
            }

            adapter = new MySqlDataAdapter("Select `Фамилия` from `пользователи` where `Логин`='" + user + "'", connection);
            datatable = new System.Data.DataTable();
            adapter.Fill(datatable);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                textBox1.Text=(string)datatable.Rows[i]["Фамилия"];
            }
            adapter = new MySqlDataAdapter("Select `Имя` from `пользователи` where `Логин`='" + user + "'", connection);
            datatable = new System.Data.DataTable();
            adapter.Fill(datatable);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                textBox2.Text = (string)datatable.Rows[i]["Имя"];
            }
            adapter = new MySqlDataAdapter("Select `Отчество` from `пользователи` where `Логин`='" + user + "'", connection);
            datatable = new System.Data.DataTable();
            adapter.Fill(datatable);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                textBox3.Text = (string)datatable.Rows[i]["Отчество"];
            }
            adapter = new MySqlDataAdapter("Select `Пароль` from `пользователи` where `Логин`='" + user + "'", connection);
            datatable = new System.Data.DataTable();
            adapter.Fill(datatable);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                string pas = (string)datatable.Rows[i]["Пароль"];
               textBox5.Text= DeCrypting(pas);
            }
            adapter = new MySqlDataAdapter("Select `idПользователя` from `пользователи` where `Логин`='" + user + "'", connection);
            datatable = new System.Data.DataTable();
            adapter.Fill(datatable);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                primarykey = (int)datatable.Rows[i]["idПользователя"];

            }

        }
        public void write()
        {
            string name="";
            string action;
            string action_object;
            ///////////////////////////////////////////
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;
            
            dateTimePicker2.Text = DateTime.Now.ToString();
            if (res=="2")
            {
                name = "Читатель: " + user;
            }
            if (res=="3")
            {
                name = "Менеджер: " + user;
            }
            if (res=="4")
            {
                name = "Старший менеджер: " + user;
            }
            if (res=="5")
            {
                name = "Руководитель: " + user;
            }


            action = "Изменение данных Учетной записи";
            action_object = "Система";

            string sql = "USE moya;" +
                    "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + action + "','" + action_object + "','" + dateTimePicker2.Text + "');";

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
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

        private void UserData_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        public bool Check_void()
        {

            int error_count = 0;

            errorProvider1.Clear();
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

        private void save_data(object sender, EventArgs e)
        {
            if (Check_void() == true)
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string pas = Crypting(textBox5.Text);
                        string sql = "Update `moya`.`пользователи` set " +
                                     $"`Фамилия` ='{textBox1.Text}',  " +
                                     $"`Имя` ='{textBox2.Text}',  " +
                                     $"`Отчество` ='{textBox3.Text}',  " +
                                     $"`Пароль` = '{pas}' " +
                                     $"Where (`idПользователя`='{primarykey}')";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        write();
                        this.DialogResult = DialogResult.Yes;
                        MessageBox.Show("Учетная Запись Успешно Изменена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить данные! Проверьте то, что Вы ввели!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }




                }

                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
