using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal.Db
{

    public class DocumentoFiscal
    {
        public int em_cdempresabluesoft { get; set; }
        public int un_operacao_cd { get; set; }
        public int df_seq { get; set; }
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
        public string df_transportadora_descricao { get; set;  }
        public string df_transportadora_placa { get; set; }
        public int df_documento_recebido_nf_numero { get; set; }
        public string df_documento_recebido_chave { get; set; }
        public double df_valor_desconto { get; set; }
        public double df_total_frete { get; set; }
        public double df_total_servico { get; set; }

        public DocumentoFiscal() { }
        public DocumentoFiscal(DataRow i)
        {
            string error = "";

            try
            {
                
                un_operacao_cd = Convert.ToInt32(i["un_operacao_cd"].ToString());
                df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
                df_nf_numero = Convert.ToInt32(i["df_nf_numero"].ToString());

                error = string.Format("Número Seq Nota Fiscal {0} / Número do documento Fiscal {1}", df_nf_seq_blue.ToString(), df_nf_numero.ToString());

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
                df_transportadora_descricao = i["df_transportadora_descricao"].ToString();
                df_transportadora_placa = i["df_transportadora_placa"].ToString();
                df_documento_recebido_nf_numero = Convert.ToInt32( i["df_documento_recebido_nf_numero"].ToString());
                df_documento_recebido_chave = i["df_documento_recebido_chave"].ToString();
                df_valor_desconto = Convert.ToDouble(i["df_valor_desconto"]);
                df_total_frete = Convert.ToDouble(i["df_total_frete"]);
                df_total_servico = Convert.ToDouble(i["df_total_servico"]);

            }
            catch (Exception ex)
            {
                throw new Exception("Class DocumentoFiscal Binding Property " + error + "\n" + ex.Message);
            }
        }
    }

}
