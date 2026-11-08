using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class UspRegistroProdutosConsolidados: Bll.USPDataContext
    {
        public DateTime DataLancamentoInicial { get; set; }
        public DateTime DataLancamentoFinal { get; set; }
        public UspRegistroProdutosConsolidados(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {

        }
        public void Select()
        {
            try
            {
                List<UVWRegistroProdutosConsolidados> L = new List<UVWRegistroProdutosConsolidados>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWRegistroProdutosConsolidados l = new UVWRegistroProdutosConsolidados();
                    l.DataLancamento = Convert.ToDateTime(i["DataLancamento"]);
                    l.DataRegistro = Convert.ToDateTime(i["DataRegistro"]);
                    l.SequencialErp = Convert.ToInt32(i["SequencialErp"]);
                    l.SeqTipoRegistro = Convert.ToInt32(i["SeqTipoRegistro"]);
                    l.Descricao = i["Descricao"].ToString();
                    l.Itens = Convert.ToInt32 ( i["Itens"].ToString());
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
            ListParameters.Add(new Models.ParameterQuey("DataLancamentoInicial", SqlDbType.DateTime , true, this.DataLancamentoInicial ));
            ListParameters.Add(new Models.ParameterQuey("DataLancamentoFinal", SqlDbType.DateTime, true, this.DataLancamentoFinal));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspRegistroProdutosConsolidados";
        }
    }
    public class UVWRegistroProdutosConsolidados
    {
        public DateTime DataRegistro { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Descricao { get; set; }
        public int Itens { get; set; }
        public int SequencialErp { get; set; }
        public int SeqTipoRegistro { get; set; }
    }
}


