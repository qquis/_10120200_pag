using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class TbRh_Setor_Operacional: Pag_Net.Bll.Tb
    {
        public int rh_setor_operacional_cd { get; set; }
        public string rh_setor_operacional_descricao { get; set; }
        //public int em_cdempresa { get; set; }
        //public int op_cdoperacao { get; set; }


        public TbRh_Setor_Operacional() 
        {

            _constructor();

        }

        public void _constructor()
        {

            this.rh_setor_operacional_cd = 0;
            this.rh_setor_operacional_descricao = "TIPO DE CONTRATO NÃO DEFINIDO";
            //this.em_cdempresa = 0;
            //this.op_cdoperacao = 0;
        }
        public override void __Binding(DataRow i)
        {

            rh_setor_operacional_cd = Convert.ToInt32(i["rh_setor_operacional_cd"].ToString());
            rh_setor_operacional_descricao = i["rh_setor_operacional_descricao"].ToString();
            //em_cdempresa = Convert.ToInt32(i["em_cdempresa"].ToString());
            //op_cdoperacao = Convert.ToInt32(i["op_cdoperacao"].ToString());
        }

    }
}
