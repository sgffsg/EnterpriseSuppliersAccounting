﻿using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class Add3 : Form
    {
        public Add3()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable datatable;
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
        private void Add3_Load(object sender, EventArgs e)
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
        }

        private void Add3_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }


        //////////////////Проверки///////////////////
        public bool Check_void()
        {
            int error_count = 0;
            errorProvider1.Clear();
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                error_count = 1;
                errorProvider1.SetError(textBox1, "Не может быть пустым");
            }
            if (textBox3.Text == "" || textBox1.Text == " ")
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Поставщик не может содержать цифры");
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
                MessageBox.Show("Поле Тип поставляемой продукции не может содержать цифры");
                errorProvider1.SetError(textBox3, "Должно быть строкой");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        public bool repeat_check()
        {
            adapter = new MySqlDataAdapter("SELECT `№ поставщика` FROM `поставщики` WHERE `Поставщик` = '" + textBox1.Text + "' AND `Тип поставляемой продукции` ='" + textBox3.Text + "'", connection);
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
        private void create(object sender, EventArgs e)
        {
            if (Check_void() == true)
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выполнить эту операцию ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (repeat_check())
                    {
                        errorProvider1.Clear();
                        String sql = "Insert into `поставщики` (`Поставщик`,`Тип поставляемой продукции`) VALUES " +
                               "(" +
                                "'" + textBox1.Text + "'," +
                                "'" + textBox3.Text + "'" +
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
                    else
                    {
                        MessageBox.Show("Такая Запись уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.No;
                    this.Close();

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