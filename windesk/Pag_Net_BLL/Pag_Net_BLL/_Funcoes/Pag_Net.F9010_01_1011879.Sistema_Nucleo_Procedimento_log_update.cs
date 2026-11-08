using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll;


namespace Pag_Net.Bll.F9010_01
{
    public static class RedShift
    {
        public static string get(
            DateTime data_inicial, 
            DateTime data_final
            )
        {

            return null;
        }
    }

    public static class Postgre
    {
  
        public static string Post(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
				string _SqlCommand,
				bool _Api ,
                Pag_Net.Bll.F9010_01.Db _db
            )
        {

            try
            {
                string _sql_post = string.Format(  "SELECT " +
                                                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F9010_01_sistema_log) + 
                                                   "   (  "+
                                                   "              {0}         " +
                                                   "          ,   {1}         " +
                                                   "          ,   {2}         " +
                                                   "          ,  '{3}'        " + 
                                                   "          ,  '{4}'        )",
                                              _db.sis_log_seq           
                                            , _db.proc_log_seq          
						                    , _db.sis_nucleo_prc_cd     
                                            , _db.sis_log_tag
                                            , _db.sis_log_info          
                                            );

                return _sql_post;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    
    }

    public class Db
    {

   		public int      sis_log_seq             {get;set; }
        public int      proc_log_seq            {get;set; }
        public int      sis_nucleo_prc_cd       {get;set; }
		public string   sis_log_tag	            {get;set; }
        public string   sis_log_info            {get;set; }

        public Db(
                     
                        int _sis_log_seq,
                        int _proc_log_seq,
                        int _sis_nucleo_prc_cd, 
                        string _sis_log_tag,    
                        string _sis_log_info      
            )
        {
            sis_log_seq = _sis_log_seq;
            proc_log_seq = _proc_log_seq;
            sis_nucleo_prc_cd = _sis_nucleo_prc_cd;
            sis_log_tag = _sis_log_tag.Length > 60 ? _sis_log_tag.Substring(0, 59) : _sis_log_tag;
            sis_log_info = _sis_log_info.Length > 120 ? _sis_log_info.Substring(0, 119) : _sis_log_info;
        }

        public Db(DataRow i)
        {
            string _error_publish_dataRow = "";
            try
            {
                _error_publish_dataRow = "Publish field sis_log_seq"; sis_log_seq = Convert.ToInt32(i["sis_log_seq"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Class {0}\x0A Command: {1} - Error: {2}", "Pag_Net.Bll.F9010_01(DataRow i)\x0A", _error_publish_dataRow, ex.Message));
            }
        }
    }
}








