using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_62_Controle_Reg_OBS_List
    {
        private static string _VERSION() { return "f0130_62_1011950_controle_reg_obs_list"; }
        public static string Get( int controle_reg_seq )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + " ( {0} )",  controle_reg_seq.ToString()  );
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


