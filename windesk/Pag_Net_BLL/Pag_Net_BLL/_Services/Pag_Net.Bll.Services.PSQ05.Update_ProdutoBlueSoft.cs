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
    public static class ProdutoBlueSoft
    {
        public static void Update(Pag_Net.Models.modelSistemaUsuario MyConnect, bool UltimoProcessamento)
        {

            string SQL_POSTGRE = " select		prb_cdprodutobluesoft_pk					            as CdProdutoBlueSoft " +
                                 "          ,   prb_cdprodutobluesoftunitario                           as cdprodutobluesoftunitraio " + 
                                 "          ,	left(prb_descricao,60) 						            as Descricao " +
                                 "          ,	left(coalesce(prb_descricao_fiscal,''),90) 	            as DescricaoFiscal " +
                                 "          ,	prb_embalagemestoque						            as EmbalagemEstoque " +
                                 "          ,	prb_fatorestoque							            as FatorEstoque " +
                                 "          ,	prb_embalagemcompra							            as EmbalagemCompra " +
                                 "          ,	prb_embalagemcompra_qtdeunitaria			            as EmbalagemCompraQtde  " +
                                 "          ,	prb_cdbarra_principal 						            as CdBarraPrincipal " +
                                 "          ,	prb_cdsubgrupo								            as CdSubGrupo  " +
                                 "          ,	coalesce(prb_dt_cadastro,'1900-01-01') 				    as DataCadastro  " +
                                 "          ,	coalesce(prb_dt_ultimaalteracao,'1900-01-01') 		    as DataUltimaAlteracao  " +
                                 "          ,	prb_cdpessoabluesoft_fabricante                         as CdPessoaBlueSoftFabricante  " +
                                 "          ,	prbf_seq									            as prbf_seq  " +
                                 "          ,	coalesce(prb_dtupdate_from_api,'1900-01-01 01:01:01')   as dtlog_update_api  " +
                                 "          ,	coalesce(dtlog_update,'1900-01-01 01:01:01')            as dtlog_update " +
                                 "          ,	coalesce(dtlog_insert,'1900-01-01 01:01:01')            as dtlog_insert " +
                                 "          ,   coalesce(prb_status,'false')                            as status " + 
                                 " from 		tbprodutobluesoft" +
                                 " where        1 = 1"; 

            if (UltimoProcessamento)
                SQL_POSTGRE = SQL_POSTGRE + string.Format(
                                     "   and       coalesce(prb_dtupdate_from_api, '1900-01-01 01:01:01' ) >= '{0}'", Pag_Net.Services.Models.infos.start_time_service_api_sqlserver());

            string ErroInfo = "";
            string SQL_SQLSERVER = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");


                

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                for (int x = 0; x <= DX.Tables[0].Rows.Count - 1; x++)
                {
                    /*ESTOQUE CUSTO BLUESOFT*/
                    SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbprodutobluesoft	                        " +
                                           "          	@CdProdutoBlueSoft					            =  {0}      " +
                                           "          , @cdprodutobluesoftunitario                      =  {1}      " +
                                           "          ,	@Descricao						                = '{2}'     " +
                                           "          ,	@descricao_fiscal 				                = '{3}'     " +
                                           "          ,	@EmbalagemEstoque				                = '{4}'     " +
                                           "          ,	@FatorEstoque                                   =  {5}      " +
                                           "          ,	@EmbalagemCompra                                = '{6}'     " +
                                           "          ,	@EmbalagemCompraQtdeUnitaria                    =  {7}      " +    
                                           "          ,	@CodigoBarraReferencia                          = '{8}'     " +    
                                           "          ,	@SubGrupoKey                                    =  {9}      " +
                                           "          ,	@DataCadastro                                   = '{10}'    " +
                                           "          ,	@DataUltimaAlteracao                            = '{11}'    " +
                                           "          ,	@dtlog_insert                                   = '{12}'    " +
                                           "          ,	@dtlog_update                                   = '{13}'    " +
                                           "          ,	@dtlog_update_api				                = '{14}'    " +
                                           "          ,	@status         				                =  {15}     " ,


                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][3].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][4].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][5].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][6].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][7].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][8].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][9].ToString()
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][10].ToString()).ToString("yyyy-MM-dd")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][11].ToString()).ToString("yyyy-MM-dd")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][14].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][15].ToString()).ToString("yyyy-MM-dd HH:mm:ss")   
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][16].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                                                 , Pag_Net.Models.BDTools.boolColumnResult(DX.Tables[0].Rows[x][17].ToString()));   

                    BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("TEMP.PostGreSQL: " + ErroInfo + " - " + ex.Message + " - " + SQL_SQLSERVER);
            }
        }


    }
}
