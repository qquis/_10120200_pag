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




namespace Pag_Wpf.Cadastros
{
    public partial class FrmParticipanteIncluir : Form
    {
        public Pag_Net.Bll.Cadastros.UspParticipante BLL;
        public FrmParticipanteIncluir(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Cadastros.UspParticipante(__myConnect);
            LBLDocumento.Text = "CNPJ/CPF";
            LblDataInicio.Text = "Data Registro";
            ChkDataNascimentoInicioAtividade.Checked = true;
            optModalidadeJuridica.Checked = true;
            

        }

        private void optModalidadeJuridica_CheckedChanged(object sender, EventArgs e)
        {
            
            optMasculino.Checked = true;
            grpSexo.Enabled = false;
        }

        private void optModalidadeFisica_CheckedChanged(object sender, EventArgs e)
        {
            
            grpSexo.Enabled = true;
        }

        private void cmdEfetiva_Click(object sender, EventArgs e)
        {
            // Pag_Net.Bll.Cadastros.UspParticipante x = new Pag_Net.Bll.Cadastros.UspParticipante(MyConnect);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BLL.Parametros.Nome = TXTNome.Text.ToString();
                BLL.Parametros.DataNascimento = DTPDataDeNascimento.Value.Date;
                if (optMasculino.Checked)
                {
                    BLL.Parametros.Sexo = "M";
                }
                else
                {
                    BLL.Parametros.Sexo = "F";
                }
                if (optModalidadeFisica.Checked)
                {
                    BLL.Parametros.CdTipoDocumento = "DOCTIPOCPF";
                }
                else
                {
                    BLL.Parametros.CdTipoDocumento = "DOCTIPOCNPJ";
                }
                BLL.Parametros.Documento = txtDocumento.Text.ToString();
                BLL.Insert();
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Participante: " + BLL.Parametros.Nome + " Incluído com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                {
                    Cursor.Current = Cursors.Arrow;
                    this.Close();
                }
                else
                {
                    TXTNome.Text = "";
                    txtDocumento.Text = "";
                }
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            LBLDocumento.Text = "CNPJ/CPF";

            if (txtDocumento.Text.Trim().Length == 14)
            {
                optModalidadeJuridica.Checked = true;
                optModalidadeJuridica.ForeColor = Color.Red;
                optModalidadeFisica.ForeColor = Color.Black;
                LBLDocumento.Text = "Número - CNPJ";
                LblDataInicio.Text = "Inicio das Atividades";
            }

            if (txtDocumento.Text.Trim().Length == 11)
            {
                optModalidadeFisica.Checked = true;
                optModalidadeFisica.ForeColor = Color.Red;
                optModalidadeJuridica.ForeColor = Color.Black;
                LBLDocumento.Text = "Número - CPF";
                LblDataInicio.Text = "Data de Nascimento";
            }


        }

        private void ChkDataNascimentoInicioAtividade_Click(object sender, EventArgs e)
        {
            if (ChkDataNascimentoInicioAtividade.Checked)
            {
                DTPDataDeNascimento.Enabled = true;
                BLL.Parametros.DataNascimentoInformacao = false;
            }
            else
            {
                DTPDataDeNascimento.Enabled = false;
                BLL.Parametros.DataNascimentoInformacao = false;
            }
        }
        private void CmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
