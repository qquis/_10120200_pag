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
    
    public partial class FrmContratoLocacaoRubrica : Form
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoRubricas BLL;
        Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoRubricas ContratoRubricaSelecionada;
        public FrmContratoLocacaoRubrica(modelSistemaUsuario __myConnect, Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoRubricas __contratoRubricaSelecionada)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoRubricas(MyConnect);
                ContratoRubricaSelecionada = __contratoRubricaSelecionada;
                TXTSeqContrato.Text = ContratoRubricaSelecionada.SeqContrato.ToString();
                TXTRubricaDescricao.Text = ContratoRubricaSelecionada.Descricao;
                TXTRubricaValor.Text = ContratoRubricaSelecionada.Valor.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BLL.Parametros.SeqContrato = ContratoRubricaSelecionada.SeqContrato;
                BLL.Parametros.SeqTipoContratoRubrica = ContratoRubricaSelecionada.SeqTipoContratoRubrica;
                BLL.Parametros.Valor = Convert.ToDouble(TXTRubricaValor.Text.ToString());
                BLL.Update();
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Atualização Realizada com Sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }

        }

        private void CmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
