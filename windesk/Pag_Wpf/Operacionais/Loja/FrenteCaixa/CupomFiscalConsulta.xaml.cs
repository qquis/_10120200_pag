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



namespace Pag_Wpf.Operacionais
{
    /// <summary>
    /// Interaction logic for CupomFiscalConsulta.xaml
    /// </summary>
    public partial class CupomFiscalConsulta : Page
    {
        // Public Var's
        public Pag_Net.Models.modelSistemaUsuario MyConnection { get; set; }
        // Private Var's
        bllOperacaoSac _Bll;
        private TbCupons [] _lista;
        private TbCuponsItens[] _ListaCupomItens;
        private TbCuponsPagamentos[] _ListaCupomPagamentos;
        private TbCupons _CupomFiscalSelecionado;
        private TbOperacoesSac.TiposOperacaoSac _TipoOperacaoSac;
        private TbOperacoesSac[] _ListaOperacoesSac;
        int _EcfSelecao;
        int _CupomFiscalSelecao;

        // Instancia 
        public CupomFiscalConsulta(Pag_Net.Models.modelSistemaUsuario myConnection)
        {
            try
            {
                InitializeComponent();
                MyConnection = myConnection;

                _Bll = new bllOperacaoSac(myConnection);

                dtPickerIni.SelectedDate = DateTime.Now;
                dtPickerFim.SelectedDate = DateTime.Now;
                // teste
                // dtPickerIni.SelectedDate = Convert.ToDateTime("10/10/2012");
                //dtPickerFim.SelectedDate = Convert.ToDateTime("10/10/2012");
                ////////////////
                cmddevolucaoDi.IsEnabled = false;

                fillOperadores();
                fillECF();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Inicialização formulário: " + ex.Message.ToString());
            }
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            filLogFilerid();
        }
        private void cmdCupomFiscalDetalhes_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            _CupomFiscalSelecionado = ((FrameworkElement)sender).DataContext as TbCupons;
            _EcfSelecao = _CupomFiscalSelecionado.Ecf;
            _CupomFiscalSelecao = _CupomFiscalSelecionado.Cupom;
            filLogFileridCupomFiscalDetalhes();
            Mouse.OverrideCursor = x;
        }
        private void BtnNfe_Click(object sender, RoutedEventArgs e)
        {


            if (_CupomFiscalSelecionado.Devolucao == true || _CupomFiscalSelecionado.Nfe == true)
            {
                MessageBox.Show(string.Format("Já existem procedimentos lançados para o Cupom: {0}. Não é permitido o lançamento de mais de um procedimento por Cupom.", _CupomFiscalSelecionado.Cupom.ToString()), "Pag");
            }

            else
            {

                if (MessageBox.Show(string.Format("Confirma Emissão Nfe do Cupom selecionado?"), "PAG", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CupomFiscalDevolucao fCupomFiscalDevolucao = new CupomFiscalDevolucao(MyConnection, TbOperacoesSac.TiposOperacaoSac.EmiteNfe, _CupomFiscalSelecionado, null);
                    fCupomFiscalDevolucao.Show();
                }
            }
        }
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {


        }
        private void DataGridCupons_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _CupomFiscalSelecionado = null;
            filLogFileridCupomFiscalDetalhes();
        }
        private void cmddevolucaototal_Click(object sender, RoutedEventArgs e)
        {
            if (_CupomFiscalSelecionado == null) return;
            foreach (TbCuponsItens i in _ListaCupomItens)
            {
                i.Devolucao = true;
            }
            filLogFileridItens();
        }
        private void cmddevolucao_Click(object sender, RoutedEventArgs e)
        {
            _TipoOperacaoSac = TbOperacoesSac.TiposOperacaoSac.Devolucao;
           Devolucao();
        }
        private void cmddevolucaoDi_Click(object sender, RoutedEventArgs e)
        {
            _TipoOperacaoSac = TbOperacoesSac.TiposOperacaoSac.DevolucaoDinheiro;
            Devolucao();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            TbCuponsItens obj = ((FrameworkElement)sender).DataContext as TbCuponsItens;
            if (obj.Devolucao)
            {
                obj.Devolucao = false;
            }
            else
            {
                obj.Devolucao = true;
            }
        }
        private void Devolucao()
        {

            try
            {

                if (_CupomFiscalSelecionado == null)
                {
                    MessageBox.Show("Selecione um cupom fiscal, clicando no icone de <Detalhes>");
                    return;
                }

                if (_CupomFiscalSelecionado.Devolucao == true || _CupomFiscalSelecionado.Nfe == true)
                {
                    MessageBox.Show(string.Format("Já existem procedimentos lançados para o Cupom: {0}. Não é permitido o lançamento de mais de um procedimento por Cupom.", _CupomFiscalSelecionado.Cupom.ToString()), "Pag");
                    return;
                }

                if (_ListaCupomItens == null)
                {
                    MessageBox.Show("Selecione Iten(s) a serem devolvidos!", "PAG");
                    return;
                }

                if (_ListaCupomItens.Count() < 1)
                {
                    MessageBox.Show("Selecione Iten(s) a serem devolvidos!", "PAG");
                    return;
                }

                int t = 0;
                List<TbCuponsItens> _devolucaoItens = new List<TbCuponsItens>();

                foreach (TbCuponsItens i in _ListaCupomItens)
                {
                    if (i.Devolucao)
                    {
                        i.QtdeDevolvida = i.Qtde;
                        _devolucaoItens.Add(i);
                        t++;
                    }
                }

                if (t > 0)
                {
                    if (MessageBox.Show(string.Format("Confirma devolução do(s) {0} iten(s) selecionados?", t), "PAG", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        CupomFiscalDevolucao fCupomFiscalDevolucao = new CupomFiscalDevolucao(MyConnection, _TipoOperacaoSac, _CupomFiscalSelecionado, _devolucaoItens.ToArray());
                        fCupomFiscalDevolucao.ShowDialog();
                    }
                }
                filLogFilerid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void filLogFilerid()
        {

            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                double? ValorCupomFiscalIni = null;
                double? ValorCupomFiscalFim = null;
                double? ValorPgtoIni = null;
                double? ValorPgtoFim = null;
                bool? CuponsCancelados = chkCuponsCancelados.IsChecked;
                int? Cdoperador = null;
                int? ECF = null;
                int? CupomFiscal = null;

                if (txtValorCupomIni.Text.Trim() != "") ValorCupomFiscalIni = Convert.ToDouble(txtValorCupomIni.Text);
                if (txtValorCupomFim.Text.Trim() != "") ValorCupomFiscalFim = Convert.ToDouble(txtValorCupomIni.Text);
                if (txtvlPgtoIni.Text.Trim() != "") ValorPgtoIni = Convert.ToDouble(txtvlPgtoIni.Text);
                if (txtvlPgtoIni.Text.Trim() != "") ValorPgtoFim = Convert.ToDouble(txtvlPgtoFim.Text);
                if (cmbOperadores.Text != "") Cdoperador = Convert.ToInt32(((TbOperadores)cmbOperadores.SelectedItem).CdOperador.ToString());
                if (cmbECF.Text != "") ECF = Convert.ToInt32(((TbECF)cmbECF.SelectedItem).ECF.ToString());
                if (txtNumeroCupomFiscal.Text != "") CupomFiscal = Convert.ToInt32(txtNumeroCupomFiscal.Text);
                _lista = Pag_Net.Bll.Tables.bllTbCupons.GetList(MyConnection, dtPickerIni.SelectedDate.Value, dtPickerFim.SelectedDate.Value, ValorCupomFiscalIni, ValorCupomFiscalFim, ValorPgtoIni, ValorPgtoFim, CuponsCancelados, Cdoperador, ECF, CupomFiscal);
                DataGridCupons.ItemsSource = _lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Consulta Cupons: " + ex.Message.ToString(), "PAG");
                Mouse.OverrideCursor = x;
            }
            Mouse.OverrideCursor = x;
        }
        private void filLogFileridCupomFiscalDetalhes()
        {

            try
            {

                if (_CupomFiscalSelecionado != null)
                {
                    if (_CupomFiscalSelecionado.Ecf > 0 && _CupomFiscalSelecionado.Cupom > 0)
                    {
                        _ListaCupomItens = Pag_Net.Bll.Tables.bllTbCuponsItens.GetList(MyConnection, _CupomFiscalSelecionado.Ecf, _CupomFiscalSelecionado.Cupom, _CupomFiscalSelecionado.DataCupom);
                        _ListaCupomPagamentos = Pag_Net.Bll.Tables.bllTbCuponsPagamentos.GetList(MyConnection, _CupomFiscalSelecionado.Ecf, _CupomFiscalSelecionado.Cupom, _CupomFiscalSelecionado.DataCupom);

                        _Bll.Select(_CupomFiscalSelecionado.Ecf, _CupomFiscalSelecionado.Cupom);
                        _ListaOperacoesSac = _Bll.TbOperacaoSac;
                    }
                }
                else
                {
                    _ListaCupomItens = null;
                    _ListaCupomPagamentos = null;
                }

                filLogFileridItens();
                filLogFileridPagamentos();
                filLogFileridOperacoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void filLogFileridItens()
        {
            DataGridItens.ItemsSource = null;
            DataGridItens.ItemsSource = _ListaCupomItens;
        }
        private void filLogFileridPagamentos()
        {
            DataGridPgtos.ItemsSource = _ListaCupomPagamentos;
        }
        private void filLogFileridOperacoes()
        {
            DataGridOperacoesGerais.ItemsSource = _ListaOperacoesSac;
        }
        private void fillOperadores()
        {
            cmbOperadores.ItemsSource = Pag_Net.Bll.Tables.bllTbOperadores.GetList(MyConnection);

        }
        private void fillECF()
        {
            cmbECF.ItemsSource = Pag_Net.Bll.Tables.bllTbECF.GetList(MyConnection); cmbECF.SelectedIndex = 0;
        }
        private void BtnPOS_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                //MessageBox.Show(((TbCuponsPagamentos)DataGridPgtos.SelectedItem).CupomFiscal.ToString());
                if (((TbCuponsPagamentos)DataGridPgtos.SelectedItem).DescricaoFinalizadora == "POS")
                {
                    Operacionais.Varejo.SACPOSLanca _form = new Varejo.SACPOSLanca(MyConnection, ((TbCuponsPagamentos)DataGridPgtos.SelectedItem));
                    _form.ShowDialog();
                    filLogFileridCupomFiscalDetalhes();
                }
                else
                {
                    throw new Exception("Tipo de Lançamento diferente de POS");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        

        
    }
}
