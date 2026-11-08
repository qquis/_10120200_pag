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
using Pag_Net.Bll;
using Pag_Net.Models;

namespace Pag_Wpf.Operacionais.Loja.Execucao
{
    /// <summary>
    /// Interaction logic for UclAtualizacao.xaml
    /// </summary>
    public partial class UclAtualizacao : UserControl
    {

        private Pag_Net.Bll.Sistemas.Operacoes.Interface.Zanthus _InterfaceZanthus;
        private modelSistemaUsuario _Myconnect;
        public UclAtualizacao(modelSistemaUsuario myconnect)
        {
            InitializeComponent();
            _Myconnect = myconnect;
            _InterfaceZanthus = new Pag_Net.Bll.Sistemas.Operacoes.Interface.Zanthus(myconnect);
            Pag_Net.Bll.Tables.BllTbTipos x = new Pag_Net.Bll.Tables.BllTbTipos(_Myconnect);
            cmbTipo.ItemsSource = x.GetList("TbLogProdutoPreco", "CdTipoRegistro");
            if (Util.GetValueParametro(_Myconnect, "EXEC_ENVIO_DADOS_ZANTHUS", "m2114") == "1")
            {
                CMDEfetivar.IsEnabled = true;
            }
            else
            {
                CMDEfetivar.IsEnabled = false;
            }
            LBLInfoDIRETORIO_EXPORTACAO_ARQUIVO_MGV.Content = "Diretório de Exportação Arquivo MGV (BALANÇAS): " + Util.GetValueParametro(_Myconnect, "PagService_MGV_path_dir_txtitens", "m2114");

            dtPickerCadIni.SelectedDate = DateTime.Now;
            dtPickerCadFim.SelectedDate = DateTime.Now;
        }
        private void BtnEfetivar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Confirma envio de Produtos/Preços para os Pdv's?", "PAG", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }

            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {

                Mouse.OverrideCursor = Cursors.Wait;
                Pag_Net.Bll.Services.PagServiceZanthusProcessaEnvio.Processa(_Myconnect);

                this.RefleshBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = x;
        }
        private void RefleshBinding()
        {
            try
            {
                Pag_Net.Bll.Tables.bllTbLogTransacoes TbLogTransacoes = new Pag_Net.Bll.Tables.bllTbLogTransacoes(_Myconnect);
                DataGridListaEventosZanthus.ItemsSource = TbLogTransacoes.GetList(dtPickerCadIni.SelectedDate.Value.ToString(), dtPickerCadFim.SelectedDate.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            this.RefleshBinding();

        }
        private void BtnHistoricoItens_Click(object sender, RoutedEventArgs e)
        {

            RefleshBindingItem();
        }
        private void cmdInfoLogTransacao_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                txtFCodigoProduto.Text = "";
                txtFDescricaoProduto.Text = "";
                ModelTbLogTransacoes obj = ((FrameworkElement)sender).DataContext as ModelTbLogTransacoes;
                txtFSequencial.Text = obj.SeqLogTransacao.ToString();
                //dtProdItemIni.SelectedDate = obj.Data;
                // dtProdItemFim.SelectedDate = obj.Data;
                RefleshBindingItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = x;
        }
        private void RefleshBindingItem()
        {
            try
            {
                Pag_Net.Bll.Tables.bllTbErpZanthusLogProdutoPreco tblogprodutoprecos = new Pag_Net.Bll.Tables.bllTbErpZanthusLogProdutoPreco(_Myconnect);
                DataGridProdutos.ItemsSource = tblogprodutoprecos.GetList(
                            txtFSequencial.Text,
                            txtFCodigoProduto.Text,
                            txtFDescricaoProduto.Text,
                            Util.TiposGetSeq(cmbTipo.SelectedItem).ToString(),
                            dtPickerCadIni.SelectedDate.Value.ToString(),
                            dtPickerCadIni.SelectedDate.Value.ToString(),
                             "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnStatusItens_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _InterfaceZanthus.StatusProdutoPrecoServidores.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void StatusPag()
        {
            StatusPag("");

        }
        public void StatusPag(string message)
        {
            
            Mouse.OverrideCursor = Cursors.Arrow;
            if (message != "")
            {
                Mouse.OverrideCursor = Cursors.Wait;
            }
        }
        private void BtnStatusReport_Click(object sender, RoutedEventArgs e)
        {
            // ReportViewForm x = new ReportViewForm(_li);
            //x.Show();
        }
        private void CmdInicializaOperacaoComercial_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Pag_Net.Bll.Services.PagServicePrecosOperacionais.Processa(_Myconnect);
                _InterfaceZanthus.StatusProdutoPrecoComercial.Select();
                this.RefleshBinding();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Mouse.OverrideCursor = x;
        }
        private void cmdEtiquetas_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ModelTbLogTransacoes obj = ((FrameworkElement)sender).DataContext as ModelTbLogTransacoes;

            Pag_Net.Bll.Operacionais.Varejo.Execucao.EtiquetaGondola _BLLEtiquetaGondola = new Pag_Net.Bll.Operacionais.Varejo.Execucao.EtiquetaGondola(_Myconnect);
            _BLLEtiquetaGondola.List.Filtros.SequenciaisProcessamentos = obj.SeqLogTransacao.ToString();
            _BLLEtiquetaGondola.List.Select();

            Pag_Net.Bll.Operacionais.Varejo.Execucao.EtiquetaGondola.Imprimir(_BLLEtiquetaGondola.List.ViewData as Pag_Net.Bll.Operacionais.Varejo.Execucao.UVWEtiquetaGondola[]);

            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void CMDEfetivar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
