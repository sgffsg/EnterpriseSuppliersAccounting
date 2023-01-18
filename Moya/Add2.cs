using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class Add2 : Form
    {
        public Add2()
        {
            InitializeComponent();
        }
        MySqlDataAdapter adapter;
        DataTable datatable;
        MySqlConnection connection;
        int[] nums = new int[2];
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

        private void Add2_Load(object sender, EventArgs e)
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
            dateTimePicker1.Text = "";



        }
        private void Add2_FormClosing(object sender, FormClosingEventArgs e)
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
            adapter = new MySqlDataAdapter("SELECT `№ поставщика` FROM `поставщики` WHERE `Тип поставляемой продукции` = '" + textBox1.Text + "'  AND `№ Поставщика` ='" + nums[0] + "'", connection);
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
        //////////////////Действие///////////////////

        private void create(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Check_void() == true)
            {

                errorProvider1.Clear();
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                            String sql = "Insert into `поставляемые материалы`(`Тип материала`,`Название материала`,`Стоимость`,`Кол-во`,`id Поставщика`,`id Отдела`,`Дата поставки`) VALUES " +
                            "(" +
                            "'" + textBox1.Text + "'," +
                            "'" + textBox2.Text + "'," +
                            "'" + textBox3.Text + "'," +
                            "'" + textBox4.Text + "'," +
                            "'" + Select_Product.selected3 + "'," +
                            "'" + Select_Otd.selected3 + "'," +
                            "'" + dateTimePicker1.Text + "'" +
                            ")";
                            MySqlCommand k = new MySqlCommand(sql, connection);
                            try
                            {
                                k.ExecuteNonQuery();
                                MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //////////////////Переход///////////////////

        private void exit(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
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
