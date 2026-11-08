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
    public static class EstoqueCusto
    {

        public static void Update(Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {

            string SQL_POSTGRE = " SELECT  	pr_cdproduto					                            " +
                    "                      ,	ec_embalagemestoque_qtde		                        " +
                    "	                   ,	ec_embalagemestoque_qtde_online	                        " +
                    "	                   ,	ec_embalagemestoque_fv_pendente                         " +
                    "	                   ,	ec_valor_custo_precificacao 	                        " +
                    "	                   ,	ec_valor_custo_faturamento		                        " +
                    "	                   ,	ec_valor_customedio_comimposto	                        " +
                    "	                   ,	ec_valor_customedio_semimposto	                        " +
                    "	                   ,	ec_valor_ultimacompra_bruto		                        " +
                    "	                   ,	ec_valor_ultimacompra_liq		                        " +
                    "	                   ,	coalesce(ec_data_atualizacao_dia, '1900-01-01')		    " +
                    "	                   ,	coalesce(ec_data_atualizacao_online, '1900-01-01')      " +
                    "	                   ,	ecdb_seq						                        " +
                    "                      ,	coalesce(dtlog_insert, '1900-01-01 01:01:01' )			" +
                    "                      ,	coalesce(dtlog_update, '1900-01-01 01:01:01' )			" +
                    "                      ,	coalesce(dtlog_update_api, '1900-01-01 01:01:01' )		" +
                    "	           FROM tbestoquecusto";
            //"	        limit 10 ";

            if (UltimoProcessamento)
                SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                     "   and       coalesce(dtlog_update, '1900-01-01 01:01:01' ) >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());

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
                    /*ESTOQUE CUSTO OXAN*/
                    string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbestoquecusto                " +
                                           "        	@pr_cdproduto						  = {0}     " +
                                           "        ,	@ec_embalagemestoque_qtde			  = {1}     " +
                                           "        ,	@ec_embalagemestoque_qtde_online	  = {2}     " +
                                           "        ,	@ec_embalagemestoque_fv_pendente	  = {3}     " +
                                           "        ,	@ec_valor_custo_precificacao 		  = {4}     " +
                                           "        ,	@ec_valor_custo_faturamento			  = {5}     " +
                                           "        ,	@ec_valor_customedio_comimposto		  = {6}     " +
                                           "        ,	@ec_valor_customedio_semimposto		  = {7}     " +
                                           "        ,	@ec_valor_ultimacompra_bruto		  = {8}     " +
                                           "        ,	@ec_valor_ultimacompra_liq			  = {9}     " +
                                           "        ,	@ec_data_atualizacao_dia			  = '{10}'  " +
                                           "        ,	@ec_data_atualizacao_online			  = '{11}'  " +
                                           "        ,	@ecdb_seq							  = {12}    " +
                                           "        ,   @dtlog_insert                         = '{13}'  " +
                                           "        ,   @dtlog_update                         = '{14}'  " +
                                           "        ,   @dtlog_update_api					  = '{15}'  "
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
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][10].ToString()).ToString("yyyy-MM-dd")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][11].ToString()).ToString("yyyy-MM-dd")
                                                 , DX.Tables[0].Rows[x][12].ToString()
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][13].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][14].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][15].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
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
