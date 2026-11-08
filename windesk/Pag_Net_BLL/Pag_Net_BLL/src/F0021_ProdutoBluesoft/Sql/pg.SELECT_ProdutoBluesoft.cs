using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0021_ProdutoBluesoft.scripts
{
    public class report_SELECT_ProdutoBlueSoft
    {
        private static string _VERSION() { return ""; }
        public static string Get(
                   Pag_Net.Models.modelSistemaUsuario MyConnect
                ,  interfaces.iF0021_ProdutoBlueSoft_filter filtro
     

               )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = string.Format("select 		prb.prb_cdprodutobluesoft_pk as prb_cdprodutobluesoft" + 
		                                    "            ,	prb.prb_cdprodutobluesoftunitario " +  
		                                    "            ,	prb.prb_descricao " +  
		                                    "            ,	prb.prb_embalagemestoque " +  
		                                    "            ,	prb.prb_fatorestoque  " + 
		                                    "            ,	coalesce(prb.prb_status_embalagemcaixa , 'false') as prb_status_embalagemcaixa " + 
		                                    "            , 	case when coalesce(prb.prb_status_embalagemcaixa , 'false') = 'true' then 'S' else 'N' end as Caixa " + 
		                                    "            ,	prb.prb_embalagemcompra " +  
		                                    "            ,	coalesce(prb.prb_embalagemcompra_qtdeunitaria,0) as prb_embalagemcompra_qtdeunitaria " +  
		                                    "            ,	coalesce(prb.prb_cdbarra_principal,'') as prb_cdbarra_principal " + 
		                                    "            ,	coalesce(prb.prb_cdprodutobluesoft_controleestoque,0 ) as prb_cdprodutobluesoft_controleestoque " + 
		                                    "            ,	coalesce(prb.prb_cdprodutobluesoft_controlepreco,0) as prb_cdprodutobluesoft_controlepreco " + 
		                                    "            ,	coalesce(prb.prb_cdsubgrupo,0) as prb_cdsubgrupo " + 
		                                    "            ,	coalesce(prb.prb_dt_cadastro, '1900-01-01') as prb_dt_cadastro " + 
		                                    "            ,	coalesce(prb.prb_dt_ultimaalteracao, '1900-01-01') as prb_dt_ultimaalteracao " + 
		                                    "            ,	coalesce(prb.prb_cdpessoabluesoft_fabricante,0) as prb_cdpessoabluesoft_fabricante " +  
		                                    "            ,	coalesce(prb.prb_vendaexterna, 'false') as prb_vendaexterna  " + 
		                                    "            , 	case when coalesce(prb.prb_vendaexterna , 'false') = 'true' then 'Ativo' else 'Inativo' end as label_descricao_vendaexterna " +  		
		                                    "            , 	coalesce(prb.prb_status, 'false') as prb_status " +  
		                                    "            , 	case when coalesce(prb.prb_status , 'false') = 'true' then 'Ativo' else 'Inativo' end as label_prb_status " + 
		                                    "            ,	coalesce(prb.prb_dtupdate_from_api, '1900-01-01') as prb_dtupdate_from_api " + 
		                                    "            ,	coalesce(prb.dtlog_insert, '1900-01-01') as dtlog_insert " + 
		                                    "            ,	coalesce(prb.dtlog_update, '1900-01-01') as dtlog_update " + 
		                                    "            ,	coalesce(prb.prb_descricao_fiscal, '') as prb_descricao_fiscal " + 
		                                    "            ,	coalesce(prb.prb_cdproduto_compra_padrao,0) as prb_cdproduto_compra_padrao " + 
		                                    "            ,	coalesce(prb.prbf_seq) as prbf_seq " +  
		                                    "            ,	coalesce(prb.prb_tipo_composicao_cd) as prb_tipo_composicao_cd " +  
		                                    "            ,	coalesce(prb.prb_descricao_gondola) as prb_descricao_gondola " + 
		                                    "            ,	coalesce(prb.prb_descricao_cupom) as prb_descricao_cupom " +  
		                                    "            ,	coalesce(prb.prb_descricao_balanca) as prb_descricao_balanca " +  
		                                    "            ,	coalesce(prb.prb_cdpessoabluesoft_fornecedor) as prb_cdpessoabluesoft_fornecedor " + 
		                                    "            ,	coalesce(prb.prb_cdpessoabluesoft_fornecedor_troca) as prb_cdpessoabluesoft_fornecedor_troca " +  
		                                    "            ,	coalesce(prb.prb_pesobruto,0) as prb_pesobruto " + 
		                                    "            ,	coalesce(prb.prb_pesoliquido,0) as prb_pesoliquido " + 
                                            "    from 		tbprodutobluesoft prb" + 
                                            "    left join  tbproduto pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoft_pk " + 
                                            " where     1 = 1 " + 
                                            "" + (filtro.prb_cdprodutoBlueSoft != 0 ? " and prb.prb_cdprodutobluesoft_pk = " + filtro.prb_cdprodutoBlueSoft.ToString() : "") +
                                            "" + (filtro.prb_descricao != "" ? " and prb.prb_descricao like '%" + filtro.prb_descricao.ToString() + "%'" : "") + 
                                            "" + (filtro.pr_cdproduto != 0 ? " and pr.pr_cdproduto = " + filtro.pr_cdproduto.ToString() : "") + 
                                            "" + (filtro.prb_descricao_fiscal != "" ? " and prb.prb_descricao_fiscal like '%" + filtro.prb_descricao_fiscal.ToString() + "%'" : "")
                                            );
                if ( filtro.Status_Ativo && !filtro.Status_Inativo)
                    SQL_POSTGRE += " and prb.pr_status = 'true' ";

                if ( !filtro.Status_Ativo && filtro.Status_Inativo)
                    SQL_POSTGRE += " and prb.pr_status = 'false' ";

                if (filtro.Seleciona_Data_Cadastro)
                {
                    SQL_POSTGRE += " and prb.prb_dt_cadastro >= '" + filtro.prb_dt_cadastro_ini.ToString("yyyy-MM-dd") + "' ";
                    SQL_POSTGRE += " and prb.prb_dt_cadastro <= '" + filtro.prb_dt_cadastro_fim.ToString("yyyy-MM-dd") + "' ";
                }


                if (filtro.Seleciona_Data_AtualizacaoAPI)
                {
                    SQL_POSTGRE += " and prb.prb_dtupdate_from_api >= '" + filtro.prb_dt_atualizacaoAPI_ini.ToString("yyyy-MM-dd") + " 01:01:01" + "' ";
                    SQL_POSTGRE += " and prb.prb_dtupdate_from_api <= '" + filtro.prb_dt_atualizacaoAPI_fim.ToString("yyyy-MM-dd") + " 23:59:59" + "' ";
                }

                if (filtro.prbg_cdbarra_pk != "")
                    SQL_POSTGRE += " and prb.prb_cdprodutobluesoft_pk in ( " + 
                                   "                select       xu.prb_cdprodutobluesoftunitario " + 
                                   "                from         tbprodutobluesoft_gtins cb " + 
                                   "                inner join   tbprodutobluesoft xu on xu.prb_cdprodutobluesoft_pk = cb.prb_cdprodutobluesoft " + 
                                   "                where        1 = 1 " +
                                   "                  and        cb.prbg_cdbarra_pk like '%" + filtro.prbg_cdbarra_pk.ToString().Trim() + "%' " +
                                   "                group by xu.prb_cdprodutobluesoftunitario ) ";


                SQL_POSTGRE += " ORDER BY prb.prb_descricao, prb_descricao asc ";

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
