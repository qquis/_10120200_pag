using Pag_Net.Bll.F0011_Participante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_Participante : Form
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        
        Pag_Net.Bll.F0011_Participante.ModelParticipante Participante;
        bool isEdit = false;
        int isEditTabInfo = -1;
        
        public frm_Participante(Pag_Net.Models.modelSistemaUsuario _myConnect, Pag_Net.Bll.F0011_Participante.ModelParticipante _Participante)
        {
            try
            {
                InitializeComponent();
                MyConnect = _myConnect;

                Participante = _Participante;

                _Screen_load(); 


                
   
            }
            catch (Exception ex )
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_Form_Open(this);
                UserTools._Screen_ButtonImage(cmdEfetivar_dados, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdCancela_Alteracao, UserTools.PagButtonsIcons.CancelUndo);
                UserTools._Screen_ButtonImage(cmdEditar, UserTools.PagButtonsIcons.Editar);
                UserTools._Screen_ButtonImage(cmdLocalizarPessoaJuridicaVendedor, UserTools.PagButtonsIcons.Localizar);
                UserTools._Screen_ButtonImage(cmdLocalizarVendedorParticipanteContador, UserTools.PagButtonsIcons.Localizar);
                UserTools._Screen_ButtonImage(cmdParticipante_Funcionario_ADD, UserTools.PagButtonsIcons.Novo);

                cmdEfetivar_dados.Enabled = false;
                cmdCancela_Alteracao.Enabled = false;
                cmdEditar.Enabled = true; 

                UserTools._Screen_Form_Format_DataGridView(dtgParticipanteTipo);
                UserTools._Screen_Form_Format_DataGridView(dtgEnderecos);
                UserTools._Screen_Form_Format_DataGridView(dtgContatos);
                UserTools._Screen_Form_Format_DataGridView(dtgFuncionarioList);

                if (Participante.cdparticipante != 0)
                {
                    Participante_Binding();
                    Participante_Endereco_Bindig();
                    Participante_BlueSoft_Binding();
                    Participante_Contato_Binding();
                    Participante_PF_Binding();
                    Participante_Vendedor_Binding();
                    Participante_Funcionario_Binding();
                }

                Participante.PropertyChanged += __Bindings;

                cmbrh_tipo_contrato_descricao.ValueMember = "rh_tipo_contrato_cd";
                cmbrh_tipo_contrato_descricao.DisplayMember = "rh_tipo_contrato_descricao";
                cmbrh_tipo_contrato_descricao.DataSource = Pag_Net.Bll.F0141_Rh.MyGets.Tipo_Contratos(MyConnect, 0);


                cmbrh_setor_operacional_descricao.ValueMember = "rh_setor_operacional_cd";
                cmbrh_setor_operacional_descricao.DisplayMember = "rh_setor_operacional_descricao";
                cmbrh_setor_operacional_descricao.DataSource = Pag_Net.Bll.F0141_Rh.MyGets.Setor_Operacional(MyConnect);


                if (!Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 99915101))
                {
                    txt_rh_vl_salario.PasswordChar = Convert.ToChar("*");
                    txt_rh_vl_salario_liq.PasswordChar = Convert.ToChar("*");
                    txt_rh_vl_pj.PasswordChar = Convert.ToChar("*");
                    txt_rh_vl_outros.PasswordChar = Convert.ToChar("*");
                    txt_rh_vl_contrato_liq.PasswordChar = Convert.ToChar("*");
                    txt_rh_vl_contrato_bruto.PasswordChar = Convert.ToChar("*");
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {



                if (sender.GetType().Name == "Label") { }
                if (sender.GetType().Name == "TextBox")
                {



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

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        
        private void _Screen_Click(object sender, EventArgs e) { }

        public void _Screen_Enablad(bool status)
        {
            try
            {
                txtcdparticipante.Enabled = status;
                txtnome_razaosocial.Enabled = status;
                txtcpf_cnpj.Enabled = status;
                dtp_pf_data_nascimento.Enabled = status;
                dtp_pf_documento_cnh_validade.Enabled = status;

                txtendereco_cep.Enabled = status;
                cmbendereco_uf.Enabled = status;
                cmbendereco_municipio.Enabled = status;
                txtendereco_logradouro.Enabled = status;
                txtendereco_numero.Enabled = status;
                txtendereco_bairro.Enabled = status;
                txtendereco_complemento.Enabled = status;

                txt_contato_email.Enabled = status;
                txt_contato_instagram.Enabled = status;
                txt_contato_facebook.Enabled = status;
                txt_contato_celular_dd.Enabled = status;
                txt_contato_celular_numero.Enabled = status;

                txtcdpessoabluesoft.Enabled = status;
                txtLOCAL_bluesoftcliente.Enabled = status;
                txtLOCAL_bluesoftvendedor.Enabled = status;
                txtLOCAL_bluesoftfabricante.Enabled = status;
                txtLOCAL_bluesoftfornecedor.Enabled = status;
                txtLOCAL_bluesoftfabricante.Enabled = status;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        public void __Bindings(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListParticipanteEndereco") Participante_Endereco_Bindig();
            if (e.PropertyName == "ListParticipanteContato") Participante_Contato_Binding();
        }

        public void Participante_Binding()
        {
            try
            {
                Participante.Model_Consultar(MyConnect);

                dtgParticipanteTipo.DataSource = Participante.ListParticipanteTiposRegs;

                LBL_DADOS_GERAIS.Text = Participante.nome_razao.ToString() + " | Cod. " + Participante.cdparticipante.ToString();

                txtcdparticipante.Text = Participante.cdparticipante.ToString();
                txtnome_razaosocial.Text = Participante.nome_razao.ToString();
                txtcpf_cnpj.Text = Participante.cpf_cnpj.ToString();
                txtcelular_dd.Text = Participante.celular_dd.ToString();
                txtcelular_numero.Text = Participante.celular_numero.ToString();
                txtemail_main.Text = Participante.email_main.ToString();

                //dtpDataNascimento.Value = Participante.Participante_Pf.pf_data_nascimento;
                //dtpcnh_vencimento.Value = Participante.Participante_Pf.pf_documento_cnh_vencimento;


                chkStatus_Participante.Checked = false;
                if (Participante.LOCAL_Status_Participante)
                {
                    chkStatus_Participante.Checked = true;
                }
                if (Participante.LOCAL_PessoaJuridica)
                {
                    chkPessoaJuridica.Checked = true;
                    grpPessoaFisica.Enabled = false;
                    lbl_subtitulo_pessoa_fisica.Text = "Dados Pessoa Física (Não aplicável a este cadastro)";
                }
                else
                {
                    chkPessoaJuridica.Checked = false;
                    grpPessoaFisica.Enabled = true;
                    lbl_subtitulo_pessoa_fisica.Text = "Dados Pessoa Física ";
                }  


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void Participante_Endereco_Bindig()
        {
            try
            {

                dtgEnderecos.DataSource = Participante.ListParticipanteEndereco;

                UserTools._Screen_DataBinding_Set(lbl_endereco_tipo_descricao, Participante.ListParticipanteEndereco, "endereco_tipo_descricao");
                UserTools._Screen_DataBinding_Set(txtendereco_cep, Participante.ListParticipanteEndereco, "endereco_cep");
                UserTools._Screen_DataBinding_Set(txtendereco_logradouro, Participante.ListParticipanteEndereco, "endereco_logradouro");
                UserTools._Screen_DataBinding_Set(txtendereco_numero, Participante.ListParticipanteEndereco, "endereco_numero");
                UserTools._Screen_DataBinding_Set(txtendereco_bairro, Participante.ListParticipanteEndereco, "endereco_bairro");
                UserTools._Screen_DataBinding_Set(cmbendereco_municipio, Participante.ListParticipanteEndereco, "endereco_municipio");
                UserTools._Screen_DataBinding_Set(cmbendereco_uf, Participante.ListParticipanteEndereco, "endereco_uf");
                UserTools._Screen_DataBinding_Set(txtendereco_complemento, Participante.ListParticipanteEndereco, "endereco_complemento");
                UserTools._Screen_DataBinding_Set(txt_endereco_latitude, Participante.ListParticipanteEndereco, "endereco_latitude");
                UserTools._Screen_DataBinding_Set(txt_endereco_longitude, Participante.ListParticipanteEndereco, "endereco_longitude");
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
         
        }
        
        public void Participante_Contato_Binding()
        {
            try
            {
                dtgContatos.DataSource = Participante.ListParticipanteContato;
                UserTools._Screen_DataBinding_Set(lbl_contato_tipo_descricao, Participante.ListParticipanteContato, "contato_tipo_descricao");
                UserTools._Screen_DataBinding_Set(txt_contato_email, Participante.ListParticipanteContato, "contato_email");
                UserTools._Screen_DataBinding_Set(txt_contato_celular_dd, Participante.ListParticipanteContato, "contato_celular_dd");
                UserTools._Screen_DataBinding_Set(txt_contato_celular_numero, Participante.ListParticipanteContato, "contato_celular_numero");
                UserTools._Screen_DataBinding_Set(txt_contato_facebook, Participante.ListParticipanteContato, "contato_facebook");
                UserTools._Screen_DataBinding_Set(txt_contato_instagram, Participante.ListParticipanteContato, "contato_instagram");
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        
        public void Participante_BlueSoft_Binding()
        {
            try
            {

                txtcdpessoabluesoft.Text = Participante.cdpessoabluesoft.ToString();
                txtLOCAL_bluesoftcliente.Text = Participante.LOCAL_bluesoftcliente.ToString();
                txtLOCAL_bluesoftvendedor.Text = Participante.LOCAL_bluesoftvendedor.ToString();
                txtLOCAL_bluesoftfabricante.Text = Participante.LOCAL_bluesoftfabricante.ToString();
                txtLOCAL_bluesoftfornecedor.Text = Participante.LOCAL_bluesoftfornecedor.ToString();
                txtLOCAL_bluesoftfabricante.Text = Participante.LOCAL_bluesoftfabricante.ToString();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        
        public void Participante_PF_Binding()
        {
            try
            {
                if (Participante.ParticipantePf.pf_sexo == "M")
                    opt_pf_sexo_M.Checked = true;
                else
                    opt_pf_sexo_F.Checked = true;

                txt_pf_documento_cnh.Text = Participante.ParticipantePf.pf_documento_cnh.ToString();
                dtp_pf_data_nascimento.Value = Participante.ParticipantePf.pf_data_nascimento;
                dtp_pf_documento_cnh_validade.Value = Participante.ParticipantePf.pf_documento_cnh_validade;
                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        
        public void Participante_Vendedor_Binding()
        {
            try
            {

                if (Participante.__Model_ConferirTipoPessoa(121))
                {
                    if (Participante.ParticipanteVendedor.vendedor_status == 1)
                        chk_vendedor_status.Checked = true;
                    else
                        chk_vendedor_status.Checked = false;
                    txt_vendedor_cdparticipante_pj.Text = Participante.ParticipanteVendedor.vendedor_cdparticipante_pj.ToString();
                    lbl_vendedor_cdparticipante_pj.Text = Participante.ParticipanteVendedor.VendedorPJ.nome_razao;
                    txt_vendedor_cdparticipante_contador.Text = Participante.ParticipanteVendedor.vendedor_cdparticipante_contador.ToString();
                    lbl_vendedor_cdparticipante_contador.Text = Participante.ParticipanteVendedor.VendedorContabilidade.nome_razao;
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        public void Participante_Funcionario_Binding()
        {
            try
            {

                if (Participante.__Model_ConferirTipoPessoa(101))
                {

                    dtgFuncionarioList.DataSource = Participante.ListParticipanteFuncinario;


                    chk_funcionario_status.DataBindings.Clear();
                    chk_funcionario_status.DataBindings.Add("Checked", Participante.ListParticipanteFuncinario, "funcinario_status_LOCAL");

                    UserTools._Screen_DataBinding_Set(lbl_funcionario_cd, Participante.ListParticipanteFuncinario, "rh_funcionario_cd");
                    UserTools._Screen_DataBinding_Set(lbl_funcionario_cd_dv, Participante.ListParticipanteFuncinario, "rh_funcionario_dv");
                    UserTools._Screen_DataBinding_Set(lbl_funcionario_data_admissao, Participante.ListParticipanteFuncinario, "data_admissao");
                    UserTools._Screen_DataBinding_Set(lbl_funcionario_data_rescisao, Participante.ListParticipanteFuncinario, "data_rescisao");
                    UserTools._Screen_DataBinding_Set(lbl_funcionario_dtm_cargo, Participante.ListParticipanteFuncinario, "dtm_cargo_descricao");
                    UserTools._Screen_DataBinding_Set(lbl_funcionario_dtm_depto, Participante.ListParticipanteFuncinario, "dtm_funcionario_situacao_descricao");
                    UserTools._Screen_DataBinding_Set(lbl_funcionario_dtm_setor, Participante.ListParticipanteFuncinario, "dtm_setor_descricao");
                    UserTools._Screen_DataBinding_Set(lbl_funcionario_dtm_secao, Participante.ListParticipanteFuncinario, "dtm_secao_descricao");
                    UserTools._Screen_DataBinding_Set(cmbrh_setor_operacional_descricao, Participante.ListParticipanteFuncinario, "rh_setor_operacional_descricao");
                    UserTools._Screen_DataBinding_Set(cmbrh_tipo_contrato_descricao, Participante.ListParticipanteFuncinario, "rh_tipo_contrato_descricao");
                    UserTools._Screen_DataBinding_Set(txt_rh_vl_contrato_bruto, Participante.ListParticipanteFuncinario, "rh_vl_contrato_bruto");
                    UserTools._Screen_DataBinding_Set(txt_rh_vl_contrato_liq, Participante.ListParticipanteFuncinario, "rh_vl_contrato_liq");
                    UserTools._Screen_DataBinding_Set(txt_rh_vl_salario, Participante.ListParticipanteFuncinario, "rh_vl_salario");
                    UserTools._Screen_DataBinding_Set(txt_rh_vl_salario_liq, Participante.ListParticipanteFuncinario, "rh_vl_salario_liq");
                    UserTools._Screen_DataBinding_Set(txt_rh_vl_pj, Participante.ListParticipanteFuncinario, "rh_vl_pj");
                    UserTools._Screen_DataBinding_Set(txt_rh_vl_outros, Participante.ListParticipanteFuncinario, "rh_vl_outros"); 
                    
                    
                    

                    /*
                                         if (Participante.ParticipanteFuncinario.funcionario_status == 1)
                        chk_funcionario_status.Checked = true;
                    else
                        chk_funcionario_status.Checked = false;

                     */

                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEfetivar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);


                if (isEditTabInfo == 0)
                {
                    Participante.celular_dd = Convert.ToInt32(txtcelular_dd.Text);
                    Participante.celular_numero = Convert.ToInt32(txtcelular_numero.Text);
                    Participante.email_main = txtemail_main.Text;
                    Participante.participante_status = chkStatus_Participante.Checked ? 1 : 0;
                    Participante.__Atualizar(MyConnect);
                    Participante.Model_Atualizar_ParticipanteTiposRegs(MyConnect);
                    Participante.__Model_Consultar_ParticipanteTiposRegs(MyConnect);
                    dtgParticipanteTipo.DataSource = Participante.ListParticipanteTiposRegs;
                    Participante_Binding();
                }

                if (isEditTabInfo == 2)
                {
                    Participante.Model_Atualizar_Enderecos(MyConnect);
                    Participante_Endereco_Bindig();
                }

                if (isEditTabInfo == 3)
                {
                    Participante.Model_Atualizar_Contatos(MyConnect);
                    Participante_Contato_Binding();
                }

                if (isEditTabInfo == 4)
                {
                    Participante.ParticipantePf.pf_documento_rg = "";
                    Participante.ParticipantePf.pf_data_nascimento = dtp_pf_data_nascimento.Value;
                    Participante.ParticipantePf.pf_documento_cnh = txt_pf_documento_cnh.Text;
                    Participante.ParticipantePf.pf_documento_cnh_validade = dtp_pf_documento_cnh_validade.Value;
                    Participante.Model_Atualiza_PF(MyConnect);
                    Participante_PF_Binding();
                }

                if (isEditTabInfo == 5)
                {
                    Participante.ParticipanteVendedor.vendedor_status = chk_vendedor_status.Checked ? 1 : 0;
                    Participante.ParticipanteVendedor.vendedor_fv_comis_mail = 1;
                    Participante.ParticipanteVendedor.vendedor_cdparticipante_pj = Convert.ToInt32(txt_vendedor_cdparticipante_pj.Text);
                    Participante.ParticipanteVendedor.vendedor_cdparticipante_contador = Convert.ToInt32(txt_vendedor_cdparticipante_contador.Text);
                    Participante.Model_Atualiza_Vendedor(MyConnect);
                    Participante.__Model_Consultar_Vendedor(MyConnect);
                    Participante_Vendedor_Binding();
                }

                if (isEditTabInfo == 6)
                {
                    Participante.Model_Atualizar_Funcionario(MyConnect);
                    Participante_Funcionario_Binding();

                    Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario MyParticipanteFuncionario = ((Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario)dtgFuncionarioList.Rows[dtgFuncionarioList.SelectedRows[0].Index].DataBoundItem);

                    if (txt_rh_vl_contrato_bruto.Text == "") txt_rh_vl_contrato_bruto.Text = "0";
                    if (txt_rh_vl_contrato_liq.Text == "") txt_rh_vl_contrato_liq.Text = "0";
                    if (txt_rh_vl_salario.Text == "") txt_rh_vl_salario.Text = "0";
                    if (txt_rh_vl_salario_liq.Text == "") txt_rh_vl_salario_liq.Text = "0";
                    if (txt_rh_vl_pj.Text == "") txt_rh_vl_pj.Text = "0";
                    if (txt_rh_vl_outros.Text == "") txt_rh_vl_outros.Text = "0";

                    MyParticipanteFuncionario.rh_vl_contrato_bruto = Convert.ToInt32(txt_rh_vl_contrato_bruto.Text);
                    MyParticipanteFuncionario.rh_vl_contrato_liq = Convert.ToDouble(txt_rh_vl_contrato_liq.Text);
                    //MyParticipanteFuncionario.rh_vl_folha_brt = Convert.ToDouble(txt_rh_vl_folha_brt.Text);
                    MyParticipanteFuncionario.rh_vl_salario_liq = Convert.ToDouble(txt_rh_vl_salario_liq.Text);
                    MyParticipanteFuncionario.rh_vl_pj = Convert.ToDouble(txt_rh_vl_pj.Text);
                    MyParticipanteFuncionario.rh_vl_outros = Convert.ToDouble(txt_rh_vl_outros.Text);
                    
                }

                __screen_Edit_Cancel(false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Atualização realizada com sucesso!");
                UserTools._Screen_Wait(this, false);
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            try
            {
                __screen_Edit_Cancel(true); 
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        public void __screen_Edit_Cancel(bool _edit)
        {
            isEdit = _edit;
            isEditTabInfo = tabinfo.SelectedIndex;

            if (isEdit)
            {
                cmdEfetivar_dados.Enabled = true;
                cmdCancela_Alteracao.Enabled = true;
                cmdEditar.Enabled = false; 
            }
            else
            {
                cmdEfetivar_dados.Enabled = false;
                cmdCancela_Alteracao.Enabled = false;
                cmdEditar.Enabled = true; 
            }


            if (isEditTabInfo == 0)
            {

                txtcelular_dd.Enabled = _edit;
                txtcelular_numero.Enabled = _edit;
                txtemail_main.Enabled = _edit;
                chkStatus_Participante.Enabled = _edit;
                dtgParticipanteTipoCheckBox.ReadOnly = !_edit;
            }


            if (isEditTabInfo == 2)
            {
                //lbl_endereco_tipo_descricao.Enabled = _edit;
                txtendereco_cep.Enabled = _edit;
                txtendereco_logradouro.Enabled = _edit;
                txtendereco_numero.Enabled = _edit;
                txtendereco_bairro.Enabled = _edit;
                cmbendereco_municipio.Enabled = _edit;
                cmbendereco_uf.Enabled = _edit;
                txtendereco_complemento.Enabled = _edit;
                dtgEnderecos.Enabled = _edit? false: true;
            }

            if (isEditTabInfo == 3)
            {
                txt_contato_email.Enabled = _edit;
                txt_contato_facebook.Enabled = _edit;
                txt_contato_instagram.Enabled = _edit;
                txt_contato_celular_dd.Enabled = _edit;
                txt_contato_celular_numero.Enabled = _edit;
            }
            if (isEditTabInfo == 4)
            {
                if (_edit)
                {
                    if (Participante.pessoajuridica == 1)
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Dados não podem ser editados para pessoa do tipo Jurídica");
                        __screen_Edit_Cancel(false);
                        return;
                    }
                }
                grpPessoaFisica.Enabled = _edit;
            }


            if (isEditTabInfo == 5)
            {
                if (_edit)
                {
                    if (!Participante.__Model_ConferirTipoPessoa(121))
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Este participante não é do tipo Vendedor");
                        __screen_Edit_Cancel(false);
                        return;
                    }
                }
                cmdLocalizarPessoaJuridicaVendedor.Enabled = _edit;
                cmdLocalizarVendedorParticipanteContador.Enabled = _edit;
                chk_vendedor_status.Enabled = _edit;
            }


            if (isEditTabInfo == 6)
            {
                if (_edit)
                {
                    if (!Participante.__Model_ConferirTipoPessoa(101))
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Este participante não é funcionário");
                        __screen_Edit_Cancel(false);
                        return;
                    }
                }
                cmbrh_setor_operacional_descricao.Enabled = _edit;
                cmbrh_tipo_contrato_descricao.Enabled = _edit;

                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 99915101))
                {
                    chk_funcionario_status.Enabled = _edit;
                    txt_rh_vl_contrato_bruto.Enabled = _edit;
                    //txt_rh_vl_folha_brt.Enabled = _edit;
                    txt_rh_vl_contrato_liq.Enabled = _edit;
                    txt_rh_vl_salario_liq.Enabled = _edit;
                    txt_rh_vl_pj.Enabled = _edit;
                    txt_rh_vl_outros.Enabled = _edit;
                }
            }

            if (!isEdit)
                isEditTabInfo = -1;
        }


        private void tabinfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (isEdit)
            {
                if (isEditTabInfo == 0)
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Edição dos dados básicos cancelada");
            
            }
            __screen_Edit_Cancel(false);

        }

        private void cmdCancela_Alteracao_Click(object sender, EventArgs e)
        {
            __screen_Edit_Cancel(false);
        }

        private void cmdLocalizarPessoaJuridicaVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                using (frm_Pessoa_List frm = new frm_Pessoa_List(MyConnect, enumParticipanteTipoCd.todos))
                {
                    var result = frm.ShowDialog(); 
                    if (result == DialogResult.OK)
                    {
                        txt_vendedor_cdparticipante_pj.Text = frm.ParticipateSelecionado.cdparticipante.ToString();
                        lbl_vendedor_cdparticipante_pj.Text = frm.ParticipateSelecionado.nome_razao.ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdLocalizarVendedorParticipanteContador_Click(object sender, EventArgs e)
        {
            try
            {
                using (frm_Pessoa_List frm = new frm_Pessoa_List(MyConnect, enumParticipanteTipoCd.adm_contador))
                {
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        txt_vendedor_cdparticipante_contador.Text = frm.ParticipateSelecionado.cdparticipante.ToString();
                        lbl_vendedor_cdparticipante_contador.Text = frm.ParticipateSelecionado.nome_razao.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmbrh_tipo_contrato_descricao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Pag_Net.Bll.F0141_Rh.TbRh_Tipo_Contrato TipoContratoSelecionado = ((Pag_Net.Bll.F0141_Rh.TbRh_Tipo_Contrato)cmbrh_tipo_contrato_descricao.SelectedItem);
                Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario MyParticipanteFuncionario = ((Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario)dtgFuncionarioList.Rows[dtgFuncionarioList.SelectedRows[0].Index].DataBoundItem);
                MyParticipanteFuncionario.TipoContrato = TipoContratoSelecionado;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        private void cmbrh_setor_operacional_descricao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional SetorOperacionalSelecionado = ((Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional)cmbrh_setor_operacional_descricao.SelectedItem);
                Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario MyParticipanteFuncionario = ((Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario)dtgFuncionarioList.Rows[dtgFuncionarioList.SelectedRows[0].Index].DataBoundItem);
                MyParticipanteFuncionario.SetorOperacional = SetorOperacionalSelecionado;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        private void chk_funcionario_status_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario MyParticipanteFuncionario = ((Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario)dtgFuncionarioList.Rows[dtgFuncionarioList.SelectedRows[0].Index].DataBoundItem);
                MyParticipanteFuncionario.rh_status = chk_funcionario_status.Checked ? 1 : 0; 
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }            
        }

        private void cmdParticipante_Funcionario_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (Participante.cdparticipante == 0)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Participante NÃO selecionado!");
                    return; 

                }

                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma Inclusão de Um registro de Funcionário PAG?"))
                {
                    Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario NovoFuncionario = new TbParticipanteFuncionario();
                    NovoFuncionario.New(MyConnect, Participante.cdparticipante);
                    Participante.__Model_Consultar_Funcionario(MyConnect);
                    this.Participante_Funcionario_Binding();
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


    }
}
