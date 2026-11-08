using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;



namespace Pag_Net.Bll.Operacionais.Produto
{
    public class UspRegistroProdutosConsolidadosItem: Bll.USPDataContext
    {
        public DateTime DataLancamento { get; set; }
        public DateTime DataRegistro { get; set; }
        public int SeqTipoRegistro { get; set; }
        
        public UspRegistroProdutosConsolidadosItem(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {

        }
        public void Select()
        {
            try
            {
                List<UVWRegistroProdutosConsolidadosItem> L = new List<UVWRegistroProdutosConsolidadosItem>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWRegistroProdutosConsolidadosItem l = new UVWRegistroProdutosConsolidadosItem();
                    l.SeqRegistroProduto = Convert.ToInt32(i["SeqRegistroProduto"]);
                    l.DataLancamento = Convert.ToDateTime(i["DataLancamento"]);
                    l.DataRegistro = Convert.ToDateTime(i["DataRegistro"]);
                    l.SequencialERP = Convert.ToInt32(i["SequencialErp"]);
                    l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                    l.Descricao = i["Descricao"].ToString();
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"].ToString());
                    l.ValorCustoPadrao = Convert.ToDouble(i["ValorCustoPadrao"].ToString());


                    L.Add(l);
                    index = index + 1;
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
            ListParameters.Add(new Models.ParameterQuey("DataLancamento", SqlDbType.DateTime , true, this.DataLancamento  ));
            ListParameters.Add(new Models.ParameterQuey("DataRegistro", SqlDbType.DateTime, true, this.DataRegistro ));
            ListParameters.Add(new Models.ParameterQuey("SeqTipoRegistro", SqlDbType.Int, true, this.SeqTipoRegistro ));

            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspRegistroProdutosConsolidadosItem";
        }
    }

    public class UVWRegistroProdutosConsolidadosItem: mdoVwRegistroProduto 
    {
        public string TipoRegistro { get; set; }
        public string Descricao { get; set; }

        

    }
}
