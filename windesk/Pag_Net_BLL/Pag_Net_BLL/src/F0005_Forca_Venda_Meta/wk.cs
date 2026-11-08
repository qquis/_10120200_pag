using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pag_Net.src.f0005_forca_venda_meta
{
    public class wk : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbList_Metas;
        public DBDataTable dbList_Metas
        {
            get { return __dbList_Metas; }
            set
            {
                __dbList_Metas = value;
                RaisePropertyChanged("dbList_Metas");
            }
        }

        private DBDataTable __dbList_Metas_Vendedor;
        public DBDataTable dbList_Metas_Vendedor
        {
            get { return __dbList_Metas_Vendedor; }
            set
            {
                __dbList_Metas_Vendedor = value;
                RaisePropertyChanged("dbList_Meta_Vendedor");
            }
        }


        private DBDataTable __dbList_Metas_Composicao;
        public DBDataTable dbList_Metas_Composicao
        {
            get { return __dbList_Metas_Composicao; }
            set
            {
                __dbList_Metas_Composicao = value;
                RaisePropertyChanged("dbList_Meta_Composicao");
            }
        }


        public tbs.tbforca_venda_meta_tipo[] ComboBoxForcaVendaTipo;


        Pag_Net.Models.modelSistemaUsuario MyConnect; 
        public wk (Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            ComboBoxForcaVendaTipo = dataStore.ArrayTabs.ForcaVendaMetaTipoList_Get(MyConnect, true);
        }
        public void ConsultarMetas(int fv_meta_tipo_cd, int competenciacd )
        {
            try
            {
                dbList_Metas = dataStore.DBDataTables.ForcaVendaMetaGet(MyConnect, fv_meta_tipo_cd, competenciacd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarMetasDetalhe(int fv_meta_cd, int fv_meta_composicao_tipo_cd,  int competenciacd, int fv_meta_cdparticipantevendedor)
        {
            try
            {
                ConsultarMetaVendedor(fv_meta_cd, fv_meta_composicao_tipo_cd, competenciacd, fv_meta_cdparticipantevendedor);
                ConsultarComposicoes(fv_meta_cd, fv_meta_composicao_tipo_cd, competenciacd, fv_meta_cdparticipantevendedor);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarMetaVendedor(int fv_meta_cd, int fv_meta_composicao_tipo_cd,  int competenciacd, int fv_meta_cdparticipantevendedor)
        {
            try
            {
                dbList_Metas_Vendedor = dataStore.DBDataTables.ForcaVendaMetaVendedorGet(MyConnect, fv_meta_cd, fv_meta_cdparticipantevendedor); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public void ConsultarComposicoes(int fv_meta_cd, int fv_meta_composicao_tipo_cd, int competenciacd, int fv_meta_cdparticipantevendedor)
        {
            try
            {

                dbList_Metas_Composicao = dataStore.DBDataTables.ForcaVendaMetaComposicao(MyConnect, fv_meta_composicao_tipo_cd, fv_meta_cd, fv_meta_cdparticipantevendedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
