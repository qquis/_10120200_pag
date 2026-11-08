using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Comercial
{
    public class UspRepresentanteFabricanteList: Bll.USPDataContext
     {
        public RepresentanteFiltros Filtros { get; set; }
        public UspRepresentanteFabricanteList(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new RepresentanteFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWRepresentanteFabricanteList> L = new List<UVWRepresentanteFabricanteList>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWRepresentanteFabricanteList l = new UVWRepresentanteFabricanteList();
                    l.CdRepresentante = Convert.ToInt32(i["CdRepresentante"].ToString());
                    l.CdFabricante = i["CdFabricante"].ToString();
                    l.RepresentanteDescricao = i["RepresentanteDescricao"].ToString();
                    l.FabricanteDescricao = i["FabricanteDescricao"].ToString();

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
            return "UspRepresentanteFabricanteList";
        }

    }
    public class UVWRepresentanteFabricanteList
    {
        public int CdRepresentante { get; set; }			
        public string CdFabricante { get; set; }
        public string RepresentanteDescricao { get; set; }
        public string FabricanteDescricao { get; set; }
    }
}

