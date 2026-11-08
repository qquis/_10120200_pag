using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Bll;


namespace Pag_Wpf.Forms
{
    public partial class FrmXProdutoBlueSoft : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        int ProdutoSelecionado = 0;

        public FrmXProdutoBlueSoft(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();

            MyConnect = _MyConnect;
            dtgProdutoBlueSoft.AutoGenerateColumns = false;
            dtgProdutoBlueSoft.ReadOnly = true;

            dtgEmbalagem.AutoGenerateColumns = false;
            dtgEmbalagem.ReadOnly = true;
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dtgProdutoBlueSoft.DataSource = Pag_Net.Bll.Produto_OLD.BlueSoft_Select.List(MyConnect, txtcdProdutoBluePesquisar.Text.ToUpper(), txtDescricaoBluePesquisar.Text.ToUpper());
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdAtualizarBase_Click(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;
            try
            {

                prgProduto.Maximum = 5;
                Pag_Net.Bll.Produto_OLD.BlueSoft_Import.Start(MyConnect);
                prgProduto.Value = 1;
                prgProduto.Refresh();
                Pag_Net.Bll.Produto_OLD.BlueSoft_Import_CodigoBarra.Start(MyConnect);
                prgProduto.Value = 2;
                prgProduto.Refresh();
                Pag_Net.Bll.Produto_OLD.BlueSoft_Import_Categoria.Start(MyConnect);
                prgProduto.Value = 3;
                Pag_Net.Bll.Produto_OLD.BlueSOft_Import_Tributacao.Start(MyConnect);
                prgProduto.Value = 4;
                Pag_Net.Bll.Produto_OLD.Update.Start(MyConnect);
                prgProduto.Value = 5;

                prgProduto.Refresh();
                this.Cursor = Cursors.Default;

                MessageBox.Show("Atualização de Produtos BlueSoft realizada com sucesso");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ProdutoSelecionado > 0)
                {
                    dtgEmbalagem.DataSource = Pag_Net.Bll.Produto_OLD.BlueSoft_Select_CodigoBarra.List(MyConnect, ProdutoSelecionado);

                    if (dtgProdutoBlueSoft.SelectedRows.Count > 0)
                    {
                        txtcdProdutoBlueSoftSelecionado.Text = dtgProdutoBlueSoft.SelectedRows[0].Cells[0].Value.ToString();
                        txtdescricaoblueselecionado.Text = dtgProdutoBlueSoft.SelectedRows[0].Cells[1].Value.ToString();
                    }

                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dtgProdutoBlueSoft_SelectionChanged(object sender, EventArgs e)
        {

            if (dtgProdutoBlueSoft.SelectedRows.Count > 0)
            {
                ProdutoSelecionado = Convert.ToInt32(dtgProdutoBlueSoft.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void cmdCodigoUnitario_Click(object sender, EventArgs e)
        {
            FrmXProdutoHtml x = new FrmXProdutoHtml(MyConnect);
            x.ShowDialog();
        }
    }
}
