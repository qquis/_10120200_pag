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
    /// Interaction logic for UclInterface.xaml
    /// </summary>
    public partial class UclInterface : UserControl
    {
        public Pag_Net.Bll.Financeiro.CartaoCredito.Interfaces BLL;
        public modelSistemaUsuario MyConnect;
        public UclInterface(modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            BLL = new Pag_Net.Bll.Financeiro.CartaoCredito.Interfaces(MyConnect);



            BLL.Arquivos.PropertyChanged += new PropertyChangedEventHandler(BllInterfacesArquivosImportados_OnList);
            BLL.Lancamentos.PropertyChanged += new PropertyChangedEventHandler(BllInterfacesLancamentos_OnList);
            BLL.ResumoInterface.PropertyChanged += new PropertyChangedEventHandler(BllInterfacesCieloRo_OnList);
            dtPickerDataProcessamentoArquivoInicial.SelectedDate = DateTime.Now;
            dtPickerDataProcessamentoArquivoFinal.SelectedDate = DateTime.Now;
        }

        private void CmdImportarArquivo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InterfaceImportacaoArquivo form = new InterfaceImportacaoArquivo(MyConnect);
                form.ShowDialog();
                ConsolidarPgtosInterfaces();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CmdBuscarInterfacesArquivos_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                BLL.Arquivos.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void BllInterfacesArquivosImportados_OnList(object sender, PropertyChangedEventArgs e)
        {
            DataGridArquivosImportados.DataContext = BLL.Arquivos.ViewData;
        }
        private void BllInterfacesLancamentos_OnList(object sender, PropertyChangedEventArgs e)
        {
            DataGridLancamentos.ItemsSource = BLL.Lancamentos.ViewData;
        }
        private void BllInterfacesCieloRo_OnList(object sender, PropertyChangedEventArgs e)
        {
            DataGridRO.ItemsSource = BLL.ResumoInterface.ViewData;
        }

        private void dtPickerDataProcessamentoArquivoInicial_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Arquivos.Filtros.DataInicial = dtPickerDataProcessamentoArquivoInicial.SelectedDate.Value;
        }

        private void dtPickerDataProcessamentoArquivoFinal_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Arquivos.Filtros.DataFinal = dtPickerDataProcessamentoArquivoFinal.SelectedDate.Value;
        }

        private void CmdLancamentos_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCInterfacesImportadasArquivos ArquivoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCInterfacesImportadasArquivos;
                BLL.SeqArquivoSelecionado = ArquivoSelecionado.SeqArquivo;
                BLL.Select();
                //DataGridLancamentos.ItemsSource = BLL.Lancamentos.ViewData;
                //DataGridCieloRO.ItemsSource = BLL.CieloRO.ViewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void CMDConsolidarPagamentos_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ConsolidarPgtosInterfaces();
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void ConsolidarPgtosInterfaces()
        {
            try
            {
                Pag_Net.Bll.Financeiro.CartaoCredito.UspFCCInterfacesConsolidarPgto.Aplicar(MyConnect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
