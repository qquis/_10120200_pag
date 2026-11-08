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

namespace Pag_Net.Bll
{
    public static class _ServiceTools
    {
        public static DateTime ObterDataProcessamentoDefult(Pag_Net.Models.modelSistemaUsuario MyConnect, string _sis_nucleo_cd, int sis_nucleo_prc_cd)
        {
            try
            {

                DateTime DataRetorno = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

                string _SELECT_PARAMETROS = string.Format(
                                            " SELECT  coalesce(data_reprocessamento_default, '1900-01-01') as data_processamento  " +
                                            "       , coalesce(dateadd_ini,0) as dateadd_ini                                      " +
                                            "       , coalesce(data_default_ini,0)  as data_default" +
                                            " FROM TBSISTEMA_NUCLEO_PROCEDIMENTO " +
                                            " WHERE 1 = 1 " +
                                            " AND  SIS_NUCLEO_CD_FK = '{0}' " +
                                            " AND  SIS_NUCLEO_PRC_CD = {1} ", _sis_nucleo_cd, sis_nucleo_prc_cd
                                            )
                                            ;




                DataSet _DataSet_Parametros = new DataSet();
                _DataSet_Parametros = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, _SELECT_PARAMETROS, "");

                /*Informações vindas do BANCO DE DADOS */
                DateTime data_processamento = Convert.ToDateTime(_DataSet_Parametros.Tables[0].Rows[0]["data_processamento"].ToString());
                int dateadd_ini = Convert.ToInt32(_DataSet_Parametros.Tables[0].Rows[0]["dateadd_ini"].ToString());
                int data_default = Convert.ToInt32(_DataSet_Parametros.Tables[0].Rows[0]["data_default"].ToString());

                if (data_default == 1)
                {

                    DataRetorno = data_processamento;

                }
                else
                {
                    DataRetorno = DataRetorno.AddDays(dateadd_ini);
                }

                string _UPDATE_PARAMETROS = string.Format(
               " UPDATE  TBSISTEMA_NUCLEO_PROCEDIMENTO SET data_reprocessamento_default = '{0}' , data_default_ini = 0, dtlog_update = current_timestamp " +
               " WHERE 1 = 1 " +
               " AND  SIS_NUCLEO_CD_FK = '{1}' " +
               " AND  SIS_NUCLEO_PRC_CD = {2} ", DataRetorno.ToString("yyyy-MM-dd"), _sis_nucleo_cd, sis_nucleo_prc_cd)
               ;
                string processamento_reset_date = string.Format(_UPDATE_PARAMETROS, _sis_nucleo_cd, sis_nucleo_prc_cd);
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute(processamento_reset_date, null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);

                return DataRetorno;



            }
            catch (Exception ex)
            {
                throw new Exception("ERRO: Pag_Net.Bll._Service | ObterDataProcessamentoDefult()" + ex.Message);
            }




        }
        public static DateTime ObterDataProcessamentoDefultFim(Pag_Net.Models.modelSistemaUsuario MyConnect, string _sis_nucleo_cd, int sis_nucleo_prc_cd)
        {
            try
            {

                DateTime DataRetorno = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

                string _SELECT_PARAMETROS = string.Format(
                                            " SELECT  coalesce(data_reprocessamento_default_fim, '1900-01-01') as data_processamento  " +
                                            "       , coalesce(dateadd_fim,0) as dateadd_fim                                      " +
                                            "       , coalesce(data_default_fim,0) as data_default" +
                                            " FROM TBSISTEMA_NUCLEO_PROCEDIMENTO " +
                                            " WHERE 1 = 1 " +
                                            " AND  SIS_NUCLEO_CD_FK = '{0}' " +
                                            " AND  SIS_NUCLEO_PRC_CD = {1} ", _sis_nucleo_cd, sis_nucleo_prc_cd
                                            )
                                            ;




                DataSet _DataSet_Parametros = new DataSet();
                _DataSet_Parametros = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, _SELECT_PARAMETROS, "");

                /*Informações vindas do BANCO DE DADOS */
                DateTime data_processamento = Convert.ToDateTime(_DataSet_Parametros.Tables[0].Rows[0]["data_processamento"].ToString());
                int dateadd_fim = Convert.ToInt32(_DataSet_Parametros.Tables[0].Rows[0]["dateadd_fim"].ToString());
                int data_default = Convert.ToInt32(_DataSet_Parametros.Tables[0].Rows[0]["data_default"].ToString());

                if (data_default == 1)
                {

                    DataRetorno = data_processamento;

                }
                else
                {
                    DataRetorno = DataRetorno.AddDays(dateadd_fim);
                }





                string _UPDATE_PARAMETROS = string.Format(
               " UPDATE  TBSISTEMA_NUCLEO_PROCEDIMENTO SET data_reprocessamento_default_fim = '{0}', data_default_fim = 0, dtlog_update = current_timestamp " +
               " WHERE 1 = 1 " +
               " AND  SIS_NUCLEO_CD_FK = '{1}' " +
               " AND  SIS_NUCLEO_PRC_CD = {2} ", DataRetorno.ToString("yyyy-MM-dd"), _sis_nucleo_cd, sis_nucleo_prc_cd)
               ;
                string processamento_reset_date = string.Format(_UPDATE_PARAMETROS, _sis_nucleo_cd, sis_nucleo_prc_cd);
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute(processamento_reset_date, null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);

                return DataRetorno;



            }
            catch (Exception ex)
            {
                throw new Exception("ERRO: Pag_Net.Bll._Service | ObterDataProcessamentoDefult()" + ex.Message);
            }




        }

    }

    public class _Service
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public string LogServiceFile;
        public Mdo_sis_ServiceTime[] ListaDeServicosTimes;
        public Mdo_sis_ServicosProcedimento[] ListaDeServicosProcedimentos;

        public _Service(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;
        }

        public _Service(Pag_Net.Models.modelSistemaUsuario _myConnect, string _LogServiceFile)
        {
            MyConnect = _myConnect;
            LogServiceFile = _LogServiceFile;
        }


        public void ObterServicosTime()
        {
            //LogFile.Write(_logServiceFile, string.Format("Obtendo lista de Serviços Postresql", Pag_Net.Models.PagVersion.Get));
            DataTable DT = Pag_Net.Bll._0009.Select.dataTable(MyConnect);
            List<Mdo_sis_ServiceTime> _list = new List<Mdo_sis_ServiceTime>();

            foreach (DataRow i in DT.Rows)
            {
                _list.Add(new Mdo_sis_ServiceTime(i));
            }
            ListaDeServicosTimes = _list.ToArray();
        }

        public void ObterServicosProcedimentos(Mdo_sis_ServiceTime _Mdo_sis_ServiceTime)
        {
            DataTable DT = Pag_Net.Bll._0010.Select._dataTable(MyConnect, _Mdo_sis_ServiceTime.sis_servico_cd);
            List<Mdo_sis_ServicosProcedimento> _list = new List<Mdo_sis_ServicosProcedimento>();

            foreach (DataRow i in DT.Rows)
            {
                _list.Add(new Mdo_sis_ServicosProcedimento(i));
            }
            ListaDeServicosProcedimentos = _list.ToArray();
        }

        public void ExecutarServicoProcedimento(Mdo_sis_ServiceTime _Mdo_sis_ServiceTime)
        {
            try
            {
                ObterServicosProcedimentos(_Mdo_sis_ServiceTime);

                if (ListaDeServicosProcedimentos.Count() > 0)
                {
                    foreach (Mdo_sis_ServicosProcedimento item in ListaDeServicosProcedimentos)
                    {
                        if (LogServiceFile != "")
                        {
                            LogFile.Write(LogServiceFile, string.Format("SERVICO {0} - N. DE ORDEM: {2} DESCRICAO: {1}",
                                    _Mdo_sis_ServiceTime.sis_servico_cd.ToString(),
                                    item.sis_nucleo_prc_descritivo.ToString(),
                                    item.sis_servico_np_order.ToString()));
                        }
                        Pag_Net.Services.Bll.Postgre.Procedimentos.Execute(MyConnect, item.sis_nucleo_cd, item.sis_nucleo_prc_cd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ProcessarServicosTime()
        {



            string Descricao_do_Servico_Em_Andamento = "";
            int _currentHor = Convert.ToInt16(DateTime.Now.Hour.ToString());
            int _currentMinute = Convert.ToInt16(DateTime.Now.Minute.ToString());
            int _currentSecond = Convert.ToInt16(DateTime.Now.Second.ToString());
            DateTime _currentDate = DateTime.Now.Date;

            try
            {

                int _currentWeekday = 0;

                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) _currentWeekday = 1;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) _currentWeekday = 2;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) _currentWeekday = 3;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday) _currentWeekday = 4;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday) _currentWeekday = 5;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday) _currentWeekday = 6;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) _currentWeekday = 7;

                Mdo_sis_ServiceTime _ListaDeServicosTimes = Array.Find(ListaDeServicosTimes,
                                    element => Convert.ToDateTime(element.sis_servico_data_ini.ToString()) <= _currentDate &
                              Convert.ToDateTime(element.sis_servico_data_fim.ToString()) >= _currentDate &
                              ( Convert.ToInt32(element.sis_servico_hora.ToString()) == _currentHor  || Convert.ToInt32(element.sis_servico_hora.ToString()) == 0 ) &
                              Convert.ToInt32(element.sis_servico_minuto.ToString()) == _currentMinute &
                              Convert.ToInt32(element.sis_servico_segundo.ToString()) == _currentSecond &
                              (Convert.ToInt32(element.sis_servico_diasemana.ToString()) == _currentWeekday ||
                                 Convert.ToInt32(element.sis_servico_diasemana.ToString()) == 0));
                if (_ListaDeServicosTimes != null)
                {
                    Descricao_do_Servico_Em_Andamento = _ListaDeServicosTimes.sis_servico_descricao;
                    ExecutarServicoProcedimento(_ListaDeServicosTimes);
                }

            }
            catch (Exception ex)
            {

                throw new Exception (

                string.Format("Date Service: {0} Time Service: {1}_{2}_{3} | Descricao: {4}",
                            _currentDate.ToShortDateString(),
                            _currentHor.ToString(),
                            _currentMinute.ToString(),
                            _currentSecond.ToString(),
                            Descricao_do_Servico_Em_Andamento + " ERRO: " + ex.Message));
            }

        }


    }
}

