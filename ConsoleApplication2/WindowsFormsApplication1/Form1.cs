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

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        public static int Nb = 4;
        public static int Nr = 0;
        public static int Nk = 0;
        public static byte[] inp = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public static byte[] inp2 = new byte[16] { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff };

        public static byte[] key4 = new byte[32] {0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08, 0x09,0x0a,0x0b,0x0c,0x0d,0x0e,0x0f,0x10,
                                                                        0x11, 0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1a, 0x1b,0x1c,0x1d,0x1e,0x1f};

        public static byte[] key5 = new byte[48] {0x11, 0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1a,0x1b,0x1c,0x1d,0x1e,0x1f,
                                                                        0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0a,0x0b,0x0c,0x0d,0x0e,0x0f,0x10,
                                                                        0x2a,0x2b,0x2c,0x2d,0x2e,0x2f, 0x3a,0x3b,0x3c,0x3d,0x3e,0x3f, 0x4a,0x4b,0x4c,0x4d };

        public static byte[] key6 = new byte[64] {0x2a,0x2b,0x2c,0x2d,0x2e,0x2f, 0x3a,0x3b,0x3c,0x3d,0x3e,0x3f, 0x4a,0x4b,0x4c,0x4d,
                                                                         0x11, 0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1a,0x1b,0x1c,0x1d,0x1e,0x1f,
                                                                         0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0a,0x0b,0x0c,0x0d,0x0e,0x0f,0x10,
                                                                         0x2a,0x2b,0x2c,0x2d,0x2e,0x2f, 0x3a,0x3b,0x3c,0x3d,0x3e,0x3f, 0x4a,0x4b,0x4c,0x4d  };

        public static byte[] outp = new byte[16];
        public static byte[] outp1 = new byte[16];
        public static byte[,] state = new byte[4, 4];
        public static byte[] RoundKey = new byte[240];

        public static byte[] Rcon = new byte[255] { 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 
	                                                                            0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 
	                                                                            0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 
	                                                                            0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 
	                                                                            0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 
	                                                                            0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 
	                                                                            0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 
	                                                                            0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 
	                                                                            0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 
	                                                                            0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 
	                                                                            0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 
	                                                                            0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 
	                                                                            0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 
	                                                                            0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 
	                                                                            0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 
	                                                                            0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb};
        public static int encrypt_state = 0;
        int opt = 0;
        Class1 c1 = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            opt = 1;           
            select_key(opt);           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opt = 2;
            select_key(opt);
        }

        public void select_key(int opt)
        {
            int keysize = 0;
            int key_length = 0;

            byte[] bytes_inp = File.ReadAllBytes("C:\\Users\\Sushil\\Desktop\\pro_dev\\test15.txt");
            byte[] bytes_tempinp2 = new byte[16];
            int x = bytes_inp.Length;

            while (x % 16 != 0)
            {
                using (var f = File.Open(@"C:\\Users\\Sushil\\Desktop\\pro_dev\\test15.txt", FileMode.Append))
                {
                    byte[] space = new byte[1];
                    space[0] = 0x20;
                    f.Write(space, 0, space.Length);
                }
                bytes_inp = File.ReadAllBytes("C:\\Users\\Sushil\\Desktop\\pro_dev\\test15.txt");
                x = bytes_inp.Length;
            }


            if (opt==1)
            {
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
                    label1.Text = "128 Bit Encryption successful";
                }
                else if (radioButton2.Checked==true)
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
                    label1.Text = "192 bit Encryption successful";
                }
                else if (radioButton3.Checked==true)
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
                    label1.Text = "256 bit Encryption successful";
                }
                else
                {
                    label1.Text="TRY AGAIN";
                }
            }

            else if (opt == 2)
            {
                if (radioButton1.Checked==true)
                {
                    keysize = 128;
                    key_length = 32;

                    byte[] bytes_out = File.ReadAllBytes("C:\\Users\\Sushil\\Desktop\\pro_dev\\test15_int.txt");
                    int i = 0;

                    for (int k = 0; k < bytes_inp.Length; k = k + 16)
                    {
                        for (int j = 0; j < 16; j++, i++)
                        {
                            bytes_tempinp2[j] = bytes_out[i];
                        }
                        c1.decrypt(bytes_tempinp2, key4, keysize, encrypt_state, key_length);
                    }

                    label1.Text = "128 Bit Decryption successful";
                }
                else if (radioButton2.Checked==true)
                {
                    keysize = 192;
                    key_length = 48;
                    byte[] bytes_out = File.ReadAllBytes("C:\\Users\\Sushil\\Desktop\\pro_dev\\test15_int.txt");
                    int i = 0;

                    for (int k = 0; k < bytes_inp.Length; k = k + 16)
                    {
                        for (int j = 0; j < 16; j++, i++)
                        {
                            bytes_tempinp2[j] = bytes_out[i];
                        }
                        c1.decrypt(bytes_tempinp2, key5, keysize, encrypt_state, key_length);
                    }
                    label1.Text = "192 Bit Decryption successful";
                }
                else if (radioButton3.Checked==true)
                {
                    keysize = 256;
                    key_length = 64;
                    byte[] bytes_out = File.ReadAllBytes("C:\\Users\\Sushil\\Desktop\\pro_dev\\test15_int.txt");
                    int i = 0;

                    for (int k = 0; k < bytes_inp.Length; k = k + 16)
                    {
                        for (int j = 0; j < 16; j++, i++)
                        {
                            bytes_tempinp2[j] = bytes_out[i];
                        }
                        c1.decrypt(bytes_tempinp2, key6, keysize, encrypt_state, key_length);
                    }
                    label1.Text = "256 Bit Decryption successful";
                }
                else
                {
                    label1.Text="TRY AGAIN";
                }
            }
        }
    }
}
