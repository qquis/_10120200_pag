using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0002_Enterprise;

namespace Pag_Net.Bll.F0002_Enterprise
{
    public class TbEmpresa
    {
        public int em_cdempresa { get; set; }
        public string em_descricao { get; set; }


        public TbEmpresa()
        {

            em_cdempresa = 0;
            em_descricao = "";


        }
        public TbEmpresa(

            int _em_cdempresa, 
            string _em_descricao

            )
        {
            em_cdempresa = _em_cdempresa;
            em_descricao = _em_descricao;

        }

        public TbEmpresa(DataRow i)
        {
            em_cdempresa = Convert.ToInt32(i["op_cdoperacao"]);
            em_descricao = i["op_descricao"].ToString();

        }
    }
}

