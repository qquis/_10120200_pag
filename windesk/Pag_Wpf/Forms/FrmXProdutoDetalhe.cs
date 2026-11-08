using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pag_Wpf.Forms
{
    public partial class FrmXProdutoDetalhe : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.SP_Produto SP;

        public FrmXProdutoDetalhe(Pag_Net.Models.modelSistemaUsuario _MyConnect, int _CdProduto, string _descricao)
        {
            try
            {
                InitializeComponent();

                txtCdProduto.Text = _CdProduto.ToString();
                txtDescricao.Text = _descricao.ToString();

                MyConnect = _MyConnect;

                SP = new Pag_Net.Bll.SP_Produto(MyConnect);
                SP.Parametros.F_CdProduto = Convert.ToInt32(txtCdProduto.Text);

                dtgEmbalagens.ReadOnly = true;
                dtgEmbalagens.DataSource = SP.getDataTable_TbProdutoEmbalagemSelect();

                dtgEmbalagemCdBarra.ReadOnly = true;
                dtgEmbalagemCdBarra.DataSource = SP.getDataTable_TbProdutoEmbalagemCbSelect();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
