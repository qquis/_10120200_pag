using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Tools;
using Pag_Net.Bll.Services;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;

namespace Pag_Wpf.Operacionais.Analise
{
            
    public partial class frmInvestimento : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Operacionais.Produto.Kit BLL;
        public frmInvestimento(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Operacionais.Produto.Kit(MyConnect);
            CMBFabricante.ValueMember = "CdFabricante";
            CMBFabricante.DisplayMember = "Descricao";

            dtgContratos.AutoGenerateColumns = false;
            Pag_Net.Bll.Cadastros.Fabricante Fabricante = new Pag_Net.Bll.Cadastros.Fabricante(__myConnect);
            CMBFabricante.DataSource = Fabricante.ViewData;
            
        }

        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                    Cursor.Current = Cursors.WaitCursor;
                    Pag_Net.Bll.Contratos _CONTRATOS = new Contratos(MyConnect);

                    _CONTRATOS.DESCRICAO_CONTRATO = TXTDescricao.Text;

                    _CONTRATOS.Reflesh();
                    dtgContratos.DataSource = _CONTRATOS.DataTableResult;
                    Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CMDAdicionar_Click(object sender, EventArgs e)
        {
            frmInvestimentosAdicionar frmadicionar = new frmInvestimentosAdicionar(MyConnect);
            frmadicionar.ShowDialog(); 

        }
    }
}
