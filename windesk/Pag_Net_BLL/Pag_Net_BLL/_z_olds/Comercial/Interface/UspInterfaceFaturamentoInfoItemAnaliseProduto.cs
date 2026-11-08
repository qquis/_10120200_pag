using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceFaturamentoInfoItemAnaliseProduto: Bll.USPDataContext
     {
        public InterfaceFaturamentoInfoItemAnaliseProdutoFiltros Filtros { get; set; }
        public UspInterfaceFaturamentoInfoItemAnaliseProduto(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new InterfaceFaturamentoInfoItemAnaliseProdutoFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWInterfaceFaturamentoInfoItemAnaliseProduto> L = new List<UVWInterfaceFaturamentoInfoItemAnaliseProduto>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceFaturamentoInfoItemAnaliseProduto l = new UVWInterfaceFaturamentoInfoItemAnaliseProduto();

                        l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                        l.DescricaoProduto = i["DescricaoProduto"].ToString();
                        l.PositivacaoTotalProduto = Convert.ToDouble(i["PositivacaoTotalProduto"].ToString());
                        l.ValorTotalFaturamentoProduto = Convert.ToDouble(i["ValorTotalFaturamentoProduto"].ToString());
                        l.VolumeTotalProduto = Convert.ToDouble(i["VolumeTotalProduto"].ToString());
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
            ListParameters.Add(new Models.ParameterQuey("DataInicial", SqlDbType.Date, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataFinal", SqlDbType.Date, true, Filtros.DataFinal));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoDepartamento", SqlDbType.VarChar, true, Filtros.CdProdutoDepartamento));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoSecao", SqlDbType.VarChar, true, Filtros.CdProdutoSecao ));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoLinha", SqlDbType.VarChar, true, Filtros.CdProdutoLinha));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, Filtros.Descricao ));
            ListParameters.Add(new Models.ParameterQuey("ProdutoLista", SqlDbType.VarChar, true, Filtros.ProdutoLista));

            return ListParameters.ToArray();
            //return null;
        }
        public override string SQLCommnad()
        {
            return "UspInterfaceFaturamentoInfoItemAnaliseProduto";
        }

    }
    public class UVWInterfaceFaturamentoInfoItemAnaliseProduto
    {
        public int CdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double PositivacaoTotalProduto { get; set; }
        public double ValorTotalFaturamentoProduto { get; set; }
        public double VolumeTotalProduto { get; set; }
    }

    public class InterfaceFaturamentoInfoItemAnaliseProdutoFiltros
    {
        public int SeqInterfaceInfo  {get;set;}
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public string ProdutoLista { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string ListaArquivos { get; set; }

    }
}
