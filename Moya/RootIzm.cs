using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Moya
{
    public partial class RootIzm : Form
    {
        public RootIzm()
        {
            InitializeComponent();     
        }
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable datatable;
        string primarykey;
        string[] roots = new string[] { "0", "1", "2", "3", "4", "5" };
        string safe;

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
        private void RootIzm_Load(object sender, EventArgs e)
        {
            primarykey = ((RootAdmin)this.Owner).dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = ((RootAdmin)this.Owner).dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = ((RootAdmin)this.Owner).dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = ((RootAdmin)this.Owner).dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = ((RootAdmin)this.Owner).dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = ((RootAdmin)this.Owner).dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dateTimePicker1.Text = ((RootAdmin)this.Owner).dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            safe = textBox4.Text;
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

                for (int i = 0; i < roots.Length; i++)
                {
                    comboBox1.Items.Add(roots[i]);
                }
            }
            catch
            {
                MessageBox.Show("Не удалось установить соединение С БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }

        private void RootIzm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }




        //////////////////Проверки///////////////////
        public bool zapros()
        {
            if (textBox4.Text == safe)
            {
                return true;
            }
            else
            {
                adapter = new MySqlDataAdapter("SELECT `idПользователя` FROM `пользователи` WHERE `Логин` = '" + textBox4.Text + "'", connection);
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

        }


        public bool Check_void()
        {
            string CreateLogin = textBox4.Text;
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
            if (textBox4.Text == "" || textBox4.Text == " ")
            {
                errorProvider1.SetError(textBox4, "Не может быть пустым");
                error_count = 1;
            }
            if (comboBox1.Text != "0")
            {
                if (comboBox1.Text != "1")
                {
                    if (comboBox1.Text != "2")
                    {
                        if (comboBox1.Text != "3")
                        {
                            if (comboBox1.Text != "4")
                            {
                                if (comboBox1.Text != "5")
                                {
                                    MessageBox.Show("Выберите существующее значение Уровня Доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    errorProvider1.SetError(comboBox1, "Выберите существуещее значение");
                                    error_count = 1;
                                }
                            }
                        }
                    }
                }


            }
            if (comboBox1.Text == "" || comboBox1.Text == " ")
            {
                MessageBox.Show("Поле Уровень Доступа не может быть пустым");
                errorProvider1.SetError(comboBox1, "Не может быть пустым");
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Фамилия не может содержать цифры");
                errorProvider1.SetError(textBox1, "Должно быть строкой");
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
                MessageBox.Show("Поле Имя не может содержать цифры");
                errorProvider1.SetError(textBox1, "Должно быть строкой");
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
                MessageBox.Show("Поле Отчество не может содержать цифры");
                errorProvider1.SetError(textBox1, "Должно быть строкой");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        //////////////////Взаимодействие///////////////////

        //////////////////Действия///////////////////
        private void izm(object sender, EventArgs e)
        {
            if (Check_void() == true)
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (zapros())
                    {
                        string sql = "Update `moya`.`пользователи` set " +
                                     $"`Фамилия` ='{textBox1.Text}',  " +
                                     $"`Имя` ='{textBox2.Text}',  " +
                                     $"`Отчество` ='{textBox3.Text}',  " +
                                     $"`Логин` = '{textBox4.Text}',  " +
                                     $"`Уровень Доступа` ='{comboBox1.Text}',  " +
                                     $"`День Рождения` ='{dateTimePicker1.Text}'  " +
                                     $"Where (`idПользователя`='{primarykey}')";
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
                    else
                    {
                        MessageBox.Show("Введенный логин уже занят другим пользователем!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.No;
                }
            }
        }
        //////////////////Переходы///////////////////
        private void label4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void sbros(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("     Вы действительно хотите \nСбросить пароль этого пользователя ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string pas=Crypting("qwerty12345");
                    string sql = "Update `moya`.`пользователи` set " +
                                 $"`Пароль` ='{pas}'  " +
                                 $"Where (`idПользователя`='{primarykey}')";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    MessageBox.Show("     Пароль пользователя успешно сброшен.\nСообщите пользователю об сбросе пароля до       стандартного qwerty12345.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось изменить данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            
        }
    }
}
