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
    public partial class bluetooth_form1 : Form
    {
        public static int flag = 0;
        public static int flag2 = 0;

        BackgroundWorker bg;
       
        public bluetooth_form1()
        {
            InitializeComponent();
            bg = new BackgroundWorker();
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            progressBar1.Visible = false;
        }

        public bluetooth_form1(int fl)
        {
            InitializeComponent();
            flag = fl;
            bg = new BackgroundWorker();
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            progressBar1.Visible = false;
            if (flag==1)
            {
                add_device.Visible = false;
            }
           
        }


        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            device_list.DataSource = (List<Device>)e.Result;
            progressBar1.Visible = false;
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Device> devices = new List<Device>();
            InTheHand.Net.Sockets.BluetoothClient bc = new InTheHand.Net.Sockets.BluetoothClient();
            InTheHand.Net.Sockets.BluetoothDeviceInfo[] array = bc.DiscoverDevices();
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                Device device = new Device(array[i]);
                devices.Add(device);
            }
            e.Result = devices;
        }


        private void btn_find_Click(object sender, EventArgs e)
        {
            if (!bg.IsBusy)
            {
                progressBar1.Visible = true;
                bg.RunWorkerAsync();
            }
            
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = 2000000;

            //for (int i = 0; i <= 2000000; i++)
            //{
            //    progressBar1.Value = i;
            //}
        }

        private void add_device_Click(object sender, EventArgs e)
        {
            if (selected_device.Items.Count != 7)
            {
                if (device_list.SelectedItem != null && device_list.SelectedItem != selected_device.Items)
                {
                    if (device_list.SelectedItem!=selected_device.Items)
                    {
                        selected_device.Items.Add(device_list.SelectedItem);    
                    }
                    else
                    {
                        MessageBox.Show("Already present in the Selected Device...");
                    }
                }
                else
                {
                    MessageBox.Show("Select A Device");
                }
            }
            else
            {
                MessageBox.Show("Reached Maximum Device Limit");
            }
        }

        private void device_list_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (flag2==0)
             {
                 MessageBox.Show("Select Your Bluetooth Device From List and Click Next");
                 flag2 = 1;
             }
            
            if (device_list.SelectedItem != null)
            {
                string a, b;
                Device device = (Device)device_list.SelectedItem;

                txt_authenticated.Text = device.Authenticated.ToString();
                txt_connected.Text = device.Connected.ToString();
                txt_devicename.Text = device.DeviceName;
                txt_lastseen.Text = device.LastSeen.ToString();
                txt_lastused.Text = device.LastUsed.ToString();
                //txt_nap.Text = device.Nap.ToString();
                txt_remembered.Text = device.Remembered.ToString();
                //txt_sap.Text = device.Sap.ToString();
                textBox1.Text = device.DeviceType.ToString();
                a = device.MacID.ToString();
                b = device.MacID.ToString();
                if (a.Length == 12)
                {
                    a = a.Insert(2, ":");
                }
                if (a.Length == 13)
                {
                    a = a.Insert(5, ":");
                }
                if (a.Length == 14)
                {
                    a = a.Insert(8, ":");
                }
                if (a.Length == 15)
                {
                    a = a.Insert(11, ":");
                }
                if (a.Length == 16)
                {
                    a = a.Insert(14, ":");
                }
                textBox2.Text = a;

            }
            else
            {
                MessageBox.Show("Cannot detect a device");
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            int res;

            if (flag==1)
            {
                string temp_mac=get_macid_reg();
                if (temp_mac == textBox2.Text)
                {
                    MessageBox.Show("Device Recognized");
                    this.Hide();
                    Email em = new Email();
                    em.Show();
                }
                else
                {
                    MessageBox.Show("Unrecognized Device","Try Again");
                }
            }
            else if (flag==2)
            {
                res = Registry_Func();
                if (res == 1)
                {
                    this.Hide();
                    Email em = new Email();
                    em.Show();
                }
                else
                {
                    this.Close();
                }    
            }
            else if (flag==3)
            {
                res = Registry_Func();
                Settings sfm = new Settings();
                sfm.Show();
                this.Close();
            }
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
                    MessageBox.Show("Error code 1, Cannot find mac id");
                    return null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error code 2, Cannot open reg");
                return null;
            }
        }

        private int Registry_Func()
        {
            //accessing the CurrentUser root element  
            //and adding "OurSettings" subkey to the "SOFTWARE" subkey  
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"BLUECRYPTSOFTWARE\OurSettings");

            //storing the values  
            string macid = textBox2.Text;
            if (macid != null && macid != "")
            {
                key.SetValue("MacID", macid);
                //key.SetValue("Setting2", "This is our setting 2");
                key.Close();

                //opening the subkey  
                RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"BLUECRYPTSOFTWARE\OurSettings");

                //if it does exist, retrieve the stored values  
                if (key1 != null)
                {
                    MessageBox.Show("Device Registered");
                    key1.Close();
                    return 1;
                }
                else
                {
                    MessageBox.Show("Unable to Register this device");
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("Mac id not available","Error");
                return 0;
            }
            
        }

        private void bluetooth_form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
