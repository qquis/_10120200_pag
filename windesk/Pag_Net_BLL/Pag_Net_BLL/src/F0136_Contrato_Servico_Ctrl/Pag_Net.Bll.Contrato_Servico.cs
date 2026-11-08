using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0136_Contrato_Servico;

namespace Pag_Net.Bll.F0136_Contrato_Servico
{
    public class WKContrato_Servico
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public F0136_30_Contrato_Servico_List Contrato_Servico_List_Filter;


        public WKContrato_Servico (Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
            Contrato_Servico_List_Filter = new F0136_30_Contrato_Servico_List();
        }

        public model_Contrato_Servico[] Contrato_Servico_List_Get()
        {
            
            List<model_Contrato_Servico> Listmodel_Contrato_Servico = new List<model_Contrato_Servico>();

            foreach (DataRow i in BD.Contrato_Servico_List_DataTable_Get(MyConnect, Contrato_Servico_List_Filter).Rows)
            {
                Listmodel_Contrato_Servico.Add(new model_Contrato_Servico(i));
            }
            return Listmodel_Contrato_Servico.ToArray();
        }

    }
    public class WKContrato_Servico_Ctrl : Pag_Net.Bll.F0130_Controle.iWK_Controle
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public model_Contrato_Servico[] Contrato_Servico_Ctrl_List;
        public model_Contrato_Servico_Ctrl Contrato_Servico_Ctrl;
        public Pag_Net.Bll.F0137_CartaoAcesso.Wk WKCartaoAcesso;
        
        
        public WKContrato_Servico_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect)
            : base(_MyConnect, 15)
        {
            MyConnect = _MyConnect;
            WKCartaoAcesso = new F0137_CartaoAcesso.Wk(MyConnect);
            Contrato_Servico_Ctrl = new model_Contrato_Servico_Ctrl();
            ContratoServicoFornecedorList_Publish();
        }

        public void ContratoServicoTecnicoCartaoAcesso_Set(F0137_CartaoAcesso.model_cartao_acesso __ModelCartaoAcesso) 
        {
            try
            {
                if (__ModelCartaoAcesso.cartao_acesso_seq != 0)
                    this.Contrato_Servico_Ctrl.Tecnico.CartaoAcesso = __ModelCartaoAcesso;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ContratoServicoFornecedorList_Publish()
        {
            List<model_Contrato_Servico> Listmodel_Contrato_Servico = new List<model_Contrato_Servico>();

            Listmodel_Contrato_Servico.Add(new model_Contrato_Servico());
            foreach (DataRow i in BD.Contrato_Servico_List_DataTable_Get(MyConnect, new F0136_30_Contrato_Servico_List("","","",0,1)).Rows)
            {
                Listmodel_Contrato_Servico.Add(new model_Contrato_Servico(i));
            }
            Contrato_Servico_Ctrl_List = Listmodel_Contrato_Servico.ToArray();
        }

    }
  

    public static class BDBlueSoft_Import
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            string ErroEtapaInfo = "";
            try
            {
                int _sis_nucleo_prc_cd = 60;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);


      
                /*--- DOCUMENTO FISCAL ------------------------------------------------ */
                ErroEtapaInfo = "Documento Fiscal";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DATASET_Contrato_Servico = new DataSet();

                DATASET_Contrato_Servico = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, F0136_01_Contrato_Servico_CRUD.RedShift_Select(), "");

                _COUNT = DATASET_Contrato_Servico.Tables[0].Rows.Count;

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "CONTRATO SERVICO", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DATASET_Contrato_Servico.Tables[0].Rows)
                {
                    ErroInfo = "CONTRATO SERVICO SEQ: " + dr[3].ToString();
                    try
                    {
                        _Command_All = _Command_All + F0136_01_Contrato_Servico_CRUD.Post(MyConnect,  Models.BDCommandTypes.DBINSERT, new TbContrato_Servico(dr) ) + " ; ";
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT )
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "CONTRATO SERVICO", string.Format("Contrato Serv REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0; 
                    }
                }
                DATASET_Contrato_Servico.Dispose();



                /*---------------------------------*/
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("CONTRATO SERVICO " + ErroEtapaInfo +  " Erro: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
    public static class BD
    {
        public static DataTable Contrato_Servico_List_DataTable_Get(
           Pag_Net.Models.modelSistemaUsuario MyConnect,
           F0136_30_Contrato_Servico_List _f0136_02_Contrato_Servico_List)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, _f0136_02_Contrato_Servico_List.sql_Get());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }



    public class model_Contrato_Servico: TbContrato_Servico
    {
        public string nome_razao { get; set;  }
        public string cpf_cnpj { get; set; }
        public string local_contrato_servico_permite_execucao
        {
            get
            {
                return base.contrato_servico_permite_execucao == 1 ? "Sim" : "Não";
            }
        }

        public bool local_bool_contrato_servico_permite_execucao
        {
            get
            {
                return base.contrato_servico_permite_execucao == 1 ? true  : false;
            }
        }

        public model_Contrato_Servico (DataRow i): base(i)
        {
            
            nome_razao = i["nome_razao"].ToString();
            cpf_cnpj = i["cpf_cnpj"].ToString();
        }

        public model_Contrato_Servico() : base ()
        {
            contrato_servico_seq = 0;
            contrato_bluesoft_seq = 0;
            contrato_servico_descritivo = "Selecione o Contrato";
        }

        public void Binding(Pag_Net.Models.modelSistemaUsuario MyConnect )
        {
            DataTable dataTableContratoServico =  BDCommand.get_DataTable(MyConnect, new  F0136_30_Contrato_Servico_List("", "", "", this.contrato_servico_seq, 0).sql_Get());
            em_cdempresa = Convert.ToInt32(dataTableContratoServico.Rows[0]["em_cdempresa"].ToString());
            contrato_servico_seq = Convert.ToInt32(dataTableContratoServico.Rows[0]["contrato_servico_seq"].ToString());
            contrato_bluesoft_seq = Convert.ToInt32(dataTableContratoServico.Rows[0]["contrato_bluesoft_seq"].ToString());
            cdpessoabluesoft = Convert.ToInt32(dataTableContratoServico.Rows[0]["cdpessoabluesoft"].ToString());
            contrato_bluesoft_descritivo = dataTableContratoServico.Rows[0]["contrato_bluesoft_descritivo"].ToString();
            contrato_bluesoft_status = Convert.ToInt32(dataTableContratoServico.Rows[0]["contrato_bluesoft_status"].ToString());
            contrato_bluesoft_valor = Convert.ToDouble(dataTableContratoServico.Rows[0]["contrato_bluesoft_valor"].ToString());
            contrato_bluesoft_dt_vigencia_ini = Convert.ToDateTime(dataTableContratoServico.Rows[0]["contrato_bluesoft_dt_vigencia_ini"].ToString());
            contrato_bluesoft_dt_vigencia_fim = Convert.ToDateTime(dataTableContratoServico.Rows[0]["contrato_bluesoft_dt_vigencia_fim"].ToString());
            contrato_servico_permite_execucao = Convert.ToInt32(dataTableContratoServico.Rows[0]["contrato_servico_permite_execucao"].ToString());
            contrato_servico_descritivo = dataTableContratoServico.Rows[0]["contrato_servico_descritivo"].ToString();
            contrato_servico_observacao = dataTableContratoServico.Rows[0]["contrato_servico_observacao"].ToString();
            nome_razao = dataTableContratoServico.Rows[0]["nome_razao"].ToString();
            cpf_cnpj = dataTableContratoServico.Rows[0]["cpf_cnpj"].ToString();
        }

        public void _BDINSERT(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0136_01_Contrato_Servico_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, this));
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
        public void _BDUPDATE(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0136_01_Contrato_Servico_CRUD.Post(MyConnect, Models.BDCommandTypes.DBUPDATE, this));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class model_Contrato_Servico_Ctrl: TbContrato_Servico_Ctrl
    {

        public Pag_Net.Bll.F0130_Controle.model_controle_reg_pessoa Tecnico;

        public int CartaoAcessoSeqReferencia_Get
        {
            get
            {
                return Tecnico.CartaoAcesso.cartao_acesso_numero;
            }
        }

        public Pag_Net.Bll.F0130_Controle.model_controle_reg_pessoa PrestadorServico;

        public model_Contrato_Servico_Ctrl() : base()
        {

        }
        public void Binding(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (CONTROLE_REG.controle_reg_seq != 0)
                {
                    CONTROLE_REG.Binding(MyConnect, CONTROLE_REG.Controle);
                    DataTable DataTable_Contrato_Servico_CTRL = BDCommand.get_DataTable(MyConnect, F0136_10_Contrato_Servico_Ctrl_Consultar.Get(this.CONTROLE_REG.controle_reg_seq));
                    this.contrato_servico_ctrl_seq = Convert.ToInt32(DataTable_Contrato_Servico_CTRL.Rows[0]["contrato_servico_ctrl_seq"].ToString());
                    this.CONTRATO_SERVICO.contrato_servico_seq = Convert.ToInt32(DataTable_Contrato_Servico_CTRL.Rows[0]["contrato_servico_seq"].ToString());
                    this.CONTROLE_REG.controle_reg_seq = Convert.ToInt32(DataTable_Contrato_Servico_CTRL.Rows[0]["controle_reg_seq"].ToString());
                    this.contrato_servico_ctrl_data = Convert.ToDateTime(DataTable_Contrato_Servico_CTRL.Rows[0]["contrato_servico_ctrl_data"].ToString());
                    this.contrato_servico_ctrl_descritivo = DataTable_Contrato_Servico_CTRL.Rows[0]["contrato_servico_ctrl_descritivo"].ToString();
                    this.contrato_servico_ctrl_observacao = DataTable_Contrato_Servico_CTRL.Rows[0]["contrato_servico_ctrl_descritivo"].ToString();
                    PrestadorServico = CONTROLE_REG.Pessoa_Get(91501);
                    Tecnico = CONTROLE_REG.Pessoa_Get(91502);

                }
                else
                {
                    PrestadorServico = CONTROLE_REG.Pessoa_Get(91501);
                    Tecnico = CONTROLE_REG.Pessoa_Get(91502);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _DBINSERT(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                CONTROLE_REG.Update(MyConnect);
                BDCommand.Execute(MyConnect, F0136_02_Contrato_Servico_Ctrl_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, this));
                CONTROLE_REG.Update_Etapa(MyConnect, CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd, CONTROLE_REG.Etapa_Proxima_Get().controle_etapa_cd, 1);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public void _DBUPDATE(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0136_02_Contrato_Servico_Ctrl_CRUD.Post(MyConnect, Models.BDCommandTypes.DBUPDATE, this));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void _Etapa_Step(Pag_Net.Models.modelSistemaUsuario MyConnect, int Etapa_a_CONSIDERAR)
        {
            try
            {
                CONTROLE_REG.Etapa_Atual_Get();
                CONTROLE_REG.Etapa_Proxima_Get();

                int STATUS_ATUAL = this.CONTROLE_REG.controle_status_cd;

                if (Etapa_a_CONSIDERAR == 0)
                    Etapa_a_CONSIDERAR = this.CONTROLE_REG.Local_controle_etapa_cd_proxima;

                if (Etapa_a_CONSIDERAR > this.CONTROLE_REG.controle_etapa_cd_final) throw new Exception("Não há mais etapa a ser processada");

                if (Etapa_a_CONSIDERAR == 15006) 
                {
                    if (STATUS_ATUAL == 1)
                        STATUS_ATUAL = 3;
                }

                this.CONTROLE_REG.Update_Etapa(MyConnect, this.CONTROLE_REG.controle_etapa_cd_atual, Etapa_a_CONSIDERAR, STATUS_ATUAL);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        
        public void _Recusar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd == 15002)
                {
                    this.CONTROLE_REG.Update_Etapa(MyConnect, this.CONTROLE_REG.controle_etapa_cd_atual, 15005, 2);
                    
                }
                else
                {
                    throw new Exception("Recusa permitida apenas para a Etapa 15002 - Entrada - Autorização");
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


////
    }

}


