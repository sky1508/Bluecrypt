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

namespace Folder_selection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb1 = new FolderBrowserDialog();
            fb1.ShowDialog();
            string fpath = fb1.SelectedPath;
            label1.Text = fpath;
            zipfolder(fpath);
        }

        private void zipfolder(string fpath)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(@fpath);
                string zipname = fpath;
                zip.Save(fpath+"1.zip");
                label1.Text = "Done zipping";
                zip.ExtractAll(fpath+"2.zip");
                label1.Text = "Done unzipping";
            }
        }
    }
}
