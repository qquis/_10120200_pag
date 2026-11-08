using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Comercial
{
    public class Representante
    {
        PrRepresentante Dal;
        public UspRepresentanteList List;
        public Representante(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            List = new UspRepresentanteList(__myConnect);
            Dal = new PrRepresentante(__myConnect);
            
        }
        public void Insert(string __descricaoRepresentante)
        {
            Dal.Insert(__descricaoRepresentante);
    
        }
        public void Delete( string __descricaoRepresentante)
        {
            Dal.Delete( __descricaoRepresentante);

        }
    }
}
