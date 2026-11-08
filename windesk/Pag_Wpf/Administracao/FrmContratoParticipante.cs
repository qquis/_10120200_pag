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

namespace Pag_Wpf.Administracao
{
    public partial class FrmContratoParticipante : Form
    {
        private modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Administrativo.UVWContratoParticipante ContratoParticipante;
        private Pag_Net.Bll.Administrativo.UspContratoParticipante BLL;
        public FrmContratoParticipante(modelSistemaUsuario __myConnect, Pag_Net.Bll.Administrativo.UVWContratoParticipante __contratoParticipante)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            ContratoParticipante = __contratoParticipante;
            BLL = new Pag_Net.Bll.Administrativo.UspContratoParticipante(MyConnect);

            TXTCdParticpante.Text = __contratoParticipante.CdParticipante.ToString();
            TXTContrato.Text = __contratoParticipante.SeqContrato.ToString();
            TXTParticipanteNome.Text = __contratoParticipante.Nome.ToString();
            TXTTipoContratoParticipanteDescricao.Text = __contratoParticipante.TipoContratoPartipanteDescricao.ToString();

            if (__contratoParticipante.SeqContrato != 0)
            {
                Pag_Net.Bll.Administrativo.UspContratos Contrato = new Pag_Net.Bll.Administrativo.UspContratos(MyConnect);
                Contrato.Parametros.SeqContrato = __contratoParticipante.SeqContrato;
                Contrato.Select();
                if (Contrato.ViewData.Count() < 1)
                {
                    throw new Exception("Erro: Contrato nâo identificado!");
                }
                TXTContratoDescricao.Text = ((Pag_Net.Bll.Administrativo.UVWContrato)Contrato.ViewData[0]).Descricao.ToString();
            }

            DefiniParticipante(__contratoParticipante.CdParticipante);

        }

        private void CMDLocalizarParticipante_Click(object sender, EventArgs e)
        {
            try
            {
                Pag_Wpf.Cadastro.FrmLocalizaParticipante frm = new Cadastro.FrmLocalizaParticipante(MyConnect);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DefiniParticipante(frm.CdParticipanteSelecionado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DefiniParticipante(int __cdParticipante)
        {
            try
            {
                if (__cdParticipante != 0)
                {
                    Pag_Net.Bll.Cadastros.UspParticipante Participante = new Pag_Net.Bll.Cadastros.UspParticipante(MyConnect);
                    Participante.Parametros.CdParticipante = __cdParticipante;
                    Participante.Select();
                    TXTCdParticpante.Text = ((Pag_Net.Bll.Cadastros.UVWParticipante)Participante.ViewData[0]).CdParticipante.ToString();
                    TXTParticipanteNome.Text = ((Pag_Net.Bll.Cadastros.UVWParticipante)Participante.ViewData[0]).Nome.ToString();
                    TXTParticipanteDocumento.Text = ((Pag_Net.Bll.Cadastros.UVWParticipante)Participante.ViewData[0]).Documento.ToString();
                    TXTParticipanteDocumentoNumero.Text = ((Pag_Net.Bll.Cadastros.UVWParticipante)Participante.ViewData[0]).Informacao.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BLL.Parametros.SeqContrato = ContratoParticipante.SeqContrato;
                BLL.Parametros.SeqTipoContratoParticipante = ContratoParticipante.SeqTipoContratoParticipante;
                BLL.Parametros.CdParticipante = Convert.ToInt32( TXTCdParticpante.Text.ToString());
                BLL.Update();
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Registro Atualizado Com sucesso!");
                this.Close();

            }

            catch( Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
