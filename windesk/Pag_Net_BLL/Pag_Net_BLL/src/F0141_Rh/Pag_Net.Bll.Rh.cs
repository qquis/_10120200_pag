using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    
    public class Filter
    {


        public int cdparticipante { get; set; }
        public int rh_funcionario_dv { get; set; }
        public string nome { get; set; }
        public string dtm_setor_descricao { get; set;  }
        public string dtm_secao_descricao { get; set; }
        

        public int data_admissao_filtrar { get; set;  }
        public DateTime data_admissao_ini { get; set; }
        public DateTime data_admissao_fim { get; set; }
        public int data_rescicao_filtrar { get; set; }
        public DateTime data_rescisao_ini { get; set; }
        public DateTime data_rescisao_fim { get; set; }
        public int rh_tipo_contrato_cd { get; set;  }
        public int rh_setor_operacional_cd { get; set; }
        
        public int rh_status_ativo { get; set; }
        public int rh_status_inativo { get; set;  }



        public Filter()
        {
            data_admissao_filtrar = 0;
            data_admissao_ini = Convert.ToDateTime("1900-01-01");
            data_admissao_fim = Convert.ToDateTime("1900-01-01");
            
            data_rescicao_filtrar = 0;
            data_rescisao_ini = Convert.ToDateTime("1900-01-01");
            data_rescisao_fim = Convert.ToDateTime("1900-01-01");
            
            rh_tipo_contrato_cd = 0;
            
            rh_setor_operacional_cd = 0;
            
            rh_status_inativo = 0;
            rh_status_ativo = 0;
            nome = "";
            dtm_setor_descricao = "";
            dtm_secao_descricao = "";
        }
    }


    public class WK : INotifyPropertyChanged
    {

        public ModelParticipanteFuncionario[] MyListFuncionarios;
        public ModelParticipanteFuncionario Funcionario_Selecionado;
        public Filter _Filter;

        Pag_Net.Models.modelSistemaUsuario MyConnect;


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbParticipanteList;
        public DBDataTable DbParticipanteList
        {
            get { return __dbParticipanteList; }
            set
            {
                __dbParticipanteList = value;
                RaisePropertyChanged("DbParticipanteList");
            }
        }


        public WK(Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
            _Filter = new Filter();
            MyListFuncionarios = null;
        }

        public void FuncionarioList_Clear()
        {
            MyListFuncionarios = null;
        }

        public void FuncionarioList_Get()
        {
            try
            {
                DbParticipanteList = Pag_Net.Bll.F0141_Rh.Dts.F0141_60_FuncionarioList_Get(MyConnect, _Filter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void MyListFuncionario_Add(ModelParticipanteFuncionario item)
        {
            List<ModelParticipanteFuncionario> Mylist = new List<ModelParticipanteFuncionario>();
            if (MyListFuncionarios != null)
            {
                foreach (ModelParticipanteFuncionario xitem in MyListFuncionarios)
                {
                    Mylist.Add(xitem);
                }
            }

            Mylist.Add(item);
            MyListFuncionarios = Mylist.ToArray();
        }
        public void MylistFuncionario_Update_SetorOperacional()
        {
            string ErroInfo = "";
            try
            {

                int _sis_nucleo_prc_cd = 1103;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;


                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                /*RedShift BlueSoft SELECT */


                _COUNT = this.MyListFuncionarios.Count();
                foreach (ModelParticipanteFuncionario item in this.MyListFuncionarios)
                {


                    _Command_All = _Command_All + item.UpdateScript_Setor_Operacional() + ";";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 5 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "f0011_50_tbparticipante_funcionario_setor_operacional", string.Format("Participante {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("NP0011_03_PessoaBlueSoft | " + ErroInfo + " - " + ex.Message);
            }
        }
    }


    public class WKSalarioContratado : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public bool _orderbyCrecente = false;
        public Filter _Filter;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        /*
        public ModelParticipanteFuncionario[] MyListFuncionarios;
        public ModelParticipanteFuncionario[] MySetorOperacional;
        public ModelParticipanteFuncionario[] MyContrato;
         */ 

        public DBDataTable MyListFuncionarios;
        public DBDataTable MySetorOperacional;
        public DBDataTable MyContrato;
    
       

        public WKSalarioContratado (Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
            _Filter = new Filter();
        }

        public void Get()
        {

            MyListFuncionarios = Pag_Net.Bll.F0141_Rh.Dts.F0141_65_Salario_Contratado_List(MyConnect, "F", _Filter);
            MySetorOperacional = Pag_Net.Bll.F0141_Rh.Dts.F0141_65_Salario_Contratado_List(MyConnect, "S", _Filter);
            MyContrato = Pag_Net.Bll.F0141_Rh.Dts.F0141_65_Salario_Contratado_List(MyConnect, "C", _Filter);
            RaisePropertyChanged("DbParticipanteList");
            
            /*
            DBDataTable DT = Pag_Net.Bll.F0141_Rh.Dts.F0141_65_Salario_Contratado_List(MyConnect, "F", _Filter);

            List<ModelParticipanteFuncionario> List = new List<ModelParticipanteFuncionario>();
            foreach (DataRow i in DT.List.Rows)
            {
                ModelParticipanteFuncionario item = new ModelParticipanteFuncionario();
                item.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                item.funcionario_cd = Convert.ToInt32(i["funcionario_cd"].ToString());
                item.funcionario_cd_dv = Convert.ToInt32(i["funcionario_cd_dv"].ToString());
                item.nome_razao = i["nome_razao"].ToString();
                item.SetorOperacional.rh_setor_operacional_descricao = i["rh_setor_operacional_descricao"].ToString();
                item.TipoContrato.rh_tipo_contrato_descricao = i["rh_tipo_contrato_descricao"].ToString();
                item.rh_vl_folha_brt = Convert.ToDouble(i["rh_vl_folha_brt"].ToString());
                item.rh_vl_pj = Convert.ToDouble(i["rh_vl_pj"].ToString());
                item.rh_vl_outros = Convert.ToDouble(i["rh_vl_outros"].ToString());
                item.rh_vl_contrato_bruto = Convert.ToDouble(i["rh_vl_contrato_bruto"].ToString());
                item.rh_vl_contrato_liq = Convert.ToDouble(i["rh_vl_contrato_liq"].ToString());
                item.rh_vl_folha_liq = Convert.ToDouble(i["rh_vl_folha_liq"].ToString());
                item.rh_vl_pj = Convert.ToDouble(i["rh_vl_pj"].ToString());
                item.rh_vl_outros = Convert.ToDouble(i["rh_vl_outros"].ToString());
                List.Add(item);
            }
            MyListFuncionarios = List.ToArray();

            var ObjSetorOperacional = (from x in List
                          orderby x.rh_setor_operacional_descricao ascending
                          group x by new { x.rh_setor_operacional_descricao } into TabSetor
                          select new { TabSetor.Key.rh_setor_operacional_descricao, 
                                        rh_vl_folha_brt = TabSetor.Sum(a => a.rh_vl_folha_brt),
                                        rh_vl_pj =  TabSetor.Sum(a => a.rh_vl_pj),
                                        rh_vl_outros =  TabSetor.Sum(a => a.rh_vl_outros),
                                        LOCAL_rh_vl_folha_brt_previsao  =  TabSetor.Sum(a => a.LOCAL_rh_vl_folha_brt_previsao),
                                        LOCAL_rh_vl_pj_previsao = TabSetor.Sum(a => a.LOCAL_rh_vl_pj_previsao),
                                        LOCAL_rh_vl_outros = TabSetor.Sum(a => a.LOCAL_rh_vl_outros),
                                        LOCAL_Total_Prev = TabSetor.Sum(a => a.LOCAL_total_prev)
                                        
                          }).ToList();

            List<ModelParticipanteFuncionario> lstSetorOperacional = new List<ModelParticipanteFuncionario>();
            for (int i = 0; i <= ObjSetorOperacional.Count -1; i ++)
            {
                ModelParticipanteFuncionario itemSetorOperacional = new ModelParticipanteFuncionario();
                itemSetorOperacional.SetorOperacional.rh_setor_operacional_descricao = ObjSetorOperacional[i].rh_setor_operacional_descricao;
                itemSetorOperacional.rh_vl_folha_brt = ObjSetorOperacional[i].rh_vl_folha_brt;
                itemSetorOperacional.rh_vl_pj = ObjSetorOperacional[i].rh_vl_pj;
                itemSetorOperacional.rh_vl_outros = ObjSetorOperacional[i].rh_vl_outros;
                lstSetorOperacional.Add(itemSetorOperacional);
            }
            this.MySetorOperacional = lstSetorOperacional.ToArray();



            var objContrato = (from x in List
                          orderby x.rh_setor_operacional_descricao ascending
                          group x by new { x.rh_tipo_contrato_descricao } into TabSetor
                          select new
                          {
                              TabSetor.Key.rh_tipo_contrato_descricao,
                              rh_vl_folha_brt = TabSetor.Sum(a => a.rh_vl_folha_brt),
                              rh_vl_pj = TabSetor.Sum(a => a.rh_vl_pj),
                              rh_vl_outros = TabSetor.Sum(a => a.rh_vl_outros),
                              LOCAL_rh_vl_folha_brt_previsao = TabSetor.Sum(a => a.LOCAL_rh_vl_folha_brt_previsao),
                              LOCAL_rh_vl_pj_previsao = TabSetor.Sum(a => a.LOCAL_rh_vl_pj_previsao),
                              LOCAL_rh_vl_outros = TabSetor.Sum(a => a.LOCAL_rh_vl_outros),
                              LOCAL_Total_Prev = TabSetor.Sum(a => a.LOCAL_total_prev)
                          }).ToList();

            List<ModelParticipanteFuncionario> lstContrato = new List<ModelParticipanteFuncionario>();
            for (int i = 0; i <= objContrato.Count - 1; i++)
            {
                ModelParticipanteFuncionario itemContrato = new ModelParticipanteFuncionario();
                itemContrato.TipoContrato.rh_tipo_contrato_descricao = objContrato[i].rh_tipo_contrato_descricao;
                itemContrato.rh_vl_folha_brt = objContrato[i].rh_vl_folha_brt;
                itemContrato.rh_vl_pj = objContrato[i].rh_vl_pj;
                itemContrato.rh_vl_outros = objContrato[i].rh_vl_outros;
                lstContrato.Add(itemContrato);
            }
            this.MyContrato = lstContrato.ToArray();
            */
            //RaisePropertyChanged("DbParticipanteList");
        }

        public void MyListOrderBy(ModelParticipanteFuncionario[] MyArraylist, string _columnName)
        {
            if (_orderbyCrecente)
            {
                _orderbyCrecente = false;
                switch (_columnName)
                {
                    case "rh_setor_operacional_descricao":
                        MyArraylist = MyArraylist.OrderBy(c => c.rh_setor_operacional_descricao).ToArray();
                        break;
                    case "rh_tipo_contrato_descricao":
                        MyArraylist = MyArraylist.OrderBy(c => c.rh_tipo_contrato_descricao).ToArray();
                        break;
                    case "rh_vl_folha_brt":
                        MyArraylist = MyArraylist.OrderBy(c => c.rh_vl_salario).ToArray();
                        break;
                    case "rh_vl_pj":
                        MyArraylist = MyArraylist.OrderBy(c => c.rh_vl_pj).ToArray();
                        break;
                    case "rh_vl_outros":
                        MyArraylist = MyArraylist.OrderBy(c => c.rh_vl_outros).ToArray();
                        break;
                    case "LOCAL_rh_vl_folha_brt_previsao":
                        MyArraylist = MyArraylist.OrderBy(c => c.LOCAL_rh_vl_folha_brt_previsao).ToArray();
                        break;
                    case "LOCAL_rh_vl_pj_previsao":
                        MyArraylist = MyArraylist.OrderBy(c => c.LOCAL_rh_vl_pj_previsao).ToArray();
                        break;
                    case "LOCAL_rh_vl_outros":
                        MyArraylist = MyArraylist.OrderBy(c => c.LOCAL_rh_vl_outros).ToArray();
                        break;
                    case "LOCAL_total_prev":
                        MyArraylist = MyArraylist.OrderBy(c => c.LOCAL_total_prev).ToArray();
                        break;
                }


            }
            else
            {
                _orderbyCrecente = true;

                switch (_columnName)
                {
                    case "rh_setor_operacional_descricao":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.rh_setor_operacional_descricao).ToArray();
                        break;
                    case "rh_tipo_contrato_descricao":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.rh_tipo_contrato_descricao).ToArray();
                        break;
                    case "rh_vl_folha_brt":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.rh_vl_salario).ToArray();
                        break;
                    case "rh_vl_pj":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.rh_vl_pj).ToArray();
                        break;
                    case "rh_vl_outros":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.rh_vl_outros).ToArray();
                        break;
                    case "LOCAL_rh_vl_folha_brt_previsao":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.LOCAL_rh_vl_folha_brt_previsao).ToArray();
                        break;
                    case "LOCAL_rh_vl_pj_previsao":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.LOCAL_rh_vl_pj_previsao).ToArray();
                        break;
                    case "LOCAL_rh_vl_outros":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.LOCAL_rh_vl_outros).ToArray();
                        break;
                    case "LOCAL_total_prev":
                        MyArraylist = MyArraylist.OrderByDescending(c => c.LOCAL_total_prev).ToArray();
                        break;
                }
            }




        }

    }


    public static class MyGets
    {
        public static TbRh_Tipo_Contrato[] Tipo_Contratos (Pag_Net.Models.modelSistemaUsuario MyConnect, int rh_tipo_contrato_legal)
        {
            try
            {

                List<TbRh_Tipo_Contrato> _TbRh_Tipo_Contrato = new List<TbRh_Tipo_Contrato>();
                DBDataTable DBDataTable_RhTipoContrato = Dts.RhTipoContrato_Get(MyConnect);
                foreach (DataRow i in DBDataTable_RhTipoContrato.List.Rows)
                {
                    TbRh_Tipo_Contrato item = new TbRh_Tipo_Contrato();
                    item.__Binding(i);
                    _TbRh_Tipo_Contrato.Add(item);
                }
                return _TbRh_Tipo_Contrato.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TbRh_Setor_Operacional[] Setor_Operacional(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            List<TbRh_Setor_Operacional> _MyList = new List<TbRh_Setor_Operacional>();
            DBDataTable MyDBDataTable = Dts.RhSetorOperacional_Get(MyConnect);
            foreach (DataRow i in MyDBDataTable.List.Rows)
            {
                TbRh_Setor_Operacional item = new TbRh_Setor_Operacional();
                item.__Binding(i);
                _MyList.Add(item);
            }
            return _MyList.ToArray();
        }

    }

    public static class MyComboBoxList
    {
        public static TbRh_Tipo_Contrato[] Tipo_Contratos(Pag_Net.Models.modelSistemaUsuario MyConnect, int rh_tipo_contrato_legal)
        {
            try
            {

                List<TbRh_Tipo_Contrato> _TbRh_Tipo_Contrato = new List<TbRh_Tipo_Contrato>();
                TbRh_Tipo_Contrato ItemZero = new TbRh_Tipo_Contrato();
                ItemZero.rh_tipo_contrato_cd = 0;
                ItemZero.rh_tipo_contrato_descricao = " * SELECIONE * ";
                _TbRh_Tipo_Contrato.Add(ItemZero);
                
                foreach(TbRh_Tipo_Contrato item in MyGets.Tipo_Contratos(MyConnect, 0))
                {
                    _TbRh_Tipo_Contrato.Add(item);
                }

                
                return _TbRh_Tipo_Contrato.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TbRh_Setor_Operacional[] Setor_Operacional(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            List<TbRh_Setor_Operacional> _MyList = new List<TbRh_Setor_Operacional>();

            TbRh_Setor_Operacional itemZERo = new TbRh_Setor_Operacional();
            itemZERo.rh_setor_operacional_cd = 0;
            itemZERo.rh_setor_operacional_descricao = " * SELECIONE * ";
            _MyList.Add(itemZERo);
            DBDataTable MyDBDataTable = Dts.RhSetorOperacional_Get(MyConnect);
            foreach (TbRh_Setor_Operacional item in MyGets.Setor_Operacional(MyConnect))
            {
                _MyList.Add(item);
            }
            return _MyList.ToArray();
        }

    }

    public static class BD
    {
        public static DataTable DataTable_RhFuncionarioStatusList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, F0141_Rh.F0147_10_RhFuncionarioStatusList filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, filter.sql_Get());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    
 

}
