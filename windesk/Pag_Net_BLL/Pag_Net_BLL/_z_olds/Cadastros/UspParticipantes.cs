using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class Participantes: Bll.USPDataContext
    {
        public Filtros Filtros;
        public Participantes(Models.modelSistemaUsuario _myConnect)
            :base(_myConnect)
        {
            Filtros = new Filtros();
            //this.Select();
        }

        public void Select()
        {
            List<UVWParticipantes> L = new List<UVWParticipantes>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWParticipantes x = new UVWParticipantes();
                x.CdParticipante = Convert.ToInt32(i["CdParticipante"]);
                x.Nome = i["Nome"].ToString();
                x.CdParticipanteErp = i["CdParticipanteERP"].ToString();
                //x.CdErpTipo = i["CdErpTipo"].ToString();
                L.Add(x);
            }
            base.ViewData = L.ToArray();
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("COMMAND", SqlDbType.VarChar, true, "SELECT"));
            ListParameters.Add(new Models.ParameterQuey("TIPO", SqlDbType.VarChar, true, Filtros.CdErpTipo));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "SP_PARTICIPANTE";
        }
    
    }

    public class UVWParticipantes
    {
        public int CdParticipante {get;set;}
        public string Nome {get;set;}
        public string CdParticipanteErp { get; set; }
        public string CdErpTipo { get; set; }
        public UVWParticipantes() {}
    }
}

  