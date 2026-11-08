using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;

namespace Pag_Net.Bll.Cadastros
{
    public class Produto
    {
        private Pag_Net.Models.modelSistemaUsuario _MyConnect;
        public string MenuFormProc { get; set; }

        public UspProdutoList List;
        public ProdutosComplementos Complementos;
        public UspProdutoGestor Gestor;
        public UspProdutoConteudo Conteudo;
        public UspProdutoEmbalagem Embalagens;
        public UspProdutoEmbalagemCodigoBarra CodigoBarra;
        public ProdutoCategoria Categoria;

        public Produto(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            _MyConnect = __myConnect;
            Complementos = new ProdutosComplementos(_MyConnect);
            Gestor = new UspProdutoGestor(_MyConnect);
            List = new UspProdutoList(_MyConnect);
            Conteudo = new UspProdutoConteudo(_MyConnect);
            Embalagens = new UspProdutoEmbalagem(_MyConnect);
            CodigoBarra = new UspProdutoEmbalagemCodigoBarra(_MyConnect);
            Categoria = new ProdutoCategoria(_MyConnect);
            

            
        }
    }
}
