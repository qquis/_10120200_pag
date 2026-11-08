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
using System.Windows.Shapes;
using Pag_Net.Models;
using Pag_Net.Bll;

namespace Pag_Wpf.Comercial.Analise
{
    /// <summary>
    /// Interaction logic for WindowFormComAnaliseMercFabricProd6MesesDT.xaml
    /// </summary>
    /// 
    
    
    public partial class WindowFormComAnaliseMercFabricProd6MesesDT : Window
    {
        public modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Comercial.Analise.USPComercialAnaliseMercFabricProd6Meses BLL;
        Pag_Net.Bll.Comercial.Analise.UVWComercialAnaliseMercFabricProd6Meses FabricanteSelecionado;
        public WindowFormComAnaliseMercFabricProd6MesesDT(modelSistemaUsuario __myConnect,Pag_Net.Bll.Comercial.Analise.UVWComercialAnaliseMercFabricProd6Meses __fabricatenSelecionado )
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Comercial.Analise.USPComercialAnaliseMercFabricProd6Meses(MyConnect);
                FabricanteSelecionado = __fabricatenSelecionado;


                BLL.Parametros.TipoRelatorio = "PRODUTO";
                BLL.Parametros.CdFabricante = __fabricatenSelecionado.CdFabricante.Trim();
                BLL.Select();

                DTGAnaliseComercialFabricanteProduto.ItemsSource = BLL.ViewData;

                
                fillgrafico();

                //mcChartProduto


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillgrafico()
        {


            List<KeyValuePair<string, double>> l1 = new List<KeyValuePair<string, double>>();
            l1.Add(new KeyValuePair<string, double>("MES 1", FabricanteSelecionado.M1Valor));
            l1.Add(new KeyValuePair<string, double>("MES 2", FabricanteSelecionado.M2Valor));
            l1.Add(new KeyValuePair<string, double>("MES 3", FabricanteSelecionado.M3Valor));
            l1.Add(new KeyValuePair<string, double>("MES 4", FabricanteSelecionado.M4Valor));
            l1.Add(new KeyValuePair<string, double>("MES 5", FabricanteSelecionado.M5Valor));
            l1.Add(new KeyValuePair<string, double>("MES 6", FabricanteSelecionado.M6Valor));
            l1.Add(new KeyValuePair<string, double>("Atual", FabricanteSelecionado.M7Valor));
            
            UclLabelCdParticipante.Text = FabricanteSelecionado.DescricaoFabricante.ToString();
            LBLMES1VALOR.Content = FabricanteSelecionado.M1Valor.ToString("0.00");
            LBLMES2VALOR.Content = FabricanteSelecionado.M2Valor.ToString("0.00");
            LBLMES3VALOR.Content = FabricanteSelecionado.M3Valor.ToString("0.00");
            LBLMES4VALOR.Content = FabricanteSelecionado.M4Valor.ToString("0.00");
            LBLMES5VALOR.Content = FabricanteSelecionado.M5Valor.ToString("0.00");
            LBLMES6VALOR.Content = FabricanteSelecionado.M6Valor.ToString("0.00");
            LBLMES7VALOR.Content = FabricanteSelecionado.M7Valor.ToString("0.00");

            LBLFABRICANTEMESFATURAMENTO.Content = FabricanteSelecionado.MesFaturamento.ToString("0.00");
            LBLFABRICANTEMESCUSTO.Content = FabricanteSelecionado.MesFaturamento.ToString("0.00");
            LBLFABRICANTEMESMARGEM.Content = FabricanteSelecionado.MesMargem.ToString("0.00");

            LBLFABRICANTEMEDIAFATURAMENTO.Content = FabricanteSelecionado.MediaFaturamento.ToString("0.00");
            LBLFABRICANTEMEDIACUSTO.Content = FabricanteSelecionado.MediaFaturamento.ToString("0.00");
            LBLFABRICANTEMEDIAMARGEM.Content = FabricanteSelecionado.MediaMargem.ToString("0.00");


            var dataSourceList = new List<List<KeyValuePair<string, double>>>();
            dataSourceList.Add(l1);
            mcChart.DataContext = dataSourceList;

        }

        private void CMDSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
