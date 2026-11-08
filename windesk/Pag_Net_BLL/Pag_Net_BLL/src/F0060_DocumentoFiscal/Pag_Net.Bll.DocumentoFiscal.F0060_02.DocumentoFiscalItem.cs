using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0061;
using Pag_Net.F0061.Models;

namespace Pag_Net.Bll.F0060_DocumentoFiscal._02_DocumentoFiscalItem
{

    public static class RedShift
    {
        public static string get(
            DateTime data_inicial,
            DateTime data_final
            )
        {
            string ErroInfo = "";
            try
            {
                string SQL_REDSHIFT = 
                   string.Format(     "     SELECT   it.loja_key                                    as em_cdempresabluesoft " + 
                                      "           ,   it.nf_key 								        as df_nf_seq_blue " + 
                                      "           ,  it.nota_fiscal_item_key 					    as df_nf_i_seq_blue " +
                                      "           ,  it.produto_key 							    as prb_cdprodutobluesoft " + 
	                                  "           ,  it.produto_origem_key                          as prb_cdprodutobluesoft_nf " + 
                                      "           ,  it.ni_unidade_medida_faturamento 	            as df_nf_i_embalagem " + 
	                                  "           ,  it.quantidade_faturada 					    as df_nf_i_qtde " + 
	                                  "           ,  it.custo_embalagem_final                       as df_nf_i_valor_total " + 
                                      "           ,  it.codigo_operacao_fiscal 				        as df_nf_i_cfop " + 
                                      "           ,  coalesce(it.ni_valor_bruto_total,0)            as df_nf_i_custo_bruto_total " +
                                      "           ,  coalesce(it.ni_fator_estoque,0)                as df_nf_i_fator_estoque" +
                                      "           ,  coalesce(it.ni_ipi_valor,0)                    as df_nf_valor_ipi" +
                                      "           ,  coalesce(it.ni_valor_icms,0)                   as df_nf_valor_icms" +
                                      "           ,  coalesce(it.ni_pis_valor,0)                    as df_nf_valor_pis" +
                                      "           ,  coalesce(it.ni_cofins_Valor,0)                 as df_nf_valor_cofins" +
                                      "           ,  coalesce(it.ni_base_calculo_icms,0)            as df_nf_base_icms_unitario" +
                                      "           ,  coalesce(it.ni_base_calculo_icms_total,0)      as df_nf_base_icms " +
                                      "           ,  coalesce(it.ni_base_calculo_icms_st_total,0)   as df_nf_base_icms_st" +
                                      "           ,  coalesce(it.ni_base_pis_total,0)               as df_nf_base_pis" +
                                      "           ,  coalesce(it.ni_base_cofins_total,0)            as df_nf_base_cofins" +
                                      "           ,  coalesce(it.ni_custo_contabil_total,0)         as df_nf_custo_contabil " +
                                      "           ,  coalesce(it.icm_key,0)                         as trib_cd_icms" +
                                      "           ,  coalesce(it.pis_key,0)                         as trib_cd_pis" +
                                      "           ,  coalesce(it.cofins_key,0)                      as trib_cd_cofins " +                              
                                      "      FROM        FATO_NOTA_FISCAL it  " + 
                                      "      inner join  nota_fiscal      nf on nf.nf_key = it.nf_key and nf.loja_key = it.loja_key " + 
                                      "      inner join  nota_fiscal_tipo tp on tp.nf_tipo_key = nf.nf_tipo_key " +
                                      "      where       1 = 1                                                                  " +
                                      "       and    (     ( nf.data_emissao     >= '{0}'  and  nf.data_emissao     <= '{1}'   )  " +
                                      "                 or ( nf.data_recebimento >= '{0}'  and  nf.data_recebimento <= '{1}'  )  " +
                                      "               ) " + 
                                      "      order by    1,2,3 asc",
                                                data_inicial.ToString("yyyy-MM-dd"),
                                                data_final.ToString("yyyy-MM-dd"));

                return SQL_REDSHIFT;
       

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0051 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
    public static class Postgres
    {
        public static string post(
             Pag_Net.Models.modelSistemaUsuario MyConnect,
             string _SqlCommand,
             bool _Api,
             Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscalItem item)
        {

            return string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0060_02) + " (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,     {1}             " +
                                   "       ,     {2}             " +
                                   "       ,     {3}             " +
                                   "       ,    '{4}'            " +
                                   "       ,    '{5}'            " +
                                   "       ,     {6}             " +
                                   "       ,     {7}             " +
                                   "       ,     {8}             " +
                                   "       ,     {9}             " +
                                   "       ,     {10}             " +
                                   "       ,     {11}             " +
                                   "       ,     {12}             " +
                                   "       ,     {13}             " +
                                   "       ,     {14}             " +
                                   "       ,     {15}             " +
                                   "       ,     {16}             " +
                                   "       ,     {17}             " +
                                   "       ,     {18}             " +
                                   "       ,     {19}             " +
                                   "       ,     {20}             " +
                                   "       ,     {21}             " +
                                   "       ,     {22}             " +
                                   "       ,     {23}             )",
                                   item.df_nf_seq_blue.ToString(),
                                   item.df_nf_i_seq_blue.ToString(),
                                   item.prb_cdprodutobluesoft.ToString(),
                                   item.prb_cdprodutobluesoft_nf.ToString(),
                                   item.df_nf_i_embalagem.ToString(),
                                   item.df_nf_i_cfop.ToString(),
                                   item.df_nf_i_valor_total.ToString("0.00").Replace(",", "."),
                                   item.df_nf_i_qtde.ToString("0.0000").Replace(",", "."),
                                   item.df_nf_i_custo_bruto_total.ToString("0.00").Replace(",", "."),
                                   item.df_nf_i_fator_estoque.ToString("0.00").Replace(",", "."),
                                   item.df_nf_valor_ipi.ToString("0.00").Replace(",", "."),
                                   item.df_nf_valor_icms.ToString("0.00").Replace(",", "."),
                                   item.df_nf_valor_pis.ToString("0.00").Replace(",", "."),
                                   item.df_nf_valor_cofins.ToString("0.00").Replace(",", "."),
                                   item.df_nf_base_icms_unitario.ToString("0.00").Replace(",", "."),
                                   item.df_nf_base_icms.ToString("0.00").Replace(",", "."),
                                   item.df_nf_base_icms_st.ToString("0.00").Replace(",", "."),
                                   item.df_nf_base_pis.ToString("0.00").Replace(",", "."),
                                   item.df_nf_base_cofins.ToString("0.00").Replace(",", "."),
                                   item.df_nf_custo_contabil.ToString("0.00").Replace(",", "."),
                                   item.trib_cd_icms.ToString(),
                                   item.trib_cd_pis.ToString(),
                                   item.trib_cd_cofins.ToString(),
                                   item.em_cdempresabluesoft.ToString()
                                   );

        }
    }

}

