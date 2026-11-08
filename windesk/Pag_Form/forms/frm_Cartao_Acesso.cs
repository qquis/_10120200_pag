using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_Cartao_Acesso : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0137_CartaoAcesso.Wk WK;
        public frm_Cartao_Acesso(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = _MyConnect;
                WK = new Pag_Net.Bll.F0137_CartaoAcesso.Wk(MyConnect);
                _Screen_load(true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void _Screen_load(bool OpenForm)
        {
            try
            {
                if (OpenForm)
                {
                    UserTools._Screen_Form_Open(this);
                    UserTools._Screen_ButtonImage(cmdNovo, UserTools.PagButtonsIcons.Novo);
                    UserTools._Screen_ButtonImage(cmdConsultar_Cartao, UserTools.PagButtonsIcons.SetaDupla_Baixo);
                    UserTools._Screen_ButtonImage(cmdDetalhe, UserTools.PagButtonsIcons.Detalhe);
                    UserTools._Screen_ButtonImage(cmdCartaoAcessoRegistroListlog, UserTools.PagButtonsIcons.SetaSimples_Baixo);
                    UserTools._Screen_ButtonImage(cmdCartaoAcessoLiberar, UserTools.PagButtonsIcons.CancelUndo);

                    cmbcartao_acesso_tipo.ValueMember = "cartao_acesso_tipo_cd";
                    cmbcartao_acesso_tipo.DisplayMember = "cartao_acesso_tipo_descricao";
                    cmbcartao_acesso_tipo.DataSource = WK.CartaoAcessoTipoList;

                    foreach (object i in this.Controls) { if (i.GetType().Name == "TextBox") if (((TextBox)i).Tag != null ) if (((TextBox)i).Tag.ToString() != "") ((TextBox)i).LostFocus += new EventHandler(_Screen_lostFocus); }
                    foreach (object i in this.Controls) { if (i.GetType().Name == "Button") ((Button)i).Click += new EventHandler(_Screen_Click); }
                    cmbcartao_acesso_tipo.LostFocus += new EventHandler(_Screen_lostFocus);
                    dtpfilter_cartao_acesso_validade_ini.DataBindings.Add("Enabled", chkfilter_data_validade, "Checked");
                    dtpfilter_cartao_acesso_validade_fim.DataBindings.Add("Enabled", chkfilter_data_validade, "Checked");
                    chkfilter_data_validade.Checked = false;
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


                    }
                }
                if (sender.GetType().Name == "TextBox")
                {

                    switch (((TextBox)sender).Name)
                    {

                        case "txtcpf_cnpj_Fornecedor":
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
                if (((Button)sender).Name == "cmdConsultar_Cartao") { _ConsultarCartaoList(); }
                if (((Button)sender).Name == "cmdNovo") { _NovoCartao(); }
                if (((Button)sender).Name == "cmdDetalhe") { _ConsultaCadastro(); }
                if (((Button)sender).Name == "cmdCartaoAcessoRegistroListlog") { _ConsultarCartaoLog(); }
                if (((Button)sender).Name == "cmdCartaoAcessoLiberar") { _CartaoAcessoLiberar(); }
                
            }
        }


        private void _ConsultarCartaoList()
        {
            try
            {
                WK.FilterCartaoList_Clear();
                dtgcartao_acesso_registro.DataSource = null;
                dtgCartao_Acesso.DataSource = null;

                if (txtfilter_cartao_acesso_seq.Text != "")
                    WK.FilterCartaoList.cartao_acesso_seq = Convert.ToInt32(txtfilter_cartao_acesso_seq.Text);

                if (txtfilter_cartao_acesso_numero.Text != "")
                    WK.FilterCartaoList.cartao_acesso_numero = Convert.ToInt32(txtfilter_cartao_acesso_numero.Text);

                if (txtfilter_cartao_acesso_cdbr.Text != "")
                    WK.FilterCartaoList.cartao_acesso_cdbr = txtfilter_cartao_acesso_cdbr.Text;

                WK.FilterCartaoList.cartao_acesso_tipo_cd = ((Pag_Net.Bll.F0137_CartaoAcesso.TbCartaoAcessoTipo)cmbcartao_acesso_tipo.SelectedItem).cartao_acesso_tipo_cd;

                WK.FilterCartaoList.data_validade = 0;
                if (chkfilter_data_validade.Checked)
                    WK.FilterCartaoList.data_validade = 1;

                WK.FilterCartaoList.cartao_acesso_validade_ini = dtpfilter_cartao_acesso_validade_ini.Value;
                WK.FilterCartaoList.cartao_acesso_validade_fim = dtpfilter_cartao_acesso_validade_fim.Value;

                WK.FilterCartaoList.cartao_acesso_status = 0;
                if (chkfilter_cartao_acesso_status.Checked)
                    WK.FilterCartaoList.cartao_acesso_status = 1;

                WK.FilterCartaoList.cartao_acesso_reg_status = 0;
                if (chkfilter_cartao_acesso_reg_status.Checked)
                {
                    WK.FilterCartaoList.cartao_acesso_reg_status_filter = true;
                    WK.FilterCartaoList.cartao_acesso_reg_status = 1;
                }
                else
                {
                    WK.FilterCartaoList.cartao_acesso_reg_status_filter = false;
                    WK.FilterCartaoList.cartao_acesso_reg_status = 0;
                }

                UserTools._Screen_Wait(this, true);
                dtgCartao_Acesso.DataSource = WK.CartaoAcessoList_Get();
                UserTools._Screen_DataBinding_Set_FromDataGrid(this, dtgCartao_Acesso);
                UserTools._Screen_Wait(this, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this,  ex);
            }
        }
        private void _ConsultarCartaoLog()
        {
            try
            {
                if (lbl_cartao_acesso_seq.Text != "")
                {
                    WK.FilterCartaoAcessoRegistroList_Clear();
                    WK.FilterCartaoAcessoRegistroList.cartao_acesso_seq = Convert.ToInt32(lbl_cartao_acesso_seq.Text);
                    dtgcartao_acesso_registro.DataSource =  WK.CartaoAcessoRegistroList_Get();

                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _NovoCartao()
        {
            try
            {
                frm_Cartao_Acesso_Cadastro frmCartaoAcessoCadastro = new frm_Cartao_Acesso_Cadastro(MyConnect,0);
                frmCartaoAcessoCadastro.ShowDialog();
                _ConsultarCartaoList();
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
            

        }
        private void _ConsultaCadastro()
        {
            try
            {
                
                if (lbl_cartao_acesso_seq.Text != "")
                {
                    UserTools._Screen_Wait(this);
                    frm_Cartao_Acesso_Cadastro frmCartaoAcessoCadastro = new frm_Cartao_Acesso_Cadastro(MyConnect, Convert.ToInt32(lbl_cartao_acesso_seq.Text));
                    UserTools._Screen_Wait(this);
                    frmCartaoAcessoCadastro.ShowDialog();
                }
                else
                {
                    UserTools._Screen_Wait(this);
                    UserTools._Screen_MessageBox(this, "Selecione um CARTÃO");
                }
            }

            catch ( Exception )
            {
                UserTools._Screen_Wait(this);
                UserTools._Screen_MessageBox(this, "Selecione um CARTÃO");
            }
        }
        private void _CartaoAcessoLiberar()
        {
 
        }
    }
}
