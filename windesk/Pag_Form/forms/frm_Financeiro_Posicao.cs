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
    public partial class frm_Financeiro_Posicao : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        //Pag_Net.Bll.F0050_Financeiro.Wk_ERP __FINANCEIRO_WK_ERP;
        //Pag_Net.Bll.F0080_Financeiro.WKBlueSoft_Consulta _WKBlueSoft_Consulta;
        user_control.frmUC_Financeiro_AutorizacaoPgto_Consulta frmUC_Financeiro_AutorizacaoPgto_Consulta;


        public frm_Financeiro_Posicao(Pag_Net.Models.modelSistemaUsuario __Myconnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __Myconnect;
                //_WKBlueSoft_Consulta = new Pag_Net.Bll.F0080_Financeiro.WKBlueSoft_Consulta(MyConnect);
                //_Screen_load();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);

            }
        }

        private void dtgFinanceiroLancamentos_SelectionChanged(object sender, EventArgs e)
        {
            
        }

    }
}
