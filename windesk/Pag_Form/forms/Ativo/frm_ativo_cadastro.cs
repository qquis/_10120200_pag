using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Ativo
{
    public partial class frm_ativo_cadastro : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0035_Ativo.WkAtivo WK;

        bool isNew = false;
        bool isEdit = false;
        int isEditTabInfo = -1;

        public frm_ativo_cadastro(Pag_Net.Models.modelSistemaUsuario _MyConnect, Pag_Net.Bll.F0035_Ativo.Models.Model_TbAtivo Model_TbAtivo)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new Pag_Net.Bll.F0035_Ativo.WkAtivo(MyConnect);
            WK.Model_TbAtivo_Selecionado = Model_TbAtivo;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_Form_Open(this);
                
                UserTools._Screen_ButtonImage(cmdconsultar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_ButtonImage(cmdEfetivar_dados, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdCancela_Alteracao, UserTools.PagButtonsIcons.CancelUndo);
                UserTools._Screen_ButtonImage(cmdEditar, UserTools.PagButtonsIcons.Editar);
                UserTools._Screen_ButtonImage(cmdIncluir, UserTools.PagButtonsIcons.Novo);

                cmbat_tipo_descricao.DisplayMember = "at_tipo_descricao";
                cmbat_tipo_descricao.ValueMember = "at_tipo_cd";
                cmbat_tipo_descricao.DataSource = WK.tipoAtivos_Obter();

                __BindingWK(null, null);
                __screen_Edit_Cancel(false);
                if (WK.Model_TbAtivo_Selecionado.at_seq == 0)
                {
                    isNew = true;
                    __screen_Edit_Cancel(true);
                }
                
                /*Class Work*/

                

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void __BindingWK(object sender, EventArgs e)
        {
            try
            {
                __screen_clear();
                WK.Model_TbAtivo_Selecionado.__ModelConsultar(MyConnect);
                txtat_seq.Text = WK.Model_TbAtivo_Selecionado.at_seq.ToString();
                txtat_descricao.Text = WK.Model_TbAtivo_Selecionado.at_descricao.ToString();
                cmbat_tipo_descricao.Text = WK.Model_TbAtivo_Selecionado.AtivoTipo.at_tipo_descricao.ToString();
                chkat_status.Checked = WK.Model_TbAtivo_Selecionado.m_bool_at_status;

                __BindingWK_Veiculo(null, null);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        private void __BindingWK_Veiculo(object sender, EventArgs e)
        {
            try
            {
                txtat_veiculo_placa.Text = WK.Model_TbAtivo_Selecionado.Veiculo.at_veiculo_placa.ToString();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        public void __screen_Edit_Cancel(bool _edit)
        {
            try
            {
                isEdit = _edit;
                isEditTabInfo = tabinfo.SelectedIndex;

                txtat_veiculo_placa.Enabled = false;

                if (isEdit)
                {
                    cmdEfetivar_dados.Enabled = true;
                    cmdCancela_Alteracao.Enabled = true;
                    cmdEditar.Enabled = false;
                    cmdIncluir.Enabled = false;

                }
                else
                {
                    cmdEfetivar_dados.Enabled = false;
                    cmdCancela_Alteracao.Enabled = false;
                    cmdEditar.Enabled = true;
                    cmdIncluir.Enabled = true;
                }

                txtat_seq.Enabled = !_edit;
                txtat_descricao.Enabled = _edit;
                cmbat_tipo_descricao.Enabled = _edit;
                chkat_status.Enabled = _edit;

                if (__TipoAtivoSelecionado() == 200)
                {
                    txtat_veiculo_placa.Enabled = _edit;
                }

                if (!isEdit)
                    isEditTabInfo = -1;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, ex);
            }
        }

        public void __screen_clear()
        {
            try
            {
                txtat_seq.Text = "0";
                txtat_descricao.Text = "";
                cmbat_tipo_descricao.SelectedIndex = -1;
                cmbat_tipo_descricao.Text = "";
                chkat_status.Checked = false;
                txtat_veiculo_placa.Text = "";
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, ex);
            }
        }

        public int __TipoAtivoSelecionado()
        {
            try
            {
                return ((Pag_Net.Bll.F0035_Ativo.TbAtivoTipo)cmbat_tipo_descricao.SelectedItem).at_tipo_cd;
            }
            catch ( Exception ex )
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, ex);
                return 0;
            }
        }

        public void __consultar()
        {
            try
            {
                if (txtat_seq.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Indique um Sequencial");
                    return;
                }
                UserTools._Screen_Wait(this);
                WK.ativoList_Selecionar(txtat_seq.Text);
                __BindingWK(null, null);
                UserTools._Screen_Wait(this);
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmbat_tipo_descricao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            __screen_Edit_Cancel(isEdit);
        }

        private void cmdCancela_Alteracao_Click(object sender, EventArgs e)
        {
            isNew = false;
            __screen_Edit_Cancel(false);
        }
        private void cmdEfetivar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                if (isNew)
                    WK.Model_TbAtivo_Selecionado.at_seq = 0;

                WK.Model_TbAtivo_Selecionado.at_status = chkat_status.Checked ? 1 : 0;
                WK.Model_TbAtivo_Selecionado.at_descricao = txtat_descricao.Text.Replace("'", "").ToUpper();
                WK.Model_TbAtivo_Selecionado.at_tipo_cd = __TipoAtivoSelecionado();

                WK.Model_TbAtivo_Selecionado.Veiculo.at_veiculo_placa = txtat_veiculo_placa.Text.Trim().Replace("'", "").ToUpper();
                WK.Model_TbAtivo_Selecionado.__ModelSalvar(MyConnect);

                if (isNew)
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Inclusao);
                else
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atualizacao);
                isNew = false;
                __screen_Edit_Cancel(false);
                __consultar();
            }
            catch ( Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, ex);
            }
        }
        private void cmdIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                WK.ativoNew();
                __BindingWK(null, null);
                //__BindingWK_Veiculo(null, null);
                isNew = true;
                __screen_Edit_Cancel(true);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, ex);
            }
        }
        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdEditar_Click(object sender, EventArgs e)
        {
            isNew = false;
            __screen_Edit_Cancel(true);
        }

        private void cmdconsultar_Click(object sender, EventArgs e)
        {
            __consultar();
        }

    }
}
