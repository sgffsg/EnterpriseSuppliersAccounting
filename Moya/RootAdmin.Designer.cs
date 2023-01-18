
namespace Moya
{
    partial class RootAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RootAdmin));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.spData = new System.Windows.Forms.ToolStripStatusLabel();
            this.AboutMe = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.col = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sCPBD30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеУчетнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзУчетнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.username = new System.Windows.Forms.Label();
            this.InboxTB = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 56;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(908, 273);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.user_izm);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::Moya.Properties.Resources._15;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spData,
            this.AboutMe,
            this.status,
            this.col,
            this.tool});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(929, 26);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spData
            // 
            this.spData.BackColor = System.Drawing.Color.Transparent;
            this.spData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spData.ForeColor = System.Drawing.Color.White;
            this.spData.Name = "spData";
            this.spData.Size = new System.Drawing.Size(42, 21);
            this.spData.Text = "Data";
            // 
            // AboutMe
            // 
            this.AboutMe.BackColor = System.Drawing.Color.Transparent;
            this.AboutMe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutMe.ForeColor = System.Drawing.Color.Black;
            this.AboutMe.Name = "AboutMe";
            this.AboutMe.Size = new System.Drawing.Size(126, 21);
            this.AboutMe.Text = "Create by Sakata";
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(124, 21);
            this.status.Text = "Create by Sgffsg";
            // 
            // col
            // 
            this.col.BackColor = System.Drawing.Color.Transparent;
            this.col.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.col.ForeColor = System.Drawing.Color.Black;
            this.col.Name = "col";
            this.col.Size = new System.Drawing.Size(90, 21);
            this.col.Text = "                    ";
            // 
            // tool
            // 
            this.tool.BackColor = System.Drawing.Color.Transparent;
            this.tool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tool.ForeColor = System.Drawing.Color.Black;
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(50, 21);
            this.tool.Text = "          ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(363, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Управление пользователями";
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
            this.label4.TabIndex = 57;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.exit);
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
            this.menuStrip1.TabIndex = 56;
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
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(751, 319);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(0, 13);
            this.username.TabIndex = 60;
            this.username.Visible = false;
            // 
            // InboxTB
            // 
            this.InboxTB.AutoSize = true;
            this.InboxTB.Location = new System.Drawing.Point(811, 360);
            this.InboxTB.Name = "InboxTB";
            this.InboxTB.Size = new System.Drawing.Size(0, 13);
            this.InboxTB.TabIndex = 59;
            this.InboxTB.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Moya.Properties.Resources.Screenshot_2;
            this.panel1.Location = new System.Drawing.Point(395, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 170);
            this.panel1.TabIndex = 61;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::Moya.Properties.Resources.add_user;
            this.button2.Location = new System.Drawing.Point(31, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 66);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.user_add);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::Moya.Properties.Resources.del_user;
            this.button3.Location = new System.Drawing.Point(164, 350);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 66);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.del_user);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::Moya.Properties.Resources.back4;
            this.button1.Location = new System.Drawing.Point(796, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.back);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(919, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 438);
            this.panel2.TabIndex = 87;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(935, 347);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(53, 26);
            this.dateTimePicker1.TabIndex = 91;
            this.dateTimePicker1.Value = new System.DateTime(2002, 1, 20, 0, 0, 0, 0);
            // 
            // RootAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Moya.Properties.Resources._13;
            this.ClientSize = new System.Drawing.Size(929, 493);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.username);
            this.Controls.Add(this.InboxTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RootAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RootAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RootAdmin_FormClosing);
            this.Load += new System.EventHandler(this.RootAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel spData;
        private System.Windows.Forms.ToolStripStatusLabel AboutMe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзУчетнойЗаписиToolStripMenuItem;
        private System.Windows.Forms.Label username;
        public System.Windows.Forms.Label InboxTB;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripStatusLabel col;
        private System.Windows.Forms.ToolStripStatusLabel tool;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem sCPBD30ToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеУчетнойЗаписиToolStripMenuItem;
    }
}