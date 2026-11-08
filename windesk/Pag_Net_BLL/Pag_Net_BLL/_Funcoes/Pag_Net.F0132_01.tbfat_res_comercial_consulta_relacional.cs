using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0132_01
{
    public static class PostGre
    {
        public static string Get(filter filter)
        {
            string POSTGRE_SQL = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0132_01_tbfat_res_comercial_consulta_relacional) +  
                                                  "   (         {0}         " +
                                                  "          ,  {1}         " +
                                                  "          ,  {2}         )",
                                                   filter.fat_res_seq.ToString(),
                                                   filter.fv_fabricante_cdpessoabluesoft.ToString(),
                                                   filter.cm_pre_ped_seq.ToString());
           return POSTGRE_SQL;
        }
    }

    public class filter
    {

        public int fat_res_seq                      {get; set; }
	    public int fv_fabricante_cdpessoabluesoft   {get; set; }
        public int cm_pre_ped_seq                   { get; set;  }
        public filter(
            
            int _fat_res_seq                    ,
            int _fv_fabricante_cdpessoabluesoft ,
            int _cm_pre_ped_seq                 
            )
        {
            fat_res_seq = _fat_res_seq;
            fv_fabricante_cdpessoabluesoft = _fv_fabricante_cdpessoabluesoft;
            cm_pre_ped_seq = _cm_pre_ped_seq;

        }

    }
}
