using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Sistemas
{
    public class UspSistemaParametros : Bll.USPDataContext
    {
        
        public UspSistemaParametros(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            this.Select();
        }
        public void Select()
        {
            List<UVWSistemaParametros> L = new List<UVWSistemaParametros>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWSistemaParametros l = new UVWSistemaParametros();
                l.Cd_Parametro = Convert.ToInt32(i["Cd_Parametro"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.Observacao = i["Observacao"].ToString();
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
            return "UspSistemaParametros";
        }

        public override object GetParametros()
        {
            return null;
        }
    }

    public class UVWSistemaParametros
    {
        public int Cd_Parametro { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
    }
}
