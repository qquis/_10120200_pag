using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0095_Integracao
{
    public class _indexReport
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;



        public int filtroIntegracao; 
        public interfaces.iF0095_IntegracaoProduto_filter filtroIntegracaoProduto; 

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public tbs.TbIntegracao[] Integracoes;
        public tbs.TbIntegracaoTipo[] IntegracoesTipo;
        public tbs.TbIntegracaoStatus[] IntegracoesStatus;
        

        private DBDataTable __dbList_IntegracaoProduto;
        public DBDataTable dbList_IntegracaoProduto { 
                get { return __dbList_IntegracaoProduto; } 
                set { __dbList_IntegracaoProduto = value; 
                        RaisePropertyChanged("dbList_IntegracaoProduto"); } }


        private DBDataTable __dbList_IntegracaoTipoInfo;
        public DBDataTable dbList_IntegracaoTipoInfo { 
                get { return __dbList_IntegracaoTipoInfo; } 
                set { __dbList_IntegracaoTipoInfo = value; 
                    RaisePropertyChanged("dbList_IntegracaoTipoInfo"); } }


        private DBDataTable __dbList_IntegracaoLancamento;
        public DBDataTable dbList_IntegracaoLancamento { 
                get { return __dbList_IntegracaoLancamento; } 
                set { __dbList_IntegracaoLancamento = value; 
                    RaisePropertyChanged("dbList_IntegracaoLancamento"); } }


        public void filtroIntegracaoProdutoClear()
        {
            filtroIntegracaoProduto.integracao_status_cd = 0;
            filtroIntegracaoProduto.integracao_cd = 0;
            filtroIntegracaoProduto.integracao_tipo_cd = 0;
            filtroIntegracaoProduto.pr_cdproduto = 0;
            filtroIntegracaoProduto.prb_cdprodutoBluesfotUnitario = 0;
            filtroIntegracaoProduto.prb_cdprodutoBlueSoft = 0;
        }

        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect) { _constructor(_MyConnect, 0); }
        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect, int integracao_cd) { _constructor(_MyConnect, 0); }


        private void _constructor(Pag_Net.Models.modelSistemaUsuario _MyConnect, int integracao_cd) 
        {
            MyConnect = _MyConnect;
            filtroIntegracaoProduto = new interfaces.iF0095_IntegracaoProduto_filter();
            filtroIntegracao = integracao_cd;
            IntegracoesStatusGet();
            IntegracoesGet(integracao_cd);
            IntegracoesTipoGet(integracao_cd);
        }


        public void ProdutoIntegracaoConsultar()
        {
            try
            {
                dbList_IntegracaoProduto = DBDataTables.ProdutoIntegracao(MyConnect, filtroIntegracaoProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void IntegracoesLancamento()
        {
            try
            {
                dbList_IntegracaoLancamento = DBDataTables.IntegracoesLancamento(MyConnect, filtroIntegracaoProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void IntegracoesGet(int integracao_cd)
        {
            try
            {
                this.Integracoes = ArrayTabs.Integracoes(MyConnect, integracao_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void IntegracoesTipoGet(int integracao_cd)
        {
            try
            {
                this.IntegracoesTipo = ArrayTabs.IntegracoesTipo(MyConnect, integracao_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void IntegracoesStatusGet()
        {
            try
            {
                this.IntegracoesStatus = ArrayTabs.IntegracoesStatus(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void IntegracaoTipoInfoGet(int integracao_tipo_cd, int sis_batch_cd)
        {
            try
            {
                this.dbList_IntegracaoTipoInfo = DBDataTables.IntegracoesTipoInfo(MyConnect, 0,integracao_tipo_cd, sis_batch_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

    public static class ArrayTabs
    {
        public static tbs.TbIntegracao[] Integracoes(Pag_Net.Models.modelSistemaUsuario MyConnect, int integracao_cd)
        {
            try
            {
                List<tbs.TbIntegracao> mylist = new List<tbs.TbIntegracao>();
                foreach (DataRow i in DBDataTables.Integracoes(MyConnect, integracao_cd).List.Rows)  
                {
                    tbs.TbIntegracao item = new tbs.TbIntegracao();
                    item.__Binding(i);
                    mylist.Add(item);

                }

                return mylist.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static tbs.TbIntegracaoStatus[] IntegracoesStatus(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                List<tbs.TbIntegracaoStatus> mylist = new List<tbs.TbIntegracaoStatus>();

                tbs.TbIntegracaoStatus itemNull = new tbs.TbIntegracaoStatus();
                itemNull.integracao_status_descricao = "* TODOS *";
                mylist.Add(itemNull);

                foreach (DataRow i in DBDataTables.IntegracoesStatus(MyConnect).List.Rows)
                {
                    tbs.TbIntegracaoStatus item = new tbs.TbIntegracaoStatus();
                    item.__Binding(i);
                    mylist.Add(item);

                }

                return mylist.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static tbs.TbIntegracaoTipo[] IntegracoesTipo(Pag_Net.Models.modelSistemaUsuario MyConnect, int integracao_cd)
        {
            try
            {
                List<tbs.TbIntegracaoTipo> mylist = new List<tbs.TbIntegracaoTipo>();
                
                tbs.TbIntegracaoTipo itemNULL = new tbs.TbIntegracaoTipo();
                itemNULL.integracao_tipo_descricao = "* TODOS * ";
                mylist.Add(itemNULL); 


                foreach (DataRow i in DBDataTables.IntegracoesTipo(MyConnect, integracao_cd).List.Rows)
                {
                    tbs.TbIntegracaoTipo item = new tbs.TbIntegracaoTipo();
                    item.__Binding(i);
                    mylist.Add(item);

                }

                return mylist.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    public static class DBDataTables
    {

        public static DBDataTable Integracoes(Pag_Net.Models.modelSistemaUsuario MyConnect, int integracao_cd)
        {
            try
            {
                string sql = "select integracao_cd " + 
                             "     , integracao_descricao " + 
                             " from  tbintegracao         " +  
                             " where 1 = 1 " + 
                             (integracao_cd > 0 ? " integracao_cd = " + integracao_cd.ToString() : "").ToString() + 
                             " order by integracao_descricao asc "; 
                return BDCommand.DBDataTableGet(MyConnect, sql); 
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DBDataTable IntegracoesStatus(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                string sql = "select integracao_status_cd " +
                             "     , integracao_status_descricao " +
                             " from  tbintegracao_status         " +
                             " order by integracao_status_descricao desc";
                return BDCommand.DBDataTableGet(MyConnect, sql);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DBDataTable IntegracoesTipo(Pag_Net.Models.modelSistemaUsuario MyConnect, int integracao_cd)
        {
            try
            {
                string sql = "select integracao_cd " +
                             "     , integracao_tipo_cd " +
                             "     , integracao_tipo_descricao " +
                             "     , coalesce(zanthus,0) as zanthus " +
                             "     , coalesce(bluesoft_redshift,0) as bluesoft_redshift  " +
                             "     , coalesce(bluesoft_api,0) as bluesoft_api " +
                             "     , coalesce(tipo_export,0) as tipo_export " +
                             "     , coalesce(tipo_import,0) as tipo_import" +
                             " from  tbintegracao_tipo         " +
                             " where 1 = 1 " +
                             (integracao_cd > 0 ? " integracao_cd = " + integracao_cd.ToString() : "").ToString() +
                             " order by integracao_tipo_descricao asc ";
                return BDCommand.DBDataTableGet(MyConnect, sql);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public static DBDataTable IntegracoesTipoInfo(Pag_Net.Models.modelSistemaUsuario MyConnect, int integracao_cd, int integracao_tipo_cd, int sis_batch_cd)
        {
            try
            {
                string sql = "select 		t.integracao_tipo_cd " +
                             "          ,	t.integracao_tipo_descricao " +
                             "          ,	bs.sis_batch_service_cd " +
                             "          ,	bs.sis_batch_service_descricao " +
                             "          ,	bt.module_cd " +
                             "          ,	bt.sis_batch_service_cd " +
                             "          ,	bt.sis_batch_cd " +
                             "          ,	bt.sis_batch_descricao " +
                             "          ,	i.script_select " +
                             "  from 		tbintegracao_tipo_info i " +
                             "  inner join 	tbintegracao_tipo t on t.integracao_tipo_cd = i.integracao_tipo_cd " +
                             "  inner join  tbsistema_batch bt on bt.sis_batch_cd = i.sis_batch_cd " +
                             "  inner join  tbsistema_batch_service bs on bs.sis_batch_service_cd = bt.sis_batch_service_cd " +
                             "  where 1 = 1 "  +
                             (integracao_tipo_cd > 0 ? " and t.integracao_tipo_cd = " + integracao_tipo_cd.ToString() : "").ToString() + 
                             (sis_batch_cd > 0 ? " and bt.sis_batch_cd = " + sis_batch_cd.ToString() : "").ToString();
                return BDCommand.DBDataTableGet(MyConnect, sql);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DBDataTable IntegracoesLancamento(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0095_IntegracaoProduto_filter filtro)
        {
            try
            {
                string sql = "select 		a.dtlog_insert 	" +
                             "          ,	a.integracao_lancamento_seq 	" +
                             "          ,	a.integracao_tipo_cd  	" +
                             "          ,	a.integracao_produto_seq  	" +
                             "          ,	a.integracao_descricao  	" +
                             "          ,	a.sis_log_seq 	" +
                             "          ,	coalesce(l.sis_nucleo_prc_cd) as sis_nucleo_prc_cd 	" +
                             "          ,	coalesce(l.sis_log_tag) as sis_log_tag 	" +
                             "          ,	coalesce(l.sis_log_info) as sis_log_info 	" +
                             "          ,	coalesce(l.uuid) as uuid 	" +
                             "          ,	coalesce(l.uuid_start) as uuid_start 	" +
                             "  from 		tbintegracao_lancamento a 	" +
                             "  left join   tbsistema_log l on l.sis_log_seq = a.sis_log_seq  	" +
                             "  where		1 = 1 	" +
                             "  and			a.integracao_produto_seq = " + filtro.integracao_produto_seq.ToString();

                return BDCommand.DBDataTableGet(MyConnect, sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DBDataTable ProdutoIntegracao(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0095_IntegracaoProduto_filter filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.f0095_10_report_integracaoProduto.Get(MyConnect, filtro)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }




    }
}
