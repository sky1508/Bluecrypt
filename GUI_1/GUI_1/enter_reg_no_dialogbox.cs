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
    public partial class enter_reg_no_dialogbox : Form
    {
        public static string user_key = "";

        public enter_reg_no_dialogbox()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pre_splash_form1 pm = new pre_splash_form1();
            pm.Show();
            this.Close();
        }

        private void demo_btn_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now.Date;
            string date = Convert.ToString(dt.ToString("dd-MM-yy"));

            int lengthofpass = 8;
            string allowedChars = "";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string key1="BL";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < lengthofpass; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                key1 += temp;
            }

            key1 = key1 + "-" + date;

            user_key = key1;
            pre_splash_form1 pm = new pre_splash_form1(user_key);
            pm.Show();
            this.Hide();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            string entered_key = lic_key_txtbox.Text;

            if (entered_key!=null && entered_key!="")
            {
                try
                {
                    
                    string[] words = entered_key.Split('-');
                    string pre_key = words[0];
                    string main_key = words[1];

                    int val=enter_key_validation(entered_key);
                    
                    if (val==1)
                    {
                        user_key = entered_key;
                        pre_splash_form1 pm = new pre_splash_form1(user_key);
                        pm.Show();
                        this.Hide();
                    }
                    else if (val==0)
                    {
                        MessageBox.Show("Invalid Key", "ERROR");
                    lic_key_txtbox.Text = "";
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Key", "ERROR");
                    lic_key_txtbox.Text = "";
                }
                
            }
            else
            {
                MessageBox.Show("Invalid Key","ERROR");
                lic_key_txtbox.Text = "";
            }
        }

        private int enter_key_validation(string entered_key)
        {
            if (entered_key != null && entered_key != "")
            {
                switch (entered_key)
                {
                    case "BLFBKFA8L9-54350":
                    case "BL9TXJ37VV-54345":
                    case "BL3QMOKJEZ-54340":
                    case "BLL9FS2PU8-54335":
                    case "BLZFB4U5G1-54330":
                    case "BLMB7FD8G7-54325":
                    case "BLUBMW8SDP-54320":
                    case "BLB1WGITKI-54315":
                    case "BLKZTV8L59-54310":
                    case "BL750U8DV4-54305":

                    return 1;
                    default: return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
