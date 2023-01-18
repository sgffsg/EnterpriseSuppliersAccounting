using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Moya
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void start_Load(object sender, EventArgs e)
        {
            
        }



        //////////////////Проверки///////////////////

        private void begin(object sender, EventArgs e)
        {
            if (File.Exists("settings.txt"))
            {
                string[] arStr = File.ReadAllLines("settings.txt");
                
       
                if (arStr.Length == 7)
                    {
                    this.Hide();
                        Entry f = new Entry();
                        f.Show();
                        this.Hide();
                    }
                else
                    {
                        
                        this.Hide();
                        Menu f = new Menu();
                        f.Show();
                        this.Hide();
                    }              
            }
            else
            {
                this.Hide();
                Menu f = new Menu();
                f.Show();
                this.Hide();
            }
        }
        //////////////////Переходы///////////////////




        private void exit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void sCPBD30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramm f = new AboutProgramm();
            f.Show();
        }

        private void сброситьНастройкиПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
