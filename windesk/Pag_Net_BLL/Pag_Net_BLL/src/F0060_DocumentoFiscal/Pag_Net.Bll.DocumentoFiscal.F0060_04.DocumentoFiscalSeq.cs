using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;


namespace Pag_Net.Bll.F0060_DocumentoFiscal._04_DocumentoFiscalSeq
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
                   string.Format("Select       nf.loja_key                     as      em_cdempresabluesoft                 " +
                                      "       ,     cast(0 as int)                  as      un_operacao_cd                       " +
                                      "       ,     coalesce(nf.nf_key,0)                       as      df_nf_seq_blue                       " +
                                      "       ,     coalesce(nf.nf_numero,0)                    as      df_nf_numero                         " +
                                      "       ,     coalesce(nf.nf_serie,'0')                     as      df_nf_serie                          " +
                                      "       ,     coalesce(nf.nf_tipo_key,0)                  as      df_nf_tipo                           " +
                                      "       ,     coalesce(ps.pessoa_key,0)                   as      cdpessoabluesoft                     " +
                                      "       ,     coalesce(nf.data_emissao,'1900-01-01')       as      df_data_emissao                      " +
                                      "      From        Nota_Fiscal         nf                                                  " +
                                      "      inner join  pessoa              ps on ps.pessoa_key = nf.fornecedor_key             " +
                                      "      INNER JOIN  NOTA_FISCAL_TOTAL   NT ON NT.NF_KEY = NF.NF_KEY                         " +
                                      "      inner join  nota_fiscal_tipo    tp on tp.nf_tipo_key = nf.nf_tipo_key               " +
                                      "      where       1 = 1                                                                   " +
                                      "      and         nf.nf_key >= ( select min(nf_key) from Nota_Fiscal nx where nx.data_emissao >= '{0}' ) " +
                                      "      order by    ps.nome_razao asc",
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
             Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscalSeq item)
        {

            string Script_PostGre_post = string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0060_04) + " (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,     {1}             " +
                                   "       ,    '{2}'            " +
                                   "       ,     {3}             " +
                                   "       ,     {4}             " +
                                   "       ,    '{5}'            " +
                                   "       ,    '{6}'            )",
                                   item.df_nf_seq_blue,
                                   item.df_nf_numero,
                                   item.df_nf_serie,
                                   item.df_nf_tipo,
                                   item.cdpessoabluesoft,
                                   item.df_data_emissao.ToString("yyyy-MM-dd"),
                                   item.em_cdempresabluesoft.ToString());
            return Script_PostGre_post;

        }
    }

}




