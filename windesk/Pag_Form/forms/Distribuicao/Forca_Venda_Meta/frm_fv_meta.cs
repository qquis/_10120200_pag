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
    public partial class frm_fv_meta : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.f0005_forca_venda_meta.wk wk; 
        public frm_fv_meta(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect; 
            _Screen_load(); 
        }

        private void _Screen_load()
        {
            try
            {
                wk = new Pag_Net.src.f0005_forca_venda_meta.wk(MyConnect);
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar_Detalhe_Meta, UserTools.PagButtonsIcons.SetaDupla_Baixo);
                UserTools._Screen_ButtonImage(cmdmeta_consultar, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdmeta_incluir, UserTools.PagButtonsIcons.Novo);
                UserTools._Screen_ButtonImage(cmdeditar_meta_vendedor, UserTools.PagButtonsIcons.Editar);
                UserTools._Screen_ButtonImage(cmdMetaClonar, UserTools.PagButtonsIcons.SetaDupla_Direita);
                UserTools._Screen_Form_Format_DataGridView(dtgC);
                UserTools._Screen_Form_Format_DataGridView(dtgV);
                UserTools._Screen_Form_Format_DataGridView(dtgR);
                
                
                cmbforca_venda_meta_tipo.DisplayMember = "fv_meta_tipo_descricao";
                cmbforca_venda_meta_tipo.ValueMember = "fv_meta_tipo_cd"; 
                cmbforca_venda_meta_tipo.DataSource = Pag_Net.src.f0005_forca_venda_meta.dataStore.ArrayTabs.ForcaVendaMetaTipoList_Get(MyConnect, true);

                cmbforca_venda_meta_composicao_tipo.DisplayMember = "fv_meta_composicao_tipo_descricao";
                cmbforca_venda_meta_composicao_tipo.ValueMember = "fv_meta_composicao_tipo_cd";
                cmbforca_venda_meta_composicao_tipo.DataSource = Pag_Net.src.f0005_forca_venda_meta.dataStore.ArrayTabs.ForcaVendaMetaComposicaoTipo(MyConnect, true); 
                
                wk.PropertyChanged += DtGridMetaBinding; 

            }
            catch (Exception ex)
            {
                MessageBox.Show("FrmForcaVendaMeta | Load \n " + ex.Message);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public void DtGridMetaBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                if (e.PropertyName == "dbList_Metas")
                {
                    dtgC.DataSource = wk.dbList_Metas.List;
                    UserTools._Screen_DataBinding_Set(lbl_fv_meta_cd, wk.dbList_Metas.List, "fv_meta_cd");
                    UserTools._Screen_DataBinding_Set(lbl_fv_meta_descricao, wk.dbList_Metas.List, "fv_meta_descricao"); 
                }

                if (e.PropertyName == "dbList_Meta_Vendedor") {
                    dtgV.DataSource = wk.dbList_Metas_Vendedor.List;
                    UserTools._Screen_DataBinding_Set(lbl_fv_meta_cdparticipantevendedor, wk.dbList_Metas_Vendedor.List, "fv_meta_cdparticipantevendedor");
                    UserTools._Screen_DataBinding_Set(lbl_fv_meta_nome_razao_vendedor, wk.dbList_Metas_Vendedor.List, "nome_razao");
                }

                if (e.PropertyName == "dbList_Meta_Composicao")
                {
                    dtgR.DataSource = wk.dbList_Metas_Composicao.List; 
                }

                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex); 
            }

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCompetenciaCd.Text == "")
                    cmbCompetenciaCd.Text = "0";
                UserTools._Screen_Wait(this); 
                wk.ConsultarMetas(Convert.ToInt32(cmbforca_venda_meta_tipo.SelectedValue), Convert.ToInt32(cmbCompetenciaCd.Text));
                UserTools._Screen_Wait(this); 
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex); 
            }
        }

        private void cmdConsultar_Detalhe_Meta_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_fv_meta_cd.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor indicar a Meta a ser consultada!");
                    return; 
                }
                UserTools._Screen_Wait(this);
                wk.ConsultarMetasDetalhe(Convert.ToInt32(lbl_fv_meta_cd.Text), Convert.ToInt32(cmbforca_venda_meta_composicao_tipo.SelectedValue),  Convert.ToInt32(cmbCompetenciaCd.Text), 0);
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void dtgC_SelectionChanged(object sender, EventArgs e)
        {

                dtgV.DataSource = null;
                dtgR.DataSource = null;
                lbl_fv_meta_cdparticipantevendedor.Text = "";
                lbl_fv_meta_nome_razao_vendedor.Text = "";
        }

        private void cmdeditar_meta_vendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_fv_meta_cd.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Nenhuma Meta Selecionada!");
                    return; 
                }

                if (lbl_fv_meta_cdparticipantevendedor.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Vendedor/Meta Não selecionado");
                    return; 
                }

                int fv_meta_cd = Convert.ToInt32(lbl_fv_meta_cd.Text);
                int fv_meta_cdparticipantevendedor = Convert.ToInt32(lbl_fv_meta_cdparticipantevendedor.Text);
                frm_fv_meta_vendedor_cadastro frm = new frm_fv_meta_vendedor_cadastro(MyConnect, fv_meta_cd, fv_meta_cdparticipantevendedor);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdmeta_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_fv_meta_cd.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Selecione uma Meta para a Consulta"); 
                }

                UserTools._Screen_Wait(this);
                Distribuicao.Forca_Venda_Meta.frm_fv_meta_cadastrar frmMetaCadastrar = new frm_fv_meta_cadastrar(MyConnect, new Pag_Net.src.f0005_forca_venda_meta.model.model_forca_venda_meta(MyConnect, Convert.ToInt32(lbl_fv_meta_cd.Text), 0));
                UserTools._Screen_Wait(this);
                frmMetaCadastrar.ShowDialog(); 
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmbforca_venda_meta_composicao_tipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                wk.ConsultarComposicoes(Convert.ToInt32(lbl_fv_meta_cd.Text), Convert.ToInt32(cmbforca_venda_meta_composicao_tipo.SelectedValue), Convert.ToInt32(cmbCompetenciaCd.Text), 0);
                UserTools._Screen_Wait(this); 
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdMetaClonar_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, string.Format("Confirma a realização de Cópia para a competência {0} ?",cmbCompetenciaCd_Clonagem.Text)))
                {

                    UserTools._Screen_Wait(this);
                    Pag_Net.src.f0005_forca_venda_meta.model.model_forca_venda_meta MODEL = new Pag_Net.src.f0005_forca_venda_meta.model.model_forca_venda_meta
                        (MyConnect, Convert.ToInt32(lbl_fv_meta_cd.Text), 0);


                    if (MODEL.fv_meta_descricao != "")
                    {
                        MODEL.Clonar(MyConnect, Convert.ToInt32(cmbCompetenciaCd_Clonagem.Text));
                        UserTools._Screen_Wait(this);

                        if (!UserTools._Screen_MessageBox_OkCancel(this, "Deseja cadastrar outra meta?"))
                        {
                            cmbCompetenciaCd.Text = cmbCompetenciaCd_Clonagem.Text;
                            cmbCompetenciaCd_Clonagem.Text = "";
                            cmdConsultar_Click(null, null);
                        }
                    }

                }

            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

      

    }


}
