
using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace Pag_Net.Bll.F0138_Recurso_Ctrl
{

    public class Wk: Pag_Net.Bll.F0130_Controle.iWK_Controle
    {

        public Model_RecursoCtrl[] List;
        public Model_RecursoCtrl Recurso_Ctrl;

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
            : base(_MyConnect, 12)
        {
            MyConnect = _MyConnect;
            Recurso_Ctrl = new Model_RecursoCtrl();
        }
    }
    

    
}
