using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9030_sistemabatch
{
    public class _index
    {



        Pag_Net.Models.modelSistemaUsuario MyConnect; 
        
        public model.modelsistema_batch MyBatch;
        public Pag_Net.src.F9030_sistemabatch.report.indexReport report;  
        
        
        public _index (Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            MyBatch = new model.modelsistema_batch();
            report = new report.indexReport(MyConnect);
        }
        public void NewRunFromBatch(int _sis_batch_cd, int _sis_batch_time_seq)
        {
            try
            {
                MyBatch.sis_batch_cd = _sis_batch_cd;
                MyBatch.sistema_batch_time.sis_batch_time_seq = _sis_batch_time_seq;
                MyBatch.modelNewRun(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
