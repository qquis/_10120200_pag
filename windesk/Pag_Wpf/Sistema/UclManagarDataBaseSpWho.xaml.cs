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

namespace Pag_Wpf.Sistema
{
    /// <summary>
    /// Interaction logic for UclManagarDataBaseSpWho.xaml
    /// </summary>
    public partial class UclManagarDataBaseSpWho : UserControl
    {
        public Pag_Net.Bll.Sistemas.UspSp_Who BLL;
        public modelSistemaUsuario Myconnect;
        public UclManagarDataBaseSpWho(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            Myconnect = __myConnect;
            BLL = new Pag_Net.Bll.Sistemas.UspSp_Who(__myConnect);
        }
 

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Select();
                DTGProcessos.ItemsSource = BLL.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch( Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void SRVADM_Click(object sender, RoutedEventArgs e)
        {
            BLL.Servidor = Pag_Net.Bll.Sistemas.UspSp_Who.eServidor.ADM;
        }

        private void SRVPRD_Click(object sender, RoutedEventArgs e)
        {
            BLL.Servidor = Pag_Net.Bll.Sistemas.UspSp_Who.eServidor.PRD;
        }
    }
}
