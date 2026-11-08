using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_DR_Processamento : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.rules.CentroDr_Processamento BLLCentroDrProcessamento;
        public frm_DR_Processamento(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            BLLCentroDrProcessamento = new Pag_Net.rules.CentroDr_Processamento(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                cmbCompetencia.TextChanged += new EventHandler(_Screen_changed);
                cmbCompetencia.ValueMember = "competencia_cd";
                cmbCompetencia.DisplayMember = "competencia_descricao";
                cmdefetivar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
                cmbCompetencia.DataSource = BLLCentroDrProcessamento.Competencias();
                cmbCompetencia.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }
        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                cmd.Enabled = false;
                _Screen_wait(ON);
            }
            else
            {
                _Screen_wait(ON);
                cmd.Enabled = true;
            }
        }
        private void _Screen_wait(bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                this.Refresh();
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "ComboBox")
                {
                    switch (((ComboBox)sender).Name)
                    {
                        case "cmbCompetencia":
                            BLLCentroDrProcessamento.CompetenciaCD = Convert.ToInt32(cmbCompetencia.SelectedValue);
                            break;
                    }
                }
            }
            catch (Exception ErroMessage)
            {
                MessageBox.Show(ErroMessage.Message);
            }
        }

        private void cmdefetivar_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdefetivar, true);
                BLLCentroDrProcessamento.Execute();
                _Screen_wait(cmdefetivar, false);
            }
            catch (Exception EX)
            {
                _Screen_wait(cmdefetivar, false);
                MessageBox.Show(EX.Message);
            }
        }
    }
}


