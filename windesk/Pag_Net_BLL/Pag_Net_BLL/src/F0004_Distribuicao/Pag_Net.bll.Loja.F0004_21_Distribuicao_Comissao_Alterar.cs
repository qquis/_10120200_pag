using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Distribuicao
{
    public class F0004_21_Distribuicao_Comissao_Alterar
    {
        private static string _VERSION() { return "f0004_21_1011980_distribuicao_comissao_alterar"; }
        public static string Post(int vfvc_seq
                                    , double vfvc_fat_valor_pgto_complemento
           
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() 
                    + "("
                    + "   vfvc_seq:= " + vfvc_seq.ToString()
                    + " , vfvc_fat_valor_pgto_complemento:= " + vfvc_fat_valor_pgto_complemento.ToString("0.00").Replace(",", ".")
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