namespace Pag_Net.Models
{
    public class Mdo_sis_ServiceTime
    {

        public string sis_servico_cd { get; set; }
        public string sis_servico_descricao { get; set; }
        public DateTime sis_servico_data_ini { get; set; }
        public DateTime sis_servico_data_fim { get; set; }
        public int sis_servico_hora { get; set; }
        public int sis_servico_minuto { get; set; }
        public int sis_servico_segundo { get; set; }
        public int sis_servico_diasemana { get; set; }


        public Mdo_sis_ServiceTime() { }


        public Mdo_sis_ServiceTime(string _sis_servico_cd
                                    , string _sis_servico_descricao
                                    , DateTime _sis_servico_data_ini
                                    , DateTime _sis_servico_data_fim
                                    , int _sis_servico_hora
                                    , int _sis_servico_minuto
                                    , int _sis_servico_segundo
                                    , int _sis_servico_diasemana



            )
        {

            sis_servico_cd = _sis_servico_cd;
            sis_servico_descricao = _sis_servico_descricao;
            sis_servico_data_ini = _sis_servico_data_ini;
            sis_servico_data_fim = _sis_servico_data_fim;
            sis_servico_hora = _sis_servico_hora;
            sis_servico_minuto = _sis_servico_minuto;
            sis_servico_segundo = _sis_servico_segundo;
            sis_servico_diasemana = _sis_servico_diasemana;



        }


        public Mdo_sis_ServiceTime(DataRow i)
        {
            try
            {
                
                sis_servico_cd = i["sis_servico_cd"].ToString();
                sis_servico_descricao = i["sis_servico_descricao"].ToString();
                sis_servico_data_ini = Convert.ToDateTime(i["sis_servico_data_ini"].ToString());
                sis_servico_data_fim = Convert.ToDateTime(i["sis_servico_data_fim"].ToString());
                sis_servico_hora = Convert.ToInt32(i["sis_servico_hora"].ToString());
                sis_servico_minuto = Convert.ToInt32(i["sis_servico_minuto"].ToString());
                sis_servico_segundo = Convert.ToInt32(i["sis_servico_segundo"].ToString());
                sis_servico_diasemana = Convert.ToInt32(i["sis_servico_diasemana"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Models.Mdo_sis_ServiceTime: " + ex.Message);
            }
        }

    }

    public class Mdo_sis_ServicosProcedimento
    {
        public string sis_servico_cd { get; set; }
        public int sis_nucleo_prc_cd { get; set; }
        public string sis_nucleo_cd { get; set; }
        public string sis_servico_descricao { get; set; }
        public int sis_servico_np_order { get; set; }
        public string sis_nucleo_prc_descritivo { get; set; }

        public Mdo_sis_ServicosProcedimento() { }

        public Mdo_sis_ServicosProcedimento(DataRow i)
        {
            sis_servico_cd = i["sis_servico_cd"].ToString();
            sis_nucleo_prc_cd = Convert.ToInt32(i["sis_nucleo_prc_cd"].ToString());
            sis_nucleo_cd = i["sis_nucleo_cd"].ToString();
            sis_servico_descricao = i["sis_servico_descricao"].ToString();
            sis_servico_np_order = Convert.ToInt32(i["sis_servico_np_order"].ToString());
            sis_nucleo_prc_descritivo = i["sis_nucleo_prc_descritivo"].ToString();
        }
    }
}



/******************************* COMPLEMENTOS *********************************************/
namespace Pag_Net.Services.Bll.SqlServer
{
    public static class Produto
    {
        public static void Service0001_SP0015_ProdutoBlueSoft(modelSistemaUsuario MyConnect)
        {
            // ServicePag Migration - Redshift_SqlServer | PRODUTOS (SPC0015TbProdutoBlueSoft)
            Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft ObjSPC0015TbProdutoBlueSoft = new Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft(MyConnect);
            ObjSPC0015TbProdutoBlueSoft.Execute();
        }
        public static void Service0002_SP_ProdutoBlueSoftComposicao(modelSistemaUsuario MyConnect)
        {
            // ServicePag Migration - Redshift_SqlServer | Composicao
            Pag_Net.Bll.SP_ProdutoBlueSoftComposicao SP_PRODUTOBLUESOFTCOMPOSICAO = new Pag_Net.Bll.SP_ProdutoBlueSoftComposicao(MyConnect);
            SP_PRODUTOBLUESOFTCOMPOSICAO.TbProdutoBlueSoftComposicao_Import();
        }
        public static void Service0003_SPC0110_ProdutoBlueSoft_Tributacao(modelSistemaUsuario MyConnect)
        {
            // ServicePag Migration - Redshift_SqlServer | Tributacao - SPC0110_ProdutoBlueSoftTributacao
            Pag_Net.SPC0110.Bll.Migration.FromRedShift.ToSqlServer(MyConnect);
        }
        public static void Service0005_SP_Produto_All_Old(modelSistemaUsuario MyConnect)
        {
            // ServicePag Migration - Redshift_SqlServer | SP_PRODUTO
            // Tabela: TbProdutoBlueSoftEmbalagem
            // Tabela: TbProdutoBlueSoftComplementoCateg
            // PROCPP: SP_PRODUTO_11A - SQLUpdateProdutoRelacional
            Pag_Net.Bll.SP_Produto SP_PRODUTO = new SP_Produto(MyConnect);
            SP_PRODUTO.Execute_Import_RedShiftBlueSoft_Produtos();
        }
        public static void Service0009_SPP0015_ProdutoTributacaoZanthus(modelSistemaUsuario MyConnect)
        {
            // ServicePag Migration - Redshift_SqlServer | Tributacao - SQLPROC SPP0015 _ Atualização BASE ZANTHUS 
            // Observações: Atualiza a tabela tab_regra_icms com base na tabela OXAN_ADM-TbZanthusTabRegraICMS 
            Pag_Net.SPP0015.Bll.SqlServer.Execute(MyConnect);
        }

    }
}

namespace Pag_Net.Services.Bll.TEMP
{

