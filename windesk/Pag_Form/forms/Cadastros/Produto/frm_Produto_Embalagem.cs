using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Cadastros.Produto
{
    public partial class frm_Produto_Embalagem : Form
    {
        //Pag_Net.Bll.Produto.List BLL;

        Pag_Net.Models.modelSistemaUsuario Myconnect;

        Pag_Net.src.F0020_Produto.model.model_produto ProdutoMODEL;


        public frm_Produto_Embalagem(Pag_Net.Models.modelSistemaUsuario myconnect, int _pr_cdproduto)
        {
            InitializeComponent();
            Myconnect = myconnect;



            ProdutoMODEL = new Pag_Net.src.F0020_Produto.model.model_produto(Myconnect, _pr_cdproduto);
            

            _Screen_load();

        }


        private void _Screen_load()
        {
            try
            {
                
                /*lay - out*/
                UserTools._Screen_Form_Open(this);
                UserTools._Screen_ButtonImage(cmdDetalhar, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdEmbalagemPagConsultarBlueSoft, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdEmbalagemPagConsultarBlueSoftTributacao, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdCestaConsultarBlueSoftTributacao, UserTools.PagButtonsIcons.Detalhe);
      
                /*info*/
                lbl_pr_cdproduto.Text = ProdutoMODEL.pr_cdproduto.ToString();
                lbl_data_pr_descricao.Text = ProdutoMODEL.pr_descricao.ToString();
                lbl_pr_cdprodutobluesoft.Text = ProdutoMODEL.prb_cdprodutobluesoft.ToString();
                lbl_label_descricao_pr_status.Text = ProdutoMODEL.label_descricao_pr_status.ToString();

                dtgProdutoEmbalagem.DataSource = ProdutoMODEL.DBDataTableListEmbalagem.List;
                
                lbl_info_total.Text = ProdutoMODEL.DBDataTableListEmbalagem.Count.ToString();

                UserTools._Screen_DataBinding_Set(lbl_pre_embalagem, dtgProdutoEmbalagem.DataSource, "pre_embalagem");
                UserTools._Screen_DataBinding_Set(lbl_prb_cdprodutobluesoft, dtgProdutoEmbalagem.DataSource, "prb_cdprodutobluesoft");
                UserTools._Screen_DataBinding_Set(lbl_prb_embalagemestoque, dtgProdutoEmbalagem.DataSource, "prb_embalagemestoque");
                UserTools._Screen_DataBinding_Set(lbl_label_prb_status, dtgProdutoEmbalagem.DataSource, "prb_status_FORMATADO");
                UserTools._Screen_DataBinding_Set(lblpre_embalagem_descricao, dtgProdutoEmbalagem.DataSource, "prb_descricao");

                dtgCestaProduto_Composicao.DataSource = ProdutoMODEL.ConsultarCestaComposicao(Myconnect).List;
                UserTools._Screen_DataBinding_Set(lbldescricao_item_cesta, dtgCestaProduto_Composicao.DataSource, "prb_descricao");
                UserTools._Screen_DataBinding_Set(lblprb_cdprodutobluesoft_item_cesta, dtgCestaProduto_Composicao.DataSource, "prb_cdprodutobluesoft");
               
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

        private void cmdConsultarIntegracoes_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_pr_cdproduto.Text != "")
                {
                    Integracao.Produto.frm_IntegracaoProduto frmProdutoIntegracao = new Integracao.Produto.frm_IntegracaoProduto(Myconnect, Convert.ToInt32(lbl_pr_cdproduto.Text));
                    frmProdutoIntegracao.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        private void cmdDetalhar_Click(object sender, EventArgs e)
        {
            detalhe_item(ProdutoMODEL.pr_cdproduto, Convert.ToInt32(lbl_prb_cdprodutobluesoft.Text));
        }

        private void cmdDetalharItemCestaBasica_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if (dtgCestaProduto_Composicao.CurrentCell.RowIndex >= 0)
                {
                    int pr_cdproduto = Convert.ToInt32(dtgCestaProduto_Composicao[0, dtgCestaProduto_Composicao.CurrentCell.RowIndex].Value.ToString());
                    int prb_cdprodutobluesoft = Convert.ToInt32(dtgCestaProduto_Composicao[1, dtgCestaProduto_Composicao.CurrentCell.RowIndex].Value.ToString());
                    detalhe_item(pr_cdproduto, prb_cdprodutobluesoft);
                }
                else
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Não há dados a serem selecionados");
                }*/
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void detalhe_item(int pr_cdproduto, int prb_cdprodutobluesoft)
        {
            try
            {
                Pag_Net.src.F0020_Produto.model.model_produtoembalagem EmbalagemModel = new Pag_Net.src.F0020_Produto.model.model_produtoembalagem(Myconnect, pr_cdproduto, prb_cdprodutobluesoft);
                Produto.frm_Produto_Embalagem_Detalhe frmdetalhe = new frm_Produto_Embalagem_Detalhe(Myconnect, EmbalagemModel);
                frmdetalhe.ShowDialog();
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdEmbalagemPagConsultarBlueSoft_Click(object sender, EventArgs e)
        {
            if (lbl_prb_cdprodutobluesoft.Text != "")
            {
                detalhe_bluesoft(Convert.ToInt32(lbl_prb_cdprodutobluesoft.Text));
            }
        }

        private void cmdEmbalagemPagConsultarBlueSoftTributacao_Click(object sender, EventArgs e)
        {
            if (lbl_prb_cdprodutobluesoft.Text != "")
            {
                detalhe_bluesoftTributacao(Convert.ToInt32(lbl_prb_cdprodutobluesoft.Text));
            }

        }

        private void cmdCestaPagConsultarBlueSoft_Click(object sender, EventArgs e)
        {
            if (lblprb_cdprodutobluesoft_item_cesta.Text != "")
            {
                detalhe_bluesoft(Convert.ToInt32(lblprb_cdprodutobluesoft_item_cesta.Text));
            }
            else 
            {
                UserTools._Screen_MessageBox(this, "Favor selecionar o Item de Cesta");
            }

        }

        private void cmdCestaConsultarBlueSoftTributacao_Click(object sender, EventArgs e)
        {
            if (lblprb_cdprodutobluesoft_item_cesta.Text != "")
            {
                detalhe_bluesoftTributacao(Convert.ToInt32(lblprb_cdprodutobluesoft_item_cesta.Text));
            }
            else
            {
                UserTools._Screen_MessageBox(this, "Favor selecionar o Item de Cesta");
            }
        }

        private void detalhe_bluesoft(int prb_cdprodutobluesoft)
        {
            try
            {
                Cadastros.ProdutoBluesoft.frm_ProdutoBluesoft frmblue = new ProdutoBluesoft.frm_ProdutoBluesoft(Myconnect, prb_cdprodutobluesoft);
                frmblue.ShowDialog();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void detalhe_bluesoftTributacao(int prb_cdprodutobluesoft)
        {
            try
            {
                Cadastros.ProdutoBluesoft.frm_ProdutoBlueSoftTributacao frmblue = new ProdutoBluesoft.frm_ProdutoBlueSoftTributacao(Myconnect, prb_cdprodutobluesoft);
                frmblue.ShowDialog();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }






        
    }
}


/*
 * Alteração em 08/09/2021 | CmdCodigoBarra_Consulta_Click -> BLL.filters_produto.CdProdutoBluesoft = "0" _ Permitir que em qualquer embalagem
 * ocorra a busca pelos códigos de barra do produto
 */