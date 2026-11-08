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
    /// Interaction logic for UclInterfaceComercialArquivos.xaml
    /// </summary>
    public partial class UclInterfaceComercialArquivos : UserControl
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Comercial.Interface.CollectionClass BLL;
        public UclInterfaceComercialArquivos(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Comercial.Interface.CollectionClass(MyConnect);
                CMBInterfaceInfo.ItemsSource = BLL.Cadastro.ViewData;
                dtPickerCadIni.SelectedDate = DateTime.Now;
                dtPickerCadFim.SelectedDate = DateTime.Now;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMBInterfaceInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                DTGInterfaceArquivos.ItemsSource = null;
                DTGInterfaceComercialArquivos.ItemsSource = null;
                DTGInterfaceComercialArquivosLinhas.ItemsSource = null;

                if (CMBInterfaceInfo.SelectedItem != null)
                {
                    BLL.Arquivos.Parametros.SeqInterfaceInfo = ((Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfo)CMBInterfaceInfo.SelectedItem).SeqInterfaceInfo;
                    BLL.Arquivos.Parametros.TipoRelatorio = "ARQUIVOS";
                    BLL.Arquivos.Parametros.SeqTipoArquivo = 0;
                    BLL.Arquivos.Parametros.SeqArquivoHistorico = 0;
                    BLL.Arquivos.Select();
                    DTGInterfaceArquivos.ItemsSource = BLL.Arquivos.ViewData;
                }
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch(Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                DTGInterfaceComercialArquivos.ItemsSource = null;
                BLL.Arquivos.Parametros.TipoRelatorio = "HISTORICO";
                BLL.Arquivos.Select();
                DTGInterfaceComercialArquivos.ItemsSource = BLL.Arquivos.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch( Exception ex)
            {

                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void dtPickerCadIni_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Arquivos.Parametros.DataGeracao = dtPickerCadIni.SelectedDate.Value; 
        }

        private void dtPickerCadFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Arquivos.Parametros.DataGeracaoFinal = dtPickerCadFim.SelectedDate.Value;
        }

        private void CMDArquivoDetalhes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfoArquivo TipoArquivoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfoArquivo;
                BLL.Arquivos.Parametros.SeqTipoArquivo = TipoArquivoSelecionado.SeqTipoArquivo;
                CMDBuscar_Click(null,null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDArquivoHistoricoDetalhes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                DTGInterfaceComercialArquivosLinhas.ItemsSource = null;
                Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfoArquivo TipoArquivoHistoricoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfoArquivo;
                BLL.Arquivos.Parametros.SeqTipoArquivo = TipoArquivoHistoricoSelecionado.SeqTipoArquivo;
                BLL.Arquivos.Parametros.SeqArquivoHistorico = TipoArquivoHistoricoSelecionado.SeqArquivoHistorico;
                BLL.Arquivos.Parametros.TipoRelatorio = "LINHA";
                BLL.Arquivos.Select();
                DTGInterfaceComercialArquivosLinhas.ItemsSource = BLL.Arquivos.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDArquivoGerar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CMDArquivoHistoricoDetalhes_Click(sender, e);
                Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfoArquivo[] Arquivos = (Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfoArquivo[])BLL.Arquivos.ViewData;

                if (Arquivos.Count() > 0)
                {
                    if (MessageBox.Show("Confirma geração do arquivo: " + Arquivos[0].NomeArquivo + "?","PAG",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        this.Cursor = Cursors.Wait;
                        Pag_Net.Bll.Comercial.Interface.UspInterfaceInfoArquivoGerar.Gerar(Arquivos);
                        this.Cursor = Cursors.Arrow;
                    }
                }
            }
            catch(Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }
    }
}