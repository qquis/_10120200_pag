using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceEstoqueInfoItem : Bll.USPDataContext
    {
        public InterfaceEstoqueInfoItemFiltros Filtros { get; set; }
        public UspInterfaceEstoqueInfoItem(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new InterfaceEstoqueInfoItemFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWInterfaceEstoqueInfoItem> L = new List<UVWInterfaceEstoqueInfoItem>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceEstoqueInfoItem l = new UVWInterfaceEstoqueInfoItem();
                        l.SeqInterfaceInfo = Convert.ToInt32(i["SeqInterfaceInfo"].ToString());
                        l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                        l.Descricao = i["Descricao"].ToString();
                        l.EmbalagemCompra = i["EmbalagemCompra"].ToString();
                        l.EmbalagemCompraQtde = Convert.ToDouble(i["EmbalagemCompraQtde"].ToString());
                        l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                        l.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"].ToString());

                        l.EmbalagemEstoqueQtdeCompra = Convert.ToDouble(i["EmbalagemEstoqueQtdeCompra"].ToString());
                        l.EmbalagemEstoqueQtdeDevolucoes = Convert.ToDouble(i["EmbalagemEstoqueQtdeDevolucoes"].ToString());
                        l.EmbalagemEstoqueQtdeVendidas = Convert.ToDouble(i["EmbalagemEstoqueQtdeVendidas"].ToString());
                        l.EmbalagemEstoqueQtdeVendidasSimuladas = Convert.ToDouble(i["EmbalagemEstoqueQtdeVendidasSimuladas"].ToString());
                        l.DataEstoque = Convert.ToDateTime(i["DataEstoque"].ToString());
                        L.Add(l);
                    }
                    base.ViewData = L.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("SeqInterfaceInfo", SqlDbType.Int, true, Filtros.SeqInterfaceInfo));
            ListParameters.Add(new Models.ParameterQuey("ProdutoLista", SqlDbType.Int, true, Filtros.ProdutoLista));

            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspInterfaceEstoqueInfoItem";
        }

        public class UVWInterfaceEstoqueInfoItem
        {
            public int SeqInterfaceInfo { get; set; }
            public int CdProduto { get; set; }
            public string Descricao { get; set; }
            public string EmbalagemCompra { get; set; }
            public double EmbalagemCompraQtde { get; set; }

            public string EmbalagemEstoque { get; set; }
            public double EmbalagemEstoqueQtde { get; set; }

            public double EmbalagemEstoqueQtdeCompra { get; set; }
            public double EmbalagemEstoqueQtdeDevolucoes { get; set; }
            public double EmbalagemEstoqueQtdeVendidas{ get; set; }
            public double EmbalagemEstoqueQtdeVendidasSimuladas { get; set; }

            public DateTime DataEstoque { get; set; }
        }

        public class InterfaceEstoqueInfoItemFiltros
        {
            public int SeqInterfaceInfo { get; set; }
            public string ProdutoLista {get;set;}


        }
    }
}