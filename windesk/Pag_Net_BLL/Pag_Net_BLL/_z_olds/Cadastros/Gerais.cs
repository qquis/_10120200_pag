using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace Pag_Net.Bll.Cadastros
{
    public class Gerais
    {
        public Pag_Net.Bll.Cadastros.Fabricante Fabricante;
        public Pag_Net.Bll.Cadastros.ProdutosComplementos ProdutosComplementos;
        public Pag_Net.Bll.Cadastros.UspOperacoes Operacoes;
        public Pag_Net.Bll.Cadastros.Participantes Vendedores;
        public Pag_Net.Bll.Cadastros.UspProdutoGestor Gestor;
        public Pag_Net.Bll.Cadastros.ProdutoCategoria Categoria;
        public Gerais(Models.modelSistemaUsuario _myConnect)
        {
            Fabricante = new Fabricante(_myConnect);
            ProdutosComplementos = new ProdutosComplementos(_myConnect);
            Operacoes = new UspOperacoes(_myConnect);
            Vendedores = new Participantes(_myConnect);
            Gestor = new UspProdutoGestor(_myConnect);
            Categoria = new ProdutoCategoria(_myConnect);
            Vendedores.Filtros.CdErpTipo = "VENDEDOR";
            Vendedores.Select();
        }
    }
}
