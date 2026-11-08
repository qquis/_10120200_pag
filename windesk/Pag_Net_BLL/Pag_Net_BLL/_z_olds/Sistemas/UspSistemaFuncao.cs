using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Sistemas
{
    public class UspSistemaFuncao : Bll.USPDataContext
    {

        public UspSistemaFuncao(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            this.Select();
        }
        public void Select()
        {
            List<UVWSistemaFuncao> L = new List<UVWSistemaFuncao>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWSistemaFuncao l = new UVWSistemaFuncao();
                l.Cd_funcao = Convert.ToInt32(i["Cd_funcao"].ToString());
                l.Descricao = i["Descricao"].ToString();
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
            return "UspSistemaFuncao";
        }

        public override object GetParametros()
        {
            return null;
        }
    }

    public class UVWSistemaFuncao
    {

        public int Cd_funcao { get; set; }
        public string Descricao { get; set; }

    }



}
