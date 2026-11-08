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
    /// Interaction logic for UclOperacaoProdutoRegistroConsolidar.xaml
    /// </summary>
    public partial class UclOperacaoProdutoRegistroPendentes : UserControl
    {
        Pag_Net.Bll.Operacionais.Produto.UspRegistroProdutoPendentes BLL;
        modelSistemaUsuario MyConnect;
        public UclOperacaoProdutoRegistroPendentes(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Operacionais.Produto.UspRegistroProdutoPendentes(MyConnect);
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Select();
                DTGRegistrosConsolidar.ItemsSource = BLL.ViewData;
                LblTotal.Content = BLL.TotalRegistros.ToString();
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void CMDConsolidar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                Pag_Net.Bll.Operacionais.Produto.UspRegistroProdutoConsolidar.Executar(MyConnect);
                DTGRegistrosConsolidar.ItemsSource = null;
                MessageBox.Show("Registros Consolidados");
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
