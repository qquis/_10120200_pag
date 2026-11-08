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

namespace Pag_Wpf.Comercial.Analise
{
    /// <summary>
    /// Interaction logic for UclComAnaliseMercFabricProd6Meses.xaml
    /// </summary>
    public partial class UclComAnaliseMercFabricProd6Meses : UserControl
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Comercial.Analise.USPComercialAnaliseMercFabricProd6Meses BLL;
        string FormularioMenu = "m4410";
        public UclComAnaliseMercFabricProd6Meses(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Comercial.Analise.USPComercialAnaliseMercFabricProd6Meses(MyConnect);
                FillGrafico();
                CMBOperacao.ItemsSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, FormularioMenu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillGrafico()
        {
            List<KeyValuePair<string, double>> l1 = new List<KeyValuePair<string, double>>();

            l1.Add(new KeyValuePair<string, double>("MES 1", BLL.ValorTotalMes1));
            l1.Add(new KeyValuePair<string, double>("MES 2", BLL.ValorTotalMes2));
            l1.Add(new KeyValuePair<string, double>("MES 3", BLL.ValorTotalMes3));
            l1.Add(new KeyValuePair<string, double>("MES 4", BLL.ValorTotalMes4));
            l1.Add(new KeyValuePair<string, double>("MES 5", BLL.ValorTotalMes5));
            l1.Add(new KeyValuePair<string, double>("MES 6", BLL.ValorTotalMes6));
            l1.Add(new KeyValuePair<string, double>("Atual", BLL.ValorTotalMes7));


            LBLMES1VALOR.Content = BLL.ValorTotalMes1.ToString("0.00");
            LBLMES2VALOR.Content = BLL.ValorTotalMes2.ToString("0.00");
            LBLMES3VALOR.Content = BLL.ValorTotalMes3.ToString("0.00");
            LBLMES4VALOR.Content = BLL.ValorTotalMes4.ToString("0.00");
            LBLMES5VALOR.Content = BLL.ValorTotalMes5.ToString("0.00");
            LBLMES6VALOR.Content = BLL.ValorTotalMes6.ToString("0.00");
            LBLMES7VALOR.Content = BLL.ValorTotalMes7.ToString("0.00");

            var DatTotal = new List<List<KeyValuePair<string, double>>>();
            DatTotal.Add(l1);

            MCTotal.DataContext = DatTotal;
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Parametros.TipoRelatorio = "FABRICANTE";
                
                BLL.Select();
                DTGAnaliseComercialFabricanteProduto.ItemsSource = BLL.ViewData;
                FillGrafico();

                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }



        private void CMDDetalhes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Comercial.Analise.UVWComercialAnaliseMercFabricProd6Meses _FabricanteSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.Analise.UVWComercialAnaliseMercFabricProd6Meses;
                WindowFormComAnaliseMercFabricProd6MesesDT _WindowForm = new WindowFormComAnaliseMercFabricProd6MesesDT(MyConnect,_FabricanteSelecionado);
                _WindowForm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMBOperacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BLL.Parametros.CdOperacao = ((Pag_Net.Models.TbSysTbOperacoes)CMBOperacao.SelectedItem).CdOperacao;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





    }
}

