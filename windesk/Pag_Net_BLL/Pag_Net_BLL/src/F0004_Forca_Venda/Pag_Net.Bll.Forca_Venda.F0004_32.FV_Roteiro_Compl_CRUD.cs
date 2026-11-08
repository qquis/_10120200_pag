using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;


namespace Pag_Net.Bll.F0004_Forca_Venda
{

    public static class F0004_32_FV_Roteiro_Compl_CRUD
    {
        public static string _VERSION() { return "f0004_32_1011990_fv_roteiro_compl_crud"; }
        public static string RedShift_Select(
            DateTime data_inicial,
            DateTime data_final
            )
        {

            string SQL_REDSHIFT =
                string.Format("select   cast( 0 as int)                             as roteiro_compl_seq               " + 
                              "     ,   coalesce(c.roteiro_entrega_key,0)           as roteiro_cd                      " +                          
                              "     ,   coalesce(c.log_roteiro_entrega_key,0)       as roteiro_compl_cd                " + 
                              "     ,   coalesce(c.data,'1900-01-01')               as roteiro_compl_data              " + 
                              "     ,   coalesce(c.valor_adicional,0)               as roteiro_compl_vl_adicional      " + 
                              "     ,   coalesce(c.valor_desconto,0)                as roteiro_compl_vl_desconto       " + 
                              "     ,   left(coalesce(c.motivo,''),60)              as roteiro_compl_motivo            " + 
                              "     ,   coalesce(c.usuario_key,0)                   as cdpessoabluesoft_usuario        " + 
                              " from        log_roteiro_entrega c                                                      " + 
                              " inner join  roteiro_entrega r on r.roteiro_entrega_key = c.roteiro_entrega_key         " + 
                              " where      1 = 1                                                                       " + 
                              " and       r.data_criacao >= '{0}'"+ 
                              " and       r.data_criacao <= '{1}'",
                              data_inicial.ToString("yyyy-MM-dd"),
                              data_final.ToString("yyyy-MM-dd"));
            return SQL_REDSHIFT;

        }
    }
    


}



