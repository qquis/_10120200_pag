using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Sistemas
{
    public class UspSistemaTarefa : Bll.USPDataContext
    {
        public ParametrosSistemaTarefas Parametros;
        public UspSistemaTarefa(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosSistemaTarefas();
        }
        public void Select()
        {
            List<UVWSistemaTarefas> L = new List<UVWSistemaTarefas>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWSistemaTarefas l = new UVWSistemaTarefas();
                l.Cd_Form_Proc = Convert.ToInt32(i["Cd_Form_Proc"].ToString());
                l.Cd_tarefa = Convert.ToInt32(i["Cd_tarefa"].ToString());
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
            return "UspSistemaTarefas";
        }

        public override object GetParametros()
        {
            return this.Parametros;
        }
    }

    public class UVWSistemaTarefas
    {

        public int Cd_Form_Proc { get; set; }
        public int Cd_tarefa { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }

    }

    public class ParametrosSistemaTarefas
    {

        public int Cd_Form_Proc { get; set; }

    }

}
