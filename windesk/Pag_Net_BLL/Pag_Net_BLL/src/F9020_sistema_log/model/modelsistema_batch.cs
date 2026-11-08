using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9020_sistema_log.model
{
    public class modelsistema_log : tbs.tbsistema_log
    {
        public modelsistema_log() : base()
        {
            modelConstructor(); 
        }

        public void modelConstructor()
        {

        }

        public void modelGerarNovoLog(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                this._DBINSERT(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
