
namespace Moya
{
    partial class Tab2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tab2));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sCPBD30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзУчетнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.spData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_bd = new System.Windows.Forms.ToolStripStatusLabel();
            this.col = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InboxTB = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::Moya.Properties.Resources.Del;
            this.button2.Location = new System.Drawing.Point(159, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 87);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.delete);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::Moya.Properties.Resources.Add;
            this.button1.Location = new System.Drawing.Point(24, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 87);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.add);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = global::Moya.Properties.Resources.Postav;
            this.button4.Location = new System.Drawing.Point(775, 337);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 52);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.goto_postav);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImage = global::Moya.Properties.Resources.Otdel;
            this.button5.Location = new System.Drawing.Point(775, 395);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 52);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.goto_otd);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::Moya.Properties.Resources._13;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sCPBD30ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 29);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sCPBD30ToolStripMenuItem
            // 
            this.sCPBD30ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sCPBD30ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.sCPBD30ToolStripMenuItem.Image = global::Moya.Properties.Resources.png_transparent_google_chrome_computer_icons_web_browser_desktop_chrome;
            this.sCPBD30ToolStripMenuItem.Name = "sCPBD30ToolStripMenuItem";
            this.sCPBD30ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.sCPBD30ToolStripMenuItem.Text = "    ";
            this.sCPBD30ToolStripMenuItem.Click += new System.EventHandler(this.sCPBD30ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem,
            this.выйтиИзУчетнойЗаписиToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 25);
            this.toolStripMenuItem1.Text = "Учетная запись";
            // 
            // изменитьДанныеУчетнойЗаписиToolStripMenuItem
            // 
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem.Name = "изменитьДанныеУчетнойЗаписиToolStripMenuItem";
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem.Text = "Параметры Учетной записи";
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem.Click += new System.EventHandler(this.изменитьДанныеУчетнойЗаписиToolStripMenuItem_Click);
            // 
            // выйтиИзУчетнойЗаписиToolStripMenuItem
            // 
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Name = "выйтиИзУчетнойЗаписиToolStripMenuItem";
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Text = "Выйти из учетной записи";
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзУчетнойЗаписиToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::Moya.Properties.Resources._15;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spData,
            this.toolStripStatusLabel1,
            this.status,
            this.status_bd,
            this.col,
            this.tool});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(929, 26);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spData
            // 
            this.spData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spData.ForeColor = System.Drawing.Color.White;
            this.spData.Name = "spData";
            this.spData.Size = new System.Drawing.Size(42, 21);
            this.spData.Text = "Data";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(126, 21);
            this.toolStripStatusLabel1.Text = "Create by Sakata";
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(30, 21);
            this.status.Text = "     ";
            // 
            // status_bd
            // 
            this.status_bd.ForeColor = System.Drawing.Color.Lime;
            this.status_bd.Name = "status_bd";
            this.status_bd.Size = new System.Drawing.Size(0, 21);
            // 
            // col
            // 
            this.col.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.col.ForeColor = System.Drawing.Color.Black;
            this.col.Name = "col";
            this.col.Size = new System.Drawing.Size(90, 21);
            this.col.Text = "                    ";
            // 
            // tool
            // 
            this.tool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tool.ForeColor = System.Drawing.Color.Black;
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(50, 21);
            this.tool.Text = "          ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(906, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 22);
            this.label4.TabIndex = 42;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.exit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(367, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Поставляемые материалы";
            // 
            // InboxTB
            // 
            this.InboxTB.AutoSize = true;
            this.InboxTB.Location = new System.Drawing.Point(454, 384);
            this.InboxTB.Name = "InboxTB";
            this.InboxTB.Size = new System.Drawing.Size(0, 13);
            this.InboxTB.TabIndex = 47;
            this.InboxTB.Visible = false;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(394, 343);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(0, 13);
            this.username.TabIndex = 48;
            this.username.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 56;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(908, 295);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.izm);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(164, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 25);
            this.label2.TabIndex = 87;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.search_null);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Impact", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(38, 337);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 28);
            this.textBox1.TabIndex = 85;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 438);
            this.panel3.TabIndex = 89;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(919, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 438);
            this.panel1.TabIndex = 88;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(935, 371);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(30, 26);
            this.dateTimePicker1.TabIndex = 90;
            this.dateTimePicker1.Value = new System.DateTime(2002, 1, 20, 0, 0, 0, 0);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.DarkCyan;
            this.button3.Location = new System.Drawing.Point(414, 350);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 67);
            this.button3.TabIndex = 5;
            this.button3.Text = "Сформировать Отчет";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Tab2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Moya.Properties.Resources._13;
            this.ClientSize = new System.Drawing.Size(929, 493);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.username);
            this.Controls.Add(this.InboxTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Tab2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поставляемые материалы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tab2_FormClosing);
            this.Load += new System.EventHandler(this.Tab2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзУчетнойЗаписиToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel spData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label InboxTB;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel status_bd;
        private System.Windows.Forms.ToolStripStatusLabel col;
        private System.Windows.Forms.ToolStripStatusLabel tool;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem sCPBD30ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеУчетнойЗаписиToolStripMenuItem;
        private System.Windows.Forms.Button button3;
    }
}