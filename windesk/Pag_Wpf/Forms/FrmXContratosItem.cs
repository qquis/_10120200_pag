using Pag_Net.Models;
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
    public partial class FrmXContratosItem : Form
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.ContratosX _BLL_Contratos;


        


        public FrmXContratosItem(Pag_Net.Models.modelSistemaUsuario _MYCONNECT, SP_Contrato_TbContrato item)
        {
            InitializeComponent();
            MyConnect = _MYCONNECT;
            DtgContratosItem.AutoGenerateColumns = false;
            DtgContratosItem.ReadOnly = true;
            _BLL_Contratos = new Pag_Net.Bll.ContratosX(MyConnect);
            if (item.SeqContrato > 0)
            {
                txtSeqContrato.Text = item.SeqContrato.ToString();
                txtDescricao.Text = item.Descricao;
                DtpInicial.Value = item.DataInicio;
                DtpFinal.Value = item.DataFim;
                txtTipoContrato_Descricao.Text  = item.Tipos_Descricao;
                txtNumeroNotaFiscal.Text = item.NumeroDocumentoFiscal.ToString();
                txtNumeroPedido.Text = item.NumeroPedido.ToString();
                _SelectItens();

            }
            
        }


        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _SelectItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _SelectItens()
        {

            try
            {
                cmdBuscar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (txtSeqContrato.Text != "")
                {
                    _BLL_Contratos.F_SeqContrato = Convert.ToInt32(txtSeqContrato.Text);
                }
                _BLL_Contratos.F_DataInicio = DtpInicial.Value;
                _BLL_Contratos.F_DataFim = DtpFinal.Value;
                _BLL_Contratos.F_SeqContrato = Convert.ToInt32(txtSeqContrato.Text);
                DtgContratosItem.DataSource = _BLL_Contratos.getDataTable_ContratoItem();
                chartInvestimento.DataSource = _BLL_Contratos.getDataTable_ContratoItem();
                chartInvestimento.DataBind();
                cmdBuscar.Enabled = true;
                this.Cursor = Cursors.Default;
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                cmdBuscar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
