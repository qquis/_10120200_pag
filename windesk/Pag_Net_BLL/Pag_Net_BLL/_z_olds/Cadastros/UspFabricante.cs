using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class Fabricante: Bll.USPDataContext
    {
        public Fabricante(Models.modelSistemaUsuario _myConnect)
            :base(_myConnect)
        {
            this.Select();
        }

        public void Select()
        {
            List<UVWFabricante> L = new List<UVWFabricante>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWFabricante l = new UVWFabricante();
                l.CdFabricante  = i["CdFabricante"].ToString();
                l.Descricao = i["Descricao"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();

        }

        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspFabricante";
        }



      
    }

    public class UVWFabricante
    {
        public string CdFabricante {get;set;}
        public string Descricao {get;set;}
        public UVWFabricante() { }

    }
}

  