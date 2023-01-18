using System;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;


namespace Moya
{
    public partial class Chart_otchet : Form
    {

        public Chart_otchet()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        System.Data.DataTable datatable;
        string[] s = { "Сумма стоимости по всем поставкам от данного поставщика за период",
                        "Сумма стоимости по всем поставкам в данный отдел за период",
                        "Сумма стоимости поставок данного материала за период",
                        "Количество поставок данного материала за период по отделам"};
        string[] d = { "День/Месяц/Год", "Год", "Месяц", "День" };

        string Save;
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
        private void Chart_otchet_Load(object sender, EventArgs e)
        {
            string[] arStr = File.ReadAllLines("settings.txt");
            string ServerTest = DeCrypting(arStr[0]);
            string PortTest = DeCrypting(arStr[1]);
            string UserTest = DeCrypting(arStr[2]);
            string PassTest = DeCrypting(arStr[3]);
            Save = arStr[5];
            date.Text = "День/Месяц/Год";
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
            textBox1.Text = "Федор";
            textBox1.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            button1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            dgv.Visible = false;
            chart1.Visible = false;
            date.Visible = false;
            panel1.Visible = false;
            saving.Visible = false;
            panel2.Visible = false;
            tabl.Text = "Показать\n Таблицу";
            charter.Text = "Показать\nДиаграмму";
            for (int i = 0; i < s.Length; i++)
            {
                select.Items.Add(s[i]);
            }
            adapter = new MySqlDataAdapter("Select distinct `поставщики`.`Поставщик` as `Поставщик` from `поставщики` inner join `поставляемые материалы` on `поставщики`.`№ поставщика`=`поставляемые материалы`.`id поставщика` group by `поставщики`.`Поставщик`; ", connection);
            datatable = new System.Data.DataTable();
            adapter.Fill(datatable);


            //adapter = new MySqlDataAdapter("Select distinct `отделы предприятия`.`Название Отдела` as `Название Отдела` from `отделы предприятия` inner join `поставляемые материалы` on `отделы предприятия`.`№ отдела`=`поставляемые материалы`.`id Отдела` group by `отделы предприятия`.`Название Отдела`", connection);
            //datatable = new System.Data.DataTable();
            //adapter.Fill(datatable);
            //for (int i = 0; i < datatable.Rows.Count; i++)
            //{
            //    comboBox2.Items.Add(datatable.Rows[i]["Название Отдела"]);
            //    comboBox4.Items.Add(datatable.Rows[i]["Название Отдела"]);
            //}

            //adapter = new MySqlDataAdapter("Select distinct `Название материала` from `поставляемые материалы` ", connection);
            //datatable = new System.Data.DataTable();
            //adapter.Fill(datatable);
            //for (int i = 0; i < datatable.Rows.Count; i++)
            //{
            //    comboBox3.Items.Add(datatable.Rows[i]["Название материала"]);
            //}
        }


        private void Chart_otchet_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();

        }


        private void label2_Click(object sender, EventArgs e)
        {
            InboxTB.Text = DataBank.root;
            string res = InboxTB.Text;
            if (res == "4")
            {
                Tab2 f = new Tab2();
                f.Show();
                this.Close();
            }
            if (res == "5")
            {
                OtchControl f = new OtchControl();
                f.Show();
                this.Close();
            }


        }

