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
    public partial class ProdutoRelacaoLinha : Form
    {
        private Pag_Net.Bll.Cadastros.Produto _BLL;
        modelSistemaUsuario MyConnect;
        public ProdutoRelacaoLinha(modelSistemaUsuario __myConnect, string __codigos)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Cadastros.Produto(__myConnect);
            _BLL.List.Filtros.Codigos = __codigos.ToString();
            CMBDepartamento.ValueMember = "CdProdutoDepartamento";
            CMBDepartamento.DisplayMember = "DescricaoDepartamento";
            CMBSecao.ValueMember = "CdProdutoSecao";
            CMBSecao.DisplayMember = "DescricaoSecao";
            CMBLinha.ValueMember = "CdProdutoLinha";
            CMBLinha.DisplayMember = "DescricaoLinha";

            CMBDepartamento.DataSource = _BLL.Complementos.Departamento;
            CMBSecao.DataSource = _BLL.Complementos.Secao;
            CMBLinha.DataSource = _BLL.Complementos.Linha;

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

        private void ProdutoRelacaoLinha_Load(object sender, EventArgs e)
        {

        }

        private void CMBDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BLL.Complementos.CdProdutoSecaoSelecionada = "";
        }

        private void CMBSecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CMBDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CMBDepartamento.SelectedItem != null)
            {
                _BLL.Complementos.CdProdutoDepartamentoSelecionado = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento;
                _BLL.Complementos.CdProdutoSecaoSelecionada = "";
                CMBSecao.DataSource = _BLL.Complementos.Secao;
                CMBLinha.DataSource = _BLL.Complementos.Linha;
            }
            else
            {
                _BLL.Complementos.CdProdutoDepartamentoSelecionado = "";
                _BLL.Complementos.CdProdutoSecaoSelecionada = "";
                CMBSecao.DataSource = _BLL.Complementos.Secao;
                CMBLinha.DataSource = _BLL.Complementos.Linha;
            }
        }

        private void CMDCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMBSecao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CMBSecao.SelectedItem != null)
            {
                _BLL.Complementos.CdProdutoSecaoSelecionada = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao;
                CMBLinha.DataSource = _BLL.Complementos.Linha;
            }

            else 
            {
                _BLL.Complementos.CdProdutoSecaoSelecionada = "";
                CMBLinha.DataSource = _BLL.Complementos.Linha;

            }
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (CMBLinha.SelectedValue.ToString() != "" || CMBLinha.SelectedValue.ToString() != "0")
                    Pag_Net.Bll.Cadastros.UspProdutoRelacaoLinha.Relacionar(MyConnect, CMBLinha.SelectedValue.ToString(), _BLL.List.Filtros.Codigos);

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



/*

      private void cmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
            if (cmbDepartamento.SelectedItem != null)
            {
                BLL.Faturamento.Filtros.Departamento = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
            }
        }
        private void cmbSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                BLL.Faturamento.Filtros.Secao = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;
            }
        }
        private void cmbLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLinha.SelectedItem != null)
            {
                BLL.Faturamento.Filtros.Linha = ((Pag_Net.Bll.Cadastros.Linha)cmbLinha.SelectedItem).CdProdutoLinha;
            }
        }

        private void cmbDepartamento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbDepartamento.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
                cmbSecao.ItemsSource = BLL.Cadastros.ProdutosComplementos.Secao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }
            else
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = "";
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
                cmbSecao.ItemsSource = BLL.Cadastros.ProdutosComplementos.Secao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }

        }
        private void cmbSecao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }

            if (cmbLinha.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;

            }
        }

*/