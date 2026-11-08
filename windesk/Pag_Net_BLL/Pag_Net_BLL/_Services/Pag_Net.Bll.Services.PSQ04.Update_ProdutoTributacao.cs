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
    public static class ProdutoTributacao
    {
        public static void Update(Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {


            string SQL_POSTGRE = " select 		prb_cdprodutobluesoft " +
                                 "           ,	prbt_icms_saida_cst " +
                                 "           ,	prbt_icms_aliquota_interna " +
                                 "           ,	prbt_icms_reducao " +
                                 "           ,	prbt_pis_saida_cst " +
                                 "           ,	prbt_pis_saida_aliquota " +
                                 "           ,	prbt_cofins_saida_cst " +
                                 "           ,	prbt_cofins_saida_aliquota " +
                                 "           ,	prbt_ncm " +
                                 "           ,	prbt_cest " +
                                 "           ,  coalesce(dtlog_insert, '1900-01-01 01:01:01') " +
                                 "           ,  coalesce(dtlog_update, '1900-01-01 01:01:01') " +
                                 "           ,  coalesce(prb_dtupdate_from_api, '1900-01-01 01:01:01') " +
                                 " from 		tbprodutobluesoft_tributacao " +
                                 " where 		1 = 1 " +
                                 " and			coalesce(op_cdoperacao,2) = 2 ";
            if (UltimoProcessamento)
                SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                     "   and       coalesce(prb_dtupdate_from_api, '1900-01-01 01:01:01' ) >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());


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
                    string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbprodutoTributacao                " +
                                             "        	@cdprodutobluesoft				        =  {0}       " +
                                           "        ,	@ICMS_Saida_CST			                = '{1}'      " +
                                           "        ,	@ICMS_Aliquota_Interna	                =  {2}       " +
                                           "        ,	@ICMS_Reducao			                =  {3}       " +
                                           "        ,	@PIS_Saida_CST			                = '{4}'      " +
                                           "        ,	@PIS_Saida_Aliquota		                =  {5}       " +
                                           "        ,	@COFINS_Saida_CST		                = '{6}'      " +
                                           "        ,	@COFINS_Saida_Aliquota	                =  {7}       " +
                                           "        ,	@NCM					                = '{8}'      " +
                                           "        ,	@CEST					                = '{9}'      " +
                                           "        ,	@dtlog_insert   		                = '{10}'     " +
                                           "        ,	@dtlog_update   		                = '{11}'     " +
                                           "        ,	@dtlog_update_api		                = '{12}'     ",
                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][3].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][4].ToString()
                                                 , DX.Tables[0].Rows[x][5].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][6].ToString()
                                                 , DX.Tables[0].Rows[x][7].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][8].ToString()
                                                 , DX.Tables[0].Rows[x][9].ToString()
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][10].ToString()).ToString("yyyyMMdd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][11].ToString()).ToString("yyyyMMdd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][12].ToString()).ToString("yyyyMMdd HH:mm:ss")
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
