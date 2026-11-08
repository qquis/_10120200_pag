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
    public partial class frm_Sistema_Log : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F9020_sistema_log._index wk;

        public frm_Sistema_Log(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            txtproc_log_seq.Text = "0";
            txtsis_nucleo_prc_cd_filter.Text = "0";
            txtsis_batch_run_seq.Text = "0";
            _Screen_load();
        }

        
        
        
        public frm_Sistema_Log(Pag_Net.Models.modelSistemaUsuario _MyConnect,int proc_log_seq, int sis_nucleo_prc_cd,  int sis_batch_run_seq)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            txtproc_log_seq.Text = proc_log_seq.ToString();
            txtsis_nucleo_prc_cd_filter.Text = sis_nucleo_prc_cd.ToString();
            txtsis_batch_run_seq.Text = sis_batch_run_seq.ToString(); 
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
                wk = new Pag_Net.src.F9020_sistema_log._index(MyConnect);
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Detalhe);
                dtpDataInicial.Format = DateTimePickerFormat.Custom;
                dtpDataInicial.CustomFormat = "dd/MM/yyyy HH:mm";
                dtpDataInicial.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 05:01:01");


                dtpDataFinal.Format = DateTimePickerFormat.Custom;
                dtpDataFinal.CustomFormat = "dd/MM/yyyy HH:mm";
                dtpDataFinal.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");

                UserTools._Screen_Form_Format_DataGridView(dtg);

                wk.PropertyChanged += DtGridMetaBinding;

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtproc_log_seq.Text ==  "" ) 
                    txtproc_log_seq.Text = "0"; 

                if (txtsis_batch_run_seq.Text == "") 
                    txtsis_batch_run_seq.Text = "0"; 

                if (txtsis_nucleo_prc_cd_filter.Text == "")
                    txtsis_nucleo_prc_cd_filter.Text = "0";
             
                UserTools._Screen_Wait(this);
                wk.ConsultarLogs(Convert.ToInt32(txtproc_log_seq.Text), Convert.ToInt32(txtsis_nucleo_prc_cd_filter.Text), txtsis_log_tag.Text, txtsis_log_info.Text, Convert.ToInt32(txtsis_batch_run_seq.Text), dtpDataInicial.Value, dtpDataFinal.Value, txtuuid_start_filter.Text);
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

                if (e.PropertyName == "dbList_Sistema_Log")
                {
                    dtg.DataSource = wk.dbList_Sistema_Log.List;
                    UserTools._Screen_DataBinding_Set(txtinfo, dtg.DataSource = wk.dbList_Sistema_Log.List, "sis_log_info");
                    UserTools._Screen_DataBinding_Set(txttag, dtg.DataSource = wk.dbList_Sistema_Log.List, "sis_log_tag");
                    UserTools._Screen_DataBinding_Set(txtsis_nucleo_prc_cd, dtg.DataSource = wk.dbList_Sistema_Log.List, "sis_nucleo_prc_cd");
                    UserTools._Screen_DataBinding_Set(txtdtlog_insert, dtg.DataSource = wk.dbList_Sistema_Log.List, "dtlog_insert");
                    UserTools._Screen_DataBinding_Set(txtsis_log_seq, dtg.DataSource = wk.dbList_Sistema_Log.List, "sis_log_seq");
                    UserTools._Screen_DataBinding_Set(txtuuid, dtg.DataSource = wk.dbList_Sistema_Log.List, "uuid");
                    UserTools._Screen_DataBinding_Set(txtuuid_start, dtg.DataSource = wk.dbList_Sistema_Log.List, "uuid_start");
                    
                    

                    
                    
                }

             
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }
    }
}
