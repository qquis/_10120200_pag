using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pag_Wpf.Forms
{
    public partial class FrmXParticipantes : Form
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public FrmXParticipantes(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cmdAtualizarBase_Click(object sender, EventArgs e)
        {

        }
    }
}
