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
using System.Data;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace Pag_Wpf.Operacionais.Produto
{
    /// <summary>
    /// Interaction logic for UclOperacaoProdutoRegistroLancados.xaml
    /// </summary>
    public partial class UclOperacaoProdutoRegistroLancados : UserControl
    {
        Pag_Net.Bll.Operacionais.Produto.Registros BLL;
        modelSistemaUsuario MyConnect;
        public UclOperacaoProdutoRegistroLancados(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Operacionais.Produto.Registros(MyConnect);
            DTPCAD_INI.SelectedDate = DateTime.Now;
            DTPCAD_FIM.SelectedDate = DateTime.Now;

        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Consolidados.DataLancamentoInicial = DTPCAD_INI.SelectedDate.Value;
                BLL.Consolidados.DataLancamentoFinal = DTPCAD_FIM.SelectedDate.Value;
                BLL.Consolidados.Select();
                DTGRegistrosProdutosConsolidados.ItemsSource = BLL.Consolidados.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Mouse.OverrideCursor = Cursors.Arrow;

            }

        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                UclLabelTextLancamento.Text  = (((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Produto.UVWRegistroProdutosConsolidados).DataLancamento.ToString();
                UclLabelTextSequencialERP.Text = (((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Produto.UVWRegistroProdutosConsolidados).SequencialErp.ToString("00000000");
                BLL.ItensConsolidados.DataLancamento = (((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Produto.UVWRegistroProdutosConsolidados).DataLancamento;
                BLL.ItensConsolidados.DataRegistro = (((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Produto.UVWRegistroProdutosConsolidados).DataRegistro;
                BLL.ItensConsolidados.SeqTipoRegistro = (((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Produto.UVWRegistroProdutosConsolidados).SeqTipoRegistro;
                BLL.ItensConsolidados.Select();
                DTGRegistrosProdutosConsolidadosItens.ItemsSource = BLL.ItensConsolidados.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }
    }
}
