using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceFaturamentoInfoDadosConsolidados : Bll.USPDataContext
    {
        public InterfaceFaturamentoInfoDadosConsolidadosFiltros Filtros { get; set; }
        public UspInterfaceFaturamentoInfoDadosConsolidados(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new InterfaceFaturamentoInfoDadosConsolidadosFiltros();
        }
            public void Select()
        {
            try
            {
                List<UVWInterfaceFaturamentoInfoDadosConsolidados> L = new List<UVWInterfaceFaturamentoInfoDadosConsolidados>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceFaturamentoInfoDadosConsolidados l = new UVWInterfaceFaturamentoInfoDadosConsolidados();

                        l.SeqInterfaceInfo  = Convert.ToInt32(i["SEQINTERFACEINFO"].ToString());
                        l.Positivacao   = Convert.ToInt32(i["POSITIVACAO"].ToString());
                        l.Faturamento    = Convert.ToDouble(i["FATURAMENTO"].ToString());
                        l.Volume    = Convert.ToDouble(i["VOLUME"].ToString());
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

            return ListParameters.ToArray();
            //return null;
        }
        public override string SQLCommnad()
        {
            return "UspInterfaceFaturamentoInfoDadosConsolidados";
        }
    }
    public class UVWInterfaceFaturamentoInfoDadosConsolidados
    {
        public int SeqInterfaceInfo { get; set; }
        public int Positivacao {get;set;}
        public double Faturamento {get;set;}
        public double Volume {get;set;}

    }
    public class InterfaceFaturamentoInfoDadosConsolidadosFiltros
    {
        public int SeqInterfaceInfo  {get;set;}
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }


    }
    
}


