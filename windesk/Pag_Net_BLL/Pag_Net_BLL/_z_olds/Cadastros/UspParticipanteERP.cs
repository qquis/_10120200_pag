using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspParticipanteERP : Bll.USPDataContext
    {
        public ParametrosParticipanteERP Parametros;
        public UspParticipanteERP(Models.modelSistemaUsuario __myconnect)
            : base(__myconnect)
        {
            Parametros = new ParametrosParticipanteERP();
        }

        public void Select()
        {
            List<UVWParticipanteERP> L = new List<UVWParticipanteERP>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWParticipanteERP x = new UVWParticipanteERP();
                x.Seq = Convert.ToInt32(i["Seq"]);
                x.CdParticipanteERP = i["CdParticipanteERP"].ToString();
                x.CdErpTipo = i["CdErpTipo"].ToString();
                x.StatusParticipanteERP = i["StatusParticipanteERP"].ToString();
                L.Add(x);
            }
            base.ViewData = L.ToArray();
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
        public override string SQLCommnad()
        {
            return "UspParticipanteERP";
        }

 
    }
    public class ParametrosParticipanteERP
    {
        public int CdParticipante { get; set; }
    }
    public class UVWParticipanteERP
    {
        public int Seq { get; set; }
        public string CdErpTipo { get; set; }
        public string CdParticipanteERP { get; set; }
        public string StatusParticipanteERP { get; set; }

    }

}
