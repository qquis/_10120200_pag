using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Pag_Net.Bll.Operacionais.Operacoes.Entrada
{
    public class NotasFiscais : Pag_Net.Bll.Base.NotasFiscais
    {
        public FiltrosNotasFiscais Filtros { get; set; }

        private Models.modelSistemaUsuario _MyConnect;
        public NotasFiscais(Models.modelSistemaUsuario _myConnect) : base(_myConnect)
        {
            _MyConnect = _myConnect;
            Filtros = new FiltrosNotasFiscais();

        }
        public override void Select()
        {
            Lista = Pag_Net.Dal.DaNotasFiscais.Select(_MyConnect, Filtros.DataInicial,Filtros.DataFinal, Filtros.CodigoFornecedor, null,Filtros.CheckSimBonificadas, Filtros.CheckNaoBonificadas, Convert.ToDouble( Filtros.ValorInicial ), Convert.ToDouble( Filtros.ValorFinal ), Filtros.NumerosNotasFiscais);
        }

    }

}
