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


namespace Pag_Wpf.Comercial.Compras
{
    /// <summary>
    /// Interaction logic for UclPedidoCompra.xaml
    /// </summary>
    public partial class UclPedidoCompra : UserControl
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Comercial.PedidoCompra.UspComercialPedidoCompra BLL;
        private string FormularioMenu = "m4510";
        public UclPedidoCompra(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                DTPDataPedidoCompraInicial.Text = "01/03/2015";// DateTime.Now;
                DTPDataPedidoCompraFinal.SelectedDate = DateTime.Now;
                BLL = new Pag_Net.Bll.Comercial.PedidoCompra.UspComercialPedidoCompra(MyConnect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLL.Parametros.Data = DTPDataPedidoCompraInicial.SelectedDate.Value;
                BLL.Parametros.DataFinal = DTPDataPedidoCompraFinal.SelectedDate.Value;
                BLL.Parametros.TipoRelatorio = "PEDIDO";
                BLL.Select();
                DTGPedidoCompras.ItemsSource = BLL.ViewData;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void CmdDetalhe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Comercial.PedidoCompra.UVWComercialPedidoCompra PedidoCompraSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.PedidoCompra.UVWComercialPedidoCompra;
                frmPedidoCompraEmail frm = new frmPedidoCompraEmail(MyConnect, PedidoCompraSelecionado);
                frm.ShowDialog();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void CmdImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Comercial.PedidoCompra.UVWComercialPedidoCompra PedidoCompraSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.PedidoCompra.UVWComercialPedidoCompra;
                BLL.Parametros.NumeroPedido = PedidoCompraSelecionado.NumeroPedido;
                BLL.Parametros.TipoRelatorio = "ITEM";
                BLL.Select();
                Pag_Wpf.ReportViewForm rpt = new ReportViewForm(BLL.ViewData, "Pag_Wpf.ReportForm.rptPedidoCompra.rdlc", "DSPedidoCompra");
                rpt.ShowDialog();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            //{
            //    // Set PDF format for export
            //    // should be one within XamReportViewer.AvailableExportFormats
            //    string exportFormat = "PDF";

            //    SaveFileDialog saveFileDialog = new SaveFileDialog()
            //    {
            //        DefaultExt = exportFormat,
            //        Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*",
            //        FilterIndex = 1
            //    };

            //    // Instantiate a SaveFileDialog to specify file destination
            //    if (saveFileDialog.ShowDialog() == true)
            //    {
            //        Stream myStream = null;
            //        try
            //        {
            //            // Open a file to save the exported report
            //            myStream = saveFileDialog.OpenFile();

            //            // Invoke Viewer's Exporter
            //            this.xamReportViewer1.Export(myStream, exportFormat);
            //        }
            //        catch (Exception)
            //        {
            //            //TODO  Handle Exception
            //            if (myStream != null)
            //                myStream.Close();
            //        }
            //    }
            //}
        }
    }
}
