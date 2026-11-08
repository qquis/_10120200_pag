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

namespace Pag_Wpf.Comercial.Contratos
{
    /// <summary>
    /// Interaction logic for Contratos.xaml
    /// </summary>
    public partial class Contratos : Page
    {
        //private ModelSystemUserInfoConnect _MyConnect;
        private Pag_Net.Bll.Comercial.CollectionClass _BLL;
        public Contratos(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            
            InitializeComponent();
            _BLL = new Pag_Net.Bll.Comercial.CollectionClass(__myConnect);
            DTPVALIDADE_INI.SelectedDate = Convert.ToDateTime("01/01/" +  DateTime.Now.Year.ToString());
            DTPVALIDADE_FIM.SelectedDate = Convert.ToDateTime("31/12/" + DateTime.Now.Year.ToString());

            DTPLANCAMENTO_INI.SelectedDate = Convert.ToDateTime("01/01/" + DateTime.Now.Year.ToString());
            DTPLANCAMENTO_FIM.SelectedDate = Convert.ToDateTime("31/12/" + DateTime.Now.Year.ToString());


        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _BLL.Contratos.List.Filtros.DataLancamentoFinal = DTPLANCAMENTO_FIM.SelectedDate.Value;
                _BLL.Contratos.List.Filtros.DataLancamentoInicial = DTPLANCAMENTO_INI.SelectedDate.Value;
                _BLL.Contratos.List.Filtros.DataValidadeInicial = DTPVALIDADE_INI.SelectedDate.Value;
                _BLL.Contratos.List.Filtros.DataValidadeFinal = DTPVALIDADE_FIM.SelectedDate.Value;
                _BLL.Contratos.List.Filtros.Descricao = TXTDescricao.Text;

                _BLL.Contratos.List.Select();
                DTGContratos.ItemsSource = _BLL.Contratos.List.ViewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void cmdCupomFiscalDetalhes_Click(object sender, RoutedEventArgs e)
        {
            
            
            Mouse.OverrideCursor = Cursors.Wait;
            _BLL.Contratos.ListInvestimentoItens.Filtros.SeqContrato = 0;
            DTGContratosInvestimentoItem.ItemsSource = null;

            Pag_Net.Bll.Comercial.UVWContratos ContratoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.UVWContratos;

            if (ContratoSelecionado.CdTipoContrato == "IV_IT")
            {
                TABCONTROL_TIPOSCONTRATOS.SelectedIndex = 1;
                _BLL.Contratos.ListInvestimentoItens.Filtros.SeqContrato = ContratoSelecionado.SeqContrato;
                _BLL.Contratos.ListInvestimentoItens.Select();
                DTGContratosInvestimentoItem.ItemsSource = _BLL.Contratos.ListInvestimentoItens.ViewData;
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
