using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.ComponentModel;


namespace Pag_Net.Bll.Operacionais.Operacoes.Entrada
{
    public class NotasFiscaisItem: Pag_Net.Bll.Base.NotasFiscaisItem
    {
        #region Property
        public FiltrosNotasFiscaisItem Filtros { get; set; }
        #endregion

        #region Varieble
        public Models.modelSistemaUsuario _MyConnect;
        #endregion

        #region Constructor
        public NotasFiscaisItem(modelSistemaUsuario _myConnect): base(_myConnect)
        {
            _MyConnect = _myConnect;
            this.Filtros = new FiltrosNotasFiscaisItem();
        }
        #endregion

        #region Methodos Publics
        public override void Select()
        {
            this.Lista = Pag_Net.Dal.DaNotasFiscaisItem.Select(_MyConnect, Filtros.DataInicial, Filtros.DataFinal,Filtros.NumeroNotaFiscal, Filtros.CodigoFornecedor);
        }
        #endregion

    }
}
