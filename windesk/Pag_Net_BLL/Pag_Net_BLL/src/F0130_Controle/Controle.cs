using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{

    public class Filter
    {
        public int controle_cd {get; set;}
        public int controle_fila_cd {get; set;} 
        public int controle_reg_seq {get; set;} 
        public int controle_reg_fila_seq {get; set;} 
        public DateTime controle_reg_data_inicial {get; set;} 
        public DateTime controle_reg_data_final {get; set; }
        public string controle_etapa_cd_list {get; set; }
        public int controle_status_cd { get; set;  }

        public Filter()
        {
            this.controle_cd = 0;
            this.controle_fila_cd = 0;
            this.controle_reg_seq = 0;
            this.controle_reg_fila_seq = 0;
            this.controle_reg_data_inicial = DateTime.Now;
            this.controle_reg_data_final = DateTime.Now;
            this.controle_etapa_cd_list = "";
            this.controle_status_cd = 0;
        }
    }
    
    public abstract class iWK_Controle
    {
       

        public model_controle[] Tipos;

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public iWK_Controle(Pag_Net.Models.modelSistemaUsuario _MyConnect, int _TipoCONTROLE)
        {
            MyConnect = _MyConnect;
            TiposControle_Get(_TipoCONTROLE);

        }
        

        /*Virtual Methods ----------------------------------------------------------------------------------------*/
        public virtual void Binding() { }
        public virtual void Save() { }

        /*Get ----------------------------------------------------------------------------------------------------*/
        public model_controle[] TiposControle_Get(int Controle_cd)
        {

            try
            {
                DataTable _DataTableCONTROLES = BDCommand.get_DataTable(MyConnect, F0130_01_Controle_Consultar.Get(MyConnect, Controle_cd));
                List<model_controle> _List_CONTROLES = new List<model_controle>();
                if (_DataTableCONTROLES.Rows.Count > 0)
                {
                    if (_DataTableCONTROLES.Rows.Count >1)
                        _List_CONTROLES.Add(new model_controle(0, "SELECIONE O CONTROLE"));

                    foreach (DataRow i in _DataTableCONTROLES.Rows)
                    {
                        _List_CONTROLES.Add(new model_controle(i));
                    }
                    Tipos = _List_CONTROLES.ToArray();
                    return Tipos;
                }
                else
                {
                    throw new Exception("Tipos de CONTROLES Não CADASTRADOS | Favor acionar o SUPORTE");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public model_controle_reg_pessoa[] PessoasList_Get(Pag_Net.Bll.F0130_Controle.model_controle_reg CONTROLE_REG, int controle_pessoa_cd, string cpf_cnpj_relacional_filter)
        {
            try
            {
                    List<model_controle_reg_pessoa> _ListPessoas = new List<model_controle_reg_pessoa>();
                    DataTable DataTable_ListPessoas = BDCommand.get_DataTable(MyConnect, 
                        F0130_Controle.F0130_53_Controle_Reg_Pessoa_Consultar.Post(
                                MyConnect,
                                CONTROLE_REG.controle_reg_seq, 
                                controle_pessoa_cd, 
                                cpf_cnpj_relacional_filter
                                ));
                    foreach (DataRow i in DataTable_ListPessoas.Rows)
                    {
                        _ListPessoas.Add(new model_controle_reg_pessoa(i));
                    }
                    DataTable_ListPessoas.Dispose();
                    return _ListPessoas.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("PAG Error | Informe o Suporte Administrativo. \n Pag_Net.Bll.Controle.cs | PagNet.IWk_Controle: \n" + ex.Message);
            }
        }
    }


    public class Wk : INotifyPropertyChanged
    {
        public Filter __Filtro;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbList;
        public DBDataTable dbList
        {
            get { return __dbList; }
            set
            {
                __dbList = value;
                RaisePropertyChanged("DbParticipanteList");
            }
        }
        public enum ControleTipoAtendimentos
        {
            Portaria = 0,
            Recebimento = 1

        }

        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public model_controle[] ControleTipos;
        public model_controle_reg CONTROLE_REG;

        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            CONTROLE_REG = new model_controle_reg(0);
            MyConnect = _MyConnect;
            __Filtro = new Filter();
        }

        public tbcontrole_status[] ControleStatusList_Get(F0130_09_Controle_Status_Consultar.filter filtro)
        {
            DataTable Dt_Controle_Status = F0130_09_Controle_Status_Consultar.PostGre.Get(MyConnect,filtro);
            List<tbcontrole_status> _list = new List<tbcontrole_status>();
            foreach (DataRow item in Dt_Controle_Status.Rows)
            {
                _list.Add(new tbcontrole_status(item));
            }
            Dt_Controle_Status.Dispose();
            return _list.ToArray();
        }
        public model_controle[] ControleTiposList_Get(int Controle_cd)
        {

            try
            {
                DataTable _DataTableCONTROLES = BDCommand.get_DataTable(MyConnect, F0130_01_Controle_Consultar.Get(MyConnect, Controle_cd));
                List<model_controle> _List_CONTROLES = new List<model_controle>();
                if (_DataTableCONTROLES.Rows.Count > 0)
                {
                    _List_CONTROLES.Add(new model_controle(0, "SELECIONE O CONTROLE"));
                    foreach (DataRow i in _DataTableCONTROLES.Rows)
                    {
                        _List_CONTROLES.Add(new model_controle(i));
                    }
                    ControleTipos = _List_CONTROLES.ToArray();
                    return ControleTipos;
                }
                else
                {
                    throw new Exception("Tipos de CONTROLES Não CADASTRADOS | Favor acionar o SUPORTE");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
 
        public void ControleRegList_Get(ControleTipoAtendimentos Atendimentos)
        {
            try
            {
                try
                {
                    if (Atendimentos == ControleTipoAtendimentos.Portaria)
                    {
                        __Filtro.controle_etapa_cd_list = "10004, 10008, 10009, 15003, 15005, 12003, 12004";
                    }

                    if (Atendimentos == ControleTipoAtendimentos.Recebimento)
                    {
                        __Filtro.controle_etapa_cd_list = "10003, 10005, 10006, 10007";
                    }
                    ControleRegList_Get();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ControleRegList_Get()
        {
            try
            {
                dbList = Dts.F0130_60_Controle_Reg_List_Get(MyConnect, __Filtro);

            }
            catch (Exception ex)
            {
                throw new Exception("\n" + "ControleRegList_Get: " + ex.Message + "\n");
            }
        }
    }
 
   
    /*Classes Modelos*/








}
