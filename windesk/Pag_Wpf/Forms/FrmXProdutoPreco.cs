using Pag_Net.Models;
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
    public partial class FrmXProdutoPreco : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.SP_ProdutoPrecos SP; 

        public FrmXProdutoPreco(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            InitializeComponent();
            _fillForm();
        }

        /*Objects*/
        private void ChkDataAlteracaoCusto_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDataAlteracaoCusto.Checked)
            {
                GroupBoxDataAlteracaoCusto.Enabled = true;
                lblFiltroCusto.Text = "Filtro de Custo Ativado";
                lblFiltroCusto.ForeColor = Color.Red;
            }
            else
            {
                GroupBoxDataAlteracaoCusto.Enabled = false;
                lblFiltroCusto.Text = "Filtro de Custo Desativado";
                lblFiltroCusto.ForeColor = Color.Black;
            }

        }
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cmdBuscar.Enabled = false;
                this.Refresh();
                this.Cursor = Cursors.WaitCursor;
                txtTotalItens.Text = "0";
                this.Refresh();
                SP.Parametros.F_CdOperacao = 2;
                SP.Parametros.F_Produto_Descricao = txtDescricao.Text;
                SP.Parametros.F_Produto_Descricao = txtDescricao.Text;
                SP.Parametros.F_FiltrarDataAlteracaoCusto = ChkDataAlteracaoCusto.Checked;
                SP.Parametros.F_DataAlteracaoCustoInicial = DtpDataAlteracaoCustoInicial.Value;
                SP.Parametros.F_DataAlteracaoCustoFinal = DtpDataAlteracaoCustoFinal.Value;
                SP.Parametros.F_CdProduto_List = TXTCdProdutoList.Text;
                SP.Parametros.F_CdProdutoBlueSoft_List = txtCdProdutoBlueSoftList.Text;
                SP.Parametros.F_CdProdutoTarget_List = txtCdProdutoTgtList.Text;
                SP.Parametros.F_CodigoBarra = txtCodigoBarraAssociado.Text;

                if ( CHKAtivo.Checked && !CHKInativo.Checked)
                {
                    SP.Parametros.F_StatusProduto = "1";
                }

                if (!CHKAtivo.Checked && !CHKInativo.Checked)
                {
                    SP.Parametros.F_StatusProduto = "1,0";
                }


                if (!CHKAtivo.Checked && CHKInativo.Checked)
                {
                    SP.Parametros.F_StatusProduto = "0";
                }


                if (CHKAtivo.Checked && CHKInativo.Checked)
                {
                    SP.Parametros.F_StatusProduto = "1,0";
                }

                _fillGridProduto();
                txtTotalItens.Text = dtgProdutoPreco.RowCount.ToString();
                cmdBuscar.Enabled = true;
                this.Cursor = Cursors.Default;
                this.Refresh();
            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                cmdBuscar.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Voids*/
        private void _fillForm()
        {

            SP = new Pag_Net.Bll.SP_ProdutoPrecos(MyConnect);
            
            /*DataGrid Produto*/
            dtgProdutoPreco.AutoGenerateColumns = false;
            //dtgProdutoPreco.ReadOnly = true;
            dtgProdutoPreco.MultiSelect = false;
            dtgProdutoPreco.SelectionMode = DataGridViewSelectionMode.CellSelect;

            for (int i = 0; i <= dtgProdutoPreco.Columns.Count-1; i++)
            {
                dtgProdutoPreco.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dtgProdutoPreco.Columns[i].ReadOnly = true;
                if (i == 8 || i == 9)
                {
                    dtgProdutoPreco.Columns[8].ReadOnly = false;
                }
            }

            ChkDataAlteracaoCusto.Checked = false;
            GroupBoxDataAlteracaoCusto.Enabled = false;
            lblFiltroCusto.ForeColor = Color.Black;
            lblFiltroCusto.Text = "Filtro de Custo Desativado";
            CHKAtivo.Checked = true;
        }
        private void _fillGridProduto()
        {
            dtgProdutoPreco.Rows.Clear();
            int linha = 0;
            DataTable TbProdutoPreco = SP.getDataTable_TbProdutoOperacaoPrecoSelect();
            //SP_ProdutoPreco_TbPreco[] List = SP.getList_TbProdutoOperacaoPrecoSelect();

            foreach (DataRow i in TbProdutoPreco.Rows)
            {
                dtgProdutoPreco.Rows.Add();
                //dtgProdutoPreco[0,i]
                dtgProdutoPreco["TbProduto_CdProduto", linha].Value = Convert.ToInt32(i["TbProduto_CdProduto"].ToString());
                dtgProdutoPreco["TbProduto_CdProdutoBlueSoft", linha].Value = Convert.ToInt32(i["TbProduto_CdProdutoBlueSoft"].ToString());
                dtgProdutoPreco["TbProduto_Descricao", linha].Value = i["TbProduto_Descricao"].ToString();
                dtgProdutoPreco["TbProduto_EmbalagemEstoque", linha].Value = i["TbProduto_EmbalagemEstoque"].ToString();
                dtgProdutoPreco["TbEstoque_Qtde", linha].Value = Convert.ToDouble(i["TbEstoque_Qtde"]);
                dtgProdutoPreco["TbProdutoOperacaoCusto_ValorCustoBrutoEntrada", linha].Value = Convert.ToDouble(i["TbProdutoOperacaoCusto_ValorCustoBrutoEntrada"]);
                //dtgProdutoPreco["DtgMgEntrada",i].Value  = TbProdutoPreco.Rows[i]["DtgMgEntrada"].ToString();
                dtgProdutoPreco["TbProdutoOperacaoCusto_ValorCustoBruto", linha].Value = Convert.ToDouble(i["TbProdutoOperacaoCusto_ValorCustoBruto"]);
                //dtgProdutoPreco["DtgMgMedia",i].Value  = TbProdutoPreco.Rows[i]["DtgMgMedia"].ToString();
                dtgProdutoPreco["TbProdutoOperacaoPreco_ValorPreco", linha].Value = Convert.ToDouble(i["TbProdutoOperacaoPreco_ValorPreco"]);
                dtgProdutoPreco["TbProdutoOperacaoPreco_DataAtualizacaoPreco", linha].Value = Convert.ToDateTime(i["TbProdutoOperacaoPreco_DataAtualizacaoPreco"]);
                dtgProdutoPreco["TbProdutoOperacaoPreco_DataAtualizacaoEstoque", linha].Value = Convert.ToDateTime(i["TbProdutoOperacaoPreco_DataAtualizacaoEstoque"]);
                linha++;
            }
            //    dtgProdutoPreco.DataSource = SP.getDataTable_TbProdutoOperacaoPrecoSelect();
        }
        
    }
}
