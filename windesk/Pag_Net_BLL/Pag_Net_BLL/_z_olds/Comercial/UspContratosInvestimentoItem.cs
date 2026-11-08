using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Comercial
{
    public class UspContratosInvestimentoItem: Bll.USPDataContext
     {
        public ContratoFiltros Filtros { get; set; }
        public UspContratosInvestimentoItem(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new ContratoFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWContratosInvestimentoItem> L = new List<UVWContratosInvestimentoItem>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWContratosInvestimentoItem l = new UVWContratosInvestimentoItem();
                    l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                    l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                    l.Descricao = i["Descricao"].ToString();
                    l.ValorInvestimento = Convert.ToDouble(i["ValorInvestimento"].ToString());
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.EmbalagemCompra = i["EmbalagemCompra"].ToString();
                    l.EmbalagemCompraQtdeUnitaria = Convert.ToDouble(i["EmbalagemCompraQtdeUnitaria"].ToString());
                    l.TipoContrato = i["TipoContrato"].ToString();
                    l.DataInicio = Convert.ToDateTime(i["DataInicio"].ToString());
                    l.DataFim = Convert.ToDateTime(i["DataFim"].ToString());
                    L.Add(l);
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("SeqContrato", SqlDbType.VarChar, true, Filtros.SeqContrato));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspContratoInvestimentoItem";
        }

    }
    public class UVWContratosInvestimentoItem
    {
        public int SeqContrato { get; set; }
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string EmbalagemEstoque { get; set; }
        public double ValorInvestimento { get; set; }
        public string EmbalagemCompra { get; set; }
        public double EmbalagemCompraQtdeUnitaria { get; set; }
        public double EmbalagemCompraValorInvestimento
        {
            get
            {
                return Math.Round( this.EmbalagemCompraQtdeUnitaria * this.ValorInvestimento,2);
            }
         }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string TipoContrato { get; set; }

    }
}

