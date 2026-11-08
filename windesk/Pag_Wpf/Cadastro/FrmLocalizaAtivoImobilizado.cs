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
    public partial class FrmLocalizaAtivoImobilizado : Form
    {
        public int SeqAtivoImobilizadoSelecionado;
        private modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Cadastros.UspAtivoImobilizado BLL;
        public FrmLocalizaAtivoImobilizado(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Cadastros.UspAtivoImobilizado(MyConnect);
            DTGWFLocalizaAtivoImobilizado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGWFLocalizaAtivoImobilizado.AutoGenerateColumns = false;

        }

        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            BLL.Select();
            DTGWFLocalizaAtivoImobilizado.DataSource = BLL.ViewData;
        }

        private void TXTDescricaoAtivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TXTDescricaoAtivo.Text != "")
                {
                    BLL.Parametros.Descricao = TXTDescricaoAtivo.Text.ToString();
                }
                else
                {
                    BLL.Parametros.Descricao = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDSeleciona_Click(object sender, EventArgs e)
        {
            try
            {
                this.SeqAtivoImobilizadoSelecionado = Convert.ToInt32(DTGWFLocalizaAtivoImobilizado[0, DTGWFLocalizaAtivoImobilizado.SelectedRows[0].Index].Value.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void CHKSelecionaAtivoTipoComponente_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKSelecionaAtivoTipoComponente.Checked)
            {
                BLL.Parametros.SelecionaTipoComponentes = true;

            }
            else
            {
                BLL.Parametros.SelecionaTipoComponentes = false;
            }
        }


    }
}
