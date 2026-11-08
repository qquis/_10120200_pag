using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.reports 
{

    public class _indexReport
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public interfaces.iF0020_Produto_filter filtro;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //private DBDataTable __dbList_ProdutoIntegracao;
        //public DBDataTable dbList_ProdutoIntegracao { get { return __dbList_ProdutoIntegracao; } set { __dbList_ProdutoIntegracao = value; RaisePropertyChanged("dbList_ProdutoIntegracao"); } }


        private DBDataTable __dbList_Produto;
        public DBDataTable dbList_Produto { get { return __dbList_Produto; } set { __dbList_Produto = value; RaisePropertyChanged("dbList_Produto"); } }        
        
        
        private DBDataTable __dbList_ZanthusMercadoria;
        public DBDataTable dbList_ZanthusMercadoria { get { return __dbList_ZanthusMercadoria; } set { __dbList_ZanthusMercadoria = value; RaisePropertyChanged("dbList_ZanthusMercadoria"); } }


        private DBDataTable __dbList_ZanthusRegraICMS;
        public DBDataTable dbList_ZanthusRegraICMS { get { return __dbList_ZanthusRegraICMS; } set { __dbList_ZanthusRegraICMS = value; RaisePropertyChanged("dbList_ZanthusRegraICMS"); } }


        private DBDataTable __dbList_ZanthusMercadoriaTipoVenda;
        public DBDataTable dbList_ZanthusMercadoriaTipoVenda { get { return __dbList_ZanthusMercadoriaTipoVenda; } set { __dbList_ZanthusMercadoriaTipoVenda = value; RaisePropertyChanged("dbList_ZanthusMercadoriaTipoVenda"); } }

        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filtro = new interfaces.iF0020_Produto_filter();

        }


        public void Produto_Consultar()
        {
            try
            {
                dbList_Produto = reports.DBDataTables.Produto(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Produto_ZanthusMercadoriaConsultar()
        {
            try
            {
                dbList_ZanthusMercadoria = reports.DBDataTables.Zanthus_Mercadoria(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Produto_ZanthusMercadoriaRegraICMSConsultar(string preg_cdbarra)
        {
            try
            {
                if (preg_cdbarra != "")
                {
                    filtro.preg_cdbarra = preg_cdbarra.Trim();
                }
                dbList_ZanthusRegraICMS = reports.DBDataTables.Zanthus_RegraICMS(MyConnect, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Produto_ZanthusMercadoriaTipoVendaConsultar(string preg_cdbarra)
        {
            try
            {
                if (preg_cdbarra != "")
                {
                    filtro.preg_cdbarra = preg_cdbarra.Trim();
                }
                dbList_ZanthusMercadoriaTipoVenda= reports.DBDataTables.Zanthus_MercadoriaTipoVenda(MyConnect, filtro);
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

        //public static DBDataTable ProdutoIntegracao(Pag_Net.Models.TbSysUserInfo MyConnect, interfaces.iF0020_Produto_filter filtro)
        //{
        //    try { return BDCommand.DBDataTableGet(MyConnect, scripts.report_ProdutoIntegracao.Get(MyConnect, filtro)); }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}


        public static DBDataTable Produto(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0020_Produto_filter filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_Produto.Get(MyConnect, filtro)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static DBDataTable Zanthus_Mercadoria(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0020_Produto_filter filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_Produto_Zanthus_Mercadoria.Get(MyConnect, filtro)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static DBDataTable Zanthus_RegraICMS(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0020_Produto_filter filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_Produto_Zanthus_RegraIcms.Get(MyConnect, filtro)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static DBDataTable Zanthus_MercadoriaTipoVenda(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.iF0020_Produto_filter filtro)
        {
            try { return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_Produto_Zanthus_MercadoriaTipoVenda.Get(MyConnect, filtro)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }

}
