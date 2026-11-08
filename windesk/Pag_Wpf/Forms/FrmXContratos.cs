using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;
namespace Pag_Wpf.Forms
{
    public partial class FrmXContratos : Form
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.ContratosX _BLL_Contratos;
        public FrmXContratos(Pag_Net.Models.modelSistemaUsuario _MYCONNECT)
        {
            InitializeComponent();
            MyConnect = _MYCONNECT;
            this._fill();

        }


        private void _fill()
        {
            cmbTipo.ValueMember = "SeqTipo";
            cmbTipo.DisplayMember = "DescricaoTipo";
            cmbTipo.DataSource = Pag_Net.Bll.Util.TiposGetDataView(MyConnect.Tipos, "TbContrato", "SeqTipoContrato");
            _BLL_Contratos = new Pag_Net.Bll.ContratosX(MyConnect);
            DtgContratos.AutoGenerateColumns = false;
            DtgContratos.ReadOnly = true;
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                _BLL_Contratos.F_DataInicio = DtpInicial.Value;
                _BLL_Contratos.F_DataFim = DtpFinal.Value;
                _BLL_Contratos.F_SeqTipoContrato = Convert.ToInt32(cmbTipo.SelectedValue);
                DtgContratos.DataSource = _BLL_Contratos.getDataTable_Contrato();
                
                
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtgContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    _BLL_Contratos.F_SeqContrato = Convert.ToInt32(DtgContratos.SelectedRows[0].Cells[2].Value.ToString());
                    Pag_Net.Models.SP_Contrato_TbContrato itemTbContrato = _BLL_Contratos.ListContrato[0];
                    this.Cursor = Cursors.Default;
                    FrmXContratosItem frmXContratosItem = new FrmXContratosItem(MyConnect, itemTbContrato);
                    frmXContratosItem.ShowDialog();
                }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
