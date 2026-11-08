using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9030_sistemabatch.scriptspg
{
    public static class f9030_60_sistema_batch_runs_list {
        public static string _VERSION() { return "f9030_01_1012001_sistema_batch_run_crud"; } 
        public static string _SELECT(interfaces.iFilter FILTER) {  
            try { 

                string SQL = string.Format("SELECT * FROM " + _VERSION() + "(" + 
                        "    vsis_batch_cd:= " + FILTER.sis_batch_cd.ToString() +  
                        " ,  vsis_batch_run_status_cd:= " + FILTER.sis_batch_run_status_cd.ToString() + 
                        " ,  vsis_batch_run_seq:= " + FILTER.sis_batch_run_seq.ToString() + 
                         ")"
                   ); 
                return SQL; 
            
            }

            catch (Exception ex) {
                throw new Exception(ex.Message); 
            }
            
        }
        public static DBDataTable DBDataTableGet(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iFilter FILTER)
        {
            try
            {
                return new DBDataTable(BDCommand.get_DataTable(MyConnect, _SELECT(FILTER)));
            }
            catch (Exception ex) {
                throw new Exception(ex.Message); 
            }
        }
    }
}
