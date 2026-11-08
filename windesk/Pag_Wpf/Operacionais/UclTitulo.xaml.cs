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

namespace Pag_Wpf.Financeiro.Titulo
{
    /// <summary>
    /// Interaction logic for UclTitulo.xaml
    /// </summary>
    public partial class UclTitulo : UserControl
    {
        private modelSistemaUsuario MyConnect;
        private string FormularioMenu = "m5210";
        Pag_Net.Bll.Financeiro.Titulos.UspTitulos BLL;

        public UclTitulo(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Financeiro.Titulos.UspTitulos(MyConnect);
                FormFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormFill()
        {
            DTPDataEmissaoINI.SelectedDate = DateTime.Now;
            DTPDataEmissaoFIM.SelectedDate = DateTime.Now;
            DTPDataVencimentoINI.SelectedDate = DateTime.Now;
            DTPDataVencimentoFIM.SelectedDate = DateTime.Now;
            BLL.Parametros.DataEmissao = DateTime.Now;
            BLL.Parametros.DataEmissaoFinal = DateTime.Now;
            BLL.Parametros.DataVencimento = Convert.ToDateTime("01/01/1900");
            BLL.Parametros.DataVencimentoFinal = Convert.ToDateTime("01/01/1900");
            CHKDataVencimento.IsChecked = false;
            CHKDataEmissao.IsChecked = true;
            DTPDataVencimentoINI.IsEnabled = false;
            DTPDataVencimentoFIM.IsEnabled = false;
            CMBTipoSituacao.ItemsSource = Pag_Net.Bll.Util.TiposGet(MyConnect.Tipos, "TbTitulo", "SeqTipoSituacaoTitulo");
            CMBOperacao.ItemsSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, "m5210");
            

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Select();
                DTGTitulos.ItemsSource = BLL.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }

        }

        private void CHKDataEmissao_Click(object sender, RoutedEventArgs e)
        {
            if (CHKDataEmissao.IsChecked.Value)
            {
                DTPDataEmissaoINI.IsEnabled = true;
                DTPDataEmissaoFIM.IsEnabled = true;
                DTPDataEmissaoINI.SelectedDate = DateTime.Now;
                DTPDataEmissaoFIM.SelectedDate = DateTime.Now;
            }
            else
            {
                DTPDataEmissaoINI.IsEnabled = false;
                DTPDataEmissaoFIM.IsEnabled = false;
                BLL.Parametros.DataEmissao = Convert.ToDateTime("01/01/1900");
                BLL.Parametros.DataEmissaoFinal = Convert.ToDateTime("01/01/1900");

            }

        }

        private void CHKDataVencimento_Click(object sender, RoutedEventArgs e)
        {

            if (CHKDataVencimento.IsChecked.Value)
            {
                DTPDataVencimentoINI.IsEnabled = true;
                DTPDataVencimentoFIM.IsEnabled = true;
                DTPDataVencimentoINI.SelectedDate = DateTime.Now;
                DTPDataVencimentoFIM.SelectedDate = DateTime.Now;
            }
            else
            {
                DTPDataVencimentoINI.IsEnabled = false;
                DTPDataVencimentoFIM.IsEnabled = false;
                BLL.Parametros.DataVencimento = Convert.ToDateTime("01/01/1900");
                BLL.Parametros.DataVencimentoFinal = Convert.ToDateTime("01/01/1900");

            }
        }

        private void DTPDataEmissaoINI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Parametros.DataEmissao = DTPDataEmissaoINI.SelectedDate.Value;

        }

        private void DTPDataEmissaoFIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Parametros.DataEmissaoFinal = DTPDataEmissaoFIM.SelectedDate.Value;
        }

        private void DTPDataVencimentoINI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Parametros.DataVencimento = DTPDataVencimentoINI.SelectedDate.Value;
        }

        private void DTPDataVencimentoFIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Parametros.DataVencimentoFinal = DTPDataVencimentoFIM.SelectedDate.Value;
        }

        private void TXTValorIni_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXTValorIni.Text.Trim() != "")
                {
                    BLL.Parametros.Valor = Convert.ToDouble(TXTValorIni.Text);
                }
                else
                {
                    BLL.Parametros.Valor = 0;
                }
            }
            catch(Exception ex)
            {
                TXTValorIni.Text = "";
                MessageBox.Show(ex.Message);
            }

        }

        private void TXTValorFim_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXTValorFim.Text.Trim() != "")
                {
                    BLL.Parametros.ValorFinal = Convert.ToDouble(TXTValorFim.Text);
                }
                else
                {
                    BLL.Parametros.Valor = 0;
                }
            }
            catch (Exception ex)
            {
                TXTValorFim.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTValorSaldoIni_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXTValorSaldoIni.Text.Trim() != "")
                {
                    BLL.Parametros.ValorSaldo = Convert.ToDouble(TXTValorSaldoIni.Text);
                }
                else
                {
                    BLL.Parametros.Valor = 0;
                }
            }
            catch (Exception ex)
            {
                TXTValorSaldoIni.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTValorSaldoFim_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXTValorSaldoFim.Text.Trim() != "")
                {
                    BLL.Parametros.ValorSaldoFinal = Convert.ToDouble(TXTValorSaldoFim.Text);
                }
                else
                {
                    BLL.Parametros.Valor = 0;
                }
            }
            catch (Exception ex)
            {
                TXTValorSaldoFim.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

 
    }
}
