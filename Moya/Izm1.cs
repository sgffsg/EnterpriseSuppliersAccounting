using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Moya
{
    public partial class Izm1 : Form
    {
        public Izm1()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable datatable;
        int[] otd = new int[1];
        string primarykey;
        string safe;
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
        private void Izm1_Load(object sender, EventArgs e)
        {
            primarykey = ((Tab1)this.Owner).dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = ((Tab1)this.Owner).dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = ((Tab1)this.Owner).dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = ((Tab1)this.Owner).dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            safe = primarykey;
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
        private void Izm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        //////////////////Проверки///////////////////
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Название Отдела не может содержать цифры");
                errorProvider1.SetError(textBox1, "Должно быть строкой");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
                MessageBox.Show("Поле Кол-во сотрудников не может содержать буквы");
                errorProvider1.SetError(textBox3, "Должно быть число");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Название Отдела не может содержать цифры");
                errorProvider1.SetError(textBox1, "Должно быть строкой");
            }
            else
            {
                errorProvider1.Clear();
            }
        }


        public bool Check_void()
        {
            int error_count = 0;
            errorProvider1.Clear();
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                error_count = 1;
                errorProvider1.SetError(textBox1, "Не может быть пустым");
            }

            if (textBox3.Text == "" || textBox3.Text == " ")
            {
                error_count = 1;
                errorProvider1.SetError(textBox3, "Не может быть пустым");
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


        public bool repeat_check()
        {
            adapter = new MySqlDataAdapter("SELECT `№ отдела` FROM `отделы предприятия` WHERE `Название отдела` = '" + textBox1.Text + "'", connection);
            datatable = new DataTable();
            adapter.Fill(datatable);
            if (datatable.Rows.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //////////////////Действия///////////////////
        private void save(object sender, EventArgs e)
        {
            if (Check_void() == true)
            {
                errorProvider1.Clear();
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (repeat_check())
                    {
                        string sql = "Update `отделы предприятия` set " +
                       $"`Название отдела` = '{textBox1.Text}',  " +
                       $"`Тип отдела` ='{textBox2.Text}',  " +
                       $"`Кол-во сотрудников в отделе` ='{textBox3.Text}'  " +
                       $"Where `№ отдела`='{primarykey}'";

                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();



                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "Введите другое название отдела");
                        MessageBox.Show("Такой отдел уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    connection.Close();
                    this.DialogResult = DialogResult.No;
                }
            }
        }
        //////////////////Переходы///////////////////


        private void exit(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
        
    }


