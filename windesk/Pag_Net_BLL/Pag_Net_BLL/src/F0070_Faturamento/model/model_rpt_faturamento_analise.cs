using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.Models
{
    public class model_rpt_faturamento_analise : Pag_Net.src.F0070_Faturamento.tbs.tbFaturamentoitens
    {
        public string referencia_id { get; set; }
        public string referencia_descricao { get; set; }
        public string pr_embalagemestoque { get; set; }
        public string pr_embalagemcompra { get; set; }


        public string _static_referencia
        {
            get
            {
                return string.Format("{1} | Ref.: {0}", referencia_id, referencia_descricao);
            }
        }

        public int _static_pontos { get; set; }
        public int _static_clientes { get; set; }
        public int _static_mix { get; set; }


        public double _static_EmbalagemEstoque_FaturamentoBase_Unitario
        {
            get
            {
                if (valortotalfaturamentobase != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(valortotalfaturamentobase / embalagemestoqueqtde, 1);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_EmbalagemEstoque_ValorCustoFaturamento_Unitario
        {
            get
            {
                if (ec_valorcusto_faturamento_total != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(ec_valorcusto_faturamento_total / embalagemestoqueqtde, 2);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_EmbalagemEstoque_FaturamentoBase_Caixa
        {
            get
            {
                if (valortotalfaturamentobase != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(valortotalfaturamentobase / embalagemcompraqtde, 1);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_EmbalagemEstoque_ValorCustoFaturamento_Caixa
        {
            get
            {
                if (ec_valorcusto_faturamento_total != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(ec_valorcusto_faturamento_total / embalagemcompraqtde, 1);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamentobase_margem
        {
            get
            {
                if (valortotalfaturamentobase > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamentobase, ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamento_margem
        {
            get
            {
                if (valortotalfaturamento > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamento, ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamentobruto_margem
        {
            get
            {
                if (valortotalfaturamentobruto > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamentobruto, ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamentoliquido_margem
        {
            get
            {
                if (valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamentoliquido, ec_valorcusto_faturamento_total);
                }
                else
                {

                    return 0;
                }
            }


        }

        public model_rpt_faturamento_analise()
        {
            referencia_id = "0";
            referencia_descricao = "";
            pr_embalagemestoque = "UN";
            pr_embalagemcompra = "CX";
        }
        public model_rpt_faturamento_analise(
                string _referencia_id,
                string _referencia_descricao,
                string _pr_embalagemestoque,
                string _pr_embalagemcompra
            )
        {

            referencia_id = _referencia_id;
            referencia_descricao = _referencia_descricao;
            pr_embalagemestoque = _pr_embalagemestoque;
            pr_embalagemcompra = _pr_embalagemcompra;
        }

        public model_rpt_faturamento_analise(DataRow i)
        {

            referencia_id = i["referencia_id"].ToString();
            referencia_descricao = i["referencia_descricao"].ToString();
            pr_embalagemestoque = i["pr_embalagemestoque"].ToString();
            pr_embalagemcompra = i["pr_embalagemcompra"].ToString();
            embalagemestoqueqtde = Convert.ToDouble(i["embalagemestoqueqtde"].ToString());
            embalagemcompraqtde = Convert.ToDouble(i["embalagemcompraqtde"].ToString());

            _static_pontos = Convert.ToInt32(i["pontos"].ToString());
            _static_clientes = Convert.ToInt32(i["clientes"].ToString());
            _static_mix = Convert.ToInt32(i["mix"].ToString());

            ec_valorcusto_faturamento_total = Convert.ToDouble(i["ec_valorcusto_faturamento_total"].ToString());
            valortotalfaturamentobase = Convert.ToDouble(i["valortotalfaturamentobase"].ToString());
            valortotalsubsidioscorrentes = Convert.ToDouble(i["valortotalsubsidioscorrentes"].ToString());
            valortotalfaturamento = Convert.ToDouble(i["valortotalfaturamento"].ToString());
            valortotaldescontofinanceiro = Convert.ToDouble(i["valortotaldescontofinanceiro"].ToString());
            valortotalfaturamentobruto = Convert.ToDouble(i["valortotalfaturamentobruto"].ToString());
            valortotalsubsidiosaplicados = Convert.ToDouble(i["valortotalsubsidiosaplicados"].ToString());
            valortotalfaturamentoliquido = Convert.ToDouble(i["valortotalfaturamentoliquido"].ToString());

        }
    }
}
