using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class Registros
    {
        public UspRegistroProdutoPendentes Pendentes;
        public UspRegistroProdutosConsolidados Consolidados;
        public UspRegistroProdutosConsolidadosItem ItensConsolidados;
        public Registros(modelSistemaUsuario __myConnect)
        {
            Pendentes = new UspRegistroProdutoPendentes(__myConnect);
            Consolidados = new UspRegistroProdutosConsolidados(__myConnect);
            ItensConsolidados = new UspRegistroProdutosConsolidadosItem(__myConnect);
        }
    }
}
