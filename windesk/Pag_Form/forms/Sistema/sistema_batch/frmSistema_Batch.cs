using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Sistema.sistema_batch
{
    public partial class frmSistema_Batch : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F9030_sistemabatch._index indexSistemaBatch;



        public frmSistema_Batch(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            txtfilter_sis_batch_cd.Text = "0";
            
            
            _Screen_load();

        }
        public frmSistema_Batch(Pag_Net.Models.modelSistemaUsuario _MyConnect, int sistema_batch_cd)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            if (sistema_batch_cd != 0)
                txtfilter_sis_batch_cd.Text = sistema_batch_cd.ToString();
            
            _Screen_load();

        }

        private void _Screen_load()
        {
            try
            {
                indexSistemaBatch = new Pag_Net.src.F9030_sistemabatch._index(MyConnect);
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_Form_Format_DataGridView(dtgsistema_batch);
                indexSistemaBatch.report.PropertyChanged += DtGridMetaBinding;

            }
            catch (Exception ex)
            {
                MessageBox.Show("FrmForcaVendaMeta | Load \n " + ex.Message);
            }
        }

        private void DtGridMetaBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                if (e.PropertyName == "dbList_Sistema_Batch")
                {
                    dtgsistema_batch.DataSource = indexSistemaBatch.report.dbList_Sistema_BatchTimes.List;
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_cd, indexSistemaBatch.report.dbList_Sistema_BatchTimes.List, "sis_batch_cd");
                    UserTools._Screen_DataBinding_Set(lbl_sis_batch_descricao, indexSistemaBatch.report.dbList_Sistema_BatchTimes.List, "sis_batch_descricao");
                    
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        private void __Consultar()
        {
            try
            {
                int filter_sis_batch_cd = 0;

                if (txtfilter_sis_batch_cd.Text != "")
                    filter_sis_batch_cd = Convert.ToInt32( txtfilter_sis_batch_cd.Text );

                UserTools._Screen_Wait(this);
                indexSistemaBatch.report.ConsultarBatch(filter_sis_batch_cd);
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            __Consultar();
        }
        
    }
}
