using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ClassLibrary1
{
    public class Class1
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
        public static byte[] key = new byte[32] { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                                                      0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};

        public static byte[] key2 = new byte[48] { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                                                        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                                                        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};

        public static byte[] key3 = new byte[64] { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                                                        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                                                        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                                                        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};

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
        public static string outfile_name;
        public static string keyfile;

        public Class1(string inpfile_name)
        {
            outfile_name = inpfile_name;
        }

        public Class1(string inpfile_name,string key_file)
        {
            outfile_name = inpfile_name;
            keyfile = key_file;
        }

        public Class1()
        {
        }


        public void encrypt(byte[] inp, byte[] key, int keysize, int encrypt_state, int key_length)
        {
            Nk = keysize / key_length;
            if (keysize == 128)
            {
                Nr = 10;
            }
            else if (keysize == 192)
            {
                Nr = 12;
            }
            else if (keysize == 256)
            {
                Nr = 14;
            }

            RoundKey = keyexpansion(key, Nr, Nk);

            using (var f = File.Open(@outfile_name+"_int_key.txt", FileMode.Append))
            {
                f.Write(RoundKey, 0, RoundKey.Length);
            }
            
            outp1 = Cipher(inp, RoundKey, Nr);
            
            using (var f = File.Open(@outfile_name+"_int.blu", FileMode.Append))
            {
                f.Write(outp1, 0, outp1.Length);
            }
        }

        public void decrypt(byte[] inp, byte[] key, int keysize, int encrypt_state, int key_length)
        {
            byte[] intemp = new byte[16];
            byte[] key_temp = File.ReadAllBytes(@keyfile+"_int_key.txt");
            RoundKey = key_temp;
            
            if (keysize == 128)
            {
                Nr = 10;
            }
            else if (keysize == 192)
            {
                Nr = 12;
            }
            else if (keysize == 256)
            {
                Nr = 14;
            }
            
            intemp = InvCipher(inp, RoundKey, Nr);
            try
            {
                using (var f = File.Open(@outfile_name, FileMode.Append))
                {
                    f.Write(intemp, 0, intemp.Length);
                }
            }
            catch (Exception e)
            {
            }     
        }

        public byte[] Cipher(byte[] inp, byte[] RoundKey, int Nr)
        {
            int i, j, iRound = 0;

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    state[j, i] = inp[i * 4 + j];
                }
            }

            state = AddRoundKey(0, RoundKey, state);

            for (iRound = 1; iRound < Nr; iRound++)
            {
                state = SubBytes(state);
                state = ShiftRows(state);
                state = MixColumns(state);
                state = AddRoundKey(iRound, RoundKey, state);
            }

            state = SubBytes(state);
            state = ShiftRows(state);
            state = AddRoundKey(Nr, RoundKey, state);

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    outp[i * 4 + j] = state[j, i];
                }
            }

            return outp;
        }

        
        public byte[,] MixColumns(byte[,] state)
        {
            int i;
            byte Tmp, Tm, t;
            for (i = 0; i < 4; i++)
            {
                t = state[0, i];
                Tmp = Convert.ToByte(state[0, i] ^ state[1, i] ^ state[2, i] ^ state[3, i]);

                Tm = Convert.ToByte(state[0, i] ^ state[1, i]);
                Tm = xtime(Tm);
                state[0, i] = Convert.ToByte(state[0, i] ^ (Tm ^ Tmp));

                Tm = Convert.ToByte(state[1, i] ^ state[2, i]);
                Tm = xtime(Tm);
                state[1, i] = Convert.ToByte(state[1, i] ^ (Tm ^ Tmp));


                Tm = Convert.ToByte(state[2, i] ^ state[3, i]);
                Tm = xtime(Tm);
                state[2, i] = Convert.ToByte(state[2, i] ^ (Tm ^ Tmp));

                Tm = Convert.ToByte(state[3, i] ^ t);
                Tm = xtime(Tm);
                state[3, i] = Convert.ToByte(state[3, i] ^ (Tm ^ Tmp));
            }

            return state;
        }

        public byte xtime(byte Tm)
        {
            unchecked
            {
                int p = Convert.ToInt32(Tm);
                int p1 = (p >> 7);
                int p2 = (p1 & 1);
                int p3 = (p2 * 0x1b);
                int p4, p5;
                byte p6;

                if ((p << 1) > 255)
                {
                    p4 = (p << 1) & 0xFF;
                }
                else
                {
                    p4 = (p << 1);
                }

                p5 = p4 ^ p3;
                p6 = unchecked(Convert.ToByte(p5));

                return p6;
            }
        }

        public byte[,] ShiftRows(byte[,] state)
        {
            byte temp;
            // Rotate first row 1 columns to left	
            temp = state[1, 0];
            state[1, 0] = state[1, 1];
            state[1, 1] = state[1, 2];
            state[1, 2] = state[1, 3];
            state[1, 3] = temp;

            // Rotate second row 2 columns to left	
            temp = state[2, 0];
            state[2, 0] = state[2, 2];
            state[2, 2] = temp;

            temp = state[2, 1];
            state[2, 1] = state[2, 3];
            state[2, 3] = temp;

            // Rotate third row 3 columns to left
            temp = state[3, 0];
            state[3, 0] = state[3, 3];
            state[3, 3] = state[3, 2];
            state[3, 2] = state[3, 1];
            state[3, 1] = temp;

            return state;
        }

        public byte[,] SubBytes(byte[,] state)
        {
            int i, j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    state[i, j] = getSBoxValue(state[i, j]);
                }
            }

            return state;
        }

        public byte[,] AddRoundKey(int round, byte[] RoundKey, byte[,] state)
        {

            int i, j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    state[j, i] = Convert.ToByte(state[j, i] ^ (RoundKey[round * Nb * 4 + i * Nb + j]));
                }
            }
            return state;
        }

        public byte[] keyexpansion(byte[] key, int Nr, int Nk)
        {
            int i, j;
            byte[] temp = new byte[4];
            byte k;

            for (i = 0; i < Nk; i++)
            {
                RoundKey[i * 4] = key[i * 4];
                RoundKey[i * 4 + 1] = key[i * 4 + 1];
                RoundKey[i * 4 + 2] = key[i * 4 + 2];
                RoundKey[i * 4 + 3] = key[i * 4 + 3];

            }

            while (i < (Nb * (Nr + 1)))
            {
                for (j = 0; j < 4; j++)
                {
                    temp[j] = RoundKey[(i - 1) * 4 + j];
                }

                if (i % Nk == 0)
                {
                    {
                        k = temp[0];
                        temp[0] = temp[1];
                        temp[1] = temp[2];
                        temp[2] = temp[3];
                        temp[3] = k;
                    }

                    {
                        temp[0] = getSBoxValue(temp[0]);
                        temp[1] = getSBoxValue(temp[1]);
                        temp[2] = getSBoxValue(temp[2]);
                        temp[3] = getSBoxValue(temp[3]);
                    }

                    temp[0] = Convert.ToByte(temp[0] ^ Rcon[i / Nk]);

                }
                else if (Nk > 6 && i % Nk == 4)
                {
                    {
                        temp[0] = getSBoxValue(temp[0]);
                        temp[1] = getSBoxValue(temp[1]);
                        temp[2] = getSBoxValue(temp[2]);
                        temp[3] = getSBoxValue(temp[3]);
                    }
                }

                RoundKey[i * 4 + 0] = Convert.ToByte(RoundKey[(i - Nk) * 4 + 0] ^ temp[0]);
                RoundKey[i * 4 + 1] = Convert.ToByte(RoundKey[(i - Nk) * 4 + 1] ^ temp[1]);
                RoundKey[i * 4 + 2] = Convert.ToByte(RoundKey[(i - Nk) * 4 + 2] ^ temp[2]);
                RoundKey[i * 4 + 3] = Convert.ToByte(RoundKey[(i - Nk) * 4 + 3] ^ temp[3]);
                i++;

            }

            return RoundKey;
        }

        public byte getSBoxValue(byte p)
        {
            //  0          1      2        3        4       5           6       7       8       9       A          B        C       D       E       F
            byte[] SBox1 = new byte[256] { 0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76, //0
	                                                          0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0, //1
	                                                          0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15, //2
	                                                          0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75, //3
	                                                          0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84, //4
	                                                          0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf, //5
	                                                          0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8, //6
	                                                          0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2, //7
	                                                          0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73, //8
	                                                          0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb, //9
	                                                          0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79, //A
	                                                          0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08, //B
	                                                          0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a, //C
	                                                          0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e, //D
	                                                          0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf, //E
	                                                          0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16 }; //F

            return SBox1[p];
        }

        public byte[] InvCipher(byte[] outp1, byte[] RoundKey, int Nr)
        {
            int i, j, iRound = 0;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    state[j, i] = outp1[i * 4 + j];
                }
            }

            state = AddRoundKey(Nr, RoundKey, state);

            for (iRound = Nr - 1; iRound > 0; iRound--)
            {
                state = InvShiftRows(state);
                state = InvSubBytes(state);
                state = AddRoundKey(iRound, RoundKey, state);
                state = InvMixColumns(state);

            }

            state = InvShiftRows(state);
            state = InvSubBytes(state);
            state = AddRoundKey(0, RoundKey, state);

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    outp[i * 4 + j] = state[j, i];
                }
            }

            return outp;
        }

        public byte[,] InvMixColumns(byte[,] state)
        {
            byte tempA, tempB, tempC, tempD;
            for (int i = 0; i < 4; i++)
            {
                tempA = state[0, i];
                tempB = state[1, i];
                tempC = state[2, i];
                tempD = state[3, i];

                state[0, i] = Convert.ToByte(Multiply(tempA, 0x0e) ^ Multiply(tempB, 0x0b) ^ Multiply(tempC, 0x0d) ^ Multiply(tempD, 0x09));
                state[1, i] = Convert.ToByte(Multiply(tempA, 0x09) ^ Multiply(tempB, 0x0e) ^ Multiply(tempC, 0x0b) ^ Multiply(tempD, 0x0d));
                state[2, i] = Convert.ToByte(Multiply(tempA, 0x0d) ^ Multiply(tempB, 0x09) ^ Multiply(tempC, 0x0e) ^ Multiply(tempD, 0x0b));
                state[3, i] = Convert.ToByte(Multiply(tempA, 0x0b) ^ Multiply(tempB, 0x0d) ^ Multiply(tempC, 0x09) ^ Multiply(tempD, 0x0e));
            }

            return state;
        }

        public int Multiply(byte x, int y)
        {
            int result = 0;

            int p1 = y & 1;
            int p2 = p1 * x;

            int p3 = y >> 1;
            int p4 = p3 & 1;
            int p5 = p4 * xtime(x);

            int p6 = y >> 2;
            int p7 = p6 & 1;
            int p8 = p7 * xtime(xtime(x));

            int p9 = y >> 3;
            int p10 = p9 & 1;
            int p11 = p10 * xtime(xtime(xtime(x)));

            int p12 = y >> 4;
            int p13 = p12 & 1;
            int p14 = p13 * xtime(xtime(xtime(xtime(x))));

            result = (p2 ^ p5 ^ p8 ^ p11 ^ p14);

            return result;
        }

        public byte[,] InvSubBytes(byte[,] state)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = getSBoxInvertValue(state[i, j]);
                }
            }
            return state;
        }

        public byte getSBoxInvertValue(byte p)
        {
            byte[] SBoxInvert = new byte[256] {0x52, 0x09, 0x6A, 0xD5, 0x30, 0x36, 0xA5, 0x38, 0xBF, 0x40, 0xA3, 0x9E, 0x81, 0xF3, 0xD7, 0xFB, 
                                                                     0x7C, 0xE3, 0x39, 0x82, 0x9B, 0x2F, 0xFF, 0x87, 0x34, 0x8E, 0x43, 0x44, 0xC4, 0xDE, 0xE9, 0xCB,
                                                                     0x54, 0x7B, 0x94, 0x32, 0xA6, 0xC2, 0x23, 0x3D, 0xEE, 0x4C, 0x95, 0x0B, 0x42, 0xFA, 0xC3, 0x4E,
                                                                     0x08, 0x2E, 0xA1, 0x66, 0x28, 0xD9, 0x24, 0xB2, 0x76, 0x5B, 0xA2, 0x49, 0x6D, 0x8B, 0xD1, 0x25,
                                                                     0x72, 0xF8, 0xF6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xD4, 0xA4, 0x5C, 0xCC, 0x5D, 0x65, 0xB6, 0x92,
                                                                     0x6C, 0x70, 0x48, 0x50, 0xFD, 0xED, 0xB9, 0xDA, 0x5E, 0x15, 0x46, 0x57, 0xA7, 0x8D, 0x9D, 0x84,
                                                                     0x90, 0xD8, 0xAB, 0x00, 0x8C, 0xBC, 0xD3, 0x0A, 0xF7, 0xE4, 0x58, 0x05, 0xB8, 0xB3, 0x45, 0x06,
                                                                     0xD0, 0x2C, 0x1E, 0x8F, 0xCA, 0x3F, 0x0F, 0x02, 0xC1, 0xAF, 0xBD, 0x03, 0x01, 0x13, 0x8A, 0x6B,  
                                                                     0x3A, 0x91, 0x11, 0x41, 0x4F, 0x67, 0xDC, 0xEA, 0x97, 0xF2, 0xCF, 0xCE, 0xF0, 0xB4, 0xE6, 0x73,
                                                                     0x96, 0xAC, 0x74, 0x22, 0xE7, 0xAD, 0x35, 0x85, 0xE2, 0xF9, 0x37, 0xE8, 0x1C, 0x75, 0xDF, 0x6E,
                                                                     0x47, 0xF1, 0x1A, 0x71, 0x1D, 0x29, 0xC5, 0x89, 0x6F, 0xB7, 0x62, 0x0E, 0xAA, 0x18, 0xBE, 0x1B,   
                                                                     0xFC, 0x56, 0x3E, 0x4B, 0xC6, 0xD2, 0x79, 0x20, 0x9A, 0xDB, 0xC0, 0xFE, 0x78, 0xCD, 0x5A, 0xF4,
                                                                     0x1F, 0xDD, 0xA8, 0x33, 0x88, 0x07, 0xC7, 0x31, 0xB1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xEC, 0x5F,   
                                                                     0x60, 0x51, 0x7F, 0xA9, 0x19, 0xB5, 0x4A, 0x0D, 0x2D, 0xE5, 0x7A, 0x9F, 0x93, 0xC9, 0x9C, 0xEF,  
                                                                     0xA0, 0xE0, 0x3B, 0x4D, 0xAE, 0x2A, 0xF5, 0xB0, 0xC8, 0xEB, 0xBB, 0x3C, 0x83, 0x53, 0x99, 0x61,  
                                                                     0x17, 0x2B, 0x04, 0x7E, 0xBA, 0x77, 0xD6, 0x26, 0xE1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0C, 0x7D 
                                                                    };
            return SBoxInvert[p];
        }

        public byte[,] InvShiftRows(byte[,] state)
        {
            byte temp;
            temp = state[1, 3];

            state[1, 3] = state[1, 2];
            state[1, 2] = state[1, 1];
            state[1, 1] = state[1, 0];
            state[1, 0] = temp;

            temp = state[2, 0];
            state[2, 0] = state[2, 2];
            state[2, 2] = temp;

            temp = state[2, 1];
            state[2, 1] = state[2, 3];
            state[2, 3] = temp;

            temp = state[3, 0];
            state[3, 0] = state[3, 1];
            state[3, 1] = state[3, 2];
            state[3, 2] = state[3, 3];
            state[3, 3] = temp;

            return state;
        }
    }
}
