using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class FiltrosBasicos
    {
        public string Arquivo { get; set; }
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
        public string Finalizadora { get; set; }
    }
    public class FiltrosCartaoCreditoInterface
    {
        private int _SeqArquivo;
        public int SeqArquivo
        {
            get
            {
                return _SeqArquivo;
            }
            set
            {
                if (value == null)
                {
                    _SeqArquivo = 0;
                }
                else
                {
                    _SeqArquivo = value;
                }
            }
        }


        public DateTime DataEmissaoInicial { get; set; }
        public DateTime DataEmissaoFinal { get; set; }

        public DateTime DataPgtoInicial { get; set; }
        public DateTime DataPgtoFinal { get; set; }

        public int SeqLinhaResumo { get; set; }
    }
}
