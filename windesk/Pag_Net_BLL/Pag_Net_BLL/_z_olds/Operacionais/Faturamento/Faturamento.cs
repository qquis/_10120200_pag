using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll; 
using Pag_Net.Models;

namespace Pag_Net.Bll.Operacionais.Faturamento
{
    public class Collection
    {
        public UspFaturamentoDocumentos Documentos;
        public Collection(Models.modelSistemaUsuario __myConnect)
        {
            Documentos = new UspFaturamentoDocumentos(__myConnect);
        }
    }
}
