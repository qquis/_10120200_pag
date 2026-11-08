using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;

namespace Pag_Wpf.Operacionais.Analise
{
    public partial class frmInvestimentosAdicionar : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frmInvestimentosAdicionar(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastro.ProdutoLocaliza frm = new Cadastro.ProdutoLocaliza(MyConnect);
            frm.ShowDialog();
            TXTCodigosProdutos.Text = frm.ReturnListaCodigosSelecionados;


        }
    }
}
