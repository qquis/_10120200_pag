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

namespace Pag_Wpf.Operacionais.Produto
{
    public partial class OperacaoPrecoAdministracao : Form
    {
        private Pag_Net.Bll.Operacionais.Produto.Kit  _BLL;
        public OperacaoPrecoAdministracao(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();

            _BLL = new Pag_Net.Bll.Operacionais.Produto.Kit(__myConnect);
            CMBFabricante.ValueMember = "CdFabricante";
            CMBFabricante.DisplayMember = "Descricao";
            CMBDepartamento.ValueMember = "CdProdutoDepartamento";
            CMBDepartamento.DisplayMember = "DescricaoDepartamento";
            CMBSecao.ValueMember = "CdProdutoSecao";
            CMBSecao.DisplayMember = "DescricaoSecao";
            CMBLinha.ValueMember = "CdProdutoLinha";
            CMBLinha.DisplayMember = "DescricaoLinha";
            CMBDepartamento.DataSource = _BLL.Cadastros.Complementos.Departamento;
            CMBSecao.DataSource = _BLL.Cadastros.Complementos.Secao;
            CMBLinha.DataSource = _BLL.Cadastros.Complementos.Linha;

            Pag_Net.Bll.Cadastros.Fabricante Fabricante = new Pag_Net.Bll.Cadastros.Fabricante(__myConnect);
            CMBFabricante.DataSource = Fabricante.ViewData;
        }

        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _BLL.Administracao.Filtros.CdOperacao = 2;
                _BLL.Administracao.Select();

                int linha = 0;
                foreach (Pag_Net.Bll.Operacionais.Produto.UVWProdutoPrecoAdministracao item in _BLL.Administracao.ViewData)
                {
                    DataGridProdutoPrecoAdministracao.Rows.Add();
                    DataGridProdutoPrecoAdministracao[0, linha].Value = item.CdProduto.ToString();
                    DataGridProdutoPrecoAdministracao[1, linha].Value = item.Descricao.ToString();
                    DataGridProdutoPrecoAdministracao[2, linha].Value = item.EmbalagemEstoque.ToString();
                    DataGridProdutoPrecoAdministracao[3, linha].Value = "0";
                    DataGridProdutoPrecoAdministracao[4, linha].Value = item.ValorPreco.ToString();
                    linha += 1;
                }
                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
