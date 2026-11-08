using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Tools.CryptPassWord;
using Pag_Net.Tools;
using Pag_Net.Services;

namespace Pag_Net.Services.Bll.TEMP
{
    public static class ProdutoBlueSoft_Embalagem
    {
        public static void Update (Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {


            string SQL_POSTGRE = " select 	    prb_cdprodutobluesoft " +
                                 "           , 	prbg_cdbarra_pk  " +
                                 "           ,	prbg_embalagem  " +
                                 "           ,	prbg_embalagemdescricao  " +
                                 "           ,	coalesce(dtlog_insert,'1900-01-01 01:01:01') " +
                                 "           ,	coalesce(dtlog_update,'1900-01-01 01:01:01') " +
                                 "           ,	coalesce(prbg_dtupdate_from_api,'1900-01-01 01:01:01') " +
                                 "   from 		tbprodutobluesoft_gtins " +
                                 "   where      1 = 1 ";

            if (UltimoProcessamento)
            SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                 "   and        dtlog_update >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());


            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");


                //BDExecute.Begin(DataBaseName.ODBCOXAN);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                for (int x = 0; x <= DX.Tables[0].Rows.Count - 1; x++)
                {
                    /*ESTOQUE CUSTO BLUESOFT*/
                    string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbprodutobluesoft_Embalagem       " +
                                           "            @cdprodutobluesoft			            =  {0}      " +
                                           "          ,	@codigobarra			                = '{1}'     " +
                                           "          ,	@embalagem           		            = '{2}'     " +
                                           "          , @embalagemdescricao                     = '{3}'     " +
                                           "          ,	@dtlog_insert                           = '{4}'     " +
                                           "          ,	@dtlog_update                           = '{5}'     " +
                                           "          ,	@dtlog_update_api                       = '{6}'     "
                                                 , DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][3].ToString().Replace("'", "")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][4].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][5].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][6].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));

                    BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("TEMP.PostGreSQL: " + ErroInfo + " - " + ex.Message);
            }
        }

    }
}
