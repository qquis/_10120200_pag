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
    public partial class ProdutoLocaliza : Form
    {
        public string ReturnListaCodigosSelecionados = "";
        private Pag_Net.Bll.Cadastros.Produto _BLL;
        public ProdutoLocaliza(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            _BLL = new Pag_Net.Bll.Cadastros.Produto(__myConnect);
            CMBFabricante.ValueMember = "CdFabricante";
            CMBFabricante.DisplayMember = "Descricao";
            CMBDepartamento.ValueMember = "CdProdutoDepartamento";
            CMBDepartamento.DisplayMember = "DescricaoDepartamento";
            CMBSecao.ValueMember = "CdProdutoSecao";
            CMBSecao.DisplayMember = "DescricaoSecao";
            CMBLinha.ValueMember = "CdProdutoLinha";
            CMBLinha.DisplayMember = "DescricaoLinha";
            CMBDepartamento.DataSource  = _BLL.Complementos.Departamento;
            CMBSecao.DataSource  = _BLL.Complementos.Secao;
            CMBLinha.DataSource  = _BLL.Complementos.Linha;
            
            Pag_Net.Bll.Cadastros.Fabricante Fabricante = new Pag_Net.Bll.Cadastros.Fabricante(__myConnect);
            CMBFabricante.DataSource = Fabricante.ViewData;
           
        }

        private void ProdutoLocaliza_Load(object sender, EventArgs e)
        {

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
            

        }


        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _BLL.List.Filtros.DataCadastro = false;
            _BLL.List.Filtros.DataCadastroInicial= DateTime.Now;
            _BLL.List.Filtros.DataCadastroFinal = DateTime.Now;
            _BLL.List.Filtros.StatusProduto = true;
            _BLL.List.Filtros.CdProdutoDepartamento = "";
            _BLL.List.Filtros.CdProdutoSecao = "";
            _BLL.List.Filtros.CdProdutoLinha = "";
            if (Convert.ToString(CMBDepartamento.SelectedValue) != "" && CMBDepartamento.SelectedValue != null)
            {
                _BLL.List.Filtros.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento;
            }
            if (Convert.ToString(CMBSecao.SelectedValue) != "" && CMBSecao.SelectedValue != null)
            {
                _BLL.List.Filtros.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao;
            }
            if (Convert.ToString(CMBLinha.SelectedValue) != "" && CMBLinha.SelectedValue != null)
            {
                _BLL.List.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha;
            }

            if (Convert.ToString(CMBLinha.SelectedValue) != "" && CMBLinha.SelectedValue != null)
            {
                _BLL.List.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha;
            }



            if (Convert.ToString(CMBFabricante.SelectedValue) != "" && CMBFabricante.SelectedValue != null)
            {
                _BLL.List.Filtros.CdFabricante = ((Pag_Net.Bll.Cadastros.UVWFabricante)CMBFabricante.SelectedItem).CdFabricante;
            }

            _BLL.List.Filtros.Descricao = TXTDescricaoProduto.Text;
            _BLL.List.Filtros.Codigos = TXTCodigoProduto.Text;
            DataGridProdutoLocaliza.Rows.Clear();
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

        private void cmdSeleciona_Click(object sender, EventArgs e)
        {
            int linha = 0;
            for (int i = 0; i < DataGridProdutoLocaliza.Rows.Count; i++ )
            {
                if (DataGridProdutoLocaliza[0, i].Selected == true)
                {
                    if (linha == 0)
                    {
                        ReturnListaCodigosSelecionados = DataGridProdutoLocaliza[0, i].Value.ToString();
                    }
                    else
                    {
                        ReturnListaCodigosSelecionados = ReturnListaCodigosSelecionados + "," + DataGridProdutoLocaliza[0, i].Value.ToString();
                    }
                    linha = linha + 1;
                }
            }
            this.Close();
        }

        private void cmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
