using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Comercial
{
    public class Contrato
    {
        public UspContratoList List;
        public UspContratosInvestimentoItem ListInvestimentoItens;
        public Contrato(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            List = new UspContratoList(__myConnect);
            ListInvestimentoItens = new UspContratosInvestimentoItem(__myConnect);
            
        }

    }
}
