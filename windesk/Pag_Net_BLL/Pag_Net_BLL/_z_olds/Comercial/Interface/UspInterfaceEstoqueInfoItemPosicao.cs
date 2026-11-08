using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceEstoqueInfoItemPosicao: Bll.USPDataContext
     {
        public InterfaceEstoqueInfoItemPosicaoFiltros Filtros { get; set; }
        public UspInterfaceEstoqueInfoItemPosicao(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new InterfaceEstoqueInfoItemPosicaoFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWInterfaceEstoqueInfoItemPosicao> L = new List<UVWInterfaceEstoqueInfoItemPosicao>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceEstoqueInfoItemPosicao l = new UVWInterfaceEstoqueInfoItemPosicao();
                        l.SeqInterfaceInfo = Convert.ToInt32(i["SeqInterfaceInfo"].ToString());
                        l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                        l.Descricao = i["Descricao"].ToString();
                        l.EmbalagemCompra = i["EmbalagemCompra"].ToString();
                        l.EmbalagemCompraQtde = Convert.ToDouble(i["EmbalagemCompraQtde"].ToString());
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
            ListParameters.Add(new Models.ParameterQuey("CdProdutoDepartamento", SqlDbType.VarChar, true, Filtros.CdProdutoDepartamento));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoSecao", SqlDbType.VarChar, true, Filtros.CdProdutoSecao ));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoLinha", SqlDbType.VarChar, true, Filtros.CdProdutoLinha));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, Filtros.Descricao ));
            ListParameters.Add(new Models.ParameterQuey("ProdutoLista", SqlDbType.VarChar, true, Filtros.ProdutoLista));

            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspInterfaceEstoqueInfoItemPosicao";
        }

    }
    public class UVWInterfaceEstoqueInfoItemPosicao
    {
        public int SeqInterfaceInfo { get; set; }
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string EmbalagemCompra { get; set; }
        public double EmbalagemCompraQtde { get; set; }
        public DateTime DataEstoque { get; set; }
    }

    public class InterfaceEstoqueInfoItemPosicaoFiltros
    {
        public int SeqInterfaceInfo  {get;set;}
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public string ProdutoLista { get; set; }
        public string Descricao { get; set; }

    }
}
