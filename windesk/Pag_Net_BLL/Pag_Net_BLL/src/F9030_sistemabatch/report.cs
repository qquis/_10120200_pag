using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9030_sistemabatch.report
{

    public class indexReport
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        /*Class */
        public indexReport(Pag_Net.Models.modelSistemaUsuario myConnect) { _constructor(myConnect); }

        /*Events */
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /*Reports */
        private DBDataTable __dbList_Sistema_Batch_Service; public DBDataTable dbList_Sistema_Batch_Service { get { return __dbList_Sistema_Batch_Service; } set { __dbList_Sistema_Batch_Service = value; RaisePropertyChanged("dbList_Sistema_Batch_Service"); } }
        private DBDataTable __dbList_Sistema_Batch_Service_Shedule; public DBDataTable dbList_Sistema_Batch_Service_Shedule { get { return __dbList_Sistema_Batch_Service_Shedule; } set { __dbList_Sistema_Batch_Service_Shedule = value; RaisePropertyChanged("dbList_Sistema_Batch_Service_Shedule"); } }
        private DBDataTable __dbList_Sistema_Batch; public DBDataTable dbList_Sistema_Batch { get { return __dbList_Sistema_Batch; } set { __dbList_Sistema_Batch = value; RaisePropertyChanged("dbList_Sistema_Batch"); } }
        private DBDataTable __dbList_Sistema_BatchTimes; public DBDataTable dbList_Sistema_BatchTimes { get { return __dbList_Sistema_BatchTimes; } set { __dbList_Sistema_BatchTimes = value; RaisePropertyChanged("dbList_Sistema_BatchTimes"); } }
        private DBDataTable __dbList_Sistema_Batch_Run; public DBDataTable dbList_Sistema_Batch_Run { get { return __dbList_Sistema_Batch_Run; } set { __dbList_Sistema_Batch_Run = value; RaisePropertyChanged("dbList_Sistema_Batch_Run"); } }


        public void _constructor(Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
        }

        public void ConsultarBatchService(int sis_batch_service_Cd)
        {
            try
            {
                dbList_Sistema_Batch_Service = DBDataTables.SistemaBatchService(MyConnect, sis_batch_service_Cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarBatchServiceShedules(int sis_batch_service_Cd)
        {
            try
            {
                dbList_Sistema_Batch_Service_Shedule = DBDataTables.SistemaBatchServiceShedule(MyConnect, sis_batch_service_Cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarBatch(int sis_batch_cd)
        {
            try
            {
                dbList_Sistema_Batch = DBDataTables.SistemaBatch(MyConnect, sis_batch_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarBatchTimes(int sis_batch_service_Cd)
        {
            try
            {
                dbList_Sistema_BatchTimes = DBDataTables.SistemaBatchTimes(MyConnect, sis_batch_service_Cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarBatchRun(int sis_batch_service_Cd, int sis_batch_cd, int sis_batch_run_seq)
        {
            try
            {
                dbList_Sistema_Batch_Run = DBDataTables.SistemaBatchRun(MyConnect, sis_batch_service_Cd, sis_batch_cd, sis_batch_run_seq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }




    public static class ArrayTabs
    {
        public static model.modelsistema_batch[] sistemaPathRunsList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iFilter FILTER)
        {
            try
            {
                List<model.modelsistema_batch> myListModel = new List<model.modelsistema_batch>();

                DBDataTable myDataTableModel = scriptspg.f9030_60_sistema_batch_runs_list.DBDataTableGet(MyConnect, FILTER);

                foreach (DataRow i in myDataTableModel.List.Rows)
                {
                    model.modelsistema_batch item = new model.modelsistema_batch();
                    item.modelDataBinding(i);
                    myListModel.Add(item);
                }
                return myListModel.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception("Dts.F0011_Participante Error \n " + ex.Message);
            }
        } 

    }

    public static class DBDataTables
    {
        public static DBDataTable SistemaBatchService(Pag_Net.Models.modelSistemaUsuario MyConnect, int sis_batch_service_Cd)
        {
            try
            {
                string SQL = " SELECT S.sis_batch_service_cd  " +
                             "      , S.sis_batch_service_descricao " +
                             "      , S.sis_batch_service_ult_run_date " +
                             "      , S.sis_batch_service_ult_run_host " +
                             "      , si.shedule_ult_insert " +
                             "      , si.shedules_status_on_count " + 
                             "      , si.shedules_status_off_count " + 
                             "      , bh.sis_batch_cd_count " + 
                             "      , br.sis_batch_run_status_cd_10 " + 
                             "      , br.sis_batch_run_status_cd_20 " + 
                             "      , br.sis_batch_run_status_cd_20_ult " + 
                             "      , br.sis_batch_run_status_cd_30 " +
                             "      , br.sis_batch_run_status_cd_90 " +
                             "      , br.sis_batch_run_status_cd_99 " + 
                             " FROM   tbsistema_batch_service S " + 
                             " LEFT JOIN  (  Select sx.sis_batch_service_cd  " +
                             "                    , max(sx.dtlog_insert) as shedule_ult_insert " +
                             "                    , count(distinct(case when sis_batch_service_run_status_shedule = 1 then sis_batch_service_run_seq else null end )) as shedules_status_on_count " +
                             "                    , count(distinct(case when sis_batch_service_run_status_shedule = 0 then sis_batch_service_run_seq else null end )) as shedules_status_off_count " + 
                             "               FROM   tbsistema_batch_service_run sx " + 
                             "               GROUP BY sx.sis_batch_service_cd ) si on si.sis_batch_service_cd  = s.sis_batch_service_cd  " + 
                             " LEFT JOIN (   Select    sx.sis_batch_service_cd " + 
                             "                     ,   count(distinct(sx.sis_batch_cd)) as sis_batch_cd_count " + 
                             "               FROM      tbsistema_batch sx " + 
                             "               GROUP BY  sx.sis_batch_service_cd " + 
                             "           ) bh ON bh.sis_batch_service_cd = S.sis_batch_service_cd" +
                             " LEFT JOIN (   Select    sxa.sis_batch_service_cd " + 
                             "                     ,   count(distinct(case when sis_batch_run_status_cd = 10 then sis_batch_run_seq else null end)) as sis_batch_run_status_cd_10 " +
                             "                     ,   count(distinct(case when sis_batch_run_status_cd = 20 then sis_batch_run_seq else null end)) as sis_batch_run_status_cd_20 " +
                             "                     ,   max(case when sis_batch_run_status_cd = 20 then sis_batch_run_dtlog_start else null end) as sis_batch_run_status_cd_20_ult " + 
                             "                     ,   count(distinct(case when sis_batch_run_status_cd = 30 then sis_batch_run_seq else null end)) as sis_batch_run_status_cd_30 " +
                             "                     ,   count(distinct(case when sis_batch_run_status_cd = 99 then sis_batch_run_seq else null end)) as sis_batch_run_status_cd_99 " +
                             "                     ,   count(distinct(case when sis_batch_run_status_cd = 90 then sis_batch_run_seq else null end)) as sis_batch_run_status_cd_90 " + 
                             "               FROM      tbsistema_batch_run sx " +
                             "               INNER JOIN tbsistema_batch sxa on sxa.sis_batch_cd = sx.sis_batch_cd " +
                             "               GROUP BY  sxa.sis_batch_service_cd " +
                             "           ) br on br.sis_batch_service_cd = s.sis_batch_service_cd  " +
                             " WHERE 1 = 1 " +
                             (sis_batch_service_Cd != 0 ? " AND   s.sis_batch_service_cd = " + sis_batch_service_Cd.ToString() : "").ToString() +
                             " ORDER BY S.sis_batch_service_descricao  ";
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable SistemaBatchServiceShedule(Pag_Net.Models.modelSistemaUsuario MyConnect, int sis_batch_service_cd )
        {
            try
            {
                string SQL = " SELECT       R.sis_batch_service_run_seq  " +
                             "      ,       R.sis_batch_service_cd " +
                             "      ,       R.sis_batch_service_run_status_shedule " +
                             "      ,       S.sis_batch_service_descricao " + 
                             "      ,       r.dtlog_insert " + 
                             " FROM         tbsistema_batch_service_run R " + 
                             " INNER JOIN   tbsistema_batch_service     S ON S.sis_batch_service_cd = R.sis_batch_service_cd " +
                             " WHERE 1 = 1 " + 
                             (sis_batch_service_cd.ToString() != "" ? " AND   s.sis_batch_service_cd = " + sis_batch_service_cd.ToString(): "").ToString() +
                             " ORDER BY     r.dtlog_insert DESC  ";
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable SistemaBatch(Pag_Net.Models.modelSistemaUsuario MyConnect, int sis_batch_cd)
        {
            try
            {
                string SQL = "  select  sb.sis_batch_cd             " +
                             "      ,   sb.sis_batch_descricao      " +
                             "      ,   sb.sis_batch_status         " +
                             "      ,   sb.sis_batch_service_cd     " +
                             "      ,   sb.module_cd                " +
                             "  from    tbsistema_batch sb          " +
                             " WHERE 1 = 1 " +
                             (sis_batch_cd.ToString() != "" ? " AND   sb.sis_batch_cd = " + sis_batch_cd.ToString() : "").ToString() +
                             "  order by sb.sis_batch_descricao     ";
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable SistemaBatchTimes(Pag_Net.Models.modelSistemaUsuario MyConnect, int sis_batch_service_cd)
        {
            try
            {
                string SQL = " SELECT       B.sis_batch_cd  " + 
                             "           ,  B.sis_batch_descricao " + 
                             "           ,  B.sis_batch_status " + 
                             "           ,  B.sis_batch_service_cd " + 
                             "           ,  S.sis_batch_service_descricao " + 
                             "           ,  T.sis_batch_recorrencia_cd " + 
                             "           ,  T.sis_batch_dt_ini " +
                             "           ,  T.sis_batch_dt_fim " +
                             "           ,  T.sis_batch_hm_ini " +
                             "           ,  T.sis_batch_hm_fim " +
                             "           ,  T.sis_batch_wk_ini " +
                             "           ,  T.sis_batch_wk_fim " + 
                             "           ,  T.sis_batch_time_seq " + 
                             " FROM         tbsistema_batch B " +
                             " INNER JOIN   tbsistema_batch_time     T ON T.sis_batch_cd = B.sis_batch_cd  " +
                             " INNER JOIN   tbsistema_batch_service  S ON S.sis_batch_service_cd = B.sis_batch_service_cd " +
                             " WHERE 1 = 1 " +
                             (sis_batch_service_cd.ToString() != "" ? " AND   s.sis_batch_service_cd = " + sis_batch_service_cd.ToString() : "").ToString() +
                             " ORDER BY     S.sis_batch_service_descricao  ";
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable SistemaBatchRun(Pag_Net.Models.modelSistemaUsuario MyConnect, int sis_batch_service_cd, int sis_batch_cd, int sis_batch_run_seq )
        {
            try
            {
                string SQL = " SELECT       R.dtlog_insert " + 
                             "           ,  R.dtlog_update " + 
                             "           ,  R.sis_batch_cd  " +
                             "           ,  b.sis_batch_descricao " + 
                             "           ,  R.sis_batch_run_seq " +
                             "           ,  R.sis_batch_run_status_cd " + 
                             "           ,  ST.sis_batch_run_status_descricao " + 
                             "           ,  R.sis_batch_run_dtlog_start " + 
                             "           ,  R.sis_batch_run_dtlog_end " +
                             "          ,   COALESCE(R.sis_batch_time_seq,0) as sis_batch_time_seq " + 
                             " FROM         tbsistema_batch_run      R " + 
                             " INNER JOIN   tbsistema_batch_run_status ST ON ST.sis_batch_run_status_cd = R.sis_batch_run_status_cd " + 
                             " INNER JOIN   tbsistema_batch          B  ON B.sis_batch_cd = R.sis_batch_cd " +
                             " INNER JOIN   tbsistema_batch_time     T ON T.sis_batch_cd = B.sis_batch_cd and T.sis_batch_time_seq = R.sis_batch_time_seq" +
                             " INNER JOIN   tbsistema_batch_service  S ON S.sis_batch_service_cd = B.sis_batch_service_cd " +
                             " WHERE 1 = 1 " +
                             (sis_batch_service_cd  != 0 ? " AND   s.sis_batch_service_cd = " + sis_batch_service_cd.ToString() : "").ToString() +
                             (sis_batch_cd != 0 ? " AND   r.sis_batch_cd = " + sis_batch_cd.ToString() : "").ToString() +
                             (sis_batch_run_seq != 0 ? " AND   r.sis_batch_run_seq = " + sis_batch_run_seq.ToString() : "").ToString() +
                             " ORDER BY     R.dtlog_insert desc  ";
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