        private void выйтиИзУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entry form = new Entry();
            form.Show();
            this.Close();
        }
        string ser;
        string sql;
        private void button1_Click(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            errorProvider1.Clear();
            datatable.Clear();
            if (select.Text == s[0])
            {
                if (textBox1.Text != "")
                {
                    datatable.Clear();
                    if (date.Text == d[0])
                    {

                        sql = "SELECT `поставляемые материалы`.`Дата поставки` as `Дата поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                        " where `поставщики`.`Поставщик`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by `поставляемые материалы`.`Дата поставки` order by `поставляемые материалы`.`Дата поставки`";
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));
                            ser = "Сумма стоимости всех поставок от поставщика " + textBox1.Text + " с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;

                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[1])
                    {
                        sql = "SELECT year(`поставляемые материалы`.`Дата поставки`) as `Год поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                        " where `поставщики`.`Поставщик`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by year(`поставляемые материалы`.`Дата поставки`) order by year(`поставляемые материалы`.`Дата поставки`)";
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));
                            ser = "Сумма стоимости всех поставок от поставщика " + textBox1.Text + " по годам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;

                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[2])
                    {
                        sql = "SELECT MONTHNAME(`поставляемые материалы`.`Дата поставки`) as `Месяц поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                        " where `поставщики`.`Поставщик`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by MONTHNAME(`поставляемые материалы`.`Дата поставки`) order by MONTHNAME(`поставляемые материалы`.`Дата поставки`)";
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));
                            ser = "Сумма стоимости всех поставок от поставщика " + textBox1.Text + " по месяцам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;

                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[3])
                    {
                        sql = "SELECT day(`поставляемые материалы`.`Дата поставки`) as `День поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                        " where `поставщики`.`Поставщик`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by day(`поставляемые материалы`.`Дата поставки`) order by day(`поставляемые материалы`.`Дата поставки`)";
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));
                            ser = "Сумма стоимости всех поставок от поставщика " + textBox1.Text + " по дням с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;

                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Не заполнено имя поставщика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorProvider1.SetError(textBox1, "Пустующее поле");
                }

            }



            if (select.Text == s[1])
            {
                if (textBox1.Text != "")
                {


                    if (date.Text == d[0])
                    {
                        datatable.Clear();
                        sql = "SELECT `поставляемые материалы`.`Дата поставки` as `Дата поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела`" +
                        " where `отделы предприятия`.`Название отдела`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by `поставляемые материалы`.`Дата поставки`";
                        ser = "Сумма стоимости всех поставок в отдел " + textBox1.Text + " с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[1])
                    {
                        sql = "SELECT year(`поставляемые материалы`.`Дата поставки`) as `Год поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела`" +
                        " where `отделы предприятия`.`Название отдела`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by year(`поставляемые материалы`.`Дата поставки`) order by year(`поставляемые материалы`.`Дата поставки`)";
                        ser = "Сумма стоимости всех поставок в отдел " + textBox1.Text + " по годам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[2])
                    {
                        sql = "SELECT MONTHNAME(`поставляемые материалы`.`Дата поставки`) as `Месяц поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела`" +
                        " where `отделы предприятия`.`Название отдела`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by MONTHNAME(`поставляемые материалы`.`Дата поставки`) order by MONTHNAME(`поставляемые материалы`.`Дата поставки`)";
                        ser = "Сумма стоимости всех поставок в отдел " + textBox1.Text + " по месяцам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[3])
                    {
                        sql = "SELECT day(`поставляемые материалы`.`Дата поставки`) as `День поставки`, Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела`" +
                        " where `отделы предприятия`.`Название отдела`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  group by day(`поставляемые материалы`.`Дата поставки`) order by day(`поставляемые материалы`.`Дата поставки`)";
                        ser = "Сумма стоимости всех поставок в отдел " + textBox1.Text + " по дням с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Не заполнено название отдела", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorProvider1.SetError(textBox1, "Пустующее поле");
                }



            }



            if (select.Text == s[2])
            {
                if (textBox1.Text != "")
                {

                    if (date.Text == d[0])
                    {
                        datatable.Clear();
                        sql = "SELECT `поставляемые материалы`.`Дата поставки` as `Дата поставки`,Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " where `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by `поставляемые материалы`.`Дата поставки`";
                        ser = "Сумма стоимости поставок материала " + textBox1.Text + " с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[1])
                    {
                        datatable.Clear();
                        sql = "SELECT year(`поставляемые материалы`.`Дата поставки`) as `Год поставки`,Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " where `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by year(`поставляемые материалы`.`Дата поставки`) order by year(`поставляемые материалы`.`Дата поставки`)";
                        ser = "Сумма стоимости поставок материала " + textBox1.Text + " по годам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[2])
                    {
                        sql = "SELECT MONTHNAME(`поставляемые материалы`.`Дата поставки`) as `Месяц поставки`,Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " where `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by MONTHNAME(`поставляемые материалы`.`Дата поставки`) order by MONTHNAME(`поставляемые материалы`.`Дата поставки`)";
                        ser = "Сумма стоимости поставок материала " + textBox1.Text + " по месяцам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (date.Text == d[3])
                    {
                        sql = "SELECT day(`поставляемые материалы`.`Дата поставки`) as `День поставки`,Sum(`поставляемые материалы`.`Стоимость`*`поставляемые материалы`.`Кол-во`) AS `Стоимость Поставки` FROM `поставляемые материалы` " +
                        " where `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by day(`поставляемые материалы`.`Дата поставки`) order by day(`поставляемые материалы`.`Дата поставки`)";
                        ser = "Сумма стоимости поставок материала " + textBox1.Text + " по дням с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                        if (prover(sql) == true)
                        {
                            panel1.Visible = true;
                            panel2.Visible = true;
                            chart1.Series.Clear();
                            adapter = new MySqlDataAdapter(sql, connection);
                            datatable = new System.Data.DataTable();

                            adapter.Fill(datatable);
                            datatable.Columns.Add("Общая Стоимость Поставок", typeof(Int32));


                            int sum = 0;
                            dgv.DataSource = datatable;
                            dgv.Visible = true;
                            chart1.Series.Add(ser);
                            for (int i = 0; i < datatable.Rows.Count; i++)
                            {
                                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                                chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
                            }
                            dgv.Rows[0].Cells[2].Value = sum;
                            chart1.DataSource = datatable;
                            chart1.DataBind();
                            saving.Visible = true;
                        }
                        if (prover(sql) == false)
                        {
                            panel1.Visible = false;
                            panel2.Visible = false;
                            dgv.Visible = false;
                            chart1.Visible = false;
                            saving.Visible = false;
                            MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Не заполнено название материала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorProvider1.SetError(textBox1, "Пустующее поле");
                }



            }




            if (select.Text == s[3])
            {
                int err = 0;
                if (textBox2.Text != "")
                {
                    errorProvider1.Clear();
                    if (textBox1.Text != "")
                    {
                        errorProvider1.Clear();
                        if (date.Text == d[0])
                        {
                            datatable.Clear();
                            sql = "SELECT `поставляемые материалы`.`Дата поставки` as `Дата поставки`,`отделы предприятия`.`Название отдела`,`поставляемые материалы`.`Название материала`,Sum(`поставляемые материалы`.`Кол-во`) AS `Количество Поставок`  FROM `поставляемые материалы` " +
                            " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                            " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела` " +
                            " where `отделы предприятия`.`Название отдела`='" + textBox2.Text + "' and `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by `поставляемые материалы`.`Дата поставки`";
                            ser = "Количество поставок материала " + textBox1.Text + " в отдел " + textBox2.Text + " с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                            if (prover(sql) == true)
                            {
                                panel1.Visible = true;
                                panel2.Visible = true;
                                chart1.Series.Clear();
                                adapter = new MySqlDataAdapter(sql, connection);
                                datatable = new System.Data.DataTable();

                                adapter.Fill(datatable);
                                datatable.Columns.Add("Общее Количество Поставок", typeof(Int32));


                                int sum = 0;
                                dgv.DataSource = datatable;

                                dgv.Visible = true;
                                chart1.Series.Add(ser);
                                for (int i = 0; i < datatable.Rows.Count; i++)
                                {
                                    sum += Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString());
                                    chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[3].Value.ToString());
                                }
                                dgv.Rows[0].Cells[4].Value = sum;
                                chart1.DataSource = datatable;
                                chart1.DataBind();
                                saving.Visible = true;
                            }
                            if (prover(sql) == false)
                            {
                                panel1.Visible = false;
                                panel2.Visible = false;
                                dgv.Visible = false;
                                chart1.Visible = false;
                                saving.Visible = false;
                                MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        if (date.Text == d[1])
                        {
                            datatable.Clear();
                            sql = "SELECT year(`поставляемые материалы`.`Дата поставки`) as `Год поставки`,`отделы предприятия`.`Название отдела`,`поставляемые материалы`.`Название материала`,Sum(`поставляемые материалы`.`Кол-во`) AS `Количество Поставок`  FROM `поставляемые материалы` " +
                            " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                            " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела` " +
                            " where `отделы предприятия`.`Название отдела`='" + textBox2.Text + "' and `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by year(`поставляемые материалы`.`Дата поставки`) order by year(`поставляемые материалы`.`Дата поставки`)";
                            ser = "Количество поставок материала " + textBox1.Text + " в отдел " + textBox2.Text + " по годам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                            if (prover(sql) == true)
                            {
                                panel1.Visible = true;
                                panel2.Visible = true;
                                chart1.Series.Clear();
                                adapter = new MySqlDataAdapter(sql, connection);
                                datatable = new System.Data.DataTable();

                                adapter.Fill(datatable);
                                datatable.Columns.Add("Общее Количество Поставок", typeof(Int32));


                                int sum = 0;
                                dgv.DataSource = datatable;
                                dgv.Visible = true;
                                chart1.Series.Add(ser);
                                for (int i = 0; i < datatable.Rows.Count; i++)
                                {
                                    sum += Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString());
                                    chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[3].Value.ToString());
                                }
                                dgv.Rows[0].Cells[4].Value = sum;
                                chart1.DataSource = datatable;
                                chart1.DataBind();
                                saving.Visible = true;
                            }
                            if (prover(sql) == false)
                            {
                                panel1.Visible = false;
                                panel2.Visible = false;
                                dgv.Visible = false;
                                chart1.Visible = false;
                                saving.Visible = false;
                                MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        if (date.Text == d[2])
                        {
                            datatable.Clear();
                            sql = "SELECT MONTHNAME(`поставляемые материалы`.`Дата поставки`) as `Месяц поставки`,`отделы предприятия`.`Название отдела`,`поставляемые материалы`.`Название материала`,Sum(`поставляемые материалы`.`Кол-во`) AS `Количество Поставок`  FROM `поставляемые материалы` " +
                            " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                            " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела` " +
                            " where `отделы предприятия`.`Название отдела`='" + textBox2.Text + "' and `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by MONTHNAME(`поставляемые материалы`.`Дата поставки`) order by MONTHNAME(`поставляемые материалы`.`Дата поставки`)";
                            ser = "Количество поставок материала " + textBox1.Text + " в отдел " + textBox2.Text + " по месяцам с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                            if (prover(sql) == true)
                            {
                                panel1.Visible = true;
                                panel2.Visible = true;
                                chart1.Series.Clear();
                                adapter = new MySqlDataAdapter(sql, connection);
                                datatable = new System.Data.DataTable();

                                adapter.Fill(datatable);
                                datatable.Columns.Add("Общее Количество Поставок", typeof(Int32));


                                int sum = 0;
                                dgv.DataSource = datatable;
                                dgv.Visible = true;
                                chart1.Series.Add(ser);
                                for (int i = 0; i < datatable.Rows.Count; i++)
                                {
                                    sum += Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString());
                                    chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[3].Value.ToString());
                                }
                                dgv.Rows[0].Cells[4].Value = sum;
                                chart1.DataSource = datatable;
                                chart1.DataBind();
                                saving.Visible = true;
                            }
                            if (prover(sql) == false)
                            {
                                panel1.Visible = false;
                                panel2.Visible = false;
                                dgv.Visible = false;
                                chart1.Visible = false;
                                saving.Visible = false;
                                MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        if (date.Text == d[3])
                        {
                            datatable.Clear();
                            sql = "SELECT day(`поставляемые материалы`.`Дата поставки`) as `День поставки`,`отделы предприятия`.`Название отдела`,`поставляемые материалы`.`Название материала`,Sum(`поставляемые материалы`.`Кол-во`) AS `Количество Поставок`  FROM `поставляемые материалы` " +
                            " inner join `поставщики` on `поставляемые материалы`.`id поставщика`=`поставщики`.`№ поставщика`" +
                            " inner join `отделы предприятия` on `поставляемые материалы`.`id Отдела`=`отделы предприятия`.`№ Отдела` " +
                            " where `отделы предприятия`.`Название отдела`='" + textBox2.Text + "' and `поставляемые материалы`.`Название материала`= '" + textBox1.Text + "' and `Дата поставки` between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' group by day(`поставляемые материалы`.`Дата поставки`) order by day(`поставляемые материалы`.`Дата поставки`)";
                            ser = "Количество поставок материала " + textBox1.Text + " в отдел " + textBox2.Text + " по дням с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text;
                            if (prover(sql) == true)
                            {
                                panel1.Visible = true;
                                panel2.Visible = true;
                                chart1.Series.Clear();
                                adapter = new MySqlDataAdapter(sql, connection);
                                datatable = new System.Data.DataTable();

                                adapter.Fill(datatable);
                                datatable.Columns.Add("Общее Количество Поставок", typeof(Int32));


                                int sum = 0;
                                dgv.DataSource = datatable;
                                dgv.Visible = true;
                                chart1.Series.Add(ser);
                                for (int i = 0; i < datatable.Rows.Count; i++)
                                {
                                    sum += Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString());
                                    chart1.Series[ser].Points.AddXY(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[3].Value.ToString());
                                }
                                dgv.Rows[0].Cells[4].Value = sum;
                                chart1.DataSource = datatable;
                                chart1.DataBind();
                                saving.Visible = true;
                            }
                            if (prover(sql) == false)
                            {
                                panel1.Visible = false;
                                panel2.Visible = false;
                                dgv.Visible = false;
                                chart1.Visible = false;
                                saving.Visible = false;
                                MessageBox.Show("Невозможно создать отчет по заданным параметрам", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                    }
                    else
                    {
                        err++;
                        errorProvider1.SetError(textBox1, "Пустующее поле");
                    }
                }
                else
                {
                    err++;
                    errorProvider1.SetError(textBox2, "Пустующее поле");
                }
                if (err != 0)
                {
                    MessageBox.Show("Пустое поле формирования отчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        public bool prover(string test)
        {
            adapter = new MySqlDataAdapter(test, connection);
            datatable = new System.Data.DataTable();
            adapter.Fill(datatable);
            if (datatable.Rows.Count <= 0)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        //////////////////Взаимодействие///////////////////

        //////////////////Действия///////////////////
        private void select_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (select.Text == s[0])
            {
                label10.Visible = true;
                date.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox2.Visible = false;
                textBox1.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label7.Visible = true;
                label6.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            if (select.Text == s[1])
            {
                label10.Visible = true;
                date.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox2.Visible = false;
                textBox1.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                label7.Visible = false;
                label6.Visible = true;
                button1.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
            }
            if (select.Text == s[2])
            {
                label10.Visible = true;
                date.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox2.Visible = false;
                textBox1.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                label7.Visible = false;
                label6.Visible = false;
                button1.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label8.Visible = true;
                label9.Visible = false;
            }
            if (select.Text == s[3])
            {
                label10.Visible = true;
                date.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox2.Visible = true;
                textBox1.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                label7.Visible = false;
                label6.Visible = false;
                button1.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label8.Visible = true;

                label9.Visible = true;
            }

        }



        private void save(object sender, EventArgs e)
        {

            Excel.Application ExcelApp = new Excel.Application();
            object misvalue = System.Reflection.Missing.Value;
            Excel.Workbook xlworkbook = ExcelApp.Workbooks.Add(misvalue);
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlworkbook.Worksheets.get_Item(1);
            ExcelApp.Columns.ColumnWidth = 25;

            if (select.Text == s[0])
            {
                if (date.Text == d[0])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "Дата Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[1])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "Год Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[2])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "Месяц Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[3])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "День Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }

                int s = 0;


                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        ExcelApp.Cells[j + 3, i + 1] = (dgv[i, j].Value).ToString();
                        s = j + 3;
                    }
                }

                ChartObjects xlCharts = (ChartObjects)xlworksheet.ChartObjects(Type.Missing);
                ChartObject myChart = (ChartObject)xlCharts.Add(410, 0, 550, 350);
                Chart chart = myChart.Chart;
                SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
                Series series = seriesCollection.NewSeries();

                series.XValues = xlworksheet.get_Range("A3", "A" + s);
                series.Values = xlworksheet.get_Range("B3", "B" + s);
                series.Name = ser;
                ExcelApp.Visible = true;


            }

            if (select.Text == s[1])
            {
                if (date.Text == d[0])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();

                    ExcelApp.Cells[2, 1] = "Дата Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[1])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "Год Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[2])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "Месяц Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[3])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "День Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }



                int s = 0;


                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        ExcelApp.Cells[j + 3, i + 1] = (dgv[i, j].Value).ToString();
                        s = j + 3;
                    }
                }

                ChartObjects xlCharts = (ChartObjects)xlworksheet.ChartObjects(Type.Missing);
                ChartObject myChart = (ChartObject)xlCharts.Add(410, 0, 550, 350);
                Chart chart = myChart.Chart;
                SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
                Series series = seriesCollection.NewSeries();
                series.XValues = xlworksheet.get_Range("A3", "A" + s);
                series.Values = xlworksheet.get_Range("B3", "B" + s);
                series.Name = ser;
                ExcelApp.Visible = true;

            }


            if (select.Text == s[2])
            {
                if (date.Text == d[0])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();

                    ExcelApp.Cells[2, 1] = "Дата Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[1])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "Год Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[2])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "Месяц Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }
                if (date.Text == d[3])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[2, 1] = "День Поставки";
                    ExcelApp.Cells[2, 2] = "Стоимость Поставки";
                    ExcelApp.Cells[2, 3] = "Общая Стоимость Поставок";
                }



                int s = 0;


                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        ExcelApp.Cells[j + 3, i + 1] = (dgv[i, j].Value).ToString();
                        s = j + 3;
                    }
                }

                ChartObjects xlCharts = (ChartObjects)xlworksheet.ChartObjects(Type.Missing);
                ChartObject myChart = (ChartObject)xlCharts.Add(410, 0, 550, 350);
                Chart chart = myChart.Chart;
                SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
                Series series = seriesCollection.NewSeries();
                series.XValues = xlworksheet.get_Range("A3", "A" + s);
                series.Values = xlworksheet.get_Range("B3", "B" + s);
                series.Name = ser;
                ExcelApp.Visible = true;

            }

            if (select.Text == s[3])
            {
                if (date.Text == d[0])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 5]].Merge();

                    ExcelApp.Cells[2, 1] = "Дата Поставки";
                    ExcelApp.Cells[2, 2] = "Название отдела";
                    ExcelApp.Cells[2, 3] = "Название материала";
                    ExcelApp.Cells[2, 4] = "Количество Поставок";
                    ExcelApp.Cells[2, 5] = "Общее Количество поставок";
                }
                if (date.Text == d[1])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 5]].Merge();
                    ExcelApp.Cells[2, 1] = "Год Поставки";
                    ExcelApp.Cells[2, 2] = "Название отдела";
                    ExcelApp.Cells[2, 3] = "Название материала";
                    ExcelApp.Cells[2, 4] = "Количество Поставок";
                    ExcelApp.Cells[2, 5] = "Общее Количество поставок";
                }
                if (date.Text == d[2])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 5]].Merge();
                    ExcelApp.Cells[2, 1] = "Месяц Поставки";
                    ExcelApp.Cells[2, 2] = "Название отдела";
                    ExcelApp.Cells[2, 3] = "Название материала";
                    ExcelApp.Cells[2, 4] = "Количество Поставок";
                    ExcelApp.Cells[2, 5] = "Общее Количество поставок";
                }
                if (date.Text == d[3])
                {
                    ExcelApp.Cells[1, 1] = ser;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 5]].Merge();
                    ExcelApp.Cells[2, 1] = "День Поставки";
                    ExcelApp.Cells[2, 2] = "Название отдела";
                    ExcelApp.Cells[2, 3] = "Название материала";
                    ExcelApp.Cells[2, 4] = "Количество Поставок";
                    ExcelApp.Cells[2, 5] = "Общее Количество поставок";
                }



                int s = 0;


                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        ExcelApp.Cells[j + 3, i + 1] = (dgv[i, j].Value).ToString();
                        s = j + 3;
                    }
                }
                ChartObjects xlCharts = (ChartObjects)xlworksheet.ChartObjects(Type.Missing);
                ChartObject myChart = (ChartObject)xlCharts.Add(682, 0, 550, 350);
                Chart chart = myChart.Chart;
                SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
                Series series = seriesCollection.NewSeries();
                series.XValues = xlworksheet.get_Range("A3", "A" + s);
                series.Values = xlworksheet.get_Range("D3", "D" + s);
                series.Name = ser;
                ExcelApp.Visible = true;
                ExcelApp.Quit();

            }
        }

        private void show_tabl(object sender, EventArgs e)
        {
            dgv.Visible = true;
            chart1.Visible = false;
        }

        private void chart_show(object sender, EventArgs e)
        {
            dgv.Visible = false;
            chart1.Visible = true;
        }

        private void изменитьДанныеУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserData form = new UserData();
            form.Owner = this;
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

        private void textBox1_Click(object sender, EventArgs e)
        {

            if (select.Text == s[0])
            {
                DataBank.otch = 1;
                Select_Product sp = new Select_Product();
                this.Hide();
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    textBox1.Text = ((string)Select_Product.selected).ToString();

                }
                else
                {
                    this.Show();
                }
            }
            if (select.Text == s[1])
            {
                DataBank.otch = 2;
                Select_Product sp = new Select_Product();
                this.Hide();
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    textBox1.Text = ((string)Select_Product.selected).ToString();

                }
                else
                {
                    this.Show();
                }
            }
            if (select.Text == s[2])
            {
                DataBank.otch = 3;
                Select_Product sp = new Select_Product();
                this.Hide();
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    textBox1.Text = ((string)Select_Product.selected).ToString();

                }
                else
                {
                    this.Show();
                }
            }
            if (select.Text == s[3])
            {
                DataBank.otch = 3;
                Select_Product sp = new Select_Product();
                this.Hide();
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    textBox1.Text = ((string)Select_Product.selected).ToString();

                }
                else
                {
                    this.Show();
                }
            }

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (select.Text == s[3])
            {
                DataBank.otch = 2;
                Select_Product sp = new Select_Product();
                this.Hide();
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    textBox2.Text = ((string)Select_Product.selected).ToString();

                }
                else
                {
                    this.Show();
                }
            }
        }
    }
}
