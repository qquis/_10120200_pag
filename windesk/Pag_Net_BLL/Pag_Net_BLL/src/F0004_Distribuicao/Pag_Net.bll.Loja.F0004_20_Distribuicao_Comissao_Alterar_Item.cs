using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Distribuicao
{
    public class F0004_20_Distribuicao_Comissao_Alterar_Item
    {
        private static string _VERSION() { return "f0004_20_1011980_distribuicao_comissao_alterar_item"; }
        public static string Post(int fvc_it_seq
                                    , double percentual_valor
           
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() 
                    + "("
                    + "   vfvc_it_seq:= " + fvc_it_seq.ToString()
                    + " , vpercentual_valor:= " + percentual_valor.ToString("0.00").Replace(",",".")
                    + ")" 
                    );
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
