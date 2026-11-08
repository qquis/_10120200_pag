using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class ProdutoOperacaoCusto : Bll.USPDataContext
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Descricao { get; set; }
        public ProdutoOperacaoCusto(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {

        }
        public void Select()
        {
            List<VWProdutoOperacaoCusto> L = new List<VWProdutoOperacaoCusto>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                VWProdutoOperacaoCusto l = new VWProdutoOperacaoCusto();
                l.CdEmpresa = Convert.ToInt32(i["CdEmpresa"].ToString());
                l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.DataAtualizacao = Convert.ToDateTime(i["DataAtualizacao"].ToString());
                l.UltimaEntradaData = Convert.ToDateTime(i["UltimaEntradaData"].ToString());
                l.UltimaEntradaValorCusto = Convert.ToDouble(i["UltimaEntradaValorCusto"].ToString());
                l.ValorCustoPadrao = Convert.ToDouble(i["ValorCustoPadrao"].ToString());
                l.DataCusto = Convert.ToDateTime(i["DataCusto"].ToString());
                l.SeqProdutoCusto = Convert.ToInt32(i["SeqProdutoCusto"].ToString());
                l.ValorCustoPadraoAtual = Convert.ToDouble(i["ValorCustoPadraoAtual"].ToString());
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataInicial", SqlDbType.DateTime, true, this.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataFinal", SqlDbType.DateTime, true, this.DataFinal));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, this.Descricao));

            return ListParameters.ToArray();
            //return null;
        }
        public override string SQLCommnad()
        {
            return "UspProdutoOperacaoCusto";
        }
    }

    public class VWProdutoOperacaoCusto
    {
        public int CdEmpresa { get; set; }
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public double ValorCustoPadrao { get; set; }
        public int SeqProdutoCusto { get; set; }
        public DateTime DataCusto { get; set; }
        public double ValorCustoPadraoAtual { get; set; }
        public int UltimaEntradaNfe { get; set; }
        public DateTime UltimaEntradaData { get; set; }
        public double UltimaEntradaValorCusto { get; set; }
        public VWProdutoOperacaoCusto() { }
    }

}
