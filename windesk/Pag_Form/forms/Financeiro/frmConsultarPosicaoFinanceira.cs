using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Financeiro
{
    public partial class frmConsultarPosicaoFinanceira : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        Pag_Net.src.F0080_Financeiro._index F0080;

        public frmConsultarPosicaoFinanceira(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {

                F0080 = new Pag_Net.src.F0080_Financeiro._index(MyConnect);


                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_ButtonImage(cmdConsultarDuplicata, UserTools.PagButtonsIcons.Detalhe);

                UserTools._Screen_Form_Format_DataGridView(dtgFinanceiroComposicao);

                cmbCompetencia.Text = "0";

                dtp_autpgto_dataemissao_ini.DataBindings.Add("Enabled", chk_filtra_dataemissao, "Checked");
                dtp_autpgto_dataemissao_fim.DataBindings.Add("Enabled", chk_filtra_dataemissao, "Checked");

                dtp_autpgto_datapagamento_ini.DataBindings.Add("Enabled", chk_filtra_datapagamento, "Checked");
                dtp_autpgto_datapagamento_fim.DataBindings.Add("Enabled", chk_filtra_datapagamento, "Checked");

                dtp_autpgto_datavencimento_ini.DataBindings.Add("Enabled", chk_filtra_datavencimento, "Checked");
                dtp_autpgto_datavencimento_fim.DataBindings.Add("Enabled", chk_filtra_datavencimento, "Checked");


                chk_filtra_dataemissao.Checked = true;

                dtp_autpgto_dataemissao_ini.Value = DateTime.Now.AddDays((-1 * DateTime.Now.Day)+1);

                chk_filtra_datapagamento.Checked = false;
                chk_filtra_datavencimento.Checked = false;

                cmbTipoConsulta.DisplayMember = "descricao";
                cmbTipoConsulta.ValueMember = "tipoconsulta_cd";
                cmbTipoConsulta.DataSource = F0080.TipoConsulta;

                optReceber.DataBindings.Add("Enabled", chktipoduplicata, "Checked");
                optPagar.DataBindings.Add("Enabled", chktipoduplicata, "Checked");

                chktipoduplicata.Checked = false;

                F0080.PropertyChanged += new PropertyChangedEventHandler(dtgBinding);
                screen_FormatarConsulta();

            }
            catch (Exception ex)
            {
                MessageBox.Show("FRM DISTRIBUIÇÃO | Load \n " + ex.Message);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {


                F0080.Filtro.filtra_datapagamento = chk_filtra_datapagamento.Checked;
                F0080.Filtro.autpgto_datapagamento_ini = dtp_autpgto_datapagamento_ini.Value;
                F0080.Filtro.autpgto_datapagamento_fim = dtp_autpgto_datapagamento_fim.Value;

                F0080.Filtro.filtra_dataemissao = chk_filtra_dataemissao.Checked;
                F0080.Filtro.autpgto_dataemissao_ini = dtp_autpgto_dataemissao_ini.Value;
                F0080.Filtro.autpgto_dataemissao_fim = dtp_autpgto_dataemissao_fim.Value;

                F0080.Filtro.filtra_datavencimento = chk_filtra_datavencimento.Checked;
                F0080.Filtro.autpgto_datavencimento_ini = dtp_autpgto_datavencimento_ini.Value;
                F0080.Filtro.autpgto_datavencimento_fim = dtp_autpgto_datavencimento_fim.Value;
                F0080.Filtro.TipoConsulta_Cd = Convert.ToInt32(cmbTipoConsulta.SelectedValue);

                F0080.Filtro.autpgto_tipo = "";
                if (chktipoduplicata.Checked)
                {
                    F0080.Filtro.autpgto_tipo = optReceber.Checked ? "R" : "P";
                }


                UserTools._Screen_Wait(this);
                F0080.ConsultaPosicaoFinanceira();
                UserTools._Screen_Wait(this);

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void dtgBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                
                dtgFinanceiroComposicao.DataSource = F0080.dbList_PosicaoFinanceira.List;

                if (cmbTipoConsulta.SelectedValue.ToString() == "0")
                {
                    UserTools._Screen_DataBinding_Set(lblNumeroDuplicataConsultar, F0080.dbList_PosicaoFinanceira.List, "autpgto_seq_pk");
                }


            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipoConsulta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            screen_FormatarConsulta();
        }


        private void screen_FormatarConsulta()
        {
            dtgFinanceiroComposicao.DataSource = null;
            
            lblNumeroDuplicataLabel.Visible = false;
            lblNumeroDuplicataConsultar.Visible = false;
            cmdConsultarDuplicata.Visible = false;
            if (cmbTipoConsulta.SelectedValue.ToString() == "0")
            {
                lblNumeroDuplicataLabel.Visible = true;
                
                cmdConsultarDuplicata.Visible = true;

                lblNumeroDuplicataConsultar.Visible = true;
                lblNumeroDuplicataConsultar.DataBindings.Clear();
                lblNumeroDuplicataConsultar.Text = "";
            }

        }

        private void cmdConsultarDuplicata_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblNumeroDuplicataConsultar.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Informe o Número da Duplicata");
                    return;
                }

                UserTools._Screen_Wait(this);
                Financeiro.frmConsultarDuplicata _frmConsultarDuplicata = new frmConsultarDuplicata(MyConnect, Convert.ToInt32(lblNumeroDuplicataConsultar.Text));
                UserTools._Screen_Wait(this);

                _frmConsultarDuplicata.ShowDialog();
                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

    }
}
