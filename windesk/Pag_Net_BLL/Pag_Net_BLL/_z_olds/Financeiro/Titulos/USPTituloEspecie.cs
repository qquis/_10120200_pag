using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Financeiro.Titulos
{
    public class USPTituloEspecie : Bll.USPDataContext
    {
        public USPTituloEspecie(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {

        }

        public void Select()
        {
            List<UVWTituloEspecie> L = new List<UVWTituloEspecie>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWTituloEspecie l = new UVWTituloEspecie();
                l.CdTituloEspecie = Convert.ToInt32(i["CdTituloEspecie"]);
                l.Descricao = i["Descricao"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspTituloEspecie";
        }
        public override object GetParametros()
        {
            return null;
        }

    }

    public class UVWTituloEspecie
    {
        public int CdTituloEspecie { get; set; }
        public string Descricao { get; set; }
    }
}
