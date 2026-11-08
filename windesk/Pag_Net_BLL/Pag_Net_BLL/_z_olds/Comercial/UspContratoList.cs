using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;


namespace Pag_Net.Bll.Comercial
{

    public class UspContratoList : Bll.USPDataContext
     {
        public ContratoFiltros Filtros { get; set; }
        public UspContratoList(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new ContratoFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWContratos> L = new List<UVWContratos>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWContratos l = new UVWContratos();
                        l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                        l.Descricao = i["Descricao"].ToString();
                        l.CdTipoContrato = i["CdTipoContrato"].ToString();
                        l.TipoContrato = i["TipoContrato"].ToString();
                        l.DataLancamento = Convert.ToDateTime(i["DataLancamento"].ToString());
                        l.DataInicio = Convert.ToDateTime(i["DataInicio"].ToString());
                        l.DataFim = Convert.ToDateTime(i["DataFim"].ToString());
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
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, Filtros.Descricao));
            ListParameters.Add(new Models.ParameterQuey("DATALANCAMENTOINICIAL", SqlDbType.DateTime, true, Filtros.DataLancamentoInicial));
            ListParameters.Add(new Models.ParameterQuey("DATALANCAMENTOFINAL", SqlDbType.DateTime, true, Filtros.DataLancamentoFinal));
            ListParameters.Add(new Models.ParameterQuey("DATAVALIDADEINICIAL", SqlDbType.DateTime, true, Filtros.DataValidadeInicial));
            ListParameters.Add(new Models.ParameterQuey("DATAVALIDADEFINAL", SqlDbType.DateTime, true, Filtros.DataValidadeFinal));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspContratoList";
        }

    }
    public class UVWContratos
    {
        public int SeqContrato { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string TipoContrato { get; set; }
        public string Observacao { get; set; }
        public string CdTipoContrato { get; set; }

    }
    public class ContratoFiltros
    {
        public string Descricao { get; set; }
        public int SeqContrato { get; set; }
        public DateTime DataValidadeInicial { get; set; }
        public DateTime DataValidadeFinal { get; set; }

        public DateTime DataLancamentoInicial { get; set; }
        public DateTime DataLancamentoFinal { get; set; }
    }
}
