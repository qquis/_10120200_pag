using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0100_Resultado.interfaces
{

    public class Filter
    {
        public int notificacao_cd { get; set;  }
        public bool datavencimento_filter { get; set; }
        public DateTime datavencimento_filter_data_ini { get; set; }
        public DateTime datavencimento_filter_data_fim { get; set; }
        public string plc_descricao { get; set; }
        public string nome_razao { get; set; }
        public bool dataemissao_filter { get; set; }
        public DateTime dataemissao_filter_data_ini { get; set; }
        public DateTime dataemissao_filter_data_fim { get; set; }

        public int bluesoft_competencia_cd { get; set;  }
        public int competencia_cd { get; set; }
        public int plc_conta_cd {get; set;}
        public int contrato_bluesoft_seq { get; set; }
        public Boolean SemContaVinculada { get; set; }

        public Filter()
        {

            notificacao_cd = 0;
            datavencimento_filter = false;
            datavencimento_filter_data_ini = DateTime.Now;
            datavencimento_filter_data_fim = DateTime.Now;
            dataemissao_filter = false;
            dataemissao_filter_data_ini = DateTime.Now;
            dataemissao_filter_data_ini = DateTime.Now;
            competencia_cd = 0;
            bluesoft_competencia_cd = 0;
            plc_descricao = "";
            nome_razao = "";
            plc_conta_cd = 0;
            contrato_bluesoft_seq = 0;
            SemContaVinculada = false;



        }
    }
}
