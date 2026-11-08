using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Pag_Net.Bll;
using Pag_Net.Models;
using Pag_Net.Dal;

namespace Pag_Net.Bll.Sistemas.Operacoes.Interface
{
    public class StatusProdutoPrecoComercial: Pag_Net.Bll.Base.StatusProdutoPreco
    {
        private Models.modelSistemaUsuario _MyConnect;
        public StatusProdutoPrecoComercial(modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            _MyConnect = _myConnect;
        }

        public override void Select()
        {
            base.Lista = Dal.DaStatusProdutoPreco.GetList(_MyConnect, DaStatusProdutoPreco.TipoProcessamento.StatusErp);
        }
    }
}
