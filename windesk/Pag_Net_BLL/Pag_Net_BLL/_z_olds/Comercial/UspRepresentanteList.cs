using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Comercial
{
    public class UspRepresentanteList: Bll.USPDataContext
     {
        public RepresentanteFiltros Filtros { get; set; }
        public UspRepresentanteList(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new RepresentanteFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWRepresentantes> L = new List<UVWRepresentantes>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWRepresentantes l = new UVWRepresentantes();
                    l.CdRepresentante = Convert.ToInt32( i["CdRepresentante"].ToString());
                    l.Descricao = i["Descricao"].ToString();
                    
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
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, Filtros.Descricao));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspRepresentanteList";
        }
     }
    public class UVWRepresentantes
    {
        public int CdRepresentante { get; set; }
        public string Descricao { get; set; }
    
    }
    public class RepresentanteFiltros
    {
        public int CdRepresentante { get; set; }
        public string Descricao { get; set; }
    }

}