    public static class SqlServer_to_PostGreSQL
    {
        public static void Update_Produto_Clear_Postgre(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {   string SQL_POSTGRE_EXEC = "delete from tbproduto; delete from tbprodutoembalagem; delete from tbprodutoembalagem_gtins";
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Update_Produto(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            int y = 0;
            int seq = 0;
            int count = 0;
            string ErroInfo = "";
            try
            {

                string SQL_SERVER_SELECT = "SELECT		    pr_cdproduto						=		A.CdProduto                                         " +
                                           "           ,	prb_cdprodutobluesoft				=		X.CdProdutoBlueSOftUnitario			                " +
                                           "           ,	pr_descricao						=		A.Descricao                                         " +
                                           "           ,	pr_embalagemestoque					=		a.EmbalagemEstoque                                  " +
                                           "           ,	pr_embalagemcompra					=		a.EmbalagemCompra                                   " +
                                           "           ,	pr_embalagemcompra_fator			=		a.EmbalagemCompraQtdeUnitaria                       " +
                                           "           ,	cdparticipante_fabricante			=		0                                                   " +
                                           "           ,	pr_cdbarra_principal				=		x.CodigoBarraReferencia                             " +
                                           "           ,	pr_status							=		A.StatusProduto                                     " +
                                           "           from			oxan_adm.dbo.Tbproduto			a " + 
                                           "           inner join	oxan_adm.dbo.TbProdutoBlueSoft	    x on x.CdProdutoBlueSoft = a.CdProdutoBlueSoft " + 
                                           "           where			1 = 1 " + 
                                           "           and				x.CdProdutoBlueSoft = x.CdProdutoBlueSOftUnitario " +
                                           "           ORDER BY	A.CdProduto " +
                                           "                  ,	A.Descricao " +
                                           "           		,	X.CdProdutoBlueSOftUnitario	";
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }



                    string SQL_POSTGRE_EXEC = string.Format("SELECT f0015_crud_tbproduto (	    " +
                                                               "           'DBINSERT'        " +
                                                               "       ,    {0}               " +
                                                               "       ,    {1}               " +
                                                               "       ,    '{2}'             " +
                                                               "       ,    '{3}'             " +
                                                               "       ,    '{4}'             " +
                                                               "       ,    {5}               " +
                                                               "       ,    {6}               " +
                                                               "       ,    '{7}'             " +
                                                               "       ,    '{8}'             " +
                                                               "       ,    'false'          )"
                                                 , DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][3].ToString()
                                                 , DX.Tables[0].Rows[x][4].ToString()
                                                 , DX.Tables[0].Rows[x][5].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][6].ToString()
                                                 , DX.Tables[0].Rows[x][7].ToString()
                                                 , DX.Tables[0].Rows[x][8].ToString());
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 10000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update_Produto: " + ErroInfo + " - " + ex.Message + "Seq.: " + y);
            }
        }
        public static void Update_ProdutoEmbalagem(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            int y = 0;
            int seq = 0;
            int count = 0;
            string ErroInfo = "";
            try
            {
                string SQL_SERVER_SELECT = "SELECT		  pr_cdproduto						    =		A.CdProduto " +
                                           "          ,	  prb_cdprodutobluesoft				    =		X.CdProdutoBlueSOft " +
                                           "          ,	  pre_embalagem						    =		em.Embalagem " +
                                           "          ,	  pre_fatorestoque					    =		em.FatorEstoque " +
                                           "          ,	  pre_fatorpreco						=		pr.FatorPreco " +
                                           "          ,	  pre_status							=		x.StatusProduto " +
                                           "          ,   pre_Embalagem_Descricao               =       em.EmbalagemDescricao " + 
                                           "  FROM		  OXAN_ADM.DBO.TbProdutoBlueSoft		            X " +
                                           "  INNER JOIN  oxan_adm.dbo.TbProdutoEmbalagemCB	    E	ON CONVERT(NUMERIC(21,0), E.CdBarra ) = CONVERT(NUMERIC(21,0), X.CodigoBarraReferencia ) " +
                                           "  inner join  oxan_adm.dbo.TbProdutoEmbalagem		    em	ON em.CdProduto = e.CdProduto and em.Embalagem = e.Embalagem " +
                                           "  INNER JOIN  oxan_adm.dbo.TbProduto                   A	ON A.CdProduto = E.CdProduto  " +
                                           "  inner join  oxan_ope.dbo.TbProdutoOperacaoPrecoEmbalagem  pr  ON pr.CdProduto = em.CdProduto and pr.Embalagem = em.Embalagem  " +
                                           "  WHERE		1 = 1 " +
                                           "    AND     isnull(x.cdprodutobluesoft,0) <> 0 " +
                                           "  GROUP BY  A.CDPRODUTO, X.CDPRODUTOBLUESOFT, EM.EMBALAGEM, EM.FATORESTOQUE, PR.FATORPRECO, X.STATUSPRODUTO, em.EmbalagemDescricao  " + 
                                           "  ORDER BY	A.CdProduto " +
                                           "          ,	X.CdProdutoBlueSOft";


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }


                    string SQL_POSTGRE_EXEC = string.Format("SELECT f0016_01_1011846_crud_tbprodutoembalagem (	    " +
                                                               "           'DBINSERT'        " +
                                                               "       ,     {0}             " +
                                                               "       ,     {1}             " +
                                                               "       ,    '{2}'            " +
                                                               "       ,     {3}             " +
                                                               "       ,     {4}             " +
                                                               "       ,    '{5}'            " +
                                                               "       ,    '{6}'            " +
                                                               "       ,    'false'        ) "
                                                 , DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace("'", "")
                                                 , DX.Tables[0].Rows[x][3].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][4].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][5].ToString()
                                                 , DX.Tables[0].Rows[x][6].ToString().Replace("'", "")
                                                 
                                                 );

                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 10000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update_ProdutoEmbalagem: " + ErroInfo + " - " + ex.Message + "Seq.: " + y);
            }
        }
        public static void Update_Preco(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            int y = 0;
            int seq = 0;
            int count = 0;
            string ErroInfo = "";
            try
            {
                string SQL_SERVER_SELECT = "  select	[CdProduto]					=			pr.CdProduto                                                                        " +
                                            "       ,	[CdProdutoBlueSoft]			=			em.CdProdutoBlueSoft                                                                " +
                                            "       ,	[EmbalagemEstoque]			=			pr.EmbalagemEstoque                                                                 " +
                                            "       ,	[Embalagem]					=			em.Embalagem                                                                        " +
                                            "       ,	[EmbalagemDescricao]		=			CASE ISNULL(em.EmbalagemDescricao, '')                                              " +
                                            "       					WHEN '' THEN LEFT(PR.Descricao,20)                                                                          " +
                                            "       					ELSE LEFT( em.EmbalagemDescricao, 20)                                                                       " +
                                            "       			END		                                                                                                            " +
                                            "       ,	[FatorEstoque]				=			em.FatorEstoque                                                                     " +
                                            "       ,	[Relacao]					=			em.Relacao                                                                          " +
                                            "       ,	[ValorPreco]				=			case em.Relacao                                                                     " +
                                            "       			when 'MAIOR' then convert(numeric(13,2), ROUND(pc.ValorPreco * pm.FatorPreco,2) * em.FatorEstoque )                 " +
                                            "       			when 'MENOR' then CONVERT(numeric(13,2), ROUND(pc.ValorPreco * pm.FatorPreco,2) / em.FatorEstoque )	                " +
                                            "       			end                                                                                                                 " +
                                            "       ,	[FatorPreco]				=			case when isnull(pm.FatorPreco,0) = 0 then 1 else isnull(pm.FatorPreco,0) end       " +
                                            "       ,	[QtdePromocional]		    =			CASE WHEN em.Embalagem = pr.EmbalagemEstoque AND isnull(PROMOCIONAL.QtdePromocional,0) > 1 THEN isnull(PROMOCIONAL.QtdePromocional,0)  ELSE 0 END  " +
                                            "       ,   [PRECO_PROMOCIONAL]         =           CASE WHEN em.Embalagem = pr.EmbalagemEstoque AND isnull(PROMOCIONAL.QtdePromocional,0) > 1 THEN isnull(PROMOCIONAL.PRECO_PROMOCIONAL,0) ELSE 0 END " + 
                                            "       	from		OXAN_ADM.dbo.TbProduto							pr                                                              " +
                                            "       	inner join	OXAN_ADM.dbo.TbProdutoEmbalagem					em	on em.CdProduto = pr.CdProduto                              " +
                                            "       	inner join  OXAN_OPE.dbo.TbProdutoOperacaoPreco				pc	on pc.CdProduto = pr.CdProduto                              " +
                                            "       	inner join  oxan_ope.dbo.TbProdutoOperacaoPrecoEmbalagem	pm  on pm.CdProduto = pc.CdProduto and pm.Embalagem = em.Embalagem  and pm.CdOperacao = pc.CdOperacao  " +
                                            "       	inner join  OXAN_ADM.dbo.TbProdutoLinha						ln  on ln.CdProdutoLinha = pr.CdProdutoLinha                    " +
                                            "       	inner join  OXAN_ADM.dbo.TbProdutoSecao						sc  on sc.CdProdutoSecao = ln.CdProdutoSecao                    " +
                                            "           LEFT JOIN ( SELECT		A.CdProduto                                                                                         " +
                                            "                        		,	A.CdProdutoBlueSoft                                                                                 " +
                                            "                               ,   A.EMBALAGEMESTOQUE                                                                                  " + 
                                            "                        		,	PX.QtdePromocional                  QtdePromocional                                                 " +
                                            "                        		,	CONVERT(NUMERIC(13,2), XX.ValorPreco * PX.FatorPreco ) AS PRECO_PROMOCIONAL                         " +
                                            "                        FROM		OXAN_ADM.DBO.TBPRODUTO				A                                                               " +
                                            "                        LEFT JOIN	(	select			pr.CdProduto                                                                    " +
                                            "                        							,	min(x.QtdePromocional) PROM_QTDE  " +
                                            "                        				from			oxan_adm.dbo.tbproduto pr " +
                                            "                        				inner join		oxan_ope.dbo.TbProdutoOperacaoPrecoEmbalagem x on x.CdProduto = pr.CdProduto  " +
                                            "                        				where			isnull(x.QtdePromocional,0) <> 0 " +
                                            "                        				AND				X.CdOperacao = 2  " +
                                            "                        				group by		pr.CdProduto  " +
                                            "                        			) PROM ON PROM.CdProduto = A.CdProduto  " +
                                            "                        LEFT JOIN	OXAN_OPE.DBO.TbProdutoOperacaoPreco				XX ON XX.CdProduto = A.CdProduto  AND XX.CdOperacao = 2 " +
                                            "                        LEFT JOIN	OXAN_OPE.DBO.TbProdutoOperacaoPrecoEmbalagem	PX ON PX.CdProduto = PROM.CdProduto AND PX.QtdePromocional = PROM.PROM_QTDE AND PX.CdOperacao = 2  " +
                                            "                        LEFT JOIN	OXAN_ADM.DBO.TbProdutoEmbalagem					EM ON EM.CdProduto = A.CdProduto AND EM.Embalagem = PX.Embalagem  " +
                                            "                        WHERE		ISNULL(PROM.PROM_QTDE,0) <> 0 " + 
                                            "                      ) PROMOCIONAL ON PROMOCIONAL.CDPRODUTO = PR.CDPRODUTO AND PROMOCIONAL.EMBALAGEMESTOQUE = PR.EMBALAGEMESTOQUE " + 
                                            "       	where		pr.StatusProduto = 1 " +
                                            "       	and			em.StatusProdutoEmbalagem = 1 " +
                                            "           and         isnull(em.cdprodutobluesoft,0) <> 0  " + 
                                            "       	AND			pc.ValorPreco > 0  " +
                                            "       	and			pc.CdOperacao = 2   "; 


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    string SQL_POSTGRE_EXEC = string.Format("SELECT f0045_crud_tbpreco_agendamento (	 " +
                                                               "              0                " + 
                                                               "       ,    'false'            " +
                                                               "       ,    '{0}'              " +
                                                               "       ,      0                " +
                                                               "       ,     {1}               " +
                                                               "       ,     {2}               " +
                                                               "       ,      1               " +
                                                               "       ,     {3}               " + 
                                                               "       ,     {4}               " + 
                                                               "       ,     {5}               " +
                                                               "       ,     {6}               )",
                                                   DateTime.Now.ToString("yyy-MM-dd")
                                                 , DX.Tables[0].Rows[x]["cdproduto"].ToString()
                                                 , DX.Tables[0].Rows[x]["cdprodutobluesoft"].ToString() 
                                                 , DX.Tables[0].Rows[x]["ValorPreco"].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x]["QtdePromocional"].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x]["PRECO_PROMOCIONAL"].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x]["FatorPreco"].ToString().Replace(",", ".")
                                                 
                                                 );


                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 10000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update_Preço: " + ErroInfo + " - " + ex.Message + "Seq.: " + y);
            }
        }
        public static void Update_Custo(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            int y = 0;
            int seq = 0;
            int count = 0;
            //string ErroInfo = "";
            string SQL_POSTGRE_EXEC;
            
            try
            {

                string SQL_SERVER_SELECT = "SELECT		CdProduto                   " +
                                           "		 ,	Isnull(ValorCustoPadrao, ValorCustoBrutoEntrada)   " +
                                           "         ,	ValorCustoBrutoEntrada      " +
                                           " FROM		OXAN_OPE.DBO.TbProdutoOperacaoCusto " +
                                           " where		1 = 1 " +
                                           " AND		CDEMPRESA  = 1" +
                                           " AND        ValorCustoBrutoEntrada > 0 ";


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    SQL_POSTGRE_EXEC = string.Format("SELECT f0030_crud_tbestoquecusto (	    " +
                                                               "           'DBINTEG'        " +
                                                               "       ,     {0}             " +
                                                               "       ,     {1}             " +
                                                               "       ,     {2}             " +
                                                               "       ,     {3}             " +
                                                               "       ,     {4}             " +
                                                               "       ,     {5}             " +
                                                               "       ,     {6}             " +
                                                               "       ,     {7}             " +
                                                               "       ,     {8}             " +
                                                               "       ,     {9}             " +
                                                               "       ,    'false'         )"
                                                 , DX.Tables[0].Rows[x][0].ToString()
                                                 , 0 
                                                 , 0 
                                                 , 0 
                                                 , DX.Tables[0].Rows[x][2].ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][1].ToString().Replace(",", "."),
                                                 0,
                                                 0,
                                                 DX.Tables[0].Rows[x][2].ToString().Replace(",", "."),
                                                 0,
                                                 "False");
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 10000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update EstoqueCusto: " + "Seq.: " + y + " Erro: " +  ex.Message.ToString());
            }
            

        }
        public static void Update_Faturamento ( Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime _dataInicial, DateTime _dataFinal)
        {

                   int y = 0;
            int seq = 0;
            int count = 0;
            //string ErroInfo = "";
            string SQL_POSTGRE_EXEC;
            
            try
            {

                string SQL_SERVER_SELECT =
                    string.Format( "SELECT	            SeqFaturamento                              " +
                                           "       ,	datafaturamento " +
                                           "       ,	dataemissao " +
                                           "       ,	cdempresa " +
                                           "       ,	cdoperacao " +
                                           "       ,	cdparticipantecliente " +
                                           "       ,	cdparticipantevendedor " +
                                           "       ,	convert(int, statusfaturamento) " +
                                           "       ,	isnull(bluesoft,0) " +
                                           "       from OXAN_EST.DBO.tbfaturamento f" +
                                           "       where	1 = 1" +
                                           "       and		f.Datafaturamento >= '{0}'" +
                                           "       and		f.Datafaturamento <= '{1}'" +
                                           "       and		f.CdOperacao in (1,2) " +
                                           "       and		f.CdEmpresa = 1 " +
                                           " order by seqfaturamento asc ", _dataInicial.ToString("yyyy-MM-dd"), _dataFinal.ToString("yyyy-MM-dd"));


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    SQL_POSTGRE_EXEC = string.Format("SELECT f0055_crud_tbfaturamento (	    " +
                                                               "           'DBINSERT'        " +
                                                               "       ,     {0}             " +
                                                               "       ,    '{1}'            " +
                                                               "       ,    '{2}'            " +
                                                               "       ,     {3}             " +
                                                               "       ,     {4}             " +
                                                               "       ,     {5}             " +
                                                               "       ,     {6}             " +
                                                               "       ,     {7}             " +
                                                               "       ,    '{8}'            )",
                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][1].ToString()).ToString("yyyy-MM-dd")
                                                 , Convert.ToDateTime(DX.Tables[0].Rows[x][2].ToString()).ToString("yyyy-MM-dd")
                                                 , DX.Tables[0].Rows[x][3].ToString()
                                                 , DX.Tables[0].Rows[x][4].ToString()
                                                 , DX.Tables[0].Rows[x][5].ToString()
                                                 , DX.Tables[0].Rows[x][6].ToString()
                                                 , DX.Tables[0].Rows[x][7].ToString()
                                                 , DX.Tables[0].Rows[x][8].ToString()                                                 );
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 5000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update EstoqueCusto: " + "Seq.: " + y + " Erro: " +  ex.Message.ToString());
            }
            

        }
        public static void Update_FaturamentoOrigem(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime _dataInicial, DateTime _dataFinal)
        {

            int y = 0;
            int seq = 0;
            int count = 0;
            //string ErroInfo = "";
            string SQL_POSTGRE_EXEC;

            try
            {

                string SQL_SERVER_SELECT =
                    string.Format("     select	 " + 
			                     "              o.seqfaturamento " + 
		                         "           ,	o.SeqFaturamentoOrigem " + 
		                         "           ,	isnull(o.ecf,0) " + 
		                         "           ,	isnull(o.cupomfiscal,0) " + 
		                         "           ,	isnull(o.numeropedido,0) " + 
		                         "           ,	isnull(o.numeronfe,0) " + 
		                         "           ,	isnull(o.nfe,0) " + 
		                         "           ,	isnull(o.prazopgtomedio,0) " + 
		                         "           ,	isnull(o.nfedevolucao,0) " +
                                 "   from		OXAN_EST.DBO.tbfaturamentoorigem o " + 
                                 "   INNER JOIN OXAN_EST.DBO.TBFATURAMENTO       F ON F.SEQFATURAMENTO = O.SEQFATURAMENTO" + 
                                 "   WHERE   1 = 1 " + 
                                 "       and		f.Datafaturamento >= '{0}'" +
                                 "       and		f.Datafaturamento <= '{1}'" +
                                 "       and		f.CdOperacao in (1,2) " +
                                 "       and		f.CdEmpresa = 1 " +
                                 " order by f.seqfaturamento, o.seqfaturamentoorigem asc "
                                    , _dataInicial.ToString("yyyy-MM-dd"), _dataFinal.ToString("yyyy-MM-dd"));


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    SQL_POSTGRE_EXEC = string.Format("SELECT f0056_crud_tbfaturamentoorigem (	    " +
                                                               "           'DBINSERT'        " +
                                                               "       ,     {0}             " +
                                                               "       ,     {1}             " +
                                                               "       ,     {2}             " +
                                                               "       ,     {3}             " +
                                                               "       ,     {4}             " +
                                                               "       ,     {5}             " +
                                                               "       ,     {6}             " +
                                                               "       ,     {7}             " +
                                                               "       ,     {8}             )",
                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString()
                                                 , DX.Tables[0].Rows[x][3].ToString()
                                                 , DX.Tables[0].Rows[x][4].ToString()
                                                 , DX.Tables[0].Rows[x][5].ToString()
                                                 , DX.Tables[0].Rows[x][6].ToString()
                                                 , DX.Tables[0].Rows[x][7].ToString()
                                                 , DX.Tables[0].Rows[x][8].ToString());
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 5000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update EstoqueCusto: " + "Seq.: " + y + " Erro: " + ex.Message.ToString());
            }


        }
        public static void Update_FaturamentoItens(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime _dataInicial, DateTime _dataFinal)
        {

            int y = 0;
            int seq = 0;
            int count = 0;
            //string ErroInfo = "";
            string SQL_POSTGRE_EXEC;

            try
            {

                string SQL_SERVER_SELECT =
                    string.Format("     select                                          " + 
                                  "			i.seqfaturamentoorigem    " + 
                                  "		,	i.SeqItem    " + 
                                  "		,	i.CdProduto    " + 
                                  "		,	i.EmbalagemEstoqueQtde     " + 
                                  "		,	i.EmbalagemCompraQtde    " + 
                                  "		,	ISNULL(i.ValorCustoPadrao,0)    " + 
                                  "		,	convert(int, 0 )      " + 
                                  "		,	ISNULL(i.ValorTotalFaturamentoBase,0)     " +
                                  "		,	ISNULL(i.ValorTotalSubsidiosCorrentes,0)     " +
                                  "		,	ISNULL(i.ValorTotalFaturamento,0)     " +
                                  "		,	ISNULL(i.ValorTotalDescontoFinanceiro,0)     " +
                                  "		,	ISNULL(i.ValorTotalFaturamentoBruto,0)     " +
                                  "		,	ISNULL(i.ValorTotalSubsidiosAplicados,0)     " +
                                  "		,	ISNULL(i.ValorTotalFaturamentoLiquido,0)     " +
                                  "		,	ISNULL(i.StatusFaturamentoItem,0)     " + 
                                  "from		OXAN_EST.DBO.TbFaturamentoItens		i    " +
                                  "inner join  oxan_est.dbo.TbFaturamentoOrigem	o on o.SeqFaturamentoOrigem = i.SeqFaturamentoOrigem     " + 
                                  "inner join  oxan_Est.dbo.tbfaturamento			f on f.SeqFaturamento = o.SeqFaturamento " +
                                 "   WHERE   1 = 1 " +
                                 "       and		f.Datafaturamento >= '{0}'" +
                                 "       and		f.Datafaturamento <= '{1}'" +
                                 "       and		f.CdOperacao in (1,2) " +
                                 "       and		f.CdEmpresa = 1 " +
                                 " order by f.seqfaturamento, o.seqfaturamentoorigem asc "

                                    , _dataInicial.ToString("yyyy-MM-dd"), _dataFinal.ToString("yyyy-MM-dd"));


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    SQL_POSTGRE_EXEC = string.Format("SELECT f0057_crud_tbfaturamentoitens (	    " +
                                                               "           'DBINSERT'         " +
                                                               "       ,     {0}              " +
                                                               "       ,     {1}              " +
                                                               "       ,     {2}              " +
                                                               "       ,     {3}              " +
                                                               "       ,     {4}              " +
                                                               "       ,     {5}              " +
                                                               "       ,     {6}              " +
                                                               "       ,     {7}              " +
                                                               "       ,     {8}              " +
                                                               "       ,     {9}              " +
                                                               "       ,     {10}             " +
                                                               "       ,     {11}             " +
                                                               "       ,     {12}             " +
                                                               "       ,     {13}             " +
                                                               "       ,     {14}             )", 
                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString()
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][3].ToString()).ToString().Replace(",",".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][4].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][5].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][6].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][7].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][8].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][9].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][10].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][11].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][12].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][13].ToString()).ToString().Replace(",", ".")
                                                 , DX.Tables[0].Rows[x][14].ToString());
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 5000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update EstoqueCusto: " + "Seq.: " + y + " Erro: " + ex.Message.ToString());
            }


        }
        public static void Update_Faturamentoinfo(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime _dataInicial, DateTime _dataFinal)
        {

            int y = 0;
            int seq = 0;
            int count = 0;
            //string ErroInfo = "";
            string SQL_POSTGRE_EXEC;

            try
            {
                string SQL_SERVER_SELECT =
                    string.Format("     SELECT		SeqFaturamentoOrigem					=			I.SeqFaturamentoOrigem  " + 
		                          "              ,	SeqItem									=			I.SeqItem   " + 
		                          "              ,	pr_cdproduto							=			I.CdProduto   " + 
		                          "              ,	prb_cdprodutobluesoft_unitario			=			x.CdProdutoBlueSoft   " + 
		                          "              ,	prb_cdprodutobluesoft					=			0  " + 
		                          "              ,	pre_embalagem_preco						=			it.EmbalagemEstoque " + 
		                          "              ,	valor_unitario_preco					=			0   " + 
		                          "              ,	valor_unitario_preco_base				=			i.ValorPrecoBase   " + 
		                          "              ,	valor_unitario_preco_faturamento		=			CONVERT(NUMERIC(13,2) ,I.ValorPrecoAplicado / it.EmbalagemEstoqueQtde )  " + 
		                          "              ,	valor_unitario_preco_liquido			=			CONVERT(NUMERIC(13,2) ,it.ValorTotalFaturamentoLiquido  / IT.EmbalagemEstoqueQtde )  " +
                                  "              ,  ItemBonificado                          =           convert(int, case when i.itembonificado = 1 then 1 else 0 end )" + 
                                  "      FROM		 OXAN_EST.DBO.TbFaturamentoItensDetalhes		    i  " + 
                                  "      INNER JOIN  OXAN_EST.DBO.TbFaturamentoItens					IT ON IT.CdProduto = IT.CdProduto AND IT.SeqItem = I.SeqItem AND I.SeqFaturamentoOrigem = IT.SeqFaturamentoOrigem   " + 
                                  "      INNER JOIN	 OXAN_eST.DBO.TbFaturamentoOrigem		O ON O.SeqFaturamentoOrigem = I.SeqFaturamentoOrigem   " + 
                                  "      INNER JOIN  OXAN_eST.DBO.TBFATURAMENTO				F ON F.SeqFaturamento = O.SeqFaturamento   " + 
                                  "      INNER JOIN  OXAN_ADM.DBO.TbProduto					X ON X.CdProduto = I.CdProduto   " + 
                                  "      LEFT  JOIN  OXAN_ADM.DBO.TbProdutoBlueSoft			A ON A.CdProdutoBlueSoft = X.CdProdutoBlueSoft  " + 
                                  "      WHERE		1 = 1  " + 
                                  "      AND		F.CdOperacao in( 1, 2)   " + 
                                  "      AND		F.DataFaturamento >= '{0}'  " +
                                  "      AND		F.DataFaturamento <= '{1}'  " +
                                  " order by f.seqfaturamento, o.seqfaturamentoorigem asc "
                                    , _dataInicial.ToString("yyyy-MM-dd")
                                    , _dataFinal.ToString("yyyy-MM-dd"));
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    SQL_POSTGRE_EXEC = string.Format("SELECT f0059_crud_tbfaturamentoitensinfo (	    " +
                                                               "           'DBINSERT'         " +
                                                               "       ,     {0}              " +
                                                               "       ,     {1}              " +
                                                               "       ,     {2}              " +
                                                               "       ,     {3}              " +
                                                               "       ,     {4}              " +
                                                               "       ,     '{5}'             " +
                                                               "       ,     {6}              " +
                                                               "       ,     {7}              " +
                                                               "       ,     {8}              " +
                                                               "       ,     {9}              " + 
                                                               "       ,     {10}              )",
                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString()
                                                 , DX.Tables[0].Rows[x][3].ToString()
                                                 , DX.Tables[0].Rows[x][4].ToString()
                                                 , DX.Tables[0].Rows[x][5].ToString()
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][6].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][7].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][8].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][9].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToInt32(DX.Tables[0].Rows[x][10].ToString()).ToString()
                                                        );
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 5000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Update_Faturamentoinfo: " + "Seq.: " + y + " Erro: " + ex.Message.ToString());
            }


        }
        public static void Update_FaturamentoItens_Embalagem(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime _dataInicial, DateTime _dataFinal)
        {

            int y = 0;
            int seq = 0;
            int count = 0;
            //string ErroInfo = "";
            string SQL_POSTGRE_EXEC;

            try
            {

                string SQL_SERVER_SELECT =
                    string.Format("     SELECT		i.SeqFaturamentoOrigem                                                                                  " + 
		                          "              ,	isnull(i.SeqItem,0)                                                                                     " + 
		                          "              ,	isnull(i.CdProduto ,0)                                                                                            " + 
		                          "              ,	isnull(p.CdProdutoBlueSoft,0)                                                                           " + 
		                          "              ,	isnull(i.EmbalagemFaturamento , 'UN')                                                                   " + 
		                          "              ,  isnull(i.CodigoBarra, '0')                                                                              " + 
                                  "              ,	isnull(EmbalagemFaturamentoQtde,0)                                                                      " + 
		                          "              ,	isnull(i.EmbalagemFaturamentoQtdeUnitaria,0)                                                            " + 
		                          "              ,	isnull(i.EmbalagemFaturamentoFatorEstoque,0)                                                            " + 
		                          "              ,	isnull(i.EmbalagemFaturamentoFatorPreco ,0)                                                             " + 
		                          "              ,	isnull(i.EmbalagemFaturamentoTotal,0)                                                                   " + 
                                  "      FROM		oxan_est.dbo.TbFaturamentoItensEmbalagem	i                                                           " + 
                                  "      inner join	oxan_est.dbo.TbFaturamentoOrigem			o on o.SeqFaturamentoOrigem = i.SeqFaturamentoOrigem        " +
                                  "      inner join oxan_est.dbo.TbFaturamento					f on f.SeqFaturamento = o.SeqFaturamento                    " +
                                  "      inner join	oxan_adm.dbo.tbproduto						p on p.CdProduto = i.CdProduto                              " +
                                  "      where		1 = 1                                                                                                   " +
                                  "      and 		f.CdOperacao in (1,2)                                                                                   " +
                                  "       and		f.Datafaturamento >= '{0}'" +
                                  "       and		f.Datafaturamento <= '{1}'" +
                                  "      and		f.CdEmpresa = 1" +
                                  " order by f.seqfaturamento, o.seqfaturamentoorigem asc "

                                    , _dataInicial.ToString("yyyy-MM-dd"), _dataFinal.ToString("yyyy-MM-dd"));


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    SQL_POSTGRE_EXEC = string.Format("SELECT f0058_crud_tbfaturamentoitens_embalagem (	    " +
                                                               "           'DBINSERT'         " +
                                                               "       ,     {0}              " +
                                                               "       ,     {1}              " +
                                                               "       ,     {2}              " +
                                                               "       ,     {3}              " +
                                                               "       ,    '{4}'              " +
                                                               "       ,    '{5}'              " +
                                                               "       ,     {6}              " +
                                                               "       ,     {7}              " +
                                                               "       ,     {8}              " +
                                                               "       ,     {9}              " +
                                                               "       ,     {10}             )",
                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString()
                                                 , DX.Tables[0].Rows[x][3].ToString()
                                                 , DX.Tables[0].Rows[x][4].ToString()
                                                 , DX.Tables[0].Rows[x][5].ToString()
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][6].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][7].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][8].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][9].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][10].ToString()).ToString().Replace(",", "."));
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 5000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update EstoqueCusto: " + "Seq.: " + y + " Erro: " + ex.Message.ToString());
            }


        }
        public static void Update_FaturamentoItensContratos(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime _dataInicial, DateTime _dataFinal)
        {
            int y = 0;
            int seq = 0;
            int count = 0;
            //string ErroInfo = "";
            string SQL_POSTGRE_EXEC;

            try
            {

                string SQL_SERVER_SELECT =
                    string.Format("     SELECT      seqfaturamentoorigem								=	it.SeqFaturamentoOrigem								" +
                                  "              ,	pr_cdproduto										=	it.CdProduto                                        " +    
                                  "              ,	contratoitem_seq									=	it.SeqContratoItem                                  " +
                                  "              ,	contratoitem_prb_embalagem							=	ic.EmbalagemFaturamento                             " +
                                  "              ,	pre_embalagemfaturamento							=	it.EmbalagemFaturamento                             " +
                                  "              ,	pr_embalagemestoque									=	pr.EmbalagemEstoque                                 " +     
                                  "              ,	contratoitem_valorinvestimento_unitario				=	ic.ValorInvestimento                                " +         
                                  "              ,	pre_fatorestoque									=	1                                                   " +
                                  "              ,	embalagemestoqueqtde								=	it.EmbalagemEstoqueQtde                             " +    
                                  "              ,	embalagemestoquevalorinvestimento					=	it.ValorInvestimentoUnitario                        " +
                                  "              ,	valorinvestimentototal								=	it.ValorInvestimentoTotal                           " +    
                                  "  from		 OXAN_EST.DBO.TBFATURAMENTOITENSCONTRATOS	IT                                                                  " +        
                                  "  INNER JOIN	 OXAN_EST.DBO.TbFaturamentoOrigem			o	on o.SeqFaturamentoOrigem = it.SeqFaturamentoOrigem             " +
                                  "  INNER JOIN  OXAN_EST.DBO.TbFaturamento					f	on f.SeqFaturamento = o.SeqFaturamento                          " + 
                                  "  INNER JOIN  OXAN_ADM.DBO.TbContratoItem					ic  on ic.SeqContratoItem = it.SeqContratoItem  and ic.CdProduto = it.CdProduto " +
                                  "  INNER JOIN  OXAN_ADM.DBO.TbProduto						pr  on pr.CdProduto = it.CdProduto " +
                                  "  where		1 = 1" +
                                  "    and      f.cdempresa = 1 " + 
                                  "    and      f.cdoperacao in (1,2) " + 
                                  "  and		f.DataFaturamento >= '{0}' " +
                                  "  and		f.DataFaturamento <= '{1}' " +
                                  " order by f.seqfaturamento, o.seqfaturamentoorigem asc "
                                    , _dataInicial.ToString("yyyy-MM-dd"), _dataFinal.ToString("yyyy-MM-dd"));


                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                y = 0;
                seq = 0;
                count = DX.Tables[0].Rows.Count;
                for (int x = 0; x <= count - 1; x++)
                {
                    if (y == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
                    SQL_POSTGRE_EXEC = string.Format("SELECT f0060_crud_faturamentoitenscontratos (	    " +
                                                               "           'DBINSERT'         " +
                                                               "       ,     {0}              " +
                                                               "       ,     {1}              " +
                                                               "       ,     {2}              " +
                                                               "       ,    '{3}'             " +
                                                               "       ,    '{4}'             " +
                                                               "       ,    '{5}'             " +
                                                               "       ,     {6}              " +
                                                               "       ,     {7}              " +
                                                               "       ,     {8}              " +
                                                               "       ,     {9}              " +
                                                               "       ,     {10}             )",
                                                   DX.Tables[0].Rows[x][0].ToString()
                                                 , DX.Tables[0].Rows[x][1].ToString()
                                                 , DX.Tables[0].Rows[x][2].ToString()
                                                 , DX.Tables[0].Rows[x][3].ToString()
                                                 , DX.Tables[0].Rows[x][4].ToString()
                                                 , DX.Tables[0].Rows[x][5].ToString()
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][6].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][7].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][8].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][9].ToString()).ToString().Replace(",", ".")
                                                 , Convert.ToDouble(DX.Tables[0].Rows[x][10].ToString()).ToString().Replace(",", "."));
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);

                    y = y + 1;
                    seq = seq + 1;

                    if (y > 5000)
                    {
                        y = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        y = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Services | Update EstoqueCusto: " + "Seq.: " + y + " Erro: " + ex.Message.ToString());
            }


        }

    }

    public static class SqlServer
    {
        public static DataTable Select_ProdutoCusto(Pag_Net.Models.modelSistemaUsuario MyConnect, bool Selecionada_Data_Atualizacao, bool Seleciona_Custos_diferente, DateTime Data_Atualizacao_Online)
        {
            DataSet DX = new DataSet();
            try
            {
                string SQL_SERVER_SELECT = "SELECT			T_PRCD_PRODUTO							=	pr.CdProduto                                                " +
                                           "             ,  T_PRCD_PRODUTOBLUESOFT                  =   pr.cdprodutobluesoft                                        " + 
                                           "             ,	T_Descricao								=	pr.Descricao                                                " +
                                           "             ,	T_EMBALAGEMESTOQUE						=	pr.EmbalagemEstoque                                         " +
                                           "             ,	T_EMBALAGEMESTOQUE_QTDE					=	Convert(numeric(13,3), c.ec_embalagemestoque_qtde)          " +
                                           "             ,	T_EMBALAGEMESTOQUE_QTDE_ONLINE			=	Convert(numeric(13,3), c.ec_embalagemestoque_qtde_online)   " +
                                           "             ,  T_VALOR_CUSTO_PRECIFICACAO_ATUAL        =   Convert(numeric(13,2), x.valorcustopadraoatual )            " +
                                           "             ,	T_VALOR_CUSTO_PRECIFICACAO				=	Convert(numeric(13,2), c.ec_valor_custo_precificacao)       " +
                                           "             ,  T_VALOR_CUSTO_PRECIFICACAO_DIFERENCA    =   Convert(numeric(13,2), x.valorcustopadraoatual ) - Convert(numeric(13,2), c.ec_valor_custo_precificacao)  " + 
                                           "             ,  T_VALOR_CUSTO_FATURAMENTO_ATUAL         =   Convert(numeric(13,2), x.valorcustopadrao)                  " +
                                           "             ,	T_VALOR_CUSTO_FATURAMENTO				=	Convert(numeric(13,2), c.ec_valor_custo_faturamento)        " +
                                           "             ,  T_VALOR_CUSTO_FATURAMENTO_DIFERENCA     =   Convert(numeric(13,2), x.valorcustopadrao ) - Convert(numeric(13,2), c.ec_valor_custo_faturamento)  " + 
                                           "             ,	T_EC_DATA_ATUALIZACAO_DIA				=	c.ec_data_atualizacao_dia                                   " +
                                           "             ,	T_EC_DATA_ATUALIZACAO_ONLINE			=	c.ec_data_atualizacao_online                                " +
                                           "             ,	T_EC_DTLOG_UPDATE_API					=	c.dtlog_update_api                                          " +
                                           " from		 oxan_adm.dbo.TbProduto				   pr                                                                   " +
                                           " inner join  oxan_ope.dbo.POSTGRE_tbestoquecusto   c on pr.CdProduto = c.pr_cdproduto                                   " +
                                           " inner join  OXAN_OPE.DBO.TbProdutoOperacaoCusto   x on x.cdproduto = pr.cdproduto                                      " +
                                           " where		 pr.StatusProduto = 1 ";
                if (Selecionada_Data_Atualizacao)
                {

                    if (Data_Atualizacao_Online != Convert.ToDateTime("1900-01-01"))
                    {
                        SQL_SERVER_SELECT += string.Format(" AND ISNULL(ec_data_atualizacao_online, '1900-01-01') = '{0}' ", Data_Atualizacao_Online.ToString("yyyy-MM-dd"));
                    }
                }

                if (Seleciona_Custos_diferente)
                {
                    SQL_SERVER_SELECT += " AND (       Convert(numeric(13,2), x.valorcustopadraoatual ) <> Convert(numeric(13,2), c.ec_valor_custo_precificacao)  " +
                                         "        OR   Convert(numeric(13,2), x.valorcustopadrao) <> Convert(numeric(13,2), c.ec_valor_custo_faturamento) )";
                }


                SQL_SERVER_SELECT += " order by	 pr.Descricao asc";

                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SQL_SERVER_SELECT, null, true);

            }
            catch (Exception ex)
            {
                throw new Exception("SQLSERVER SELECT" + ex.Message);
            }

            return DX.Tables[0];


        }
        public static void ProdutoCustoAtualiza(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                string SQL_SQLSERVER = string.Format("EXEC SP_POSTGRE_tbestoquecusto_Atualiza ");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Services.Bll.TEMP.SqlServer.ProdutoCustoAtualiza | " + ex.Message);
            }


        }
    }
}

