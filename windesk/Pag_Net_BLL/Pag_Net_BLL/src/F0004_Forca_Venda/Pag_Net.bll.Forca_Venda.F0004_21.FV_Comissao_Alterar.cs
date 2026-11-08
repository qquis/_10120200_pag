using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class F0004_21_FV_Comissao_Alterar
    {
        private static string _VERSION() { return "f0004_21_1011996_fv_comissao_alterar"; }
        public static string Post(int vfvc_seq
                                    , double vfvc_fat_valor_pgto_complemento
                                    , double vfvc_fat_valor_pgto_impostos
                                    , double vfvc_fat_valor_pgto_adiantamentos
           
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() 
                    + "("
                    + "   vfvc_seq:= " + vfvc_seq.ToString()
                    + " , vfvc_fat_valor_pgto_complemento:= " + vfvc_fat_valor_pgto_complemento.ToString("0.00").Replace(",", ".")
                    + " , vfvc_fat_valor_pgto_impostos:= " + vfvc_fat_valor_pgto_impostos.ToString("0.00").Replace(",", ".")
                    + " , vfvc_fat_valor_pgto_adiantamentos:= " + vfvc_fat_valor_pgto_adiantamentos.ToString("0.00").Replace(",", ".")
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
