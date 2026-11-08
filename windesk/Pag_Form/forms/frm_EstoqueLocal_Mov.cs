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
    public partial class frm_EstoqueLocal_Mov : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0020_Produto.WkProduto WKProduto;
        Pag_Net.Bll.F0025_EstoqueLocal.WK WKEstoqueLocal;

        public frm_EstoqueLocal_Mov(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;

            WKProduto = new Pag_Net.Bll.F0020_Produto.WkProduto(MyConnect);
            WKEstoqueLocal = new Pag_Net.Bll.F0025_EstoqueLocal.WK(MyConnect);
            _Screen_load();
        }
        private void _Screen_load()
        {
            try
            {
                //__WKControle_REG = new Pag_Net.Bll.F0130_Controle.WKControle_Reg(MyConnect);
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                //cmdsair.Click += new EventHandler(_Screen_Click);

                //dtgProdutoEmbalagem.AutoGenerateColumns = false;
                //lbl_prb_cdprodutobluesoft.TextChanged += new EventHandler(_Screen_changed);
                //txtestlocal_mov_embalagemestoque_qtde.TextChanged += new EventHandler(_Screen_changed);
                dtgProdutoEmbalagem.SelectionChanged += new EventHandler(DTG_SelectionChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _Screen_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Button")
            {


            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_prb_cdprodutobluesoft")
                    {
                        txtestlocal_mov_embalagemestoque_qtde.Text = "1";
                        _Embalagem_List_Calcular();

                    }
                }
                if (sender.GetType().Name == "TextBox") 
                {
                    if (((TextBox)sender).Name == "txtestlocal_mov_embalagemestoque_qtde") { _Embalagem_List_Calcular(); }
                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") { }
                if (sender.GetType().Name == "TabControl") { if (((TabControl)sender).Name == "tabPortaria") { } }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            _Embalagens_List_Get();
        }
        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdEfetivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_pr_cdproduto.Text != "")
                {
                    int pr_cdproduto = Convert.ToInt32(lbl_pr_cdproduto.Text );
                    string pr_embalagemEstoque = lbl_pr_embalagemestoque.Text;
                    double estlocal_mov_embalagemestoque_qtde = Convert.ToDouble(txtestlocal_mov_embalagemestoque_qtde.Text);
                    WKEstoqueLocal.EstoqueLocal_Mov_Registrar(pr_cdproduto, pr_embalagemEstoque, estlocal_mov_embalagemestoque_qtde);
                    _Screen_Clear();
                }
                else
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Selecione o Produto/Embalagem");
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Error | Possível Valor Inválido: ", ex);
            }
        }
        private void DTG_SelectionChanged(object sender, EventArgs e)
        {
            _Embalagem_List_Calcular();

        }
        private void txtCodigo_Barra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCodigo_Barra.Text.Trim().Length > 0)
            {
                try
                {
                    _Embalagens_List_Get();
                    cmdEfetivar_Click(null, null);
                    _Screen_Clear();
                }
                catch (Exception ex)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
                    MessageBox.Show(ex.Message);
                }

            }
        }       

        private void _Embalagem_List_Calcular()
        {
            try
            {
                if (txtestlocal_mov_embalagemestoque_qtde.Text == "")
                    txtestlocal_mov_embalagemestoque_qtde.Text = "1";

                double Fator = 0;
                try
                {
                    Fator = Convert.ToDouble(dtgProdutoEmbalagem.CurrentRow.Cells["dtgProdutoEmbalagem_COL_ec_embalagemestoque_qtde"].Value.ToString());
                }
                catch(Exception)
                {
                    return;
                }

                if (txtestlocal_mov_embalagemestoque_qtde.Text != "")
                {
                    double estlocal_mov_embalagemestoque_qtde = Convert.ToDouble(txtestlocal_mov_embalagemestoque_qtde.Text);

                    lblINFO_estlocal_mov_embalagemestoque_qtde.Text = (estlocal_mov_embalagemestoque_qtde * Fator).ToString();
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }
        private void _Embalagens_List_Get()
        {
            try
            {

                dtgProdutoEmbalagem.DataSource = null;
                

                int pr_cdproduto = 0;
                int prb_cdprodutobluesoft = 0;
                string preg_cdbarra = "";


                if (txtcdproduto.Text != "")
                {
                    pr_cdproduto = Convert.ToInt32(txtcdproduto.Text);
                }

                if (txtcdprodutobluesoft.Text != "")
                {
                    prb_cdprodutobluesoft = Convert.ToInt32(txtcdprodutobluesoft.Text);
                }

                if (txtCodigo_Barra.Text != "")
                {
                    preg_cdbarra = txtCodigo_Barra.Text;
                }

                UserTools._Screen_Wait(this, true);
                DataTable localDataTableProdutoEmbalagem = WKProduto.ProdutoEmbalagem_List_Get(pr_cdproduto, prb_cdprodutobluesoft, preg_cdbarra);

                if (localDataTableProdutoEmbalagem.Rows.Count < 1)
                {
                    throw new Exception("Produto NÃO localizado");
                }

                dtgProdutoEmbalagem.DataSource = localDataTableProdutoEmbalagem;
                UserTools._Screen_Wait(this, false);


                foreach (Control item in this.Controls)
                {
                    if (item.Name.Substring(0, 4) == "lbl_")
                    {
                        string name = item.Name.Substring(4);
                        item.DataBindings.Clear();
                        item.DataBindings.Add("Text", dtgProdutoEmbalagem.DataSource, name);
                    }
                }


            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                txtcdproduto.Text = "";
                txtcdprodutobluesoft.Text = "";
                txtCodigo_Barra.Text = "";
                txtdescricao.Text = "";
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
            }
        }
        private void _Screen_Clear()
        {
            txtcdproduto.Text = "";
            txtcdprodutobluesoft.Text = "";
            txtdescricao.Text = "";
            txtCodigo_Barra.Text = "";
            dtgProdutoEmbalagem.DataSource = null;
            foreach (Control item in this.Controls)
            {
                if (item.Name.Substring(0, 4) == "lbl_")
                {
                    item.DataBindings.Clear();
                    item.Text = "";
                }
            }

        }



    }
}
