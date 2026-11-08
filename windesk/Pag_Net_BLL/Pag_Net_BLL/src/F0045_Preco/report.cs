using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0045_Preco.reports
{

    public class _indexReport
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public interfaces.iFiltroPrecoListagem filtro;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbList_PrecoListagem;
        public DBDataTable dbList_PrecoListagem { get { return __dbList_PrecoListagem; } set { __dbList_PrecoListagem = value; RaisePropertyChanged("dbList_PrecoListagem"); } }


        private DBDataTable __dbList_PrecoListagemAgendamento;
        public DBDataTable dbList_PrecoListagemAgendamento { get { return __dbList_PrecoListagemAgendamento; } set { __dbList_PrecoListagemAgendamento = value; RaisePropertyChanged("dbList_PrecoListagemAgendamento"); } }


        private DBDataTable __dbList_PrecoLog;
        public DBDataTable dbList_PrecoLog { get { return __dbList_PrecoLog; } set { __dbList_PrecoLog = value; RaisePropertyChanged("dbList_PrecoLog"); } }

        private DBDataTable __dbList_PrecoAplicacaoLoteList;
        public DBDataTable dbList_PrecoAplicacaoLoteList { get { return __dbList_PrecoAplicacaoLoteList; } set { __dbList_PrecoAplicacaoLoteList = value; RaisePropertyChanged("dbList_PrecoAplicacaoLoteList"); } }


        public void PrecoListagemConsultar()
        {
            try
            {
                dbList_PrecoListagem = reports.DBDataTables.PrecoListagemConsultar(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void PrecoAgendamentoListagemConsultar()
        {
            try
            {
                dbList_PrecoListagemAgendamento = reports.DBDataTables.PrecoAgendamentoListagem(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PrecoLogConsultar()
        {
            try
            {
                dbList_PrecoLog = reports.DBDataTables.PrecoLog(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PrecoAplicacaoLoteListConsultar()
        {
            try
            {
                dbList_PrecoAplicacaoLoteList = reports.DBDataTables.PrecoAplicacaoLoteListGet(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void filterClear()
        {
            filtro = new interfaces.iFiltroPrecoListagem();
        }

        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            
        }
    }


    public static class ArrayTabs
    {

    }


    public static class DBDataTables 
    {

        public static DBDataTable TabelaPreco(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.f0045_10_Report_TabelaPreco.Get()); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static DBDataTable PrecoListagemConsultar(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iFiltroPrecoListagem filtro)
        {
            try {return BDCommand.DBDataTableGet(MyConnect, scripts.f0045_50_Report_PrecoListagem.Get(filtro)); } catch (Exception ex) { throw new Exception(ex.Message);}
        }
        public static DBDataTable PrecoAgendamentoListagem(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iFiltroPrecoListagem filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.f0045_50_Report_PrecoAgendamentoListagem.Get(filtro));} catch (Exception ex) {throw new Exception(ex.Message); }
        } 
        public static DBDataTable PrecoLog(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iFiltroPrecoListagem filtro)
        {
            try {return BDCommand.DBDataTableGet(MyConnect, scripts.f0045_52_Report_PrecoLog.Get(filtro));} catch (Exception ex) {throw new Exception(ex.Message);}
        }

        public static DBDataTable PrecoAplicacaoLoteListGet(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                string sql = "select 		l.data_processamento " +
                             "           ,	l.prd_cddepartamento " +
                             "           ,	l.prd_descricao " +
                             "           ,	l.prs_cdsecao " +
                             "           ,	l.prs_descricao " +
                             "           ,	l.prg_cdgrupo " +
                             "           ,	l.prg_descricao " +
                             "           ,	coalesce(l.qtde_produto,0) as qtde_produto " +
                             "           ,	coalesce(i.qtde_produto,0) as qtde_produto_registrados  " +
                             "           ,	coalesce(i.qtde_produto_processado,0) as qtde_produto_processados  " +
                             "           ,	coalesce(i.qtde_registros_unitarios,0) as qtde_produto_embalagem " +
                             "   from   		tbpreco_aplicacao_lote l " +
                             "   left join   ( 	select      sg.prg_cdgrupo " +
                             "                           ,	lp.data_processamento " +
                             "                           ,	count(distinct(lp.pr_cdproduto)) qtde_produto " +
                             "                           ,	count(distinct(case when lp.processado = 1 then lp.pr_cdproduto else null end )) qtde_produto_processado  " +
                             "                           ,	count(*) qtde_registros_unitarios " +
                             "                   from 		tbpreco_aplicacao_lote_produto lp " +
                             "                   inner join  tbproduto 				pr on pr.pr_cdproduto = lp.pr_cdproduto  " +
                             "                   inner join  tbproduto_subgrupo 	sg on sg.prsg_cdsubgrupo = pr.prsg_cdsubgrupo " +
                             "                   group by 	sg.prg_cdgrupo " +
                             "                           ,	lp.data_processamento " +
                             "                ) i on i.prg_cdgrupo = l.prg_cdgrupo " + 
                             " order by 1, 3, 5, 7" ;
                return BDCommand.DBDataTableGet(MyConnect, sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }
    }

}
