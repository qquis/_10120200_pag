using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus.F0055_21_Faturamento_Zanthus_Item_Consultar
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

        public static string Version() { return "f0055_21_1011914_faturamento_zanthus_item_consultar"; }
        public static string Get(
                   DateTime data_m00af
               , int sat_ecf_m00ac
                , int cupomfiscal_m00ad
            )
        {
            try
            {


                string _PostGre = string.Format("SELECT * FROM " + Version() + "( '{0}', {1}, {2}) ", 
                      data_m00af.ToString("yyyy-MM-dd"), 
                      sat_ecf_m00ac.ToString(), 
                      cupomfiscal_m00ad.ToString()
                    );
                return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
