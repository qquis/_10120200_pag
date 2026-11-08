using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Integracao
{
    public partial class frm_IntegracaoTipoInfo : Form
    {
        public int filter_sis_batch_cd;
        public int filter_integracao_tipo_cd;

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F0095_Integracao._index F0095;
        

        public frm_IntegracaoTipoInfo(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            _Screen_load();
        }
        private void frm_IntegracaoTipoInfo_Shown(object sender, EventArgs e)
        {

            bool filterSelect = false;

            if (filter_sis_batch_cd != 0)
            {
                txtsis_batch_cd.Text = filter_sis_batch_cd.ToString();
                filterSelect = true;
            }

            if (filter_integracao_tipo_cd != 0)
            {
                txtIntegracaoTipoCd.Text = filter_integracao_tipo_cd.ToString();
                filterSelect = true;
            }

            if (filterSelect)
                cmdConsultar_Click(null, null);

        }
        private void _Screen_load()
        {
            F0095 = new Pag_Net.src.F0095_Integracao._index(MyConnect, 2000);
            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
            UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);

            UserTools._Screen_Form_Format_DataGridView(dtgI);

            F0095.reports.PropertyChanged += _databinding;




        }
        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_IntegracaoTipoInfo")
            {
                dtgI.DataSource = F0095.reports.dbList_IntegracaoTipoInfo.List;
                UserTools._Screen_DataBinding_Set(txtscript_select, dtgI.DataSource, "script_select");
                //UserTools._Screen_DataBinding_Set(lbl_integracao_produto_seq, dtgI.DataSource, "integracao_produto_seq");
            }

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtIntegracaoTipoCd.Text == "") txtIntegracaoTipoCd.Text = "0";
                if (txtsis_batch_cd.Text == "") txtsis_batch_cd.Text = "0";

                UserTools._Screen_Wait(this);
                F0095.reports.IntegracaoTipoInfoGet(Convert.ToInt32(txtIntegracaoTipoCd.Text), Convert.ToInt32(txtsis_batch_cd.Text));
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


    }

}
