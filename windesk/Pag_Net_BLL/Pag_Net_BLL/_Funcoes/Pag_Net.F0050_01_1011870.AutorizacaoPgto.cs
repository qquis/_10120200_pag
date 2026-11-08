using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;



namespace Pag_Net.Bll.F0050_01
{

    public static class RedShift
    {
        public static string get(
            DateTime data_inicial,
            DateTime data_final
            )
        {


            string SQL = string.Format(
                         " select  p.favorecido                              as autpgto_cdpessoabluesoft  " +
                         "       , p.ap_key                                  as autpgto_seq_pk  " +
                         "       , left(p.pagar_receber,1)                   as autpgto_tipo  " +
                         "       , left(p.descritivo,100)                    as autpgto_descritivo  " +
                         "       , isnull(p.data_emissao,'1900-01-01')       as autpgto_dataemissao  " +
                         "       , isnull(p.data_vencimento,'1900-01-01')    as autpgto_datavencimento  " +
                         "       , isnull(p.data_quitacao,'1900-01-01')      as autpgto_dataquitacao  " +
                         "       , isnull(p.valor_fatura,0)                  as autpgto_valorfatura  " +
                         "       , isnull(p.valor_total,0)                   as autpgto_valortotal  " +
                         "       , isnull(p.valor_pago,0)                    as autpgto_valorpago  " +
                         "       , isnull(p.numero_documento,0)              as autpgto_nf_numero  " +
                         "       , isnull(p.desconto_financeiro,0)           as autpgto_valorDescontoFinanceiro  " +
                         "       , isnull(p.parcela,0)                       as autpgto_numeroparcela  " +
                         "       , isnull(p.data_pagamento,'1900-01-01')     as autpgto_datapagamento  " +
                         "       , isnull(p.data_emissao_nf,'1900-01-01')    as autpgto_nf_dataemissao  " +
                         "       , isnull(p.valor_liquido,0)                 as autpgto_valorliquido  " +
                         "       , isnull(p.data_criacao,'1900-01-01')       as autpgto_datacriacao  " +
                         "       , isnull(p.data_cancelamento,'1900-01-01')  as autpgto_datacancelamento  " +
                         "       , isnull(p.updated_at,'1900-01-01')         as autpgto_DtLog_update_redshift  " +
                         "       , isnull(p.status_duplicata_key,0)          as autpgto_status_cd  " +
                         "       , isnull(p.cancelada,0)                     as autpgto_cancelada " +
                         "       , isnull(p.codigo_barra,'')                 as autpgto_codigobarra " +
                         " from          autorizacao_pagamento p  " +
                         " left  join    status_duplicata      st on st.status_duplicata_key = p.status_duplicata_key   " +
                         " where         1 = 1 " +
                         "   and  (     isnull(p.updated_at,'1900-01-01') >= '{0}'  " +
                         "           or isnull(p.data_emissao,'1900-01-01') >= '{1}'  " +
                /// --- ATENÇÃO ---->> ** * * * * * * AMBOS OS CAMPOS DEVEM SER DATA INICIAL * * * * * *
                         "   ) order by p.data_emissao desc ", data_inicial.ToString("yyyy-MM-dd"), data_inicial.ToString("yyyy-MM-dd"));
            /// --- ATENÇÃO ---->> ** * * * * * * AMBOS OS CAMPOS DEVEM SER DATA INICIAL * * * * * *


            return SQL;
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
            return string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0050_01) + " ('DBINSERT', {0}, {1}, '{2}', '{3}', '{4}', " +
                                                                  " '{5}', {6}, {7}, {8}, '{9}', {10}, {11}, " +
                                                                  " '{12}', '{13}', {14}, '{15}', '{16}', '{17}', {18}, '{19}', {20}, '{21}' ) ",
                                                                  item.autpgto_seq_pk.ToString(),
                                                                  item.autpgto_cdpessoabluesoft.ToString(),
                                                                  item.autpgto_tipo.ToString(),
                                                                  item.autpgto_dataemissao.ToString("yyyyMMdd"),
                                                                  item.autpgto_datavencimento.ToString("yyyyMMdd"),
                                                                  item.autpgto_dataquitacao.ToString("yyyyMMdd"),
                                                                  item.autpgto_valorfatura.ToString("0.00").Replace(",", "."),
                                                                  item.autpgto_valortotal.ToString("0.00").Replace(",", "."),
                                                                  item.autpgto_valorpago.ToString("0.00").Replace(",", "."),
                                                                  item.autpgto_nf_numero.ToString(),
                                                                  item.autpgto_valorDescontoFinanceiro.ToString().Replace(",", "."),
                                                                  item.autpgto_numeroparcela.ToString(),
                                                                  item.autpgto_datapagamento.ToString("yyyyMMdd"),
                                                                  item.autpgto_nf_dataemissao.ToString("yyyyMMdd"),
                                                                  item.autpgto_valorliquido.ToString("0.00").Replace(",", "."),
                                                                  item.autpgto_datacriacao.ToString("yyyyMMdd"),
                                                                  item.autpgto_datacancelamento.ToString("yyyyMMdd"),
                                                                  item.autpgto_DtLog_update_redshift.ToString("yyyyMMdd"),
                                                                  item.autpgto_status_cd.ToString(),
                                                                  item.autpgto_descritivo.Replace("'", "`"),
                                                                  item.autpgto_cancelada.ToString(),
                                                                  item.autpgto_codigobarra.ToString()
                                                                  );
        }

    }

    public class Db
    {
        public int autpgto_seq_pk { get; set; }
        public int autpgto_cdpessoabluesoft { get; set; }
        public string autpgto_tipo { get; set; }
        public string autpgto_descritivo { get; set; }
        public DateTime autpgto_dataemissao { get; set; }
        public DateTime autpgto_datavencimento { get; set; }
        public DateTime autpgto_dataquitacao { get; set; }
        public double autpgto_valorfatura { get; set; }
        public double autpgto_valortotal { get; set; }
        public double autpgto_valorpago { get; set; }
        public string autpgto_nf_numero { get; set; }
        public double autpgto_valorDescontoFinanceiro { get; set; }
        public int autpgto_numeroparcela { get; set; }
        public DateTime autpgto_datapagamento { get; set; }
        public DateTime autpgto_nf_dataemissao { get; set; }
        public double autpgto_valorliquido { get; set; }
        public DateTime autpgto_datacriacao { get; set; }
        public DateTime autpgto_datacancelamento { get; set; }
        public DateTime autpgto_DtLog_update_redshift { get; set; }
        public int autpgto_status_cd { get; set; }
        public int autpgto_cancelada { get; set; }
        public string autpgto_codigobarra { get; set; }

        public Db()
        {

        }

        public Db(System.Data.DataRow i)
        {
            string errorString = i[0].ToString();
            try
            {
                autpgto_seq_pk = Convert.ToInt32(i["autpgto_seq_pk"]);
                autpgto_cdpessoabluesoft = Convert.ToInt32(i["autpgto_cdpessoabluesoft"]);
                autpgto_tipo = i["autpgto_tipo"].ToString();
                autpgto_descritivo = Convert.ToString(i["autpgto_descritivo"]);
                autpgto_dataemissao = Convert.ToDateTime(i["autpgto_dataemissao"]);
                autpgto_datavencimento = Convert.ToDateTime(i["autpgto_datavencimento"]);
                autpgto_dataquitacao = Convert.ToDateTime(i["autpgto_dataquitacao"]);
                autpgto_valorfatura = Convert.ToDouble(i["autpgto_valorfatura"]);
                autpgto_valortotal = Convert.ToDouble(i["autpgto_valortotal"]);
                autpgto_valorpago = Convert.ToDouble(i["autpgto_valorpago"]);
                autpgto_nf_numero = i["autpgto_nf_numero"].ToString(); ;
                autpgto_valorDescontoFinanceiro = Convert.ToDouble(i["autpgto_valorDescontoFinanceiro"]);
                autpgto_numeroparcela = Convert.ToInt32(i["autpgto_numeroparcela"]);
                autpgto_datapagamento = Convert.ToDateTime(i["autpgto_datapagamento"]);
                autpgto_nf_dataemissao = Convert.ToDateTime(i["autpgto_nf_dataemissao"]);
                autpgto_valorliquido = Convert.ToDouble(i["autpgto_valorliquido"]);
                autpgto_datacriacao = Convert.ToDateTime(i["autpgto_datacriacao"]);
                autpgto_datacancelamento = Convert.ToDateTime(i["autpgto_datacancelamento"]);
                autpgto_DtLog_update_redshift = Convert.ToDateTime(i["autpgto_DtLog_update_redshift"]);
                autpgto_status_cd = Convert.ToInt32(i["autpgto_status_cd"]);
                autpgto_cancelada = Convert.ToInt32(i["autpgto_cancelada"]);
                autpgto_codigobarra = i["autpgto_codigobarra"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }


    }

}

