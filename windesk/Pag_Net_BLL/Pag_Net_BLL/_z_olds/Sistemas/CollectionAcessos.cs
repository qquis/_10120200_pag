using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.Sistemas
{
    public class CollectionAcesso
    {
        public UspSistemaAcessos Acessos;
        public UspSistemaFormulario Formularios;
        public UspSistemaParametros Parametros;
        public UspSistemaTarefa Tarefas;
        public UspSistemaFuncao Funcao;
        

        public CollectionAcesso (Models.modelSistemaUsuario __myConnect)
        {
            Formularios = new UspSistemaFormulario(__myConnect);
            Acessos = new UspSistemaAcessos(__myConnect);
            Parametros = new UspSistemaParametros(__myConnect);
            Tarefas = new UspSistemaTarefa(__myConnect);
            Funcao = new UspSistemaFuncao(__myConnect);

        }
    }
}
