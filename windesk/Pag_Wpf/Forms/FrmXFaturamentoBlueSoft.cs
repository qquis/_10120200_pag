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
    public partial class FrmXFaturamentoBlueSoft : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        int NotaFiscalSelecionada = 0;

        public FrmXFaturamentoBlueSoft(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;

            dtgFaturamentoBlueSoftNotasFiscais.AutoGenerateColumns = false;
            dtgFaturamentoBlueSoftNotasFiscais.ReadOnly = true;


            dtgFaturamentoBlueSoft.AutoGenerateColumns = false;
            dtgFaturamentoBlueSoft.ReadOnly = true;
            
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                NotaFiscalSelecionada = 0;
                //DataTable Lista = Pag_Net.Bll.Faturamento.BlueSoft_Select_FVNotasFiscais.List(MyConnect, DtpInicial.Value, DtpFinal.Value);


                DataTable Lista = Pag_Net.CO03.Bll.FaturamentoBlueSoft.RSTSPCO003_Select.dataTable(MyConnect, new Pag_Net.CO03.Models.FaturamentoBlueSoft(DtpInicial.Value, DtpFinal.Value), Pag_Net.CO03.Models.FaturamentoBlueSoft.Reports.Header);
                
                dtgFaturamentoBlueSoftNotasFiscais.DataSource = Lista;
                txtNDocumentosFiscaisEncontrados.Text = string.Format("{0} Notas", Lista.Rows.Count.ToString());


                this.Cursor = Cursors.Default;
            }

            catch ( Exception ex )

            {
                MessageBox.Show(ex.Message);

            }

        }

        private void cmdAtualizarBase_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Confirma atualização da base de vendas Pag com as vendas BLUESOFT?", "Pag", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    cmdAtualizarBase.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    /*Importações de Documentos Fiscais */
                    Pag_Net.Bll.Integration.RedShiftSqlServer.SPC5000TbDocumentosFiscais.Execute(MyConnect, new Pag_Net.Models.SPC5000TbDocumentosFiscais(0, 0, 0, 0, DtpInicial.Value, DtpFinal.Value));

                    /*Importações de Faturamento Modelo Antigo*/
                    Pag_Net.Bll.Faturamento.BlueSoft_Import.Start(MyConnect, DtpInicial.Value, DtpFinal.Value);

                    /*Importações de Faturamento Modelo Novo*/
                    Pag_Net.CO03.Bll.FaturamentoBlue.Export.SqlServer(MyConnect, DtpInicial.Value, DtpFinal.Value);


                    this.Cursor = Cursors.Default;
                    cmdAtualizarBase.Enabled = true;
                    MessageBox.Show("Dados importados com sucesso");
                }
            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                cmdAtualizarBase.Enabled = true;
                MessageBox.Show(ex.Message);

            }
        }

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable Lista = Pag_Net.Bll.Faturamento.BlueSoft_Select_FVNotasFiscais_Itens.List(MyConnect, DtpInicial.Value, DtpFinal.Value, NotaFiscalSelecionada);
                txtNotaFiscalSelecionada.Text = NotaFiscalSelecionada.ToString();
                dtgFaturamentoBlueSoft.DataSource = Lista;
                txtQtdeItens.Text = string.Format("{0} Itens", Lista.Rows.Count.ToString());


                this.Cursor = Cursors.Default;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dtgFaturamentoBlueSoftNotasFiscais_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgFaturamentoBlueSoftNotasFiscais.SelectedRows.Count > 0)
            {
                NotaFiscalSelecionada = Convert.ToInt32(dtgFaturamentoBlueSoftNotasFiscais.SelectedRows[0].Cells[6].Value.ToString());
                
            }           
        }

        private void LocalProgress(object sender, Pag_Net.Models.PagSystemProgressInf e)
        {
     
            LBLInfo.Text = e.MetodoExecute;
            this.Refresh();
        }
    }
}
