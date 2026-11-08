using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class tbcontrole_status_pgto
    {
        public int controle_status_pgto_cd { get; set; }
        public string controle_status_pgto_descricao { get; set; }
        public int controle_cd { get; set; }

        public tbcontrole_status_pgto() { }
        
        public tbcontrole_status_pgto(
                int _controle_status_pgto_cd,
                string _controle_status_descricao,
                int _controle_cd
            )
        {
            this.controle_cd = _controle_cd;
            this.controle_status_pgto_cd = _controle_status_pgto_cd;
            this.controle_status_pgto_descricao = _controle_status_descricao;
        }

        public tbcontrole_status_pgto(DataRow i)
        {
            this.controle_cd = Convert.ToInt32(i["controle_cd"].ToString());
            this.controle_status_pgto_cd = Convert.ToInt32(i["controle_status_pgto_cd"].ToString());
            this.controle_status_pgto_descricao = i["controle_status_pgto_descricao"].ToString();
        }
    }
}

