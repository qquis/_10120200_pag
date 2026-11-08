using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0012_GrupoEconomico;

namespace Pag_Net.Bll.F0012_GrupoEconomico
{

    public class Filter
    {
      
        public int	    cdgrupoeconomico 			            {get;set;}
		public string	descricao    					        {get;set;}
        public int      johnson_cliente_top { get; set; }
        public int      grupoeconomico_status { get; set; }

        public Filter()
        {

            cdgrupoeconomico = 0;   
            descricao	    = "";
            johnson_cliente_top = 0;
            grupoeconomico_status = 1;
        }


    }

    public class Wk : INotifyPropertyChanged
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Filter Filtros;
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private ModelGrupoEconomico[] __DbModelGrupoEconomicoList;
        public ModelGrupoEconomico[] DbModelGrupoEconomicoList
        {
            get { return __DbModelGrupoEconomicoList; }
            set
            {
                __DbModelGrupoEconomicoList = value;
                RaisePropertyChanged("DbModelGrupoEconomicoList");
            }
        }

        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filtros = new Filter();
        }

        public void GrupoEconomicoList_Get()
        {
            try
            {
                DbModelGrupoEconomicoList = MyGets.GrupoEconomicoList_Get(MyConnect, Filtros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class MyGets
    {

        public static ModelGrupoEconomico[] GrupoEconomicoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            Filter FILTRO = new Filter();
            return GrupoEconomicoList_Get(MyConnect, FILTRO, null);
        }

        public static ModelGrupoEconomico[] GrupoEconomicoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTRO)
        {
            return GrupoEconomicoList_Get(MyConnect, FILTRO, null);
        }

        public static ModelGrupoEconomico[] GrupoEconomicoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTRO, ModelGrupoEconomico ItemNull)
        {
            try
            {
                DBDataTable _DataTable = Dts.F0012_60_GrupoEconomicoList_Get(MyConnect, FILTRO);
                List<ModelGrupoEconomico> _GrupoEconomico_List = new List<ModelGrupoEconomico>();

                if (ItemNull != null)
                {
                    _GrupoEconomico_List.Add(ItemNull);
                }


                foreach (DataRow i in _DataTable.List.Rows)
                {

                    ModelGrupoEconomico item = new ModelGrupoEconomico();
                    item.__Binding(i);
                    _GrupoEconomico_List.Add(item);
                }
                return _GrupoEconomico_List.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class ComboBox
    {
        public static  ModelGrupoEconomico[] GrupoEconomico(Pag_Net.Models.modelSistemaUsuario MyConnect, int tipo_cliente_top)
        {
            try
            {
                Filter FILTRO = new Filter();
                FILTRO.johnson_cliente_top = tipo_cliente_top;
                ModelGrupoEconomico ITEM0 = new ModelGrupoEconomico();
                ITEM0.cdgrupoeconomico = 0;
                ITEM0.descricao = "* TODOS *";
                ITEM0.descricaoresumida = "* TODOS * ";
                ITEM0.referencia = "* TODOS *";
                return MyGets.GrupoEconomicoList_Get(MyConnect, FILTRO, ITEM0);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    
}
