using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Comercial
{
    public class UspRepresentanteParticipanteList: Bll.USPDataContext
     {
        public RepresentanteFiltros Filtros { get; set; }
        public UspRepresentanteParticipanteList(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new RepresentanteFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWRepresentanteParticipanteList> L = new List<UVWRepresentanteParticipanteList>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWRepresentanteParticipanteList l = new UVWRepresentanteParticipanteList();
                    l.CdRepresentante = Convert.ToInt32(i["CdRepresentante"].ToString());
                    l.CdParticipante = Convert.ToInt32(i["CdParticipante"].ToString());
                    l.RepresentanteDescricao = i["RepresentanteDescricao"].ToString();
                    l.ParticipanteNome = i["ParticipanteNome"].ToString();
                    l.ParticipanteDocumento = i["ParticipanteDocumento"].ToString();
                    
                    L.Add(l);
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
            ListParameters.Add(new Models.ParameterQuey("CdRepresentante", SqlDbType.VarChar, true, Filtros.CdRepresentante));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspRepresentanteParticipanteList";
        }
    }
    public class UVWRepresentanteParticipanteList
    {
        public int CdRepresentante { get; set; }			
        public int CdParticipante { get; set; }
        public string RepresentanteDescricao { get; set; }
        public string ParticipanteNome { get; set; }
        public string ParticipanteDocumento { get; set; }
    
    }
}