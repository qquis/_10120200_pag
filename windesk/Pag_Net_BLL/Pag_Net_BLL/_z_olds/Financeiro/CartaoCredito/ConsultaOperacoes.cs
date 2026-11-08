using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class ConsultaOperacoes
    {
        public Pag_Net.Bll.Financeiro.CartaoCredito.FinalizadorasRegistradas FinalizadorasRegistradas; //UspCCCFinalizadorasRegistradas.cs
        public Pag_Net.Bll.Financeiro.CartaoCredito.OperacoesRegistradas OperacoesRegistradas; //UspCCCOperacoesRegistradas.cs

        public ConsultaOperacoes(Models.modelSistemaUsuario _myConnect)
        {
            FinalizadorasRegistradas = new Bll.Financeiro.CartaoCredito.FinalizadorasRegistradas(_myConnect);
            OperacoesRegistradas = new Bll.Financeiro.CartaoCredito.OperacoesRegistradas(_myConnect);

        }

        public void Select()
        {
            FinalizadorasRegistradas.Select();
            OperacoesRegistradas.Select();

        }


    }
}
