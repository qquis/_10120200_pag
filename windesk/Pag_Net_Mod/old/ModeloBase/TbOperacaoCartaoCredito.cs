using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models.ModeloBase
{
    public class TbOperacaoCartaoCredito
    {
        public DateTime DataFaturamento {get;set;} 
        public DateTime DataPgto {get;set;}
        public string Finalizadora { get; set; }
        public string Autorizador { get; set; }
        public string CdProdutoFinanceiro { get; set; }
        public double Valor { get; set; }
        public double ValorSitef { get; set; }
        public int ECF { get; set; }
        public int CupomFiscal { get; set; }
        public int DocumentoFiscal { get; set; }
        public bool StatusErro { get; set; }
        public string StatusErroDescricao { get; set; }
        public TbOperacaoCartaoCredito() { }


    }
}
