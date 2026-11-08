using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9020_sistema_log
{
    public class _index : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbList_Sistema_Log; public DBDataTable dbList_Sistema_Log { get { return __dbList_Sistema_Log; } set { __dbList_Sistema_Log = value; RaisePropertyChanged("dbList_Sistema_Log"); } }
              
        Pag_Net.Models.modelSistemaUsuario MyConnect; 
       
        public _index (Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            
        }

        public void ConsultarLogs( int proc_log_seq,
                    int sis_nucleo_prc_cd,
                    string sis_log_tag,
                    string sis_log_info,
                    int sis_batch_run_seq,
                    DateTime DataInicial,
                    DateTime DataFinal,
                    string uuid_start
            
            )
        {
            try
            {
                
                dbList_Sistema_Log = pools.DBDataTables.SistemaLog(MyConnect, proc_log_seq,
                     sis_nucleo_prc_cd,
                     sis_log_tag,
                     sis_log_info,
                     sis_batch_run_seq,
                     DataInicial,
                     DataFinal,
                     uuid_start);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

    public static class pool
    {
        public static void GerarLog(Pag_Net.Models.modelSistemaUsuario MyConnect, 
                    int proc_log_seq, 
                    int sis_nucleo_prc_cd, 
                    string sis_log_tag, 
                    string sis_log_info, 
                    int sis_batch_run_seq 
            )
        {
            
            
            Pag_Net.src.F9020_sistema_log.model.modelsistema_log mySistemaLogModel = new model.modelsistema_log();
            mySistemaLogModel.proc_log_seq = proc_log_seq;
            mySistemaLogModel.sis_nucleo_prc_cd = sis_nucleo_prc_cd;
            mySistemaLogModel.sis_log_tag = sis_log_tag;
            mySistemaLogModel.sis_log_info = sis_log_info;
            mySistemaLogModel.sis_batch_run_seq = sis_batch_run_seq;
            mySistemaLogModel.modelGerarNovoLog(MyConnect);

        }
    }
}
