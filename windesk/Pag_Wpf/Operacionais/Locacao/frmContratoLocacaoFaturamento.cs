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

namespace Pag_Wpf.Operacionais.Locacao
{
    public partial class frmContratoLocacaoFaturamento : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoFaturamento BLL;
        Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao ContratoLocacaoSelecionado;
        Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFaturamento ContratoLocacaoFaturamentoSelecionado;
        

        public frmContratoLocacaoFaturamento(Pag_Net.Models.modelSistemaUsuario __myConnect, Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao __contratoLocacao,Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFaturamento __contratoLocacaoFaturamento )
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoFaturamento(MyConnect);
                
                ContratoLocacaoSelecionado = __contratoLocacao;
                ContratoLocacaoFaturamentoSelecionado = __contratoLocacaoFaturamento;
                TXTSeqContrato.Text = ContratoLocacaoSelecionado.SeqContrato.ToString();
                DTPDataInicial.Value = ContratoLocacaoSelecionado.DataInicio;

                Pag_Net.Bll.Financeiro.Titulos.USPTituloEspecie TituloEspecieBLL = new Pag_Net.Bll.Financeiro.Titulos.USPTituloEspecie(MyConnect);
                TituloEspecieBLL.Select();
                CMBTituloEspecie.ValueMember = "CdTituloEspecie";
                CMBTituloEspecie.DisplayMember = "Descricao";
                CMBTituloEspecie.DataSource = TituloEspecieBLL.ViewData;


                if (ContratoLocacaoFaturamentoSelecionado != null)
                {
                    FillContratoLocacalFaturamento();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillContratoLocacalFaturamento()
        {
            TXTSeqContratoLocacaoFaturamento.Text = ContratoLocacaoFaturamentoSelecionado.ToString();
        }

        private void CmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Parametros.SeqContrato = ContratoLocacaoSelecionado.SeqContrato;
                BLL.Parametros.DataInicial = DTPDataInicial.Value;
                BLL.Parametros.NumeroParcelas = Convert.ToInt32(TXTNumeroParcelas.Text);
                BLL.Parametros.DiaVencimento = Convert.ToInt32(TXTDiaVencimento.Text.ToString());
                BLL.Parametros.DataInicial = DTPDataInicial.Value;
                this.Cursor = Cursors.WaitCursor;
                if (ContratoLocacaoFaturamentoSelecionado == null)
                {
                    BLL.Insert();
                }
                else
                {
                    BLL.Update();
                }
                MessageBox.Show("Atualização concluída com sucesso!");
                this.Cursor = Cursors.Arrow;
            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void DTPDataInicial_ValueChanged(object sender, EventArgs e)
        {
            TXTDiaVencimento.Text = DTPDataInicial.Value.Day.ToString();
        }

        private void TXTNumeroParcelas_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTDiaVencimento_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTSeqContratoLocacaoFaturamento_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTSeqContrato_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
