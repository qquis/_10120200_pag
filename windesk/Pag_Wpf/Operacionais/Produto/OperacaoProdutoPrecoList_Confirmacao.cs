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
using Pag_Net.Bll.Operacionais.Produto;


namespace Pag_Wpf.Operacionais.Produto
{
    public partial class OperacaoProdutoPrecoList_Confirmacao : Form
    {
        modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Operacionais.Produto.Precos BLL;
        private Pag_Net.Bll.Operacionais.Produto.VWProdutoOperacaoPreco[] Lista;
        public OperacaoProdutoPrecoList_Confirmacao(modelSistemaUsuario __myConnect, 
            Pag_Net.Bll.Operacionais.Produto.VWProdutoOperacaoPreco[] __Lista)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Operacionais.Produto.Precos(MyConnect);

            DTPData.Value = DateTime.Now;
            DGListAlterados.AutoGenerateColumns = false;
            DGListAlterados.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;

            int linha = 0;
            Lista = __Lista;

            foreach(VWProdutoOperacaoPreco item in Lista)
            {
                DGListAlterados.Rows.Add();
                DGListAlterados[0, linha].Value = item.CdProduto;
                DGListAlterados[1, linha].Value = item.Descricao;
                DGListAlterados[2, linha].Value = item.EmbalagemEstoque;
                DGListAlterados[3, linha].Value = item.ValorCusto.ToString("0.00");
                DGListAlterados[4, linha].Value = item.ValorPrecoAlterado.ToString("0.00");
                DGListAlterados[5, linha].Value = item.MargemAlterada.ToString("0.00");
                linha = linha + 1;
            }

            TXTTotalItens.Text = Lista.Count().ToString();
        }

        private void OperacaoProdutoPrecoList_Confirmacao_Load(object sender, EventArgs e)
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
                if (MessageBox.Show("Confirma alteração dos preços?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {


                    Pag_Net.Bll.Operacionais.Produto.UspProdutoPrecoAlteracao.Aplicacao(MyConnect, Lista, DTPData.Value, 2);
                    MessageBox.Show("Atualização concluida com sucesso!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na atualização dos preços");
            }
        }

        private void DGListAlterados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
