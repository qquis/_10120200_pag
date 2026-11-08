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
    public partial class ProdutoRelacaoCategoria : Form
    {
        private Pag_Net.Bll.Cadastros.Produto _BLL;
        modelSistemaUsuario MyConnect;
        public ProdutoRelacaoCategoria(modelSistemaUsuario __myConnect, string __codigos)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Cadastros.Produto(__myConnect);


            DataGridProdutoLocaliza.AutoGenerateColumns = false;
            DataGridProdutoLocaliza.MultiSelect = true;
            DataGridProdutoLocaliza.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.AllowUserToAddRows = false;
            DataGridProdutoLocaliza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CMBFabricante.ValueMember = "CdFabricante";
            CMBFabricante.DisplayMember = "Descricao";
            CMBDepartamento.ValueMember = "CdProdutoDepartamento";
            CMBDepartamento.DisplayMember = "DescricaoDepartamento";
            CMBSecao.ValueMember = "CdProdutoSecao";
            CMBSecao.DisplayMember = "DescricaoSecao";
            CMBLinha.ValueMember = "CdProdutoLinha";
            CMBLinha.DisplayMember = "DescricaoLinha";
            CMBDepartamento.DataSource = _BLL.Complementos.Departamento;
            CMBSecao.DataSource = _BLL.Complementos.Secao;
            CMBLinha.DataSource = _BLL.Complementos.Linha;

            CMBCategoria.ValueMember = "SeqProdutoCategoria";
            CMBCategoria.DisplayMember = "Descricao";
            CMBCategoria.DataSource = _BLL.Categoria.ViewData;

            if (__codigos.Trim() != "")
            {
                TXTCodigoProduto.Text = __codigos;
                CMDLocalizar_Click(null, null);

            }


       
        }

        private void ProdutoRelacaoCategoria_Load(object sender, EventArgs e)
        {
           
        }

        private void CMDCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (CMBCategoria.SelectedValue.ToString() != "" || CMBCategoria.SelectedValue.ToString() != "0")
                {

                    string codigos = "";
                    int linha = 0;
                    this.Cursor = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in DataGridProdutoLocaliza.Rows)
                    {
                        if (Convert.ToBoolean( row.Cells["DTGColumnSeleciona"].Value) == true)
                        {
                            
                            if (linha == 0)
                            {
                                codigos = row.Cells["DTGColumnCdProduto"].Value.ToString();
                            }
                            else
                            {
                                codigos = codigos + "," + row.Cells["DTGColumnCdProduto"].Value.ToString();
                            }
                            linha = linha + 1;
                        }
                        
                    }
                    this.Cursor = Cursors.Arrow;
                    Pag_Net.Bll.Cadastros.UspProdutoRelacaoCategoria.Relacionar(MyConnect, Convert.ToInt32(CMBCategoria.SelectedValue.ToString()), codigos);
                    MessageBox.Show("Atualização Realizada com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }

        }

        private void CMBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridProdutoLocaliza_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataGridProdutoLocaliza.Rows.Clear();

                _BLL.List.Filtros.DataCadastro = false;
                _BLL.List.Filtros.DataCadastroInicial = DateTime.Now;
                _BLL.List.Filtros.DataCadastroFinal = DateTime.Now;
                _BLL.List.Filtros.StatusProduto = true;
                _BLL.List.Filtros.CdProdutoDepartamento = "";
                _BLL.List.Filtros.CdProdutoSecao = "";
                _BLL.List.Filtros.CdProdutoLinha = "";
                _BLL.List.Filtros.SeqProdutoCategoria = 0;


                if (TXTCodigoCategoria.Text.Trim() != "")
                {
                    _BLL.List.Filtros.SeqProdutoCategoria = Convert.ToInt32(TXTCodigoCategoria.Text.Trim());
                }

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


                _BLL.List.Select();
                int linha = 0;
                foreach (Pag_Net.Bll.Cadastros.UVWProduto item in _BLL.List.ViewData)
                {
                    DataGridProdutoLocaliza.Rows.Add();
                    DataGridProdutoLocaliza[0, linha].Value = item.CdProduto.ToString();
                    DataGridProdutoLocaliza[1, linha].Value = item.Descricao.ToString();
                    DataGridProdutoLocaliza[2, linha].Value = item.EmbalagemEstoque.ToString();
                    DataGridProdutoLocaliza[4, linha].Value = true;
                    linha += 1;
                }
                LBLTOTALPRODUTO.Text = "Total: " + linha.ToString();
                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDSelecionaTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataGridProdutoLocaliza.Rows)
            {
                this.Cursor = Cursors.WaitCursor;
                row.Cells["DTGColumnSeleciona"].Value = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void CMDLimpaSelecao_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataGridProdutoLocaliza.Rows)
            {
                this.Cursor = Cursors.WaitCursor;
                row.Cells["DTGColumnSeleciona"].Value = false;
                this.Cursor = Cursors.Arrow;
            }
        }


    }
}
