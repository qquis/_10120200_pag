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

    public partial class FrmXProduto : Form
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        
        Pag_Net.Bll.SP_Produto SP_PRODUTO;
        Pag_Net.Bll.SP_ProdutoBlueSoftComposicao SP_PRODUTOBLUESOFTCOMPOSICAO;
        Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft SPC0015TBPRODUTOBLUESOFT;
        
        public FrmXProduto(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            dtgProduto.AutoGenerateColumns = false;
            dtgProduto.ReadOnly = true;
            CHKAtivo.Checked = true;
            
            
            SP_PRODUTO = new Pag_Net.Bll.SP_Produto(MyConnect);
            SP_PRODUTO.PagProgress += _LocalProgress;

            SP_PRODUTOBLUESOFTCOMPOSICAO = new Pag_Net.Bll.SP_ProdutoBlueSoftComposicao(MyConnect);
            SP_PRODUTO.PagProgress += _LocalProgress;

            SPC0015TBPRODUTOBLUESOFT = new Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft(MyConnect);
            SPC0015TBPRODUTOBLUESOFT.PagProgress += _LocalProgress;

            _data_list_functions();
            

            LBL_INFO_PROGRESS.Text = "";
        }
        
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LBL_INFO_PROGRESS.Text = "Buscando itens...";
                this.Cursor = Cursors.WaitCursor;

                string statusProduto = "1,0";

                if (CHKAtivo.Checked == true && CHKInativo.Checked == true)
                {
                    statusProduto = "1,0";
                }

                if (CHKAtivo.Checked == true && CHKInativo.Checked == false)
                {
                    statusProduto = "1";
                }

                if (CHKAtivo.Checked == false && CHKInativo.Checked == true)
                {
                    statusProduto = "0";
                }

                if (CHKAtivo.Checked == false && CHKInativo.Checked == false )
                {
                    statusProduto = "1,0";
                }




                SP_PRODUTO.Parametros.F_CdProdutoList = TXTCdProdutoList.Text;
                SP_PRODUTO.Parametros.F_CdProdutoTargetList = txtCdProdutoTgtList.Text;
                SP_PRODUTO.Parametros.F_CdProdutoBlueSoftList = txtCdProdutoBlueSoftList.Text;
                SP_PRODUTO.Parametros.F_Descricao = txtDescricao.Text;
                SP_PRODUTO.Parametros.F_StatusProduto = statusProduto;
                SP_PRODUTO.Parametros.F_CodigoBarraAssociado = txtCodigoBarraAssociado.Text;

                //Pag_Net.Bll.Produto.List List = new Pag_Net.Bll.Produto.List(MyConnect);
                //List.FilterCdProdutoList = TXTCdProdutoList.Text;
                //List.FilterCdProdutoTargettList = txtCdProdutoTgtList.Text;
                //List.FilterCdProdutoBlueSoftList = txtCdProdutoBlueSoftList.Text;
                //List.FilterDescricao = txtDescricao.Text.ToString();
                //List.FilterStatusProduto = statusProduto;
                //List.FilterCodigoBarraAssociado = txtCodigoBarraAssociado.Text;
                //dtgProduto.DataSource = List.Start();
                dtgProduto.DataSource = SP_PRODUTO.getDataTable_TbProdutoSelect();
                this.Cursor = Cursors.Default;
                LBL_INFO_PROGRESS.Text = "";
            }

            catch (Exception ex)
            {
                LBL_INFO_PROGRESS.Text = "Erro encontrato:" + ex.Message.ToString();
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdDetalhe_Click(object sender, EventArgs e)
        {

            try
            {
                
                int _cdproduto = Convert.ToInt32(dtgProduto.SelectedRows[0].Cells[0].Value.ToString());
                string _descricao = dtgProduto.SelectedRows[0].Cells[1].Value.ToString();
                LBL_INFO_PROGRESS.Text = "Detalhe do Item: " + _descricao;
                FrmXProdutoDetalhe frmX = new FrmXProdutoDetalhe(MyConnect, _cdproduto, _descricao);
                frmX.ShowDialog();
                LBL_INFO_PROGRESS.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void dtgProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                int _cdproduto = Convert.ToInt32(dtgProduto.SelectedRows[0].Cells[2].Value.ToString());
                string _descricao = dtgProduto.SelectedRows[0].Cells[4].Value.ToString();
                LBL_INFO_PROGRESS.Text = "Detalhe do Item: " + _descricao;
                FrmXProdutoDetalhe frmX = new FrmXProdutoDetalhe(MyConnect, _cdproduto, _descricao);
                frmX.ShowDialog();
                LBL_INFO_PROGRESS.Text = "";
            }


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                int _cdproduto = Convert.ToInt32(dtgProduto.SelectedRows[0].Cells[2].Value.ToString());
                FrmXRecebimento frmXe = new FrmXRecebimento(MyConnect, _cdproduto);
                frmXe.ShowDialog();
            }
        }
        
        private void cmdAtualizarBase_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (MessageBox.Show("Confirma operação 1?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    LBL_INFO_PROGRESS.Text = "Inicializando Atualização...";
                    this.Cursor = Cursors.WaitCursor;
                    cmdAtualizarBase.Enabled = false;
                    
                    //Execute SPC0015TbProdutoBlueSoft 
                    //PRODUTO: Tabela Base de Produto BLUESOFT TbProdutoBlueSoft (Delete / Insert)
                    Pag_Net.Services.Bll.SqlServer.Produto.Service0001_SP0015_ProdutoBlueSoft(MyConnect);

                    //Execute SP_PRODUTO ------------------------------------------
                    // COMPOSIÇÃO 
                    Pag_Net.Services.Bll.SqlServer.Produto.Service0002_SP_ProdutoBlueSoftComposicao(MyConnect);


                    //Execute SP_PRODUTO ------------------------------------------
                    // CATEGORIAS 
                    // EMBALAGEM
                    // TRIBUTAÇÃO -> Excluido em 09/11
                    Pag_Net.Services.Bll.SqlServer.Produto.Service0005_SP_Produto_All_Old(MyConnect);

                    //TRIBUTACAO BLUESFOT -> SQL SERVER | SPC0110_ProdutoBlueSoftTributacao */
                    Pag_Net.Services.Bll.SqlServer.Produto.Service0003_SPC0110_ProdutoBlueSoft_Tributacao(MyConnect);

                    //TRIBUTACAO BLUESFOT -> SQL SERVER | SPP0015_ZanthusTabRegraICMS 
                    //Tabela Tab_regra_icms*/
                    //Observações: Atualiza a tabela tab_regra_icms com base na tabela OXAN_ADM-TbZanthusTabRegraICMS 
                    Pag_Net.Services.Bll.SqlServer.Produto.Service0009_SPP0015_ProdutoTributacaoZanthus(MyConnect);

                    //TRIBUTACAO BLUESFOT -> SQL SERVER | SPC0111_ProdutoBlueSoftTributacaoObservacoes*/
                    //Pag_Net.SPC0111.Bll.Migration.FromRedShift.ToSqlServer(MyConnect);
                    this.Refresh();


                    MessageBox.Show("Importação realizada com sucesso!");

                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdAtualizarBase_ZanthusTributacao_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma operação 2?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {


                    //TRIBUTACAO BLUESFOT -> SQL SERVER | SPP0015_ZanthusTabRegraICMS 
                    //Tabela Tab_regra_icms*/
                    //Observações: Atualiza a tabela tab_regra_icms com base na tabela OXAN_ADM-TbZanthusTabRegraICMS 
                    this.Cursor = Cursors.WaitCursor;
                    this.Refresh();
                    Pag_Net.Services.Bll.SqlServer.Produto.Service0009_SPP0015_ProdutoTributacaoZanthus(MyConnect);
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("Dados Atualizados com sucesso!");

                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdred_to_post_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma atualização RedShift - PostGre", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    _Screen_wait(cmdred_to_post, true);
                    _Services_exec(dtg_RedShift_Postgre);
                    _Screen_wait(cmdred_to_post, false);
                    MessageBox.Show("Atualizações selecionadas realizadas com sucesso!");
                    
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdpost_to_sql_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma atualização Post -> SQL", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    _Screen_wait(cmdred_to_post, true);
                    _Services_exec(dtg_Postgre_sqlserver);
                    _Screen_wait(cmdred_to_post, false);
                    MessageBox.Show("Atualizações selecionadas realizadas com sucesso!");

                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }

        }


        private void cmdProcessamentoGeral_Produto_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma atualização Post -> SQL", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    _Screen_wait(cmdred_to_post, true);
                    _Services_exec(dtg_processamento_geral_produto);
                    _Screen_wait(cmdred_to_post, false);
                    MessageBox.Show("Atualizações selecionadas realizadas com sucesso!");

                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void _Services_exec(DataGridView _mydt)
        {
            try
            {
                if (MessageBox.Show("Confirma atualização RedShift - PostGre", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool atualizacaoparcial = true;
                    if (chkAtualizacaoParcial.Checked == false)
                        atualizacaoparcial = false;

                    for (int li = 0; li <= _mydt.Rows.Count - 1; li++)
                    {
                        DataGridViewCheckBoxCell Chk = new DataGridViewCheckBoxCell();
                        Chk = (DataGridViewCheckBoxCell)_mydt.Rows[li].Cells[0];
                        if (Convert.ToBoolean(Chk.Value) == true)
                        {
                            Pag_Net.Services.Bll.Postgre.Procedimentos.Execute(MyConnect, (Pag_Net.Services.Models.sistema_nucleo_procedimentos)_mydt.Rows[li].DataBoundItem, atualizacaoparcial);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        
        }
        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                cmd.Enabled = false;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                cmd.Enabled = true;
                this.Refresh();
            }
        }
        private void _data_list_functions()
        {
            try
            {
                dtg_RedShift_Postgre.AutoGenerateColumns = false;
                dtg_Postgre_sqlserver.AutoGenerateColumns = false;
                dtg_processamento_geral_produto.AutoGenerateColumns = false;
                dtg_RedShift_Postgre.DataSource = Pag_Net.Services.Bll.Postgre.Tab.List(MyConnect, 3);
                dtg_Postgre_sqlserver.DataSource = Pag_Net.Services.Bll.Postgre.Tab.List(MyConnect, 7);
                dtg_processamento_geral_produto.DataSource = Pag_Net.Services.Bll.Postgre.Tab.List(MyConnect, 8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _LocalProgress(object sender, Pag_Net.Models.PagSystemProgressInf e)
        {
            PrgPagAtualizaProduto.Minimum = e.ValorInicial;
            PrgPagAtualizaProduto.Maximum = e.ValorFinal;
            PrgPagAtualizaProduto.Value = e.ValorEtapa;
            LBL_INFO_PROGRESS.Text = e.MetodoExecute;
            this.Refresh();
        }




    }
}
