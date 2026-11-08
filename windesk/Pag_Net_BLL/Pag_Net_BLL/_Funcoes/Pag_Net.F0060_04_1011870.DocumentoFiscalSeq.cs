using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;


namespace Pag_Net.Bll.F0060_04
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
                   string.Format(     "Select       nf.loja_key                     as      em_cdempresabluesoft                 " +
                                      "       ,     cast(0 as int)                  as      un_operacao_cd                       " + 
                                      "       ,     nf.nf_key                       as      df_nf_seq_blue                       " + 
                                      "       ,     nf.nf_numero                    as      df_nf_numero                         " + 
                                      "       ,     nf.nf_serie                     as      df_nf_serie                          " + 
                                      "       ,     nf.nf_tipo_key                  as      df_nf_tipo                           " + 
                                      "       ,     ps.pessoa_key                   as      cdpessoabluesoft                     " +
                                      "       ,     nf.data_emissao                 as      df_data_emissao                      " + 
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
             Db item)
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


    public class Db
    {

        public int df_nf_seq_blue { get; set; }
        public int df_nf_numero { get; set; }
        public string df_nf_serie { get; set; }
        public int df_nf_tipo { get; set; }
        public int cdpessoabluesoft { get; set; }
        public DateTime df_data_emissao { get; set; }
        public int em_cdempresabluesoft { get; set; }


        public Db() { }
        public Db(DataRow i)
        {

            df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
            df_nf_numero = Convert.ToInt32(i["df_nf_numero"].ToString());
            df_nf_serie = i["df_nf_serie"].ToString();
            df_nf_tipo = Convert.ToInt32(i["df_nf_tipo"].ToString());
            cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
            df_data_emissao = Convert.ToDateTime(i["df_data_emissao"]);
            em_cdempresabluesoft = Convert.ToInt32(i["em_cdempresabluesoft"]);


        }





    }


}

