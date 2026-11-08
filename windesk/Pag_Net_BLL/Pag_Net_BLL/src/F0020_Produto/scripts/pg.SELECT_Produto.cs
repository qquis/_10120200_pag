using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.scripts
{
    public class report_SELECT_Produto
    {
        private static string _VERSION() { return ""; }
        public static string Get(
                   Pag_Net.Models.modelSistemaUsuario MyConnect
                ,  interfaces.iF0020_Produto_filter filtro
     

               )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = string.Format("select 	pr.pr_seq                       as pr_seq                                                         " +
                                            "         ,	coalesce(pr.dtlog_insert,'1900-01-01')                  as dtlog_insert                          " +
                                            "         ,	coalesce(pr.dtlog_update,'1900-01-01')                  as dtlog_update                          " +
                                            "         ,	coalesce(pr.dtlog_update_api,'1900-01-01')  as dtlog_update_api                                   " +
                                            "         ,	pr.pr_cdproduto                 as pr_cdproduto                                                   " +
                                            "         ,	pr.prb_cdprodutobluesoft        as prb_cdprodutobluesoft                                          " +
                                            "         , prb.prb_dt_cadastro             as prb_dt_cadastro                                                " + 
                                            "         ,	pr.pr_descricao                 as pr_descricao                                                   " +
                                            "         , prb.prb_descricao               as prb_descricao                                                  " + 
                                            "         , prb.prb_descricao_fiscal        as prb_descricao_fiscal                                           " +
                                            "         ,	pr.pr_embalagemestoque          as pr_embalagemestoque                                            " +
                                            "         ,	pr.pr_embalagemcompra           as pr_embalagemcompra                                             " +
                                            "         ,	pr.pr_embalagemcompra_fator     as pr_embalagemcompra_fator                                       " +
                                            "         ,	pr.pr_cdbarra_principal         as pr_cdbarra_principal                                           " +
                                            "         , cast( case when coalesce(pr.pr_status, 'false') then 'Ativo' else 'Inativo' end as varchar(7)) as label_descricao_pr_status " +
                                            "         , cast( case when coalesce(pr.pr_cesta, 'false') then 'Cesta' else '' end as varchar(7)) as label_descricao_pr_cesta " + 
                                            "         ,	pr.cdpessoabluesoft_fabricante                                                                    " +
                                            "         ,	pr.prbf_seq                                                                                       " +
                                            "         ,	pr.prb_cdproduto_compra_padrao                                                                    " +
                                            "         ,	pr.prsg_cdsubgrupo                                                                                " +
                                            "         ,	coalesce(pr.pr_status_comercial_preco_inativo,0) as pr_status_comercial_preco_inativo             " +
                                            "         , coalesce(pr.pr_status, 'false' ) as pr_status " +
                                            "         , coalesce(pr.pr_cesta, 'false' ) as pr_cesta " + 
                                            "         , coalesce(prb.prb_pesobruto, 0) as prb_pesobruto " +
                                            "         , coalesce(prb.prb_pesoliquido, 0) as prb_pesoliquido " +
                                            " from 	tbproduto pr                                                                                          " + 
                                            " left  join tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft " + 
                                            " where     1 = 1 " + 
                                            "" + ( filtro.pr_cdproduto != 0? " and pr.pr_cdproduto = " + filtro.pr_cdproduto.ToString(): "") +  
                                            "" + ( filtro.prb_cdprodutoBlueSoft != 0? " and pr.prb_cdprodutobluesoft = " + filtro.prb_cdprodutoBlueSoft.ToString(): "") +
                                            "" + ( filtro.pr_descricao != "" ? " and pr.pr_descricao like '%" + filtro.pr_descricao.ToString().ToUpper() + "%'" : "") +
                                            "" + ( filtro.prb_descricao != "" ? " and prb.prb_descricao like '%" + filtro.prb_descricao.ToString().ToUpper() + "%'" : "")
                                            );
                if ( filtro.Status_Ativo && !filtro.Status_Inativo)
                    SQL_POSTGRE += " and pr.pr_status = 'true' ";

                if ( !filtro.Status_Ativo && filtro.Status_Inativo)
                    SQL_POSTGRE += " and pr.pr_status = 'false' ";

                if (filtro.Seleciona_Data_Cadastro)
                {
                    SQL_POSTGRE += " and prb.prb_dt_cadastro >= '" + filtro.prb_dt_cadastro_ini.ToString("yyyy-MM-dd") + "' ";
                    SQL_POSTGRE += " and prb.prb_dt_cadastro <= '" + filtro.prb_dt_cadastro_fim.ToString("yyyy-MM-dd") + "' ";
                }

                if (filtro.prbg_cdbarra_pk != "")
                    SQL_POSTGRE += " and prb.prb_cdprodutobluesoft_pk in ( " + 
                                   "                select       xu.prb_cdprodutobluesoftunitario " + 
                                   "                from         tbprodutobluesoft_gtins cb " + 
                                   "                inner join   tbprodutobluesoft xu on xu.prb_cdprodutobluesoft_pk = cb.prb_cdprodutobluesoft " + 
                                   "                where        1 = 1 " +
                                   "                  and        cb.prbg_cdbarra_pk like '%" + filtro.prbg_cdbarra_pk.ToString().Trim() + "%' " +
                                   "                group by xu.prb_cdprodutobluesoftunitario ) ";


                SQL_POSTGRE += " ORDER BY pr.pr_descricao, prb_descricao asc ";

                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.src.F0020_Produto.scripts.report_SELECT_Produto " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }
    }
}
