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


namespace Pag_Wpf.Operacionais.Distribuicao
{
    /// <summary>
    /// Interaction logic for StatusOperacaoVenda.xaml
    /// </summary>
    public partial class StatusOperacaoVenda : Page
    {
        
        private Pag_Net.Bll.Operacionais.Distribuicao.UspStatusOperacaoVenda BLL;
        public StatusOperacaoVenda(modelSistemaUsuario __MyConnect)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Operacionais.Distribuicao.UspStatusOperacaoVenda(__MyConnect);
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BLL.Select();
            DGStatusOperacaoVendaList.ItemsSource = BLL.ViewData;
        }
    }
}
