using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_Transporte_Ctrl : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        
        Ctrl_Transporte_Form_Action __Screen_Form_Action;

        public enum Ctrl_Transporte_Form_Action
        {
            Ctrl_Transporte_Consultar = 0,
            Ctrl_Transporte_Incluir = 1,
            Ctrl_Transporte_Inclusao_Externa = 2,
            Ctrl_Transporte_Etapa_Next = 3,
            Ctrl_Transporte_Etapa_Next_Externo = 4,
            Ctrl_Transporte_Pgto_Incluir = 5,
            Ctrl_Transporte_Status_Excluido = 6, 
            Ctrl_Transporte_Status_Negado = 7,
            Ctrl_Transporte_Status_NaoRecebido = 8,



        }

        Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl __WKTransporte_Ctrl;

        Pag_Form.user_control.frmUC_DocumentoFiscalRegistro frmUC_DocumentoFiscalRegistro;
        Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft.WkComercial_PedidoBlueSoft _BLL_Comercial_PedidoBluesoft;
        Pag_Form.user_control.frmUC_Controle_Reg frmUC_Controle_Reg;

        int OPEN_Controle_Reg_Seq;
        Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro __OPEN_DocumentoFiscalRegistro;



        bool tarefa_441010 = false;
        bool tarefa_441011 = false;
        bool tarefa_441030 = false;
        bool tarefa_441040 = false;
        bool tarefa_441050 = false;
        bool tarefa_441051 = false;
        bool tarefa_441060 = false;
        bool tarefa_441070 = false;
        bool tarefa_441080 = false;
        bool tarefa_441090 = false;


        public frm_Transporte_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = _MyConnect;


                OPEN_Controle_Reg_Seq = 0;
                __OPEN_DocumentoFiscalRegistro = null;
                _BLL_Comercial_PedidoBluesoft = new Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft.WkComercial_PedidoBlueSoft(MyConnect);
                __WKTransporte_Ctrl = new Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl(MyConnect);
                __Screen_Form_Action = Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar;
                _Screen_load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public frm_Transporte_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect, 
            Ctrl_Transporte_Form_Action __ctrl_Trasnporte_Form_Action, 
            int Controle_Reg_Seq,
            Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro _open_DocumentoFiscalRegistro
            //int _open_controle_etapa_cd_Atual,
            //int _open_controle_etapa_Cd_NEW, 
            //int _open_controle_status_Cd_Atual, 
            //int _open_controle_status_cd_New 
            )
        {
            try
            {
                InitializeComponent();
                MyConnect = _MyConnect;
                
                OPEN_Controle_Reg_Seq = Controle_Reg_Seq;
                __OPEN_DocumentoFiscalRegistro = _open_DocumentoFiscalRegistro;
                //OPEN_controle_etapa_cd_Atual = _open_controle_etapa_cd_Atual;
                //OPEN_controle_etapa_Cd_NEW = _open_controle_etapa_Cd_NEW;
                //OPEN_controle_status_Cd_Atual = _open_controle_status_Cd_Atual;
                //OPEN_controle_status_cd_New = _open_controle_status_cd_New;
                _BLL_Comercial_PedidoBluesoft = new Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft.WkComercial_PedidoBlueSoft(MyConnect);


                __Screen_Form_Action = __ctrl_Trasnporte_Form_Action;
                _Screen_load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void _Screen_load()
        {
            try
            {
                //__WKControle_REG = new Pag_Net.Bll.F0130_Controle.WKControle_Reg(MyConnect);
                __WKTransporte_Ctrl = new Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl(MyConnect);

                /*Icones -----------------------------------------------------------------*/
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.SetaSimples_Baixo);
                UserTools._Screen_ButtonImage(cmdNovo_Controle, UserTools.PagButtonsIcons.Novo);
                UserTools._Screen_ButtonImage(cmdEfetivar_CONTROLE, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdCancelar, UserTools.PagButtonsIcons.CancelUndo);
                UserTools._Screen_ButtonImage(cmdControle_Reg_Fin, UserTools.PagButtonsIcons._Default_Valor);
                UserTools._Screen_ButtonImage(cmdControle_Reg_RecusarEntrada, UserTools.PagButtonsIcons.DeleteError);
                UserTools._Screen_ButtonImage(cmdControle_Reg_RecusarRecebimento, UserTools.PagButtonsIcons.DeleteError);
                UserTools._Screen_ButtonImage(cmdProximaEtapa, UserTools.PagButtonsIcons.SetaDupla_Direita);
                UserTools._Screen_ButtonImage(cmdRecibo, UserTools.PagButtonsIcons._Default_Imprimir);


                cmdEfetivar_CONTROLE.Click += new EventHandler(_Screen_Click);
                cmdCancelar.Click += new EventHandler(_Screen_Click);
                cmdControle_Reg_Fin.Click += new EventHandler(_Screen_Click);
                cmdRecibo.Click += new EventHandler(_Screen_Click);

                /*USER CONTROL -----------------------------------------------------------------*/
                frmUC_DocumentoFiscalRegistro = new Pag_Form.user_control.frmUC_DocumentoFiscalRegistro(MyConnect, false, false);
                frmUC_DocumentoFiscalRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
                frmUC_DocumentoFiscalRegistro.Location = new System.Drawing.Point(1, 1);
                frmUC_DocumentoFiscalRegistro.Name = "frmUC_DocumentoFiscalRegistro";
                frmUC_DocumentoFiscalRegistro.Size = new System.Drawing.Size(782, 373);
                frmUC_DocumentoFiscalRegistro.TabIndex = 0;

                tabRecebimento.Controls.Add(frmUC_DocumentoFiscalRegistro);

                frmUC_DocumentoFiscalRegistro.EventHanlder_Incluir_Nota_Fiscal_No_Grid += new EventHandler(_DocumentoFiscal_Add);
                frmUC_DocumentoFiscalRegistro.EventHanlder_Incluir_Nota_Fiscal_No_Grid += new EventHandler(_DocumentoFiscal_Info_Exibir);

                //TENTAR IMPLEMENTAR O CONTROLE COMO INTERFACE DE UM TIPO DE ATUAÇÃO

                frmUC_Controle_Reg = new Pag_Form.user_control.frmUC_Controle_Reg(MyConnect, __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg);
                frmUC_Controle_Reg.BackColor = System.Drawing.Color.LightSteelBlue;
                frmUC_Controle_Reg.Location = new System.Drawing.Point(1, 1);
                frmUC_Controle_Reg.Name = "frmUC_Controle_Reg";
                frmUC_Controle_Reg.Size = new System.Drawing.Size(1000, 1000);
                frmUC_Controle_Reg.TabIndex = 0;
                grpUC_Controle.Controls.Add(frmUC_Controle_Reg);

                frmUC_Controle_Reg.EventHandler_Tipo_Controle_Alterado += new EventHandler(_UserControl_Controle_info);
                frmUC_Controle_Reg.EventHandler_Fila_Alterada += new EventHandler(_UserControl_Controle_info);

                dtgpessoa_historico.AutoGenerateColumns = false;
                dtgDocumentosFiscais_Consultar.AutoGenerateColumns = false;
                dtg_comercial_pedidoblesoft.AutoGenerateColumns = false;

                
                //frmUC_DocumentoFiscalRegistro.EventHandler_Confirma_Lista += new EventHandler(_Efetiva_Lista);
                frmUC_DocumentoFiscalRegistro.__CONTROLE_REG_SEQ = 0;
                frmUC_DocumentoFiscalRegistro.__CONTROLE_ETAPA_CD = 2;
                //frmUC_DocumentoFiscalRegistro.DocumentoFiscal_Incluir(DocumentoFiscal_Inicial);


                /*Butons Events  -----------------------------------------------------------------*/
                cmdsair.Click += new EventHandler(_Screen_Click);
                cmdConsultar.Click += new EventHandler(_Screen_Click);
                cmdNovo_Controle.Click += new EventHandler(_Screen_Click);
                cmdProximaEtapa.Click += new EventHandler(_Screen_Click);
                cmdControle_Reg_RecusarEntrada.Click += new EventHandler(_Screen_Click);
                cmdControle_Reg_RecusarRecebimento.Click += new EventHandler(_Screen_Click);
                cmdControle_Reg_RecusarEntrada.Enabled = false;

                chkMotoristaPesquisar.Enabled = true; 
                chkMotoristaPesquisar.CheckedChanged += new EventHandler(_Screen_changed); 

                /*Text -----------------------------------------------------------------*/
                txtcontrole_reg_seq.TextChanged += new EventHandler(_Screen_changed);

                txtcpf_cnpj_Fornecedor.LostFocus += new EventHandler(_Screen_lostFocus);
                txtnome_razao_Fornecedor.LostFocus += new EventHandler(_Screen_lostFocus);
                txtnome_razao_Fornecedor.TextChanged += new EventHandler(_Screen_changed);
                txtcpf_cnpj.LostFocus += new EventHandler(_Screen_lostFocus);
                //txtcpf_cnpj.TextChanged += new EventHandler(_Screen_changed);
                txtnome_razao.LostFocus += new EventHandler(_Screen_lostFocus);
                txtnome_razao.TextChanged += new EventHandler(_Screen_changed);
                txtveiculo_placa.LostFocus += new EventHandler(_Screen_lostFocus);
                txtveiculo_placa.TextChanged += new EventHandler(_Screen_changed);
                txtpallet_qtde.LostFocus += new EventHandler(_Screen_lostFocus);
                txtpallet_qtde.TextChanged += new EventHandler(_Screen_changed);
                txtpallet_valor_unitario.LostFocus += new EventHandler(_Screen_lostFocus);
                txtpallet_valor_unitario.TextChanged += new EventHandler(_Screen_changed);


                /*ComboBOX  -----------------------------------------------------------------*/

                CmbVeiculo_Modelo_Descricao.ValueMember = "veiculo_modelo_cd";
                CmbVeiculo_Modelo_Descricao.DisplayMember = "veiculo_modelo_descricao";
                CmbVeiculo_Modelo_Descricao.DataSource = __WKTransporte_Ctrl.Modelos_Veiculos;


                /*ACESSOS  -----------------------------------------------------------------*/
                tarefa_441010 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441010);
                tarefa_441011 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441011);
                tarefa_441030 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441030);
                tarefa_441040 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441040);
                tarefa_441050 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441050);
                tarefa_441051 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441051);
                tarefa_441060 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441060);
                tarefa_441070 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441070);
                tarefa_441080 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441080);
                tarefa_441090 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441090);

                /*Ação Inicial  -----------------------------------------------------------------*/
                _Screen_Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void _Screen_Open()
        {
            try
            {
                //__Screen_Form_Action = Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar;
                _Screen_Acao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _Screen_Acao()
        {
            try
            {

                frmUC_Controle_Reg._GrpControle_Enabled(false);

                grpDocumentoFiscal_Lancamento.Enabled = false;
                grpTransportes.Enabled = false;
                grpConsultaControle.Enabled = false;

                cmdNovo_Controle.Enabled = false;
                cmdEfetivar_CONTROLE.Enabled = false;
                cmdCancelar.Enabled = false;
                cmdProximaEtapa.Enabled = false;
                cmdControle_Reg_Fin.Enabled = false;
                cmdControle_Reg_RecusarRecebimento.Enabled = false;
                cmdControle_Reg_RecusarRecebimento.Enabled = false;
                cmdRecibo.Enabled = false;


                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Incluir)
                {
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();
                    txtcontrole_reg_seq.Text = "0";
                    _Screen_Clear();
                    lbl_PROCESSO.Text = "Inclusão de <NOVO> controle";
                    __WKTransporte_Ctrl = new Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl(MyConnect);
                    frmUC_Controle_Reg.__iWK_Controle = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg;

                    __WKTransporte_Ctrl.Transporte_Ctrl.controle_reg_seq = 0;
                    frmUC_Controle_Reg._GrpControle_Enabled(true);
                    grpDocumentoFiscal_Lancamento.Enabled = true;
                    grpTransportes.Enabled = true;
                    cmdEfetivar_CONTROLE.Enabled = true;
                    cmdCancelar.Enabled = true;
                    frmUC_Controle_Reg._Exibir_Etapas();

                }

                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Inclusao_Externa)
                {
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();
                    cmdEfetivar_CONTROLE.Enabled = true;
                    cmdCancelar.Enabled = true;
                    grpDocumentoFiscal_Lancamento.Enabled = true;
                    grpTransportes.Enabled = true;

                    txtcontrole_reg_seq.Text = "0";
                    _Screen_Clear();
                    lbl_PROCESSO.Text = "Inclusão de <NOVO> controle";
                    __WKTransporte_Ctrl = new Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl(MyConnect);
                    frmUC_Controle_Reg.__iWK_Controle = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg;
                    __WKTransporte_Ctrl.Transporte_Ctrl.controle_reg_seq = 0;
                    frmUC_Controle_Reg._GrpControle_Enabled(true);
                    frmUC_Controle_Reg._Exibir_Etapas();

                    if (__OPEN_DocumentoFiscalRegistro.dfr_nf_numero != 0)
                    {
                        __WKTransporte_Ctrl.Transporte_Ctrl.Transporte_Ctrl_DocumentoFiscal_Lancamento = new Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro();

                        // Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro WKRegistroDocumentoFiscal = new Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro(MyConnect);
                        __WKTransporte_Ctrl.Transporte_Ctrl.Transporte_Ctrl_DocumentoFiscal_Lancamento = __OPEN_DocumentoFiscalRegistro;

                        frmUC_DocumentoFiscalRegistro._DocumentoFiscaisRegistroExterno_Incluir(__WKTransporte_Ctrl.Transporte_Ctrl.Transporte_Ctrl_DocumentoFiscal_Lancamento);
                        //WKRegistroDocumentoFiscal.Item = __WKTransporte_Ctrl.Transporte_Ctrl.Transporte_Ctrl_DocumentoFiscal_Lancamento;
                        //WKRegistroDocumentoFiscal.RegistroLista_Incluir();
                        //WKRegistroDocumentoFiscal.RegistroLista_Efetivar();

                        txtcpf_cnpj_Fornecedor.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Transporte_Ctrl_DocumentoFiscal_Lancamento.dfr_cnpj_cpf.ToString();
                        _Binding_Fornecedor();
                        
                    }

                }


                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar)
                {
                    _Screen_Clear();
                    frmUC_DocumentoFiscalRegistro.WKDocumentoFiscal.RegistroLista_Clear();

                    if (OPEN_Controle_Reg_Seq != 0)
                    {
                        __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq = OPEN_Controle_Reg_Seq;
                        txtcontrole_reg_seq.Text = OPEN_Controle_Reg_Seq.ToString();
                        _Binding();
                        
                    }


                    lbl_PROCESSO.Text = "Consultar de Controle: Informe o Sequencial";
                    grpConsultaControle.Enabled = true;
                    cmdNovo_Controle.Enabled = true;
                    cmdRecibo.Enabled = true;
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();
                    _Screen_Button_cmdControle_Reg_RecusarEntrada_Status();
                }

                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo)
                {
                    _Screen_Clear();
                    frmUC_DocumentoFiscalRegistro.WKDocumentoFiscal.RegistroLista_Clear();
                    if (OPEN_Controle_Reg_Seq != 0)
                    {
                        __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq = OPEN_Controle_Reg_Seq;
                        txtcontrole_reg_seq.Text = OPEN_Controle_Reg_Seq.ToString();
                        _Binding();
                    }
                    /**************************************************/
                    if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq == 0)
                    {
                        MessageBox.Show("Selecione um Controle de Transporte de Recebimento de Mercadoria");
                        return;
                    }
                    cmdProximaEtapa.Enabled = false;
                    cmdEfetivar_CONTROLE.Enabled = true;
                    cmdCancelar.Enabled = true;
                    cmdRecibo.Enabled = true;
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();
                    _Screen_Button_cmdControle_Reg_RecusarEntrada_Status();

                    string local_EtapaAtualDescricao = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_descricao.ToString();
                    string local_EtapaProximaDescricao = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_descricao;
                    int local_EtapaAtual_cd = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_cd;

                    if (local_EtapaAtual_cd == 10006)
                    {
                        TabControle.SelectTab(1);
                        grpDocumentoFiscal_Lancamento.Enabled = true;
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Antes de Passar para a Etapa " + local_EtapaProximaDescricao + ". Favor lançar os documentos Fiscais e Pagamentos \n Depois, clique em <EFETIVAR>");
                    }

                    lbl_PROCESSO.Text = "Alteração para a Etapa: " + __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_descricao + " -> Favor Lançar as notas fiscais RECEBIDAS. Depois <Click> em Efetivar";
                }



                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_Negado || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_NaoRecebido)
                {
                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq = OPEN_Controle_Reg_Seq;
                    txtcontrole_reg_seq.Text = OPEN_Controle_Reg_Seq.ToString();

                    _Binding();
                    if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq == 0)
                    {
                        MessageBox.Show("Selecione um Controle de Transporte de Recebimento de Mercadoria");
                        return;
                    }
                    cmdEfetivar_CONTROLE.Enabled = true;
                    cmdCancelar.Enabled = true;
                    cmdRecibo.Enabled = true;

                    if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_Negado)
                        lbl_PROCESSO.Text = "RECUSAR ADMINISTRATIVAMENTE o Controle " + __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq + " -> Click em <EFETIVAR>";

                    if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_NaoRecebido)
                        lbl_PROCESSO.Text = "NEGAR RECEBIMENTO do Controle " + __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq + " -> Click em <EFETIVAR>";
                    
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();
                    _Screen_Button_cmdControle_Reg_RecusarEntrada_Status();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _Screen_Clear()
        {
            //txtcontrole_reg_seq.Text = "0";
            
            dtgpessoa_historico.DataSource = null;
            _Binding_DtgPessoas();
            txtcpf_cnpj_Fornecedor.Text = "";
            txtnome_razao_Fornecedor.Text = "";
            txtcpf_cnpj.Text = "";
            txtnome_razao.Text = "";
            txtcpf_cnpj.Text = "";
            txtpallet_qtde.Text = "";
            txtveiculo_placa.Text = "";
            txtpallet_valor_unitario.Text = "";
            lbl_info_lanca_documentos_etapa.Text = "";
            lbl_info_NDocumentos.Text = "";
            lbl_info_Motorista.Text = "";
            lbl_info_Transportadora.Text = "";
            txtcelular_numero.Text = "";
            txtcelular_dd.Text = "";
            txtdocumento_cnh.Text = "";
            frmUC_Controle_Reg._Clear();

            
            //frmUC_Controle_Reg.Clear();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            _Screen_OnPaint(cmdConsultar);
            //_Screen_OnPaint(lbl_info_Transportadora);
            //_Screen_OnPaint(lbl_info_Motorista);
            //_Screen_OnPaint(lbl_info_NDocumentos);
            //_Screen_OnPaint(lbl_ffornecedor);
            //_Screen_OnPaint(lbl_fmotorista);
            //_Screen_OnPaint(lbl_fdados_carga);
            //_Screen_OnPaint(lbl_fveiculo);
            base.OnPaint(e);
        }

        private void _Screen_OnPaint(object sender)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            if (sender.GetType().Name == "Button")
            {
                graphicsPath.AddEllipse(0, 0, ((Button)sender).Width, ((Button)sender).Height);
                ((Button)sender).Region = new Region(graphicsPath);
            }

            if (sender.GetType().Name == "Label")
            {
                graphicsPath.AddEllipse(0, 0, ((Label)sender).Width, ((Label)sender).Height);
                ((Label)sender).Region = new Region(graphicsPath);
            }

        }

        private void _Screen_Click(object sender, EventArgs e)
        {

            if (sender.GetType().Name == "Button")
            {
                if (((Button)sender).Name == "cmdsair") { this.Close(); }
                /*---------------------------BOTÃO CONSULTAR------------------------------------*/
                if (((Button)sender).Name == "cmdConsultar")
                {
                    switch (__Screen_Form_Action)
                    {
                        case 0:
                            _Screen_Clear();
                            _Binding();
                            break;
                    }
                }

                if (((Button)sender).Name == "cmdNovo_Controle") { __Screen_Form_Action = Ctrl_Transporte_Form_Action.Ctrl_Transporte_Incluir;_Screen_Acao(); }

                if (((Button)sender).Name == "cmdCancelar") { __Screen_Form_Action = Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar; _Screen_Acao(); }

                if (((Button)sender).Name == "cmdEfetivar_CONTROLE") {_Transporte_Crtl_Efetivar();}

                if (((Button)sender).Name == "cmdControle_Reg_Fin") { _Transporte_Crtl_Controle_Reg_Fin(); }
                
                if (((Button)sender).Name == "cmdProximaEtapa") 
                {
                    if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma alteração da Etapa"))
                    {

                        if (__Screen_Form_Action != Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo)
                        {
                            __Screen_Form_Action = Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next;
                        }
                        _Screen_Acao();
                        _Transporte_Crtl_Efetivar();

                    }
                }
                
                if (((Button)sender).Name == "cmdControle_Reg_RecusarEntrada") { _Transporte_Ctrl_RecusaAdministrativa(); }
                if (((Button)sender).Name == "cmdControle_Reg_RecusarRecebimento") { _Transporte_Ctrl_RecusaRecebimento(); }
                if (((Button)sender).Name == "cmdRecibo") { _Transporte_Ctrl_Recibo(); }

                    
            }
        }

        private void _UserControl_Controle_info(object sender, EventArgs e)
        {
            try
            {
                lbl_info_lanca_documentos_etapa.Text = "";
                if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapas != null)
                {
                    if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapas.Count() > 0 )
                    lbl_info_lanca_documentos_etapa.Text = "Controle: " +
                                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Fila.controle_fila_descricao + " | " +
                                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_descricao;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                cmd.Enabled = false;
                _Screen_wait(ON);
            }
            else
            {
                _Screen_wait(ON);
                cmd.Enabled = true;
            }
        }
        
        private void _Screen_wait(bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                this.Refresh();
            }
        }
        
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                

                if (sender.GetType().Name == "Label") { }
                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtcontrole_reg_seq")
                    {
                        try
                        {
                            if (Convert.ToInt32(txtcontrole_reg_seq.Text) > 0)
                            {
                                //__WKControle_REG.CONTROLE_REG.controle_reg_seq = Convert.ToInt32(txtcontrole_reg_seq.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro - Valor Inválido: " + ex.Message);
                            txtcontrole_reg_seq.Text = "0";
                        }
                    }

                    if (((TextBox)sender).Name == "txtcpf_cnpj")
                    {
                            txtnome_razao.Text ="";
                    }

                    if (((TextBox)sender).Name == "txtnome_razao_Fornecedor")
                        lbl_info_Transportadora.Text = txtnome_razao_Fornecedor.Text;
   

                    if (((TextBox)sender).Name == "txtnome_razao")
                        lbl_info_Motorista.Text = txtnome_razao.Text;



                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox")
                {

                    if (((CheckBox)sender).Name == "chkMotoristaPesquisar")
                    {
                        _Binding_DtgPessoas();
                    }

                }
                if (sender.GetType().Name == "ComboBox")
                {
                    try
                    {

                        if (((ComboBox)sender).Name == "cmbcontrole_fila_descricao") { }

                    }
                    catch (Exception ex)
                    {
                        _Screen_wait(false);
                        MessageBox.Show("Lista de Filas Não encontradas" + ex.Message);
                    }
                }
                if (sender.GetType().Name == "TabControl")
                {


                    if (((TabControl)sender).Name == "tabPortaria")
                    {


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        
        private void _Screen_lostFocus(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "ComboBox")
                {
                    if (((ComboBox)sender).Name == "CmbVeiculoModelo") { }
                }
                if (sender.GetType().Name == "TextBox")
                {
                    string ObjectTextName = ((TextBox)sender).Name;
                    if (ObjectTextName == "txtcpf_cnpj" ||
                         ObjectTextName == "txtcdparticipante" ||
                         ObjectTextName == "txtcdpessoabluesoft" ||
                        ObjectTextName == "txtrh_funcionario_cd" ||
                        ObjectTextName == "txtdocumento_cnh" ||
                        ObjectTextName == "txtendereco_cep" ||
                        ObjectTextName == "txtendereco_logradouro" ||
                        ObjectTextName == "txtendereco_numero" ||
                        ObjectTextName == "txtendereco_bairro" ||
                        ObjectTextName == "txtendereco_municipio" ||
                        ObjectTextName == "txtnome_razao")
                    {

                    }
                    switch (((TextBox)sender).Name)
                    {

                        case "txtcpf_cnpj_Fornecedor":
                            _Binding_Fornecedor();
                       
                            break;

                        case "txtcpf_cnpj":
                            __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.cpf_cnpj = txtcpf_cnpj.Text;

                            //if (txtnome_razao.Text.Trim() == "")
                            //{
                                if (txtcpf_cnpj_Fornecedor.Text.Length >= 11)
                                    __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.Binding(MyConnect);
                                txtnome_razao.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.nome_razao.ToString();
                                txtdocumento_cnh.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.documento_cnh.ToString();
                                txtcelular_numero.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_numero.ToString();
                                txtcelular_dd.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_dd.ToString();
                            //}



                            if (txtcpf_cnpj.Text != "" && txtcpf_cnpj.Text.Length >= 11)
                            {
                                _Screen_wait(true);
                                __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.cpf_cnpj = txtcpf_cnpj.Text.ToString();
                                _Screen_wait(false);
                            }
                            break;


                        case "txtnome_razao_Fornecedor":
                            __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.nome_razao = txtnome_razao_Fornecedor.Text;
                                break;


                        case "txtdocumento_cnh":
                            __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.documento_cnh = txtdocumento_cnh.Text;
                            break;

                        case "txtcelular_dd":
                            __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_dd = Convert.ToInt32(txtcelular_dd.Text);
                            break;

                        case "txtcelular_numero":
                            __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_numero = Convert.ToInt32(txtcelular_numero.Text);
                            break;
                        case "txtveiculo_placa":
                            if (txtveiculo_placa.Text != "")
                            {
                                if (txtveiculo_placa.Text.Length == 7)
                                {

                                        Pag_Net.Bll.F0131_Veiculo.TbVeiculoModelo MODELO_VEICULO = ((Pag_Net.Bll.F0131_Veiculo.TbVeiculoModelo)CmbVeiculo_Modelo_Descricao.SelectedItem);

                                    __WKTransporte_Ctrl.Transporte_Ctrl.Veiculo.veiculo_placa = txtveiculo_placa.Text.ToString().ToUpper().Trim();
                                    __WKTransporte_Ctrl.Transporte_Ctrl.Veiculo.veiculo_modelo_cd = MODELO_VEICULO.veiculo_modelo_cd;
                                    __WKTransporte_Ctrl.Transporte_Ctrl.Binding_Veiculo(MyConnect);
                                }
                                else
                                {
                                    MessageBox.Show("Placa do Veículo INVÁLIDA, favor informar a Placa corretamente");
                                    txtveiculo_placa.Text = "";
                                }
                                
                            }
                            break;
                        case "txtpallet_qtde":
                            if (txtpallet_qtde.Text != "")
                            __WKTransporte_Ctrl.Transporte_Ctrl.pallet_qtde = Convert.ToInt32(txtpallet_qtde.Text);
                            break;

                        case "txtpallet_valor_unitario":
                            if (txtpallet_valor_unitario.Text != "")
                            __WKTransporte_Ctrl.Transporte_Ctrl.pallet_valor_unitario = Convert.ToDouble(txtpallet_valor_unitario.Text);
                            break;
                        
                    }

                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") { }
            }

            catch (Exception ErroMessage)
            {
                MessageBox.Show(ErroMessage.Message);
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Focus();
                    ((TextBox)sender).SelectAll();

                }

            }

        }
        


        private void _Screen_Button_cmdProximaEtapa_Status()
        {
            cmdProximaEtapa.Enabled = false;

           
            if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next 
                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo
                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_Negado
                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_NaoRecebido
                )
            {
                return;
            }

            

            if (txtcontrole_reg_seq.Text != "")
            {
                if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq != 0)
                {
                    if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar)
                    {
                        int localControle_etapa_cd_proxima = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_cd;
                        int localControle_etapa_atual = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_cd;
                        cmdProximaEtapa.Enabled = false;
                        if (
                            (localControle_etapa_atual == 10002 && tarefa_441010) ||
                            (localControle_etapa_atual == 10003 && tarefa_441030) ||
                            (localControle_etapa_atual == 10004 && tarefa_441040) ||
                            (localControle_etapa_atual == 10005 && tarefa_441050) ||
                            (localControle_etapa_atual == 10006 && tarefa_441060) ||
                            (localControle_etapa_atual == 10007 && tarefa_441070) ||
                            (localControle_etapa_atual == 10008 && tarefa_441080) ||
                            (localControle_etapa_atual == 10009 && tarefa_441090) ||
                            (localControle_etapa_atual == 10010 && tarefa_441010)
                            )
                        {
                            cmdProximaEtapa.Enabled = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Validar(MyConnect, localControle_etapa_cd_proxima, __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_status_cd);
                        }
                    }
                }
            }
        }
        private void _Screen_Button_cmdControle_Reg_RecusarEntrada_Status()
        {
            cmdControle_Reg_RecusarEntrada.Enabled = false;
            if (!tarefa_441011) return; /*Tarefa para permissão de RECUSA*/
            if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq != null)
            {
                if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq != 0)
                {
                    if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar 
                                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next
                                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo
                                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_Negado
                        )
                    {
                        if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_cd == 10002)

                            cmdControle_Reg_RecusarEntrada.Enabled = true;
                    }
                }
            }
        }
        private void _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status()
        {
            cmdControle_Reg_RecusarRecebimento.Enabled = false;
            if (!tarefa_441051) return; /*Tarefa para permissão de RECUSA*/
            if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg != null)
            {
                if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq != 0)
                {
                    if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar 
                                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next
                                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo
                                || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_NaoRecebido)
                   
                         if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_cd == 10003 ||
                            __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_cd == 10006)

                            cmdControle_Reg_RecusarRecebimento.Enabled = true;
                    }
                }
        }

        private void _Binding()
        {
            try
            {
                if (txtcontrole_reg_seq.Text != "")
                {
                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq = Convert.ToInt32(txtcontrole_reg_seq.Text);
                    __WKTransporte_Ctrl.Transporte_Ctrl.Binding(MyConnect);

                    //cmdControle_Reg_RecusarEntrada.Enabled = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Validar(MyConnect, 0, 4);
                    _Screen_Button_cmdControle_Reg_RecusarEntrada_Status();

                    //cmdControle_Reg_RecusarRecebimento.Enabled = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Validar(MyConnect, 0, 5);
                    _Screen_Button_cmdControle_Reg_RecusarRecebimento_Status();

                    //cmdProximaEtapa.Enabled = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Validar(MyConnect, __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_cd, __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_status_cd);
                    _Screen_Button_cmdProximaEtapa_Status();

                    frmUC_Controle_Reg.__iWK_Controle = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg;
                    frmUC_Controle_Reg._Binding();
                    txtcpf_cnpj.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.cpf_cnpj.ToString();
                    txtnome_razao.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.nome_razao.ToString();
                    txtdocumento_cnh.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.documento_cnh.ToString();
                    txtcelular_dd.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_dd.ToString();
                    txtcelular_numero.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_numero.ToString();
                    txtveiculo_placa.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Veiculo.veiculo_placa.ToString();
                    CmbVeiculo_Modelo_Descricao.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Veiculo.veiculo_modelo_descricao;
                    txtcpf_cnpj_Fornecedor.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.cpf_cnpj.ToString();
                    txtnome_razao_Fornecedor.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.nome_razao.ToString();
                    txtpallet_qtde.Text = __WKTransporte_Ctrl.Transporte_Ctrl.pallet_qtde.ToString();
                    txtpallet_valor_unitario.Text = __WKTransporte_Ctrl.Transporte_Ctrl.pallet_valor_unitario.ToString();
                    
                    
                    /*Documentos Fiscais----------------------------------------------------*/
                    //dtgDocumentosFiscais_Consultar.DataSource = null;
                    //dtgDocumentosFiscais_Consultar.DataSource = __WKTransporte_Ctrl.Transporte_Ctrl.DocumentosFiscaisLancados(MyConnect);
                    //lbl_info_NDocumentos.Text = dtgDocumentosFiscais_Consultar.Rows.Count.ToString();
                    _Binding_DocumentoFiscal();
                    /*---------------------------------------------------------------------*/

                    _BLL_Comercial_PedidoBluesoft.filter.cm_pedblue_dataemissao_inicial = DateTime.Now.AddDays(-15);
                    _BLL_Comercial_PedidoBluesoft.filter.cnpj_cnpj = txtcpf_cnpj_Fornecedor.Text;
                    dtg_comercial_pedidoblesoft.DataSource = _BLL_Comercial_PedidoBluesoft.Consultar();
                    lblcm_pedblue_numeropedido.DataBindings.Clear();
                    lblcm_pedblue_numeropedido.DataBindings.Add("Text", dtg_comercial_pedidoblesoft.DataSource, "cm_pedblue_numeropedido");
                    _UserControl_Controle_info(null, null);
                    cmdControle_Reg_Fin.Enabled = true;
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void _Binding_DocumentoFiscal()
        {
            try
            {
                __WKTransporte_Ctrl.Transporte_Ctrl.DocumentosFiscaisLancados(MyConnect);
                dtgDocumentosFiscais_Consultar.DataSource = null;
                dtgDocumentosFiscais_Consultar.DataSource = __WKTransporte_Ctrl.Transporte_Ctrl.DocumentosFiscais;
                lbl_info_NDocumentos.Text = dtgDocumentosFiscais_Consultar.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro: Falha na listagem dos documentos fiscais", ex);
            }
        }
        private void _Transporte_Crtl_Efetivar()
        {
            try
            {
                cmdProximaEtapa.Enabled = false;
                cmdControle_Reg_RecusarEntrada.Enabled = false;
                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo)
                {
                    string local_EtapaAtualDescricao = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_descricao.ToString();
                    string local_EtapaProximaDescricao = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_descricao;
                    int local_EtapaAtual_cd = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_cd;

                    if (local_EtapaAtual_cd == 10006)
                    {

                        int localNumeroDocumentoFiscalLancados = Convert.ToInt32(lbl_info_NDocumentos.Text); /*Documentos Fiscais Lançados no Inicio do Controle*/
                        int localNumeroDocumentoFiscalaLancar = frmUC_DocumentoFiscalRegistro.WKDocumentoFiscal.ListaDeDocumentosFiscais.Count();/*Documentos Fiscais Lançados no Inicio do Controle*/
                        if (localNumeroDocumentoFiscalLancados > localNumeroDocumentoFiscalaLancar)
                        {
                            UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor informar os Documentos Fiscais Recebidos e Conferidos!");
                            grpDocumentoFiscal_Lancamento.Enabled = true;
                            
                            TabControle.SelectTab(1);
                            return;
                        }
                        else
                        {
                            //frmUC_DocumentoFiscalRegistro.Efetivar();
                            //_DocumentoFiscal_Add(null, null);
                           
                            __WKTransporte_Ctrl.Transporte_Ctrl.Update_DocumentosFiscais_Etapa_list(MyConnect);
                            _Binding_DocumentoFiscal();
                            _DocumentoFiscal_Info_Exibir(null, null);
                        }
                        TabControle.SelectTab(0);
                        grpDocumentoFiscal_Lancamento.Enabled = false;

                       

                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor conferir Ordem de Serviços/Produtos -x- Pgtos!");
                        _Transporte_Crtl_Controle_Reg_Fin();

                        UserTools._Screen_Wait(this, true);
                        __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Binding_Fin(MyConnect);
                        UserTools._Screen_Wait(this, false);
                        if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Financeiro_Total_Saldo < 0)
                        {
                            UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "ETAPA NÃO ALTERADA \n Pendências Financeiras identificadas! Favor Conferir");
                            return;
                        }
                        if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Financeiro_Total_Debito != 0 && __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Financeiro_Total_Saldo ==0)
                        {
                            __WKTransporte_Ctrl.Transporte_Ctrl.ImprimirRecibo_DarumaDR700(MyConnect);
                        }
                    }
                    //if (local_EtapaAtual_cd == 10007)
                    //{
                    //    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor conferir Ordem de Serviços/Produtos -x- Pgtos!");
                    //    _Transporte_Crtl_Controle_Reg_Fin();
                    //}

                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Etapa_Step(MyConnect, 0);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, string.Format(" Alteração de Etapa CONCLUÍDA COM SUCESSO \n " +
                                                                                                       " -------------------------------------------------- " + 
                                                                                                       " \n " +
                                                                                                       "Etapa Anterior: \n" + 
                                                                                                       " {0} " +
                                                                                                       " \n " +
                                                                                                       " \n " +
                                                                                                       " \n " + 
                                                                                                       "NOVA ETAPA: \n " + 
                                                                                                       "->>> {1}", local_EtapaAtualDescricao, local_EtapaProximaDescricao));

                }

                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_Negado)
                {
                    string _EtapaAtual = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_descricao.ToString();
                    string _ProximaEtapa = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_descricao;
                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Negar(MyConnect);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, string.Format("Recusa Administrativa Efetuada"));

                }

                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Status_NaoRecebido)
                {
                    string _EtapaAtual = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_descricao.ToString();
                    string _ProximaEtapa = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_descricao;
                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Negar_Recebimento(MyConnect);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, string.Format("Recebimento Negado"));

                }                


                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Incluir || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Inclusao_Externa)
                {

                    string ERROR_VALIDACAO = "";
                    try
                    {
                        ERROR_VALIDACAO = "CNPJ Fornecedor/Transpotadora inválido";
                        if (__WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.cpf_cnpj == "")
                        {
                            __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.cpf_cnpj = txtcpf_cnpj_Fornecedor.Text;
                        }

                        ERROR_VALIDACAO = "Nome do Fornecedor/Transpotadora inválido";
                        __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.nome_razao = txtnome_razao_Fornecedor.Text;
                        ERROR_VALIDACAO = "CNPJ do Fornecedor/Transpotadora não informado ou inválido";
                        __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.cpf_cnpj = txtcpf_cnpj.Text;
                        ERROR_VALIDACAO = "Nome do Motorista não informado ";
                        __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.nome_razao = txtnome_razao.Text.ToString().ToUpper().Replace("'", "");
 
                        __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.documento_cnh = txtdocumento_cnh.Text;
                        ERROR_VALIDACAO = "Número do DD Celular OBRIGATÓRIO: Número Inválido";
                        __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_dd = Convert.ToInt32(txtcelular_dd.Text);
                        ERROR_VALIDACAO = "Número do Celular OBRIGATÓRIO: Número Inválido";
                        __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.celular_numero = Convert.ToInt32(txtcelular_numero.Text);
                        ERROR_VALIDACAO = "Qtde de Pallet inválida (Informea quantidade ou digite 0)";
                        __WKTransporte_Ctrl.Transporte_Ctrl.pallet_qtde = Convert.ToInt32(txtpallet_qtde.Text);
                        ERROR_VALIDACAO = "Valor do Pallet Inválido (Informe o valor ou digite ZERO)";
                        __WKTransporte_Ctrl.Transporte_Ctrl.pallet_valor_unitario = Convert.ToDouble(txtpallet_valor_unitario.Text);

                    }
                    catch (Exception ex)
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Processo NÃO Realizado \n" + ERROR_VALIDACAO , ex);
                        return;
                    }


 

                    if (!__WKTransporte_Ctrl.Transporte_Ctrl.Validar())
                    {
                        UserTools._Screen_Wait(this, cmdEfetivar_CONTROLE, false);
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Registro não Validado! Favor Averiguar com o Suporte");
                        return;
                    }
                    else
                    {


                        UserTools._Screen_Wait(this, cmdEfetivar_CONTROLE, true);
                        __WKTransporte_Ctrl.Save();

                        string Resultado = string.Format("CONTROLE DE RECEBIMENTO INCLUÍDO COM SUCESSO! \n " + 
                                                         " \n " + 
                                                         "NÚMERO {0} \n " +
                                                         "_______________________________" +
                                                         " \n " +
                                                         "Chave Inicial {1} \n " +
                                                         "_______________________________" +
                                                         " \n " +
                                                         "Fornecedor: {2}  \n " +
                                                         "_______________________________" +
                                                         " \n " +
                                                         "Motorista: {3}  \n "
                            ,
                            __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq.ToString(),
                            __WKTransporte_Ctrl.Transporte_Ctrl.Transporte_Ctrl_DocumentoFiscal_Lancamento.dfr_nf_chave,
                            frmUC_Controle_Reg.__iWK_Controle.Pessoa_Get(91001).nome_razao.ToString(),
                            frmUC_Controle_Reg.__iWK_Controle.Pessoa_Get(91002).nome_razao.ToString());

                        __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Update_Etapa(MyConnect,
                                           __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Atual_Get().controle_etapa_cd, 
                                           __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_cd,
                                           __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_status_cd);
                        UserTools._Screen_Wait(this, cmdEfetivar_CONTROLE, false);
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, Resultado);


                    }
                }
                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Inclusao_Externa || __Screen_Form_Action == Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo)
                {
                    if ( __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.Etapa_Proxima_Get().controle_etapa_cd == 10007)
                    {
                        UserTools._Screen_Wait(this, cmdEfetivar_CONTROLE, false);
                        lbl_PROCESSO.Text = "Clique em Próxima Etapa para prosseguir";
                        _Screen_Acao();
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                __Screen_Form_Action = Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar;
                _Screen_Acao();

                if (__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq != 0)
                {
                    txtcontrole_reg_seq.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg.controle_reg_seq.ToString();
                    _Binding();
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdEfetivar_CONTROLE, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Processamento NÃO realizado! \n" + ex.Message);
            }
        }
        private void _Transporte_Crtl_Controle_Reg_Fin()
        {
            try
            {
                frm_ControleFin _frmControle_Reg_Fin = new frm_ControleFin(MyConnect, __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg);
                _frmControle_Reg_Fin.ShowDialog();
                __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Status_Pgto(MyConnect);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
            }
        }
        private void _Transporte_Ctrl_RecusaAdministrativa()
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma RECUSA ADMINISTRATIVA deste Recebimento?"))
                {
                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Negar(MyConnect);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Recusa Administrativa realizada");
                    this.Close();
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro ao lançar a Recusa para a operação", ex);
            }
        }
        private void _Transporte_Ctrl_RecusaRecebimento()
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma RECUSAR Recebimento?"))
                {
                    __WKTransporte_Ctrl.Transporte_Ctrl.Controle_Ctrl_Update_Negar_Recebimento(MyConnect);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Recebimento NEGADO");
                    this.Close();
                }

            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro ao lançar a Recusa para a operação", ex);
            }
        }
        private void _Transporte_Ctrl_Recibo()
        {
            try
            {
                if (chkDARUMADR700.Checked)
                {
                    __WKTransporte_Ctrl.Transporte_Ctrl.ImprimirRecibo_DarumaDR700(MyConnect);
                }
                else
                {
                    // this.DocumentosFiscaisLancados
                    //__WKTransporte_Ctrl.Transporte_Ctrl.DocumentosFiscaisLancados(MyConnect);
                    //MessageBox.Show(__WKTransporte_Ctrl.Transporte_Ctrl.DocumentosFiscais.Length.ToString());

                    UserReports.ControleFin_Recibo(MyConnect, __WKTransporte_Ctrl.Transporte_Ctrl);
                }
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Impressão Realizada!");
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }

        private void _DocumentoFiscal_Info_Exibir(object sender, EventArgs e)
        {
            lbl_info_NDocumentos_Lancamento.Text = frmUC_DocumentoFiscalRegistro.WKDocumentoFiscal.ListaDeDocumentosFiscais.Count().ToString();
        }
        private void _DocumentoFiscal_Add(object sender, EventArgs e)
        {
            try
            {

                foreach (Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro item in frmUC_DocumentoFiscalRegistro.WKDocumentoFiscal.ListaDeDocumentosFiscais)
                {
                    //frmUC_DocumentoFiscalRegistro.DocumentoFiscal_Incluir(item);
                    __WKTransporte_Ctrl.Transporte_Ctrl.DocumentoFiscal_add(MyConnect, item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void _Binding_DtgPessoas()
        {
            try
            {
                txtcpf_cnpj.Text = "";
                txtnome_razao.Text = "";
                txtdocumento_cnh.Text = "";
                txtcelular_dd.Text = "";
                txtcelular_numero.Text = "";

                txtcpf_cnpj.DataBindings.Clear();
                txtnome_razao.DataBindings.Clear();
                txtdocumento_cnh.DataBindings.Clear();
                txtcelular_dd.DataBindings.Clear();
                txtcelular_numero.DataBindings.Clear();
                if (dtgpessoa_historico.DataSource == null)
                {
                    return;
                }

                if (chkMotoristaPesquisar.Checked)
                {

                    chkMotoristaPesquisar.Text = "Desmarque a opção para digitar os dados do motorista manualmente"; 
                    txtcpf_cnpj.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "cpf_cnpj");
                    txtnome_razao.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "nome_razao");
                    txtdocumento_cnh.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "documento_cnh");
                    txtcelular_dd.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "celular_dd");
                    txtcelular_numero.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "celular_numero");
                    txtcpf_cnpj.Enabled = false;
                    txtnome_razao.Enabled = false;
                    txtdocumento_cnh.Enabled = false;
                    txtcelular_dd.Enabled = false;
                    txtcelular_numero.Enabled = false; 

                }
                else
                {
                    chkMotoristaPesquisar.Text = "Marque esta opção para utilizar os dados de um motorista já lançado anteriormente";
                    txtcpf_cnpj.Enabled = true;
                    txtnome_razao.Enabled = true ;
                    txtdocumento_cnh.Enabled = true;
                    txtcelular_dd.Enabled = true;
                    txtcelular_numero.Enabled = true; 
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _Binding_Fornecedor()
        {
            try
            {
                if (txtcpf_cnpj_Fornecedor.Text != "" && txtcpf_cnpj_Fornecedor.Text.Length >= 11)
                {
                    _Screen_wait(true);
                    __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.cpf_cnpj = txtcpf_cnpj_Fornecedor.Text.ToString();
                    if (txtcpf_cnpj_Fornecedor.Text.Length >= 11)
                        dtgpessoa_historico.DataSource = __WKTransporte_Ctrl.PessoasList_Get(__WKTransporte_Ctrl.Transporte_Ctrl.Controle_Reg, __WKTransporte_Ctrl.Transporte_Ctrl.Motorista.controle_pessoa_cd, txtcpf_cnpj_Fornecedor.Text);
                    _Binding_DtgPessoas();
                    chkMotoristaPesquisar.Enabled = true; 

                    __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.Binding(MyConnect);
                    
                    txtnome_razao_Fornecedor.Text = __WKTransporte_Ctrl.Transporte_Ctrl.Transportadora.nome_razao.ToString();
                    _Screen_wait(false);
                }
            }
            catch (Exception)
            {
                txtcpf_cnpj_Fornecedor.Text = "";
            }
        }

        private void cmdAbrirPedido_Click(object sender, EventArgs e)
        {
            if (lblcm_pedblue_numeropedido.Text != "")
                System.Diagnostics.Process.Start(string.Format("https://erp.bluesoft.com.br/oxan/comercial/consultaPedido/listarDetalheDoPedido.action?pedidoKey={0}", lblcm_pedblue_numeropedido.Text));
        }
    }
}
