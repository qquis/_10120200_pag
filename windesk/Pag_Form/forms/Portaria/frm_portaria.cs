using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pag_Form;

namespace Pag_Form.forms
{
    public partial class frm_portaria : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        //Pag_Net.Bll.F0141_Rh.wkFuncionario _BLL_FUNCIONARIO;


        Pag_Net.Bll.F0130_Controle.Wk WK;
        Pag_Net.Bll.F0130_Controle.Wk WKListGeral;
        //Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl WK_Transporte_Ctrl;

        System.Windows.Forms.Timer _TIMER_tProc;
        int _TIMER_EXECUTE;
        int _TIMER_EXECUTE_LIMIT = 15;

        //int _controle_fila_cd = 0;
        public frm_portaria(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;

            WK = new Pag_Net.Bll.F0130_Controle.Wk(MyConnect);
            WKListGeral = new Pag_Net.Bll.F0130_Controle.Wk(MyConnect);
            //WK_Transporte_Ctrl = new Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl(MyConnect);

            _Screen_load();

        }

        private void frm_portaria_MouseMove(object sender, MouseEventArgs e)
        {
            _TIMER_EXECUTE = 0;
        }
        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdbuscar_controles_pendentes, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_ButtonImage(cmdControle_Reg_Alterar_Etapa, UserTools.PagButtonsIcons.SetaSimples_Baixo);
                UserTools._Screen_ButtonImage( cmdDetalheControle_Reg, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdPrestadorServico, UserTools.PagButtonsIcons.X_ICO_CMD_SERVICO_CTRL);


                WK.PropertyChanged += _Controle_DataBinding;
                WKListGeral.PropertyChanged += _ControleListGeral_DataBinding;

                //cmdEfetivar_Voucher.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\ok.ico");
                dtgCONTROLE_REG.AutoGenerateColumns = false;
                dtgControleListaGeral.AutoGenerateColumns = false;
                cmdsair.Click += new EventHandler(_Screen_Click);
                cmdbuscar_controles_pendentes.Click += new EventHandler(_Screen_Click);
                cmdControle_Ctrl_Receber.Click += new EventHandler(_Screen_Click);
                cmdControle_Reg_Alterar_Etapa.Click += new EventHandler(_Screen_Click);
                cmdDetalheControle_Reg.Click += new EventHandler(_Screen_Click);
                cmdPrestadorServico.Click += new EventHandler(_Screen_Click);

                cmdDetalheControle_Reg.Enabled = false;
                cmdControle_Reg_Alterar_Etapa.Enabled = false;
                //_Controle_Reg_Pendentes();


                txtdfr_nf_chave.TextChanged += new EventHandler(_Screen_changed);
                txtdfr_nf_numero.TextChanged += new EventHandler(_Screen_changed);
                txtdfr_nf_serie.TextChanged += new EventHandler(_Screen_changed);
                txtdfr_cnpj_cpf.TextChanged += new EventHandler(_Screen_changed);
                dtpdata_emissao.ValueChanged += new EventHandler(_Screen_changed);
                lbl_controle_reg_seq.TextChanged += new EventHandler(_Screen_changed);
                lbl_controle_reg_seq.Text = "";
                txtdfr_nf_chave.LostFocus += new EventHandler(_Screen_lostFocus);
                txtdfr_nf_numero.LostFocus += new EventHandler(_Screen_lostFocus);
                txtdfr_nf_serie.LostFocus += new EventHandler(_Screen_lostFocus);


