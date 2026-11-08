using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh._01_funcionario 
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

        public static string Get(
            int vrh_funcionario_cd,
            string vrh_funcionario_nome
            
            )
        {
            try
            {
               string _PostGre_GET = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0141_01_rh_funcionario) + "( {0}, '{1}' ) ",
                                    vrh_funcionario_cd.ToString(),
                                    vrh_funcionario_nome.ToString().ToUpper().Replace("'", "")
                   );


               return _PostGre_GET;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
