using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class USPEmpresa : Bll.USPDataContext
    {
        public ParametrosEmpresa Parametros;
        public USPEmpresa(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosEmpresa();
            Select();
        }
        public void Select()
        {
            List<UVWEmpresa> L = new List<UVWEmpresa>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWEmpresa l = new UVWEmpresa();
                l.CdEmpresa  = Convert.ToInt32(i["CdEmpresa"].ToString());
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
            return "UspEmpresa";
        }

        public override object GetParametros()
        {
            return this.Parametros;
        }
    }

    public class ParametrosEmpresa
    {
        public int CdEmpresa { get; set; }

    }

    public class UVWEmpresa
    {
        public int CdEmpresa { get; set; }
        public string Descricao { get; set;  }
        public string DescricaoResumida { get; set; }

    }
}
