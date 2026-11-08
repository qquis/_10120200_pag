using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Comercial
{
    public class RepresentanteParticipante
    {
        PrRepresentanteParticipante Dal;
        public UspRepresentanteParticipanteList List;
        public RepresentanteParticipante(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            List = new UspRepresentanteParticipanteList(__myConnect);
            Dal = new PrRepresentanteParticipante(__myConnect);
            
        }
        public void Insert(int __cdRepresentante, int __cdParticipante)
        {
            Dal.Insert(__cdRepresentante, __cdParticipante);
    
        }
        public void Delete(int __cdRepresentante, int __cdParticipante)
        {
            Dal.Delete(__cdRepresentante,__cdParticipante);

        }
    }
}
