using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models.ModeloBase;
using Pag_Net.Models;

namespace Pag_Net.Bll.Sistemas.Operacoes.Interface
{
    public class Zanthus
    {
        public Pag_Net.Bll.Sistemas.Operacoes.Interface.StatusProdutoPrecoComercial StatusProdutoPrecoComercial { get; set; }
        public Pag_Net.Bll.Sistemas.Operacoes.Interface.StatusProdutoPrecoServidores StatusProdutoPrecoServidores { get; set; }
        public Zanthus(modelSistemaUsuario _myConnect)
        {
            StatusProdutoPrecoComercial = new StatusProdutoPrecoComercial(_myConnect);
            StatusProdutoPrecoServidores = new StatusProdutoPrecoServidores(_myConnect);
        }
    }
}
