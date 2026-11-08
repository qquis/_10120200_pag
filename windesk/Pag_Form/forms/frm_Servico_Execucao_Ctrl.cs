using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pag_Net.Bll.F0136_Contrato_Servico;

namespace Pag_Form.forms
{
    public partial class frm_Servico_Execucao_Ctrl : Form
    {


        Form_Action __Screen_Form_Action;

        public enum Form_Action
        {
            Consultar = 0,
            Incluir = 1,
            Alterar_Etapa = 2,
            Inclusao_Externa = 3,
            Alterar_Etapa_Externo = 4,
            Recusar_Entrada = 5
        }
        

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico_Ctrl WK;

        Pag_Form.user_control.frmUC_Controle_Reg frmUC_Controle_Reg;


        string _CartaoCodigoBarra_Acesso = "";

        
        public frm_Servico_Execucao_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = _MyConnect;
                WK = new Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico_Ctrl(MyConnect);

                /* ACTION LOAD */
                __Screen_Form_Action = Form_Action.Consultar;
                _Screen_load(true);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }

        }
        public frm_Servico_Execucao_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect, Form_Action _screen_form_action, string CartaoAcessoCodigoBarra )
        {
            try
            {
                InitializeComponent();
                MyConnect = _MyConnect;
                WK = new Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico_Ctrl(MyConnect);

                /* ACTION LOAD */
                __Screen_Form_Action = _screen_form_action;
                _CartaoCodigoBarra_Acesso = CartaoAcessoCodigoBarra;
                

                _Screen_load(true);

                

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }
        public frm_Servico_Execucao_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect, Form_Action _screen_form_action, int controle_reg_seq)
        {
            try
            {
                InitializeComponent();
                MyConnect = _MyConnect;
                WK = new Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico_Ctrl(MyConnect);

                /* ACTION LOAD */
                __Screen_Form_Action = _screen_form_action;

                _Screen_load(true);

                if (controle_reg_seq != 0)
                {
                    txtfiltro_controle_reg_seq.Text = controle_reg_seq.ToString();
                    _Consultar_Servico();
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }



        private void _Screen_load(bool OpenForm)
        {
            try
            {

                if (OpenForm)
                {
                    UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons.SetaSimples_Direita);
                    UserTools._Screen_ButtonImage(cmdCancelar, UserTools.PagButtonsIcons.CancelUndo);
                    UserTools._Screen_ButtonImage(cmdEfetivar, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                    UserTools._Screen_ButtonImage(cmdNovo_Controle, UserTools.PagButtonsIcons.Novo);
                    UserTools._Screen_ButtonImage(cmdProximaEtapa, UserTools.PagButtonsIcons.SetaDupla_Direita);
                    UserTools._Screen_ButtonImage(cmdRecusarEntrada, UserTools.PagButtonsIcons.DeleteError);


                    frmUC_Controle_Reg = new Pag_Form.user_control.frmUC_Controle_Reg(MyConnect, WK.Contrato_Servico_Ctrl.CONTROLE_REG);
                    frmUC_Controle_Reg.BackColor = System.Drawing.Color.LightSteelBlue;
                    frmUC_Controle_Reg.Location = new System.Drawing.Point(1, 1);
                    frmUC_Controle_Reg.Name = "frmUC_Controle_Reg";
                    frmUC_Controle_Reg.Size = new System.Drawing.Size(1000, 1000);
                    frmUC_Controle_Reg.TabIndex = 0;
                    grpUC_Controle.Controls.Add(frmUC_Controle_Reg);
                    frmUC_Controle_Reg._Exibir_Etapas();
                    dtgpessoa_historico.AutoGenerateColumns = false;


                    cmbContratoServico.DisplayMember = "contrato_servico_descritivo";
                    cmbContratoServico.ValueMember = "contrato_servico_seq";
                    WKContrato_Servico __WKContratoServico = new WKContrato_Servico(MyConnect);
                    cmbContratoServico.DataSource = WK.Contrato_Servico_Ctrl_List;

                    foreach (object i in this.Controls) { if (i.GetType().Name == "TextBox") if (((TextBox)i).Tag.ToString() != "") ((TextBox)i).LostFocus += new EventHandler(_Screen_lostFocus); }
                    foreach (object i in this.Controls) { if (i.GetType().Name == "Button") ((Button)i).Click += new EventHandler(_Screen_Click); }
                    cmbContratoServico.LostFocus += new EventHandler(_Screen_lostFocus);


                    cmbcartaoCtrl.ValueMember = "cartao_acesso_seq";
                    cmbcartaoCtrl.DisplayMember = "cartao_acesso_numero";
                }


                if (__Screen_Form_Action == Form_Action.Incluir || __Screen_Form_Action == Form_Action.Inclusao_Externa)
                {
                    lbl_PROCESSO.Text = "Incluir nova prestação de Serviço: Informe os dados e clique em <EFETIVAR>";
                    foreach (object i in this.Controls) { if (i.GetType().Name == "TextBox") { ((TextBox)i).Enabled = true; ((TextBox)i).Text = ""; } }
                    dtgpessoa_historico.Enabled = true;
                    cmbContratoServico.SelectedIndex = 0;
                    cmbContratoServico.Enabled = true;
                    cmbcartaoCtrl.Enabled = true;
                    cmdEfetivar.Enabled = true;
                    cmdCancelar.Enabled = true;
                    cmdNovo_Controle.Enabled = false;
                    cmdConsultar.Enabled = false;
                    cmdProximaEtapa.Enabled = false;
                    cmdRecusarEntrada.Enabled = false;
                    txtfiltro_controle_reg_seq.Enabled = false;
                    frmUC_Controle_Reg._Clear();
                    frmUC_Controle_Reg._GrpControle_Enabled(true);
                    WK.Contrato_Servico_Ctrl.Binding(MyConnect);
                    frmUC_Controle_Reg.__iWK_Controle = WK.Contrato_Servico_Ctrl.CONTROLE_REG;

                    cmbcartaoCtrl.DataSource = WK.WKCartaoAcesso.CartaoStatusDisponivelList_Get(_CartaoCodigoBarra_Acesso);
                }


                if (__Screen_Form_Action == Form_Action.Consultar)
                {
                    lbl_PROCESSO.Text = "Consulta: Informe o Número do Controle";
                    foreach (object i in this.Controls) { if (i.GetType().Name == "TextBox") if (((TextBox)i).Tag.ToString() != "") { ((TextBox)i).Enabled = false; ((TextBox)i).Text = ""; } }
                    //cmbcartaoCtrl.Text = "";
                    dtgpessoa_historico.DataSource = null;
                    dtgpessoa_historico.Enabled = false;
                    cmbContratoServico.SelectedIndex = 0;
                    txtfiltro_controle_reg_seq.Enabled = true;
                    cmbContratoServico.Enabled = false;
                    cmbcartaoCtrl.Enabled = false;
                    WK.Contrato_Servico_Ctrl.Binding(MyConnect);
                    cmdEfetivar.Enabled = false;
                    cmdCancelar.Enabled = false;
                    cmdNovo_Controle.Enabled = true;
                    cmdConsultar.Enabled = true;
                    cmdProximaEtapa.Enabled = true;
                    cmdRecusarEntrada.Enabled = true;

                    frmUC_Controle_Reg._Clear();
                    frmUC_Controle_Reg._GrpControle_Enabled(false);
                    frmUC_Controle_Reg.__iWK_Controle = WK.Contrato_Servico_Ctrl.CONTROLE_REG;
                }


                if (__Screen_Form_Action == Form_Action.Alterar_Etapa || __Screen_Form_Action == Form_Action.Alterar_Etapa_Externo || __Screen_Form_Action ==  Form_Action.Recusar_Entrada)
                {


                    lbl_PROCESSO.Text = "Alteração de Etapa: Clique em <EFETIVAR> para concluir";
                    foreach (object i in this.Controls) { if (i.GetType().Name == "TextBox") if (((TextBox)i).Tag.ToString() != "") { ((TextBox)i).Enabled = false; ((TextBox)i).Text = ""; } }

                    cmdEfetivar.Enabled = true;
                    cmdCancelar.Enabled = true;
                    cmdNovo_Controle.Enabled = false;
                    cmdConsultar.Enabled = false;
                    cmdProximaEtapa.Enabled = false;
                    cmdRecusarEntrada.Enabled = false;
                    txtfiltro_controle_reg_seq.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }

        private void _Screen_lostFocus(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "ComboBox")
                {

                    if (((ComboBox)sender).Name == "cmbContratoServico") 
                    { 
                        WK.Contrato_Servico_Ctrl.CONTRATO_SERVICO = ((model_Contrato_Servico)cmbContratoServico.SelectedItem);
                            WK.Contrato_Servico_Ctrl.CONTRATO_SERVICO.Binding(MyConnect);
                                        txtcpf_cnpj_Fornecedor.Text = WK.Contrato_Servico_Ctrl.CONTRATO_SERVICO.cpf_cnpj.ToString();
                        _Binding_Fornecedor();
                        
                    }
                }
                if (sender.GetType().Name == "TextBox")
                {

                    switch (((TextBox)sender).Name)
                    {

                        case "txtcpf_cnpj_Fornecedor":
                            _Binding_Fornecedor();
                            break;

                        case "txtcpf_cnpj":
                            WK.Contrato_Servico_Ctrl.Tecnico.cpf_cnpj = txtcpf_cnpj.Text;
                            if (txtcpf_cnpj.Text.Length >= 11)
                                WK.Contrato_Servico_Ctrl.Tecnico.Binding(MyConnect);
                            txtnome_razao.Text = WK.Contrato_Servico_Ctrl.Tecnico.nome_razao.ToString();
                            txtcelular_numero.Text = WK.Contrato_Servico_Ctrl.Tecnico.celular_numero.ToString();
                            txtcelular_dd.Text = WK.Contrato_Servico_Ctrl.Tecnico.celular_dd.ToString();
                            break;
                        case "txtnome_razao_Fornecedor":
                            WK.Contrato_Servico_Ctrl.PrestadorServico.nome_razao = txtnome_razao_Fornecedor.Text;
                            break;
                        case "txtcelular_dd":
                            WK.Contrato_Servico_Ctrl.Tecnico.celular_dd = Convert.ToInt32(txtcelular_dd.Text);
                            break;
                        case "txtcelular_numero":
                            WK.Contrato_Servico_Ctrl.Tecnico.celular_numero = Convert.ToInt32(txtcelular_numero.Text);
                            break;

                        case "txtcontrato_servico_ctrl_descritivo":
                            WK.Contrato_Servico_Ctrl.contrato_servico_ctrl_descritivo = txtcontrato_servico_ctrl_descritivo.Text.ToString().Replace("'", "");
                            break;

                        case "txtcontrato_servico_ctrl_observacao":
                            WK.Contrato_Servico_Ctrl.contrato_servico_ctrl_observacao = txtcontrato_servico_ctrl_observacao.Text.ToString().Replace("'", "");
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
        
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label") { }
                if (sender.GetType().Name == "TextBox") { }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox")
                {

                }
                if (sender.GetType().Name == "ComboBox") { }
                if (sender.GetType().Name == "TabControl") { }
            }

            catch (Exception ErroMessage)
            {
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Text = "0";
                }
                MessageBox.Show(ErroMessage.Message);
            }
        }
        private void _Screen_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Button")
            {
                if (((Button)sender).Name == "cmdsair") { this.Close(); }
                if (((Button)sender).Name == "cmdConsultar_Servico") { _Consultar_Servico(); }
                if (((Button)sender).Name == "cmdEfetivar") { _Efetivar(); }
                if (((Button)sender).Name == "cmdConsultar") { _Consultar_Servico(); }
                if (((Button)sender).Name == "cmdNovo_Controle") { __Screen_Form_Action = Form_Action.Incluir; _Screen_load(false); }
                if (((Button)sender).Name == "cmdCancelar") { __Screen_Form_Action = Form_Action.Consultar; _Screen_load(false); }
                if (((Button)sender).Name == "cmdProximaEtapa")
                {
                    if (frmUC_Controle_Reg.__iWK_Controle.controle_reg_seq != 0)
                    {
                        
                        if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma Alteração da Etapa?"))
                        {
                            UserTools._Screen_Wait(this, true);
                            __Screen_Form_Action = Form_Action.Alterar_Etapa;
                            _Efetivar();
                            UserTools._Screen_Wait(this, false);
                        }
                        
                    }
                    else
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Selecione um Controle", null);
                    }

                }
                if (((Button)sender).Name == "cmdRecusarEntrada")
                {
                    if (frmUC_Controle_Reg.__iWK_Controle.controle_reg_seq != 0)
                    {
                        __Screen_Form_Action = Form_Action.Recusar_Entrada;
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, string.Format("Clique em Efetivar para RECUSAR o Serviço")); 
                        _Screen_load(false);
                    }
                    else
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Selecione um Controle", null);
                    }
                }
                
            }
        }
        private void _Consultar_Servico()
        {
            try
            {
                _Screen_load(false);
                if (txtfiltro_controle_reg_seq.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Informe o número do Controle");
                    return;
                }
                UserTools._Screen_Wait(this, true);

                if (_Binding_Controle_Servico_Ctrl(Convert.ToInt32(txtfiltro_controle_reg_seq.Text)))
                {

                    cmbContratoServico.Text = WK.Contrato_Servico_Ctrl.CONTRATO_SERVICO.contrato_servico_descritivo;
                    txtcpf_cnpj_Fornecedor.Text = WK.Contrato_Servico_Ctrl.PrestadorServico.cpf_cnpj.ToString();
                    txtnome_razao_Fornecedor.Text = WK.Contrato_Servico_Ctrl.PrestadorServico.nome_razao.ToString();
                    txtcpf_cnpj.Text = WK.Contrato_Servico_Ctrl.Tecnico.cpf_cnpj.ToString();
                    txtnome_razao.Text = WK.Contrato_Servico_Ctrl.Tecnico.nome_razao;
                    txtcelular_dd.Text = WK.Contrato_Servico_Ctrl.Tecnico.celular_dd.ToString();
                    txtcelular_numero.Text = WK.Contrato_Servico_Ctrl.Tecnico.celular_numero.ToString();
                    txtcontrato_servico_ctrl_descritivo.Text = WK.Contrato_Servico_Ctrl.contrato_servico_ctrl_descritivo;
                    txtcontrato_servico_ctrl_observacao.Text = WK.Contrato_Servico_Ctrl.contrato_servico_ctrl_observacao;
                    cmbcartaoCtrl.Text = WK.Contrato_Servico_Ctrl.CartaoAcessoSeqReferencia_Get.ToString();

                    if (__Screen_Form_Action == Form_Action.Alterar_Etapa || __Screen_Form_Action == Form_Action.Alterar_Etapa_Externo ) 
                        lbl_PROCESSO.Text = "Confirme a alteração para a etapa:" + WK.Contrato_Servico_Ctrl.CONTROLE_REG.Etapa_Proxima_Get().controle_etapa_descricao;
                    if (__Screen_Form_Action == Form_Action.Recusar_Entrada) 
                        lbl_PROCESSO.Text = "Clique em Confirmar para Recusar o SERVIÇO";
                    if (frmUC_Controle_Reg.__iWK_Controle.controle_status_cd == 2 || frmUC_Controle_Reg.__iWK_Controle.controle_status_cd == 3) 
                        cmdProximaEtapa.Enabled = false;
                    if (frmUC_Controle_Reg.__iWK_Controle.Etapa_Atual_Get().controle_etapa_cd != 15002) 
                        cmdRecusarEntrada.Enabled = false;
                }
                UserTools._Screen_Wait(this, false);
            }

            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }
        private void _Efetivar()
        {
            try
            {

                int Controle_New = 0;
                UserTools._Screen_Wait(this, true);
                if (__Screen_Form_Action == Form_Action.Incluir || __Screen_Form_Action == Form_Action.Inclusao_Externa)
                {

                    /*Validações ---   */
                    if (frmUC_Controle_Reg.__iWK_Controle.Fila.controle_fila_cd == 0) { UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Informar a Fila!"); return;}
                    if (txtcpf_cnpj_Fornecedor.Text == "") {UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Favor informar o CNPJ prestador do Serviço"); return;}
                    /* --------------  */
                    WK.Contrato_Servico_Ctrl.PrestadorServico.cpf_cnpj = txtcpf_cnpj_Fornecedor.Text.ToString();
                    WK.Contrato_Servico_Ctrl.PrestadorServico.nome_razao = txtnome_razao_Fornecedor.Text.ToString().ToUpper().Replace("'", "");
                    WK.Contrato_Servico_Ctrl.Tecnico.cpf_cnpj = txtcpf_cnpj.Text;
                    WK.Contrato_Servico_Ctrl.Tecnico.nome_razao = txtnome_razao.Text.ToString().ToUpper().Replace("'", "");
                    WK.Contrato_Servico_Ctrl.Tecnico.celular_dd = Convert.ToInt32(txtcelular_dd.Text);
                    WK.Contrato_Servico_Ctrl.Tecnico.celular_numero = Convert.ToInt32(txtcelular_numero.Text);
                    WK.Contrato_Servico_Ctrl.contrato_servico_ctrl_descritivo = txtcontrato_servico_ctrl_descritivo.Text.ToString().ToUpper().Replace("'", "");
                    WK.Contrato_Servico_Ctrl.contrato_servico_ctrl_observacao = txtcontrato_servico_ctrl_observacao.Text.ToString().ToUpper().Replace("'", "");
                    WK.ContratoServicoTecnicoCartaoAcesso_Set(((Pag_Net.Bll.F0137_CartaoAcesso.model_cartao_acesso)cmbcartaoCtrl.SelectedItem));
                    WK.Contrato_Servico_Ctrl._DBINSERT(MyConnect);
                }

                if (__Screen_Form_Action == Form_Action.Alterar_Etapa || __Screen_Form_Action == Form_Action.Alterar_Etapa_Externo)
                {
                    WK.Contrato_Servico_Ctrl._Etapa_Step(MyConnect, 0);
                }


                if (__Screen_Form_Action == Form_Action.Recusar_Entrada)
                {
                    WK.Contrato_Servico_Ctrl._Recusar(MyConnect);
                }

                Controle_New = WK.Contrato_Servico_Ctrl.CONTROLE_REG.controle_reg_seq;

                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, string.Format("Registro Efetivado com sucesso: {0}", Controle_New));


                if (__Screen_Form_Action == Form_Action.Inclusao_Externa || __Screen_Form_Action == Form_Action.Alterar_Etapa_Externo)
                {
                    this.Close();
                }
                /* __ CONSULTAR O REGISTRO APÓS ALTERAÇÃO __ */
                __Screen_Form_Action = Form_Action.Consultar;
                _Screen_load(false);
                txtfiltro_controle_reg_seq.Text = Controle_New.ToString();
                _Consultar_Servico();

                
            }
            catch (Exception ex)
            {
                _Screen_load(false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }

        private bool _Binding_Controle_Servico_Ctrl(int _controle_reg_seq)
        {
            try
            {
                WK.Contrato_Servico_Ctrl.CONTROLE_REG.controle_reg_seq = _controle_reg_seq;
                WK.Contrato_Servico_Ctrl.Binding(MyConnect);
                frmUC_Controle_Reg.__iWK_Controle = WK.Contrato_Servico_Ctrl.CONTROLE_REG;
                frmUC_Controle_Reg._Binding();
                return true;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, ex);
                return false;
            }
        }

        private void _Binding_Fornecedor()
        {
            try
            {
                if (txtcpf_cnpj_Fornecedor.Text != "" && txtcpf_cnpj_Fornecedor.Text.Length >= 11)
                {
                    UserTools._Screen_Wait(this, true);
                    WK.Contrato_Servico_Ctrl.PrestadorServico.cpf_cnpj = txtcpf_cnpj_Fornecedor.Text.ToString();

                    if (txtcpf_cnpj_Fornecedor.Text.Length >= 11)
                        dtgpessoa_historico.DataSource = WK.PessoasList_Get(WK.Contrato_Servico_Ctrl.CONTROLE_REG, WK.Contrato_Servico_Ctrl.Tecnico.controle_pessoa_cd, txtcpf_cnpj_Fornecedor.Text);
                    _Binding_DtgPessoas();

                    WK.Contrato_Servico_Ctrl.PrestadorServico.Binding(MyConnect);
                    txtnome_razao_Fornecedor.Text = WK.Contrato_Servico_Ctrl.PrestadorServico.nome_razao.ToString();
                    UserTools._Screen_Wait(this, false);
                }
            }
            catch (Exception ex)
            {
                txtcpf_cnpj_Fornecedor.Text = "";
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Fornecedor não localizado", ex);
            }
        }
        private void _Binding_DtgPessoas()
        {
            try
            {

                if (dtgpessoa_historico.DataSource == null)
                {
                    return;
                }

                //dtgControlePessoa
                txtcpf_cnpj.DataBindings.Clear();
                txtcpf_cnpj.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "cpf_cnpj");

                txtnome_razao.DataBindings.Clear();
                txtnome_razao.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "nome_razao");


                txtcelular_dd.DataBindings.Clear();
                txtcelular_dd.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "celular_dd");

                txtcelular_numero.DataBindings.Clear();
                txtcelular_numero.DataBindings.Add("Text", dtgpessoa_historico.DataSource, "celular_numero");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
