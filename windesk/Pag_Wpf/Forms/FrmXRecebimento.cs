using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;
using Pag_Net.Bll;

namespace Pag_Wpf.Forms
{
    public partial class FrmXRecebimento : Form
    {
        modelSistemaUsuario MyConnect;

        Pag_Net.Bll.Recebimentos _BLL_Recebimentos;

        public FrmXRecebimento(Pag_Net.Models.modelSistemaUsuario _MYCONNECT)
        {
            InitializeComponent();
            FormFill(_MYCONNECT, 0);

            Cmd_PARAMETRO_024_CdImport.Enabled = false;

            if (Pag_Net.Bll.Util.GetValueParametro(_MYCONNECT, "Cmd_PARAMETRO_024_CdImport", "m2500") == "1")
            {
                Cmd_PARAMETRO_024_CdImport.Enabled = true;
            }
            _BLL_Recebimentos.PagProgress += LocalProgress;


        }

        public FrmXRecebimento(Pag_Net.Models.modelSistemaUsuario _MYCONNECT, int _CDPRODUTOBLUESFOT)
        {
            InitializeComponent();
            FormFill(_MYCONNECT, _CDPRODUTOBLUESFOT);
            _BLL_Recebimentos.PagProgress += LocalProgress;
        }

        private void FormFill(Pag_Net.Models.modelSistemaUsuario _MYCONNECT, int _CDPRODUTOBLUESFOT)
        {
            MyConnect = _MYCONNECT;
            dtgProduto.AutoGenerateColumns = false;
            dtgProduto.ReadOnly = true;
            _BLL_Recebimentos = new Pag_Net.Bll.Recebimentos(MyConnect);
            if (_CDPRODUTOBLUESFOT > 0)
            {
                txtCdProdutoTgt.Text = _CDPRODUTOBLUESFOT.ToString();
                Fill();
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Fill();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                this.Cursor = Cursors.Default;
                cmdBuscar.Enabled = true;
            }
        }

        private void Fill()
        {
            try
            {
                cmdBuscar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                _BLL_Recebimentos.F_DtRecebimentoInicial = DtpInicial.Value;
                _BLL_Recebimentos.F_DtRecebimentoFinal = DtpFinal.Value;
                _BLL_Recebimentos.F_CdProdutoBlueSoft_List = txtCdProdutoTgt.Text.ToString();
                _BLL_Recebimentos.F_CdProduto_List = txtCdProdutoTgt.Text.ToString();
                _BLL_Recebimentos.F_Descricao = txtDescricao.Text;
                dtgProduto.DataSource = _BLL_Recebimentos.GetDataTable();
                this.Cursor = Cursors.Default;
                cmdBuscar.Enabled = true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                this.Cursor = Cursors.Default;
                cmdBuscar.Enabled = true;
            }

        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cmd_PARAMETRO_024_CdImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma atualização dos dados?", "PAG", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Cmd_PARAMETRO_024_CdImport.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    this.Refresh();
                    this.Refresh();
                    _BLL_Recebimentos.F_DtRecebimentoInicial = DtpInicial.Value;
                    _BLL_Recebimentos.F_DtRecebimentoFinal = DtpFinal.Value;
                    _BLL_Recebimentos.Import();
                    this.Cursor = Cursors.Default;
                    Cmd_PARAMETRO_024_CdImport.Enabled = true;
                    this.Refresh();
                    this.Refresh();
                    MessageBox.Show("Atualização realizada com sucesso!");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                this.Cursor = Cursors.Default;
                Cmd_PARAMETRO_024_CdImport.Enabled = true;
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
