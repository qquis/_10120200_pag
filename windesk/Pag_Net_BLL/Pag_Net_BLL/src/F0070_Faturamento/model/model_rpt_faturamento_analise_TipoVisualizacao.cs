using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.Models
{
    public class model_rpt_faturamentoTipoVisualizacao
    {
        public int FaturamentoTipoVisualizacao { get; set; }
        public string FaturamentoTipoVisualizacaoDescricao { get; set; }

        public model_rpt_faturamentoTipoVisualizacao()
        {
            FaturamentoTipoVisualizacao = 0;
            FaturamentoTipoVisualizacaoDescricao = "";

        }
        public model_rpt_faturamentoTipoVisualizacao(
            int _FaturamentoTipoVisualizacao,
            string _FaturamentoTipoVisualizacaoDescricao
            )
        {
            FaturamentoTipoVisualizacao = _FaturamentoTipoVisualizacao;
            FaturamentoTipoVisualizacaoDescricao = _FaturamentoTipoVisualizacaoDescricao;
        }
    }
}
