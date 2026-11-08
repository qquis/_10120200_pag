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

namespace Pag_Wpf.Cadastro
{
    public partial class FrmAtivoImobilizadoInformacao : Form
    {
        public modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Cadastros.Imobilizado BLL;
        private int SeqAtivoImobilizado;
        public FrmAtivoImobilizadoInformacao(modelSistemaUsuario __myConnect, int __seqAtivoImobilizado, int __cdTipoInformacao)
        {
            InitializeComponent();
            try
            {
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Cadastros.Imobilizado(MyConnect);
                BLL.Informacao.Parametros.SeqAtivoImobilizado = __seqAtivoImobilizado;
                BLL.Informacao.Parametros.CdTipoInformacao = __cdTipoInformacao;
                BLL.Informacao.Select();
                TXTSeqAtivoImobilizado.Text  = __seqAtivoImobilizado.ToString();

                TXTDescricaoTipoInformacao.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizadoInformacao)BLL.Informacao.ViewData[0]).DescricaoTipoInformacao.ToString();
                TXTAtivoImobilizadoDescricao.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizadoInformacao)BLL.Informacao.ViewData[0]).DescricaoAtivoImobilizado.ToString();
                TXTInformacao.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizadoInformacao)BLL.Informacao.ViewData[0]).Informacao.ToString();
                TXTObservacao.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizadoInformacao)BLL.Informacao.ViewData[0]).Observacao.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BLL.Informacao.Parametros.Informacao = TXTInformacao.Text.ToString();
                BLL.Informacao.Parametros.Observacao = TXTObservacao.Text.ToString();
                BLL.Informacao.Update();
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Informação Atualizada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show(ex.Message);

            }
            
        }
    }
}
