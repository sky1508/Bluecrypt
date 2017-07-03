using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;
using System.Net;
using System.Net.Mail;
using Microsoft.Win32;

namespace GUI_1
{
    public partial class Email : Form
    {
        public static string totp = "";
        int ms, s, m, h;

        public Email()
        {
            InitializeComponent();
        }

        private void btn_send_otp_Click(object sender, EventArgs e)
        {
            try
            {
                otp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void otp()
        {
            int lenthofpass = 6;
            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0";//!,@,#,$,%,&,?;
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < lenthofpass; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }

            SendMail(passwordString);
            timer1.Enabled = true;
            timer1.Start();
            totp = passwordString;
        }

        private void SendMail(string passwordString)
        {
            string rec = null;

            try
            {
                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                if (key1 != null)
                {
                    rec = Convert.ToString(key1.GetValue("Mail_ID"));
                    key1.Close();
                }
                else
                {
                    MessageBox.Show("Error code 1, Cannot find mail id");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error code 2, Cannot open reg");
            }

            try
            {               
                string sub = "OTP";
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials=false,                    
                    Credentials = new NetworkCredential("kurmianurag009@gmail.com", "anurag786"),
                    EnableSsl = true
                };
                client.Send(rec, rec, sub, passwordString);
                MessageBox.Show("OTP sent");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Cannot Send OTP due to network problems");
                //this.Close();
            }
        }

        private void btn_proceed_Click(object sender, EventArgs e)
        {
            string user_otp = textBox2.Text;
            if (user_otp == totp)
            {
                MessageBox.Show("Continue","Success");
                this.Hide();
                timer1.Stop();
                timer1.Enabled = false;
                splash_screen fm = new splash_screen();
                fm.Show();
            }
            else
            {
                MessageBox.Show("Invalid otp entered");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
              ms = ms + 1;
            if (ms == 9)
            {
                ms = 0;
                s = s + 1;
                lblsecond.Text = s.ToString();
                if (s == 59)
                {
                    s = 0;
                    m = m + 1;
                    lblmin.Text = m.ToString();
                    //if (m == 59)
                    //{
                    //    m = 0;
                    //    h = h + 1;
                    //    lblhur.Text = h.ToString();
                    //}
                }
            }

            //if (lblsecond.Text == "10" || lblmin.Text == "01")
            if (lblmin.Text == "5" || lblmin.Text == "05")
            {
                timer1.Enabled = false;
                timer1.Stop();
                MessageBox.Show("otp expired");
                lblmin.Text = "00";
                lblsecond.Text = "00";
                otp();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
