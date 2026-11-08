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
using Pag_Net.Bll.Financeiro;
using Pag_Net.Models;
using Pag_Net.Models.ModeloBase;
using System.ComponentModel;
using System.Data;

namespace Pag_Wpf.Financeiro.CartaoCredito
{
    /// <summary>
    /// Interaction logic for UclInterfaceConsultaRegistros.xaml
    /// </summary>
    public partial class UclInterfaceConsultaRegistros : UserControl
    {
        private modelSistemaUsuario _MyConnect;
        public Pag_Net.Bll.Financeiro.CartaoCredito.UspFCCInterfacesPgtosProcessados BLL;
        public UclInterfaceConsultaRegistros(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            _MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Financeiro.CartaoCredito.UspFCCInterfacesPgtosProcessados(_MyConnect);
            DTPDataFaturamentoInicial.SelectedDate = DateTime.Now;
            DTPDataFaturamentoFinal.SelectedDate = DateTime.Now;
            DTPDataPagamentoInicial.SelectedDate = DateTime.Now;
            DTPDataPagamentoFinal.SelectedDate = DateTime.Now;

            CMBProdutoFinanceiro.ItemsSource = BLL.ProdutosFinanceiros.ViewData;
            if (BLL.ProdutosFinanceiros.ViewData.Count() > 0)
            {
                CMBProdutoFinanceiro.SelectedIndex = 0;
            }
            else
            {
                CMBProdutoFinanceiro.IsEnabled = false;
            }
            CHKDataPagamento.IsChecked = true;
            CHKDataFaturamento.IsChecked = false;
            DTPDataFaturamentoInicial.IsEnabled = false;
            DTPDataFaturamentoFinal.IsEnabled = false;

            Pag_Net.Bll.Cadastros.Participantes BllParticipantes = new Pag_Net.Bll.Cadastros.Participantes(_MyConnect);
            BllParticipantes.Filtros.CdErpTipo = "FINANC";
            BllParticipantes.Select();
            CMBAutorizadorCartaoFinanceiro.ItemsSource = BllParticipantes.ViewData;
            if (CMBAutorizadorCartaoFinanceiro.Items.Count > 0)
                CMBAutorizadorCartaoFinanceiro.SelectedIndex = 0;
        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DTGInterfacePagamentos.ItemsSource = null;
                DataGridLancamentos.ItemsSource = null;
                if (CHKDataPagamento.IsChecked.Value)
                {
                    BLL.DataPagamento = true;
                }
                else
                {
                    BLL.DataPagamento = false;
                }
                if (CHKDataFaturamento.IsChecked.Value)
                {
                    BLL.DataFaturamento = true;
                }
                else
                {
                    BLL.DataFaturamento = false;
                }
                BLL.DataFaturamentoInicial = DTPDataFaturamentoInicial.SelectedDate.Value;
                BLL.DataFaturamentoFinal = DTPDataFaturamentoFinal.SelectedDate.Value;
                BLL.DataPagamentoInicial = DTPDataPagamentoInicial.SelectedDate.Value;
                BLL.DataPagamentoFinal = DTPDataPagamentoFinal.SelectedDate.Value;





                BLL.CdParticipante = ((Pag_Net.Bll.Cadastros.UVWParticipantes)CMBAutorizadorCartaoFinanceiro.SelectedItem).CdParticipante;


                if (TXTValorPagamentoCupomInicial.Text != "")
                {
                    BLL.ValorPagamentoCupomInicial = Convert.ToDouble(TXTValorPagamentoCupomInicial.Text);
                }
                else
                {
                    BLL.ValorPagamentoCupomInicial = 0;
                }

                if (TXTValorPagamentoCupomFinal.Text != "")
                {
                    BLL.ValorPagamentoCupomFinal = Convert.ToDouble(TXTValorPagamentoCupomFinal.Text);
                }
                else
                {
                    BLL.ValorPagamentoCupomFinal = 0;
                }


                BLL.SeqSitefLogInterfacedProdutoFinanceiro = ((Pag_Net.Bll.Financeiro.CartaoCredito.VWFCCInterfaceProdutoFinanceiro)CMBProdutoFinanceiro.SelectedItem).SeqSitefLogInterfaceProdutoFinanceiro;
                BLL.Select();
                DTGInterfacePagamentos.ItemsSource = BLL.ViewData;

                UclTotalValor.Text = BLL.ValorTotal.ToString("#,###,##0.00");
                UclTotalTarifa.Text = BLL.ValorTarifa.ToString("#,###,##0.00");
                UclTotalValorLiquido.Text = BLL.ValorLiquido.ToString("#,###,##0.00");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void CHKDataFaturamento_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CHKDataFaturamento_Click(object sender, RoutedEventArgs e)
        {
            if (CHKDataFaturamento.IsChecked.Value)
            {
                BLL.DataFaturamento = true;
                DTPDataFaturamentoInicial.IsEnabled = true;
                DTPDataFaturamentoFinal.IsEnabled = true;
            }
            else
            {
                BLL.DataFaturamento = false;
                DTPDataFaturamentoInicial.IsEnabled = false;
                DTPDataFaturamentoFinal.IsEnabled = false;
            }
        }

        private void CHKDataPagamento_Click(object sender, RoutedEventArgs e)
        {
            if (CHKDataPagamento.IsChecked.Value)
            {
                BLL.DataPagamento = true;
                DTPDataPagamentoInicial.IsEnabled = true;
                DTPDataPagamentoFinal.IsEnabled = true;
            }
            else
            {
                BLL.DataPagamento = false;
                DTPDataPagamentoInicial.IsEnabled = false;
                DTPDataPagamentoFinal.IsEnabled = false;
            }
        }

        private void CmdDetalhe_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCInterfacesPgtosProcessados ItemUVWFCCInterfacesPgtosProcessados = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Financeiro.CartaoCredito.UVWFCCInterfacesPgtosProcessados;
                Pag_Net.Bll.Financeiro.CartaoCredito.UspFCCInterfacesImportadasLancamentos Lancamentos = new Pag_Net.Bll.Financeiro.CartaoCredito.UspFCCInterfacesImportadasLancamentos(_MyConnect);
                Lancamentos.Filtros.SeqLinhaResumo = ItemUVWFCCInterfacesPgtosProcessados.SeqLinha;
                Lancamentos.Select();
                DataGridLancamentos.ItemsSource = Lancamentos.ViewData;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void TXTValorPagamentoCupomInicial_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXTValorPagamentoCupomInicial.Text != "")
                {
                    double Valor = Convert.ToDouble(TXTValorPagamentoCupomInicial.Text);
                    if (Valor > 0)
                    {
                        TXTValorPagamentoCupomInicial.Text = Valor.ToString("#,##0.00");
                    }
                    else
                    {
                        TXTValorPagamentoCupomInicial.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                TXTValorPagamentoCupomInicial.Text = "";
                MessageBox.Show("Valor Invalido!");
            }
        }

        private void TXTValorPagamentoCupomFinal_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXTValorPagamentoCupomFinal.Text != "")
                {
                    double Valor = Convert.ToDouble(TXTValorPagamentoCupomFinal.Text);
                    if (Valor > 0)
                    {
                        TXTValorPagamentoCupomFinal.Text = Valor.ToString("#,##0.00");
                    }
                    else
                    {
                        TXTValorPagamentoCupomFinal.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                TXTValorPagamentoCupomFinal.Text = "";
                MessageBox.Show("Valor Invalido!");
            }
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            if (BLL.ProdutosFinanceiros.ViewData == null)
            {
                MessageBox.Show("Não há dados para impressão!", "PAG");
            }
            else
            {

                Pag_Wpf.ReportViewForm ReportBrandao = new ReportViewForm(BLL.ViewData, "Pag_Wpf.ReportForm.rptTbResumoRegistroInterface.rdlc", "DataSetTbResumoRegistroInterface");

                ReportBrandao.ShowDialog();

            }
        }


    }
}
