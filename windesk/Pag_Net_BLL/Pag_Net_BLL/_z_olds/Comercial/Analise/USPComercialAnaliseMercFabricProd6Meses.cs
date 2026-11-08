using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Comercial.Analise
{
    public class USPComercialAnaliseMercFabricProd6Meses : Bll.USPDataContext
    {
        public double ValorTotalMes1;
        public double ValorTotalMes2;
        public double ValorTotalMes3;
        public double ValorTotalMes4;
        public double ValorTotalMes5;
        public double ValorTotalMes6;
        public double ValorTotalMes7;

        public ParametrosComercialAnaliseMercFabricProd6Meses Parametros;
        public USPComercialAnaliseMercFabricProd6Meses(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosComercialAnaliseMercFabricProd6Meses();
        }

        public void Select()
        {
            List<UVWComercialAnaliseMercFabricProd6Meses> L = new List<UVWComercialAnaliseMercFabricProd6Meses>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWComercialAnaliseMercFabricProd6Meses l = new UVWComercialAnaliseMercFabricProd6Meses();
                l.CdFabricante = i["CdFabricante"].ToString();
                l.DescricaoFabricante = i["DescricaoFabricante"].ToString();
                l.CdProduto = Convert.ToInt32(i["CdProduto"]);
                l.DescricaoProduto = i["DescricaoProduto"].ToString();

                l.M1EmbalagemCompraQtde = Convert.ToDouble(i["M1EmbalagemCompraQtde"]);
                l.M2EmbalagemCompraQtde = Convert.ToDouble(i["M2EmbalagemCompraQtde"]);
                l.M3EmbalagemCompraQtde = Convert.ToDouble(i["M3EmbalagemCompraQtde"]);
                l.M4EmbalagemCompraQtde = Convert.ToDouble(i["M4EmbalagemCompraQtde"]);
                l.M5EmbalagemCompraQtde = Convert.ToDouble(i["M5EmbalagemCompraQtde"]);
                l.M6EmbalagemCompraQtde = Convert.ToDouble(i["M6EmbalagemCompraQtde"]);
                l.M7EmbalagemCompraQtde = Convert.ToDouble(i["M7EmbalagemCompraQtde"]);
                l.M1EmbalagemEstoqueQtde = Convert.ToDouble(i["M1EmbalagemEstoqueQtde"]);
                l.M2EmbalagemEstoqueQtde = Convert.ToDouble(i["M2EmbalagemEstoqueQtde"]);
                l.M3EmbalagemEstoqueQtde = Convert.ToDouble(i["M3EmbalagemEstoqueQtde"]);
                l.M4EmbalagemEstoqueQtde = Convert.ToDouble(i["M4EmbalagemEstoqueQtde"]);
                l.M5EmbalagemEstoqueQtde = Convert.ToDouble(i["M5EmbalagemEstoqueQtde"]);
                l.M6EmbalagemEstoqueQtde = Convert.ToDouble(i["M6EmbalagemEstoqueQtde"]);
                l.M7EmbalagemEstoqueQtde = Convert.ToDouble(i["M7EmbalagemEstoqueQtde"]);
                l.M1Valor = Convert.ToDouble(i["M1Valor"]);
                l.M2Valor = Convert.ToDouble(i["M2Valor"]);
                l.M3Valor = Convert.ToDouble(i["M3Valor"]);
                l.M4Valor = Convert.ToDouble(i["M4Valor"]);
                l.M5Valor = Convert.ToDouble(i["M5Valor"]);
                l.M6Valor = Convert.ToDouble(i["M6Valor"]);
                l.M7Valor = Convert.ToDouble(i["M7Valor"]);


                this.ValorTotalMes1 = this.ValorTotalMes1 + l.M1Valor;
                this.ValorTotalMes2 = this.ValorTotalMes2 + l.M2Valor;
                this.ValorTotalMes3 = this.ValorTotalMes3 + l.M3Valor;
                this.ValorTotalMes4 = this.ValorTotalMes4 + l.M4Valor;
                this.ValorTotalMes5 = this.ValorTotalMes5 + l.M5Valor;
                this.ValorTotalMes6 = this.ValorTotalMes6 + l.M6Valor;
                this.ValorTotalMes7 = this.ValorTotalMes7 + l.M7Valor;



                l.ValorEstoque = Convert.ToDouble(i["ValorEstoque"]);
                l.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"]);
                l.EmbalagemCompraQtde = Convert.ToDouble(i["EmbalagemCompraQtde"]); 


                l.MesFaturamento = Convert.ToDouble(i["MesFaturamento"]);
                l.MesCusto = Convert.ToDouble(i["MesCusto"]);
                l.MesEmbalagemCompraQtde = Convert.ToDouble(i["MesEmbalagemCompraQtde"]);
                l.MesEmbalagemEstoqueQtde = Convert.ToDouble(i["MesEmbalagemCompraQtde"]);

                if ( l.MesFaturamento > 0 && l.MesCusto > 0)
                {
                    l.MesMargem = Math.Round( (l.MesFaturamento - l.MesCusto) / l.MesFaturamento, 2);
                }


                l.MediaFaturamento = Convert.ToDouble(i["MesFaturamento"]);
                l.MediaCusto = Convert.ToDouble(i["MediaCusto"]);

                l.MediaEmbalagemCompraQtde = Convert.ToDouble(i["MesEmbalagemCompraQtde"]);
                l.MediaEmbalagemEstoqueQtde = Convert.ToDouble(i["MesEmbalagemCompraQtde"]);
                if (l.MediaFaturamento > 0 && l.MediaCusto > 0)
                {
                    l.MediaMargem = Math.Round((l.MediaFaturamento - l.MediaCusto) / l.MediaFaturamento, 2);
                }

                if ((l.M1Valor + l.M2Valor + l.M3Valor + l.M4Valor + l.M5Valor + l.M6Valor) > 0 & l.MediaCusto > 0)
                {
                    l.IndiceMedio = Math.Round( (((l.M1Valor + l.M2Valor + l.M3Valor + l.M4Valor + l.M5Valor + l.M6Valor) / 6) / l.MediaCusto),3);
                }

                if (l.ValorEstoque > 0 && l.MesCusto > 0)
                {
                    l.IndiceCorrente = l.ValorEstoque / l.MesCusto;
                }

                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
        public override string SQLCommnad()
        {
            return "USPComercialAnaliseMercFabricProd6Meses";
        }
    }

    public class UVWComercialAnaliseMercFabricProd6Meses
    {
        public string CdFabricante { get; set; }
        public string DescricaoFabricante { get; set; }
        public int CdProduto { get; set; }
        public string DescricaoProduto { get; set; }

        public double M1Valor { get; set; }
        public double M2Valor { get; set; }
        public double M3Valor { get; set; }
        public double M4Valor { get; set; }
        public double M5Valor { get; set; }
        public double M6Valor { get; set; }
        public double M7Valor { get; set; }

        public double M1EmbalagemEstoqueQtde { get; set; }
        public double M2EmbalagemEstoqueQtde { get; set; }
        public double M3EmbalagemEstoqueQtde { get; set; }
        public double M4EmbalagemEstoqueQtde { get; set; }
        public double M5EmbalagemEstoqueQtde { get; set; }
        public double M6EmbalagemEstoqueQtde { get; set; }
        public double M7EmbalagemEstoqueQtde { get; set; }

        public double M1EmbalagemCompraQtde { get; set; }
        public double M2EmbalagemCompraQtde { get; set; }
        public double M3EmbalagemCompraQtde { get; set; }
        public double M4EmbalagemCompraQtde { get; set; }
        public double M5EmbalagemCompraQtde { get; set; }
        public double M6EmbalagemCompraQtde { get; set; }
        public double M7EmbalagemCompraQtde { get; set; }

        public double MesFaturamento { get; set; }
        public double MesEmbalagemEstoqueQtde { get; set; }
        public double MesEmbalagemCompraQtde { get; set; }
        public double MesCusto { get; set; }
        public double MesMargem { get; set; }

        public double MediaFaturamento { get; set; }
        public double MediaEmbalagemEstoqueQtde { get; set; }
        public double MediaEmbalagemCompraQtde { get; set; }
        public double MediaCusto { get; set; }
        public double MediaMargem { get; set; }

        public double IndiceCorrente { get; set; }
        public double IndiceMedio { get; set; }

        public double ValorEstoque { get; set; }
        public double EmbalagemEstoqueQtde { get; set; }
        public double EmbalagemCompraQtde { get; set; }

    }
    
    public class ParametrosComercialAnaliseMercFabricProd6Meses
    {
        public DateTime DataProcessamento { get; set; }
        public string TipoRelatorio { get; set; }
        public string CdFabricante { get; set; }
        public int CdProduto { get; set; }
        public int CdOperacao { get; set; }
    }


}


