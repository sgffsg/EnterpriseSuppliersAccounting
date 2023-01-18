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
    public partial class Tab1 : Form
    {
        public Tab1()
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
        private void Tab1_Load(object sender, EventArgs e)
        {
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;




            if (res == "2")
            {
                button2.Visible = false;
                button3.Visible = false;

                dataGridView1.CellDoubleClick -= izm;
            }
            if (res == "3")
            {
                button2.Visible = false;

                textBox1.Visible = false;
                label2.Visible = false;

                dataGridView1.CellDoubleClick -= izm;
            }
            if (res == "4")
            {

                textBox1.Visible = false;
                label2.Visible = false;
            }

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


                adapter = new MySqlDataAdapter("Select * from `отделы предприятия` order by `Название отдела`", connection);
                datatable = new DataTable();

                adapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
                dataGridView1.Columns[0].Visible = false;


                count = datatable.Rows.Count;
                status.Text = "| Всего записей в БД: " + count+" |";                
                col.Text = "Текущий Сеанс: выполнено=" + kol;
            }
            catch
            {
                MessageBox.Show("Не удалось установить соединение С БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            spData.Text = Convert.ToString(System.DateTime.Today.ToLongDateString())+" |";
        }

        private void Tab1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            
        }



        //////////////////Взаимодействие///////////////////
        void loaddata()
        {
            adap = new MySqlDataAdapter("Select * From `отделы предприятия` order by `Название отдела`", connection);
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
            tool.Text = "    [Операция Выполнена]";
            tool.ForeColor = Color.Blue;
            count = update_datatable.Rows.Count;
            status.Text = "| Всего записей в БД: " + count+" |";
            kol++;
            col.Text = "Текущий Сеанс: выполнено=" + kol;
        }


        public void write(string deistvie, string deistv_object)
        {

            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;
            dateTimePicker2.Text = DateTime.Now.ToString();

            if (res == "2")
            {
                name = "Читатель: " + user;
                string sql = "USE moya;" +
                "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker2.Text + "');";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            if (res == "3")
            {
                name = "Менеджер: " + user;
                string sql = "USE moya;" +
                        "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker2.Text + "');";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            if (res == "4")
            {
                name = "Старший Менеджер: " + user;
                string sql = "USE moya;" +
                        "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker2.Text + "');";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }

        }

        //////////////////Действия///////////////////

        private void add(object sender, EventArgs e)
        {
            Add1 f = new Add1();
            f.Owner = this;
            if (f.ShowDialog() == DialogResult.Yes)
            {
                loaddata();
                action = "Добавление записи";
                action_object = "таблица Отделы Предприятия";
                write(action, action_object);
            }
            else
            {
                tool.Text = "    [Операция Отклонена]";
                tool.ForeColor = Color.Red;
            }
        }

        private void search_null(object sender, EventArgs e)
        {
            loaddata();
            textBox1.Text = "";
        }




        private void izm(object sender, DataGridViewCellEventArgs e)
        {
            Izm1 form = new Izm1();
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.Yes)
            {
                loaddata();
                action = "Изменение записи";
                action_object = "таблица Отделы Предприятия";
                write(action, action_object);
                MessageBox.Show("Запись Успешно Изменена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tool.Text = "    [Операция Отклонена]";
                tool.ForeColor = Color.Red;
            }
        }


        private void delete(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    string sql = "Delete From `отделы предприятия` where " +
                        $"`№ отдела`='{dataGridView1.SelectedRows[i].Cells[0].Value.ToString()}'";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        action = "Удаление записи";
                        action_object = "таблица Отделы Предприятия";
                        write(action, action_object);
                        MessageBox.Show("Запись Успешно Удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    { }
                }
                loaddata();
            }
            else
            {
                tool.Text = "    [Операция Отклонена]";
                tool.ForeColor = Color.Red;
            }
        }
        //////////////////Переходы///////////////////

        private void выйтиИзУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Entry form = new Entry();
            form.Show();
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
            this.Close();
            Tab2 f = new Tab2();
            f.Show();
        }

        private void back(object sender, EventArgs e)
        {
            this.Close();
            Tab2 f = new Tab2();
            f.Show();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1;
            sql1 = "Select * From `отделы предприятия` where `Название отдела` like '%"
                + textBox1.Text + "%' OR `Тип отдела` like '%" + textBox1.Text + "%' OR `Кол-во сотрудников в отделе` like '%" + textBox1.Text + "%'";


            adapter = new MySqlDataAdapter(sql1, connection);
            datatable = new DataTable();
            adapter.Fill(datatable);
            if (textBox1.Text == "" || textBox1.Text.Length == 0) { loaddata(); textBox1.Text = ""; }
            if (datatable.Rows.Count <= 0)
            {
                loaddata();

            }
            else
            {
                dataGridView1.DataSource = datatable;
                dataGridView1.Columns[0].Visible = false;
            }
        }
    }
}
