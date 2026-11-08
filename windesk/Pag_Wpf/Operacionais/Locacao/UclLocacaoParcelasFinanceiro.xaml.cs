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

namespace Pag_Wpf.Operacionais.Locacao
{
    /// <summary>
    /// Interaction logic for UclLocacaoParcelasFinanceiro.xaml
    /// </summary>
    /// 

    public partial class UclLocacaoParcelasFinanceiro : UserControl
    {

        private modelSistemaUsuario MyConnect;
        private string FormularioMenu = "m2912";
        public Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoParcela ContratoLocacaoParcelaSelecionada;
        Pag_Net.Bll.Operacionais.Locacao.Collection BLL;
        public UclLocacaoParcelasFinanceiro(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Operacionais.Locacao.Collection(MyConnect);
                FormFill();

            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FormFill()
        {
            DTPVENCIMENTO_INICIAL.SelectedDate = Convert.ToDateTime("01/01/1900");
            DTPVENCIMENTO_FINAL.SelectedDate = Convert.ToDateTime("31/12/2050");

        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                DTGContratoParcelas.ItemsSource = null;
                BLL.Financeiro.Select();
                DTGContratoFinanceiro.ItemsSource = BLL.Financeiro.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }

        }

        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TXTSEQCONTRATO_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXTSEQCONTRATO.Text.Trim() != "")
                {
                    BLL.Financeiro.Parametros.SeqContrato = Convert.ToInt32(TXTSEQCONTRATO.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valor Inválido: " + ex.Message);
            }
        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFinanceiro ContratoLocacaoFinanceiroSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFinanceiro;
                BLL.Parcelas.Parametros.SeqTitulo = ContratoLocacaoFinanceiroSelecionado.SeqTitulo;
                BLL.Parcelas.Select();
                DTGContratoParcelas.ItemsSource = BLL.Parcelas.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
            
        }

        private void DTPVENCIMENTO_INICIAL_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Financeiro.Parametros.DataVencimentoInicial = DTPVENCIMENTO_INICIAL.SelectedDate.Value;
        }

        private void DTPVENCIMENTO_FINAL_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Financeiro.Parametros.DataVencimentoFinal = DTPVENCIMENTO_FINAL.SelectedDate.Value;
        }


        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFinanceiro ItemSelecionadoParaComando = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFinanceiro;

                if (ItemSelecionadoParaComando.SelecionadoParaExecucaoDeComando)
                {
                    ItemSelecionadoParaComando.SelecionadoParaExecucaoDeComando = false;
                }
                else
                {
                    ItemSelecionadoParaComando.SelecionadoParaExecucaoDeComando = true;
                }
            }

            catch (Exception ex)
            {

            }
        }

        private void CMDTituloComandoLiquidar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ListaTitulos = "";
                int i = 0;
                foreach (Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFinanceiro item in ((Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFinanceiro[])DTGContratoFinanceiro.ItemsSource))
                {
                    if (item.SelecionadoParaExecucaoDeComando)
                    {
                        if (i == 0)
                        {
                            ListaTitulos = ListaTitulos + item.SeqTitulo.ToString();
                        }
                        else
                        {
                            ListaTitulos = ListaTitulos + "," + item.SeqTitulo.ToString();
                        }
                        i = i + 1;
                    }
                }

                if (i == 0)
                {
                    MessageBox.Show("Favor Selecionar algum Título para a execução de comandos!");
                }

                else
                {
                    Pag_Wpf.Financeiro.Titulo.FrmTituloComando frm = new Financeiro.Titulo.FrmTituloComando(MyConnect, ListaTitulos);
                    frm.ShowDialog();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }
}
