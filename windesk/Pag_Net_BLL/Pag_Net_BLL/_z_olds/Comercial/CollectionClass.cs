using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Comercial
{
    public class CollectionClass
    {
        public Pag_Net.Bll.Comercial.Contrato Contratos;
        public Pag_Net.Bll.Comercial.Representante Representante;
        public Pag_Net.Bll.Comercial.RepresentanteParticipante RepresentanteParticipante;
        public Pag_Net.Bll.Comercial.RepresentanteFabricante RepresentanteFabricantes;
        public Pag_Net.Bll.Cadastros.Gerais Cadastros;
        public Pag_Net.Bll.Comercial.Interface.CollectionClass Interface;
        public CollectionClass(Models.modelSistemaUsuario __myConnect)
        {
            Contratos = new Contrato(__myConnect);
            Representante = new Representante(__myConnect);
            RepresentanteParticipante = new RepresentanteParticipante(__myConnect);
            RepresentanteFabricantes = new RepresentanteFabricante(__myConnect);
            Interface = new Interface.CollectionClass(__myConnect);
            Cadastros = new Cadastros.Gerais(__myConnect);
        }
    }
}

