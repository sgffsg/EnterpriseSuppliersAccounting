using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class Menu : Form
    {
        
        MySqlConnection connection;
        public Menu()
        {
            InitializeComponent();
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        //////////////////Проверки///////////////////
        public bool check(string ServerTest, string PortTest, string UserTest, string PassTest)
        {
            try
            {
                string config = "server=" + ServerTest + ";port=" + PortTest + ";userid=" + UserTest + ";password=" + PassTest + "";
                connection = new MySqlConnection(config);
                connection.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Не удалось установить соединение по указанным данным.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void connect(object sender, EventArgs e)
        {
            string Server = textBox1.Text;
            string Port = textBox2.Text;
            string User = textBox3.Text;
            string Pass = textBox4.Text;
            string writePath = "settings.txt";


            if (check(Server, Port, User, Pass) == true)
            {
                string path = null;
                MessageBox.Show("Выберите папку для хранения резервных файлов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var dialog = new FolderBrowserDialog())
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Server=Crypting(Server);
                        Port = Crypting(Port);
                        User = Crypting(User);
                        Pass = Crypting(Pass);

                        try
                        {
                            string sqls = "DROP SCHEMA `moya`";
                            MySqlCommand cmd1 = new MySqlCommand(sqls, connection);
                            cmd1.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                        {
                            path = dialog.SelectedPath;
                            sw.WriteLine(Server);
                            sw.WriteLine(Port);
                            sw.WriteLine(User);
                            sw.WriteLine(Pass);
                            sw.WriteLine(1);
                            sw.WriteLine(path);
                            sw.WriteLine(1);

                        }


                        string sql = "CREATE SCHEMA `moya`";

                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        string sql2 = "USE moya;" + "CREATE TABLE `moya`.`отделы предприятия`" +
                        "(`№ отдела` INT NOT NULL AUTO_INCREMENT," +
                        "`Название отдела` VARCHAR(45) NULL," +
                        "`Тип отдела` VARCHAR(45) NULL," +
                        "`Кол-во сотрудников в отделе` INT NULL," +
                        "PRIMARY KEY(`№ отдела`))";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();


                        sql2 = "USE moya;" + "CREATE TABLE `moya`.`поставляемые материалы`" +
                        "(`id поставки` INT NOT NULL AUTO_INCREMENT," +
                        "`Тип материала` VARCHAR(45) NULL," +
                        "`Название материала` VARCHAR(45) NULL," +
                        "`Стоимость` INT NULL," +
                        "`Кол-во` INT NULL," +
                        "`id Поставщика` INT NULL," +
                        "`id Отдела` INT NULL," +
                        "`Дата поставки` DATE NULL," +
                        "PRIMARY KEY(`id поставки`))";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();

                        sql2 = "USE moya;" + "CREATE TABLE `moya`.`поставщики`" +
                        "(`№ поставщика` INT NOT NULL AUTO_INCREMENT," +
                        "`Поставщик` VARCHAR(45) NULL," +
                        "`Тип поставляемой продукции` VARCHAR(45) NULL," +             
                        "PRIMARY KEY(`№ поставщика`))";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();

                        sql2 = "USE moya;" + "CREATE TABLE `moya`.`пользователи`" +
                        "(`idПользователя` INT NOT NULL AUTO_INCREMENT," +
                        "`Фамилия` VARCHAR(45) NULL," +
                        "`Имя` VARCHAR(45) NULL," +
                        "`Отчество` VARCHAR(45) NULL," +
                        "`Логин` VARCHAR(45) NULL," +
                        "`Пароль` VARCHAR(45) NULL," +
                        "`Уровень Доступа` INT NULL," +
                        "`День Рождения` DATE NULL," +
                        "PRIMARY KEY(`idПользователя`))";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();

                        sql2 = "USE moya;" + "CREATE TABLE `moya`.`Журнал`" +
                        "(`№Действия` INT NOT NULL AUTO_INCREMENT," +
                        "`Пользователь` VARCHAR(45) NULL," +
                        "`Действие` VARCHAR(45) NULL," +
                        "`Объект Действия` VARCHAR(45) NULL," +
                        "`Дата Выполнения` DATETIME NULL," +
                        "PRIMARY KEY(`№Действия`))";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();
                        string pass1 = Crypting("Admin");
                        string pass2 = Crypting("bot");
                        sql2 = "USE moya;" +
                        "INSERT INTO `moya`.`пользователи` (`Фамилия`, `Имя`, `Отчество`,`Логин`, `Пароль`, `Уровень Доступа`,`День Рождения`) VALUES('Пичугов', 'Александр', 'Сергеевич','Admin', '"+pass1+"', '1','2002.01.20');";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();

                        sql2 = "USE moya;" +
                        "INSERT INTO `moya`.`пользователи` (`Фамилия`, `Имя`, `Отчество`,`Логин`, `Пароль`, `Уровень Доступа`,`День Рождения`) VALUES('Бот', 'Помощник', 'Админ','Bot', '"+pass2+"', '1','2002.01.20');";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();

                        dateTimePicker1.Text = DateTime.Now.ToString();

                        sql2 = "USE moya;" +
                        "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('Гл. Администратор Пичугов Александр Сергеевич', 'Создание БД','Server','" + dateTimePicker1.Text + "');";

                        cmd = new MySqlCommand(sql2, connection);
                        cmd.ExecuteNonQuery();

                        Process.Start("cmd.exe", "/C " + "\"\"C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\\mysqldump.exe\"\" -h" + Server + " -P" + "3306" + "  -u" + User + " -p" + Pass + " moya > " + path + "\\0_dump.sql");
                        connection.Close();
                        Entry f = new Entry();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Не задан путь к сохранению резервных файлов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
        }
        //////////////////Переходы///////////////////
        private void exit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
