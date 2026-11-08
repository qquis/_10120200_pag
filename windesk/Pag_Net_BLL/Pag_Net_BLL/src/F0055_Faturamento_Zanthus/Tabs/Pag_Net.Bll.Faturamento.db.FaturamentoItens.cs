using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus
{
    public class tbFaturamentoitens : tbFaturamentoOrigem
    {
        public int seqfaturamentoitem { get; set; }
        public int seqitem { get; set; }
        public int pr_cdproduto { get; set; }
        public Double embalagemestoqueqtde { get; set; }
        public Double embalagemcompraqtde { get; set; }
        public Double ec_valorcusto_faturamento_total { get; set; }
        public Double ec_valorcusto_precificacao_total { get; set; }
        public Double valortotalfaturamentobase { get; set; }
        public Double valortotalsubsidioscorrentes { get; set; }
        public Double valortotalfaturamento { get; set; }
        public Double valortotaldescontofinanceiro { get; set; }
        public Double valortotalfaturamentobruto { get; set; }
        public Double valortotalsubsidiosaplicados { get; set; }
        public Double valortotalfaturamentoliquido { get; set; }
        public int statusfaturamentoitem { get; set; }




        public tbFaturamentoitens()
        {
            this.seqfaturamentoitem = 0;
            this.seqitem = 0;
            this.pr_cdproduto = 0;
            this.embalagemestoqueqtde = 0;
            this.embalagemcompraqtde = 0;
            this.ec_valorcusto_faturamento_total = 0;
            this.ec_valorcusto_precificacao_total = 0;
            this.valortotalfaturamentobase = 0;
            this.valortotalsubsidioscorrentes = 0;
            this.valortotalfaturamento = 0;
            this.valortotaldescontofinanceiro = 0;
            this.valortotalfaturamentobruto = 0;
            this.valortotalsubsidiosaplicados = 0;
            this.valortotalfaturamentoliquido = 0;
            this.statusfaturamentoitem = 0;
        }

        public tbFaturamentoitens(DataRow i)
        {
            this.seqfaturamentoitem                             = Convert.ToInt32(i["seqfaturamentoitem"].ToString());
            this.seqitem                                        = Convert.ToInt32(i["seqitem"].ToString());
            this.pr_cdproduto                                   = Convert.ToInt32(i["embalagemestoqueqtde"].ToString());
            this.embalagemestoqueqtde                           = Convert.ToDouble(i["embalagemcompraqtde"].ToString());
            this.embalagemcompraqtde                            = Convert.ToDouble(i["embalagemcompraqtde"].ToString());
            this.ec_valorcusto_faturamento_total                = Convert.ToDouble(i["ec_valorcusto_faturamento_total"].ToString());
            this.ec_valorcusto_precificacao_total               = Convert.ToDouble(i["ec_valorcusto_precificacao_total"].ToString());
            this.valortotalfaturamentobase                      = Convert.ToDouble(i["valortotalfaturamentobase"].ToString());
            this.valortotalsubsidioscorrentes                   = Convert.ToDouble(i["valortotalsubsidioscorrentes"].ToString());
            this.valortotalfaturamento                          = Convert.ToDouble(i["valortotalfaturamento"].ToString());
            this.valortotaldescontofinanceiro                   = Convert.ToDouble(i["valortotaldescontofinanceiro"].ToString());
            this.valortotalfaturamentobruto                     = Convert.ToDouble(i["valortotalfaturamentobruto"].ToString());
            this.valortotalsubsidiosaplicados                   = Convert.ToDouble(i["valortotalsubsidiosaplicados"].ToString());
            this.valortotalfaturamentoliquido                   = Convert.ToDouble(i["valortotalfaturamentoliquido"].ToString());
            this.statusfaturamentoitem                          = Convert.ToInt32(i["statusfaturamentoitem"].ToString());
        }


    }

}
