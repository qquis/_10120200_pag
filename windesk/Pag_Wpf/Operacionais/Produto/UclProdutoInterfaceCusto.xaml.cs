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
using Pag_Net.Bll;

namespace Pag_Wpf.Operacionais.Produto
{
    /// <summary>
    /// Interaction logic for UclProdutoInterfaceCusto.xaml
    /// </summary>
    public partial class UclProdutoInterfaceCusto : UserControl
    {
        private modelSistemaUsuario _MyConnect;
        public Pag_Net.Bll.Operacionais.Produto.ProdutoOperacaoCusto BLL;
        public UclProdutoInterfaceCusto(modelSistemaUsuario __MyConnect)
        {
            InitializeComponent();
            _MyConnect = __MyConnect;
            BLL = new Pag_Net.Bll.Operacionais.Produto.ProdutoOperacaoCusto(_MyConnect);
            dtPickerIni.SelectedDate = DateTime.Now;
            dtPickerFim.SelectedDate = DateTime.Now;
            CHKDataCustoAtualizacao.IsChecked = true;
            if (_MyConnect.ListAccess[0].CdFuncao == "1")
            {
                CMImportar.IsEnabled = true;
            }
        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {

                BLL.Select();
                DTGProdutoCusto.ItemsSource = null;
                DTGProdutoCusto.ItemsSource = BLL.ViewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void CHKDataCustoAtualizacao_Click(object sender, RoutedEventArgs e)
        {
            if (CHKDataCustoAtualizacao.IsChecked.Value)
            {
                dtPickerIni.IsEnabled = true;
                dtPickerFim.IsEnabled = true;
                BLL.DataInicial = dtPickerIni.SelectedDate.Value;
                BLL.DataFinal = dtPickerFim.SelectedDate.Value;
            }
            else
            {
                dtPickerIni.IsEnabled = false;
                dtPickerFim.IsEnabled = false;
                BLL.DataInicial = Convert.ToDateTime("1999-01-01");
                BLL.DataFinal = Convert.ToDateTime("2030-12-31");
            }
        }
        private void dtPickerIni_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.DataInicial = dtPickerIni.SelectedDate.Value;
        }
        private void dtPickerFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.DataFinal = dtPickerFim.SelectedDate.Value;
        }
        private void CMImportar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Pag_Net.Bll.Operacionais.Produto.UspInterfaceImportaCusto.Importar(_MyConnect);
            BtnBuscar_Click(null, null);
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void txtdescricaoProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.Descricao = txtdescricaoProduto.Text.TrimEnd().TrimStart();
        }
        private void cmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cmbLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void txtcodigoproduto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void cmbFabricante_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cmbSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
