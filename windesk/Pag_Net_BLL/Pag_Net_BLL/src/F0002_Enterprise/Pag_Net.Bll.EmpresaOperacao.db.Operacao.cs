using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0002_Enterprise;

namespace Pag_Net.Bll.F0002_Enterprise
{
    public class TbOperacao: TbEmpresa
    {
        public int      op_cdoperacao { get; set; }
        public string   op_descricao { get; set; }
   

        public TbOperacao()
        {
            
            op_cdoperacao = 0;
            op_descricao = "";


        }
        public TbOperacao(

            int      _op_cdoperacao,
            string   _op_descricao 

            )
        {
            op_cdoperacao   = _op_cdoperacao ;
            op_descricao    = _op_descricao;
           
        }

        public TbOperacao(DataRow i)
        {
           op_cdoperacao  = Convert.ToInt32(i["op_cdoperacao"]);
           op_descricao = i["op_descricao"].ToString();
           em_cdempresa = Convert.ToInt32(i["em_cdempresa"]);
           em_descricao = i["em_descricao"].ToString();


        }
    }
}

