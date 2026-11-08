using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Operacionais.Analise
{
    public class Filtros
    {
        private DateTime _DataInicial;
        public DateTime DataInicial
        {
            get
            {
                return _DataInicial;
            }
            set
            {
                if (value == null)
                {
                    _DataInicial = DateTime.Now.Date;
                }
                else
                {
                    _DataInicial = value;
                }
            }
        }

        private DateTime _DataFinal;
        public DateTime DataFinal
        {
            get
            {
                return _DataFinal;
            }
            set
            {
                if (value == null)
                {
                    _DataFinal = DateTime.Now.Date;
                }
                else
                {
                    _DataFinal = value;
                }
            }
        }

        public string TipoPesquisa { get; set; }

        public string Fabricante { get; set; }
        public string Departamento { get; set; }
        public string Secao { get; set; }
        public string Linha { get; set; }
        public int Vendedor { get; set; }
        public int Cliente { get; set; }
        public string NomeCliente { get; set; }
        public bool EmbalagemFornecedor { get; set; }
        public string StatusFaturamento { get; set; }
        public string ProdutosCodigoLista { get; set; }
        public string DescricaoProduto { get; set; }
        public string NumerosPedidos { get; set; }
        public int CdOperacao { get; set; }
        public int SeqProdutoGestor { get; set; }
        public int SeqTipoRegistroProduto { get; set; }
        public int SeqProdutoCategoria { get; set;  }
        public Int16 OperacoesComOutrosTiposDeProduto { get; set; }
        public Int16 FvBlueSoft { get; set; }
        
        
    }
}
