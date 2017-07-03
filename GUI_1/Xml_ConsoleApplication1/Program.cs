using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace Xml_ConsoleApplication1
{
    class Program
    {
        public bool invalid = false;
        static void Main(string[] args)
        {

            //email_validation();
            bool a=IsValidEmail("a@a");
            Console.WriteLine(a);


            //Console.WriteLine("1.Write\n2.Read\n3.Append \n");
            //int ch = Convert.ToInt32(Console.ReadLine());
            //if (ch == 1)
            //{
            //    write_xml();
            //}
            //else if (ch == 2)
            //{
            //    read_xml();
            //}
            //else if (ch == 3)
            //{
            //    append_xml();
            //}

            //DateTime dt=DateTime.Now.Date;
            //string date = Convert.ToString(dt.ToString("dd-MM-yyyy"));
            //Console.WriteLine(date);
            
            Console.ReadKey();            
        }


 private static bool IsValidEmail(string email)
{
    try {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
    }
    catch {
        return false;
    }
}






        private static void email_validation()
        {
            Console.WriteLine("Processing");
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch("sky1508@asdfa.in", pattern))
            {

                Console.WriteLine("Valid Email address ");
            }
            else
            {
                Console.WriteLine("Not a valid Email address ");
            }

        }

        private static void append_xml()
        {
            XmlDocument xd = new XmlDocument();
            xd.Load("D:\\Appdata\\cipher.xml");
            XmlNode nl = xd.SelectSingleNode("//Encryption");
            XmlDocument xd2 = new XmlDocument();
            xd2.LoadXml("<folder_name>C:\\Users\\Sushil\\Desktop\\pro_dev\\test15_int_folder_name.txt</folder_name>");
            XmlNode n = xd.ImportNode(xd2.FirstChild, true);
            nl.AppendChild(n);
            xd.Save("D:\\Appdata\\cipher.xml");
        }

private static void write_xml()
{
            string inp_file = "C:\\Users\\Sushil\\Desktop\\pro_dev\\test15_int_name.txt";
            string file_length = "16";

            string ver = "v1.0";
            DateTime dt = DateTime.Now.Date;
            string date = Convert.ToString(dt.ToString("dd-MM-yy"));
            string auto_up = "ON";
            string no_of_en_files = "12";
            try
            {
                Directory.CreateDirectory("D:\\Appdata");
                //using (XmlWriter writer = XmlWriter.Create("D:\\Appdata\\cipher.xml"))
                using (XmlWriter writer = XmlWriter.Create("D:\\Appdata\\splash.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Encryption");
                    //writer.WriteElementString("file_name", inp_file);
                    //writer.WriteElementString("file_length", file_length);
                    writer.WriteElementString("version_info",ver);
                    writer.WriteElementString("Last_used", date);
                    writer.WriteElementString("no_of_en_files", no_of_en_files);
                    writer.WriteElementString("Auto_up", auto_up);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
              
               //  foreach (Employee employee in employees)     
               //  {  
               //      writer.WriteStartElement("Employee");
               //      writer.WriteElementString("ID", employee.Id.ToString());  
               //      writer.WriteElementString("FirstName", employee.FirstName);  
               //      writer.WriteElementString("LastName", employee.LastName);  
               //      writer.WriteElementString("Salary", employee.Salary.ToString());
               //      writer.WriteEndElement();     
               //}
            Console.WriteLine("Done");
               
}

private static void read_xml()
{
    using (XmlReader reader = XmlReader.Create("D:\\Appdata\\cipher.xml"))
    {
        while (reader.Read())
        {
            if (reader.IsStartElement())
            {      
                switch (reader.Name)
                {
                    case "file_name":
                        string attribute = reader["name"];
                        if (attribute != null)
                        {
                            Console.WriteLine("Has attr name " + attribute);
                        }

                        if (reader.Read())
                        {
                            Console.WriteLine("  Text node: " + reader.Value.Trim());
                        }
                        break;

                    case "file_length":
                        attribute = reader["name"];
                        if (attribute != null)
                        {
                            Console.WriteLine("Has attr name " + attribute);
                        }

                        if (reader.Read())
                        {
                            Console.WriteLine("  Text node: " + reader.Value.Trim());
                        }
                        break;

                    case "id3":
                        attribute = reader["name"];
                        if (attribute != null)
                        {
                            Console.WriteLine("Has attr name " + attribute);
                        }

                        if (reader.Read())
                        {
                            Console.WriteLine("  Text node: " + reader.Value.Trim());
                        }
                        break;

                }
            }
        }
    }
}
    }
       
}
