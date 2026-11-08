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
using Pag_Net.Bll.Sac;


namespace Pag_Wpf.Operacionais.Loja.Sac
{
    /// <summary>
    /// Interaction logic for UclSACFinanceiro.xaml
    /// </summary>
    public partial class UclSACFinanceiro : UserControl
    {
        private Pag_Net.Bll.Operacionais.Varejo.Sac.UspOperacaoSacSuprimentos Suprimentos;
        public Pag_Net.Models.modelSistemaUsuario  _MyConnection { get; set; }
        private TbOperacoesSacOperadoresAtivos _TbOperacaoSacOperadorAtivoSelecionado;
        public UclSACFinanceiro(Pag_Net.Models.modelSistemaUsuario _myConnection)
        {
            InitializeComponent();
            _MyConnection = _myConnection;
            dtPickerSelecao.SelectedDate = DateTime.Now;
            _TbOperacaoSacOperadorAtivoSelecionado = new TbOperacoesSacOperadoresAtivos();
            Suprimentos = new Pag_Net.Bll.Operacionais.Varejo.Sac.UspOperacaoSacSuprimentos(_myConnection);
        }
        private void BtnOperadoresAtivos_Click(object sender, RoutedEventArgs e)
        {
            FillOperacaoAtiva();
        }
        private void cmdOperacaoDetalhes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor x = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;
                _TbOperacaoSacOperadorAtivoSelecionado = ((FrameworkElement)sender).DataContext as TbOperacoesSacOperadoresAtivos;
                FillOperacaoSacFinalizadora();
                FillOperacaoSacProdutoFinanceiro();
                FillOperacaoSacProdutoFinanceiroItem();
                FillOperacaoSacDetalhes();
                lblNomeOperador.Content = _TbOperacaoSacOperadorAtivoSelecionado.NomeOperador;
                lblECF.Content = _TbOperacaoSacOperadorAtivoSelecionado.ECF;
                lblRegistros.Content = _TbOperacaoSacOperadorAtivoSelecionado.Registros.ToString();
                Suprimentos.Operador = _TbOperacaoSacOperadorAtivoSelecionado.CdOperador;
                Suprimentos.Data = dtPickerSelecao.SelectedDate.Value;
                Suprimentos.ECF = _TbOperacaoSacOperadorAtivoSelecionado.ECF;
                Suprimentos.Select();
                DataGridSuprimentos.ItemsSource = Suprimentos.ViewData;
                LblTotalVolume.Content = Suprimentos.TOTALSALDO.ToString("0");


                Mouse.OverrideCursor = x;
            }
            catch( Exception ex )
            {

                MessageBox.Show(ex.Message.ToString());
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }
        private void FillOperacaoAtiva()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DataGridOperacaoAtiva.ItemsSource = bllOperacaoSacOperadoresAtivos.Select(_MyConnection, dtPickerSelecao.SelectedDate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Seleção de Operadores ativos: " + ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void FillOperacaoSacFinalizadora()
        {
            DataGridFinalizadora.ItemsSource = bllOperacaoSacFinanceiro.Select(_MyConnection, dtPickerSelecao.SelectedDate.Value, TbOperacoesSacFinanceiro.TipoInformacao.ResumoRecebimentoFinalizadora, _TbOperacaoSacOperadorAtivoSelecionado.CdOperador, _TbOperacaoSacOperadorAtivoSelecionado.ECF, null  );
        }
        private void FillOperacaoSacProdutoFinanceiro()
        {
            DataGridProdutoFinanceiro.ItemsSource = bllOperacaoSacFinanceiro.Select(_MyConnection, dtPickerSelecao.SelectedDate.Value, TbOperacoesSacFinanceiro.TipoInformacao.ResumoFinalizadoraProdutoFinanceiro, _TbOperacaoSacOperadorAtivoSelecionado.CdOperador, _TbOperacaoSacOperadorAtivoSelecionado.ECF, null);
        }
        private void FillOperacaoSacProdutoFinanceiroItem()
        {
            DataGridProdutoFinanceiroItem.ItemsSource = bllOperacaoSacFinanceiro.Select(_MyConnection, dtPickerSelecao.SelectedDate.Value, TbOperacoesSacFinanceiro.TipoInformacao.ResumoRecebimentoProdutoFinanceiro, _TbOperacaoSacOperadorAtivoSelecionado.CdOperador, _TbOperacaoSacOperadorAtivoSelecionado.ECF, null);
        }
        private void FillOperacaoSacDetalhes()
        {
            lblentrada.Content = string.Format("{0:0.0}", _TbOperacaoSacOperadorAtivoSelecionado.ValorEntrada.ToString());
            lblreforco.Content = _TbOperacaoSacOperadorAtivoSelecionado.ValorReforco.ToString();
            lblfaturamento.Content = _TbOperacaoSacOperadorAtivoSelecionado.ValorFaturamentoDinheiro.ToString();
            lblsangria.Content = _TbOperacaoSacOperadorAtivoSelecionado.ValorSangria.ToString();
            lblsaldo.Content = _TbOperacaoSacOperadorAtivoSelecionado.ValorSaldo.ToString();
            DataGridDetalhes.ItemsSource = bllOperacaoSacFinanceiro.Select(_MyConnection, dtPickerSelecao.SelectedDate.Value, TbOperacoesSacFinanceiro.TipoInformacao.DetalheRecebimentos, _TbOperacaoSacOperadorAtivoSelecionado.CdOperador, _TbOperacaoSacOperadorAtivoSelecionado.ECF, null);
        }
    }
}
