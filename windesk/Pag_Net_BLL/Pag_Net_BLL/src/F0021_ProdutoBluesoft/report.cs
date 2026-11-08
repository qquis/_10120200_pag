using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Pag_Net.src.F0021_ProdutoBluesoft;

namespace Pag_Net.src.F0021_ProdutoBluesoft.reports 
{

    public class _indexReport
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public interfaces.iF0021_ProdutoBlueSoft_filter filtro;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //private DBDataTable __dbList_ProdutoIntegracao;
        //public DBDataTable dbList_ProdutoIntegracao { get { return __dbList_ProdutoIntegracao; } set { __dbList_ProdutoIntegracao = value; RaisePropertyChanged("dbList_ProdutoIntegracao"); } }

        private DBDataTable __dbList_ProdutoBlueSoftTributacao;
        public DBDataTable dbList_ProdutoBlueSoftTributacao { get { return __dbList_ProdutoBlueSoftTributacao; } set { __dbList_ProdutoBlueSoftTributacao = value; RaisePropertyChanged("dbList_ProdutoBlueSoftTributacao"); } }        

        private DBDataTable __dbList_ProdutoBlueSoft;
        public DBDataTable dbList_ProdutoBlueSoft { get { return __dbList_ProdutoBlueSoft; } set { __dbList_ProdutoBlueSoft = value; RaisePropertyChanged("dbList_ProdutoBlueSoft"); } }        
        
        
     
        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filtro = new interfaces.iF0021_ProdutoBlueSoft_filter();

        }


        public void ProdutoBlueSoft_Consultar()
        {
            try
            {
                dbList_ProdutoBlueSoft = reports.DBDataTables.ProdutoBluesoft(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ProdutoBlueSoftTributacao_Consultar()
        {
            try
            {
                dbList_ProdutoBlueSoftTributacao = reports.DBDataTables.ProdutoBluesoftTributacao(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      

        public void FilterClear() 
        {
            filtro._constructor(0);
        }

    }


    public static class ArrayTabs
    {

    }


    public static class DBDataTables 
    {

        public static DBDataTable ProdutoBluesoft(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0021_ProdutoBlueSoft_filter filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_ProdutoBlueSoft.Get(MyConnect, filtro)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static DBDataTable ProdutoBluesoftTributacao(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0021_ProdutoBlueSoft_filter filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_ProdutoBlueSoftTributacao.Get(MyConnect, filtro)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    

    }

}
