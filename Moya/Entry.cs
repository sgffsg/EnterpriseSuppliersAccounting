using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Moya
{
    public partial class Entry : Form
    {
        
        public Entry()
        {
            InitializeComponent();


        }
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable datatable;     
        MySqlCommand cmd;
        string login, passwd;
        int count = 0;
        int user_root;
        Timer time = new Timer();
        string ServerTest;
        string PortTest;
        string UserTest;
        string PassTest;
        string AdmChek;
        string name;
        string action;
        string action_object;
        string Adress;
        string zn;
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
        private void Entry_Load(object sender, EventArgs e)
        {
            string[] arStr = File.ReadAllLines("settings.txt");
            ServerTest = DeCrypting(arStr[0]);
            PortTest = DeCrypting(arStr[1]);
            UserTest = DeCrypting(arStr[2]);
            PassTest = DeCrypting(arStr[3]);
            AdmChek = arStr[4];
            Adress = arStr[5];
            zn = arStr[6];
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
        private void Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
        //////////////////Взаимодействие///////////////////
        public void write(string deistvie, string deistv_object)
        {
            dateTimePicker1.Text = DateTime.Now.ToString();

            string sql = "USE moya;" +
              "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker1.Text + "');";

            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        //////////////////Действия///////////////////

        private void entry(object sender, EventArgs e)
        {
            
            login = textBox1.Text;
            passwd = textBox2.Text;
            string hack=null;
            adapter = new MySqlDataAdapter("SELECT `Пароль` FROM `пользователи` WHERE `Логин` = '" + login + "'", connection);
            datatable = new DataTable();
            adapter.Fill(datatable);
            if (datatable.Rows.Count<=0)
            {
                
            }
            else
            {
                string full = (string)datatable.Rows[0]["Пароль"];
                hack = DeCrypting(full); 
            }


            if (hack==textBox2.Text)
            {


                cmd = new MySqlCommand("SELECT `Уровень Доступа` FROM `пользователи` WHERE `Логин` = '" + login + "'", connection);

                user_root = (int)cmd.ExecuteScalar();
                DataBank.log = login;
                if (user_root == 0)
                {
                    MessageBox.Show("Ваша учетная запись находится на рассмотрении", "Нет доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    datatable.Clear();
                }
                if (user_root == 1)
                {
                    if (AdmChek == "1")
                    {
                        string writePath = "settings.txt";
                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(Crypting(ServerTest));
                            sw.WriteLine(Crypting(PortTest));
                            sw.WriteLine(Crypting(UserTest));
                            sw.WriteLine(Crypting(PassTest));
                            sw.WriteLine(0);
                            sw.WriteLine(Adress);
                            sw.WriteLine(zn);
                        }
                        FastIzm f = new FastIzm();
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        name = "Администратор: " + textBox1.Text;
                        action = "Вход в систему";
                        action_object = "Система";
                        write(action, action_object);

                        MessageBox.Show("Добро Пожаловать, администратор ", "Вход выполнен", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        DataBank.root = "1";
                        AdminControl f = new AdminControl();
                        f.Show();
                        this.Close();
                    }
                }
                if (user_root == 2)
                {
                    MessageBox.Show("Добро Пожаловать, читатель ", "Вход выполнен", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Tab2 f = new Tab2();
                    DataBank.root = "2";
                    f.Show();
                    name = "Читатель: " + textBox1.Text;
                    action = "Вход в систему";
                    action_object = "Система";
                    write(action, action_object);
                    this.Close();
                }
                if (user_root == 3)
                {
                    MessageBox.Show("Добро Пожаловать, менеджер ", "Вход выполнен", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Tab2 f = new Tab2();
                    DataBank.root = "3";
                    f.Show();
                    name = "Менеджер: " + textBox1.Text;
                    action = "Вход в систему";
                    action_object = "Система";
                    write(action, action_object);
                    this.Close();
                }
                if (user_root == 4)
                {
                    MessageBox.Show("Добро Пожаловать, старший менеджер ", "Вход выполнен", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Tab2 f = new Tab2();
                    DataBank.root = "4";
                    f.Show();
                    name = "Старший Менеджер: " + textBox1.Text;
                    action = "Вход в систему";
                    action_object = "Система";
                    write(action, action_object);
                    this.Close();
                }
                if (user_root == 5)
                {
                    DataBank.root = "5";
                    MessageBox.Show("Добро Пожаловать, руководитель ", "Вход выполнен", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OtchControl f = new OtchControl();
                    f.Show();
                    name = "Руководитель: " + textBox1.Text;
                    action = "Вход в систему";
                    action_object = "Система";
                    write(action, action_object);
                    this.Close();
                }

                datatable.Clear();
            }
            else
            {
                count++;
                if (count > 2)
                {
                    time.Interval = 180000;
                    time.Enabled = true;
                    time.Tick += new EventHandler(timer1_Tick);
                    time.Start();
                    MessageBox.Show("Вы превысили количество ввода неправильных попыток.\nВремя блокировки 3 минуты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button1.Visible = false;
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Аккаунта с такими параметрами не существует.\n После  3 неправильных попыток входа, текущая сессия \n будет заблокирована на 3 минуты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                datatable.Clear();
            }
        }
        //////////////////Проверки///////////////////

        //////////////////Переходы///////////////////
        private void registration(object sender, EventArgs e)
        {
            CreateLogin f = new CreateLogin();
            f.Show();
            this.Close();
        }

        private void exit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Stop();
            MessageBox.Show("Возможность входа разблокированна");
            time.Enabled = false;
            button1.Visible = true;
            count = 0;
        }







    }
}
