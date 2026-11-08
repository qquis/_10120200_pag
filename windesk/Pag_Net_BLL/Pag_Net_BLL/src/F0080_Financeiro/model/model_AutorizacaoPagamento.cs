using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0080_Financeiro.tbs;
using System.Data;
using Pag_Net.Bll;

namespace Pag_Net.src.F0080_Financeiro.model
{
    public class model_AutorizacaoPagamento : TbAutorizacaoPagamento
    {

        public string Nome_Razao { get; set; }
        //public string descritivo { get; set;  }
        public string plc_descricao { get; set; }
        public string plc_descricao_destino { get; set; }
        public string LOCAL_status_cancelado
        {
            get
            {
                if (autpgto_cancelada == 0)
                {
                    return " -- ";
                }
                else
                {
                    return "SIM";
                }
            }
        }
        public double CALC_ValorPrincipalLiquido
        {
            get
            {
                double valor_calculado = 0;
                valor_calculado = base.autpgto_valorfatura - base.autpgto_valor_abatimento - base.autpgto_valorDescontoFinanceiro;
                return valor_calculado;

            }

        }
        public model_AutorizacaoPagamento() : base() { model_constructor(); }

        public void model_constructor() 
        {
            this.Nome_Razao = "";
            this.plc_descricao = "";
            this.plc_descricao_destino = "";

        }


        public void model_Binding(DataRow i)
        {
            Nome_Razao = i["nome_razao"].ToString();
            //descritivo = i["descritivo"].ToString();
            plc_descricao = i["plc_descricao"].ToString();
            plc_descricao_destino = i["plc_descricao_destino"].ToString();
        }

