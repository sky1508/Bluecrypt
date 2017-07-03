using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace Folder_zip
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(@"C:\\Users\\Sushil\\Desktop\\pro_dev\\csharp");
                zip.Save("C:\\Users\\Sushil\\Desktop\\pro_dev\\csharp1.zip");
                Console.WriteLine("Done zipping");
                zip.ExtractAll("C:\\Users\\Sushil\\Desktop\\pro_dev\\csharp2.zip");
                Console.WriteLine("Done unzipping");
            }

           // Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
