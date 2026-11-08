using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Distribuicao.Forca_Venda_Meta
{
    public partial class frm_fv_meta_tipo : Form
    {
        //Pag_Net.src.f0005_forca_venda_meta.wk WK;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_fv_meta_tipo( Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect; 
            InitializeComponent();
            _Screen_load(); 
        }

        private void _Screen_load()
        {
            try
            {

                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_Form_Format_DataGridView(dtgC);
                dtgC.DataSource = Pag_Net.src.f0005_forca_venda_meta.dataStore.ArrayTabs.ForcaVendaMetaTipoList_Get(MyConnect, false);

                /*COMBO VENDEDOR*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("FrmForcaVendaMeta | Load \n " + ex.Message);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
