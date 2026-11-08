using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Operacionais.Operacoes.Entrada
{
    public class Entrada
    {
        public NotasFiscais NotasFiscais { get; set; }
        public NotasFiscaisItem NotasFiscaisItem { get; set; }
        public Models.TbPessoas[] Fornecedores { get; set; }
        public Models.ModeloBase.TbNotasFiscais NotaFiscalSelecionada { get; set; }

        public Entrada(Models.modelSistemaUsuario _myConnect)
        {
            NotasFiscaisItem = new NotasFiscaisItem(_myConnect);
            NotasFiscais = new NotasFiscais(_myConnect);
            Pessoas objfornecedores = new Pessoas(_myConnect);
            objfornecedores.Select();
            Fornecedores = objfornecedores.List;
        }
    }
}
