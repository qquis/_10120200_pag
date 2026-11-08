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
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Reflection;
using Pag_Net.Bll;
using Pag_Net.Bll.Financeiro;
using Pag_Net.Models;
using Pag_Net.Models.ModeloBase;

namespace Pag_Wpf.Financeiro.CartaoCredito
{
    /// <summary>
    /// Interaction logic for UclConsultaOperacoes.xaml
    /// </summary>
    public partial class UclConsultaOperacoes : UserControl
    {
        Pag_Net.Bll.Financeiro.CartaoCredito.ConsultaOperacoes BLL;
        public UclConsultaOperacoes(modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Financeiro.CartaoCredito.ConsultaOperacoes(_myConnect);

            //BLL = new Pag_Net.Bll.Financeiro.CartaoCredito.OperacoesRegistradas(_myConnect);
            BLL.OperacoesRegistradas.PropertyChanged += new PropertyChangedEventHandler(BllOperacoesCartaoCreditoRegistros_OnLista);
            BLL.FinalizadorasRegistradas.PropertyChanged += new PropertyChangedEventHandler(BllOperacoesCartaoCreditoFinalizadoras_OnLista);

            //BLL = new Pag_Net.Bll.Financeiro.CartaoCredito.OperacoesPendentesRegistros(_myConnect);
            //BLL.Finalizadoras.PropertyChanged += new PropertyChangedEventHandler(BllOperacoesCartaoCreditoFinalizadoras_OnLista);
            //BLL.Registros.PropertyChanged += new PropertyChangedEventHandler(BllOperacoesCartaoCreditoRegistros_OnLista);
            dtPickerDataOperacao.SelectedDate = DateTime.Now;
            //dtPickerDataOperacao.SelectedDate = Convert.ToDateTime("01/03/2014");
        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DataGridCartaoCreditoConsultaOperacoesFinalizadora.ItemsSource = null;
                DataGridCartaoCreditoConsultaOperacoesRegistros.ItemsSource = null;
                BLL.Select();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Mouse.OverrideCursor = x;
        }
        private void BllOperacoesCartaoCreditoFinalizadoras_OnLista(object sender, PropertyChangedEventArgs e)
        {

            DataGridCartaoCreditoConsultaOperacoesFinalizadora.ItemsSource = BLL.FinalizadorasRegistradas.ViewData;
        }
        private void BllOperacoesCartaoCreditoRegistros_OnLista(object sender, PropertyChangedEventArgs e)
        {
            DataGridCartaoCreditoConsultaOperacoesRegistros.ItemsSource = BLL.OperacoesRegistradas.ViewData;
        }
        private void dtPickerDataOperacao_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.OperacoesRegistradas.Filtros.DataInicial = dtPickerDataOperacao.SelectedDate.Value;
            BLL.OperacoesRegistradas.Filtros.DataFinal = dtPickerDataOperacao.SelectedDate.Value;

            BLL.FinalizadorasRegistradas.Filtros.DataInicial = dtPickerDataOperacao.SelectedDate.Value;
            BLL.FinalizadorasRegistradas.Filtros.DataFinal = dtPickerDataOperacao.SelectedDate.Value;
        }

        private void CmdDetalhe_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                BLL.OperacoesRegistradas.Filtros.DataInicial = dtPickerDataOperacao.SelectedDate.Value;
                BLL.OperacoesRegistradas.Filtros.DataFinal = dtPickerDataOperacao.SelectedDate.Value;
                Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCFinalizadorasRegistradas FinalizadoraSelecionada = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCFinalizadorasRegistradas;
                if (FinalizadoraSelecionada.Finalizadora != "")
                {
                    BLL.OperacoesRegistradas.Filtros.Finalizadora = FinalizadoraSelecionada.Finalizadora;
                }
                else
                {
                    BLL.OperacoesRegistradas.Filtros.Finalizadora = null;
                }
                BLL.Select();
                //DataGridLancamentos.ItemsSource = BLL.Lancamentos.ViewData;
                //DataGridCieloRO.ItemsSource = BLL.CieloRO.ViewData;
                BLL.OperacoesRegistradas.Filtros.Finalizadora = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
