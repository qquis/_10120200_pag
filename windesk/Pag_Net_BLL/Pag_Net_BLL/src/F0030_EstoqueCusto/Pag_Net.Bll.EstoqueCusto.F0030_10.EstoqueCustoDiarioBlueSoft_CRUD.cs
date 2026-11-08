using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0030_EstoqueCusto;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public static class F0030_10_EstoqueCustoDiarioBlueSoft_CRUD
    {
        private static string _VERSION() { return "f0030_10_1011950_tbestoquecusto_diariobluesoft_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbEstoqueCusto_DiarioBlueSoft item
            )
        {
            try
            {
                string RedShift_SELECT = String.Format("SELECT  " + _VERSION() + " ('{0}', {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, '{19}')",
                                              BDCommnadType,
                                              item.prb_cdprodutobluesoft,
                                              item.ecdb_data.ToString("yyyy-MM-dd"),
                                              item.ecdb_embalagemestoque_qtde.ToString().Replace(",", "."),
                                              item.ecdb_embalagemestoque_qtde_online.ToString().Replace(",", "."),
                                              item.ecdb_embalagemestoque_fv_pendente.ToString().Replace(",", "."),
                                              item.ecdb_valor_custo_precificacao.ToString().Replace(",", "."),
                                              item.ecdb_valor_custo_faturamento.ToString().Replace(",", "."),
                                              item.ecdb_valor_customedio_comimposto.ToString().Replace(",", "."),
                                              item.ecdb_valor_customedio_semimposto.ToString().Replace(",", "."),
                                              item.ecdb_valor_ultimacompra_bruto.ToString().Replace(",", "."),
                                              item.ecdb_valor_ultimacompra_liq.ToString().Replace(",", "."),
                                              item.ecdb_composicao_vl_mao_de_obra.ToString().Replace(",", "."),
                                              item.ecdb_composicao_vl_custo_indireto.ToString().Replace(",", "."),
                                              item.ecdb_composicao_itens.ToString().Replace(",", "."),
                                              item.ecdb_composicao_QTDE.ToString().Replace(",", "."),
                                              item.ecdb_composicao_vl_custo.ToString().Replace(",", "."),
                                              item.ecdb_embalagemestoque_troca_ger_qtde.ToString().Replace(",", "."),
                                              item.ecdb_embalagemestoque_troca_cont_qtde.ToString().Replace(",", "."),
                                              "false");
                return RedShift_SELECT;                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static string RedShift_Select()
        {
            string RedShift_SELECT = "      select    cast(isnull(ES.produto_key,0)             as int)                 as prb_cdprodutobluesoft  " +
                         "             ,  ES.data                                                           as ecdb_data  " +
                         "             ,  cast(isnull(ES.quantidade,0)              as numeric(17,4))       as ecdb_embalagemestoque_qtde  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_embalagemestoque_qtde_online  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_embalagemestoque_fv_pendente  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_valor_custo_precificacao  " +
                         "             ,  cast(isnull(ES.custo_unitario_com_icm,0)  as numeric(17,4))       as ecdb_valor_custo_faturamento  " +
                         "             ,  cast(isnull(ES.custo_unitario_com_icm,0)  as numeric(17,4))       as ecdb_valor_customedio_comimposto  " +
                         "             ,  cast(isnull(ES.custo_unitario,0)          as numeric(17,4))       as ecdb_valor_customedio_semimposto  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_valor_ultimacompra_bruto   " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_valor_ultimacompra_liq  " +
                         "             ,  cast(data                                 as date)                as ecdb_data_atualizacao_dia  " +
                         "             ,  cast(data                                 as date)                as ecdb_data_atualizacao_online  " +
                         "             ,  cast(COALESCE(CPX.CUSTO_MAO_DE_OBRA,0)    AS numeric(17,4))       as ecdb_composicao_vl_mao_de_obra  " +
                         "             ,  cast(COALESCE(CPX.CUSTO_INDIRETO,0)       AS numeric(17,4))       as ecdb_composicao_vl_custo_indireto  " +
                         "             ,  cast(COALESCE(CP.COMPOSICAO_ITENS,0)      as numeric(17,4))       as ecdb_composicao_itens  " +
                         "             ,  cast(COALESCE(CP.COMPOSICAO_QTDE,0)       as numeric(17,4))       as ecdb_composicao_QTDE  " +
                         "             ,  cast(COALESCE(CP.COMPOSICAO_CUSTO,0)      as numeric(17,4))       as ecdb_composicao_vl_custo  " +
                         "             ,  cast(COALESCE(es.quantidade_troca_gerencial,0) as numeric(17,4))  as ecdb_embalagemestoque_troca_ger_qtde " + 
                         "             ,  cast(COALESCE(es.quantidade_troca_contabil,0) as numeric(17,4))   as ecdb_embalagemestoque_troca_cont_qtde " + 
                         "             from      estoque_diario ES  " +
                         "             LEFT JOIN custos_produto_producao CPX ON CPX.PRODUTO_KEY = ES.PRODUTO_KEY  " +
                         "             LEFT JOIN (  " +
                         "                          SELECT        CP.PRODUTO_FINAL                    AS PRODUTO_KEY   " +
                         "                              ,         COUNT(DISTINCT(CP.PRODUTO_PARTE))   AS COMPOSICAO_ITENS  " +
                         "                              ,         SUM(CP.QUANTIDADE)                  AS COMPOSICAO_QTDE  " +
                         "                              ,         SUM(COALESCE(ED.CUSTO_UNITARIO_COM_ICM,0) * COALESCE(CP.QUANTIDADE,0))  AS COMPOSICAO_CUSTO  " +
                         "                          FROM          COMPOSICAO        CP  " +
                         "                          LEFT JOIN     ESTOQUE_DIARIO    ED ON ED.PRODUTO_KEY = CP.PRODUTO_PARTE AND ED.DATA = CURRENT_DATE -1   " +
                         "                          INNER JOIN    (  " +
                         "                                              SELECT      produto_final             PRODUTO_KEY  " +
                         "                                                  ,      max(ULTIMA_ALTERACAO)     COMPOSICAO_DATA  " +
                         "                                              FROM     composicao  " +
                         "                                              GROUP BY produto_final  " +
                         "                                         ) CM ON CM.PRODUTO_KEY = CP.PRODUTO_FINAL AND CM.COMPOSICAO_dATA = CP.ULTIMA_ALTERACAO   " +
                         "                          GROUP BY CP.PRODUTO_FINAL  " +
                         "                      )   CP ON CP.PRODUTO_KEY = ES.PRODUTO_KEY  " +
                         "             where     1 = 1	  " +
                         "             and       es.data = current_date -1   ";

            return RedShift_SELECT;

        }
    }
}
