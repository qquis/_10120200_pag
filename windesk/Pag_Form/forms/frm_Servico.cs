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
    public partial class frm_Servico : Form
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico WK;
        public frm_Servico(Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            InitializeComponent();
            MyConnect = myConnect;
            WK = new Pag_Net.Bll.F0136_Contrato_Servico.WKContrato_Servico(myConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdConsultar_Servico, UserTools.PagButtonsIcons.SetaSimples_Baixo);
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons.SetaSimples_Baixo);
                UserTools._Screen_ButtonImage(cmdEfetivar, UserTools.PagButtonsIcons.Efetiva_Seleciona);

                cmdConsultar_Servico.Click += new EventHandler(_Screen_Click);
                cmdEfetivar.Click += new EventHandler(_Screen_Click);
                cmdsair.Click += new EventHandler(_Screen_Click);

                dtgCONTRATO_SERVICO.AutoGenerateColumns = false;
                
                
                txtfilter_contrato_servico_seq.TextChanged += new EventHandler(_Screen_changed);
                txtfilter_contrato_bluesoft_descritivo.TextChanged += new EventHandler(_Screen_changed);
                txtfilter_cpf_cnpj.TextChanged += new EventHandler(_Screen_changed);

                chk_contrato_servico_permite_execucao.CheckedChanged += new EventHandler(_Screen_changed);
                txt_contrato_servico_descritivo.Enabled = false;
                txt_contrato_servico_observacao.Enabled = false;

                
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void _Screen_lostFocus(object sender, EventArgs e) { }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label"){ }
                if (sender.GetType().Name == "TextBox") { }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") 
                { 
                    if(((CheckBox)sender).Name == "chk_contrato_servico_permite_execucao")
                    {
                        if (!chk_contrato_servico_permite_execucao.Checked)
                        {
                            txt_contrato_servico_descritivo.Enabled = false;
                            txt_contrato_servico_observacao.Enabled = false;
                        }
                        else
                        {
                            txt_contrato_servico_descritivo.Enabled = true;
                            txt_contrato_servico_observacao.Enabled = true;
                        }
                    }
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
            }
        }
        private void _Consultar_Servico()
        {
            try
            {
                int filter_contrato_servico_seq = 0;
                if (txtfilter_contrato_servico_seq.Text != "")
                    filter_contrato_servico_seq = Convert.ToInt32(txtfilter_contrato_servico_seq.Text);
                chk_contrato_servico_permite_execucao.Checked = false;
                UserTools._Screen_Wait(this, true);


                WK.Contrato_Servico_List_Filter.contrato_bluesoft_descritivo = txtfilter_contrato_bluesoft_descritivo.Text;
                WK.Contrato_Servico_List_Filter.cpf_cnpj = txtfilter_cpf_cnpj.Text;
                WK.Contrato_Servico_List_Filter.nome_razao = txtfilter_razao_social.Text;
                WK.Contrato_Servico_List_Filter.contrato_servico_seq = filter_contrato_servico_seq;
                WK.Contrato_Servico_List_Filter.contrato_servico_permite_execucao = chkfilter_contrato_servico_permite_execucao.Checked ? 1 : 0;

                dtgCONTRATO_SERVICO.DataSource = WK.Contrato_Servico_List_Get();
                foreach (object i in this.Controls)
                {
                    UserTools._Screen_DataBinding_Set(i, dtgCONTRATO_SERVICO.DataSource, "");
                }
                chk_contrato_servico_permite_execucao.DataBindings.Clear();
                chk_contrato_servico_permite_execucao.DataBindings.Add("Checked", dtgCONTRATO_SERVICO.DataSource, chk_contrato_servico_permite_execucao.Tag.ToString());
                UserTools._Screen_Wait(this, false);
            }
            catch(Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }
        private void _Efetivar()
        {
            try
            {
                if (chk_contrato_servico_permite_execucao.Checked)
                {
                    ((model_Contrato_Servico)(dtgCONTRATO_SERVICO.CurrentRow.DataBoundItem)).contrato_servico_permite_execucao = 1;
                    ((model_Contrato_Servico)(dtgCONTRATO_SERVICO.CurrentRow.DataBoundItem)).contrato_servico_descritivo = txt_contrato_servico_descritivo.Text;
                    ((model_Contrato_Servico)(dtgCONTRATO_SERVICO.CurrentRow.DataBoundItem)).contrato_servico_observacao = txt_contrato_servico_observacao.Text;
                }
                else
                {
                    ((model_Contrato_Servico)(dtgCONTRATO_SERVICO.CurrentRow.DataBoundItem)).contrato_servico_permite_execucao = 0;
                    ((model_Contrato_Servico)(dtgCONTRATO_SERVICO.CurrentRow.DataBoundItem)).contrato_servico_descritivo = "";
                    ((model_Contrato_Servico)(dtgCONTRATO_SERVICO.CurrentRow.DataBoundItem)).contrato_servico_observacao = "";
                    
                }
                ((model_Contrato_Servico)(dtgCONTRATO_SERVICO.CurrentRow.DataBoundItem))._BDUPDATE(MyConnect);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Alteração Efetuada com sucesso");

            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
