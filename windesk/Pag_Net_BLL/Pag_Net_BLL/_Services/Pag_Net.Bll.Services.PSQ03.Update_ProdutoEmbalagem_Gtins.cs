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
    public static class ProdutoEmbalagem_Gtins
    {
        public static void Update(Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {

            string SQL_POSTGRE = " select 		pr.pr_cdproduto " +
                                 "           ,	em.prb_cdprodutobluesoft " +
                                 "           ,	em.pre_embalagem " +
                                 "           ,	gt.preg_cdbarra " +
                                 "           ,	coalesce(gt.dtlog_insert, '1900-01-01 01:01:01' ) " +
                                 "           ,	coalesce(gt.dtlog_update, '1900-01-01 01:01:01' ) " +
                                 "           ,	coalesce(gt.dtlog_update_api, '1900-01-01 01:01:01' ) " +
                                 "   from 		tbprodutoembalagem_gtins gt " +
                                 "   inner join	tbprodutoembalagem 		 em on 	em.pr_cdproduto = gt.pr_cdproduto " +
                                 "	                                    and 	em.prb_cdprodutobluesoft = gt.prb_cdprodutobluesoft " +
                                 "   inner join  tbproduto				 pr on	pr.pr_cdproduto = em.pr_cdproduto ";
            if (UltimoProcessamento)
                SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                     "   and        gt.dtlog_update >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());

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
                    string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbproduto_Embalagem_Gtins               " +
                                           "            @cdproduto          			        =  {0}      " +
                                           "          , @cdprodutobluesoft                      =  {1}      " +
                                           "          , @Embalagem                              = '{2}'     " +
                                           "          , @cdbarra                                = '{3}'     " +
                                           "          , @dtlog_insert                           = '{4}'     " +
                                           "          , @dtlog_update                           = '{5}'     " +
                                           "          , @dtlog_update_api                       = '{6}'      ",

                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][3].ToString()
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][4].ToString()).ToString("yyyyMMdd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][5].ToString()).ToString("yyyyMMdd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][6].ToString()).ToString("yyyyMMdd HH:mm:ss")
                                                 );

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
