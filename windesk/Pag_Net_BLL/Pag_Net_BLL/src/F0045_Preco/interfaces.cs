using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0045_Preco.interfaces
{
    public class iFiltroPrecoListagem 
    {
        public int cdproduto { get; set; }
	    public int cdprodutobluesoft { get; set; }
	    public int seleciona_data_cadastro { get; set; }
	    public DateTime dt_cadastro_ini { get; set; }
	    public DateTime dt_cadastro_fim { get; set; }
	    public string descricao { get; set; }
	    public string descricao_fiscal { get; set; }
	    public int status_ativo { get; set; }
	    public int status_inativo { get; set; }
	    public int prd_cddepartamento { get; set; }
	    public int prs_cdsecao { get; set; }
	    public int prg_cdgrupo { get; set; }
	    public int prsg_cdsubgrupo { get; set; }
	    public int tab_pre_cd { get; set; }
	    public int unitario { get; set; }
	    public int proc_log_seq { get; set; }
	    public DateTime dt_agendamento_ini { get; set; }
        public DateTime dt_agendamento_fim { get; set; }
        public DateTime dt_data_aplicacao_ini { get; set; }
        public DateTime dt_data_aplicacao_fim { get; set; }
        public int ItensComPreco { get; set;  }

        public iFiltroPrecoListagem()
        {
            this.cdproduto = 0;
            this.cdprodutobluesoft = 0;
            this.seleciona_data_cadastro = 0;
            this.dt_cadastro_ini = Convert.ToDateTime("1900-01-01");
            this.dt_cadastro_fim = Convert.ToDateTime("1900-01-01");
            this.descricao = "";
            this.descricao_fiscal = "";
            this.status_ativo = 0;
            this.status_inativo = 0;
            this.prd_cddepartamento = 0;
            this.prg_cdgrupo = 0;
            this.prsg_cdsubgrupo = 0;
            this.tab_pre_cd = 0;
            this.unitario = 0;
            this.proc_log_seq = 0;
            this.dt_agendamento_ini = Convert.ToDateTime("1900-01-01");
            this.dt_agendamento_fim = Convert.ToDateTime("1900-01-01");
            this.ItensComPreco = 1;
        }
    }
}
