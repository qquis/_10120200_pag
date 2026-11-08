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
using Pag_Net.Bll;
using Pag_Net.Models; 

namespace Pag_Net
{
    /// <summary>
    /// Interaction logic for ProdutoNaoEncontrado.xaml
    /// </summary>
    public partial class ProdutoNaoEncontrado : Window
    {
        public bllPackageConnection MyConnect;
        public ProdutoNaoEncontrado(bllPackageConnection myConnect)
        {
            InitializeComponent();
            txtDigiteAqui.Focus();
            MyConnect = myConnect;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btnConfirma_Click(object sender, RoutedEventArgs e)
        {
            if (txtDigiteAqui.Text == "")
            {
                return;
            }
            ModelTbTipos objtipos = new ModelTbTipos();
            Models.TbCrmTerminal objcrmTerminal = new TbCrmTerminal(objtipos);
            objcrmTerminal.ProdutoNaoEncontrado = txtDigiteAqui.Text.ToString();
            Bll.Tables.bllTbCrmTerminal blltbcrmterminal = new Bll.Tables.bllTbCrmTerminal(MyConnect);
            //blltbcrmterminal.Insert(objcrmTerminal);
            this.Close();
        }
    }
}
