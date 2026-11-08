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
    public partial class FrmLocalizaParticipante : Form
    {
        public int CdParticipanteSelecionado;
        private Pag_Net.Bll.Cadastros.UspParticipante BLL;
        private modelSistemaUsuario MyConnect;
        public FrmLocalizaParticipante(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Cadastros.UspParticipante(MyConnect);
            DTGWFLocalizaParticipante.AutoGenerateColumns = false;
            DTGWFLocalizaParticipante.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void CmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDSeleciona_Click(object sender, EventArgs e)
        {
            try
            {
                this.CdParticipanteSelecionado = Convert.ToInt32(DTGWFLocalizaParticipante[0, DTGWFLocalizaParticipante.SelectedRows[0].Index].Value.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BLL.Select();
                DTGWFLocalizaParticipante.DataSource = BLL.ViewData;
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTNome_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLL.Parametros.Nome = TXTNome.Text.ToString().TrimEnd(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTDocumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLL.Parametros.Documento = TXTDocumento.Text.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
