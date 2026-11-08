using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;
using Pag_Net.Dal;

namespace Pag_Net.Bll.Administrativo
{
    public class UspContratos : Bll.USPDataContext
    {
        public ParametroContrato Parametros;
        public UspContratos (Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContrato();
        }

        public void Select()
        {
            List<UVWContrato> L = new List<UVWContrato>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContrato l = new UVWContrato();
                l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                l.CdEmpresa = Convert.ToInt32(i["CdEmpresa"].ToString());
                l.DataInicio = Convert.ToDateTime(i["DataInicio"].ToString());
                l.DataFim = Convert.ToDateTime(i["DataFim"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.DescricaoOperacao = i["DescricaoOperacao"].ToString();
                l.TipoContratoDescricao = i["TipoContratoDescricao"].ToString();
                l.SeqTipoContrato  = Convert.ToInt32(i["SeqTipoContrato"].ToString());
                l.Empresa  = i["Empresa"].ToString();
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
            return "UspContrato";
        }

   }

    public class ParametroContrato
    {

        public int CdOperacao { get; set; }
        public int SeqContrato { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int SeqTipoContrato { get; set; }

    }

    public class UVWContrato
    {
        public int CdOperacao { get; set; }
        public string DescricaoOperacao { get; set; }
        public int SeqContrato { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int SeqTipoContrato { get; set; }
        public string TipoContratoDescricao { get; set; }
        public int CdEmpresa { get; set; }
        public string Empresa { get; set; }
    }
}
