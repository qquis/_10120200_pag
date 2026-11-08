using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;


namespace Pag_Net.Bll.F0004_Forca_Venda
{

    public static class F0004_30_FV_Roteiro_CRUD
    {
        public static string _VERSION() { return "f0004_30_1011990_fv_roteiro_crud"; }
        public static string RedShift_Select(
            DateTime data_inicial,
            DateTime data_final
            )
        {

            string SQL_REDSHIFT =
                string.Format("select     cast(0 as int)                                as roteiro_seq " + 
                      "               ,   roteiro_entrega_key                           as roteiro_cd " + 
                      "               ,   coalesce(veiculo_entrega_key,0)               as veiculo_bluesoft_cd " +
                      "               ,   coalesce(motorista_key,0)                     as cdpessoabluesoft_motorista " +
                      "               ,   data_criacao                                  as roteiro_data_lanc " +
                      "               ,   coalesce(previsao_data_entrega, '1900-01-01') as roteiro_data_prev_entrega " +
                      "               ,   coalesce(data_hora_saida, '1900-01-01')       as roteiro_data_saida " +
                      "               ,   coalesce(data_hora_retorno,'1900-01-01')      as roteiro_data_retorno " +
                      "               ,   coalesce(descricao,'')                        as roteiro_descricao  " +
                      "               ,   coalesce(roteiro_grupo_key,0)                 as roteiro_grupo_cd " + 
                      "               ,   coalesce(valor_desconto,0)                    as roteiro_valor_desconto " +  
                      "               ,   coalesce(motivo_cancelamento,'')              as roteiro_motivo_cancelamento " +
                      "               ,   coalesce(data_cancelamento,'1900-01-01')      as roteiro_data_cancelamento " +
                      "               ,   case when coalesce(data_cancelamento, '1900-01-01') != '1900-01-01' then 1 else 0 end  as roteiro_status " +
                      "               ,   cast(coalesce(data_hora_saida, '1900-01-01') as date)   as roteiro_data_fechamento " +
                      "         from      roteiro_entrega " +
                      "         where     1 = 1 " +
                      "         and       data_criacao >= '{0}'" + 
                      "         and       data_criacao <= '{1}'",
                                             data_inicial.ToString("yyyy-MM-dd"),
                                             data_final.ToString("yyyy-MM-dd"));
            return SQL_REDSHIFT;

        }
    }
    


}



