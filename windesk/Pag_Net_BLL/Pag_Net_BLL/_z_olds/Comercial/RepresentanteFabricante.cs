using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Comercial
{
    public class RepresentanteFabricante
    {
        PrRepresentanteFabricante Dal;
        public UspRepresentanteFabricanteList List;
        public RepresentanteFabricante(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            List = new UspRepresentanteFabricanteList(__myConnect);
            Dal = new PrRepresentanteFabricante(__myConnect);
            
        }
        public void Insert(int __cdRepresentante, string __cdFabricante)
        {
            Dal.Insert(__cdRepresentante, __cdFabricante);
    
        }
        public void Delete(int __cdRepresentante, string __cdFabricante)
        {
            Dal.Delete(__cdRepresentante, __cdFabricante);

        }
    }
}
