using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.F001001
{
    public static class Postgres
    {
        public static int getKey(
                 Pag_Net.Models.modelSistemaUsuario MyConnect
               , DateTime FileData
               , string FileName


           )
        {

            try
            {

                int SEQ_ARQUIVO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 200101);

                string SQL_POSTGRE = string.Format("SELECT xproc_log_seq FROM f001101_processo_log_arquivo({0}, '{1}', '{2}' )",
                                                        SEQ_ARQUIVO.ToString()
                                                      , FileData.ToString("yyyy-MM-dd")
                                                      , FileName
                                                      );

                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return Convert.ToInt32(DX.Tables[0].Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F001001 | ERRO: " + ex.Message);
            }

        }

    
    }
}

