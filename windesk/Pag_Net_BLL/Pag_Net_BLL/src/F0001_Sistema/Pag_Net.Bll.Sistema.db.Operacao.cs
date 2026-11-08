using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0001_Sistema
{
    public class tboperacao
    {
        public int      op_cdoperacao { get; set; }
        public string   op_descricao { get; set; }
   

        public tboperacao()
        {
            
            op_cdoperacao = 0;
            op_descricao = "";


        }
        public tboperacao(

            int      _op_cdoperacao,
            string   _op_descricao 

            )
        {
            op_cdoperacao   = _op_cdoperacao ;
            op_descricao    = _op_descricao;
           
        }

        public tboperacao(DataRow i)
        {
           op_cdoperacao  = Convert.ToInt32(i["op_cdoperacao"]);
           op_descricao = i["op_descricao"].ToString();

        }
    }
}