                _TIMER_tProc = new System.Windows.Forms.Timer();
                _TIMER_tProc.Tick += new EventHandler(tProc_Elapsed);
                _TIMER_tProc.Interval = 1000;
                _TIMER_tProc.Enabled = true;
                _TIMER_tProc.Start();
                _TIMER_EXECUTE = 0;


            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void _Screen_lostFocus(object sender, EventArgs e) { }
        private void _Screen_changed(object sender, EventArgs e)
        {
            _TIMER_EXECUTE = 0;
            try
            {
                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_controle_reg_seq")
                    {
                        cmdDetalheControle_Reg.Enabled = false;
                        cmdControle_Reg_Alterar_Etapa.Enabled = false;
                        //cmdControle_Reg_RecusarEntrada.Enabled = false;
                        _Screen_Clear_lblinfo();
                        if (lbl_controle_reg_seq.Text != "")
                        {
                            cmdDetalheControle_Reg.Enabled = true;
                            cmdControle_Reg_Alterar_Etapa.Enabled = true;

                        }
                    }
                }
                if (sender.GetType().Name == "TextBox"){}
                if (sender.GetType().Name == "DateTimePicker"){}
                if (sender.GetType().Name == "CheckBox"){}
                if (sender.GetType().Name == "ComboBox"){}
                if (sender.GetType().Name == "TabControl") {}
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
                if (((Button)sender).Name == "cmdbuscar_controles_pendentes") { _Consultar(); } 
                if (((Button)sender).Name == "cmdControle_Ctrl_Receber") { _Controle_Ctrl_ReceberDocumentoFiscal(); }
                if (((Button)sender).Name == "cmdDetalheControle_Reg") { _Controle_Reg_Detalhe(); }
                if (((Button)sender).Name == "cmdControle_Reg_Alterar_Etapa") { _Controle_Reg_Alterar_Etapa(); }
                if (((Button)sender).Name == "cmdPrestadorServico") { _Controle_Ctrl_PrestadorServico(); }
                
            }
        }

        private void cmdReceber_Click(object sender, EventArgs e)
        {
            _Controle_Ctrl_ReceberDocumentoFiscal();
        }

        private void cmdRecibo_Click(object sender, EventArgs e)
        {
            Pag_Net.Bll.Controle.tbcontrole i = new Pag_Net.Bll.Controle.tbcontrole(1,1,Convert.ToDateTime("09-02-2022"), 1,1,0);

            List<Pag_Net.Bll.Controle.tbcontrole> _l = new List<Pag_Net.Bll.Controle.tbcontrole>();
            _l.Add(i);



            Pag_Form.report.frmReportView frm = new report.frmReportView(_l.ToArray(), "Pag_Form.report.Rpt_Controle_Recebimento_Senha.rdlc", "DataSet_TbControle", null);
            // Pag_Wpf.ReportViewForm ReportBrandao = new ReportViewForm(BLL.Faturamento.ViewData, "Pag_Wpf.ReportForm.rptTbFaturamento.rdlc", "DataSetTbFaturamento");

            frm.ShowDialog();
        }

        private void _Controle_Reg_Detalhe()
        {
            try
            {
                if (lbl_controle_cd.Text == "")
                {
                    Pag_Form.UserTools._Screen_MessageBox(this, Pag_Form.UserTools.PagTipoMessageBox.Info, "Tipo de Controle Não informado, favor solicitar ajuda do suporte");
                    return;
                }

                if (lbl_controle_reg_seq.Text == "")
                {
                    Pag_Form.UserTools._Screen_MessageBox(this, Pag_Form.UserTools.PagTipoMessageBox.Info, "Sequêncial do Controle Não informado, favor solicitar ajuda do suporte");
                    return;
                }

                int controle_cd = Convert.ToInt32(lbl_controle_cd.Text);
                int controle_reg_seq = Convert.ToInt32(lbl_controle_reg_seq.Text);

                switch (controle_cd)
                {
                    case 10:
                        Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl TipoControle_10_Controle_Ctrl_WK = new Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl(MyConnect);
                        TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Controle_Reg.controle_reg_seq = controle_reg_seq;
                        TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Binding(MyConnect);
                        //TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Controle_Reg.]
                        lblinfo_fornecedor_cnpj.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Transportadora.cpf_cnpj.ToString();
                        lblinfo_fornecedor_nome.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Transportadora.nome_razao.ToString();
                        lblinfo_ControleCtrl_motorista_cnpjcpf.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.cpf_cnpj.ToString();
                        lblinfo_ControleCtrl_motorista_nome.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.nome_razao.ToString();
                        lblinfo_ControleCtrl_veiculo.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Veiculo.veiculo_modelo_descricao + "Placa: " + TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Veiculo.veiculo_placa.ToString();
                        lblinfo_ControleCtrl_carga_NumeroPallet.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.pallet_qtde.ToString();
                        lblinfo_ControleCtrl_carga_VALOR.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.pallet_valor_unitario.ToString();
                        lblinfo_ControleCtrl_motorista_celular.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.celular_dd.ToString() + "-" + TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.celular_numero.ToString();
                        lblinfo_CartaoAcessoNumero.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.Local_CartaoAcessoNumero.ToString();

                        break;
                    case 15:

                        Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico_Ctrl TipoControle_15_Controle_CtrlWK = new Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico_Ctrl(MyConnect);
                        TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.CONTROLE_REG.controle_reg_seq = controle_reg_seq;
                        TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.Binding(MyConnect);
                        lblinfo_fornecedor_cnpj.Text = TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.PrestadorServico.cpf_cnpj.ToString();
                        lblinfo_fornecedor_nome.Text = TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.PrestadorServico.nome_razao.ToString();
                        lblinfo_ControleCtrl_motorista_cnpjcpf.Text = TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.Tecnico.cpf_cnpj.ToString();
                        lblinfo_ControleCtrl_motorista_nome.Text = TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.Tecnico.nome_razao.ToString();
                        lblinfo_ControleCtrl_veiculo.Text = "";
                        lblinfo_ControleCtrl_carga_NumeroPallet.Text = "";
                        lblinfo_ControleCtrl_carga_VALOR.Text = "";
                        lblinfo_ControleCtrl_motorista_celular.Text = TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.Tecnico.celular_dd.ToString() + "-" + TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.Tecnico.celular_numero.ToString();
                        lblinfo_CartaoAcessoNumero.Text = TipoControle_15_Controle_CtrlWK.Contrato_Servico_Ctrl.Tecnico.Local_CartaoAcessoNumero.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Falha na localização do Tipo de controle informado", ex);
            }


        }
        private void _Controle_Reg_AlterarEtapa(object sender, EventArgs e)
        {

            try
            {
       
                int etapa_a_finalizar = 0;
                int etapa_a_considerar = 0;
                int controle_status_cd = 0;
       

                if (lbl_controle_status_cd.Text != "")
                    controle_status_cd = Convert.ToInt32(lbl_controle_status_cd.Text);

                switch (((Button)sender).Name)
                {
                    case "cmdETAPA_FINALIZA_04":
                        etapa_a_finalizar = 4;
                        etapa_a_considerar = 5;
                        controle_status_cd = 1;
                        break;
                    case "cmdETAPA_FINALIZA_08":
                        etapa_a_finalizar = 8;
                        etapa_a_considerar = 9;
                        controle_status_cd = 1;
                        break;
                    case "cmdETAPA_FINALIZA_09":
                        etapa_a_finalizar = 9;
                        etapa_a_considerar = 10;
                        controle_status_cd = 2;
                        break;
                }
                Pag_Form.UserTools._Screen_Wait(this, true);
                //Pag_Net.Bll.Controle.Pool.Controle_etapa_finalizar(MyConnect, Convert.ToInt32(lbl_controle_reg_seq.Text), Convert.ToInt32(lbl_vcontrole_reg_fila_seq.Text), etapa_a_finalizar, etapa_a_considerar, controle_status_cd);
                Pag_Form.UserTools._Screen_Wait(this, false);

                MessageBox.Show("Etapa alterada com sucesso! A TELA SERÁ ATUALIZADA");
                _Consultar();
            }
            catch (Exception ex)
            {
                Pag_Form.UserTools._Screen_Wait(this, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void _Controle_Reg_Alterar_Etapa()
        {
            try
            {
                if (lbl_controle_cd.Text != "")
                {
                    if (lbl_controle_cd.Text == "10")
                    {
                        _TIMER_tProc.Stop();
                        frm_Transporte_Ctrl frm = new frm_Transporte_Ctrl(MyConnect, frm_Transporte_Ctrl.Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo, Convert.ToInt32(lbl_controle_reg_seq.Text), null);
                        frm.ShowDialog();
                    }
                    if (lbl_controle_cd.Text == "15")
                    {
                        _TIMER_tProc.Stop();
                        frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Alterar_Etapa_Externo, Convert.ToInt32(lbl_controle_reg_seq.Text));
                        FrmServicoExecucaoCtrl.ShowDialog();
                    }

                    if (lbl_controle_cd.Text == "12")
                    {
                        _TIMER_tProc.Stop();
                        Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl frmRecursoCtrl = new Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl(MyConnect, Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl.Form_Action.Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text));
                        frmRecursoCtrl.ShowDialog();

                    }
                }
                _Consultar();
                _TIMER_EXECUTE = -15;
                _TIMER_tProc.Start();
            }
            catch (Exception ex)
            {
                _TIMER_EXECUTE = -15;
                _TIMER_tProc.Start();
                MessageBox.Show(ex.Message);
            }
        }

        private void tProc_Elapsed(object sender, EventArgs e)
        {
            try
            {

                _TIMER_EXECUTE += 1;
                if (_TIMER_EXECUTE >= _TIMER_EXECUTE_LIMIT)
                {
                    Pag_Form.UserTools._Screen_Wait(this, true);
                    _Consultar();
                    Pag_Form.UserTools._Screen_Wait(this, false);
                    _TIMER_EXECUTE = 0;
                }
                lblatualizacao_timer.Text = string.Format("Atualização em: {0}/{1}", _TIMER_EXECUTE.ToString(), _TIMER_EXECUTE_LIMIT.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtdfr_nf_chave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                try
                {
                    if (txtdfr_nf_chave.Text.Length == 44)
                    _Controle_Ctrl_ReceberDocumentoFiscal();

                    if (txtdfr_nf_chave.Text.Length == 13)
                        _Controle_Ctrl_PrestadorServico();
                    //_receber_via_chave();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void txtdfr_nf_chave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtdfr_nf_chave.Text.Length == 44)
                        _Controle_Ctrl_ReceberDocumentoFiscal();

                    if (txtdfr_nf_chave.Text.Length == 13)
                        _Controle_Ctrl_PrestadorServico();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void _Screen_Clear_lblinfo()
        {

            lblinfo_ControleCtrl_carga_NumeroPallet.Text = "";
            lblinfo_ControleCtrl_carga_VALOR.Text = "";
            lblinfo_ControleCtrl_motorista_celular.Text = "";
            lblinfo_ControleCtrl_motorista_cnpjcpf.Text = "";
            lblinfo_ControleCtrl_motorista_nome.Text = "";
            lblinfo_ControleCtrl_veiculo.Text = "";
            lblinfo_fornecedor_cnpj.Text = "";
            lblinfo_fornecedor_nome.Text = "";

        }

        private void _Controle_Ctrl_ReceberDocumentoFiscal()
        {

            try
            {
                UserTools._Screen_Wait(this, cmdControle_Ctrl_Receber, true);
                _TIMER_tProc.Stop();
                Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro DocumentoFiscal = new Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro();
                if (txtdfr_nf_chave.Text.Trim() == "0")
                {
                    txtdfr_nf_chave.Text = "";
                }
                if (txtdfr_nf_chave.Text != "") //Recebimento pelo número da chave
                {
                    txtdfr_nf_chave.Text = txtdfr_nf_chave.Text.Trim();
                    if (txtdfr_nf_chave.Text.Length >= 1 && txtdfr_nf_chave.Text.Length < 44)
                    {
                        UserTools._Screen_Wait(this, cmdControle_Ctrl_Receber, false);
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, string.Format("Chave NFE {0} Indica é INVÁLIDA", txtdfr_nf_chave.Text));
                        _TIMER_tProc.Start();
                        return;

                    }
                    DocumentoFiscal.dfr_nf_chave = txtdfr_nf_chave.Text.ToString(); //Uma vez informada a chave, os demais campos são preenchidos automaticamente
                    txtdfr_nf_numero.Text = DocumentoFiscal.dfr_nf_numero.ToString();
                    txtdfr_nf_serie.Text = DocumentoFiscal.dfr_nf_serie.ToString();
                    txtdfr_cnpj_cpf.Text = DocumentoFiscal.dfr_cnpj_cpf.ToString();
                }
                else
                {

                    if (txtdfr_nf_numero.Text == "" || txtdfr_nf_serie.Text == "" || txtdfr_cnpj_cpf.Text == "")
                    {
                        _TIMER_tProc.Start();
                        UserTools._Screen_Wait(this, cmdControle_Ctrl_Receber, false);
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor indicar o Número da Nota / Número de série");
                        return;
                    }

                    //DocumentoFiscal.dfr_nf_chave = txtdfr_nf_chave.Text.ToString();
                    DocumentoFiscal.dfr_nf_numero = Convert.ToInt32(txtdfr_nf_numero.Text.ToString());
                    DocumentoFiscal.dfr_nf_serie = Convert.ToInt32(txtdfr_nf_serie.Text.ToString());
                    DocumentoFiscal.dfr_nf_data_emissao = dtpdata_emissao.Value;
                    try
                    {
                        DocumentoFiscal.dfr_cnpj_cpf = txtdfr_cnpj_cpf.Text.ToString();
                    }
                    catch (Exception ex)
                    {
                        UserTools._Screen_Wait(this, cmdControle_Ctrl_Receber, false);
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
                        txtdfr_nf_numero.Text = "";
                        txtdfr_nf_chave.Text = "";
                        txtdfr_nf_serie.Text = "";
                        txtdfr_cnpj_cpf.Text = "";
                        _TIMER_tProc.Start();
                        return;
                    }
                }

                if (MessageBox.Show(string.Format("Confirma o recebimento da Nota Fiscal N. {0} CNPJ: {1}", DocumentoFiscal.dfr_nf_numero.ToString(), DocumentoFiscal.dfr_cnpj_cpf.ToString()), "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    _TIMER_tProc.Enabled = false;
                    UserTools._Screen_Wait(this, cmdControle_Ctrl_Receber, true);

                    if (DocumentoFiscal.dfr_nf_numero == 0 )
                    {
                        UserTools._Screen_MessageBox(this, "Número da Nota Não informado");
                        return;
                    }

                    /*
                    if (DocumentoFiscal.dfr_nf_serie == 0)
                    {
                        UserTools._Screen_MessageBox(this, "Informe o NÚMERO de SÉRIE da Nota fiscal");
                        return;
                    }*/

                    if (DocumentoFiscal.dfr_cnpj_cpf == "")
                    {
                        UserTools._Screen_MessageBox(this, "Fornecedor Não informado");
                        return;
                    }

                    frm_Transporte_Ctrl FRM = new frm_Transporte_Ctrl(MyConnect, frm_Transporte_Ctrl.Ctrl_Transporte_Form_Action.Ctrl_Transporte_Inclusao_Externa, 0, DocumentoFiscal);
                    UserTools._Screen_Wait(this, cmdControle_Ctrl_Receber, false);
                    FRM.ShowDialog();
                    _Consultar();
                }
                txtdfr_nf_numero.Text = "";
                txtdfr_nf_chave.Text = "";
                txtdfr_nf_serie.Text = "";
                txtdfr_cnpj_cpf.Text = "";
                _TIMER_tProc.Enabled = true;
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdControle_Ctrl_Receber, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
                txtdfr_nf_numero.Text = "";
                txtdfr_nf_chave.Text = "";
                txtdfr_nf_serie.Text = "";
                txtdfr_cnpj_cpf.Text = "";
                _TIMER_tProc.Enabled = true;
            }
        }
        private void _Controle_Ctrl_PrestadorServico()
        {
            try 
            {
                frm_Servico_Execucao_Ctrl frmServicoExececuaoCtrl;
                string CODIGOCARTAO = "";
                if (txtdfr_nf_chave.Text.Length == 13)
                {
                    CODIGOCARTAO = txtdfr_nf_chave.Text;
                    Pag_Net.Bll.F0137_CartaoAcesso.Wk CartaoAcessoWK = new Pag_Net.Bll.F0137_CartaoAcesso.Wk(MyConnect);
                    if (CartaoAcessoWK.Cartao_status_disponivel_get(CODIGOCARTAO).cartao_acesso_seq == 0 )
                    {
                        txtdfr_nf_chave.Text = "";
                        string _strInformativo = string.Format("CARTÃO DE ACESSO | Código de Barra {0} IDENTIFICADO, porém já está em uso em outro Acesso. \n Favor averiguar com o Administrativo.", CODIGOCARTAO);
                        UserTools._Screen_MessageBox(this, _strInformativo);
                        return; 
                    }

                    frmServicoExececuaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Inclusao_Externa, CODIGOCARTAO);
                    txtdfr_nf_chave.Text = "";
                }
                else
                {
                    frmServicoExececuaoCtrl =  new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Inclusao_Externa, 0);
                }
                frmServicoExececuaoCtrl.ShowDialog();
            }
            catch ( Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }
        private void _Controle_DataBinding(object sender, PropertyChangedEventArgs e)
        {
            lblTotalControleEmAndamento.Text = "";
            lblTotalControleEmAndamento.Text = dtgControleListaGeral.Rows.Count.ToString();
            dtgCONTROLE_REG.DataSource = WK.dbList.List;
            cmdControle_Ctrl_Receber.Text = "╚ " + Pag_Net.Bll.Controle.Recebimento_Mercadoria.Proximo_Numero_Recebimento(MyConnect).ToString();
            if (dtgCONTROLE_REG.DataSource != null)
            {
                lblICO_CONTROLE.Image = null;

                foreach (Control item in this.Controls)
                {
                    if (item.Name.Substring(0, 4) == "lbl_")
                    {
                        string name = item.Name.Substring(4);
                        item.DataBindings.Clear();
                        item.DataBindings.Add("Text", dtgCONTROLE_REG.DataSource, name);
                    }
                }
                if (lbl_controle_cd.Text == "10")
                    lblICO_CONTROLE.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\CONTROLE_10.ico");
            }

            foreach (DataGridViewRow row in dtgCONTROLE_REG.Rows)
            {
                //if (Convert.ToInt32(row.Cells[12].Value) > 0) { row.DefaultCellStyle.BackColor = Color.LightCoral; }

                if (Convert.ToInt32(row.Cells[14].Value) == 15) { row.DefaultCellStyle.BackColor = Color.DarkSeaGreen; }

                if (Convert.ToInt32(row.Cells[14].Value) == 12) { row.DefaultCellStyle.BackColor = Color.AliceBlue; }

            }

            Pag_Form.UserTools._Screen_Wait(this, false);   
        }

        private void _ControleListGeral_DataBinding(object sender, PropertyChangedEventArgs e)
        {
            dtgControleListaGeral.DataSource = WKListGeral.dbList.List;
        }

        private void cmdbuscar_controles_pendentes_Click(object sender, EventArgs e)
        {
            _Consultar();
        }

        private void _Consultar()
        {
            try
            {
                WK.__Filtro.controle_reg_data_inicial = DateTime.Now.AddDays(-15);
                WK.__Filtro.controle_reg_data_final = DateTime.Now;
                WK.__Filtro.controle_status_cd = 1;
                WK.ControleRegList_Get(Pag_Net.Bll.F0130_Controle.Wk.ControleTipoAtendimentos.Portaria);

                WKListGeral.__Filtro.controle_reg_data_inicial = DateTime.Now.AddDays(-15);
                WKListGeral.__Filtro.controle_reg_data_final = DateTime.Now;
                WKListGeral.__Filtro.controle_status_cd = 1;
                WKListGeral.ControleRegList_Get();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

 
    }
}
