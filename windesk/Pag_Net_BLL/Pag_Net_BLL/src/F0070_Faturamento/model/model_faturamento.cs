using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.Models
{
    public class model_faturamento: tbs.tbFaturamento
    {
        public string em_descricao {get; set;}
        public string op_descricao  {get; set;}
        public string cliente_cpf_cnpj {get; set;}
        public string cliente_nome_razao  {get; set;}
        public string vendedor_cpf_cnpj  {get; set;}
        public string vendedor_nome_razao  {get; set;}
        public string statusfaturamento_descricao { get; set; }


        public int seqfaturamentoorigem { get; set; }

        public int numeropedido { get; set; }
        public int df_nf_seq_blue { get; set; }
        public int df_nf_numero { get; set;  }
        public double df_valor_total { get; set; }
        public string df_chave { get; set;  }
        public DateTime df_data_emissao { get; set; }
        public int df_nf_tipo { get; set; }
        public string df_nf_tipo_descricao { get; set; }

        public int sat_ecf { get; set; }
        public int cupomfiscal { get; set; }
        public double cupomfiscal_valor { get; set; }
        public string cupomfiscal_chave { get; set; }
        
        public int faturamento_pag_itens_qtde { get; set; }

        public double ec_valorcusto_faturamento_total  { get; set; } 
        public double ec_valorcusto_precificacao_total  { get; set; }  
        public double valortotalfaturamentobase  { get; set; } 
        public double valortotalsubsidioscorrentes  { get; set; } 
        public double valortotalfaturamento  { get; set; }
        public double valortotaldescontofinanceiro   { get; set; }
        public double valortotalfaturamentobruto   { get; set; }
        public double valortotalsubsidiosaplicados   { get; set; }
        public double valortotalfaturamentoliquido { get; set; }





        public int cliente_cdpessoabluesoft { get; set;  }
        public int vendedor_cdpessoabluesoft { get; set; }


        public model_faturamento() : base()
        {
                
        }

        public void binding(DataRow i)
        {
            this.cdparticipantecliente = Convert.ToInt32(i["cdparticipantecliente"]);
            this.cdparticipantevendedor = Convert.ToInt32(i["cdparticipantevendedor"]);
            this.em_cdempresa = Convert.ToInt32(i["em_cdempresa"]);
            this.op_cdoperacao = Convert.ToInt32(i["op_cdoperacao"]);
            this.dataemissao = Convert.ToDateTime(i["dataemissao"]);
            this.datafaturamento = Convert.ToDateTime(i["datafaturamento"]);
            this.seqfaturamento = Convert.ToInt32(i["seqfaturamento"]);
            this.seqfaturamentoorigem = Convert.ToInt32(i["seqfaturamentoorigem"]);
            this.em_descricao = i["em_descricao"].ToString();
            this.op_descricao = i["op_descricao"].ToString();
            this.cliente_cpf_cnpj = i["cliente_cpf_cnpj"].ToString();
            this.cliente_nome_razao = i["cliente_nome_razao"].ToString();
            this.vendedor_cpf_cnpj = i["vendedor_cpf_cnpj"].ToString();
            this.vendedor_nome_razao = i["vendedor_nome_razao"].ToString();
            this.statusfaturamento_descricao = i["statusfaturamento_descricao"].ToString();
            this.statusfaturamento = Convert.ToInt32(i["statusfaturamento"].ToString());

            this.numeropedido = Convert.ToInt32(i["numeropedido"]);
            this.df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"]);
            this.df_nf_numero = Convert.ToInt32(i["df_nf_numero"]);
            this.df_valor_total = Convert.ToDouble(i["df_valor_total"]);
            this.df_chave = i["df_chave"].ToString();
            this.df_nf_tipo = Convert.ToInt32(i["df_nf_tipo"].ToString());
            this.df_nf_tipo_descricao = i["df_nf_tipo_descricao"].ToString();
            this.df_data_emissao = Convert.ToDateTime(i["df_data_emissao"]);

            this.sat_ecf = Convert.ToInt32(i["sat_ecf"].ToString());
            this.cupomfiscal = Convert.ToInt32(i["cupomfiscal"].ToString());
            this.cupomfiscal_chave = i["cupomfiscal_chave"].ToString();
            this.cupomfiscal_valor = Convert.ToDouble(i["cupomfiscal_valor"].ToString());

            this.faturamento_pag_itens_qtde = Convert.ToInt32(i["faturamento_pag_itens_qtde"].ToString());
            this.ec_valorcusto_faturamento_total = Convert.ToDouble(i["ec_valorcusto_faturamento_total"].ToString());
            this.ec_valorcusto_precificacao_total = Convert.ToDouble(i["ec_valorcusto_precificacao_total"].ToString());
            this.valortotalfaturamentobase = Convert.ToDouble(i["valortotalfaturamentobase"].ToString());
            this.valortotalsubsidioscorrentes = Convert.ToDouble(i["valortotalsubsidioscorrentes"].ToString());
            this.valortotalfaturamento = Convert.ToDouble(i["valortotalfaturamento"].ToString());
            this.valortotaldescontofinanceiro = Convert.ToDouble(i["valortotaldescontofinanceiro"].ToString());
            this.valortotalfaturamentobruto = Convert.ToDouble(i["valortotalfaturamentobruto"].ToString());
            this.valortotalsubsidiosaplicados = Convert.ToDouble(i["valortotalsubsidiosaplicados"].ToString());
            this.valortotalfaturamentoliquido = Convert.ToDouble(i["valortotalfaturamentoliquido"].ToString());


            this.vendedor_cdpessoabluesoft = Convert.ToInt32(i["vendedor_cdpessoabluesoft"].ToString());
            this.cliente_cdpessoabluesoft = Convert.ToInt32(i["cliente_cdpessoabluesoft"].ToString());

        }
    }
}
