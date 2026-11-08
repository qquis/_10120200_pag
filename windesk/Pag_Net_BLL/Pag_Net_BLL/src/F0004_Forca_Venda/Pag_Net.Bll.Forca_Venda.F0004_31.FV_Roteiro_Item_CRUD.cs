using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;


namespace Pag_Net.Bll.F0004_Forca_Venda
{

    public static class F0004_31_FV_Roteiro_Item_CRUD
    {
        public static string _VERSION() { return "f0004_31_1011990_fv_roteiro_item_crud"; }
        public static string RedShift_Select(
            DateTime data_inicial,
            DateTime data_final
            )
        {

            string SQL_REDSHIFT =
                string.Format("select     coalesce(pv.cliente_key,0)                                as cdpessoabluesoft_cliente " + 
                              "        ,  coalesce(a.roteiro_entrega_key,0)                         as roteiro_cd " + 
                              "        ,  coalesce(a.roteiro_pedido_cliente_key,0)                  as roteiro_item_cd " + 
                              "        ,  coalesce(pv.nf_key,0)                                     as df_nf_seq_blue " +
                              "        ,  coalesce(pv.pedido_cliente_venda_key,0)                   as numeropedido " + 
                              "        ,  left(coalesce(a.observacao,''),60)                        as roteiro_obs " + 
                              "        ,  coalesce(a.valor_frete_base,0)                            as roteiro_frete_percentual " + 
                              "        ,  coalesce(a.valor_frete_final,0)                           as roteiro_frete_valor " + 
                              "        ,  left(coalesce(a.tipo_valor_frete,''),15)                  as roteiro_tipo_calculo " + 
                              "        ,  coalesce(a.remunerar_nao_entregue,0)                      as roteiro_remunerar_nao_entregue " + 
                              "        ,  coalesce(a.ordem_entrega,0)                               as roteiro_ordem  " + 
                              "        ,  left(coalesce(a.tipo_origem,''),25)                       as roteiro_tipo_origem " + 
                              "        ,  left(coalesce(a.status_entrega,''),25)                    as roteiro_status_entrega " +
                              "        ,  coalesce(a.observacao_key,0)                              as roteiro_obs_key " +
                              "        ,  left(coalesce(a.motivo_mercadoria_nao_entregue,''),60)    as roteiro_obs_nao_entregue " + 
                              " from       roteiro_pedido_cliente   a " + 
                              " inner join roteiro_entrega          r  on r.roteiro_entrega_key = a.roteiro_entrega_key " +
                              " inner join fato_pedido_forca_venda  pv on pv.pedido_cliente_venda_key = a.pedido_origem_key " + 
                              " where     1 = 1 " +
                              " and       data_criacao >= '{0}'" + 
                              " and       data_criacao <= '{1}'",
                                          data_inicial.ToString("yyyy-MM-dd"),
                                          data_final.ToString("yyyy-MM-dd"));
            return SQL_REDSHIFT;

        }
    }
    


}



