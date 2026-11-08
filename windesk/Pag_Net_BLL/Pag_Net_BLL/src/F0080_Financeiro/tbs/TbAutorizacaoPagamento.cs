using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;



/*
    10/02/2023 Criação - vindo da pasta funções
    11/02/2023 Adição dos campos  competencia_cd, plc_conta_cd, plc_conta_cd_destino
 
*/
namespace Pag_Net.src.F0080_Financeiro.tbs
{
    public class TbAutorizacaoPagamento : Pag_Net.Bll.Tb
    {
        public int em_cdempresa { get; set;  }
        public int autpgto_seq_pk { get; set; }
        public int autpgto_cdpessoabluesoft { get; set; }
        public string autpgto_tipo { get; set; }
        public string descritivo { get; set; }
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
        public int autpgto_status_bluesoft_cd { get; set; }
        public int autpgto_cancelada { get; set; }
        public string autpgto_codigobarra { get; set; }
        public int competencia_cd { get; set;  }
        public int plc_conta_cd { get; set; }
        public int plc_conta_cd_destino { get; set; }
        public int contrato_bluesoft_seq { get; set;  }
        public int em_cdpessoabluesoft { get; set; }


        public int    bordero_seq 	                { get; set;  }			
        public double autpgto_juro_diario 	        { get; set;  }	
        public double autpgto_valor_multa 	        { get; set;  }	
        public double autpgto_valor_abatimento      { get; set;  }
        public double autpgto_valor_juros 		    { get; set;  }
        public double autpgto_valor_juros_fixo      {     get; set; }




        public TbAutorizacaoPagamento()
        {

            _constructor();

        }

        public void _constructor()
        {
            em_cdempresa = 0;
            autpgto_dataemissao = DateTime.Now;
            autpgto_datavencimento = DateTime.Now;
            autpgto_dataquitacao = Convert.ToDateTime("1900-01-01");
            autpgto_datapagamento = Convert.ToDateTime("1900-01-01");

        }

        public override void __Binding(DataRow i)
        {
            try
            {
                autpgto_seq_pk = Convert.ToInt32(i["autpgto_seq_pk"]);
                autpgto_cdpessoabluesoft = Convert.ToInt32(i["autpgto_cdpessoabluesoft"]);
                autpgto_tipo = i["autpgto_tipo"].ToString();
                descritivo = Convert.ToString(i["descritivo"]);
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
                autpgto_status_bluesoft_cd = Convert.ToInt32(i["autpgto_status_bluesoft_cd"]);
                autpgto_cancelada = Convert.ToInt32(i["autpgto_cancelada"]);
                autpgto_codigobarra = i["autpgto_codigobarra"].ToString();
                competencia_cd = Convert.ToInt32(i["competencia_cd"]);
                plc_conta_cd = Convert.ToInt32(i["plc_conta_cd"]);
                plc_conta_cd_destino = Convert.ToInt32(i["plc_conta_cd_destino"]);

                bordero_seq = Convert.ToInt32(i["bordero_seq"]);
                autpgto_juro_diario = Convert.ToDouble(i["autpgto_juro_diario"]);
                autpgto_valor_multa = Convert.ToDouble(i["autpgto_valor_multa"]);
                autpgto_valor_abatimento = Convert.ToDouble(i["autpgto_valor_abatimento"]);
                autpgto_valor_juros = Convert.ToDouble(i["autpgto_valor_juros"]);
                autpgto_valor_juros_fixo = Convert.ToDouble(i["autpgto_valor_juros_fixo"]);
                em_cdempresa = Convert.ToInt32(i["em_cdempresa"].ToString());
                em_cdpessoabluesoft = Convert.ToInt32(i["em_cdpessoabluesoft"].ToString());
                contrato_bluesoft_seq = Convert.ToInt32(i["contrato_bluesoft_seq"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string _Db_Pg_script_Select()
        {
            return "SELECT 	autpgto_seq_pk                          " +
                   "     ,	autpgto_cdpessoabluesoft                " +
                   "     ,	autpgto_tipo                            " +
                   "     ,	coalesce(autpgto_descritivo,'') as autpgto_descritivo         " +
                   "     ,	autpgto_dataemissao                     " +
                   "     ,	autpgto_datavencimento  	            " +
                   "     ,	autpgto_dataquitacao                    " +
                   "     ,	autpgto_valorfatura  	                " +
                   "     ,	autpgto_valortotal	                    " +
                   "     ,	autpgto_valorpago	                    " +
                   "     ,	autpgto_nf_numero                       " +
                   "     ,	autpgto_valordescontofinanceiro         " +
                   "     ,	autpgto_numeroparcela                   " +
                   "     ,	autpgto_datapagamento                   " +
                   "     ,	autpgto_nf_dataemissao                  " +
                   "     ,	autpgto_valorliquido                    " +
                   "     ,	autpgto_datacriacao                     " +
                   "     ,	autpgto_datacancelamento                " +
                   "     ,	autpgto_dtlog_update_redshift           " +
                   "     ,	autpgto_status_cd                       " +
                   "     ,  autpgto_cancelada                       " +
                   "     ,  autpgto_codigobarra                     " +
                   "     ,  competencia_cd                          " + 
                   "     ,  plc_conta_cd                            " +
                   "     ,  plc_conta_cd_destino                    " +
                   "     ,  bordero_seq                             " +
                   "     ,  autpgto_juro_diario                     " +
                   "     ,  autpgto_valor_multa                     " +
                   "     ,  autpgto_valor_abatimento                " +
                   "     ,  autpgto_valor_juros                     " +
                   "     ,  autpgto_valor_juros_fixo                " +
                   "     ,  em_cdempresa                            " + 
                   "     ,  contrato_bluesoft_seq                   " + 
                   "     ,  coalesce(em_cdpessoabluesoft,0) as em_cdpessoabluesoft        " + 
                   " FROM 	tbautorizacaopagamento                  " +
                   " WHERE  1 = 1                                   " + 
                   " AND    autpgto_seq_pk = " + autpgto_seq_pk.ToString(); 
        }
    }
}

