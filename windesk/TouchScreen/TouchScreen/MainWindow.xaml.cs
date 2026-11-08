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

namespace Pag_Net
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bllPackageConnection myConnect;
        public bllPackageConnection Myconnect { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            string _strUserInfo = "ELIAS";
            string _strPassWordInfo = "+17jesusbom";
            try
            {
                myConnect = new bllPackageConnection("TER", _strUserInfo, "PRD", "LAN", _strPassWordInfo,
               @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("TouchScreen.exe", "") + @"\infox.dll");

                Myconnect = myConnect;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Abertura do Terminal: " + ex.Message.ToString());
            }
        }

        private void btnProduto_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnElogio_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnProdNaoEncontrado_Click(object sender, RoutedEventArgs e)
        {
            ProdutoNaoEncontrado _n = new ProdutoNaoEncontrado(Myconnect);
            _n.Show();
        }

    }
}
