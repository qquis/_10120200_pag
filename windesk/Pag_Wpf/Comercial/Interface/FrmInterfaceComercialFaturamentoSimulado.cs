using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pag_Wpf.Comercial.Interface
{
    public partial class FrmInterfaceComercialFaturamentoSimulado : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        //Pag_Net.Bll.Comercial.Interface.UspInterfaceFaturamentoAgendamentoSimuladoInfoItem BLL;
        Pag_Net.Bll.Comercial.Interface.InterfaceFaturamentoSimulacao BLL;
        int SeqInterfaceInfo = 0;
        string FormularioMenu = "m2411";

        public FrmInterfaceComercialFaturamentoSimulado(Pag_Net.Models.modelSistemaUsuario __myConnect, Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfo __interface)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Comercial.Interface.InterfaceFaturamentoSimulacao(MyConnect);
                DTP_INI.Value = DateTime.Now;
                DTP_FIM.Value = DateTime.Now;
                DTPDataFaturamentoRegistroIni.Value = DateTime.Now;
                DTPDataFaturamentoRegistroFim.Value = DateTime.Now;

                BLL.FaturamentoSimulado.Parametros.DadosNovos = true;
                BLL.FaturamentoSimulado.Parametros.DataFaturamento = DTP_INI.Value;
                BLL.FaturamentoSimulado.Parametros.DataFaturamentoFinal = DTP_FIM.Value;
                CMBVendedor.DataSource = BLL.Vendedores.ViewData;
                DTGInterfaceComercialFaturamentoSimulado.AutoGenerateColumns = false;
                DTGInterfaceComercialFaturamentoSimulado.SelectionMode = DataGridViewSelectionMode.CellSelect;

                SeqInterfaceInfo = __interface.SeqInterfaceInfo;
                TXTInterfaceInfoDescricao.Text = __interface.Descricao;


                DTGInterfaceComercialFaturamentoSimulado.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[7].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[8].SortMode = DataGridViewColumnSortMode.Automatic;
                DTGInterfaceComercialFaturamentoSimulado.Columns[9].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDLocalizarProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                Pag_Wpf.Cadastro.ProdutoLocaliza frm = new Cadastro.ProdutoLocaliza(MyConnect);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TXTProdutos.Text = frm.ReturnListaCodigosSelecionados.ToString();
                }
                else
                {
                    TXTProdutos.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTProdutos_TextChanged(object sender, EventArgs e)
        {
            BLL.FaturamentoSimulado.Parametros.ListaProduto = TXTProdutos.Text.ToString();
        }

        private void DTP_INI_ValueChanged(object sender, EventArgs e)
        {
            BLL.FaturamentoSimulado.Parametros.DataFaturamento = DTP_INI.Value;
        }

        private void DTP_FIM_ValueChanged(object sender, EventArgs e)
        {
            BLL.FaturamentoSimulado.Parametros.DataFaturamentoFinal = DTP_FIM.Value;
        }

        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            
            
            
            try
            {
                if (DTPDataFaturamentoRegistroIni.Value < DateTime.Now.Date)
                {
                    MessageBox.Show("Periodo de Data para registro inicial deve ser igual o maior que hoje");
                    return;
                }

                if  (DTPDataFaturamentoRegistroIni.Value > DTPDataFaturamentoRegistroFim.Value )
                {
                    MessageBox.Show ("Periodo de Data para registro inválido");
                    return;
                }

                if (DTP_INI.Value > DTP_FIM.Value)
                {
                    MessageBox.Show("Periodo de Data para registro inválido");
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                BLL.FaturamentoSimulado.Select();
                //DTGInterfaceComercialFaturamentoSimulado.DataSource = BLL.FaturamentoSimulado.ViewData;
                DTGInterfaceComercialFaturamentoSimulado.Rows.Clear();

                DateTime DataSequencial = DTPDataFaturamentoRegistroIni.Value;


                int linha = 0;
                foreach (Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem item in (Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem[])BLL.FaturamentoSimulado.ViewData)
                {
                    DTGInterfaceComercialFaturamentoSimulado.Rows.Add();
                    DTGInterfaceComercialFaturamentoSimulado[0, linha].Value = DataSequencial.ToShortDateString();
                    DTGInterfaceComercialFaturamentoSimulado[1, linha].Value = item.CdVendedorERP;
                    DTGInterfaceComercialFaturamentoSimulado[2, linha].Value = item.NomeParticipanteVendedor;
                    DTGInterfaceComercialFaturamentoSimulado[3, linha].Value = item.CdClienteERP;
                    DTGInterfaceComercialFaturamentoSimulado[4, linha].Value = item.NomeParticipanteCliente;
                    DTGInterfaceComercialFaturamentoSimulado[5, linha].Value = item.CdProduto;
                    DTGInterfaceComercialFaturamentoSimulado[6, linha].Value = item.Descricao;
                    DTGInterfaceComercialFaturamentoSimulado[7, linha].Value = item.EmbalagemEstoque;
                    DTGInterfaceComercialFaturamentoSimulado[8, linha].Value = item.EmbalagemEstoqueQtde;
                    DTGInterfaceComercialFaturamentoSimulado[9, linha].Value = item.ValorTotalFaturamento;
                    DTGInterfaceComercialFaturamentoSimulado[11, linha].Value = item.CdParticipanteVendedor;
                    DTGInterfaceComercialFaturamentoSimulado[12, linha].Value = item.CdParticipanteCliente;
                    DataSequencial = DataSequencial.AddDays(1);
                    if (DataSequencial > DTPDataFaturamentoRegistroFim.Value)
                    {
                        DataSequencial = DTPDataFaturamentoRegistroIni.Value;
                    }
                    linha = linha + 1;
                }
                this.Cursor = Cursors.Arrow;
            }
            catch( Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTProdutos_DoubleClick(object sender, EventArgs e)
        {
            TXTProdutos.Text = "";
        }

        private void CMBVendedor_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                BLL.FaturamentoSimulado.Parametros.SeqParticipanteVendedor = ((Pag_Net.Bll.Cadastros.UVWParticipante)CMBVendedor.SelectedItem).CdParticipante;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem> List = new List<Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem>();
                foreach (DataGridViewRow row in DTGInterfaceComercialFaturamentoSimulado.Rows)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Convert.ToBoolean(row.Cells["DTGColumnSelecionar"].Value) == true)
                    {
                        Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem item = new Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem();
                        item.SeqInterfaceInfo = SeqInterfaceInfo;
                        item.DataFaturamento = Convert.ToDateTime(row.Cells[0].Value);
                        item.CdProduto = Convert.ToInt32(row.Cells[5].Value);
                        item.EmbalagemEstoqueQtde = Convert.ToDouble(row.Cells[8].Value);
                        item.CdParticipanteVendedor = Convert.ToInt32(row.Cells[11].Value);
                        item.CdParticipanteCliente = Convert.ToInt32(row.Cells[12].Value);
                        List.Add(item);
                    }
                    this.Cursor = Cursors.Arrow;
                }
                if (MessageBox.Show("Confirma inclusão de " + List.Count().ToString() + " Registros?", "Inclusão de simulação de faturamento?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    BLL.Inserir(List.ToArray());
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("Registro(s) Incluido(s) com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CMDDesmarcaTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DTGInterfaceComercialFaturamentoSimulado.Rows)
            {
                this.Cursor = Cursors.WaitCursor;
                row.Cells["DTGColumnSelecionar"].Value = false;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void CMDSelecionaTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DTGInterfaceComercialFaturamentoSimulado.Rows)
            {
                this.Cursor = Cursors.WaitCursor;
                row.Cells["DTGColumnSelecionar"].Value = true;
                this.Cursor = Cursors.Arrow;
            }
        }

  


    }
}

