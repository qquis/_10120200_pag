using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.src.F0070_Faturamento.Models;
namespace Pag_Net.src.F0070_Faturamento.reports
{

    public class rptFaturamentoTipoVisualizacao
    {
        public model_rpt_faturamentoTipoVisualizacao[] report;
        public int Count;
        public rptFaturamentoTipoVisualizacao() { }
    }
    public static class rptGeneratorFaturamentoTipoVisualizacao
    {
        public static rptFaturamentoTipoVisualizacao Get(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            rptFaturamentoTipoVisualizacao RPT = new rptFaturamentoTipoVisualizacao();
            try
            {
                List<model_rpt_faturamentoTipoVisualizacao> _faturamentoTipoVisualizacao = new List<model_rpt_faturamentoTipoVisualizacao>();
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(10, "Produto"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(11, "Sub Grupo"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(12, "Grupo"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(13, "Seção"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(14, "Departamento"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(15, "Fabricante"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(16, "Encarregado de Seção"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(20, "Vendedor"));
                //_faturamentoTipoVisualizacao.Add(new Wkdb_Faturamento_TipoVisualizacao(21, "Vendedor/Cliente"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(30, "Grupo Econômico"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(31, "Cliente"));
                //_faturamentoTipoVisualizacao.Add(new Wkdb_Faturamento_TipoVisualizacao(31, "Cliente/Endereço"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(90, "Empresa"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(91, "Empresa/Operação"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(100, "Mês/Ano"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(101, "Data"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(110, "ECF"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(115, "Cupom Fiscal"));
                _faturamentoTipoVisualizacao.Add(new model_rpt_faturamentoTipoVisualizacao(120, "Pedido de Venda"));
                RPT.report = _faturamentoTipoVisualizacao.ToArray();
                return RPT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static string sql(int faturamento_consolidado)
        {
           return "";
        }


    }
}
