using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models.ModeloBase
{
    public class TbStatusProdutoPreco
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Cadastro { get; set; }
        public string CodigoBarra { get; set; }
        public string Unidade { get; set; }
        public double PrecoOn { get; set; }
        public double PrecoOx { get; set; }
        public double PrecoZanthus { get; set; }
        public string Situacao { get; set; }
        public double EstoqueAtual { get; set; }

        public TbStatusProdutoPreco() { }

        public TbStatusProdutoPreco
            (int codigo,
            string descricao,
            DateTime cadastro,
            string codigobarra,
            string unidade,
            double precoon,
            double precoox,
            double precozanthus,
            string situacao)
        {
            Codigo = codigo;
            Descricao = descricao;
            Cadastro = cadastro;
            CodigoBarra = codigobarra;
            Unidade = unidade;
            PrecoOn = precoon;
            PrecoOx = precoox;
            PrecoZanthus = precozanthus;
            Situacao = situacao;
        }
    }
}
