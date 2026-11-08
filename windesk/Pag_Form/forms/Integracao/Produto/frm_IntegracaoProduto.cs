using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Integracao.Produto
{
    public partial class frm_IntegracaoProduto : Form
    {



        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F0095_Integracao._index F0095;


        public frm_IntegracaoProduto(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            _Screen_load();
        }


        public frm_IntegracaoProduto(Pag_Net.Models.modelSistemaUsuario _Myconnect, int pr_cdproduto)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            txtpr_cdproduto.Text = pr_cdproduto.ToString();
            _Screen_load();
        }


        private void _Screen_load()
        {
            F0095 = new Pag_Net.src.F0095_Integracao._index(MyConnect, 2000);
            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
            UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
            UserTools._Screen_ButtonImage(cmdAtualizaStatusParaPendente, UserTools.PagButtonsIcons.Efetiva_Seleciona);
            UserTools._Screen_ButtonImage(cmdGerarPendenciasPrecosD1, UserTools.PagButtonsIcons.SetaSimples_Baixo);
            UserTools._Screen_ButtonImage(cmdConsultarIntegracaoTipoInfo, UserTools.PagButtonsIcons.Detalhe);
            UserTools._Screen_ButtonImage(cmdConsultarProduto, UserTools.PagButtonsIcons.Detalhe);
            UserTools._Screen_ButtonImage(cmdConsultaLancamentoDaIntegracao, UserTools.PagButtonsIcons.Detalhe);
            UserTools._Screen_Form_Format_DataGridView(dtgPI);

            dtpatualizacao_ini.Value = DateTime.Now;
            dtpatualizacao_fim.Value = DateTime.Now;
            dtplancamento_ini.Value = DateTime.Now;
            dtplancamento_fim.Value = DateTime.Now;

            dtplancamento_ini.DataBindings.Add("enabled", chkfilter_dtlancamento, "checked");
            dtplancamento_fim.DataBindings.Add("enabled", chkfilter_dtlancamento, "checked");

            dtpatualizacao_ini.DataBindings.Add("enabled", chkfilter_dtatualizacao, "checked");
            dtpatualizacao_fim.DataBindings.Add("enabled", chkfilter_dtatualizacao, "checked");

            F0095.reports.PropertyChanged += _databinding;

            cmbIntegracaoTipoDescricao.ValueMember = "integracao_tipo_cd";
            cmbIntegracaoTipoDescricao.DisplayMember = "integracao_tipo_descricao";
            cmbIntegracaoTipoDescricao.DataSource = F0095.reports.IntegracoesTipo;

            cmbIntegracaoStatus.ValueMember = "integracao_status_cd";
            cmbIntegracaoStatus.DisplayMember = "integracao_status_descricao";
            cmbIntegracaoStatus.DataSource = F0095.reports.IntegracoesStatus;

            if (txtpr_cdproduto.Text != "")
                cmdConsultar_Click(null, null);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                F0095.reports.filtroIntegracaoProdutoClear();
                F0095.reports.filtroIntegracaoProduto.integracao_tipo_cd = Convert.ToInt32(cmbIntegracaoTipoDescricao.SelectedValue);
                F0095.reports.filtroIntegracaoProduto.integracao_status_cd = Convert.ToInt32(cmbIntegracaoStatus.SelectedValue);
                
                F0095.reports.filtroIntegracaoProduto.dtlog_insert_filter = chkfilter_dtlancamento.Checked ? 1 : 0;
                F0095.reports.filtroIntegracaoProduto.dtlog_insert_ini = dtplancamento_ini.Value;
                F0095.reports.filtroIntegracaoProduto.dtlog_insert_fim = dtplancamento_fim.Value;

                F0095.reports.filtroIntegracaoProduto.dtlog_update_filter = chkfilter_dtatualizacao.Checked ? 1 : 0;
                F0095.reports.filtroIntegracaoProduto.dtlog_update_ini = dtpatualizacao_ini.Value;
                F0095.reports.filtroIntegracaoProduto.dtlog_update_fim = dtpatualizacao_fim.Value;

                if (txtpr_cdproduto.Text != "")
                    F0095.reports.filtroIntegracaoProduto.pr_cdproduto = Convert.ToInt32(txtpr_cdproduto.Text);

                if (txtprb_cdprodutobluesoftunitario.Text != "")
                    F0095.reports.filtroIntegracaoProduto.prb_cdprodutoBluesfotUnitario = Convert.ToInt32(txtprb_cdprodutobluesoftunitario.Text);

                if (txtprb_cdprodutobluesoft.Text != "")
                    F0095.reports.filtroIntegracaoProduto.prb_cdprodutoBlueSoft = Convert.ToInt32(txtprb_cdprodutobluesoft.Text);

                F0095.reports.ProdutoIntegracaoConsultar();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_IntegracaoProduto")
            {
                dtgPI.DataSource = F0095.reports.dbList_IntegracaoProduto.List;
                lbltotal_itens.Text = F0095.reports.dbList_IntegracaoProduto.Count.ToString();
                UserTools._Screen_DataBinding_Set(lbl_integracao_produto_seq, dtgPI.DataSource, "integracao_produto_seq");
                UserTools._Screen_DataBinding_Set(lblpr_cdproduto, dtgPI.DataSource, "pr_cdproduto");
                UserTools._Screen_DataBinding_Set(lblprodutoDescricao, dtgPI.DataSource, "pr_descricao");
            }
            if (e.PropertyName == "dbList_IntegracaoLancamento")
            {
                dtgIntegracaoLancamento.DataSource = F0095.reports.dbList_IntegracaoLancamento.List;
            }

            
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAtualizaStatusParaPendente_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma atualização do Registro"))
                {
                    UserTools._Screen_Wait(this);
                    F0095.selecionarIntegracaoProduto(Convert.ToInt32(lbl_integracao_produto_seq.Text));
                    F0095.modelIntegracaoProduto.AtualizarStatusParaPendente(MyConnect);
                    F0095.reports.ProdutoIntegracaoConsultar();
                    UserTools._Screen_Wait(this);
                } 

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultarIntegracaoTipoInfo_Click(object sender, EventArgs e)
        {
            try
            {

                Integracao.frm_IntegracaoTipoInfo frmIntegracaoTipoInfo = new frm_IntegracaoTipoInfo(MyConnect);

                Pag_Net.src.F0095_Integracao.tbs.TbIntegracaoTipo IntegracaoTipo = ((Pag_Net.src.F0095_Integracao.tbs.TbIntegracaoTipo)cmbIntegracaoTipoDescricao.SelectedItem);

                frmIntegracaoTipoInfo.filter_integracao_tipo_cd = IntegracaoTipo.integracao_tipo_cd;

                frmIntegracaoTipoInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmbIntegracaoTipoDescricao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Pag_Net.src.F0095_Integracao.tbs.TbIntegracaoTipo ITEM = ((Pag_Net.src.F0095_Integracao.tbs.TbIntegracaoTipo)cmbIntegracaoTipoDescricao.SelectedItem);

                switch (ITEM.integracao_tipo_cd)
                {
                    case 20002090:
                        cmdGerarPendenciasPrecosD1.Enabled = false;
                        break;
                    case 20004501:
                        cmdGerarPendenciasPrecosD1.Enabled = false;
                        break;
                    case 20004502:
                        cmdGerarPendenciasPrecosD1.Enabled = false;
                        break;
                    case 20008501:
                        cmdGerarPendenciasPrecosD1.Enabled = true;
                        break; 

                }



            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex.Message);
            }
        }

        private void cmdGerarPendenciasPrecosD1_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                Pag_Net.src.F0095_Integracao.tbs.TbIntegracaoTipo ITEM = ((Pag_Net.src.F0095_Integracao.tbs.TbIntegracaoTipo)cmbIntegracaoTipoDescricao.SelectedItem);
                F0095.GerarPendenciaPrecoD1(ITEM.integracao_tipo_cd);
                UserTools._Screen_Wait(this);
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex.Message);
            }
        }

        private void cmdConsultarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblpr_cdproduto.Text != "") 
                {
                    
                    Pag_Form.forms.Cadastros.Produto.frm_Produto_Embalagem frmProduto = new Cadastros.Produto.frm_Produto_Embalagem(MyConnect, Convert.ToInt32(lblpr_cdproduto.Text));
                    frmProduto.ShowDialog();
                }
                else 
                {
                    UserTools._Screen_MessageBox(this, "Selecione um Produto!");
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultaLancamentoDaIntegracao_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_integracao_produto_seq.Text == "")
                {
                    UserTools._Screen_MessageBox(this, "Sequencial não informado");
                    return;
                }
                UserTools._Screen_Wait(this);
                F0095.reports.filtroIntegracaoProduto.integracao_produto_seq = Convert.ToInt32(lbl_integracao_produto_seq.Text);
                F0095.reports.IntegracoesLancamento();
                UserTools._Screen_Wait(this);

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
