using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Distribuicao.Forca_Venda_Meta
{
    public partial class frm_fv_meta_cadastrar : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.f0005_forca_venda_meta.model.model_forca_venda_meta modelForcaVendaMeta;
        Pag_Net.src.f0005_forca_venda_meta.wk wk;
        public frm_fv_meta_cadastrar(Pag_Net.Models.modelSistemaUsuario __MyConnect, Pag_Net.src.f0005_forca_venda_meta.model.model_forca_venda_meta __modelForcaVendaMeta)
        {
            InitializeComponent();
            MyConnect = __MyConnect;
            modelForcaVendaMeta = __modelForcaVendaMeta;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdEfetivarMetaVendedor, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                wk = new Pag_Net.src.f0005_forca_venda_meta.wk(MyConnect);
                
                cmbforca_venda_meta_tipo.DataSource = wk.ComboBoxForcaVendaTipo;
                cmbforca_venda_meta_tipo.DisplayMember = "fv_meta_tipo_descricao";
                cmbforca_venda_meta_tipo.ValueMember = "fv_meta_tipo_cd";
                
                if (modelForcaVendaMeta.fv_meta_cd != 0) {
                    cmbforca_venda_meta_tipo.Enabled = false;
                    UserTools._Screen_ComboBox_Select_Item(cmbforca_venda_meta_tipo, modelForcaVendaMeta.META_TIPO.fv_meta_tipo_descricao);
                    _DataShow();
                }



                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _DataShow()
        {
            try
            {
                txt_fv_meta_descricao.Text = modelForcaVendaMeta.fv_meta_descricao.ToString();
                txt_fv_meta_bonus_percentual.Text = modelForcaVendaMeta.fv_meta_bonus_percentual.ToString("0.00");
                txt_fv_meta_bonus_percentual_proporcional.Text = modelForcaVendaMeta.fv_meta_bonus_percentual_proporcional.ToString("0.00");
                txt_fv_meta_bonus_valor.Text = modelForcaVendaMeta.fv_meta_bonus_valor.ToString("0.00");
                dtpfv_meta_data_ini.Value = modelForcaVendaMeta.fv_meta_data_ini;
                dtpfv_meta_data_fim.Value = modelForcaVendaMeta.fv_meta_data_fim;
                cmbCompetenciaCd.Text = modelForcaVendaMeta.competencia_cd.ToString();
                lbl_fv_meta_cd.Text = modelForcaVendaMeta.fv_meta_cd.ToString();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdEfetivarMetaVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_fv_meta_descricao.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Descrição Inválida");
                    return;
                }

                if (txt_fv_meta_bonus_percentual.Text == "")
                    txt_fv_meta_bonus_percentual.Text = "0";
                if (txt_fv_meta_bonus_percentual_proporcional.Text == "")
                    txt_fv_meta_bonus_percentual_proporcional.Text = "0";
                if (txt_fv_meta_bonus_valor.Text == "")
                    txt_fv_meta_bonus_valor.Text = "0";

                modelForcaVendaMeta.fv_meta_descricao = txt_fv_meta_descricao.Text.ToString();
                modelForcaVendaMeta.fv_meta_bonus_percentual = Convert.ToDouble(txt_fv_meta_bonus_percentual.Text);
                modelForcaVendaMeta.fv_meta_bonus_valor = Convert.ToDouble(txt_fv_meta_bonus_valor.Text);
                modelForcaVendaMeta.fv_meta_bonus_percentual_proporcional = Convert.ToDouble(txt_fv_meta_bonus_percentual_proporcional.Text);

                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma atualização dos valores da Meta?"))
                {
                    modelForcaVendaMeta.__Atualizar(MyConnect);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Registro Alterado com sucesso");
                }
                else
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Registro NÃO Alterado");
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

    }
}
