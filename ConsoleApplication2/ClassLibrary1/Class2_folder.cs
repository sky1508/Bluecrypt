using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace ClassLibrary1
{
    class Class2_folder
    {
        public string zipfolder(string fpath)
        {
            using (ZipFile zip = new ZipFile())
            {
                string temp_folder_name;
                zip.AddDirectory(@fpath);
                string zipname = fpath;
                zip.Save(fpath + "1.zip");
                temp_folder_name = fpath + "1.zip";              
                return temp_folder_name;
            }
        }

        public void unzipfolder(string fpath)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.ExtractAll(fpath + ".zip");
            }
        }
    }
}
