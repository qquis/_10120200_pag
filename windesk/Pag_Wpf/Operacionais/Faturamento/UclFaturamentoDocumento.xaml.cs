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

namespace Pag_Wpf.Operacionais.Faturamento
{
    /// <summary>
    /// Interaction logic for UclFaturamentoDocumento.xaml
    /// </summary>
    public partial class UclFaturamentoDocumento : UserControl
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Operacionais.Faturamento.Collection  BLL;
        Pag_Net.Bll.Operacionais.Faturamento.UspFaturamentoDocumentos _BLL;
        Pag_Net.Bll.Operacionais.Faturamento.UspFaturamentoDocumentoItens _Item;
        string FormularioMenu = "m2710";

        //Pag_Net.Bll.Operacionais.Faturamento.UVWFaturamentoDocumentos _SeqSelecionado;
        public UclFaturamentoDocumento(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;

                BLL = new Pag_Net.Bll.Operacionais.Faturamento.Collection(MyConnect);


                dtPickerIni.SelectedDate = DateTime.Now.Date;
                dtPickerFim.SelectedDate = DateTime.Now.Date;

                cmbOperacao.ItemsSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, FormularioMenu);
                cmbOperacao.SelectedIndex = 0;

                cmbECF.ItemsSource = Pag_Net.Bll.Tables.bllTbECF.GetList(MyConnect);
                cmbECF.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Documentos.Select();
                DTGReceitaFaturamentoDocumentos.ItemsSource = BLL.Documentos.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void cmdNotasFiscais_Detalhes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                _Item.Filtros.SeqFaturamento = 0;
                _Item.Filtros.SeqFaturamento = (((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Faturamento.UVWFaturamentoDocumentos).SeqFaturamento;
                _Item.Filtros.SeqFaturamentoOrigem = (((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Faturamento.UVWFaturamentoDocumentos).SeqFaturamentoOrigem;
                _Item.Select();
                //RepresentanteSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.UVWRepresentantes;
                //AtualizarFabricante(RepresentanteSelecionado.CdRepresentante);
                //AtualizarParticipante(RepresentanteSelecionado.CdRepresentante);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void cmbOperacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BLL.Documentos.Parametros.CdOperacao = ((Pag_Net.Models.TbSysTbOperacoes)cmbOperacao.SelectedItem).CdOperacao;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtPickerIni_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Documentos.Parametros.DataFaturamentoInicial = dtPickerIni.SelectedDate.Value;
        }

        private void dtPickerFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Documentos.Parametros.DataFaturamentoFinal = dtPickerFim.SelectedDate.Value;
        }

        private void txtNumeroNota_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtNumeroNota.Text  != "")
            {
                BLL.Documentos.Parametros.NumeroNota = Convert.ToInt32(txtNumeroNota.Text);
            }
        }
    }
}
