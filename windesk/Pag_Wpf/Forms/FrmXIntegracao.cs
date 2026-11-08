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
    public partial class FrmXIntegracao : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public FrmXIntegracao(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            DtgIntegracoes.AutoGenerateColumns = false;
            Listar();
            //DtgIntegracoes.ReadOnly = true;
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void cmdAtualizarBase_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Listar()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Pag_Net.Bll.SP_Integracao SP = new Pag_Net.Bll.SP_Integracao(MyConnect);
                DtgIntegracoes.DataSource = SP.getDataTable_TbIntegracaoSelect();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }
        private void Atualizar()
        {
            try
            {
                
                if (MessageBox.Show("Confirma atualização das tabelas selecionadas?","PAG",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) 
                {
                    return;
                }
                
                this.Cursor = Cursors.WaitCursor;
                cmdAtualizarBase.Enabled = false;
                cmdSelecionarTodos.Enabled = false;
                this.Refresh();
                this.Refresh();
                this.Refresh();
                this.Refresh();

                for (int li = 0; li <= DtgIntegracoes.Rows.Count -1 ; li++)
                {
                    DataGridViewCheckBoxCell Chk = new DataGridViewCheckBoxCell();
                    Chk = (DataGridViewCheckBoxCell)DtgIntegracoes.Rows[li].Cells[2];
                    if (Convert.ToBoolean(Chk.Value) == true)
                    {
                        if (Convert.ToInt32(DtgIntegracoes.Rows[li].Cells[1].Value.ToString()) == 1) //Importação Recebimento. 
                        {
                            LBL_INFO_PROGRESS.Text = "Atualização da Base de Notas Fiscais de Entrada";
                            Pag_Net.Bll.Recebimentos CLSRecebimento = new Pag_Net.Bll.Recebimentos(MyConnect);
                            CLSRecebimento.PagProgress += LocalProgress;
                            CLSRecebimento.F_DtRecebimentoInicial = Convert.ToDateTime(DateTime.Now.AddDays(-30).ToShortDateString());
                            CLSRecebimento.F_DtRecebimentoFinal = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            CLSRecebimento.Import();
                            LBL_INFO_PROGRESS.Text = "";
                        }
                        if (Convert.ToInt32(DtgIntegracoes.Rows[li].Cells[1].Value.ToString()) == 2) //Importação de Produtos
                        {

                            Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft ObjSPC0015TbProdutoBlueSoft = new Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft(MyConnect);
                            LBL_INFO_PROGRESS.Text = "Base Produto via Classe SPC0015TbProdutoBlueSoft";
                            ObjSPC0015TbProdutoBlueSoft.PagProgress += LocalProgress;
                            this.Refresh();
                            ObjSPC0015TbProdutoBlueSoft.Execute();
                            this.Refresh();

                            Pag_Net.Bll.SP_Produto CLSProduto = new Pag_Net.Bll.SP_Produto(MyConnect);
                            LBL_INFO_PROGRESS.Text = "Base Produto (dados restantes) via Classe Execute_Import_RedShiftBlueSoft_Produtos";
                            this.Refresh();
                            this.Refresh();
                            CLSProduto.PagProgress += LocalProgress;
                            CLSProduto.Execute_Import_RedShiftBlueSoft_Produtos();
                            this.Refresh();

                            Pag_Net.Bll.SP_ProdutoBlueSoftComposicao SP_PRODUTOBLUESOFTCOMPOSICAO = new Pag_Net.Bll.SP_ProdutoBlueSoftComposicao(MyConnect);
                            LBL_INFO_PROGRESS.Text = "Base Composição via SP_ProdutoBlueSoftComposicao";
                            this.Refresh();
                            this.Refresh();

                            SP_PRODUTOBLUESOFTCOMPOSICAO.PagProgress += LocalProgress;
                            this.Refresh();
                            SP_PRODUTOBLUESOFTCOMPOSICAO.TbProdutoBlueSoftComposicao_Import();
                            this.Refresh();

                        }

                        if (Convert.ToInt32(DtgIntegracoes.Rows[li].Cells[1].Value.ToString()) == 3) //Importação de Participantes
                        {
                            LBL_INFO_PROGRESS.Text = "Atualização da Base de Participantes";
                            this.Refresh();
                            this.Refresh();
                            Pag_Net.Bll.Participante.BlueSoft_Import.Start(MyConnect);
                            LBL_INFO_PROGRESS.Text = "";
                            this.Refresh();
                        }

                        if (Convert.ToInt32(DtgIntegracoes.Rows[li].Cells[1].Value.ToString()) == 4) //Importação de Participantes
                        {
                            LBL_INFO_PROGRESS.Text = "Atualização da Base de Faturamento";
                            this.Refresh();
                            this.Refresh();
                            Pag_Net.Bll.Faturamento.BlueSoft_Import.Start(MyConnect, Convert.ToDateTime(DateTime.Now.AddDays(-30).ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                            this.Refresh();
                        }
                        DtgIntegracoes.Rows[li].Cells[2].Value = 0;
                    }
                }
                cmdAtualizarBase.Enabled = true;
                cmdSelecionarTodos.Enabled = false;
                this.Cursor = Cursors.Default;

                LBL_INFO_PROGRESS.Text = "";
                PrgPagAtualizaProduto.Minimum = 0;
                PrgPagAtualizaProduto.Maximum = 0;
                PrgPagAtualizaProduto.Value = 0;

                this.Refresh();

                MessageBox.Show("Atualizações realizadas com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSelecionarTodos_Click(object sender, EventArgs e)
        {
            for (int li = 0; li <= DtgIntegracoes.Rows.Count - 1; li++)
            {
                DtgIntegracoes.Rows[li].Cells[2].Value = 1;
            }

        }

        private void LocalProgress(object sender, Pag_Net.Models.PagSystemProgressInf e)
        {
            this.Refresh();
            PrgPagAtualizaProduto.Minimum = e.ValorInicial;
            PrgPagAtualizaProduto.Maximum = e.ValorFinal;
            PrgPagAtualizaProduto.Value = e.ValorEtapa;
            LBL_INFO_PROGRESS.Text = e.MetodoExecute;
            this.Refresh();
        }
    }
}
