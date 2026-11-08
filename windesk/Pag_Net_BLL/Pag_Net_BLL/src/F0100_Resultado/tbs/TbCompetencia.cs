using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0100_Resultado.tbs
{
    public class TbCompetencia
    {
        public int competencia_cd { get; set;  }
        public int competencia_ano { get; set;  }
        public int competencia_mes { get; set;  }
        public DateTime competencia_data_ini { get; set; }
        public DateTime competencia_data_fim { get; set;  }
        public string competencia_descricao { get; set;  }
        public TbCompetencia()
        {
            competencia_cd = 0;
            competencia_ano = 0;
            competencia_mes = 0;
            competencia_data_ini = Convert.ToDateTime("1900-01-01");
            competencia_data_fim = Convert.ToDateTime("1900-01-01"); 
            competencia_descricao =  "Definir Competência";

        }
        public TbCompetencia(DataRow i)
        {
            competencia_cd = Convert.ToInt32(i["competencia_cd"].ToString());
            competencia_ano = Convert.ToInt32(i["competencia_ano"].ToString());
            competencia_mes = Convert.ToInt32(i["competencia_mes"].ToString());
            competencia_data_ini = Convert.ToDateTime(i["competencia_data_ini"].ToString());
            competencia_data_fim = Convert.ToDateTime(i["competencia_data_fim"].ToString());
            competencia_descricao = i["competencia_descricao"].ToString();

        }
    }
}
