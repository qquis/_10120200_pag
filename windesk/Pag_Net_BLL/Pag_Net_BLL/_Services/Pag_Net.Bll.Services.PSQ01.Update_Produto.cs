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
    public static class Produto
    {
        public static void Update(Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {

            string SQL_POSTGRE = " select 		p.pr_cdproduto                                      " +
                                 "           ,	p.prb_cdprodutobluesoft                             " +
                                 "           ,	p.pr_descricao                                      " +
                                 "           ,	p.pr_embalagemestoque                               " +
                                 "           ,	coalesce(p.pr_embalagemcompra, p.pr_embalagemestoque) " +
                                 "           ,	coalesce(p.pr_embalagemcompra_fator,1)              " +
                                 "           ,	x.prb_descricao_fiscal                              " +
                                 "           ,	coalesce(p.prsg_cdsubgrupo,1)                       " +
                                 "           ,  p.pr_status                                         " +
                                 "           ,  coalesce(p.cdpessoabluesoft_fabricante,1)           " +
                                 "           ,  coalesce(fnp.prbf_cdpessoabluesoft,0)               " +
                                 "           ,  coalesce(prbf_codigo_referencia,'')                 " +
                                 "           ,  coalesce(p.dtlog_insert,'1900-01-01 01:01:01')      " +
                                 "           ,  coalesce(p.dtlog_update,'1900-01-01 01:01:01')      " +
                                 "           ,  coalesce(p.dtlog_update_api,'1900-01-01 01:01:01')  " +
                                 "   from 		 tbproduto 			                    p " +
                                 "   inner join  tbprodutobluesoft 	                    x on x.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft" +
                                 "   left  join  tbprodutobluesoft_fornecedor           fnp on fnp.prbf_seq = x.prbf_seq " +
                                 "   where       1 = 1 ";


            if (UltimoProcessamento)
                SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                     "   and        p.dtlog_update >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());

                SQL_POSTGRE = SQL_POSTGRE + 
                                             "   order by   p.pr_cdproduto, p.prb_cdprodutobluesoft, p.pr_descricao asc ";

            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");


                //BDExecute.Begin(DataBaseName.ODBCOXAN);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                for (int x = 0; x <= DX.Tables[0].Rows.Count -1; x++)
                {
                    /*ESTOQUE CUSTO BLUESOFT*/
                    string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbproduto      	                " +
                                           "            @cdproduto          			        =   {0}      " +
                                           "          , @cdprodutobluesoft                      =   {1}      " +
                                           "          , @descricao                              =  '{2}'     " +
                                           "          , @embalagemestoque                       =  '{3}'     " +
                                           "          , @embalagemcompra                        =  '{4}'     " +
                                           "          , @embalagemcompra_fator                  =   {5}      " +
                                           "          , @descricao_fiscal                       =  '{6}'     " +
                                           "          ,	@prsg_cdsubgrupo			            =   {7}      " +
                                           "          , @status_produto                         =   {8}      " +
                                           "          , @CdParticipanteBlueSoft_Fabricante      =   {9}      " +
                                           "          , @CdParticipanteBlueSoft_Fornecedor      =   {10}     " +
                                           "          , @Fornecedor_CodigoReferencia            =  '{11}'    " +
                                           "          ,	@dtlog_insert                           =  '{12}'    " + 
                                           "          ,	@dtlog_update                           =  '{13}'    " + 
                                           "          ,	@dtlog_update_api                       =  '{14}'    ", 
                                                   DX.Tables[0].Rows[x][0].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][1].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][3].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][4].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][5].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][6].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][7].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][8].ToString()
                                                 , DX.Tables[0].Rows[x][9].ToString()
                                                 , DX.Tables[0].Rows[x][10].ToString()
                                                 , DX.Tables[0].Rows[x][11].ToString().ToString().Replace("'", "")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][12].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][13].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][14].ToString()).ToString("yyyy-MM-dd HH:mm:ss")

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
