using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace GUI_1
{
    public partial class Start_form : Form
    {
        public static int flag = 0;

        public Start_form()
        {
            InitializeComponent();
            string temp_mac = get_macid_reg();
            if (temp_mac==null || temp_mac=="")
            {
                btn_existing_user.Enabled = false;
            }
            else
            {
                btn_new_user.Enabled = false;
            }
            textBox1.Visible = false;
            btn_register.Visible = false;
        }

        private string get_macid_reg()
        {
            try
            {
                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                if (key1 != null)
                {
                    string t_mac = Convert.ToString(key1.GetValue("MacID"));
                    key1.Close();
                    return t_mac;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                  return null;
            }
        }

        public Start_form(int flag1)
        {
            flag = flag1;
            InitializeComponent();
            textBox1.Visible = true;
            btn_register.Visible = true;
            btn_existing_user.Enabled = false;
            btn_new_user.Enabled = false;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_existing_user_Click(object sender, EventArgs e)
        {
            flag = 1;
            MessageBox.Show("Turn on Bluetooth of your registered device");
            bluetooth_form1 bf = new bluetooth_form1(flag);

            bf.Show();
            this.Hide();
        }

        private void btn_new_user_Click(object sender, EventArgs e)
        {
            flag = 2;
            MessageBox.Show("Register your email id for otp authentication");
            textBox1.Visible = true;
            btn_register.Visible = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Func_email_validation(textBox1.Text);

            if (flag == 3 || flag==4)
            {
                int res = Registry_Func();
                Settings sfm = new Settings();
                sfm.Show();
                this.Hide();
            }
            else if (textBox1.Text != "" && textBox1.Text != null && textBox1.Text != "Enter Your Email Id Here" && flag!=3 && flag!=4)
            {
                int res = Registry_Func();
                if (res == 1)
                {
                    flag = 2;
                    bluetooth_form1 bf = new bluetooth_form1(flag);
                    bf.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Mail id is empty", "Error");
            }
        }

        private int Registry_Func()
        {            
            try
            {
                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                string mailid = textBox1.Text;
                key1.SetValue("Mail_ID", mailid);
                key1.Close();

                if (key1 != null)
                {
                    MessageBox.Show("Email Registered");
                    key1.Close();
                    return 1;
                }
                else
                {
                    MessageBox.Show("Cannot Register at the moment", "Error");
                    return 0;
                }
            }
            catch (Exception)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"BLUECRYPTSOFTWARE\OurSettings");    
                string mailid = textBox1.Text;
                key.SetValue("Mail_ID", mailid);
                key.Close();

                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                if (key1 != null)
                {
                    MessageBox.Show("Email Registered");
                    key1.Close();
                    return 1;
                }
                else
                {
                    MessageBox.Show("Cannot Register at the moment", "Error");
                    return 0;
                }
            }    
        }

        private void Func_email_validation(string mailid)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(mailid, pattern))
            {
                var addr = new System.Net.Mail.MailAddress(mailid);
                if (addr.Address == mailid)
                {

                }
                else
                {
                    MessageBox.Show("Not a valid Email address ");
                    textBox1.Text = "";
                    flag = 4;                                                                                               //4 indicates not a valid email address
                }
            }
            else
            {
                MessageBox.Show("Not a valid Email address ");
                textBox1.Text = "";
                flag = 4;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
