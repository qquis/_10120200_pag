using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Sistemas
{
    public class UspSistemaFormulario: Bll.USPDataContext
    {
        public ParametrosSistemaFormulario Parametros;
        public UspSistemaFormulario(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosSistemaFormulario();
        }
        public void Select()
        {
            List<UVWSistemaFormulario> L = new List<UVWSistemaFormulario>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWSistemaFormulario l = new UVWSistemaFormulario();
                l.Cd_Form_Proc = Convert.ToInt32(i["Cd_Form_Proc"].ToString());
                l.Descricao= i["Descricao"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            //List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            //ListParameters.Add(new Models.ParameterQuey("SeqProdutoCategoria", SqlDbType.Int, true, this.Parametros.SeqProdutoCategoria));
            //return ListParameters.ToArray();
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspSistemaFormulario";
        }

        public override object GetParametros()
        {
            return this.Parametros;
        }
    }

    public class UVWSistemaFormulario
    {
      
        public int Cd_Form_Proc { get; set; }
        public string Descricao { get; set; }
      
    }

    public class ParametrosSistemaFormulario
    {

        public string Descricao { get; set; }

    }


}
