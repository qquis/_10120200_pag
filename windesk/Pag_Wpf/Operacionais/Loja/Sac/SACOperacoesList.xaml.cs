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

namespace Pag_Wpf.Operacionais.Loja.Sac
{
    /// <summary>
    /// Interaction logic for SACOperacoesList.xaml
    /// </summary>
    public partial class SACOperacoesList : Page
    {
        public Pag_Net.Bll.Operacionais.Varejo.Sac.UspOperacaoSac BLL;
        public SACOperacoesList(Pag_Net.Models.modelSistemaUsuario __myConnection)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Operacionais.Varejo.Sac.UspOperacaoSac(__myConnection);

            Pag_Net.Bll.Tables.BllTbTipos _tipos = new Pag_Net.Bll.Tables.BllTbTipos(__myConnection);
            cmbTipoOperacaoSac.ItemsSource = _tipos.GetList("TbOperacaoSac", "TipoOperacaoSac");
            CmbSituacao.ItemsSource = _tipos.GetList("TbOperacaoSac", "Situacao");
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            BLL.Select();
            DataGridOperacoesSac.ItemsSource = BLL.ViewData;
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
