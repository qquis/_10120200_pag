using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class tbcontrole_status
    {
        public int controle_status_cd { get; set; }
        public string controle_status_descricao { get; set; }
        public int controle_cd { get; set; }
        public tbcontrole_status() { }
        public tbcontrole_status(
                int _controle_status_cd,
                string _controle_status_descricao,
                int _controle_cd
            )
        {
            this.controle_cd = _controle_cd;
            this.controle_status_cd = _controle_status_cd;
            this.controle_status_descricao = _controle_status_descricao;
        }
        public tbcontrole_status(DataRow i)
        {
            this.controle_cd = Convert.ToInt32(i["controle_cd"].ToString());
            this.controle_status_cd = Convert.ToInt32(i["controle_status_cd"].ToString());
            this.controle_status_descricao = i["controle_status_descricao"].ToString();
        }
    }
}
