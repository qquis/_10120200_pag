using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Sistemas
{
    public class UspSistemaAcessos : Bll.USPDataContext
    {
        public ParametrosSistemaAcessos Parametros;
        public UspSistemaAcessos(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosSistemaAcessos();
        }
        public void Select()
        {
            List<UVWSistemaAcessos> L = new List<UVWSistemaAcessos>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWSistemaAcessos l = new UVWSistemaAcessos();
                l.Cd_Form_Proc = Convert.ToInt32(i["Cd_Form_Proc"].ToString());
                l.Cd_Funcao = Convert.ToInt32(i["Cd_Funcao"].ToString());
                l.Cd_Parametro = Convert.ToInt32(i["Cd_Parametro"].ToString());
                l.Cd_Tarefa = Convert.ToInt32(i["Cd_Tarefa"].ToString());
                l.DescricaoFormulario = i["DescricaoFormulario"].ToString();
                l.DescricaoFuncao = i["DescricaoFuncao"].ToString();
                l.DescricaoTarefa = i["DescricaoTarefa"].ToString();
                l.ParametroDescricao = i["ParametroDescricao"].ToString();
                l.Valor = i["Valor"].ToString();
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
            return "UspSistemaAcessos";
        }

        public override object GetParametros()
        {
            return this.Parametros;
        }
    }

    public class UVWSistemaAcessos
    {
        public int Cd_Funcao { get; set; }
        public string DescricaoFuncao { get; set; }
        public int Cd_Tarefa { get; set; }
        public string DescricaoTarefa { get; set; }
        public int Cd_Form_Proc { get; set; }
        public string DescricaoFormulario { get; set; }
        public int Cd_Parametro { get; set; }
        public string ParametroDescricao { get; set; }
        public string Valor { get; set; }
    }

    public class ParametrosSistemaAcessos
    {
        public int Cd_Form_Proc { get; set; }
        public int Cd_Tarefa { get; set; }
        public int Cd_Funcao { get; set; }
        public int Cd_Parametro { get; set; }
        public string Valor { get; set; }

    }
}
