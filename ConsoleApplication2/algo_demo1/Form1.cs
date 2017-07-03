using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using ClassLibrary1;

namespace algo_demo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.ShowDialog();
            string file_name = op1.FileName;
            if (file_name == null || file_name == "")
            {
                MessageBox.Show("File not selected!!","ERROR");
            }
            else
            {
                Form2 fm = new Form2(file_name);
                fm.Show();
                this.Hide();
            }
        }

        private void btnopenfolder_Click_1(object sender, EventArgs e)
        {
            int folder_mode = 1;
            FolderBrowserDialog fb1 = new FolderBrowserDialog();
            fb1.ShowDialog();
            string fpath = fb1.SelectedPath;
            if (fpath == null || fpath=="")
            {
                MessageBox.Show("Invalid Selection!!!","ERROR");
            }
            else
            {
                Form2 fm = new Form2(fpath, folder_mode);
                fm.Show();
                this.Hide();
            }
        }


    }
}
