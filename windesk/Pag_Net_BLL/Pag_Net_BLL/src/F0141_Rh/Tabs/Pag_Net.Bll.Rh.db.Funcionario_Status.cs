using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class TbRhFuncionarioStatus
    {
        public int rh_funcionario_status_cd { get; set;  }
        public string rh_funcionario_status_descricao { get; set;  }


        public TbRhFuncionarioStatus() 
        {

            this.rh_funcionario_status_cd = 0;
            this.rh_funcionario_status_descricao = "STATUS NÃO DEFINIDO";

        }
        public TbRhFuncionarioStatus(

            int      _rh_funcionario_status_cd,
            string   _rh_funcionario_status_descricao 

            ) 
        {
            rh_funcionario_status_cd = _rh_funcionario_status_cd;
            rh_funcionario_status_descricao = _rh_funcionario_status_descricao; 

        }

        public TbRhFuncionarioStatus(DataRow i)
        {

             rh_funcionario_status_cd = Convert.ToInt32(i["rh_funcionario_status_cd"].ToString());
             rh_funcionario_status_descricao = i["rh_funcionario_status_descricao"].ToString();
        }

    }
}
