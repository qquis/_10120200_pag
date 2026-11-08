using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Loja
{
    public partial class frm_Loja_Agendamento_Lote : Form
    {
        Pag_Net.src.F0045_Preco._index SRC_PRECO;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_Loja_Agendamento_Lote(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _Screen_load();
        }


        private void _Screen_load()
        {
            SRC_PRECO = new Pag_Net.src.F0045_Preco._index(MyConnect);
            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdPesquisar, UserTools.PagButtonsIcons.Atualiza);
            SRC_PRECO.Reports.PropertyChanged += new PropertyChangedEventHandler(Binding);
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                SRC_PRECO.Reports.PrecoAplicacaoLoteListConsultar();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void Binding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_PrecoAplicacaoLoteList")
            {
                dtg.DataSource = SRC_PRECO.Reports.dbList_PrecoAplicacaoLoteList.List;
            }
        }
    }
}
