using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models.ModeloBase
{
    public class TbNotasFiscaisItem
    {
        public int NumeroNotaFiscal { get; set; }
        public DateTime DataRecebimento { get; set; }
        public int CodigoFornecedor { get; set; }
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string NCMCodigo { get; set; }
        public string CSTCodigo { get; set; }
        public string CFOPCodigo { get; set; }
        public string EmbalagemNotaFiscal { get; set; }
        public double QtdeNotaFiscal { get; set; }
        public string EmbalagemCompra { get; set; }
        public double EmbalagemCompraFator { get; set; }
        public string EmbalagemEstoque { get; set; }
        public double QtdeEmbalagemEstoque { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public double ValorItemIcms { get; set; }
        public double ValorItemIcmsBase { get; set; }
        public double AliquotaItemIcms { get; set; }
        public TbNotasFiscaisItem() { }
    }
}
