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

namespace Pag_Wpf.Comercial.Interface
{
    /// <summary>
    /// Interaction logic for UclInterfaceComercialFaturamentoSimulado.xaml
    /// </summary>
    public partial class UclInterfaceComercialFaturamentoSimulado : UserControl
    {
        private modelSistemaUsuario MyConnect;
        private string FormularioMenu = "m2411";
        public Pag_Net.Bll.Comercial.Interface.InterfaceFaturamentoSimulacao BLL;

        public UclInterfaceComercialFaturamentoSimulado(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Comercial.Interface.InterfaceFaturamentoSimulacao(MyConnect);
                BLL.FaturamentoSimulado.Parametros.DadosNovos = false;
                DTPCAD_FIM.SelectedDate = DateTime.Now;
                DTPCAD_INI.SelectedDate = DateTime.Now;
                CMBInterface.ItemsSource = BLL.Cadastro.ViewData;
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DTPCAD_FIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.FaturamentoSimulado.Parametros.DataFaturamentoFinal = DTPCAD_FIM.SelectedDate.Value;
        }

        private void DTPCAD_INI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.FaturamentoSimulado.Parametros.DataFaturamento = DTPCAD_INI.SelectedDate.Value;
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.FaturamentoSimulado.Select();
                DTGInterfaceFaturamentoClientesNaoFaturados.ItemsSource = BLL.FaturamentoSimulado.ViewData;
                UclLabelTotalRegistros.Text = BLL.FaturamentoSimulado.ViewData.Count().ToString();
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CMDIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ( CMBInterface.SelectedItem == null)
                {
                    MessageBox.Show("Favor selecionar a Interface no Filtro");
                    return;
                }
                else
                {

                    if (((Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfo)CMBInterface.SelectedItem).SeqInterfaceInfo == 0)
                    {
                        MessageBox.Show("Favor selecionar a Interface no Filtro");
                        return;
                    }

                    FrmInterfaceComercialFaturamentoSimulado frm = new FrmInterfaceComercialFaturamentoSimulado(MyConnect, ((Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfo)CMBInterface.SelectedItem));
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TXTPRODUTOS_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXTPRODUTOS.Text != "")
                {
                    BLL.FaturamentoSimulado.Parametros.ListaProduto = TXTPRODUTOS.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTPRODUTOS_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Pag_Wpf.Cadastro.ProdutoLocaliza frm = new Cadastro.ProdutoLocaliza(MyConnect);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TXTPRODUTOS.Text = frm.ReturnListaCodigosSelecionados.ToString();
                }
                else
                {
                    TXTPRODUTOS.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMBInterface_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CMBInterface.SelectedItem == null)
                {
                    return;
                }
                BLL.FaturamentoSimulado.Parametros.SeqInterfaceInfo = ((Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfo)CMBInterface.SelectedItem).SeqInterfaceInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

  
    }
}
