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
    public static class ProdutoEmbalagem
    {
        public static void Update(Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {


            string SQL_POSTGRE = " select 		 em.pr_cdproduto  " +
                                 "           ,	 em.prb_cdprodutobluesoft " +
                                 "           ,	 em.pre_embalagem " +
                                 "           ,	 em.pre_fatorestoque " +
                                 "           ,	 b.prb_descricao " +
                                 "           ,	 em.pre_status " +
                                 "           ,	 b.prb_embalagemestoque " +
                                 "           ,   coalesce(em.cdbarra_princial,'')  " + 
                                 "           ,   coalesce(em.dtlog_insert,'1900-01-01 01:01:01') " +
                                 "           ,   coalesce(em.dtlog_update,'1900-01-01 01:01:01')  " +
                                 "           ,   coalesce(em.dtlog_update_api,'1900-01-01 01:01:01')  " + 
                                 "   from 		 tbprodutoembalagem em " +
                                 "   inner join  tbprodutobluesoft  b 	on b.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft ";
            if (UltimoProcessamento)
                SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                     "   and        em.dtlog_update >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());

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
                    string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbproduto_Embalagem               " +
                                           "            @cdproduto          			        =  {0}      " +
                                           "          , @cdprodutobluesoft                      =  {1}      " +
                                           "          , @Embalagem                              = '{2}'     " +
                                           "          , @FatorEstoque                           =  {3}      " +
                                           "          , @EmbalagemDescricao                     = '{4}'     " +
                                           "          , @statusprodutoembalagem                 =  {5}      " +
                                           "          , @embalagembluesoft                      = '{6}'     " + 
                                           "          , @dtlog_insert                           = '{7}'     " + 
                                           "          , @dtlog_update                           = '{8}'     " + 
                                           "          , @dtlog_update_api                       = '{9}'     "
                                                 , DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][3].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][4].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][5].ToString()
                                                 , DX.Tables[0].Rows[x][6].ToString().Replace("'", "")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][7].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][8].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][9].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
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
