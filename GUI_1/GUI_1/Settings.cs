using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_1
{
    public partial class Settings : Form
    {
        public static int flag = 0;
        public Settings()
        {
            InitializeComponent();
        }

        private void btn_change_MAC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Find and Add your new Device","System");
            flag = 3;                                                                                          //3 value specifies that only registry entry will be changed no further forms will be loaded
            bluetooth_form1 bfm = new bluetooth_form1(flag);
            bfm.Show();
            this.Hide();
        }

        private void btn_change_mail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Register your new Email Address", "System");
            flag = 3;                                                                                       //3 value specifies that only registry entry will be changed no further forms will be loaded
            Start_form stfm = new Start_form(flag);
            stfm.Show();
            this.Hide();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_backtosplash_Click(object sender, EventArgs e)
        {
            splash_screen fm = new splash_screen();
            fm.Show();
            this.Hide();
        }
    }
}
