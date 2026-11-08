using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;


namespace Pag_Net.Bll.F0060_01
{

    public static class RedShift
    {
        public static string get(
            DateTime data_inicial,
            DateTime data_final
            )
        {

            string SQL_REDSHIFT =
                string.Format("Select           cast(nf.loja_key as int )       as      em_cdempresabluesoft                         " +
                                   "      ,     cast(0 as int)                  as      un_operacao_cd                       " +
                                   "      ,     nf.nf_key                       as      df_nf_seq_blue                       " +
                                   "      ,     nf.nf_numero                    as      df_nf_numero                         " +
                                   "      ,     nf.nf_serie                     as      df_nf_serie                          " +
                                   "      ,     nf.nf_tipo_key                  as      df_nf_tipo                           " +
                                   "      ,     CASE WHEN tp.entrada_saida = -1 THEN 'S' else 'E' end                        " +
                                   "                                                  as      df_entrada_saida               " +
                                   "      ,     ps.pessoa_key                   as      cdpessoabluesoft                     " +
                                   "      ,     nf.codigo_operacao_fiscal       as      df_cfop_generico                     " +
                                   "      ,     nf.data_emissao                 as      df_data_emissao                      " +
                                   "      ,     nf.data_saida                   as      df_data_saida                        " +
                                   "      ,     nf.data_recebimento             as      df_data_recebimento                  " +
                                   "      ,     nf.status_recebimento           as      df_status_recebimento                " +
                                   "      ,     NT.VALOR_TOTAL_NOTA             as      df_valor_total                       " +
                                   "      ,     NT.VALOR_TOTAL_MERCADORIAS      as      df_valor_total_mercadoria            " +
                                   "      ,     cast(ISNULL(NT.TOTAL_PALLETS,0) as numeric(13,0))      as      df_total_paletes                     " +
                                   "      ,     NT.TOTAL_EMBALAGENS             as      df_total_embalagens                  " +
                                   "      ,     isnull(nf.data_cancelamento,'1900-01-01')   as      df_data_cancelamento     " +
                                   "      ,     isnull(nf.usuario_cancelamento_key,0)     as      df_cdpessoabluesoft_cancelamento     " +
                                   "      ,     nf.numero_documento_origem      as      df_numero_documento_origem           " +
                                   "      ,     nf.chave                        as      df_chave                             " +
                                   "      ,     nf.protocolo_autorizacao        as      df_protocolo_autorizacao             " +
                                   "      ,     nf.tipo_status_nfe_key                                                       " +
                                   "      ,     isnull(nf.tipo_manifestacao_dest_key,0)   as      df_manifestacao                      " +
                                   "      From        Nota_Fiscal         nf                                                 " +
                                   "      inner join  pessoa              ps on ps.pessoa_key = nf.fornecedor_key            " +
                                   "      INNER JOIN  NOTA_FISCAL_TOTAL   NT ON NT.NF_KEY = NF.NF_KEY                        " +
                                   "      inner join  nota_fiscal_tipo    tp on tp.nf_tipo_key = nf.nf_tipo_key              " +
                                   "      where       1 = 1                                                                  " +
                                   "      and    (     ( nf.data_emissao     >= '{0}'  and  nf.data_emissao     <= '{1}'   )  " +
                                   "                or ( nf.data_recebimento >= '{0}'  and  nf.data_recebimento <= '{1}'  )  " + 
                                   "             ) " + 
                                   "      order by    ps.nome_razao asc",
                                             data_inicial.ToString("yyyy-MM-dd"),
                                             data_final.ToString("yyyy-MM-dd"));
            return SQL_REDSHIFT;

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
            try
            {
                string _PostGre_Post = string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0060_01) + " (	    " +
                                      "           'DBINSERT'        " +
                                      "       ,     {0}             " +
                                      "       ,     {1}             " +
                                      "       ,     {2}             " +
                                      "       ,    '{3}'            " +
                                      "       ,     {4}             " +
                                      "       ,     {5}             " +
                                      "       ,    '{6}'            " +
                                      "       ,    '{7}'            " +
                                      "       ,    '{8}'            " +
                                      "       ,    '{9}'            " +
                                      "       ,    '{10}'           " +
                                      "       ,    '{11}'           " +
                                      "       ,     {12}            " +
                                      "       ,     {13}            " +
                                      "       ,     {14}            " +
                                      "       ,     {15}            " +
                                      "       ,    '{16}'           " +
                                      "       ,     {17}            " +
                                      "       ,    '{18}'           " +
                                      "       ,    '{19}'           " +
                                      "       ,    '{20}'           " +
                                      "       ,     {21}            " +
                                      "       ,     {22}            " +
                                      "       ,    'false'          )",
                                      item.un_operacao_cd,
                                      item.df_nf_seq_blue,
                                      item.df_nf_numero,
                                      item.df_nf_serie,
                                      item.df_nf_tipo,
                                      item.cdpessoabluesoft,
                                      item.df_entrada_saida,
                                      item.df_cfop_generico,
                                      item.df_data_emissao.ToString("yyyy-MM-dd"),
                                      item.df_data_saida.ToString("yyyy-MM-dd"),
                                      item.df_data_recebimento.ToString("yyyy-MM-dd"),
                                      item.df_status_recebimento,
                                      item.df_valor_total.ToString().Replace(",", "."),
                                      item.df_valor_total_mercadoria.ToString().Replace(",", "."),
                                      item.df_total_paletes.ToString().Replace(",", "."),
                                      item.df_total_embalagens.ToString().Replace(",", "."),
                                      item.df_data_cancelamento.ToString("yyyy-MM-dd"),
                                      item.df_cdpessoabluesoft_cancelamento,
                                      item.df_numero_documento_origem,
                                      item.df_chave,
                                      item.df_protocolo_autorizacao,
                                      item.df_manifestacao,
                                      item.em_cdempresabluesoft.ToString()
                                      );
                return _PostGre_Post;
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0051 | Update: " + ex.Message);
            }
        }

    }
    public class Db
    {
        public int em_cdempresabluesoft { get; set; }
        public int un_operacao_cd { get; set; }
        public int df_nf_seq_blue { get; set; }
        public int df_nf_numero { get; set; }
        public string df_nf_serie { get; set; }
        public int df_nf_tipo { get; set; }
        public int cdpessoabluesoft { get; set; }
        public string df_entrada_saida { get; set; }
        public string df_cfop_generico { get; set; }
        public DateTime df_data_emissao { get; set; }
        public DateTime df_data_saida { get; set; }
        public DateTime df_data_recebimento { get; set; }
        public string df_status_recebimento { get; set; }
        public double df_valor_total { get; set; }
        public double df_valor_total_mercadoria { get; set; }
        public int df_total_paletes { get; set; }
        public double df_total_embalagens { get; set; }
        public DateTime df_data_cancelamento { get; set; }
        public int df_cdpessoabluesoft_cancelamento { get; set; }
        public string df_numero_documento_origem { get; set; }
        public string df_chave { get; set; }
        public string df_protocolo_autorizacao { get; set; }
        public int df_manifestacao { get; set; }


        public Db() { }
        public Db(DataRow i)
        {



            un_operacao_cd = Convert.ToInt32(i["un_operacao_cd"].ToString());
            df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
            df_nf_numero = Convert.ToInt32(i["df_nf_numero"].ToString());
            df_nf_serie = i["df_nf_serie"].ToString();
            df_nf_tipo = Convert.ToInt32(i["df_nf_tipo"].ToString());
            cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
            df_entrada_saida = i["df_entrada_saida"].ToString();
            df_cfop_generico = i["df_cfop_generico"].ToString();
            df_data_emissao = Convert.ToDateTime(i["df_data_emissao"]);
            df_data_saida = Convert.ToDateTime(i["df_data_saida"]);
            df_data_recebimento = Convert.ToDateTime(i["df_data_recebimento"]);
            df_status_recebimento = i["df_status_recebimento"].ToString();
            df_valor_total = Convert.ToDouble(i["df_valor_total"]);
            df_valor_total_mercadoria = Convert.ToDouble(i["df_valor_total_mercadoria"]);
            df_total_paletes = Convert.ToInt32(i["df_total_paletes"].ToString());
            df_total_embalagens = Convert.ToDouble(i["df_total_embalagens"]);
            df_data_cancelamento = Convert.ToDateTime(i["df_data_cancelamento"]);
            df_cdpessoabluesoft_cancelamento = Convert.ToInt32(i["df_cdpessoabluesoft_cancelamento"].ToString());
            df_numero_documento_origem = i["df_numero_documento_origem"].ToString();
            df_chave = i["df_chave"].ToString();
            df_protocolo_autorizacao = i["df_protocolo_autorizacao"].ToString();
            df_manifestacao = Convert.ToInt32(i["df_manifestacao"].ToString());
            em_cdempresabluesoft = Convert.ToInt32(i["em_cdempresabluesoft"].ToString());


        }





    }

}



