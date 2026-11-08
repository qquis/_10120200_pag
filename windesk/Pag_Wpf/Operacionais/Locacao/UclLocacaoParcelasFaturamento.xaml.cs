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
    /// Interaction logic for UclLocacaoParcelasFaturamento.xaml
    /// </summary>
    public partial class UclLocacaoParcelasFaturamento : UserControl
    {
        private modelSistemaUsuario MyConnect;
        private string FormularioMenu = "m2911";
        public Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoParcela ContratoLocacaoParcelaSelecionada;
        Pag_Net.Bll.Operacionais.Locacao.Collection BLL;

        public UclLocacaoParcelasFaturamento(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Operacionais.Locacao.Collection(MyConnect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CHKDataCadastro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Parcelas.Parametros.StatusFaturamento = CMBStatusFaturamento.Text.TrimEnd();
                BLL.Parcelas.Select();
                DTGContratosParcelas.ItemsSource = BLL.Parcelas.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void DTPCAD_INI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DTPCAD_FIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TXTDESCRICAO.Text.ToString().Trim() != "")
            {
                BLL.Parcelas.Parametros.DescricaoContrato = "";
                BLL.Parcelas.Parametros.DescricaoContrato = TXTDESCRICAO.Text.TrimEnd();
            }

        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                ContratoLocacaoParcelaSelecionada = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoParcela;
                BLL.Rubricas.Parametros.SeqContratoLocacaoParcela = ContratoLocacaoParcelaSelecionada.SeqContratoLocacaoParcela;
                BLL.Rubricas.Parametros.SeqContrato = ContratoLocacaoParcelaSelecionada.SeqContrato;
                BLL.Rubricas.Select();
                DTGContratoRubricas.ItemsSource = null;
                DTGContratoRubricas.ItemsSource = BLL.Rubricas.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch(Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDFATURAR_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                ContratoLocacaoParcelaSelecionada = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoParcela;
                if (ContratoLocacaoParcelaSelecionada.StatusFaturamento == "FATURADO" || ContratoLocacaoParcelaSelecionada.StatusFaturamento == "CANCELADO")
                {
                    MessageBox.Show("Operação Não permitida para Status Faturado ou Cancelado");
                    return;
                }
                if (MessageBox.Show("Confirma faturamento do Contrato: " + ContratoLocacaoParcelaSelecionada.SeqContrato.ToString() + " Parcela " + ContratoLocacaoParcelaSelecionada.NumeroOrdem.ToString(),"Locação - Faturamento de Parcela", MessageBoxButton.YesNo  ) == MessageBoxResult.Yes)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    BLL.Faturamento(ContratoLocacaoParcelaSelecionada.SeqContratoLocacaoParcela);
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
                MessageBox.Show("Parcela Faturada com sucesso! Os dados serão atualizados na Tela");
                CMDBuscar_Click(null,null);
                Mouse.OverrideCursor = Cursors.Arrow;

            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTSEQCONTRATO_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXTSEQCONTRATO.Text.ToString().Trim() != "")
                {
                    BLL.Parcelas.Parametros.SeqContrato = Convert.ToInt32(TXTSEQCONTRATO.Text);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Valor Inválido!");
                TXTSEQCONTRATO.Text = "";
            }
        }

        private void CHKDataFaturamento_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
