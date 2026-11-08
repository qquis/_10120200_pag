using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Bll;
using Pag_Net.Models;


namespace Pag_Wpf.Cadastro
{
    public partial class ProdutoRelacaoGestor : Form
    {
        private Pag_Net.Bll.Cadastros.Produto _BLL;
        modelSistemaUsuario MyConnect;
        public ProdutoRelacaoGestor(modelSistemaUsuario __myConnect, string __codigos)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Cadastros.Produto(__myConnect);
            _BLL.List.Filtros.Codigos = __codigos.ToString();
            CMBGestor.ValueMember = "SeqProdutoGestor";
            CMBGestor.DisplayMember = "Descricao";
            CMBGestor.DataSource = _BLL.Gestor.ViewData;

            Cursor.Current = Cursors.WaitCursor;
            DataGridProdutoLocaliza.AutoGenerateColumns = false;
            DataGridProdutoLocaliza.AutoGenerateColumns = false;
            DataGridProdutoLocaliza.MultiSelect = true;
            DataGridProdutoLocaliza.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.AllowUserToAddRows = false;
            DataGridProdutoLocaliza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Cursor.Current = Cursors.Arrow;
            _BLL.List.Select();
            int linha = 0;
            foreach (Pag_Net.Bll.Cadastros.UVWProduto item in _BLL.List.ViewData)
            {
                DataGridProdutoLocaliza.Rows.Add();
                DataGridProdutoLocaliza[0, linha].Value = item.CdProduto.ToString();
                DataGridProdutoLocaliza[1, linha].Value = item.Descricao.ToString();
                DataGridProdutoLocaliza[2, linha].Value = item.EmbalagemEstoque.ToString();
                linha += 1;
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void CMDCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (CMBGestor.SelectedValue.ToString() != "" || CMBGestor.SelectedValue.ToString() != "0")
                    Pag_Net.Bll.Cadastros.UspProdutoRelacaoGestor.Relacionar(MyConnect, Convert.ToInt32(CMBGestor.SelectedValue.ToString()), _BLL.List.Filtros.Codigos);

                MessageBox.Show("Atualização Realizada com Sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
        }
    }
}
