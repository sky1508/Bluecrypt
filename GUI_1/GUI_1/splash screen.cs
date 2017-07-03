using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace GUI_1
{
    public partial class splash_screen : Form
    {
        public static int filebtn_clicked = 0;
        public static int folderbtn_clicked = 0;
        public static int ciphertxtbtn_clicked = 0;
        int flag = 0;
        public static string sys_folder_path = "D:\\Appdata";

        public splash_screen()
        {
            InitializeComponent();        
        }

        private void splash_screen_Load(object sender, EventArgs e)
        {
            flag = 0;
            splash_xml_changed(flag);
        }

        //private void sys_fold_write()
        //{            
        //    string tf = sys_folder_path + "\\sys_file_name.xml";
        //    using (XmlWriter writer = XmlWriter.Create(tf))
        //    {
        //        writer.WriteStartDocument();
        //        writer.WriteStartElement("folder_name");

        //        writer.WriteElementString("fname", sys_folder_path);
        //        writer.WriteEndElement();
        //        writer.WriteEndDocument();
        //    }
        //}

        //private void sys_fold_read()
        //{
        //    try
        //    {
        //        using (XmlReader reader = XmlReader.Create(sys_folder_path + "\\splash.xml"))
        //        {
        //            while (reader.Read())
        //            {
        //                if (reader.IsStartElement())
        //                {
        //                    switch (reader.Name)
        //                    {
        //                        case "fname":
        //                            if (reader.Read())
        //                            {
        //                                sys_folder_path = reader.Value.Trim();
        //                            }
        //                            break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exe)
        //    {
             
        //    }
        //}

        private void btn_file_Click(object sender, EventArgs e)
        {
            filebtn_clicked = 1;
            folderbtn_clicked = 0;

            centre_lbl_1.Hide();
            centre_lbl_2.Hide();
            centre_lbl_7.Hide();
            centre_lbl_8.Hide();
            centre_lbl_9.Hide();
            centre_lbl_10.Hide();

            centre_lbl_3.Text = "File Encryption Mode";
            centre_lbl_4.Text = "Start";

            centre_lbl_5.Text = "File Decryption Mode";
            centre_lbl_6.Text = "Start";



          //  sys_fold_write();
      }

        private void centre_lbl_4_Click(object sender, EventArgs e)
        {
            //ENCRYPTION

            if (filebtn_clicked==1 && folderbtn_clicked==0)
            {
                OpenFileDialog op1 = new OpenFileDialog();
                op1.ShowDialog();
                string file_name = op1.FileName;
                if (file_name == null || file_name == "")
                {
                    MessageBox.Show("File not selected!!", "ERROR");
                }
                else
                {
                    key_size_select_encrypt fm = new key_size_select_encrypt(file_name,sys_folder_path,0);
                    fm.Show();
                    this.Hide();
                }
            }
            else if (folderbtn_clicked==1 && filebtn_clicked==0)
            {
                int folder_mode = 1;
                FolderBrowserDialog fb1 = new FolderBrowserDialog();
                fb1.ShowDialog();
                string fpath = fb1.SelectedPath;
                if (fpath == null || fpath == "")
                {
                    MessageBox.Show("Invalid Selection!!!", "ERROR");
                }
                else
                {
                    key_size_select_encrypt fm = new key_size_select_encrypt(fpath, folder_mode,sys_folder_path);
                    fm.Show();
                    this.Hide();
                }
            }
            
            
        }

        private void btn_folder_Click(object sender, EventArgs e)
        {
            folderbtn_clicked = 1;
            filebtn_clicked = 0;

            centre_lbl_1.Hide();
            centre_lbl_2.Hide();
            centre_lbl_7.Hide();
            centre_lbl_8.Hide();
            centre_lbl_9.Hide();
            centre_lbl_10.Hide();

            centre_lbl_3.Text = "Folder Encryption Mode";
            centre_lbl_4.Text = "Start";

            centre_lbl_5.Text = "Folder Decryption Mode";
            centre_lbl_6.Text = "Start";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void centre_lbl_6_Click(object sender, EventArgs e)
        {
            //DECRYPTION
            try
            {
                if (filebtn_clicked == 1 && folderbtn_clicked == 0)
                {
                    MessageBox.Show("select an intermediate file for decryption");
                    OpenFileDialog op1 = new OpenFileDialog();
                    op1.ShowDialog();
                    string file_name = op1.FileName;
                    if (file_name == null || file_name == "")
                    {
                        MessageBox.Show("File not selected!!", "ERROR");
                    }
                    else
                    {
                        key_size_select_encrypt fm = new key_size_select_encrypt(sys_folder_path,"D",file_name);
                        fm.Show();
                        this.Hide();
                    }
                }
                else if (folderbtn_clicked == 1 && filebtn_clicked == 0)
                {
                    int folder_mode=2;
                    MessageBox.Show("select an intermediate file for decryption");
                    OpenFileDialog op1 = new OpenFileDialog();
                    op1.ShowDialog();
                    string file_name = op1.FileName;
                    if (file_name == null || file_name == "")
                    {
                        MessageBox.Show("File not selected!!", "ERROR");
                    }
                    else
                    {
                        key_size_select_encrypt fm = new key_size_select_encrypt(file_name,folder_mode,sys_folder_path);
                        fm.Show();
                        this.Hide();
                    }
                }
                else
                {

                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.ToString());
            }
        }

        private void centre_lbl_8_Click(object sender, EventArgs e)
        {
            if (centre_lbl_8.Text=="ON")
            {
                centre_lbl_8.Text = "OFF";    
            }
            else if(centre_lbl_8.Text=="OFF")
            {
                centre_lbl_8.Text = "ON";        
            }

            flag = 1;
            splash_xml_changed(flag);
        }

        private void splash_xml_changed(int flag)
        {
            int date_change = 0;
            int no_of_files_change = 0;
            int auto_up_changed = 0;
            int src_file_keep_changed = 0;
            string version_info = "v1.0"; 
            string last_used = null;
            string no_of_en_files = "0";
            string auto_up = "ON";
            string src_file_keep = "OFF";

            DateTime dt = DateTime.Now.Date;
            string date = Convert.ToString(dt.ToString("dd-MM-yy"));
            last_used = date;


            try
            {
                using (XmlReader reader = XmlReader.Create(sys_folder_path + "\\splash.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "version_info":
                                    if (reader.Read())
                                    {
                                        version_info = reader.Value.Trim();
                                        centre_lbl_2.Text = version_info;
                                    }
                                    break;

                                case "Last_used":
                                    if (reader.Read())
                                    {
                                        last_used = reader.Value.Trim();
                                        centre_lbl_4.Text = last_used;
                                        if (last_used!=date)
                                        {
                                            date_change = 1;
                                        }
                                    }
                                    break;

                                case "no_of_en_files":
                                    if (reader.Read())
                                    {
                                        no_of_en_files = reader.Value.Trim();
                                        centre_lbl_6.Text = no_of_en_files;
                                    }
                                    break;

                                case "Auto_up":
                                    if (reader.Read())
                                    {
                                        auto_up = reader.Value.Trim();
                                        if (flag==1)
                                        {
                                            if (centre_lbl_8.Text != auto_up)
                                            {
                                                auto_up_changed = 1;
                                            }    
                                        }
                                        else
                                        {
                                            centre_lbl_8.Text = auto_up;       
                                        }
                                    }
                                    break;

                                case "src_file_keep":
                                    if (reader.Read())
                                    {
                                        src_file_keep = reader.Value.Trim();
                                        if (flag == 1)
                                        {
                                            if (centre_lbl_10.Text != src_file_keep)
                                            {
                                                src_file_keep_changed = 1;
                                            }
                                        }
                                        else
                                        {
                                            centre_lbl_8.Text = auto_up;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                try
                {
                    //sys_fold_read();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in reading splash.xml");
                    MessageBox.Show("Select a dir to store system files");
                    FolderBrowserDialog fb1 = new FolderBrowserDialog();
                    fb1.ShowDialog();
                    string fpath = fb1.SelectedPath;
                    Directory.CreateDirectory(fpath + "Appdata");
                    sys_folder_path = fpath + "Appdata";                        
                }                
            }

           
            try
            {
                using (XmlWriter writer = XmlWriter.Create( sys_folder_path + "\\splash.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Encryption");

                    writer.WriteElementString("version_info", version_info);
                    
                    if (date_change==1)
                    {
                        writer.WriteElementString("Last_used", date);    
                    }
                    else
                    {
                        writer.WriteElementString("Last_used", last_used);    
                    }

                    if (no_of_files_change==1)
                    {
                        writer.WriteElementString("no_of_en_files", no_of_en_files);    
                    }
                    else
                    {
                        writer.WriteElementString("no_of_en_files", no_of_en_files);
                    }

                    if (auto_up_changed==1)
                    {
                        writer.WriteElementString("Auto_up", centre_lbl_8.Text);    
                    }
                    else
                    {
                        writer.WriteElementString("Auto_up", auto_up);
                    }
                    if (src_file_keep_changed == 1)
                    {
                        writer.WriteElementString("src_file_keep", centre_lbl_10.Text);
                    }
                    else
                    {
                        writer.WriteElementString("src_file_keep", src_file_keep);
                    }
                    
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

        }

        private void centre_lbl_10_Click(object sender, EventArgs e)
        {
            if (centre_lbl_10.Text == "ON")
            {
                centre_lbl_10.Text = "OFF";
            }
            else if (centre_lbl_10.Text == "OFF")
            {
                centre_lbl_10.Text = "ON";
            }

            flag = 1;
            splash_xml_changed(flag);
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Settings sfm = new Settings();
            sfm.Show();
            this.Hide();
        }

    }
}
