using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceFaturamentoAgendamentoSimuladoInfoItem : Bll.USPDataContext
    {
        public ParametrosInterfaceFaturamentoAgendamentoSimuladoInfoItem Parametros;
        public UspInterfaceFaturamentoAgendamentoSimuladoInfoItem(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Parametros = new ParametrosInterfaceFaturamentoAgendamentoSimuladoInfoItem();
        }

        public void Select()
        {
            try
            {
                List<UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem> L = new List<UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem l = new UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem();

                        l.CdParticipanteVendedor  = Convert.ToInt32(i["CdParticipanteVendedor"].ToString().Trim());
                        l.CdParticipanteCliente = Convert.ToInt32(i["CdParticipanteCliente"].ToString().Trim());
                        l.CdVendedorERP  =  i["CdVendedorErp"].ToString().Trim();
                        l.CdClienteERP = i["CdClienteErp"].ToString().Trim();
                        l.NomeParticipanteCliente = i["NomeParticipanteCliente"].ToString().Trim();
                        l.NomeParticipanteVendedor = i["NomeParticipanteVendedor"].ToString().Trim();
                        l.SeqInterfaceInfo = Convert.ToInt32(i["SeqInterfaceInfo"].ToString().Trim());
                        l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString().Trim());
                        l.Descricao  = i["Descricao"].ToString().Trim();
                        l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString().Trim();
                        l.EmbalagemEstoqueQtde = Convert.ToDouble ( i["EmbalagemEstoqueQtde"].ToString().Trim());
                        l.DataFaturamento = Convert.ToDateTime(i["DataFaturamento"]);
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
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspInterfaceFaturamentoAgendamentoSimuladoInfoItem";
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
    }


    public class UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem
    {
        public int SeqInterfaceInfo {get;set;}
        public int SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem {get;set;}
        public DateTime DataFaturamento {get;set;}
        public int CdParticipanteVendedor {get;set;}
        public string CdVendedorERP { get; set; }
        public string NomeParticipanteVendedor {get;set;}
        public int CdParticipanteCliente {get;set;}
        public string CdClienteERP { get; set; }
        public string NomeParticipanteCliente {get;set;}
        public int CdProduto {get;set;}
        public string Descricao {get;set;}
        public string EmbalagemEstoque {get;set;}
        public double EmbalagemEstoqueQtde {get;set;}
        public double ValorTotalFaturamento {get;set;}

    }

    public class ParametrosInterfaceFaturamentoAgendamentoSimuladoInfoItem
    {
        public DateTime DataFaturamento { get; set; }
        public DateTime DataFaturamentoFinal { get; set; }
        public string ListaProduto { get; set; }
        public string Cdfabricante { get; set; }
        public bool DadosNovos { get; set; }
        public int SeqParticipanteVendedor {get; set;}
        public int SeqInterfaceInfo { get; set; }
    }
}
