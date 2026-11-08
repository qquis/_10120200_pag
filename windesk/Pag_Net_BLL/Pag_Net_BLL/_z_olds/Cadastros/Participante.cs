using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;


namespace Pag_Net.Bll.Cadastros
{
    
    public class Participante
    {
        public UVWParticipante Informacoes;
        public UVWParticipanteEndereco[] Enderecos;
        public UVWParticipanteERP[] ERP;
        public UVWParticipanteEmpresa[] Empresas;
        
        public Participante(modelSistemaUsuario __myConnect, int __cdParticipante)
        {
            Informacoes = new UVWParticipante();

            UspParticipante Uparticipante = new UspParticipante(__myConnect);
            Uparticipante.Parametros.CdParticipante = __cdParticipante;
            Uparticipante.Select();
            Informacoes = (UVWParticipante)Uparticipante.ViewData[0];

            UspParticipanteEndereco UParticipanteEndereco = new UspParticipanteEndereco(__myConnect);
            UParticipanteEndereco.Parametros.CdParticipante = __cdParticipante;
            UParticipanteEndereco.Select();
            Enderecos = (UVWParticipanteEndereco[])UParticipanteEndereco.ViewData;


            UspParticipanteERP UParticipanteERP = new UspParticipanteERP(__myConnect);
            UParticipanteERP.Parametros.CdParticipante = __cdParticipante;
            UParticipanteERP.Select();
            ERP = (UVWParticipanteERP[])UParticipanteERP.ViewData;

            UspParticipanteEmpresa UEmpresas = new UspParticipanteEmpresa(__myConnect);
            UEmpresas.Parametros.CdParticipante = __cdParticipante;
            UEmpresas.Select();
            Empresas = (UVWParticipanteEmpresa[])UEmpresas.ViewData;


        }


    }
}
