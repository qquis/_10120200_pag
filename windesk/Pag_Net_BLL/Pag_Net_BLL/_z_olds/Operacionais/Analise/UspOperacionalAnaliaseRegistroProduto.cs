using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;


namespace Pag_Net.Bll.Operacionais.Analise
{
    public class UspOperacionalAnaliaseRegistroProduto : Bll.USPDataContext
    {

        public double TotalVolume;
        public double TotalValorCustoPadrao;
        public int TotalItens;

        public Filtros Filtros;



        public UspOperacionalAnaliaseRegistroProduto(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new Filtros();   
        }

        public void Select()
        {
            string linhaEmProcessamento = "";
            try
            {
              

                //base.ViewData = null;
                TotalValorCustoPadrao = 0;
                TotalVolume = 0;

                List<RegistroProdutoItem> L = new List<RegistroProdutoItem>();
                base.Select();

                if (base.DataTableResult == null)
                {
                    return;
                }

                if (!DBNull.Value.Equals(base.DataTableResult))
                {
                    if (base.DataTableResult.Rows.Count > 0)
                    {
                        TotalValorCustoPadrao = Convert.ToDouble(base.DataTableResult.Compute("Sum(ValorCustoPadrao)", ""));
                    }
                    else
                    {
                        return;
                    }
                }

                else
                {
                    return;
                }


                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    RegistroProdutoItem l = new RegistroProdutoItem();
                    linhaEmProcessamento = i["Codigo"].ToString();
                    l.Codigo = i["Codigo"].ToString();
                    l.Descricao = i["Descricao"].ToString();
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.ValorCustoPadrao = Convert.ToDouble(i["ValorCustoPadrao"].ToString());
                    l.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"].ToString());

                    this.TotalVolume = this.TotalVolume + l.EmbalagemEstoqueQtde;

                    if (this.TotalValorCustoPadrao > 0)
                    {
                        l.Participacao = (l.ValorCustoPadrao / this.TotalValorCustoPadrao) * 100;
                    }
                    L.Add(l);

                    
                }



           
                base.ViewData = L.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public override Models.ParameterQuey[] ListParametros()
        {

            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataInicial", SqlDbType.DateTime, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataFinal", SqlDbType.DateTime, true, Filtros.DataFinal));
            ListParameters.Add(new Models.ParameterQuey("TipoPesquisa", SqlDbType.VarChar, true, Filtros.TipoPesquisa));
            ListParameters.Add(new Models.ParameterQuey("Departamento", SqlDbType.VarChar, true, Filtros.Departamento));
            ListParameters.Add(new Models.ParameterQuey("Secao", SqlDbType.VarChar, true, Filtros.Secao));
            ListParameters.Add(new Models.ParameterQuey("Linha", SqlDbType.VarChar, true, Filtros.Linha));
            ListParameters.Add(new Models.ParameterQuey("ProdutosCodigoLista", SqlDbType.VarChar, true, Filtros.ProdutosCodigoLista));
            ListParameters.Add(new Models.ParameterQuey("DescricaoProduto", SqlDbType.VarChar, true, Filtros.DescricaoProduto));
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoGestor", SqlDbType.Int, true, Filtros.SeqProdutoGestor));
            ListParameters.Add(new Models.ParameterQuey("SeqTipoRegistro", SqlDbType.Int, true, Filtros.SeqTipoRegistroProduto));

            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspOperacionalAnaliaseRegistroProduto";
        }
    }


    public class RegistroProdutoItem
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string EmbalagemEstoque { get; set; }
        public double EmbalagemEstoqueQtde { get; set; }
        public double ValorCustoPadrao { get; set; }
        public double Participacao { get; set; }


    }
}

