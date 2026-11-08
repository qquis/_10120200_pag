using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus.F0055_03_Faturamento_Excluir
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
        public static string Post(
             int SeqFaturamento
            )
        {
            try
            {
                string _PostGre = string.Format("SELECT * FROM " +
                    Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0055_03_Faturamento_Excluir) + "( {0} ) ",
                        SeqFaturamento.ToString()
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
