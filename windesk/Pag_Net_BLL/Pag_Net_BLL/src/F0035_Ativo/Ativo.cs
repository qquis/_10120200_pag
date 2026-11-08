using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0210_Notificacao;
using System.Data;
using Pag_Net.Dal;
using System.ComponentModel;

namespace Pag_Net.Bll.F0035_Ativo
{
    public enum enumTipoMovimentacao
    {
        COMPRA = 10,
        VENDA = 20,
        SAIDA = 30,
        ENTRADA = 40,
        OUTRAS = 90
    }

    public class Filter
    {
        public int at_seq { get; set;  }
        public int at_tipo_cd {get; set;}
        public string at_descricao { get; set; }
        public string list_tipo_cd { get; set;  }
        public string at_veiculo_placa { get; set;  }
        public Filter() { _constructor(); } 
        public Filter(string _list_tipo_cd){_constructor(); list_tipo_cd = _list_tipo_cd; }
        public Filter(int _at_seq) { _constructor(); this.at_seq = _at_seq; }

        public void _constructor()
        {
            at_seq = 0;
            at_tipo_cd = 0;
            at_descricao = "";
            list_tipo_cd = "";
            at_veiculo_placa = "";
        }
    }

    public class WkAtivo : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbAtivos;
        public DBDataTable DbAtivos_List
        {
            get { return __dbAtivos; }
            set
            {
                __dbAtivos = value;
                RaisePropertyChanged("DbAtivos_List");
            }
        }

        private DBDataTable __dbAtivosRegistro;
        public DBDataTable DbAtivosRegistro_List
        {
            get { return __dbAtivosRegistro; }
            set
            {
                __dbAtivosRegistro = value;
                RaisePropertyChanged("DbAtivos_Registro_List");
            }
        }

        public Models.Model_TbAtivo Model_TbAtivo_Selecionado;

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Filter Filtros;
        public WkAtivo(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filtros = new Filter();
            Model_TbAtivo_Selecionado = new Models.Model_TbAtivo();
        }

        public void ativoList_Obter()
        {

            switch (Filtros.at_tipo_cd)
            {
                case 0:
                    DbAtivos_List = Pag_Net.Bll.F0035_Ativo.Dts.F0035_60_AtivoList_Get(MyConnect, Filtros);
                    break;
                case 200:
                    DbAtivos_List = Pag_Net.Bll.F0035_Ativo.Dts.F0035_61_AtivoVeiculoList_Get(MyConnect, Filtros);
                    break;
                default:
                    DbAtivos_List = Pag_Net.Bll.F0035_Ativo.Dts.F0035_60_AtivoList_Get(MyConnect, Filtros);
                    break;
            }


        }
        public void ativoRegistroList_Obter()
        {

            switch (Filtros.at_tipo_cd)
            {
                case 200:
                    DbAtivos_List = Pag_Net.Bll.F0035_Ativo.Dts.F0035_66_AtivoRegistroVeiculoList_Get(MyConnect, Filtros);
                    break;
                default:
                    DbAtivos_List = null;
                    break;
            }


        }
        public Models.Model_TbAtivo ativoList_Selecionar(string at_seq_text_component)
        {
            try
            {
                if (at_seq_text_component == "")
                    throw new Exception("Indique um sequencial Válido");
                Model_TbAtivo_Selecionado = new Models.Model_TbAtivo();
                Model_TbAtivo_Selecionado.at_seq = Convert.ToInt32(at_seq_text_component);
                return Model_TbAtivo_Selecionado;
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public TbAtivoTipo[] tipoAtivos_Obter() { return MyGets.listTipoAtivoGet(MyConnect, Filtros); }
        
        public void ativoNew()
        {
            Model_TbAtivo_Selecionado = new Models.Model_TbAtivo();
        }

    }


    public class WkAtivoVeiculo : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbAtivos;
        public DBDataTable DbAtivosVeiculos_List
        {
            get { return __dbAtivos; }
            set
            {
                __dbAtivos = value;
                RaisePropertyChanged("DbAtivos_List");
            }
        }

        private DBDataTable __dbAtivosRegistro;
        public DBDataTable DbAtivosRegistro_List
        {
            get { return __dbAtivosRegistro; }
            set
            {
                __dbAtivosRegistro = value;
                RaisePropertyChanged("DbAtivos_Registro_List");
            }
        }


        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Filter Filtros;
        public WkAtivoVeiculo(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filtros = new Filter();
            //Model_TbAtivo_Selecionado = new Models.Model_TbAtivo();
        }
        public void ativoList_Obter()
        {
            try
            {
                DbAtivosVeiculos_List = Pag_Net.Bll.F0035_Ativo.Dts.F0035_61_AtivoVeiculoList_Get(MyConnect, Filtros);
            }
            catch (Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex); 
            }

        }
        public void ativoRegistroList_Obter()
        {

            try
            {
                DbAtivosRegistro_List = Pag_Net.Bll.F0035_Ativo.Dts.F0035_66_AtivoRegistroVeiculoList_Get(MyConnect, Filtros);
            }
            catch (Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
            }


        }
       
    }


    public static class MyGets
    {
        public static TbAtivoTipo[] listTipoAtivoGet(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {

            try
            {
                List<TbAtivoTipo> TipoAtivos = new List<TbAtivoTipo>();

                foreach (DataRow Item in Dts.TiposDeAtivos(MyConnect, FILTER).List.Rows)
                {
                    TbAtivoTipo x = new TbAtivoTipo();
                    x.at_tipo_cd = Convert.ToInt32(Item["at_tipo_cd"].ToString());
                    x.at_tipo_descricao = Item["at_tipo_descricao"].ToString();
                    TipoAtivos.Add(x);
                }
                return TipoAtivos.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Models.Model_TbAtivo[] listVeiculoGet(Pag_Net.Models.modelSistemaUsuario MyConnect, string at_veiculo_placa)
        {
            try
            {
                Filter FILTER = new Filter();
                FILTER.at_veiculo_placa = at_veiculo_placa;
                return listVeiculoGet(MyConnect, FILTER);

            }
            catch ( Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
                return null;
            }
        }

        public static Models.Model_TbAtivo[] listVeiculoGet(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {
                DBDataTable Dt =  Dts.F0035_61_AtivoVeiculoList_Get(MyConnect, FILTER);
                List<Models.Model_TbAtivo> List = new List<Models.Model_TbAtivo>();
                foreach (DataRow i in Dt.List.Rows)
                {
                    Models.Model_TbAtivo item = new Models.Model_TbAtivo();
                    item.at_seq = Convert.ToInt32(i["at_seq"].ToString());
                    item.Veiculo.at_veiculo_placa = i["at_veiculo_placa"].ToString();
                    item.at_descricao = i["at_descricao"].ToString();
                    List.Add(item);
                }
                return List.ToArray(); 
            }
            catch (Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
                return null;
            }
        }
        public static Models.Model_TbAtivo VeiculoGet(Pag_Net.Models.modelSistemaUsuario MyConnect, string at_veiculo_placa)
        {
            try
            {
                if (at_veiculo_placa == "")
                    resource.PagException(PagExceptionType.Info, "Informe a placa do veículo");

                Pag_Net.Bll.F0035_Ativo.Filter myAtivoFilter = new Pag_Net.Bll.F0035_Ativo.Filter();
                myAtivoFilter.at_veiculo_placa = at_veiculo_placa;
                Models.Model_TbAtivo Veiculo = listVeiculoGet(MyConnect, myAtivoFilter)[0];

                return Veiculo;

            }
            catch (Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
                return null;
            }
        }

    }



}
