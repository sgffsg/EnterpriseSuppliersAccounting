
namespace Moya
{
    partial class AdminControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminControl));
            this.username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sCPBD30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзУчетнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.spData = new System.Windows.Forms.ToolStripStatusLabel();
            this.AboutMe = new System.Windows.Forms.ToolStripStatusLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.InboxTB = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(414, 237);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(0, 13);
            this.username.TabIndex = 50;
            this.username.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(906, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 22);
            this.label2.TabIndex = 65;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.exit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(345, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "Панель Администратора";
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
            this.menuStrip1.TabIndex = 63;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(126, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 67);
            this.button1.TabIndex = 1;
            this.button1.Text = "Управление Пользователями";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.users_control);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::Moya.Properties.Resources._14;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spData,
            this.AboutMe});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(929, 26);
            this.statusStrip1.TabIndex = 69;
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
            // AboutMe
            // 
            this.AboutMe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutMe.ForeColor = System.Drawing.Color.White;
            this.AboutMe.Name = "AboutMe";
            this.AboutMe.Size = new System.Drawing.Size(126, 21);
            this.AboutMe.Text = "Create by Sakata";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.LightGray;
            this.button3.Location = new System.Drawing.Point(573, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 67);
            this.button3.TabIndex = 3;
            this.button3.Text = "Восстановление из дампа";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.recovery_bd);
            // 
            // InboxTB
            // 
            this.InboxTB.AutoSize = true;
            this.InboxTB.Location = new System.Drawing.Point(485, 264);
            this.InboxTB.Name = "InboxTB";
            this.InboxTB.Size = new System.Drawing.Size(0, 13);
            this.InboxTB.TabIndex = 70;
            this.InboxTB.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(351, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 67);
            this.button2.TabIndex = 2;
            this.button2.Text = "Резервное копирование";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.backup);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 438);
            this.panel3.TabIndex = 88;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.dateTimePicker3);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(919, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 438);
            this.panel1.TabIndex = 87;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(16, 358);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(51, 20);
            this.dateTimePicker3.TabIndex = 92;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(16, 308);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(61, 26);
            this.dateTimePicker2.TabIndex = 89;
            this.dateTimePicker2.Value = new System.DateTime(2021, 2, 8, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(935, 305);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(49, 26);
            this.dateTimePicker1.TabIndex = 91;
            this.dateTimePicker1.TabStop = false;
            this.dateTimePicker1.Value = new System.DateTime(2002, 1, 20, 0, 0, 0, 0);
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Moya.Properties.Resources._16;
            this.ClientSize = new System.Drawing.Size(929, 493);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.InboxTB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminControl_FormClosing);
            this.Load += new System.EventHandler(this.AdminControl_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзУчетнойЗаписиToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel spData;
        private System.Windows.Forms.ToolStripStatusLabel AboutMe;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label InboxTB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem sCPBD30ToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеУчетнойЗаписиToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
    }
}