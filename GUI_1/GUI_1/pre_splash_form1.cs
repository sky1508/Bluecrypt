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

namespace GUI_1
{
    public partial class pre_splash_form1 : Form
    {
        public static int loading_btn_click = 0;
        public static string temp_key1 = "Unregistered";

        public pre_splash_form1()
        {
            InitializeComponent();
        }


        public pre_splash_form1(string key)
        {
            string pre_key = null;
            string main_key = null;

            temp_key1 = key;

            string[] words = temp_key1.Split('-');
            pre_key = words[0];
            main_key = words[1];

            try
            {
                string tm = words[2];
            }
            catch (Exception)
            {
                write_reg_licence();
            }
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string entered_key=null;
            string pre_key=null;
            string main_key =null;
            string main2_key = null;
            string main3_key = null;


            string tkey=read_reg_licence();
            if (tkey != null && tkey != "" &&tkey!="Unregistered")
            {
                int val = 0;
                entered_key = tkey;
                try
                {
                    string[] words = entered_key.Split('-');
                    pre_key = words[0];
                    main_key = words[1];
                    main2_key = words[2];
                    main3_key = words[3];
                    string trial_date = main_key + "-" + main2_key + "-" + main3_key;
                    val = trial_check(trial_date); 
                    
                    if (val==1)
                    {
                        pre_key = "Trial Expired";
                    }
                    else if(val==2)
                    {
                        pre_key = pre_key + " Demo";
                    }

                }
                catch (Exception)
                {
                    user_lic_lbl.Text = pre_key;
                    //MessageBox.Show("Invalid Key", "ERROR");
                }
                user_lic_lbl.Text = pre_key;
                
            }
            else 
            {
                entered_key = temp_key1;
                try
                {
                    string[] words = entered_key.Split('-');
                    pre_key = words[0];
                    main_key = words[1];
                }
                catch (Exception)
                {
                    //MessageBox.Show("Invalid Key", "ERROR");
                }

                if (temp_key1!=null&&temp_key1!="Unregistered"&&temp_key1!="")
                {
                    write_reg_licence();     
                }

                user_lic_lbl.Text = pre_key;
                
            }
        }

        private int trial_check(string trial_date)
        {
            DateTime dt = DateTime.Now.Date;
            string cur_date = Convert.ToString(dt.ToString("dd-MM-yy"));

            DateTime dt1=Convert.ToDateTime(trial_date);
            //DateTime dt1 = new DateTime(2015,3,2);
            DateTime dt2=Convert.ToDateTime(cur_date);

            TimeSpan diff = dt2.Subtract(dt1);
            TimeSpan diff1 = dt2 - dt1;

            string diff2 = (dt1 - dt2).TotalDays.ToString();

            if (Convert.ToInt32(diff2)>30)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private string read_reg_licence()
        {
            try
            {
                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                if (key1 != null)
                {
                    string t_key = Convert.ToString(key1.GetValue("Licence_Key"));
                    key1.Close();
                    return t_key;
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

        private void write_reg_licence()
        {
            
            try
            {
                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                string lic_id = temp_key1;
                key1.SetValue("Licence_Key", lic_id);
                key1.Close();

                if (key1 != null)
                {
                    MessageBox.Show("Software Licenced");
                    key1.Close();
                }
                else
                {
                    MessageBox.Show("Cannot Register at the moment", "Error");
                }
            }
            catch (Exception)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                string lic_id = temp_key1;
                key.SetValue("Licence_Key", lic_id);
                key.Close();

                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");
                if (key1 != null)
                {
                    MessageBox.Show("Licence Generated");
                    key1.Close();
                }
                else
                {
                    MessageBox.Show("Cannot Register at the moment", "Error");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enter_reg_no_dialogbox ereg1 = new enter_reg_no_dialogbox();
            ereg1.Show();
            this.Hide();
        }

        private void btn_stop_loading_Click_1(object sender, EventArgs e)
        {
            if (btn_stop_loading.Text=="Continue")
            {
                //splash_screen sp = new splash_screen();
                Start_form sp = new Start_form();
                sp.Show();
                this.Hide();
            }
            else
            {
                btn_stop_loading.Text = "Continue";
            }
        }
    }
}
