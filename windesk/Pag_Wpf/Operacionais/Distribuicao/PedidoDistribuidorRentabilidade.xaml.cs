using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pag_Net.Bll;
using Pag_Net.Models;


namespace Pag_Wpf.Operacionais
{
    /// <summary>
    /// Interaction logic for PedidoDistribuidorRentabilidade.xaml
    /// </summary>
    public partial class PedidoDistribuidorRentabilidade : Page
    {
        // Public Var's
        public Pag_Net.Models.modelSistemaUsuario MyConnection { get; set; }
        
        // Private Var's
        private Pag_Net.Bll.Tables.bllTbPedido _objTbPedido;


        public PedidoDistribuidorRentabilidade(Pag_Net.Models.modelSistemaUsuario myConnection)
        {
            InitializeComponent();
            MyConnection = myConnection;


            dtPickerIni.SelectedDate = DateTime.Now; //Convert.ToDateTime("10/09/2011");
            dtPickerFim.SelectedDate = DateTime.Now; //Convert.ToDateTime("15/09/2011");
            FillVendedor();
            FillFabricante();
            
            
            

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            fillGrid();
        }


        private void cmdDetalhesItens_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            TbPedido obj = ((FrameworkElement)sender).DataContext as TbPedido;
            FillGridItens(obj.NumeroPedido);
            Mouse.OverrideCursor = x;
        }

        private void DataGridPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillGridItens(0);
        }

        private void FillVendedor()
        {
            cmbVendedor.ItemsSource = Pag_Net.Bll.Tables.bllTbVendedor.GetList(MyConnection);
            cmbVendedor.SelectedIndex = 0;
            
 
        }

        private void FillFabricante()
        {
            cmbfabricante.ItemsSource = Pag_Net.Bll.Tables.bllTbFabricante.GetList(MyConnection);
            cmbfabricante.SelectedIndex = 0;
        }


        private void cmbVendedor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (TbVendedor  i in cmbVendedor.Items)
            {
                if (i.NomeVendedor.ToString().ToUpper() == e.Text.ToUpper())
                {
                    cmbVendedor.SelectedItem = i;
                    break;
                }
            }
            e.Handled = true;
        }

        private void fillGrid()
        {

            try
            {
                
                this.Cursor = Cursors.Wait;
                int? numeropedido = null;
                int? codigocliente = null;
                if (txtCdCliente.Text.ToString() != "")
                {
                    codigocliente = Convert.ToInt32(txtCdCliente.Text.ToString());
                }
                string codigovendedor = ((TbVendedor)cmbVendedor.SelectedItem).CdERPVendedor.ToString();
                string descricaofabricante = ((TbFabricante)cmbfabricante.SelectedItem).DescricaoFabricante.ToString();
                _objTbPedido = new Pag_Net.Bll.Tables.bllTbPedido(MyConnection, dtPickerIni.SelectedDate.Value, dtPickerFim.SelectedDate.Value, numeropedido, codigocliente, codigovendedor, txtNomeCliente.Text.ToString(),descricaofabricante.ToString());
                TbPedido[] ListaPedidos = _objTbPedido.GetList();

                double NumeroPedidos = 0;
                double BaseValor = 0;
                double BaseMargem = 0;
                double TabelaValor = 0;
                double TabelaMargem = 0;
                double AplicadoValor = 0;
                double AplicadoMargem = 0;
                double FinanceiroValor = 0;
                double FinanceiroMargem = 0;
                double VerbaVendedor = 0;
                double VerbaFornecedor = 0;
                double CustoValor = 0;
                double MargemLiquida = 0;


                foreach (TbPedido _item in ListaPedidos)
                {
                    NumeroPedidos++;
                    BaseValor += Convert.ToDouble( _item.ValorFaturamentoBruto.ToString());
                    TabelaValor += Convert.ToDouble(_item.ValorFaturamento.ToString());
                    AplicadoValor += Convert.ToDouble(_item.ValorFaturamentoAplicado.ToString());
                    FinanceiroValor += Convert.ToDouble(_item.ValorFaturamentoFinanceiro.ToString());
                    VerbaVendedor += Convert.ToDouble(_item.ValorVerbaTotal.ToString());
                    VerbaFornecedor += Convert.ToDouble(_item.ValorVerbaFabricanteTotal.ToString());

                    CustoValor += Convert.ToDouble(_item.ValorCustoTotal.ToString());
                }

                if (BaseValor >0) BaseMargem = Math.Round((BaseValor - CustoValor) / BaseValor * 100, 2);
                if (TabelaValor > 0) TabelaMargem = Math.Round((TabelaValor - CustoValor) / TabelaValor * 100, 2);
                if (AplicadoValor >0) AplicadoMargem = Math.Round((AplicadoValor - CustoValor) / AplicadoValor * 100, 2);
                if (FinanceiroValor >0) FinanceiroMargem = Math.Round((FinanceiroValor - CustoValor) / FinanceiroValor * 100, 2);
                if (FinanceiroValor >0) MargemLiquida = Math.Round((FinanceiroValor - (CustoValor - VerbaFornecedor)) / FinanceiroValor * 100, 2);

                LblTRegistros.Content = NumeroPedidos.ToString("0");
                LblTCustoValor.Content = CustoValor.ToString("#,###,##0.00");
                LblTBaseMargem.Content = BaseMargem.ToString("#,###,##0.00");
                LblTBaseValor.Content = BaseValor.ToString("#,###,##0.00");

                LblTTabelaValor.Content = TabelaValor.ToString("#,###,##0.00");
                LblTTabelaMargem.Content = TabelaMargem.ToString("#,###,##0.00");
                LblTAplicadoValor.Content = AplicadoValor.ToString("#,###,##0.00");
                LblTAplicadoMargem.Content = AplicadoMargem.ToString("#,###,##0.00");
                LblTFinanceiroValor.Content = FinanceiroValor.ToString("#,###,##0.00");
                LblTFinanceiroMargem.Content = FinanceiroMargem.ToString("#,###,##0.00");


                LblTVerbaFabricante.Content = VerbaFornecedor.ToString("#,###,##0.00");
                LblTVerbaVendedor.Content = VerbaVendedor.ToString("#,###,##0.00");

                LblTMargemLiquida.Content = MargemLiquida.ToString("#,###,##0.00");

                DataGridPedido.ItemsSource = ListaPedidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.Cursor = Cursors.Arrow;
            

        }
        private void FillGridItens(int _numeropedido)
        {
            try
            {
                if (_numeropedido == 0)
                {
                    DataGridPedidoItens.ItemsSource = null;
                    DataGridPedidoFabricante.ItemsSource = null;
                }
                else
                {
                    DataGridPedidoItens.ItemsSource = _objTbPedido.GetListItens(_numeropedido);
                    DataGridPedidoFabricante.ItemsSource = _objTbPedido.GetListFabricante(_numeropedido);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }



    }
}
