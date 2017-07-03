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
using ClassLibrary1;
using Ionic.Zip;
using System.Xml;

namespace GUI_1
{
    public partial class key_size_select_encrypt : Form
    {
        public static byte[] key4 = new byte[32] {0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08, 0x09,0x0a,0x0b,0x0c,0x0d,0x0e,0x0f,0x10,
                                                                        0x11, 0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1a, 0x1b,0x1c,0x1d,0x1e,0x1f};

        public static byte[] key5 = new byte[48] {0x11, 0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1a,0x1b,0x1c,0x1d,0x1e,0x1f,
                                                                        0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0a,0x0b,0x0c,0x0d,0x0e,0x0f,0x10,
                                                                        0x2a,0x2b,0x2c,0x2d,0x2e,0x2f, 0x3a,0x3b,0x3c,0x3d,0x3e,0x3f, 0x4a,0x4b,0x4c,0x4d };

        public static byte[] key6 = new byte[64] {0x2a,0x2b,0x2c,0x2d,0x2e,0x2f, 0x3a,0x3b,0x3c,0x3d,0x3e,0x3f, 0x4a,0x4b,0x4c,0x4d,
                                                                         0x11, 0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1a,0x1b,0x1c,0x1d,0x1e,0x1f,
                                                                         0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0a,0x0b,0x0c,0x0d,0x0e,0x0f,0x10,
                                                                         0x2a,0x2b,0x2c,0x2d,0x2e,0x2f, 0x3a,0x3b,0x3c,0x3d,0x3e,0x3f, 0x4a,0x4b,0x4c,0x4d  };

        public static int encrypt_state = 0;
        public static int folder_mode = 0;
        public static int folder_zip_mode = 0;
        public static string zipfolderpath;
        public static string tempfpath;
        public static string inp_length;
        
        int opt = 0;
        public static string sys_folder_path;

        public static int flag = 0;
        public static int encryption_count = 0;

        public static string first_file_name = null;
        public static string rest_file_name = null;

        public static string src_file_status = null;

        Class1 c1 = new Class1();
        string inpfile_name;
        string temp_ofname;
        byte[] bytes_inp;

        
        public key_size_select_encrypt()
        {
            InitializeComponent();
        }

       public key_size_select_encrypt(string temp_file_name,string sys_fold_path,int a)
        {
            InitializeComponent();
            inpfile_name = temp_file_name;
            temp_ofname = temp_file_name;
            sys_folder_path = sys_fold_path;
        }

       public key_size_select_encrypt(string sys_fp_path,string mode,string temp_file_name)
       {
           InitializeComponent();
           btn_encrypt.Visible = false;
           inpfile_name = temp_file_name;
           sys_folder_path = sys_fp_path;
        }

