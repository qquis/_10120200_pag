using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;
using Pag_Net.Bll;

namespace Pag_Net.Bll.Comercial.PedidoCompra
{
    public class UspComercialPedidoCompra : Bll.USPDataContext
    {

        public ParametrosComercialPedidoCompra Parametros;
        public UspComercialPedidoCompra(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosComercialPedidoCompra();

        }

        public void Select()
        {
            List<UVWComercialPedidoCompra> L = new List<UVWComercialPedidoCompra>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWComercialPedidoCompra l = new UVWComercialPedidoCompra();

                l.NumeroPedido = Convert.ToInt32(i["NumeroPedido"]);
                l.CdParticipanteErp = Convert.ToInt32(i["CdParticipanteErp"]);
                l.NomeParticipante = i["NomeParticipante"].ToString();
                l.EnderecoParticipante = i["EnderecoParticipante"].ToString();
                l.BairroParticipante = i["BairroParticipante"].ToString();
                l.MunicipioParticipante = i["MunicipioParticipante"].ToString();
                l.EstadoParticipante = i["EstadoParticipante"].ToString();
                l.CepParticipante = i["CepParticipante"].ToString();
                l.TelefoneParticipante = i["TelefoneParticipante"].ToString();
                l.DataPedido = Convert.ToDateTime(i["DataPedido"]); 
                l.DataEntregaPedido = Convert.ToDateTime(i["DataEntregaPedido"]);
                l.ValorTotal = Convert.ToDouble(i["ValorTotal"]);
                l.CondicaoPagamento = i["CondicaoPagamento"].ToString();
                l.CdProduto = Convert.ToInt32(i["CdProduto"]);
                l.CdProdutoFabricante = Convert.ToInt32(i["CdProdutoFabricante"]);
                l.Descricao = i["Descricao"].ToString() ;
                l.EmbalagemCompra = i["EmbalagemCompra"].ToString(); 
                l.EmbalagemCompraQtde = Convert.ToDouble(i["EmbalagemCompraQtde"]);
                l.EmbalagemCompraQtdeBonificada = Convert.ToDouble(i["EmbalagemCompraQtdeBonificada"]);
                l.EmbalagemCompraQtdeUnitaria = Convert.ToDouble(i["EmbalagemCompraQtdeUnitaria"]);
                l.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"]);
                l.ValorUnitario = Convert.ToDouble(i["ValorUnitario"]);
                l.ValorIcmsSubstituicao  = Convert.ToDouble(i["ValorIcmsSubstituicao"]);
                l.ValorIpi = Convert.ToDouble(i["ValorIpi"]); 
                l.ValorDescontoAplicado = Convert.ToDouble(i["ValorDescontoAplicado"]); 
                l.ValorOriginal = Convert.ToDouble(i["ValorOriginal"]); 

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
            return "UspComercialPedidoCompra";
        }
    }

    public class UVWComercialPedidoCompra
    {
        public int      NumeroPedido { get; set; }
        public int      CdParticipanteErp { get; set; }
        public string   NomeParticipante { get; set; }
        public string   EnderecoParticipante { get; set; }
        public string   BairroParticipante { get; set; }
        public string   MunicipioParticipante { get; set; }
        public string   EstadoParticipante { get; set; }
        public string   CepParticipante { get; set; }
        public string   TelefoneParticipante { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntregaPedido { get; set; }
        public double   ValorTotal { get; set; }
        public string   CondicaoPagamento { get; set; }
        public int      CdProduto { get; set; }
        public int      CdProdutoFabricante { get; set; }
        public string   Descricao { get; set; }
        public string   EmbalagemCompra { get; set; }
        public double   EmbalagemCompraQtde { get; set; }
        public double   EmbalagemCompraQtdeBonificada { get; set; }
        public double   EmbalagemCompraQtdeUnitaria { get; set; }
        public double   EmbalagemEstoqueQtde { get; set; }
        public double   ValorUnitario { get; set; }
        public double   ValorIcmsSubstituicao { get; set; }
        public double   ValorIpi { get; set; }
        public double   ValorDescontoAplicado { get; set; }
        public double   ValorOriginal { get; set; }

    }

    public class ParametrosComercialPedidoCompra
    {
        public int NumeroPedido { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataFinal { get; set; }
        public string TipoRelatorio { get; set; }
    }
}
