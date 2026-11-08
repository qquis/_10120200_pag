using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0100_Resultado.tbs
{
    public class tbresultado_conta
    {
        public int r_grupo_cd {get; set;}
        public int r_conta_cd { get; set; }
        public string r_conta_descricao { get; set; }
        public int r_conta_lancamento_manual { get; set; }
        public int debitocredito { get; set; }
        public int r_rateio_cd { get; set; }
        public int r_grupo_origem_blue { get; set;  }
        public string r_grupo_descricao { get; set;  }
        public string LOCAL_DESC_GRUPO
        {
            get
            {
                return this.r_grupo_descricao + " - " + this.r_conta_descricao;
            }
        }
        public tbresultado_conta() {}

        public void binding (DataRow i) 
        {
            this.r_grupo_cd = Convert.ToInt32(i["r_grupo_cd"]);
            this.r_conta_cd = Convert.ToInt32(i["r_conta_cd"]);
            this.r_conta_lancamento_manual = Convert.ToInt32(i["r_conta_lancamento_manual"]);
            this.r_conta_descricao = i["r_conta_descricao"].ToString();
            this.r_grupo_descricao = i["r_grupo_descricao"].ToString();
            this.debitocredito = Convert.ToInt32(i["debitocredito"]);
            this.r_rateio_cd = Convert.ToInt32(i["r_rateio_cd"]);
            this.r_grupo_origem_blue = Convert.ToInt32(i["r_grupo_origem_blue"]);
        }
    }
}
