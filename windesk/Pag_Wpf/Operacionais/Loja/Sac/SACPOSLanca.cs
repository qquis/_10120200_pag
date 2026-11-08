using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;
using Pag_Net.Bll.Tables;
using Pag_Net.Bll;
using Pag_Net.Bll.Sac;

namespace Pag_Wpf.Operacionais.Varejo
{
    public partial class SACPOSLanca : Form
    {
        public bllOperacaoSac _BllOperacaoSac;
        public SACPOSLanca(Pag_Net.Models.modelSistemaUsuario _myConnection, TbCuponsPagamentos _tbcupompagamentoselecionado)
        {
            InitializeComponent();
            _BllOperacaoSac = new bllOperacaoSac(_myConnection);
            DtSacPosLancamento.AutoGenerateColumns = false;
            DtSacPosLancamento.AllowUserToDeleteRows = true;
            DtSacPosLancamento.AllowUserToAddRows = true;
            //_BllOperacaoSac.FiltroEcf = new TbECF(19);
            //_BllOperacaoSac.FiltroCupomFiscal = "291262";
            lblCupomFiscal.Text = _tbcupompagamentoselecionado.CupomFiscal.ToString();
            lblECF.Text = _tbcupompagamentoselecionado.Ecf.ToString();
            lblValorTotalPagamento.Text = _tbcupompagamentoselecionado.Valor.ToString("0.00");
            _BllOperacaoSac.NumeroEcf = _tbcupompagamentoselecionado.Ecf.ToString();
            _BllOperacaoSac.NumeroCupomFiscal = _tbcupompagamentoselecionado.CupomFiscal.ToString();
            _BllOperacaoSac.SeqZanthusTransacao = _tbcupompagamentoselecionado.SeqZanthusTransacao.ToString();

           
        }
        private void SACPOSLanca_Load(object sender, EventArgs e)
        {
           try
            {
                cmbAutorizadora.ValueMember = "CdAutorizadorFinanceiro";
                cmbAutorizadora.DisplayMember = "DescricaoAutorizadorFinanceiro";
                cmbAutorizadora.DataSource = _BllOperacaoSac.TbAutorizadoresFinanceiros;
                cmbProdutoFinanceiro.ValueMember = "CdProdutoFinanceiro";
                cmbProdutoFinanceiro.DisplayMember = "DescricaoProdutoFinanceiro";
                cmbProdutoFinanceiro.DataSource = _BllOperacaoSac.TbProdutosFinanceiros;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            // _ColumnValor.HeaderText = "Valor";
            //_ColumnValor.DataPropertyName = "Valor";
            //_ColumnValor.MaxInputLength = 15;
            //_ColumnValor.Width = 100;
        }

        private void cmdEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                _BllOperacaoSac.Insert(TbOperacoesSac.TiposOperacaoSac.PagamentoPos);
                MessageBox.Show("Lançamento Efetuado!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdAdicionaPOS_Click(object sender, EventArgs e)
        {
            try
            {

                _BllOperacaoSac.Autorizador = cmbAutorizadora.SelectedItem;
                _BllOperacaoSac.CartaoReferencia = txtCartaoReferencia.Text;
                _BllOperacaoSac.NumeroCartaoIdentificador = txtNumeroCartaoReferenciaIdentificadorDireito.Text;
                _BllOperacaoSac.NumeroCartaoIdentificadorDireito = txtNumeroCartaoReferenciaIdentificadorDireito.Text;
                _BllOperacaoSac.ProdutoFinanceiro = cmbProdutoFinanceiro.SelectedItem;
                _BllOperacaoSac.CodigoAutorizacao = txtNumeroAutorizacao.Text;

                _BllOperacaoSac.Valor = txtValor.Text;
                

                _BllOperacaoSac.PosAddNewItem();
                DtSacPosLancamento.DataSource = _BllOperacaoSac.TbSitefLogsNaoGravados;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro inclusão de Item POS:" + ex.Message.ToString());
            }
            total();

        }

        private void DtSacPosLancamento_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                if (e.ColumnIndex == 4 && e.RowIndex >= 0)// created column index (delete button)
                {
                    
                    _BllOperacaoSac.PosDelItemCollecion(e.RowIndex);
                    DtSacPosLancamento.DataSource = _BllOperacaoSac.TbSitefLogsNaoGravados;
                    //commit the changes!
                    total();
                }
            }
        }

        private void total()
        {
            lblValorTotal.Text = _BllOperacaoSac.ValorPagamentoPosLancados.ToString();
            
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroCartaoReferenciaIdentificador_TextChanged(object sender, EventArgs e)
        {
            txtCartaoReferencia.Text = txtNumeroCartaoReferenciaIdentificador.Text + "******" + txtNumeroCartaoReferenciaIdentificadorDireito.Text;
        }

        private void txtNumeroCartaoReferenciaIdentificadorDireito_TextChanged(object sender, EventArgs e)
        {
            txtCartaoReferencia.Text = txtNumeroCartaoReferenciaIdentificador.Text + "******" + txtNumeroCartaoReferenciaIdentificadorDireito.Text;
        }


     }
}
