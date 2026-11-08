using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Sistema
{
    public partial class frm_Sistema_Batchs_Manager : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F9030_sistemabatch._index indexSistemaBatch;

        public frm_Sistema_Batchs_Manager(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void _Screen_load()
        {
            try
            {
                indexSistemaBatch = new Pag_Net.src.F9030_sistemabatch._index(MyConnect);
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultarBatchService, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmddetalhe_batchs, UserTools.PagButtonsIcons.SetaDupla_Direita);
                UserTools._Screen_ButtonImage(cmdSisBatchRUN_Alterar_Status, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdSisBatchRUN_Gerar, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdConsultarLogs, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdintegracaotipoinfo_vinculada, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdBatchs, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_Form_Format_DataGridView(dtgSistemaBatchService);
                UserTools._Screen_Form_Format_DataGridView(dtgSistemaBatchServiceShedule);
                UserTools._Screen_Form_Format_DataGridView(dtgsistema_batch);
                UserTools._Screen_Form_Format_DataGridView(dtgSistemaBatchRUN);


                dtgSistemaBatchRUN.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dtgSistemaBatchRUN_complete);
              
                indexSistemaBatch.report.PropertyChanged += DtGridMetaBinding;

            }
            catch (Exception ex)
            {
                MessageBox.Show("FrmForcaVendaMeta | Load \n " + ex.Message);
            }
        }



        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);


                int filter_sis_batch_service_cd = 0;
                if (txtfilter_sis_batch_service_cd.Text != "")
                    filter_sis_batch_service_cd = Convert.ToInt32(txtfilter_sis_batch_service_cd.Text);

                indexSistemaBatch.report.ConsultarBatchService(filter_sis_batch_service_cd);
                listruns(0, 0);
                //__Consultar_Detalhe();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void __Consultar_Detalhe()
        {
            try
            {
                UserTools._Screen_Wait(this);
                int sis_batch_service_cd = 0; 
                if (lbl_sis_batch_service_cd.Text != "")
                {
                    sis_batch_service_cd = Convert.ToInt32(lbl_sis_batch_service_cd.Text);
                }

                indexSistemaBatch.report.ConsultarBatchServiceShedules(sis_batch_service_cd);
                indexSistemaBatch.report.ConsultarBatchTimes(sis_batch_service_cd);

                
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        public void DtGridMetaBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                if (e.PropertyName == "dbList_Sistema_Batch_Service")
                {
                    dtgSistemaBatchService.DataSource = indexSistemaBatch.report.dbList_Sistema_Batch_Service.List;
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_service_cd, indexSistemaBatch.report.dbList_Sistema_Batch_Service.List, "sis_batch_service_cd");
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_service_descricao, indexSistemaBatch.report.dbList_Sistema_Batch_Service.List, "sis_batch_service_descricao");
                }

                if (e.PropertyName == "dbList_Sistema_Batch_Service_Shedule")
                {
                    dtgSistemaBatchServiceShedule.DataSource = indexSistemaBatch.report.dbList_Sistema_Batch_Service_Shedule.List;
                }
                if (e.PropertyName == "dbList_Sistema_BatchTimes")
                {
                    dtgsistema_batch.DataSource = indexSistemaBatch.report.dbList_Sistema_BatchTimes.List;
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_cd, indexSistemaBatch.report.dbList_Sistema_BatchTimes.List, "sis_batch_cd");
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_time_seq, indexSistemaBatch.report.dbList_Sistema_BatchTimes.List, "sis_batch_time_seq");
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_descricao, indexSistemaBatch.report.dbList_Sistema_BatchTimes.List, "sis_batch_descricao");
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_recorrencia_cd, indexSistemaBatch.report.dbList_Sistema_BatchTimes.List, "sis_batch_recorrencia_cd"); 
                }

                if (e.PropertyName == "dbList_Sistema_Batch_Run")
                {
                    dtgSistemaBatchRUN.DataSource = indexSistemaBatch.report.dbList_Sistema_Batch_Run.List;
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_run_seq, indexSistemaBatch.report.dbList_Sistema_Batch_Run.List, "sis_batch_run_seq");
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_run_status_cd, indexSistemaBatch.report.dbList_Sistema_Batch_Run.List, "sis_batch_run_status_cd");
                    UserTools._Screen_DataBinding_Set(lblsis_batch_descricao, indexSistemaBatch.report.dbList_Sistema_Batch_Run.List, "sis_batch_descricao");
                    UserTools._Screen_DataBinding_Set(lblsis_batch_run_status_descricao, indexSistemaBatch.report.dbList_Sistema_Batch_Run.List, "sis_batch_run_status_descricao"); 
                    
                    
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        private void cmdConsultarBatchService_Click(object sender, EventArgs e)
        {
            __Consultar_Detalhe();
        }

        private void cmddetalhe_batchs_Click(object sender, EventArgs e)
        {
            try
            {
                int sis_batch_cd = 0;
                int sis_batch_service_cd = 0;
                
                if (lbl_sis_batch_cd.Text != "") 
                {
                    sis_batch_cd = Convert.ToInt32(lbl_sis_batch_cd.Text);
                }
                else 
                {
                    UserTools._Screen_MessageBox(this,UserTools.PagTipoMessageBox.Atencao, "Código do Batch Não selecionado! Informe-o"); 
                    return;
                }
                
                if (lbl_sis_batch_service_cd.Text != "")
                {
                    sis_batch_service_cd = Convert.ToInt32(lbl_sis_batch_service_cd.Text);
                }
                else 
                {
                    UserTools._Screen_MessageBox(this,UserTools.PagTipoMessageBox.Atencao, "Código do Serviço não selecionado! Informe-o"); 
                    return;
                }
                listruns(sis_batch_service_cd, sis_batch_cd);
            }
            catch (Exception ex)
            {
                 UserTools._Screen_MessageBox(this, ex);
            }
        }


        private void listruns(int sis_batch_service_cd, int sis_batch_cd)
        {
            try
            {
                indexSistemaBatch.report.ConsultarBatchRun(sis_batch_service_cd, sis_batch_cd, 0);
            }
            catch ( Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }


        private void lbl_sis_batch_descricao_TextChanged(object sender, EventArgs e)
        {
            dtgSistemaBatchRUN.DataSource = null;
            lbl_sis_batch_run_seq.Text = "";
            lbl_sis_batch_run_status_cd.Text = "";
            lblsis_batch_descricao.Text = "";
            lblsis_batch_run_status_descricao.Text = "";
        }

        private void lbl_sis_batch_service_cd_TextChanged(object sender, EventArgs e)
        {
            dtgSistemaBatchServiceShedule.DataSource = null;
            dtgsistema_batch.DataSource = null;
            lbl_sis_batch_cd.Text = "";
            lbl_sis_batch_descricao.Text = "";
            lblsis_batch_descricao.Text = "";
            lbl_sis_batch_run_seq.Text = "";
            lbl_sis_batch_run_status_cd.Text = "";
            lbl_sis_batch_recorrencia_cd.Text = "";
            lblsis_batch_run_status_descricao.Text = "";
        }

        private void lbl_sis_batch_run_status_cd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmdSisBatchRUN_Alterar_Status.Enabled = false;
                cmdConsultarLogs.Enabled = false;
                if (lbl_sis_batch_run_status_cd.Text == "")
                    return;


                cmdConsultarLogs.Enabled = true;
                int status = Convert.ToInt32(lbl_sis_batch_run_status_cd.Text);
                if (status == 20)
                {
                    cmdSisBatchRUN_Alterar_Status.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdSisBatchRUN_Alterar_Status_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_sis_batch_run_seq.Text != "")
                {
                    Pag_Net.src.F9030_sistemabatch.model.modelsistema_batch ModelSisBatch = new Pag_Net.src.F9030_sistemabatch.model.modelsistema_batch();
                    ModelSisBatch.BindingFromRun(MyConnect, Convert.ToInt32(lbl_sis_batch_run_seq.Text));

                    if (UserTools._Screen_MessageBox_OkCancel(this, string.Format("Confirma atualização do Run Seq N. {0}", ModelSisBatch.sistema_batch_run.sis_batch_run_seq.ToString())))
                    {
                        ModelSisBatch.modelFinalizarRunUser(MyConnect);
                        cmddetalhe_batchs_Click(null, null);
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, string.Format("Path Run {0} finalizado com sucesso!", ModelSisBatch.sistema_batch_run.sis_batch_run_seq.ToString()));
                        
                        
                    }
                }
                else
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Selecione um Batch RUN Seq");
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void lbl_sis_batch_recorrencia_cd_TextChanged(object sender, EventArgs e)
        {
            cmdSisBatchRUN_Gerar.Enabled = false;
            
            if (lbl_sis_batch_recorrencia_cd.Text != "")
            {
                if (lbl_sis_batch_recorrencia_cd.Text ==  "2")
                {
                    cmdSisBatchRUN_Gerar.Enabled = true;
                }
            }
        }

        private void cmdConsultarLogs_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_sis_batch_run_seq.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Favor Secionar o Seq Batch" );
                    return; 
                }
                Sistema.frm_Sistema_Log frmsistemaLog = new frm_Sistema_Log(MyConnect, 0, 0, Convert.ToInt32(lbl_sis_batch_run_seq.Text));
                frmsistemaLog.ShowDialog(); 

            }
            catch (Exception ex) 
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdSisBatchRUN_Gerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirmar geração do RUN?"))
                {
                    Pag_Net.src.F9030_sistemabatch.model.modelsistema_batch ModelSisBatch = new Pag_Net.src.F9030_sistemabatch.model.modelsistema_batch();
                    ModelSisBatch.sis_batch_cd = Convert.ToInt32(lbl_sis_batch_cd.Text);
                    ModelSisBatch.sistema_batch_time.sis_batch_time_seq = Convert.ToInt32(lbl_sis_batch_time_seq.Text);
                    ModelSisBatch.modelNewRun(MyConnect);
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdintegracaotipoinfo_vinculada_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_sis_batch_cd.Text != "") 
                {
                    Integracao.frm_IntegracaoTipoInfo frmIntegracaoTipoInfo = new Integracao.frm_IntegracaoTipoInfo(MyConnect);
                    frmIntegracaoTipoInfo.filter_sis_batch_cd = Convert.ToInt32(lbl_sis_batch_cd.Text);
                    frmIntegracaoTipoInfo.ShowDialog();
                }

                else
                {
                    UserTools._Screen_MessageBox(this,"Informe o sis bacth cd");
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdBatchs_Click(object sender, EventArgs e)
        {
            try
            {
                int sistema_batch_cd = 0;
                if (lbl_sis_batch_cd.Text != "")
                    sistema_batch_cd = Convert.ToInt32(lbl_sis_batch_cd.Text);


                sistema_batch.frmSistema_Batch _frmsistema_batch = new sistema_batch.frmSistema_Batch(MyConnect, sistema_batch_cd);
                _frmsistema_batch.ShowDialog();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void dtgSistemaBatchRUN_complete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            foreach (DataGridViewRow row in dtgSistemaBatchRUN.Rows)
            {
                // Condição para colorir a linha (exemplo: se o valor da primeira célula for maior que 10)
                if (Convert.ToInt32(row.Cells["dtgSistemaBatchRUN_sis_batch_run_status_cd"].Value) == 20)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White; // Cor de fundo branca
                }
            }


        }
    }
}
