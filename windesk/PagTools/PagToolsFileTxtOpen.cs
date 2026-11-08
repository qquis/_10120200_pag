using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pag_Net.Tools
{
    public static class PagToolsFileTxt
    {
        public  static string open(string path_file_name)
        {
            try
            {
                FileStream fsread = new FileStream(path_file_name,
                   FileMode.Open,
                   FileAccess.Read);
                StreamReader x = new StreamReader(fsread, Encoding.Default);
                return x.ReadToEnd();
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Tools.PagToolsFileTxt.Open: " + ex.Message);
            }
        }
    }
}
