using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pag_Net.Bll.F0055_Faturamento_Zanthus;

namespace Pag_Form.forms
{
    public partial class frm_Loja_CupomECF_Processamento : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        WKProcessamento WK;

        public frm_Loja_CupomECF_Processamento(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new WKProcessamento(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdPesquisarCtrl, UserTools.PagButtonsIcons.Localizar);
                UserTools._Screen_ButtonImage(cmdProcessarCtrl, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_ButtonImage(cmdProcessarECF_DATA, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_Form_Format_DataGridView(dtgECFS_VENDA);
                
                chkProcessamentoPag.Checked = true;
                
                chkApenasVendasPendentes.Enabled = true;
                chkApenasVendasPendentes.Checked = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 

        private void cmdPesquisarEcfs_Click(object sender, EventArgs e)
        {
            try 
            {
                ProcessarPesquisarCtrl(false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }
        private void cmdProcessarCtrl_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessarPesquisarCtrl(true);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
  

        private void cmdProcessarData_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_fat_zanthus_sat_ecf_m00ac.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "ECF não Selecionada");
                    return; 
                }

                if (!UserTools._Screen_MessageBox_OkCancel(this, "Confirma atualização da ECF")) return; 
                

                UserTools._Screen_Wait(this, true);
                UserTools._Screen_Wait(this, true);
                this.Refresh();
                this.Refresh();
                this.Refresh();
                WK.Processamento_ECF(Convert.ToInt32(lbl_fat_zanthus_sat_ecf_m00ac.Text), Convert.ToDateTime(lbl_fat_zanthus_data_m00af.Text), chkProcessamentoPag.Checked, chkApenasVendasPendentes.Checked);
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_Wait(this, false);

                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "ECF " + lbl_fat_zanthus_sat_ecf_m00ac.Text + " Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessarPesquisarCtrl(bool processar)
        {
            try
            {
                try
                {
                    var dataDiferenca = dtp_processamentodata_fim.Value - dtp_processamentodata_ini.Value;

                    int vcomDiferenca = chkdiferenca.Checked ? 1 : 0;


                    

                    if (dtp_processamentodata_fim.Value.Date < dtp_processamentodata_ini.Value.Date)
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Período Inválido! Data Inicial maior que a final.");
                        return;
                    }



                    if (dataDiferenca.Days >= 31)
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Período Inválido! Intervalo maior do que 31 dias não permitido.");
                        return;
                    }

                    UserTools._Screen_Wait(this);
                    this.Refresh();
                    dtgECFS_VENDA.DataSource = WK.ProcessamentoECF_Consultar(processar, dtp_processamentodata_ini.Value, dtp_processamentodata_fim.Value, vcomDiferenca);


                    /*
                     * #33910 Alteração em 07/11/2024 - Recpcionar quando o valor é igual a null
                     */

                    if (dtgECFS_VENDA.DataSource != null)
                    {
                        UserTools._Screen_DataBinding_Set(lbl_fat_zanthus_sat_ecf_m00ac, "Text", dtgECFS_VENDA.DataSource, "fat_zanthus_sat_ecf_m00ac");
                        UserTools._Screen_DataBinding_Set(lbl_fat_zanthus_data_m00af, "Text", dtgECFS_VENDA.DataSource, "lbl_fat_zanthus_data_m00af");
                    }
                    UserTools._Screen_Wait(this);

                }
                catch (Exception ex)
                {
                    UserTools._Screen_MessageBox(this, ex);
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


    }
}
