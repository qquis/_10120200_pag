using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0045_Preco.scripts
{
    public class f0045_50_Report_PrecoAgendamentoListagem 
    {
        public static string _VERSION() { return "f0045_51_1012003_report_precoagendamentolistagem"; }
        public static string Get(interfaces.iFiltroPrecoListagem filtro)
        {
            string SQL = "SELECT * " +
                             "FROM   " + scripts.f0045_50_Report_PrecoAgendamentoListagem._VERSION() + "(" +
                             "   vcdproduto:= " + filtro.cdproduto.ToString() +
                             " , vcdprodutobluesoft:= " + filtro.cdprodutobluesoft.ToString() +
                             " , vseleciona_data_cadastro:= " + filtro.seleciona_data_cadastro.ToString() +
                             " , vdt_cadastro_ini:= '" + filtro.dt_cadastro_ini.ToString("yyyy-MM-dd") + "'" +
                             " , vdt_cadastro_fim:= '" + filtro.dt_cadastro_fim.ToString("yyyy-MM-dd") + "'" +
                             " , vdescricao:= '" + filtro.descricao.ToString().Replace("'", "") + "'" +
                             " , vdescricao_fiscal:= '" + filtro.descricao_fiscal.ToString().Replace("'", "") + "'" +
                             " , vstatus_ativo:= " + filtro.status_ativo.ToString() +
                             " , vstatus_inativo:= " + filtro.status_inativo.ToString() +
                             " , vprd_cddepartamento:= " + filtro.prd_cddepartamento.ToString() +
                             " , vprs_cdsecao:= " + filtro.prs_cdsecao.ToString() +
                             " , vprg_cdgrupo:= " + filtro.prg_cdgrupo.ToString() +
                             " , vprsg_cdsubgrupo:= " + filtro.prsg_cdsubgrupo.ToString() +
                             " , vtab_pre_cd:= " + filtro.tab_pre_cd.ToString() +
                             " , vunitario:= " + filtro.unitario.ToString() +
                             " , vproc_log_seq:= " + filtro.proc_log_seq.ToString() +
                             " , vdt_agendamento_ini:= '" + filtro.dt_agendamento_ini.ToString("yyyy-MM-dd") + "'" +
                             " , vdt_agendamento_fim:= '" + filtro.dt_agendamento_fim.ToString("yyyy-MM-dd") + "'" +
                             "); ";
            return SQL; 
        }
    }
}
