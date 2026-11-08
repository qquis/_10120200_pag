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
namespace Pag_Net
{
    /// <summary>
    /// Interaction logic for IdentificaCli.xaml
    /// </summary>
    public partial class IdentificaCli : Window
    {
        IMarketingCli_AE _MyMarketingCli;
        public IdentificaCli()
        {
            InitializeComponent();
            _MyMarketingCli = new IMarketingCli_AE("ELIAS");

            foreach (object _MyObject in LayoutRoot.Children)
            {
                if (_MyObject is TextBox)
                {
                    /*((TextBox)_MyObject).GotFocus += new RoutedEventHandler(TextBox_GotFocus);*/
                    ((TextBox)_MyObject).LostFocus += new RoutedEventHandler(TextBox_LostFocus);
                }
            }

        }

        private void btnConfirma_Click(object sender, RoutedEventArgs e)
        {
            _MyMarketingCli.Insert(); 
            MessageBox.Show( _MyMarketingCli.GetInterfaceMessage.ToString());

        }
        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Background = Brushes.White;
        }
        private void btnCorrige_Click(object sender, RoutedEventArgs e)
        {
            foreach (object _MyObject in LayoutRoot.Children)
            {
                if (_MyObject is TextBox)
                {
                    ((TextBox)_MyObject).Text = string.Empty;

                }
            }
        }
        /*void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Background = Brushes.White;
        }*/

        private void btnFeminino_Click(object sender, RoutedEventArgs e)
        {
            _MyMarketingCli.Sex = "F";
        }

        private void btnMasculino_Click(object sender, RoutedEventArgs e)
        {
            _MyMarketingCli.Sex = "M";
        }

         void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Name == "txtName") { _MyMarketingCli.Name = ((TextBox)sender).Text.ToString(); }
            if (((TextBox)sender).Name == "txtCep") { _MyMarketingCli.Zip_code  = ((TextBox)sender).Text.ToString(); }
            
        } 
    }
}