namespace Pag_Net.Services.Models
{
    public class sistema_nucleo_procedimentos
    {
        //[Display(Name = "Núcleo Cd")]
        public string sis_nucleo_cd_fk { get; set; }
        public string sis_nucleo_prc_ref { get; set; }
        public string sis_nucleo_descricao { get; set; }
        public int sis_nucleo_prc_cd { get; set; }



        public int sis_nucleo_prc_tipo { get; set; }
        public DateTime sis_nucleo_prc_dt_ultima_execucao { get; set; }




        public sistema_nucleo_procedimentos()
        {

        }

        public sistema_nucleo_procedimentos(System.Data.DataRow i)
        {
            string errorString = i[0].ToString();
            try
            {
                sis_nucleo_cd_fk = "0000";
                sis_nucleo_cd_fk = i["sis_nucleo_cd_fk"].ToString();
                sis_nucleo_descricao = i["sis_nucleo_descricao"].ToString();
                sis_nucleo_prc_cd = Convert.ToInt32(i["sis_nucleo_prc_cd"].ToString());
                sis_nucleo_prc_tipo = Convert.ToInt32(i["sis_nucleo_prc_tipo"].ToString());
                sis_nucleo_prc_ref = i["sis_nucleo_prc_ref"].ToString();
                //sis_nucleo_prc_dt_ultima_execucao = Convert.ToDateTime(i["sis_nucleo_prc_dt_ultima_execucao"]);


            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }


    }
    public static class infos
    {
        public static string start_time_service_api_sqlserver()
        {
            string _now = DateTime.Now.ToString("yyyy-MM-dd");
            _now = _now + " 08:01:01";
            return _now;
        }
    }
}

namespace Pag_Net.Services.Models.BD
{
    public static class Postgres
    {
        public static string F9000_15_SistemaNucleoProcedimento_List_Get()
        {
            return F9000_15_SistemaNucleoProcedimento_List_Get(1);
        }
        public static string F9000_15_SistemaNucleoProcedimento_List_Get(int Execucao_Manual)
        {
            return
                string.Format(
                   " select 	ret_sis_nucleo_descricao				        AS 	sis_nucleo_descricao        	            " +
                   "          ,	ret_sis_nucleo_cd_fk		 			        AS	sis_nucleo_cd_fk	    	                " +
                   "          ,	ret_sis_nucleo_prc_cd					        AS	sis_nucleo_prc_cd				            " +
                   "          ,	ret_sis_nucleo_prc_tipo 				        AS	sis_nucleo_prc_tipo 			            " +
                   "          , ret_sis_nucleo_prc_ref                          as  sis_nucleo_prc_ref                          " +
                   " from 	f9000_15_1011950_sistema_nucleo_procedimento_list({0}) ", Execucao_Manual);
        }

    }
}




