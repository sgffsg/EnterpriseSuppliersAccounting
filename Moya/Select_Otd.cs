using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moya
{
    public partial class Select_Otd : Form
    {
        public Select_Otd()
        {
            InitializeComponent();
        }

        MySqlConnection connection;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        System.Data.DataTable datatable;
        public static string selected = null;
        public static int selected3;
        string name;
        string action;
        string action_object;
        private void Select_Otd_Load(object sender, EventArgs e)
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
            string sql = "Select * From `отделы предприятия`";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }
        public void loaddata()
        {
            string sql = "Select * From `отделы предприятия`";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selected3 = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            selected = (string)dataGridView1.SelectedRows[0].Cells[1].Value;

            this.DialogResult = DialogResult.OK;
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

        private void Select_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            selected3 = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            selected = (string)dataGridView1.SelectedRows[0].Cells[1].Value;

            this.DialogResult = DialogResult.OK;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void write(string deistvie, string deistv_object)
        {

            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            username.Text = DataBank.log;
            string user = username.Text;
            dateTimePicker1.Text = DateTime.Now.ToString();


            if (res == "3")
            {
                name = "Менеджер: " + user;
                string sql = "USE moya;" +
                        "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker1.Text + "');";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            if (res == "4")
            {
                name = "Старший Менеджер: " + user;
                string sql = "USE moya;" +
                        "INSERT INTO `moya`.`Журнал` (`Пользователь`, `Действие`, `Объект Действия`,`Дата Выполнения`) VALUES('" + name + "', '" + deistvie + "','" + deistv_object + "','" + dateTimePicker1.Text + "');";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }

        }
        private void label3_Click(object sender, EventArgs e)
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

            }
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

        private void label5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            loaddata();
        }

        private void Select_Otd_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
}
