using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Ctrl.Recurso
{
    public partial class frm_Recurso_Ctrl : Form
    {
        Form_Action __Screen_Form_Action;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0138_Recurso_Ctrl.Wk WK;
        Pag_Net.Bll.F0011_Participante.Wk WKParticipante;
        
        public enum Form_Action
        {
            Consultar = 0,
            Incluir = 1,
            Alterar_Etapa = 2,
            Inclusao_Externa = 3
        }

        Pag_Form.user_control.frmUC_DocumentoFiscalRegistro frmUC_DocumentoFiscalRegistro;
        Pag_Form.user_control.frmUC_Controle_Reg frmUC_Controle_Reg;

        public frm_Recurso_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new Pag_Net.Bll.F0138_Recurso_Ctrl.Wk(MyConnect);
            WKParticipante = new Pag_Net.Bll.F0011_Participante.Wk(MyConnect);

            _Screen_load(true);
            __Screen_Form_Action = Form_Action.Incluir;
        }

        public frm_Recurso_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect, Form_Action _screen_form_action, int controle_reg_seq)
        {
            try
            {
                InitializeComponent();
                MyConnect = _MyConnect;
                WK = new Pag_Net.Bll.F0138_Recurso_Ctrl.Wk(MyConnect);
                WKParticipante = new Pag_Net.Bll.F0011_Participante.Wk(MyConnect);

                /* ACTION LOAD */
                __Screen_Form_Action = _screen_form_action;

                if (controle_reg_seq != 0)
                {
                    txtfiltro_controle_reg_seq.Text = controle_reg_seq.ToString();
                    _Binding_Recurso_Ctrl();
                }
                _Screen_load(true);

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
                    UserTools._Screen_ButtonImage(cmdProximaEtapa, UserTools.PagButtonsIcons.SetaSimples_Baixo);
                    UserTools._Screen_ButtonImage(cmdCancelar, UserTools.PagButtonsIcons.CancelUndo);
                    UserTools._Screen_ButtonImage(cmdEfetivar, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                    UserTools._Screen_ButtonImage(cmdPesquisarVeiculo, UserTools.PagButtonsIcons.Localizar);
                    UserTools._Screen_ButtonImage(cmdPesquisarFuncionario, UserTools.PagButtonsIcons.Localizar);
                    UserTools._Screen_Form_Format_DataGridView(dtgParticipante);
                    //UserTools._Screen_Form_Format_DataGridView(dtgparticipante);

                    frmUC_Controle_Reg = new Pag_Form.user_control.frmUC_Controle_Reg(MyConnect, WK.Recurso_Ctrl.CONTROLE_REG);
                    frmUC_Controle_Reg.BackColor = System.Drawing.Color.LightSteelBlue;
                    frmUC_Controle_Reg.Location = new System.Drawing.Point(1, 1);
                    frmUC_Controle_Reg.Name = "frmUC_Controle_Reg";
                    frmUC_Controle_Reg.Size = new System.Drawing.Size(1000, 1000);
                    frmUC_Controle_Reg.TabIndex = 0;
                    grpUC_Controle.Controls.Add(frmUC_Controle_Reg);
                    frmUC_Controle_Reg._Exibir_Controle();
                    frmUC_Controle_Reg._Exibir_Etapas();
                    frmUC_Controle_Reg._Exibir_Fila();
                    
                    //txtnome_razao.TextChanged += new EventHandler(_Screen_changed);
                    txtcpf_cnpj.TextChanged += new EventHandler(_Screen_changed);
                }

                if (__Screen_Form_Action == Form_Action.Incluir)
                {

                    txtfiltro_controle_reg_seq.Enabled = false;
                    cmdEfetivar.Enabled = true;
                    cmdCancelar.Enabled = true;
                    cmdConsultar.Enabled = false;
                    cmdNovo_Controle.Enabled = false;

                    cmdProximaEtapa.Enabled = false;
                    grpPesquisar_Funcionario.Visible = true;
                    grpFuncionario.Enabled = true;
                    grpFuncionario.Location = new Point(500, 280);
                    grpVeiculo.Visible = false;
                    chkutilizar_veiculo.Enabled = true;
                    chkutilizar_veiculo.Checked = false;
                }

                if (__Screen_Form_Action == Form_Action.Consultar)
                {

                    int controleRegEtapa = WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd;
                    grpVeiculo.Visible = false; 
                    cmdEfetivar.Enabled = false;
                    cmdCancelar.Enabled = false;
                    cmdConsultar.Enabled = true;
                    cmdProximaEtapa.Enabled = true;
                    grpFuncionario.Location = new Point(500, 54);
                    grpPesquisar_Funcionario.Visible = false;
                    grpFuncionario.Enabled = false;


                    if (controleRegEtapa == 12003)
                    {
                        if (WK.Recurso_Ctrl.recurso_ctrl_utiliza_ativo == 1)
                        {
                            grpVeiculo.Visible = true;
                            grpVeiculo.Enabled = true;
                            grpVeiculo.Location = new Point(500, 280);
                            lbl_km_etapa_descricao.Text = "Etapa atual: " + WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_descricao;
                            lblkm_info.Text = "KM de Saída";
                        }

                    }


                    if (controleRegEtapa == 12004)
                    {


                        if (WK.Recurso_Ctrl.recurso_ctrl_utiliza_ativo == 1) 
                        {
                            grpVeiculo.Visible = true;
                            grpVeiculo.Enabled = true;
                            cmdPesquisarVeiculo.Enabled = false;
                            txtat_veiculo_placa.Enabled = false; 

                            if (WK.Recurso_Ctrl.ATIVO.at_tipo_cd == 200)
                            {
                                lbl_at_seq.Text = WK.Recurso_Ctrl.ATIVO.at_seq.ToString(); 
                                txtat_veiculo_placa.Text = WK.Recurso_Ctrl.ATIVO.Veiculo.at_veiculo_placa.ToString(); 
                            }
                        }

                        grpVeiculo.Location = new Point(500, 280);
                        lbl_km_etapa_descricao.Text = "Etapa atual: " + WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_descricao;
                        lblkm_info.Text = "KM de Retorno (Entrada)";
                    }
                    _Exibir_Recurso_Ctrl();    
                }

                
            }
            catch (Exception ex )
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

   

        private void _limpar_filtro_participante()
        {
            //dtgparticipante.DataSource = null;
            //lbl_cnpj_cpf.Text = "";
            lbl_nome_razao.Text = "";
        }

        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {



                if (sender.GetType().Name == "Label") { }
                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtcpf_cnpj" || ((TextBox)sender).Name == "txtnome_razao")
                    {
                        _limpar_filtro_participante();
                    }

                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox")
                {

                }
                if (sender.GetType().Name == "ComboBox")
                {
          
                }
                if (sender.GetType().Name == "TabControl")
                {


      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void _Binding_Recurso_Ctrl()
        {
            try
            {
                WK.Recurso_Ctrl.CONTROLE_REG.controle_reg_seq = Convert.ToInt32(txtfiltro_controle_reg_seq.Text);
                WK.Recurso_Ctrl.Consultar(MyConnect);

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _Exibir_Recurso_Ctrl()
        {
            try
            {
                //_Binding_Recurso_Ctrl();

                txt_recurso_ctrl_observacao.Text = WK.Recurso_Ctrl.recurso_ctrl_observacao.ToString();
                lbl_cpf_cnpj.Text = WK.Recurso_Ctrl.CONTROLE_REG.Pessoa_Get(91201).cpf_cnpj.ToString();
                lbl_nome_razao.Text = WK.Recurso_Ctrl.CONTROLE_REG.Pessoa_Get(91201).nome_razao.ToString();
                txtcelular_dd.Text = WK.Recurso_Ctrl.CONTROLE_REG.Pessoa_Get(91201).celular_dd.ToString();
                txtcelular_numero.Text = WK.Recurso_Ctrl.CONTROLE_REG.Pessoa_Get(91201).celular_numero.ToString();
                chkutilizar_veiculo.Checked = WK.Recurso_Ctrl.recurso_ctrl_utiliza_ativo == 1 ? true : false; 
                frmUC_Controle_Reg._Clear();
                frmUC_Controle_Reg._GrpControle_Enabled(false);

                WK.Recurso_Ctrl.CONTROLE_REG.Binding(MyConnect, new Pag_Net.Bll.F0130_Controle.model_controle(12, ""));
                frmUC_Controle_Reg.__iWK_Controle = WK.Recurso_Ctrl.CONTROLE_REG;
                frmUC_Controle_Reg._Binding();
                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

   


        private void cmdEfetivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_cpf_cnpj.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Informe um funcionário");
                    return;
                }

                if (WK.Recurso_Ctrl.CONTROLE_REG.Fila.controle_fila_cd == 0)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor informar o Tipo de Saída no Campo Tipo/Fila");
                    return;
                }
                UserTools._Screen_Wait(this);

                if (lbl_at_seq.Text == "")
                    lbl_at_seq.Text = "0";

                WK.Recurso_Ctrl.recurso_ctrl_utiliza_ativo = chkutilizar_veiculo.Checked ? 1 : 0;
                WK.Recurso_Ctrl.at_seq = Convert.ToInt32(lbl_at_seq.Text);
                WK.Recurso_Ctrl.recurso_ctrl_observacao = txt_recurso_ctrl_observacao.Text;
                WK.Recurso_Ctrl.CONTROLE_REG.Pessoas[0].cpf_cnpj = lbl_cpf_cnpj.Text;
                WK.Recurso_Ctrl.CONTROLE_REG.Pessoas[0].nome_razao = lbl_nome_razao.Text;
                WK.Recurso_Ctrl.CONTROLE_REG.Pessoas[0].celular_dd = Convert.ToInt32(txtcelular_dd.Text);
                WK.Recurso_Ctrl.CONTROLE_REG.Pessoas[0].celular_numero = Convert.ToInt32(txtcelular_numero.Text);

                int controleRegEtapa = WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd;

                if (controleRegEtapa == 12003)
                {
                    if (WK.Recurso_Ctrl.recurso_ctrl_utiliza_ativo == 1)
                        if (lbl_at_seq.Text == "")
                        {
                            UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor indicar o veículo");
                            return; 
                        }
                }
                WK.Recurso_Ctrl.Registrar(MyConnect);

                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Registro Incluído com sucesso");
                UserTools._Screen_Wait(this, false);
                __Screen_Form_Action = Form_Action.Consultar;
                _Screen_load(false);
            }

            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdPesquisarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                txtnome_razao.Text = txtnome_razao.Text.ToString().ToUpper();
                WKParticipante.Filtros.cpf_cnpj = txtcpf_cnpj.Text;
                WKParticipante.Filtros.nome_razao = txtnome_razao.Text;
                WKParticipante.Filtros.funcionario_cd = Convert.ToInt32(txtfuncionario_cd.Text);
                WKParticipante.Filtros.list_participante_tipo = "101";
                WKParticipante.ParticipantePessoaList_Get();
                dtgParticipante.DataSource = WKParticipante.DbParticipanteList.List;
                UserTools._Screen_DataBinding_Set(lbl_cpf_cnpj, WKParticipante.DbParticipanteList.List, "cpf_cnpj");
                UserTools._Screen_DataBinding_Set(lbl_nome_razao, WKParticipante.DbParticipanteList.List, "nome_razao");
                UserTools._Screen_Wait(this);

            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex);
            }


        }

        private void cmdProximaEtapa_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma alteração da Etapa"))
                {
                    int controleRegEtapa = WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd;


                    if (controleRegEtapa == 12003)
                    {
                        if (WK.Recurso_Ctrl.recurso_ctrl_utiliza_ativo == 1)
                        {
                            if (lbl_at_seq.Text == "" || lbl_at_seq.Text == "0")
                            {
                                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Este controle exige a indicação do veículo. Favor indicar a placa do veículo e clicar em pesquisar!");
                                return;
                            }

                            if (txt_at_reg_veiculo_km.Text == "")
                            {
                                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "KM não informado");
                                return;
                            }

                            if (lbl_at_seq.Text == "")
                                lbl_at_seq.Text = "0";

                            WK.Recurso_Ctrl.ATIVO.Registro.RegistroVeiculo.at_reg_veiculo_km = Convert.ToInt32(txt_at_reg_veiculo_km.Text);
                        }
                    }


                    if (controleRegEtapa == 12004)
                    {
                        if (WK.Recurso_Ctrl.recurso_ctrl_utiliza_ativo == 1)
                        {
                            if (lbl_at_seq.Text == "")
                            {
                                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor indicar o veículo");
                                return;
                            }

                            if (txt_at_reg_veiculo_km.Text == "")
                            {
                                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "KM não informado");
                                return;
                            }
                            WK.Recurso_Ctrl.ATIVO.Registro.RegistroVeiculo.at_reg_veiculo_km = Convert.ToInt32(txt_at_reg_veiculo_km.Text);
                        }
                    }
                    UserTools._Screen_Wait(this);
                    WK.Recurso_Ctrl._Etapa_Step(MyConnect, 0);
                    UserTools._Screen_Wait(this, false);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdPesquisarVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
              
                UserTools._Screen_Wait(this);

                Pag_Net.Bll.F0035_Ativo.Models.Model_TbAtivo[] VEICULOS = Pag_Net.Bll.F0035_Ativo.MyGets.listVeiculoGet(MyConnect, txtat_veiculo_placa.Text);
                if (VEICULOS.Count() <= 0)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Veículo não encontrado");
                    return; 
                }

                WK.Recurso_Ctrl.ATIVO = VEICULOS[0];

                if (WK.Recurso_Ctrl.ATIVO == null)
                {
                    UserTools._Screen_MessageBox(this, "Ativo não localizado");
                    return;
                }

                if (WK.Recurso_Ctrl.ATIVO.at_seq == 0)
                {
                    UserTools._Screen_MessageBox(this, "Ativo não localizado");
                    return; 
                }

                

                lbl_at_seq.Text = WK.Recurso_Ctrl.ATIVO.at_seq.ToString();
                lbl_at_descricao.Text = WK.Recurso_Ctrl.ATIVO.at_descricao.ToString();

                lbl_km_etapa_descricao.Text = WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_descricao;

                if (WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd == 12003)
                    lblkm_info.Text = "KM de Saída";

                if (WK.Recurso_Ctrl.CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd == 12004)
                    lblkm_info.Text = "KM de Retorno (Entrada)";

                UserTools._Screen_Wait(this);
                    
            }

            catch ( Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
