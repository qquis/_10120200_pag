using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9020_sistema_log.pools
{
    public static class ArrayTabs
    {
       

    }

    public static class DBDataTables
    {
        public static DBDataTable SistemaLog(Pag_Net.Models.modelSistemaUsuario MyConnect,
                    int proc_log_seq,
                    int sis_nucleo_prc_cd,
                    string sis_log_tag,
                    string sis_log_info,
                    int sis_batch_run_seq,  
                    DateTime _DataInicial,
                    DateTime _DataFinal , 
                    string _uuid_start 
            )
        {
            try
            {
                string SQL = " SELECT   l.dtlog_insert " +  
                             "        , l.sis_log_seq " + 
                             "        , l.proc_log_seq " + 
                             "        , l.sis_nucleo_prc_cd " +
                             "        , l.sis_log_tag " + 
                             "        , l.sis_log_info " + 
                             "        , l.sis_batch_run_seq " + 
                             "        , l.uuid " +
                             "        , coalesce(l.uuid_start,'') as uuid_start " + 
                             " FROM     tbsistema_log l " + 
                             " WHERE 1 = 1 " +
                             "   AND l.dtlog_insert >= '" + _DataInicial.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "'" + 
                             "   AND l.dtlog_insert <= '" + _DataFinal.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "'" +  
                             (proc_log_seq != 0 ? " AND   l.proc_log_seq = " + proc_log_seq.ToString() : "").ToString() +
                             (sis_nucleo_prc_cd != 0 ? " AND   l.sis_nucleo_prc_cd = " + sis_nucleo_prc_cd.ToString() : "").ToString() +
                             (sis_log_tag != "" ? " AND   l.sis_log_tag like '%" + sis_log_tag.Replace("'", "").ToString() + "%'": "").ToString() +
                             (sis_log_info != "" ? " AND   l.sis_log_info like '%" + sis_log_info.Replace("'", "").ToString() + "%'" : "").ToString() +
                             (sis_batch_run_seq != 0 ? " AND   l.sis_batch_run_seq  = " + sis_batch_run_seq.ToString() : "").ToString() +
                             (_uuid_start != "" ? " AND   l.uuid_start  like '%" + _uuid_start.ToString() + "%'" : "").ToString() +
                             " ORDER BY l.sis_log_seq desc ";
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
