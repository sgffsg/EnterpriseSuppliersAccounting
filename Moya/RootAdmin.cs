using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class RootAdmin : Form
    {
        public RootAdmin()
        {
            InitializeComponent();
            

        }
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable datatable;
        MySqlDataAdapter adap = null;
        DataTable update_datatable;
        MySqlCommand cmd;
        string name;
        string action;
        string action_object;
        int count;
        int kol = 0;
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
        private void RootAdmin_Load(object sender, EventArgs e)
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


                adapter = new MySqlDataAdapter("SELECT `idПользователя`,`Фамилия`,`Имя`,`Отчество`,`Логин`,`Уровень Доступа`,`День Рождения` FROM moya.пользователи where `idПользователя` NOT LIKE '1'", connection);
                datatable = new DataTable();
                adapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
                dataGridView1.Columns[0].Visible = false;
                count = datatable.Rows.Count;
                status.Text = "| Всего записей в БД: " + count + " |";
                col.Text = "Текущий Сеанс: выполнено=" + kol;
            }
            catch
            {
                MessageBox.Show("Не удалось установить соединение С БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            spData.Text = Convert.ToString(System.DateTime.Today.ToLongDateString()) + " |";
            
                
        }
        private void RootAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
        


    //////////////////Взаимодействие///////////////////
    void loaddata()
        {
            adap = new MySqlDataAdapter("SELECT `idПользователя`,`Фамилия`,`Имя`,`Отчество`,`Логин`,`Уровень Доступа`,`День Рождения` FROM moya.пользователи where `idПользователя` NOT LIKE '1'", connection);
            update_datatable = new DataTable();
            try
            {
                adap.Fill(update_datatable);
            }
            catch
            {
                MessageBox.Show("Не удалось получить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = update_datatable;
            dataGridView1.Columns[0].Visible = false;
            count = update_datatable.Rows.Count;
            status.Text = "| Всего записей в БД: " + count + " |";
            tool.Text = "    [Операция Выполнена]";
            tool.ForeColor = Color.Blue;
            kol++;
            col.Text = "Текущий Сеанс: выполнено=" + kol;
        }

        public void write(string deistvie, string deistv_object)
        {
            ///////////////////////////////////////////
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;

            dateTimePicker1.Text = DateTime.Now.ToString();

            name = "Администратор: " + user;

            string sql = "USE moya;" +
                    "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker1.Text + "');";

            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        //////////////////Действия///////////////////
        private void user_izm(object sender, DataGridViewCellEventArgs e)
        {
            RootIzm form = new RootIzm();
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.Yes)
            {
                MessageBox.Show("Запись Успешно Изменена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
                action = "Изменение уч. записи";
                action_object = "таблица учетных записей Пользователей";
                write(action, action_object);
            }
            else
            {
                tool.Text = "    [Операция Отклонена]";
                tool.ForeColor = Color.Red;
            }
        }

        private void del_user(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    string sql = "Delete From `пользователи` where " +
                        $"`idПользователя`='{dataGridView1.SelectedRows[i].Cells[0].Value.ToString()}'";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    try
                    {
                        cmd.ExecuteNonQuery();


                        action = "Удаление уч. записи пользователя";
                        action_object = "таблица учетных записей Пользователей";
                        write(action, action_object);
                    }
                    catch
                    { }
                }
                MessageBox.Show("Запись Успешно Удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
            }
            else
            {
                tool.Text = "    [Операция Отклонена]";
                tool.ForeColor = Color.Red;
            }
        }

        private void user_add(object sender, EventArgs e)
        {
            RootCreate form = new RootCreate();
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.Yes)
            {
                loaddata();
                action = "Создание Учетной Записи";
                action_object = "Система";
                write(action, action_object);
            }
            else
            {
                tool.Text = "    [Операция Отклонена]";
                tool.ForeColor = Color.Red;
            }
        }
        //////////////////Переъоды///////////////////

        private void выйтиИзУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            action = "Выход из Учетной Записи";
            action_object = "Система";
            write(action, action_object);

            Entry form = new Entry();
            form.Show();
            this.Close();
        }



        private void back(object sender, EventArgs e)
        {
            this.Close();
            AdminControl f = new AdminControl();
            f.Show();
        }

        private void exit(object sender, EventArgs e)
        {

            this.Close();
            AdminControl f = new AdminControl();
            f.Show();
        }

        private void sCPBD30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramm f = new AboutProgramm();
            f.ShowDialog();
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
    }
}
