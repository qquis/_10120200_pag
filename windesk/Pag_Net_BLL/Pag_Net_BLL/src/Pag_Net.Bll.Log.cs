using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll
{
    public static class Log
    {

        public static void register(Pag_Net.Models.modelSistemaUsuario MyConnect, int sis_nucleo_prc_cd, string tag_info, string info)
        {
            try
            {
                DbUpdate BDExecute_log = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                register(MyConnect, BDExecute_log, sis_nucleo_prc_cd, tag_info, info);
                BDExecute_log.Dispose();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        
        public static void register(Pag_Net.Models.modelSistemaUsuario MyConnect, DbUpdate BDExecute, int sis_nucleo_prc_cd, string info)
        {
            try
            {
                //string __log_control_insert = Pag_Net.Bll.F9010_01.Postgre.Post(MyConnect, "DBINSERT", false, new F9010_01.Db(0,MyConnect.SEQUENCIAL_DE_PROCESSO, sis_nucleo_prc_cd, "", info));
                //BDExecute.Execute(__log_control_insert, null, DataBaseName.ODBCOXAN);
                register(MyConnect, BDExecute, sis_nucleo_prc_cd, "", info);
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        

        public static void register(Pag_Net.Models.modelSistemaUsuario MyConnect, DbUpdate BDExecute, int sis_nucleo_prc_cd, string tag_info, string info)
        {
            try
            {

                if (info.Length > 120)
                    info = info.Substring(0, 120);

                info = info.Replace("error", "ERROR");
                info = info.Replace("Error", "ERROR");
                info = info.Replace("Erro", "ERROR");
                info = info.Replace("ERRO", "ERROR");
                string __log_control_insert = Pag_Net.Bll.F9010_01.Postgre.Post(MyConnect, "DBINSERT", false, new F9010_01.Db(0, MyConnect.SEQUENCIAL_DE_PROCESSO, sis_nucleo_prc_cd, tag_info.Replace("'",""), info.Replace("'","")));
                BDExecute.Execute(__log_control_insert, null, DataBaseName.ODBCOXAN);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    
    }



}
