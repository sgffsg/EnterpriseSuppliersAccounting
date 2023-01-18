using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Moya
{
    public partial class Izm2 : Form
    {
        public Izm2()
        {
            InitializeComponent();
        }
        MySqlDataAdapter adapter;
        DataTable datatable;
        MySqlConnection connection;
        int[] nums = new int[2];
        string primarykey;


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
        string safe;
        string safe2;
        private void Izm2_Load(object sender, EventArgs e)
        {
            primarykey = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            dateTimePicker1.Text = ((Tab2)this.Owner).dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            safe = textBox5.Text;
            safe2 = textBox6.Text;
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

        private void Izm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        //////////////////Проверки///////////////////


        public bool Check_void()
        {
            int error_count = 0;
            errorProvider1.Clear();
            if (textBox5.Text == "" || textBox5.Text == " ")
            {
                errorProvider1.SetError(textBox5, "Не может быть пустым");
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
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                errorProvider1.SetError(textBox1, "Не может быть пустым");
                error_count = 1;
            }
            if (textBox6.Text == "" || textBox6.Text == " ")
            {
                errorProvider1.SetError(textBox6, "Не может быть пустым");
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


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Название материала не может содержать цифры");
                errorProvider1.SetError(textBox2, "Должно быть строкой");
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
                MessageBox.Show("Поле Стоимость не может содержать буквы");
                errorProvider1.SetError(textBox3, "Должно быть число");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
                MessageBox.Show("Поле Количество не может содержать буквы");
                errorProvider1.SetError(textBox4, "Должно быть число");
            }
            else
            {
                errorProvider1.Clear();
            }
        }




        public bool post_check()
        {
            adapter = new MySqlDataAdapter("SELECT `№ поставщика` FROM `поставщики` WHERE `Тип поставляемой продукции` = '" + textBox1.Text + "'  AND `№ Поставщика` ='" + Select_Product.selected3 + "'", connection);
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

        public bool otd_check()
        {
            adapter = new MySqlDataAdapter("SELECT `№ отдела` FROM `отделы предприятия` WHERE `Название отдела` = '" + textBox6.Text + "'", connection);
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
                test();
                errorProvider1.Clear();
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {





                                string sql = "Update`поставляемые материалы` set " +
                                $"`Тип материала` = '{textBox1.Text}',  " +
                                $"`Название материала` ='{textBox2.Text}',  " +
                                $"`Стоимость` ='{textBox3.Text}',  " +
                                $"`Кол-во` ='{textBox4.Text}',  " +
                                $"`id Поставщика` ='{nums[0]}',  " +
                                $"`id Отдела` ='{nums[1]}', " +
                                $"`Дата Поставки` ='{dateTimePicker1.Text}' " +
                                $"Where `id поставки`='{primarykey}'";
                                MySqlCommand cmd = new MySqlCommand(sql, connection);
                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    
                                    this.DialogResult = DialogResult.Yes;
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
                }
            }
        }




        //////////////////Переходы///////////////////

        private void exit(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }


        private void textBox5_Click(object sender, EventArgs e)
        {
            DataBank.otch = 0;
            Select_Product sp = new Select_Product();
            this.Hide();
            if (sp.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                textBox5.Text = ((string)Select_Product.selected).ToString();
                textBox1.Text = ((string)Select_Product.selected2).ToString();

            }
            else
            {
                this.Show();
            }
        }
        public void test()
        {
            test1.Text = "";
            test1.Items.Clear();
            adapter = new MySqlDataAdapter("Select `№ Поставщика` from `поставщики` where `Поставщик`='" + textBox5.Text + "'", connection);
            datatable = new DataTable();
            adapter.Fill(datatable);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                nums[0] = ((int)datatable.Rows[i]["№ Поставщика"]);
            }


            test2.Text = "";
            test2.Items.Clear();
            adapter = new MySqlDataAdapter("Select `№ отдела` from `отделы предприятия` where `Название отдела`='" + textBox6.Text + "'", connection);
            datatable = new DataTable();
            adapter.Fill(datatable);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                nums[1] = ((int)datatable.Rows[i]["№ отдела"]);
            }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            DataBank.otch = 0;
            Select_Otd sp = new Select_Otd();
            this.Hide();
            if (sp.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                textBox6.Text = ((string)Select_Otd.selected).ToString();
            }
            else
            {
                this.Show();
            }
        }

    }
}
