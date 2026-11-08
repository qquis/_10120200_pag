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
    public partial class frm_Loja_Atualizacao_Balanca : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_Loja_Atualizacao_Balanca(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            UserTools._Screen_Form_Format_DataGridView(dtgPreco_BALANCA);
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            DataTable ListaKG = Pag_Net.Bll.F0003_Loja.Loja.ArquivoMGV(MyConnect);
            dtgPreco_BALANCA.DataSource = ListaKG;
            lbl_total.Text = ListaKG.Rows.Count.ToString();
            
        }
    }
}
