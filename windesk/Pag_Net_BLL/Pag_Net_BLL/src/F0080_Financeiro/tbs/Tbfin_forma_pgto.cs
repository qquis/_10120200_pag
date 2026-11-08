using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro.tbs
{
    public class TbFin_Forma_Pgto : Pag_Net.Bll.Tb
    {
        public int fin_forma_pgto_cd { get; set;  }
        public string fin_forma_pgto_descricao { get; set;  }

        public TbFin_Forma_Pgto()
        {
            fin_forma_pgto_cd = 0;
            fin_forma_pgto_descricao = "";
        }
        public TbFin_Forma_Pgto(int _fin_forma_pgto_cd)
        {
            fin_forma_pgto_cd = _fin_forma_pgto_cd;
            fin_forma_pgto_descricao = "-";
        }
		public TbFin_Forma_Pgto(DataRow i)
        {
            fin_forma_pgto_cd = Convert.ToInt32(i["fin_forma_pgto_cd"].ToString());
            fin_forma_pgto_descricao = i["fin_forma_pgto_descricao"].ToString();
        }
    }
}