        public string model_Script_RedShiftPostgre_Integ()
        {
            try
            {
                string sql = "SELECT " + scripts.F0080_01_AutorizacaoPgto_Integ.VERSION() + 
                            " ( " + 
                            "   sqlcommand:=  '" + "INTEG_REDSHIFT" + "'" + 							
                            " , vautpgto_seq_pk:=  " + this.autpgto_seq_pk.ToString() + 
                            " , vautpgto_cdpessoabluesoft:= " + this.autpgto_cdpessoabluesoft.ToString() + 
                            " , vautpgto_tipo:= '" + this.autpgto_tipo.ToString() + "'" + 		
                            " , vautpgto_dataemissao:=  '" + this.autpgto_dataemissao.ToString("yyyyMMdd") + "'" + 		
                            " , vautpgto_datavencimento:= '" + this.autpgto_datavencimento.ToString("yyyyMMdd") + "'" + 		
                            " , vautpgto_dataquitacao:= '" +  this.autpgto_dataquitacao.ToString("yyyyMMdd") + "'" + 		
                            " , vautpgto_valorfatura:=  " + this.autpgto_valorfatura.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_valortotal:=  " + this.autpgto_valortotal.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_valorpago:=  " +	this.autpgto_valorpago.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_nf_numero:=  '" + this.autpgto_nf_numero.ToString() + "'"  + 
                            " , vautpgto_valordescontofinanceiro:= " + this.autpgto_valorDescontoFinanceiro.ToString().Replace(",", ".") + 
                            " , vautpgto_numeroparcela:= " + this.autpgto_numeroparcela.ToString() + 
                            " , vautpgto_datapagamento:= '" +  this.autpgto_datapagamento.ToString("yyyyMMdd") + "'" + 
                            " , vautpgto_nf_dataemissao:= '" + this.autpgto_nf_dataemissao.ToString("yyyyMMdd") + "'" + 
                            " , vautpgto_valorliquido:= " + this.autpgto_valorliquido.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_datacriacao:= '" + this.autpgto_datacriacao.ToString("yyyyMMdd") + "'" + 		
                            " , vautpgto_datacancelamento:= '" + this.autpgto_datacancelamento.ToString("yyyyMMdd") + "'" + 		
                            " , vautpgto_dtlog_update_redshift:= '" + this.autpgto_DtLog_update_redshift.ToString("yyyyMMdd") + "'" +
                            " , vautpgto_status_bluesoft_cd:= " + this.autpgto_status_bluesoft_cd.ToString() + 
                            " , vdescritivo:= '" + this.descritivo.Replace("'", "`") + "'" + 
                            " , vautpgto_cancelada:= " + this.autpgto_cancelada.ToString() + 
                            " , vautpgto_codigobarra:= '" + this.autpgto_codigobarra.ToString() + "'" + 
                            " , vcompetencia_cd:= " + this.competencia_cd.ToString() + 
                            " , vplc_conta_cd:= " + this.plc_conta_cd.ToString() + 
                            " , vplc_conta_cd_destino:=  " + this.plc_conta_cd_destino.ToString() + 
                            " , vbordero_seq:= " + this.bordero_seq.ToString() + 
                            " , vautpgto_juro_diario:= " + this.autpgto_juro_diario.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_valor_multa:= " + this.autpgto_valor_multa.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_valor_abatimento:= " + this.autpgto_valor_abatimento.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_valor_juros:= " + this.autpgto_valor_juros.ToString("0.00").Replace(",", ".") + 
                            " , vautpgto_valor_juros_fixo:= " + this.autpgto_valor_juros_fixo.ToString("0.00").Replace(",", ".") + 
                            " , vem_cdempresa:= " + this.em_cdempresa.ToString()  +
                            " , vcontrato_bluesoft_seq:=  " + this.contrato_bluesoft_seq.ToString() +
                            " , vem_cdpessoabluesoft:= " + this.em_cdpessoabluesoft.ToString() + ")";
                return sql;
                                                      
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        public void model_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                string SQL = "SELECT 	a.autpgto_seq_pk                          " +
                   "                ,   p.nome_razao                              " +
                   "                ,	a.autpgto_cdpessoabluesoft                " +
                   "                ,	a.autpgto_tipo                            " +
                   "                ,	coalesce(ds.descritivo,'') as descritivo         " +
                   "                ,	a.autpgto_dataemissao                     " +
                   "                ,	a.autpgto_datavencimento  	              " +
                   "                ,	a.autpgto_dataquitacao                    " +
                   "                ,	a.autpgto_valorfatura  	                  " +
                   "                ,	a.autpgto_valortotal	                  " +
                   "                ,	a.autpgto_valorpago	                      " +
                   "                ,	a.autpgto_nf_numero                       " +
                   "                ,	a.autpgto_valordescontofinanceiro         " +
                   "                ,	a.autpgto_numeroparcela                   " +
                   "                ,	a.autpgto_datapagamento                   " +
                   "                ,	a.autpgto_nf_dataemissao                  " +
                   "                ,	a.autpgto_valorliquido                    " +
                   "                ,	a.autpgto_datacriacao                     " +
                   "                ,	a.autpgto_datacancelamento                " +
                   "                ,	a.autpgto_dtlog_update_redshift           " +
                   "                ,	a.autpgto_status_cd                       " +
                   "                ,   a.autpgto_cancelada                       " +
                   "                ,   a.autpgto_codigobarra                     " +
                   "                ,   a.competencia_cd                          " +
                   "                ,   a.plc_conta_cd                            " +
                   "                ,   a.plc_conta_cd_destino                    " +
                   "                ,   a.bordero_seq                             " +
                   "                ,   a.autpgto_juro_diario                     " +
                   "                ,   a.autpgto_valor_multa                     " +
                   "                ,   a.autpgto_valor_abatimento                " +
                   "                ,   a.autpgto_valor_juros                     " +
                   "                ,   a.autpgto_valor_juros_fixo                " +
                   "                ,   a.em_cdempresa                            " +
                   "                ,   '' as plc_descricao                       " +
                   "                ,   '' as plc_descricao_destino               " +
                   "                ,   contrato_bluesoft_seq         " +
                   " FROM 	   tbautorizacaopagamento               a                " +
                   " LEFT JOIN tbpessoabluesoft                     p on p.cdpessoabluesoft = a.autpgto_cdpessoabluesoft " +
                   " LEFT JOIN tbautorizacaopagamento_descritivo    ds on ds.autpgto_seq_fk = a.autpgto_seq_pk" + 
                   " WHERE  1 = 1                                   " +
                   " AND    autpgto_seq_pk = " + autpgto_seq_pk.ToString();

                DBDataTable Data = this.__DataGet(MyConnect, SQL);

                __Binding(Data.List.Rows[0]);
                model_Binding(Data.List.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
