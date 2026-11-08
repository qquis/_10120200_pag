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
    public static class EstoqueCustoBlueSoft
    {
        public static void Update(Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {


            string SQL_POSTGRE = " SELECT  prb_cdprodutobluesoft,  " +
                    "                      ecb_embalagemestoqueqtde, " +
                    "	                   ecb_embalagemestoqueqtde_online, " +
                    "	                   ecb_embalagemestoqueqtde_disponivel, " +
                    "	                   ecb_embalagemestoqueqtde_contabil, " +
                    "	                   ecb_valor_customedio_contabil, " +
                    "	                   ecb_valor_customedio_semimposto, " +
                    "	                   ecb_valor_customedio_comimposto, " +
                    "	                   ecb_valor_custobruto_ultimacompra, " +
                    "	                   ecb_valor_custoliquido_ultimacompra, " +
                    "	                   coalesce(ecb_dtupdate_from_api, '1900-01-01 01:01:01'), " +
                    "	                   coalesce(dtlog_insert, '1900-01-01 01:01:01'), " +
                    "	                   coalesce(dtlog_update, '1900-01-01 01:01:01')  " +
                    "	           FROM public.tbestoquecustobluesoft " + 
                    "              where 1 = 1 " ;
            //"	        limit 10 ";

            if (UltimoProcessamento)
                SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                     "   and        coalesce(ecb_dtupdate_from_api, '1900-01-01 01:01:01') >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());

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
                    string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbestoquecustobluesoft	                  " +
                                           "             @prb_cdprodutobluesoft			        = {0}     " +
                                           "          ,	@ecb_embalagemestoqueqtde			    = {1}     " +
                                           "          ,	@ecb_embalagemestoqueqtde_online		= {2}     " +
                                           "          ,	@ecb_embalagemestoqueqtde_disponivel	= {3}     " +
                                           "          ,	@ecb_embalagemestoqueqtde_contabil	    = {4}     " +
                                           "          ,	@ecb_valor_customedio_contabil		    = {5}     " +
                                           "          ,	@ecb_valor_customedio_semimposto		= {6}     " +
                                           "          ,	@ecb_valor_customedio_comimposto		= {7}     " +
                                           "          ,	@ecb_valor_custobruto_ultimacompra	    = {8}     " +
                                           "          ,	@ecb_valor_custoliquido_ultimacompra	= {9}     " +
                                           "          ,	@ecb_dtupdate_from_api				    = '{10}'  " +
                                           "          ,	@dtlog_insert						    = '{11}'  " +
                                           "          ,	@dtlog_update                           = '{12}'  "

                                                 , DX.Tables[0].Rows[x][0].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][1].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][3].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][4].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][5].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][6].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][7].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][8].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][9].ToString().Replace(",", ".")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][10].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][11].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][12].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));

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
