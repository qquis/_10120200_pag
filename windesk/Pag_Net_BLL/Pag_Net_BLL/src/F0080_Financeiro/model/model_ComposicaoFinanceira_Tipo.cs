using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro.model
{
    public class model_ComposicaoFinanceira_Tipo
    {
        public string descricao { get; set; }
        public int tipoconsulta_cd { get; set; }
        public model_ComposicaoFinanceira_Tipo(int _TipoConsulta_Cd, string _Descricao)
        {
            descricao = _Descricao;
            tipoconsulta_cd = _TipoConsulta_Cd;
        }

    }
}
