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
using System.ComponentModel;

namespace Pag_Wpf.Sistema
{
    /// <summary>
    /// Interaction logic for UclProcessos.xaml
    /// </summary>
    public partial class UclProcessos : UserControl
    {
        public Pag_Net.Bll.Sistemas.UspProcessos BLL;
        public modelSistemaUsuario Myconnect;
        public UclProcessos(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            Myconnect = __myConnect;
            BLL = new Pag_Net.Bll.Sistemas.UspProcessos(Myconnect);
            CMDBuscar_Click(null, null);
        }

        private void CMDEfetivar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                
                Pag_Net.Bll.Sistemas.VWProcessos Processo = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Sistemas.VWProcessos;
                if (MessageBox.Show("Confirma Execução do Processo: " + Processo.Descricao, "Pag - Sistema/Processos", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    Pag_Net.Bll.Sistemas.Processos.Executa(Myconnect, Processo);
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("Erro: " + ex.Message.ToString());

            }

        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            BLL.Select();
            DTGProcessos.ItemsSource = BLL.ViewData;
        }
    }
}
