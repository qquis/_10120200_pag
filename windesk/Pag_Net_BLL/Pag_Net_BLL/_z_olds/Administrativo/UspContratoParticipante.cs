using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;


namespace Pag_Net.Bll.Administrativo
{
    public class UspContratoParticipante : Bll.USPDataContext
    {
        public ParametroContratoParticipante Parametros;
        public UspContratoParticipante(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContratoParticipante();

        }

        public void Select()
        {
            List<UVWContratoParticipante> L = new List<UVWContratoParticipante>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContratoParticipante l = new UVWContratoParticipante();
                l.SeqTipoContratoParticipante = Convert.ToInt32(i["SeqTipoContratoParticipante"].ToString());
                l.TipoContratoPartipanteDescricao = i["TipoContratoPartipanteDescricao"].ToString();
                l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                l.CdParticipante = Convert.ToInt32(i["CdParticipante"].ToString());
                l.Nome = i["Nome"].ToString();
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
            return "UspContratoParticipante";
        }
    }

    public class UVWContratoParticipante
    {
        public int SeqContrato { get; set; }
        public int SeqTipoContratoParticipante { get; set; }
        public int CdParticipante { get; set; }
        public string TipoContratoPartipanteDescricao { get; set; }
        public string Nome { get; set; }
        
    }


    public class ParametroContratoParticipante
    {
        public int SeqContrato { get; set; }
        public int SeqTipoContratoParticipante { get; set; }
        public int CdParticipante { get; set; }
    }
}
