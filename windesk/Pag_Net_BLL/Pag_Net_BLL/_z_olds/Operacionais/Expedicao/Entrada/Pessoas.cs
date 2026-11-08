using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Operacionais.Operacoes.Entrada
{
    class Pessoas: Pag_Net.Bll.Base.Pessoas
    {
        private Models.modelSistemaUsuario _MyConnect;
        public Pessoas(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            _MyConnect = _myConnect;
        }
        public override void Select()
        {
            base.List = Dal.DaPessoa.GetList(_MyConnect, Models.TbPessoas.TiposPessoa.Fornecedor, "", "", 0);
        }
    }
}
