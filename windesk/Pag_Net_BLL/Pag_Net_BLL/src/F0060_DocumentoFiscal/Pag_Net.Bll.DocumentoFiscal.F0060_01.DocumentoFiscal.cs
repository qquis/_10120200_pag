using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;


namespace Pag_Net.Bll.F0060_DocumentoFiscal._01_DocumentoFiscal
{

    public static class RedShift
    {
        public static string get(
            DateTime data_inicial,
            DateTime data_final
            )
        {

            string SQL_REDSHIFT =
                string.Format("Select           cast(coalesce(nf.loja_key,0) as int )       as      em_cdempresabluesoft                         " +
                                   "      ,     cast(0 as int)                  as      un_operacao_cd                       " +
                                   "      ,     coalesce(nf.nf_key,0)           as      df_nf_seq_blue                       " +
                                   "      ,     coalesce(nf.nf_numero,0)        as      df_nf_numero                         " +
                                   "      ,     coalesce(nf.nf_serie,'0')                     as      df_nf_serie                          " +
                                   "      ,     coalesce(nf.nf_tipo_key,0)             as      df_nf_tipo                           " +
                                   "      ,     CASE WHEN tp.entrada_saida = -1 THEN 'S' else 'E' end                        " +
                                   "                                                  as      df_entrada_saida               " +
                                   "      ,     coalesce(ps.pessoa_key,0)                   as      cdpessoabluesoft                     " +
                                   "      ,     left(cast(coalesce(nf.codigo_operacao_fiscal,0) as varchar(10)),10)        as      df_cfop_generico                     " +
                                   "      ,     coalesce(nf.data_emissao,'1900-01-01')                 as      df_data_emissao                      " +
                                   "      ,     coalesce(nf.data_saida,'1900-01-01')                   as      df_data_saida                        " +
                                   "      ,     coalesce(nf.data_recebimento,'1900-01-01')             as      df_data_recebimento                  " +
                                   "      ,     coalesce(nf.status_recebimento,'Não Definido')        as      df_status_recebimento                " +
                                   "      ,     coalesce(NT.VALOR_TOTAL_NOTA,0)             as      df_valor_total                       " +
                                   "      ,     coalesce(NT.VALOR_TOTAL_MERCADORIAS,0)      as      df_valor_total_mercadoria            " +
                                   "      ,     cast(ISNULL(NT.TOTAL_PALLETS,0) as numeric(13,0))      as      df_total_paletes                     " +
                                   "      ,     coalesce(NT.TOTAL_EMBALAGENS,0)             as      df_total_embalagens                  " +
                                   "      ,     isnull(nf.data_cancelamento,'1900-01-01')   as      df_data_cancelamento     " +
                                   "      ,     isnull(nf.usuario_cancelamento_key,0)     as      df_cdpessoabluesoft_cancelamento     " +
                                   "      ,     coalesce(nf.numero_documento_origem,'0')      as      df_numero_documento_origem           " +
                                   "      ,     coalesce(nf.chave,'')                        as      df_chave                             " +
                                   "      ,     coalesce(nf.protocolo_autorizacao,0)        as      df_protocolo_autorizacao             " +
                                   "      ,     coalesce(nf.tipo_status_nfe_key,'0')                                                      " +
                                   "      ,     isnull(nf.tipo_manifestacao_dest_key,0)   as      df_manifestacao            " +
                                   "      ,     coalesce(nf.numero_arquivo_nfe_recebido, 0) as df_documento_recebido_nf_numero " + 
                                   "      ,     coalesce(nf.chave_arquivo_nfe_recebido, '') as df_documento_recebido_chave " + 
                                   "      , coalesce(fr.nome_transportadora,'')                       as df_transportadora_descricao      " + 
                                   "      , coalesce(fr.placa_veiculo,'')                              as df_transportadora_placa          " +
                                   "      ,     coalesce(nt.valor_total_descontos, 0) as df_valor_desconto " +
                                   "      ,     coalesce(nt.valor_total_frete, 0) as df_total_frete " +
                                   "      ,     coalesce(nt.valor_total_servicos, 0) as df_total_servico " + 
                                   "      From        Nota_Fiscal         nf                                                 " +
                                   "      inner join  pessoa              ps    on ps.pessoa_key = nf.fornecedor_key         " +
                                   "      INNER JOIN  NOTA_FISCAL_TOTAL   NT    on NT.NF_KEY = NF.NF_KEY                     " +
                                   "      inner join  nota_fiscal_tipo    tp    on tp.nf_tipo_key = nf.nf_tipo_key           " +
                                   "      left  join  fato_nota_fiscal_frete fr on fr.nf_key = nf.nf_key                     " + 
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
        public static string VERSION() { return "f0060_01_1012010_tbdocumentofiscal"; }
        public static string post(
             Pag_Net.Models.modelSistemaUsuario MyConnect,
             string _SqlCommand,
             bool _Api,
             Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscal item)
        {
            try
            {
                string _PostGre_Post = string.Format("SELECT " + VERSION() + " (	    " +
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
                                      "       ,    '{23}'           " +
                                      "       ,    '{24}'           " + 
                                      "       ,     {25}            " + 
                                      "       ,     '{26}'          " + 
                                      "       ,     {27}            " +
                                      "       ,     {28}            " +
                                      "       ,     {29}             )", 
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
                                      item.em_cdempresabluesoft.ToString(), 
                                      item.df_transportadora_descricao.ToString(), 
                                      item.df_transportadora_placa.ToString(),
                                      item.df_documento_recebido_nf_numero.ToString(), 
                                      item.df_documento_recebido_chave.ToString(), 
                                      item.df_valor_desconto.ToString().Replace(",", "."),
                                      item.df_total_frete.ToString().Replace(",", "."),
                                      item.df_total_servico.ToString().Replace(",", ".")
                                      );
                return _PostGre_Post;
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0051 | Update: " + ex.Message);
            }
        }

    }


}



