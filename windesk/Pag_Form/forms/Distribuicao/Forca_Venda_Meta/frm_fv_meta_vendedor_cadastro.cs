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
    public partial class frm_fv_meta_vendedor_cadastro : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.f0005_forca_venda_meta.model.model_forca_venda_meta modelForcaVendaMeta;
        Pag_Net.src.f0005_forca_venda_meta.wk wk; 


        public frm_fv_meta_vendedor_cadastro(Pag_Net.Models.modelSistemaUsuario _MyConnect, int __fv_meta_cd, int __fv_meta_cdparticipantevendedor)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            modelForcaVendaMeta = new Pag_Net.src.f0005_forca_venda_meta.model.model_forca_venda_meta(MyConnect, __fv_meta_cd, __fv_meta_cdparticipantevendedor);
            _Screen_load();
            
        }

        private void _Screen_load()
        {
            try
            {
                
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_Form_Format_DataGridView(dtgR);
                cmbforca_venda_meta_composicao_tipo.DisplayMember = "fv_meta_tipo_descricao";
                cmbforca_venda_meta_composicao_tipo.ValueMember = "fv_meta_tipo_cd";
                cmbforca_venda_meta_composicao_tipo.DataSource = Pag_Net.src.f0005_forca_venda_meta.dataStore.ArrayTabs.ForcaVendaMetaTipoList_Get(MyConnect, true);
                wk = new Pag_Net.src.f0005_forca_venda_meta.wk(MyConnect);
                wk.PropertyChanged += _BindingComposicao;
                _Binding();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        private void _Binding()
        {
            try
            {
                lbl_fv_meta_descricao.Text = modelForcaVendaMeta.fv_meta_descricao.ToString();
                lbl_fv_meta_cd.Text = modelForcaVendaMeta.fv_meta_cd.ToString(); 
                lbl_competencia_cd.Text = modelForcaVendaMeta.competencia_cd.ToString();
                lbl_fv_meta_cdparticipantevendedor.Text = modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_cdparticipantevendedor.ToString();
                lbl_fv_meta_participantevendedor_nome_razao.Text = modelForcaVendaMeta.Label_NomeVendedor.ToString();
                txt_fv_meta_rq_pos_minimo.Text = modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_pos_minimo.ToString();
                txt_fv_meta_rq_pos_maximo.Text = modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_pos_maximo.ToString();
                txt_fv_meta_rq_pos.Text = modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_pos.ToString();
                txt_fv_meta_rq_qtde.Text = modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_qtde.ToString();
                txt_fv_meta_rq_valor.Text = modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_valor.ToString();
                _ConsultarComposicao();

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex); 
            }
        }

        private void _ConsultarComposicao()
        {
            try
            {
                wk.ConsultarComposicoes(Convert.ToInt32(lbl_fv_meta_cd.Text), Convert.ToInt32(cmbforca_venda_meta_composicao_tipo.SelectedValue), Convert.ToInt32(lbl_competencia_cd.Text), Convert.ToInt32(lbl_fv_meta_cdparticipantevendedor.Text));
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }


        private void _BindingComposicao(object sender, PropertyChangedEventArgs e)
        {
            try
            {
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

        private void cmdEfetivarMetaVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_pos_maximo = Convert.ToInt32(txt_fv_meta_rq_pos_maximo.Text);
                modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_pos_minimo = Convert.ToInt32(txt_fv_meta_rq_pos_minimo.Text);
                modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_pos = Convert.ToInt32(txt_fv_meta_rq_pos.Text);
                modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_pos = Convert.ToInt32(txt_fv_meta_rq_pos.Text);
                modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_qtde = Convert.ToInt32(txt_fv_meta_rq_qtde.Text);
                modelForcaVendaMeta.RegistroMetaVendedor.fv_meta_rq_valor = Convert.ToInt32(txt_fv_meta_rq_valor.Text);
                modelForcaVendaMeta.RegistroMetaVendedor_Atualizar(MyConnect);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Atualização da Meta realizada com Sucesso!");
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

    }
}
