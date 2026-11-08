using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;


namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class UspFCCInterfaceProdutoFinanceiro : Bll.USPDataContext
    {

        public UspFCCInterfaceProdutoFinanceiro(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            this.Select();
        }
        public void Select()
        {

            List<VWFCCInterfaceProdutoFinanceiro> L = new List<VWFCCInterfaceProdutoFinanceiro>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                VWFCCInterfaceProdutoFinanceiro l = new VWFCCInterfaceProdutoFinanceiro();
                l.SeqSitefLogInterfaceProdutoFinanceiro = Convert.ToInt32(i["SeqSitefLogInterfaceProdutoFinanceiro"].ToString());
                l.DescricaoProdutoFinanceiroInterface = i["DescricaoProdutoFinanceiroInterface"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspFCCInterfaceProdutoFinanceiro";
        }

    }

    public class VWFCCInterfaceProdutoFinanceiro
    {
        public int SeqSitefLogInterfaceProdutoFinanceiro { get; set; }
        public string DescricaoProdutoFinanceiroInterface { get; set; }
    }
}
