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
namespace Pag_Wpf
{
    /// <summary>
    /// Interaction logic for PagWpfLogin.xaml
    /// </summary>
    public partial class PagWpfLogin : Window
    {
        public PagWpfLogin()
        {
            InitializeComponent();
        }
        private void cmdLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow PagWpf = new MainWindow();
            PagWpf.UsrCd = "ELIAS";
            PagWpf.UsrEmail = "eliassilva@oxan.com.br";
            PagWpf.UsrNome = "ELIAS DA SILVA";
            this.Close();
        }
        private void cmdSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
