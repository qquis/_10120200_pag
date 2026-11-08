using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class ProdutoOperacaoPreco: Bll.USPDataContext
    {
       // public FiltrosBasicos Filtros { get; set; }
        public int CdOperacao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime DataCustoInicial { get; set; }
        public DateTime DataCustoFinal { get; set; }
        public bool AlteracoesPendentes { get; set; }
        ~ProdutoOperacaoPreco() {}
        public void Dispose() {}
        
        public ProdutoOperacaoPreco(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            //Filtros = new FiltrosBasicos();
        }
        public void Select()
        {
            int CdProdutoEmProcessamento = 0;
            try
            {
                List<VWProdutoOperacaoPreco> L = new List<VWProdutoOperacaoPreco>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    
                    VWProdutoOperacaoPreco l = new VWProdutoOperacaoPreco();

                    CdProdutoEmProcessamento = Convert.ToInt32(i["CdProduto"].ToString());
                    l.Index = index;
                    l.CdOperacao = Convert.ToInt32(i["CdOperacao"].ToString());
                    l.CdFabricante = i["CdFabricante"].ToString();
                    l.CdProdutoDepartamento = i["CdProdutoDepartamento"].ToString();
                    l.CdProdutoSecao = i["CdProdutoSecao"].ToString();
                    l.CdProdutoLinha = i["CdProdutoLinha"].ToString();
                    l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                    l.CdProdutoBlueSoft = Convert.ToInt32(i["CdProdutoBlueSoft"].ToString());
                    l.Descricao = i["Descricao"].ToString();
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.EmbalagemEstoquePreco = Convert.ToDouble( i["EmbalagemEstoquePreco"].ToString());
                    l.EmbalagemEstoquePrecoAlterado = l.EmbalagemEstoquePreco;
                    l.EmbalagemEstoqueCusto = Convert.ToDouble(i["EmbalagemEstoqueCusto"].ToString()); //->>> CUSTO ULTIMA ENTRADA PADRAO
                    //l.ValorPreco = Convert.ToDouble(i["ValorPreco"]);
                    //l.ValorCusto = Convert.ToDouble(i["ValorCustoPadrao"]);
                    l.Embalagem = i["Embalagem"].ToString();
                    l.EmbalagemCdprodutobluesoft = Convert.ToInt32(i["EmbalagemCdprodutobluesoft"].ToString());
                    l.FatorEstoque = Convert.ToDouble(i["FatorEstoque"].ToString());
                    l.FatorPreco = Convert.ToDouble(i["FatorPreco"].ToString());
                    
                    l.FatorPrecoAlterado = l.FatorPreco;
                    l.Relacao = i["Relacao"].ToString();
                    l.EmbalagemDescricao = i["EmbalagemDescricao"].ToString();
                    l.Agendado = Convert.ToBoolean(i["AGENDADO"].ToString());
                    l.DataAplicacao = Convert.ToDateTime(i["DataAplicacao"].ToString());
                    l.EmbalagemEstoqueCustoFaturamento = Convert.ToDouble(i["EmbalagemEstoqueCustoFaturamento"].ToString()); //-> CUSTO MEDIO 
                    l.AplicacaoPendente = Convert.ToBoolean (i["AplicacaoPendente"].ToString());
                    l.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"].ToString());
                    
                    l.QtdePromocional = Convert.ToDouble(i["QtdePromocional"].ToString());
                    l.QtdePromocionalAlterada = l.QtdePromocional;
                    //l.MargemMinima = Convert.ToDouble(i["MargemMinima"]);
                    //l.MargemMaxima = Convert.ToDouble(i["MargemMaxima"]);
                    L.Add(l);
                    index = index + 1;
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + " - Produto Em Processamento: " + CdProdutoEmProcessamento.ToString());
            }
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataAplicacao", SqlDbType.DateTime, true, this.DataAplicacao ));
            ListParameters.Add(new Models.ParameterQuey("CdOperacao", SqlDbType.Int, true, this.CdOperacao));
            ListParameters.Add(new Models.ParameterQuey("custodataInicial", SqlDbType.DateTime, true, this.DataCustoInicial));
            ListParameters.Add(new Models.ParameterQuey("custodataFinal", SqlDbType.DateTime, true, this.DataCustoFinal));
            ListParameters.Add(new Models.ParameterQuey("AplicacaoPendente", SqlDbType.Bit, true, this.AlteracoesPendentes));

            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "SPP0070_ProdutoPrecoConsulta";
            ///return "UspProdutoOperacaoPreco";
        }
    }
    public class VWProdutoOperacaoPreco
    {
        public int    Index { get; set; }
        public int    IndexLocal { get; set; }
        public int    CdOperacao { get; set; }
        public string CdFabricante { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public int    CdProduto { get; set; }
        public int    CdProdutoBlueSoft { get; set; }
        public string Descricao { get; set; }
        public string EmbalagemEstoque { get; set; }
        
        public string Embalagem { get; set; }
        public int      EmbalagemCdprodutobluesoft { get; set; }
        public double FatorEstoque { get; set; }
        
        public string EmbalagemDescricao { get; set; }
        public double MargemMinima { get; set; }
        public double MargemMaxima { get; set; }
        public string Relacao { get; set; }



        public double EmbalagemEstoquePreco { get; set; }
        public double EmbalagemEstoquePrecoAlterado { get; set; }

        public double EmbalagemEstoqueCusto { get; set; }
        public double EmbalagemEstoqueCustoFaturamento { get; set; }
        public double QtdePromocional { get; set; }
        public double QtdePromocionalAlterada { get; set; }
        public double ValorVariacaoCusto
        {
            get
            {
                try
                {
                    return (ValorCusto - ValorCustoFaturamento) / ValorCusto * 100;
                }
                catch(Exception)
                {
                    return 0;
                }
            }
        }

        public double ValorPreco
        {
            get
            {
                if (this.Relacao == "MAIOR")
                {
                    return Math.Round(this.EmbalagemEstoquePreco * this.FatorPreco,2) * this.FatorEstoque ;
                }
                else
                {
                    return Math.Round(this.EmbalagemEstoquePreco * this.FatorPreco, 2) / this.FatorEstoque;
                }

            }
            
        }

        public double ValorPrecoAlterado
        {
            get 
            {
                if (this.Relacao == "MAIOR")
                {
                    return Math.Round(this.EmbalagemEstoquePrecoAlterado * this.FatorPrecoAlterado, 2) * this.FatorEstoque;
                }
                else
                {
                    return Math.Round(this.EmbalagemEstoquePrecoAlterado * this.FatorPrecoAlterado, 2) / this.FatorEstoque;
                }

            }
        }
        private Double  _fatorPreco;
        public double FatorPreco
        {
            get {return _fatorPreco;}
            set
            {
                if (value == 0)
                {
                    throw new Exception("Valor invalido");

                }
                else
                {
                    _fatorPreco = value;
                }
            }
        }

        private Double _fatorPrecoAlterado;
        public double FatorPrecoAlterado
        {
            get { return _fatorPrecoAlterado; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Valor invalido");

                }
                else
                {
                    _fatorPrecoAlterado = value;
                }

            }
        }


        public double EmbalagemEstoqueQtde { get; set; }

        public double ValorEstoque
        {
            get
            {
                double valor;
                if (this.Relacao == "MAIOR")
                {
                    valor = Math.Round(this.EmbalagemEstoqueQtde / this.FatorEstoque, 4);
                }
                else
                {
                    valor = Math.Round(this.EmbalagemEstoqueQtde * this.FatorEstoque, 4);
                }
                return valor;
            }

        }

        public double ValorCusto 
        {
            get
            {
                double valor;
                if (this.Relacao == "MAIOR")
                {
                    valor = Math.Round(this.EmbalagemEstoqueCusto * this.FatorEstoque,2 );
                }
                else
                {
                    valor = Math.Round(this.EmbalagemEstoqueCusto / this.FatorEstoque,2 );
                }
                return valor;
            }
        }


        public double ValorCustoFaturamento
        {
            get
            {
                double valor;
                if (this.Relacao == "MAIOR")
                {
                    valor = Math.Round(this.EmbalagemEstoqueCustoFaturamento * this.FatorEstoque, 2);
                }
                else
                {
                    valor = Math.Round(this.EmbalagemEstoqueCustoFaturamento / this.FatorEstoque, 2);
                }
                return valor;
            }
        }

        public double Margem 
        { 
            get
            {
                if (this.ValorPreco > 0)
                {
                    return Math.Round((this.ValorPreco - this.ValorCusto) / this.ValorPreco * 100, 2);
                }
                else
                {
                    return 0;
                }

            } 
        }
        public double MargemAlterada 
        { 
            get
            {
                if (this.ValorPrecoAlterado > 0)
                {
                    return Math.Round((this.ValorPrecoAlterado - this.ValorCusto) / this.ValorPrecoAlterado * 100, 2);
                }
                else
                {
                    return 0;
                }
            } 
        }

        public bool Agendado { get; set; }
        public DateTime DataAplicacao { get; set; }
        public bool AplicacaoPendente { get; set; }


        public VWProdutoOperacaoPreco() { }
        public VWProdutoOperacaoPreco(int index, int indexLocal, int cdProduto, string descricao, string embalagemEstoque, double embalagemEstoquePreco, double embalagemEstoquePrecoALTERADO, double embalagemEstoqueCusto, string embalagem, string embalagemDescricao, double fatorEstoque, double fatorPreco, double fatorPrecoALTERADO, DateTime __DataAplicacao, bool __Agendado, double __EmbalagemEstoqueCustoFaturamento, bool __AplicacaoPendente, string __Relacao, double __EmbalagemEstoqueQtde, double qtdePromocional, Double qtdePromocionalAlterada, int embalagemCdProdutoBlueSoft)
        {
            this.Index = index;
            this.IndexLocal = indexLocal;
            this.CdProduto = cdProduto;
            this.Descricao = descricao;
            this.FatorPreco = fatorPreco;
            this.FatorPrecoAlterado = fatorPrecoALTERADO;
            
            this.FatorEstoque = fatorEstoque;
            this.EmbalagemEstoque = embalagemEstoque;
            this.EmbalagemEstoquePreco = embalagemEstoquePreco;
            this.EmbalagemEstoquePrecoAlterado = embalagemEstoquePrecoALTERADO;
            this.EmbalagemEstoqueCusto = embalagemEstoqueCusto;
            this.Embalagem = embalagem;
            this.EmbalagemCdprodutobluesoft = embalagemCdProdutoBlueSoft;
            this.EmbalagemDescricao = embalagemDescricao;
            this.DataAplicacao = __DataAplicacao;
            this.Agendado = __Agendado;
            this.EmbalagemEstoqueCustoFaturamento = __EmbalagemEstoqueCustoFaturamento;
            this.AplicacaoPendente = __AplicacaoPendente;
            this.Relacao = __Relacao;
            this.EmbalagemEstoqueQtde = __EmbalagemEstoqueQtde;
            this.QtdePromocional = qtdePromocional;
            this.QtdePromocionalAlterada = qtdePromocionalAlterada;
        }
   
    }

}
