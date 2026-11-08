using Pag_Net.Bll.Loja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Loja
{
    public partial class Frm_Loja_Etiqueta_Gondola_Caixa : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        int PR_CDPRODUTO = 0;
        string PRB_DESCRICAO = "";



        public Frm_Loja_Etiqueta_Gondola_Caixa(Pag_Net.Models.modelSistemaUsuario _MyConnect, int pr_cdproduto, string prb_descricao)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            PR_CDPRODUTO = pr_cdproduto;
            PRB_DESCRICAO = prb_descricao;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {

                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdefetivar_precos_alterados.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\print.ico");
         
                dtgEtiqueta_Precos.AutoGenerateColumns = false;

                lbl_pr_cdproduto.Text = PR_CDPRODUTO.ToString();
                lbl_pr_descricao.Text = PRB_DESCRICAO;

                
                
                dtgEtiqueta_Precos.DataSource = EtiquetaCaixa.ConsultarCaixas(MyConnect, PR_CDPRODUTO).List;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Inicializçaão do Formulário: " + ex.Message);
            }



        }

        private void cmdefetivar_precos_alterados_Click(object sender, EventArgs e)
        {
            try
            {

                Pag_Net.Bll.Loja.EtiquetaPrecos_Imprimir IMPRIMIR = new Pag_Net.Bll.Loja.EtiquetaPrecos_Imprimir();

                Pag_Net.Bll.Loja.Db.Etiqueta __ETIQUETA = new Pag_Net.Bll.Loja.Db.Etiqueta();

                if (dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_cdprodutoblueosft"].Value.ToString() == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Item não selecionado!");
                    return;
                }
                
                __ETIQUETA.CdProduto = Convert.ToInt32(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_cdprodutoblueosft"].Value.ToString());
                __ETIQUETA.Descricao = dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_descricao"].Value.ToString();
                __ETIQUETA.Embalagem = dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_pr_embalagemestoque"].Value.ToString();
                __ETIQUETA.EmbalagemDescricao = dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_descricao"].Value.ToString();
                __ETIQUETA.CodigoBarra = dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_preg_cdbarra"].Value.ToString();
                __ETIQUETA.ValorPreco = Convert.ToDouble(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prc_valor"].Value.ToString());

                if (__ETIQUETA.Embalagem == "UN")
                {
                    __ETIQUETA.TipoCodigoBarra = "EAN13";
                }


                if (Convert.ToDouble(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prc_qtde_promocional"].Value.ToString()) > 0)
                {
                    __ETIQUETA.AtacadoQtdeMinima = Convert.ToDouble(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prc_qtde_promocional"].Value.ToString());
                    __ETIQUETA.AtacadoQtdePromocional = Convert.ToDouble(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prc_qtde_promocional"].Value.ToString());
                    __ETIQUETA.ValorPromocional = Convert.ToDouble(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prc_valor_promocional"].Value.ToString());
                    __ETIQUETA.AtacadoEmbalagem = "CX";
                }
                else
                {
                    __ETIQUETA.AtacadoQtdeMinima = 0;

                    __ETIQUETA.AtacadoQtdePromocional = 0;
                    __ETIQUETA.AtacadoEmbalagem = "";
                    __ETIQUETA.AtacadoCodigoBarra = "";
                }
                IMPRIMIR.Adicionar(__ETIQUETA);


                IMPRIMIR.Imprimir();

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
    }
}
