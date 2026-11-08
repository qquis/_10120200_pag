using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro.interfaces
{
    public class iFiltroConsultaAutorizacao
    {
        public int TipoConsulta_Cd { get; set; }
        public int competencia { get; set; }
        public string autpgto_tipo { get; set; }
        public int autpgto_seq_pk { get; set; }
        public int plc_conta_cd { get; set; }
        public int plc_conta_cd_destino { get; set; }
        public bool filtra_dataemissao { get; set; }
        public DateTime autpgto_dataemissao_ini { get; set; }
        public DateTime autpgto_dataemissao_fim { get; set; }
        public bool filtra_datavencimento { get; set; }
        public DateTime autpgto_datavencimento_ini { get; set; }
        public DateTime autpgto_datavencimento_fim { get; set; }
        public bool filtra_datapagamento { get; set; }
        public DateTime autpgto_datapagamento_ini { get; set; }
        public DateTime autpgto_datapagamento_fim { get; set; }
        public int cdpessoabluesoft { get; set; }
        public int autpgto_cancelada { get; set; }
        public iFiltroConsultaAutorizacao()
        {
            competencia = 0;
            TipoConsulta_Cd = 0;
            autpgto_tipo = "";
            autpgto_seq_pk = 0;
            plc_conta_cd = 0;
            plc_conta_cd_destino = 0;
            filtra_dataemissao = false;
            filtra_datavencimento = false;
            filtra_datapagamento = false;
            autpgto_dataemissao_ini = Convert.ToDateTime("1900-01-01");
            autpgto_dataemissao_fim = Convert.ToDateTime("1900-01-01");
            autpgto_datavencimento_ini = Convert.ToDateTime("1900-01-01");
            autpgto_datavencimento_fim = Convert.ToDateTime("1900-01-01");
            autpgto_datapagamento_ini = Convert.ToDateTime("1900-01-01");
            autpgto_datapagamento_fim = Convert.ToDateTime("1900-01-01");
        }
    }
}
