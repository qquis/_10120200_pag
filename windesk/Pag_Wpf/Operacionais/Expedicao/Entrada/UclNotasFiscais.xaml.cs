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
using Pag_Net.Models;
using System.ComponentModel;

namespace Pag_Wpf.Operacionais.Expedicao.Entrada
{
    /// <summary>
    /// Interaction logic for UclNotasFiscais.xaml
    /// </summary>
    public partial class UclNotasFiscais : UserControl
    {
        #region Publics
        private Pag_Net.Bll.Operacionais.Operacoes.Entrada.Entrada BLL;
        private modelSistemaUsuario MyConnect;
        #endregion

        #region FormOpen
        public UclNotasFiscais(modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Operacionais.Operacoes.Entrada.Entrada(_myConnect);


            BLL.NotasFiscais.PropertyChanged += new PropertyChangedEventHandler(BllNotasFiscais_OnLista);
            BLL.NotasFiscaisItem.PropertyChanged += new PropertyChangedEventHandler(BllNotasFiscaisItens_OnLista);

            dtPickerIni.SelectedDate = DateTime.Now;
            dtPickerFim.SelectedDate = DateTime.Now;

            cmbFornecedor.ItemsSource = BLL.Fornecedores;
            cmbFornecedor.SelectedIndex = 0;
        }
        #endregion

        #region Buttons
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            DataGridItens.ItemsSource = null;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                BLL.NotasFiscais.Filtros.DataFinal = dtPickerFim.SelectedDate.Value;
                BLL.NotasFiscais.Filtros.DataInicial = dtPickerIni.SelectedDate.Value;
                BLL.NotasFiscais.Filtros.CodigoFornecedor = ((TbPessoas)cmbFornecedor.SelectedItem).CdErpFornecedor;
                BLL.NotasFiscais.Filtros.NumerosNotasFiscais = txtNumeroNota.Text;
                BLL.NotasFiscais.Filtros.CheckNaoBonificadas = chkTipoNormal.IsChecked.Value;
                BLL.NotasFiscais.Filtros.CheckSimBonificadas = chkTipoBonificado.IsChecked.Value;
                BLL.NotasFiscais.Filtros.ValorInicial = txtValorNotaIni.Text;
                BLL.NotasFiscais.Filtros.ValorFinal = txtValorNotaFim.Text;
                BLL.NotasFiscais.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void cmdNotasFiscais_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                BLL.NotaFiscalSelecionada = ((FrameworkElement)sender).DataContext as Pag_Net.Models.ModeloBase.TbNotasFiscais;
                BLL.NotasFiscaisItem.Filtros.DataInicial = BLL.NotasFiscais.Filtros.DataInicial;
                BLL.NotasFiscaisItem.Filtros.DataFinal = BLL.NotasFiscais.Filtros.DataFinal;
                BLL.NotasFiscaisItem.Filtros.CodigoFornecedor = BLL.NotaFiscalSelecionada.CdPessoaEmissor;
                BLL.NotasFiscaisItem.Filtros.NumeroNotaFiscal = BLL.NotaFiscalSelecionada.NumeroNotaFiscal;
                BLL.NotasFiscaisItem.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = x;
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {

            if (BLL.NotasFiscais.Lista == null)
            {
                MessageBox.Show("Não há dados para impressão!", "PAG");
            }
            else
            {
                Cursor x = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;
                try
                {
                    Pag_Wpf.ReportViewForm ReportNotaEntrada = new ReportViewForm(BLL.NotasFiscais.Lista, "Pag_Wpf.ReportForm.rptTbNotasFiscaisEntrada.rdlc", "DataSetTbNotasFiscais");
                    ReportNotaEntrada.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                Mouse.OverrideCursor = x;
            }
        }

        #endregion

        #region Event Class
        private void BllNotasFiscais_OnLista(object sender, PropertyChangedEventArgs e)
        {

            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DataGridNotasFiscaisEntrada.ItemsSource = BLL.NotasFiscais.Lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = x;
        }
        private void BllNotasFiscaisItens_OnLista(object sender, PropertyChangedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DataGridItens.ItemsSource = BLL.NotasFiscaisItem.Lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = x;
        }

        #endregion
    }
}
