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
using Pag_Net.Bll.Financeiro;
using Pag_Net.Models;
using Pag_Net.Models.ModeloBase;
using System.ComponentModel;
using System.Data;

namespace Pag_Wpf.Financeiro.CartaoCredito
{
    /// <summary>
    /// Interaction logic for UclInterfaceLogSitef.xaml
    /// </summary>
    public partial class UclInterfaceLogSitef : UserControl
    {
        public Pag_Net.Bll.Financeiro.CartaoCredito.LogSitef BLL;
        public modelSistemaUsuario MyConnect;
        public UclInterfaceLogSitef(modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            BLL = new Pag_Net.Bll.Financeiro.CartaoCredito.LogSitef(MyConnect);
            BLL.ArquivosImportados.PropertyChanged += new PropertyChangedEventHandler(BllSitefLogArquivosImportados_OnList);
            BLL.Registros.PropertyChanged += new PropertyChangedEventHandler(BllSitefLogRegistros_OnList);

            dtPickerDataProcessamentoArquivoInicial.SelectedDate = DateTime.Now;
            dtPickerDataProcessamentoArquivoFinal.SelectedDate = DateTime.Now;
        }
        private void CmdImportarArquivo_Click(object sender, RoutedEventArgs e)
        {
            LogSitefImportacaoArquivo form = new LogSitefImportacaoArquivo(MyConnect);
            form.ShowDialog();
        }

        private void CmdBuscarInterfacesArquivos_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                BLL.ArquivosImportados.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void BllSitefLogArquivosImportados_OnList(object sender, PropertyChangedEventArgs e)
        {
            DataGridSitefLogArquivos.ItemsSource = null;
            DataGridSitefLogArquivos.ItemsSource = BLL.ArquivosImportados.ViewData;
        }
        private void BllSitefLogRegistros_OnList(object sender, PropertyChangedEventArgs e)
        {
            DataGridRegistos.ItemsSource = null;
            DataGridRegistos.ItemsSource = BLL.Registros.ViewData;
        }

        private void dtPickerDataProcessamentoArquivoInicial_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.ArquivosImportados.Filtros.DataInicial = dtPickerDataProcessamentoArquivoInicial.SelectedDate.Value;
        }

        private void dtPickerDataProcessamentoArquivoFinal_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.ArquivosImportados.Filtros.DataFinal = dtPickerDataProcessamentoArquivoFinal.SelectedDate.Value;
        }

        private void CmdLancamentos_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCSitefLogArquivos ArquivoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCSitefLogArquivos;
                BLL.Registros.Filtros.Arquivo = ArquivoSelecionado.Arquivo;
                BLL.Registros.Select();
                //DataGridRegistos.DataContext = BLL.Registros.ViewData;
                //DataGridLancamentos.ItemsSource = BLL.Lancamentos.ViewData;
                //DataGridCieloRO.ItemsSource = BLL.CieloRO.ViewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
