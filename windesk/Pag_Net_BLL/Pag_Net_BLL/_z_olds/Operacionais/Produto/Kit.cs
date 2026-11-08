using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class Kit
    {
        public Pag_Net.Bll.Cadastros.Produto Cadastros;
        public Pag_Net.Bll.Operacionais.Produto.UspProdutoPrecoAdministracao Administracao;
        public Pag_Net.Bll.Operacionais.Produto.UspProdutoPrecoList PrecoList;
        public Pag_Net.Bll.Cadastros.Fabricante Fabricantes;

        public Kit(Models.modelSistemaUsuario __myConnect)
        {
            Cadastros = new Bll.Cadastros.Produto(__myConnect);
            Administracao = new Bll.Operacionais.Produto.UspProdutoPrecoAdministracao(__myConnect);
            PrecoList = new UspProdutoPrecoList(__myConnect);
            Fabricantes = new Cadastros.Fabricante(__myConnect);
            
        }


    }
}
