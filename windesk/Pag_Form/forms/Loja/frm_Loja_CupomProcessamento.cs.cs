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
    public partial class frm_Loja_CupomProcessamento : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0105_Zanthus.Wk WKZanthus;
        Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Zanthus WKFaturamentoZanthus;
        public frm_Loja_CupomProcessamento(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WKFaturamentoZanthus = new Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Zanthus(MyConnect);
            WKZanthus = new Pag_Net.Bll.F0105_Zanthus.Wk(MyConnect);
            dtpdata_movimento.Value = DateTime.Now;
            lblAMBIENTE.Text = MyConnect.User_environment.ToString();

            chkSQLSERVER_REPROCESSA_STATUS.DataBindings.Add("Enabled", chkSQLSERVER, "Checked");
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdefetiva_Click(object sender, EventArgs e)
        {
            try
            {


                if (MessageBox.Show("ATENÇÃO: Não executar este comando com o PagServiceJS / JOB SQL SERVER ATIVO. Deseja continuar?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No )
                {
                    return;
                }


                if (txtecf.Text == "")
                {
                    txtecf.Text = "0";
                }

                int _ECF = Convert.ToInt32(txtecf.Text);
                lblinfo.Text = "";
                this.Refresh();
                if (chkSQLSERVER.Checked)
                {
                    lblinfo.Text = "Processando SQL SERVER -> POSTGRE";
                    _Screen_wait(cmdefetiva, true);
                    WKZanthus.Exportar(new Pag_Net.Bll.F0105_Zanthus.Zanthus_Processamento(dtpdata_movimento.Value, _ECF, 0, chkSQLSERVER_REPROCESSA_STATUS.Checked));
                    lblinfo.Text = "Processamento SQL SERVER: OK | ";
                    _Screen_wait(cmdefetiva, false);
                }
                this.Refresh();
                if (chkPostGreFaturamento.Checked)
                {
                    _Screen_wait(cmdefetiva, true);
                    WKFaturamentoZanthus.ProcessaCupom(new Pag_Net.Bll.F0055_Faturamento_Zanthus.Faturamento_Processamento(dtpdata_movimento.Value, _ECF, 0));
                    lblinfo.Text += lblinfo.Text + " | Processando dados na base PostGre";
                    _Screen_wait(cmdefetiva, false);
                }
                this.Refresh();
                lblinfo.Text = "CONCLUÍDO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    }
}
