using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0150_Estatistica.Consultar_Info
{
    public static class RedShift
    {
        public static string get()
        {
            return "";
        }
    }


    
    public static class Postgre
    {
        public static string _Version() 
        {
            return "f0150_10_1011914_estatistica_info";
        }
        public static string get()
        {
            try
            {
                
                string _PostGre = string.Format("SELECT * FROM " + _Version() + "(  ) " );
                return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
