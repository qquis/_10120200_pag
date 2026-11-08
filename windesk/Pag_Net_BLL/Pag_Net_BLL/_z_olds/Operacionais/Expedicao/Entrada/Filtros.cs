using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Operacionais.Operacoes.Entrada
{
    public class FiltrosBasicos
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

        private int _CodigoFornecedor;
        private int _NumeroNotaFiscal;

        public int CodigoFornecedor
        {

            get
            {
                return _CodigoFornecedor;
            }
            set
            {
                _CodigoFornecedor = value;
            }

        }
        public int NumeroNotaFiscal
        {

            get
            {
                return _NumeroNotaFiscal;
            }
            set
            {
                _NumeroNotaFiscal = value;
            }

        }
    }
    public class FiltrosNotasFiscais: FiltrosBasicos
    {
        private string _ValorInicial;
        private string _ValorFinal;


        public bool? CheckSimBonificadas { get; set; }
        public bool? CheckNaoBonificadas { get; set; }

        public string ValorInicial 
        {
            get
            {
                return _ValorInicial;
            }
            set
            {
                try
                {
                    
                    if (Bll.Util.IsDouble(value) == true)
                    {
                        _ValorInicial = value; 
                    }
                    else
                    {
                        new Exception("Valor Inválido");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
                
            }
        }
        public string ValorFinal
        {
            get
            {
                return _ValorFinal;
            }
            set
            {
                try
                {
                    if (Bll.Util.IsDouble(value) == true)
                    {
                        _ValorFinal = value;

                    }
                    else
                    {
                        new Exception("Valor Inválido");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }

            }
        }
        public string NumerosNotasFiscais { get; set; }





    }
    public class FiltrosNotasFiscaisItem: FiltrosBasicos
    {
        private int _CdProduto;

        
        public int CdProduto
        {
            get
            {
                return _CdProduto;
            }
            set
            {
                _CdProduto = value;
            }

        }
    }

}
