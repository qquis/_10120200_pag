using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class Precos
    {
        private Models.modelSistemaUsuario MyConnect;
        public Pag_Net.Bll.Cadastros.Gerais Cadastros;

        public VWProdutoOperacaoPreco[] ListAll { get; set; }

        public VWProdutoOperacaoPreco[] SelectProdutoList { get; set; }
        public VWProdutoOperacaoPreco[] SelectEmbalagensList { get; set; }

        public VWProdutoOperacaoPreco SelectItem { get; set; }

        public List<VWProdutoOperacaoPreco> PrecosAlterados { get; set; }
        public List<VWProdutoOperacaoPreco> EmbalagensAlteradas { get; set; }

        public int CdOperacao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime DataCustoInicial { get; set; }
        public DateTime DataCustoFinal { get; set; }
        public bool AlteracoesPendentes { get; set; }

        public string CdFabricante { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public string Descricao { get; set; }
        public int CdProduto { get; set; }
        public int CdProdutoBlueSoft { get; set; }

        public int ProdutosTotalFiltrado { get; set; }
        public double ProdutosMargemMedia { get; set; }
        

        private Produto.ProdutoOperacaoPreco BLL;
        public void Dispose() { }
        ~Precos() { }


        public Precos(Models.modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;
            this.CdFabricante = "";
            this.CdProdutoDepartamento = "";
            this.CdProdutoSecao = "";
            this.CdProdutoLinha = "";
            this.Descricao = "";
            this.CdProduto = 0;
            
            BLL = new ProdutoOperacaoPreco(_myConnect);
            Cadastros = new Bll.Cadastros.Gerais(_myConnect);
            PrecosAlterados = new List<VWProdutoOperacaoPreco>();
            EmbalagensAlteradas = new List<VWProdutoOperacaoPreco>();
        }

        public void Select()
        {
            BLL.CdOperacao = this.CdOperacao;
            BLL.DataAplicacao = this.DataAplicacao;
            BLL.DataCustoInicial = this.DataCustoInicial;
            BLL.DataCustoFinal = this.DataCustoFinal;
            BLL.AlteracoesPendentes = this.AlteracoesPendentes;
            //BLL.DataAplicacao 
            BLL.Select();
            this.ListAll = (VWProdutoOperacaoPreco[])BLL.ViewData;
            Filtrar();
        }



        public void Produtos()
        {
            Filtrar();
            this.SelectProdutoList = null;
            this.SelectEmbalagensList = null;
            this.SelectProdutoList = fill((from t in Filtrar() where (t.Embalagem == t.EmbalagemEstoque) select t).ToArray());
        }
        public void Embalagens(int cdProdutoSelecionado)
        {
            this.SelectEmbalagensList = fill((from t in Filtrar() where (t.Embalagem != t.EmbalagemEstoque) where (t.CdProduto == cdProdutoSelecionado) select t).ToArray());
        }

        public VWProdutoOperacaoPreco[] Alterados()
        {
            return fill((from t in this.ListAll
                        where ( t.EmbalagemEstoquePreco != t.EmbalagemEstoquePrecoAlterado || t.FatorPreco != t.FatorPrecoAlterado || t.QtdePromocionalAlterada != t.QtdePromocional )
                        select t).ToArray());
        }

        public void Aplicacao(DateTime __DataAplicacao, int __CdOperacao)
        {
            try
            {
                Pag_Net.Bll.Operacionais.Produto.UspProdutoPrecoAlteracao.Aplicacao(MyConnect, Alterados(), __DataAplicacao , __CdOperacao);
                foreach (VWProdutoOperacaoPreco i in this.ListAll)
                {
                    i.EmbalagemEstoquePreco = i.EmbalagemEstoquePrecoAlterado;
                    i.FatorPreco = i.FatorPrecoAlterado;
                    i.QtdePromocional = i.QtdePromocionalAlterada;
                    i.AplicacaoPendente = true;
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
        }


        private VWProdutoOperacaoPreco[] fill(VWProdutoOperacaoPreco[] arrayVwProdutoOperacaoPreco)
        {
            int index = 0;
            int TotalItens = 0;
            double MargemMedia = 0;

            List<VWProdutoOperacaoPreco> L = new List<VWProdutoOperacaoPreco>();
            foreach (VWProdutoOperacaoPreco i in arrayVwProdutoOperacaoPreco)
            {
                L.Add(new VWProdutoOperacaoPreco(i.Index, index, i.CdProduto, i.Descricao, i.EmbalagemEstoque, i.EmbalagemEstoquePreco, i.EmbalagemEstoquePrecoAlterado, i.EmbalagemEstoqueCusto, i.Embalagem, i.EmbalagemDescricao, i.FatorEstoque, i.FatorPreco, i.FatorPrecoAlterado, i.DataAplicacao, i.Agendado, i.EmbalagemEstoqueCustoFaturamento, i.AplicacaoPendente, i.Relacao, i.EmbalagemEstoqueQtde, i.QtdePromocional, i.QtdePromocionalAlterada, i.EmbalagemCdprodutobluesoft));
                index = index + 1;
                
                MargemMedia = MargemMedia + i.Margem;
                
            }
            TotalItens = index -1;
            if (TotalItens > 0)
            {
                this.ProdutosMargemMedia = MargemMedia / Convert.ToDouble(TotalItens);
                this.ProdutosTotalFiltrado = TotalItens;
            }


            return L.ToArray();
        }

        public VWProdutoOperacaoPreco[] Filtrar()
        {
            //VWProdutoOperacaoPreco[] List = this.ListAll;
            return  (from t in this.ListAll
                 where (t.CdFabricante == ((this.CdFabricante != "") ? this.CdFabricante : t.CdFabricante))
                 where (t.CdProdutoDepartamento == ((this.CdProdutoDepartamento != "") ? this.CdProdutoDepartamento : t.CdProdutoDepartamento))
                 where (t.CdProdutoSecao == ((this.CdProdutoSecao != "") ? this.CdProdutoSecao : t.CdProdutoSecao))
                 where (t.CdProdutoLinha == ((this.CdProdutoLinha != "") ? this.CdProdutoLinha : t.CdProdutoLinha))
                 where (t.Descricao.Contains(this.Descricao))
                 where (t.CdProduto == ((this.CdProduto > 0) ? this.CdProduto : t.CdProduto))
                 where (t.CdProdutoBlueSoft == ((this.CdProdutoBlueSoft > 0) ? this.CdProdutoBlueSoft : t.CdProdutoBlueSoft))
                 select t).ToArray();
        }
    
        /*
        public VWProdutoOperacaoPreco[] GetCodigoBarra(int cdProduto, string embalagem)
        {
            VWProdutoOperacaoPreco[] List = (VWProdutoOperacaoPreco[])BLL.ViewData;


            var TempTbPrecoBase = (from t in List
                                   group t by new { t.CdProduto, t.EmbalagemDescricao, t.Embalagem, t.CdBarra} into Z
                                   where (Z.Key.CdProduto == cdProduto)
                                   where (Z.Key.Embalagem == ((embalagem != "") ? embalagem : Z.Key.Embalagem))
                                   select Z);



            List<VWProdutoOperacaoPreco> ListaPrecoBase = new List<VWProdutoOperacaoPreco>();

            foreach (var i in TempTbPrecoBase)
            {
                ListaPrecoBase.Add(new VWProdutoOperacaoPreco(i.Key.CdProduto, i.Key.EmbalagemDescricao, i.Key.Embalagem, i.Key.CdBarra));
            }
            return ListaPrecoBase.ToArray();
        }
         */

        public void AlterarProduto(VWProdutoOperacaoPreco item, double precoAlterado, double margemAlterada, bool ManterPreco)
        {
            AlterarProduto(item, precoAlterado, margemAlterada, ManterPreco, 0);
        }

        public void AlterarProduto(VWProdutoOperacaoPreco item, double precoAlterado, double margemAlterada, bool ManterPreco, double QtdePromocional)
        {

            //ProdutosSelecionados[0].Index
            //this.EmbalagensSelecionadas[0].
            double ValorCustoSelecionado = 0;
            if (item.EmbalagemEstoque == item.Embalagem)
            {
                ValorCustoSelecionado = SelectProdutoList[item.IndexLocal].EmbalagemEstoqueCusto;
                if (margemAlterada != 0)
                {
                    if (margemAlterada >= 100)
                    {
                        throw new Exception("Valor inválido! Informe o valor entre - 99 e 99");
                    }
                    precoAlterado = Math.Round(ValorCustoSelecionado / (1 - (margemAlterada / 100)), 2);
                }



                SelectProdutoList[item.IndexLocal].EmbalagemEstoquePrecoAlterado = precoAlterado;

                foreach (VWProdutoOperacaoPreco x in this.ListAll)
                {
                    if (x.CdProduto == item.CdProduto)
                    {
                        
                        this.ListAll[x.Index].EmbalagemEstoquePrecoAlterado = precoAlterado;
                        x.EmbalagemEstoquePrecoAlterado = precoAlterado;
                        if (ManterPreco && this.ListAll[x.Index].Embalagem != item.EmbalagemEstoque)
                        {
                            double precoAnterior = this.ListAll[x.Index].ValorPreco;
                            
                            AlterarProduto(x, precoAnterior, 0, false);
                        }
                        
                    }

              

                }
            }

            else
            {
                if (margemAlterada != 0 || precoAlterado != 0)
                {
                    ValorCustoSelecionado = SelectEmbalagensList[item.IndexLocal].EmbalagemEstoqueCusto;
                    if (margemAlterada != 0)
                    {
                        precoAlterado = Math.Round(ValorCustoSelecionado / (1 - (margemAlterada / 100)), 2);
                    }
                    //SelectEmbalagensList[item.IndexLocal].FatorPrecoAlterado = precoAlterado / SelectEmbalagensList[item.IndexLocal].EmbalagemEstoquePrecoAlterado;


                    double ValorEmbalagemBasico = 0;
                    if (this.ListAll[item.Index].Relacao == "MAIOR")
                    {
                        ValorEmbalagemBasico = precoAlterado / this.ListAll[item.Index].FatorEstoque;
                    }
                    else
                    {
                        ValorEmbalagemBasico = precoAlterado * this.ListAll[item.Index].FatorEstoque;
                    }
                    ValorEmbalagemBasico = Math.Round(ValorEmbalagemBasico, 2);
                    this.SelectEmbalagensList[item.IndexLocal].EmbalagemEstoquePrecoAlterado = ListAll[item.Index].EmbalagemEstoquePrecoAlterado;
                    this.ListAll[item.Index].FatorPrecoAlterado = Math.Round(ValorEmbalagemBasico / SelectEmbalagensList[item.IndexLocal].EmbalagemEstoquePrecoAlterado, 4);

                    this.SelectEmbalagensList[item.IndexLocal].FatorPrecoAlterado = Math.Round(ValorEmbalagemBasico / SelectEmbalagensList[item.IndexLocal].EmbalagemEstoquePrecoAlterado, 4);
                }
                if (QtdePromocional != this.SelectEmbalagensList[item.IndexLocal].QtdePromocionalAlterada)
                {
                    this.SelectEmbalagensList[item.IndexLocal].QtdePromocionalAlterada = QtdePromocional;
                    this.ListAll[item.Index].QtdePromocionalAlterada = QtdePromocional;
                }

            }


        }

    }
  
}
