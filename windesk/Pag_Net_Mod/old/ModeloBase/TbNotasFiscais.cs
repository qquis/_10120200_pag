using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models.ModeloBase
{
    public class TbNotasFiscais
    {
        public int CdPessoaEmissor { get; set; }
        public int CdPessoaDestinatario { get; set; }
        public int ErpCdFornecedor { get; set; }
        public int ErpCdCliente { get; set; }
        public int DocumentoIdentificadorEmissor { get; set; }
        public int DocumentoIdentificadorDestinatario { get; set; }
        public string NotaFiscalBonificada { get; set; }
        public string RazaoSocialEmissor { get; set; }
        public string RazaoSocialDestinatario { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public string ChaveEletronica { get; set; }
        public string Protocolo { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataRecebimento { get; set; }
        public double ValorProdutos { get; set; }
        public double ValorNotaFiscal { get; set; }
        public double ValorIcmsBase { get; set; }
        public double ValorIcms { get; set; }
        public double ValorSubstituicaoIcmsBase { get; set; }
        public double ValorSubstituicaoIcms { get; set; }
        public double ValorIPI { get; set; }
        public double ValorFrete { get; set; }
        public double ValorSeguro { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorAcessorios { get; set; }
        public TbNotasFiscais() { }
    }
}
