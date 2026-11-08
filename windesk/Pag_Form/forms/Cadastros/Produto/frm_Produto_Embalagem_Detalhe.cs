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
    public partial class frm_Produto_Embalagem_Detalhe : Form
    {

        Pag_Net.Models.modelSistemaUsuario Myconnect;
        Pag_Net.src.F0020_Produto.model.model_produtoembalagem EmbalagemModel;



        public frm_Produto_Embalagem_Detalhe(Pag_Net.Models.modelSistemaUsuario _Myconnect, Pag_Net.src.F0020_Produto.model.model_produtoembalagem _EmbalagemModel)
        {
            try
            {
                InitializeComponent();

                Myconnect = _Myconnect;
                EmbalagemModel = _EmbalagemModel;
                _Screen_load();
            } 
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }
        private void _Screen_load()
        {
            try
            {

                /*lay - out*/
                UserTools._Screen_Form_Open(this);
                lbl_pre_embalagem_descricao.Text = EmbalagemModel.prb_descricao.ToString();
                lbl_prb_cdprodutobluesoft.Text = EmbalagemModel.prb_cdprodutobluesoft.ToString();
                lbl_prb_embalagemestoque.Text = EmbalagemModel.prb_embalagemestoque.ToString();
                lbl_label_prb_status.Text = EmbalagemModel.label_prb_status.ToString();
                /*info*/


                /*
                UserTools._Screen_DataBinding_Set(lbl_pre_embalagem, dtgProdutoEmbalagem.DataSource, "pre_embalagem");
                UserTools._Screen_DataBinding_Set(lbl_prb_cdprodutobluesoft, dtgProdutoEmbalagem.DataSource, "prb_cdprodutobluesoft");
                UserTools._Screen_DataBinding_Set(lbl_prb_embalagemestoque, dtgProdutoEmbalagem.DataSource, "prb_embalagemestoque");
                UserTools._Screen_DataBinding_Set(lbl_label_prb_status, dtgProdutoEmbalagem.DataSource, "prb_status_FORMATADO");
                UserTools._Screen_DataBinding_Set(lbl_pre_embalagem_descricao, dtgProdutoEmbalagem.DataSource, "prb_descricao");
                */

                dtgEmbalagem_Gtins.DataSource = null;


                if (lbl_prb_cdprodutobluesoft.Text != "")
                {

                    UserTools._Screen_Wait(this);
                    dtgEmbalagem_Gtins.DataSource = EmbalagemModel.GtinsGet(Myconnect).List;
                   
                    Pag_Net.src.F0021_ProdutoBluesoft._index ProdutoBlueSoftManager = new Pag_Net.src.F0021_ProdutoBluesoft._index(Myconnect);
                    ProdutoBlueSoftManager.reports.filtro.prb_cdprodutoBlueSoft = Convert.ToInt32(lbl_prb_cdprodutobluesoft.Text);

                    UserTools._Screen_Wait(this);
                }
                else
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Selecione uma embalagem");
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }
    }


}