       public key_size_select_encrypt(string fpath, int folder,string sys_f_path)
        {
            InitializeComponent();
            sys_folder_path = sys_f_path;

            folder_mode = folder;
            if (folder_mode==1)
            {
                using (ZipFile zip = new ZipFile())
                {
                    try
                    {
                        zip.AddDirectory(@fpath);
                        string zipname = fpath;
                        zip.Save(fpath + ".zip");
                        zipfolderpath = fpath + ".zip";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
                tempfpath = fpath;
                inpfile_name = zipfolderpath;
            }
            else if (folder_mode==2)
            {
                btn_encrypt.Visible = false;
                inpfile_name = fpath;
            }
   
        }


        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label2.Text = "Encrypting";
            opt = 1;
            select_key(opt);
            //bytes_inp = File.ReadAllBytes(inpfile_name);
            //File.Delete(inpfile_name);
        }


        private void select_key(int opt)
        {
            progressBar1.Visible = true;
            int keysize = 0;
            int key_length = 0;
            int x;
            byte[] bytes_tempinp2 = new byte[16];

            if (opt == 1)
            {
                seperate_name_format(inpfile_name);
                Class1 csf = new Class1(first_file_name);
                //Class1 csf = new Class1(inpfile_name);
                bytes_inp = File.ReadAllBytes(inpfile_name);
                x = bytes_inp.Length;
                inp_length = Convert.ToString(x);

                cipher_xml();


                while (x % 16 != 0)
                {
                    using (var f = File.Open(@inpfile_name, FileMode.Append))
                    {
                        byte[] space = new byte[1];
                        space[0] = 0x20;
                        f.Write(space, 0, space.Length);
                    }
                    bytes_inp = File.ReadAllBytes(inpfile_name);
                    x = bytes_inp.Length;
                }


                if (radioButton1.Checked == true)
                {
                    keysize = 128;
                    int i = 0;

                    for (int k = 0; k < bytes_inp.Length; k = k + 16)
                    {
                        for (int j = 0; j < 16; j++, i++)
                        {
                            bytes_tempinp2[j] = bytes_inp[i];
                        
                        }
                        c1.encrypt(bytes_tempinp2, key4, keysize, encrypt_state, 32);
                    }

                    if (src_file_status == "OFF")
                    {
                        File.Delete(inpfile_name);
                    }

                    MessageBox.Show("128 Bit Encryption successful");
                    label2.Visible = false;
                    progressBar1.Visible = false;
                    encryption_count++;
                    flag = 1;
                    splash_xml_changed(flag);

                   

                    if (folder_mode == 1)
                    {
                        try
                        {
                            XmlDocument xd = new XmlDocument();
                            xd.Load(first_file_name + ".xml");
                            XmlNode nl = xd.SelectSingleNode("//Encryption");
                            XmlDocument xd2 = new XmlDocument();
                            xd2.LoadXml("<folder_name>"+tempfpath+"</folder_name>");
                            XmlNode n = xd.ImportNode(xd2.FirstChild, true);
                            nl.AppendChild(n);
                            xd.Save(first_file_name + ".xml");
                        }
                        catch (Exception exep)
                        {
                            
                        }
                        Directory.Delete(tempfpath, true);
                        folder_zip_mode = 1;
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    keysize = 192;
                    int i = 0;

                    for (int k = 0; k < bytes_inp.Length; k = k + 16)
                    {
                        for (int j = 0; j < 16; j++, i++)
                        {
                            bytes_tempinp2[j] = bytes_inp[i];
                        }
                        c1.encrypt(bytes_tempinp2, key5, keysize, encrypt_state, 48);
                    }
                    MessageBox.Show("192 bit Encryption successful");
                    progressBar1.Visible = false;
                    encryption_count++;
                    flag = 1;
                    splash_xml_changed(flag);

                    if (folder_mode == 1)
                    {
                        try
                        {
                            XmlDocument xd = new XmlDocument();
                            xd.Load(first_file_name + ".xml");
                            XmlNode nl = xd.SelectSingleNode("//Encryption");
                            XmlDocument xd2 = new XmlDocument();
                            xd2.LoadXml("<folder_name>" + tempfpath + "</folder_name>");
                            XmlNode n = xd.ImportNode(xd2.FirstChild, true);
                            nl.AppendChild(n);
                            xd.Save(first_file_name + ".xml");
                        }
                        catch (Exception exep)
                        {

                        }
                        Directory.Delete(tempfpath, true);
                        folder_zip_mode = 1;
                    }
                }

                else if (radioButton3.Checked == true)
                {
                    keysize = 256;
                    int i = 0;

                    for (int k = 0; k < bytes_inp.Length; k = k + 16)
                    {
                        for (int j = 0; j < 16; j++, i++)
                        {
                            bytes_tempinp2[j] = bytes_inp[i];
                        }
                        c1.encrypt(bytes_tempinp2, key6, keysize = 256, encrypt_state, 64);
                    }
                    MessageBox.Show("256 bit Encryption successful");

                    encryption_count++;
                    flag = 1;
                    splash_xml_changed(flag);
                    
                    if (folder_mode == 1)
                    {
                        try
                        {
                            XmlDocument xd = new XmlDocument();
                            xd.Load(first_file_name + ".xml");
                            XmlNode nl = xd.SelectSingleNode("//Encryption");
                            XmlDocument xd2 = new XmlDocument();
                            xd2.LoadXml("<folder_name>" + tempfpath + "</folder_name>");
                            XmlNode n = xd.ImportNode(xd2.FirstChild, true);
                            nl.AppendChild(n);
                            xd.Save(first_file_name + ".xml");
                        }
                        catch (Exception exep)
                        {

                        }
                        Directory.Delete(tempfpath, true);
                        folder_zip_mode = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid selection !!!! TRY AGAIN");
                }
            }
        }

        private void seperate_name_format(string inpfile_name)
        {
            try
            {
                string[] sep_file_name = inpfile_name.Split('.');
                first_file_name = sep_file_name[0];
                rest_file_name = sep_file_name[1];

            }
            catch (Exception)
            {
                MessageBox.Show("Error1");
            }
        }

        private void cipher_xml()
        {
                        try
            {
                
                using (XmlWriter writer = XmlWriter.Create(first_file_name + ".xml"))
                //using (XmlWriter writer = XmlWriter.Create(sys_folder_path + "\\cipher.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Encryption");

                    writer.WriteElementString("file_name", inpfile_name);
                    writer.WriteElementString("file_length", inp_length);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error in writing cipher.xml"+exp.ToString());
            }
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label2.Text = "Decrypting";
            opt = 2;
            try
            {
                MessageBox.Show("select an intermediate file for decryption");
                OpenFileDialog op1 = new OpenFileDialog();
                op1.ShowDialog();
                string file_name = op1.FileName;
                inpfile_name = file_name;
                bytes_inp = File.ReadAllBytes(file_name);
                File.Delete(file_name);
                select_key2(opt);
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("select an intermediate file for decryption");
                    OpenFileDialog op1 = new OpenFileDialog();
                    op1.ShowDialog();
                    string file_name = op1.FileName;
                    bytes_inp = File.ReadAllBytes(file_name);
                    File.Delete(file_name);
                    select_key2(opt);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("file not selected");     
                }
            }
            
        }

        private void select_key2(int opt)
        {
            int i = 0;
            int keysize = 0;
            int key_length = 0;
            byte[] bytes_tempinp2 = new byte[16];
            string first_file_name=null;
            string rest_file_name=null;

            if (opt==2)
            {

                try
                {
                    string[] sep_file_name = inpfile_name.Split('_');
                    first_file_name = sep_file_name[0];
                    rest_file_name = sep_file_name[1];
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }

                string temp=null;

                try
                {
                    using (XmlReader reader = XmlReader.Create(first_file_name+".xml"))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement())
                            {
                                switch (reader.Name)
                                {
                                    case "file_name":
                                                                    if (reader.Read())
                                                                    {
                                                                        temp = reader.Value.Trim();
                                                                    }
                                                                    break;

                                    case "file_length":
                                                                        if (reader.Read())
                                                                        {
                                                                            inp_length = reader.Value.Trim();
                                                                        }
                                                                        break;
                                    
                                    case "folder_name":
                                                                    if (reader.Read())
                                                                    {
                                                                        tempfpath = reader.Value.Trim();
                                                                    }
                                                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception exex)
                {
                    MessageBox.Show("Error in reading the dir");
                }
                
                Class1 csf = new Class1(temp,first_file_name);

                zipfolderpath = temp;             
                int inp_var_length = Convert.ToInt32(inp_length);

                 if (radioButton1.Checked == true)
                {
                    keysize = 128;
                    key_length = 32;                    
                    i = 0;

                    for (int k = 0; k < inp_var_length; k = k + 16)
                    {
                        for (int j = 0; j < 16; j++, i++)
                        {
                               bytes_tempinp2[j] = bytes_inp[i];
                        }
                        c1.decrypt(bytes_tempinp2, key4, keysize, encrypt_state, key_length);
                    }

                    if (folder_mode == 2||folder_zip_mode==1)
                    {
                        string ziptounpack = zipfolderpath;
                        string unpackDirectory = tempfpath;
                        using (ZipFile zip1 = ZipFile.Read(zipfolderpath))
                        {
                            foreach (ZipEntry e in zip1)
                            {
                                e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                       File.Delete(zipfolderpath);
                    }
                    File.Delete(first_file_name + "_int_key.txt");
                    File.Delete(first_file_name + "_int_key.txt");
                    File.Delete(first_file_name + ".xml");
                    MessageBox.Show("128 Bit Decryption successful");
                    label2.Visible = false;
                    progressBar1.Visible = false;
                    this.Close();
                }

                 else if (radioButton2.Checked == true)
                 {
                     keysize = 192;
                     key_length = 48;
                     i = 0;

                     for (int k = 0; k < inp_var_length; k = k + 16)
                     {
                         for (int j = 0; j < 16; j++, i++)
                         {
                             bytes_tempinp2[j] = bytes_inp[i];
                         }
                         c1.decrypt(bytes_tempinp2, key5, keysize, encrypt_state, key_length);
                     }

                     if (folder_mode == 2 || folder_zip_mode == 1)
                     {
                         string ziptounpack = zipfolderpath;
                         string unpackDirectory = tempfpath;
                         using (ZipFile zip1 = ZipFile.Read(zipfolderpath))
                         {
                             foreach (ZipEntry e in zip1)
                             {
                                 e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                             }
                         }
                         File.Delete(zipfolderpath);
                     }
                     File.Delete(first_file_name + "_int_key.txt");
                     File.Delete(first_file_name + ".xml");
                     MessageBox.Show("192 Bit Decryption successful");
                     this.Close();
                 }
                 else if (radioButton3.Checked == true)
                 {
                     keysize = 256;
                     key_length = 64;
                     i = 0;

                     for (int k = 0; k < inp_var_length; k = k + 16)
                     {
                         for (int j = 0; j < 16; j++, i++)
                         {
                             bytes_tempinp2[j] = bytes_inp[i];
                         }
                         c1.decrypt(bytes_tempinp2, key6, keysize, encrypt_state, key_length);
                     }
                     if (folder_mode == 2 || folder_zip_mode == 1)
                     {
                         string ziptounpack = zipfolderpath;
                         string unpackDirectory = tempfpath;
                         using (ZipFile zip1 = ZipFile.Read(zipfolderpath))
                         {
                             foreach (ZipEntry e in zip1)
                             {
                                 e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                             }
                         }
                         File.Delete(zipfolderpath);
                     }
                     File.Delete(first_file_name + "_int_key.txt");
                     File.Delete(first_file_name + ".xml");
                     MessageBox.Show("256 Bit Decryption successful");
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("Invalid Selection!!!! TRY AGAIN");
                 }
            }
 
        }

        private void key_size_select_encrypt_Load(object sender, EventArgs e)
        {
            flag = 0;
            splash_xml_changed(flag);
            progressBar1.Visible = false;
        }

        private void splash_xml_changed(int flag)
        {
            int no_of_files_change = 0;
            string version_info = null;
            string last_used = null;
            string no_of_en_files = null;
            string auto_up = null;
            string src_file_keep = null;

            try
            {
                using (XmlReader reader = XmlReader.Create(sys_folder_path+"\\splash.xml"))
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
                                    }
                                    break;

                                case "Last_used":
                                    if (reader.Read())
                                    {
                                        last_used = reader.Value.Trim();
                                    }
                                    break;

                                case "no_of_en_files":
                                    if (reader.Read())
                                    {
                                        no_of_en_files = reader.Value.Trim();
                                        if (flag == 1)
                                        {
                                            if (no_of_en_files!=Convert.ToString(encryption_count))
                                            {
                                                no_of_files_change = 1;
                                            }
                                        }
                                        else
                                        {
                                            encryption_count = Convert.ToInt32(no_of_en_files);
                                        }
                                    }
                                    break;

                                case "Auto_up":
                                    if (reader.Read())
                                    {
                                        auto_up = reader.Value.Trim();
                                    }
                                    break;

                                case "src_file_keep":
                                    if (reader.Read())
                                    {
                                        src_file_keep = reader.Value.Trim();
                                        src_file_status = src_file_keep;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Error in reading splash.xml");
            }


            try
            {
                using (XmlWriter writer = XmlWriter.Create(sys_folder_path + "\\splash.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Encryption");

                    writer.WriteElementString("version_info", version_info);
                    writer.WriteElementString("Last_used", last_used);
                    
                    if (no_of_files_change == 1)
                    {
                        writer.WriteElementString("no_of_en_files", Convert.ToString(encryption_count));
                    }
                    else
                    {
                        writer.WriteElementString("no_of_en_files", no_of_en_files);
                    }

                    writer.WriteElementString("Auto_up", auto_up);
                    
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
    }
}
