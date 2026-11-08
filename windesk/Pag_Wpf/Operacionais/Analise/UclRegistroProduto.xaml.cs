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
using System.ComponentModel;


namespace Pag_Wpf.Operacionais.Analise
{
    /// <summary>
    /// Interaction logic for UclRegistroProduto.xaml
    /// </summary>
    public partial class UclRegistroProduto : UserControl
    {
        public modelSistemaUsuario MyConnection { get; set; }
        public Pag_Net.Bll.Operacionais.Analise.Consulta BLL;
        public UclRegistroProduto(modelSistemaUsuario myConnection)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Operacionais.Analise.Consulta(myConnection);

            cmbDepartamento.ItemsSource = BLL.Cadastros.ProdutosComplementos.Departamento;
            cmbSecao.ItemsSource = BLL.Cadastros.ProdutosComplementos.Secao;
            cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;

            if (BLL.Cadastros.ProdutosComplementos.Departamento.Count() <= 1)
            {
                cmbDepartamento.IsEnabled = false;
                cmbDepartamento.SelectedIndex = 0;
            }

            if (BLL.Cadastros.ProdutosComplementos.Secao.Count() <= 1)
            {
                cmbSecao.IsEnabled = false;
                cmbSecao.SelectedIndex = 0;
            }

            if (BLL.Cadastros.ProdutosComplementos.Linha.Count() <= 1)
            {
                cmbLinha.IsEnabled = false;
                cmbLinha.SelectedIndex = 0;
            }

            cmbFabricante.ItemsSource = BLL.Cadastros.Fabricante.ViewData;
            CMBProdutoGestor.ItemsSource = BLL.Cadastros.Gestor.ViewData;

            Pag_Net.Bll.Tables.BllTbTipos x = new Pag_Net.Bll.Tables.BllTbTipos(myConnection);
            cmbTipo.ItemsSource = x.GetList("TbRegistroProduto", "SeqRegistroProduto");

            dtPickerCadIni.SelectedDate = DateTime.Now.Date;
            dtPickerCadFim.SelectedDate = DateTime.Now.Date;

            BLL.RegistroProduto.PropertyChanged += new PropertyChangedEventHandler(BllFaturamento_OnList);
            CMBTipoPesquisa.SelectedIndex = 0;

        }

        /*
        private void Select(object sender, RoutedEventArgs e)
        {
            DataGridFaturamentoOperacional.ItemsSource = null;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {

                switch (((Button)sender).Name.Trim())
                {
                    case "cmdtpPesquisaEmpresa": BLL.RegistroProduto.Filtros.TipoPesquisa = "EMPRESA"; break;
                    case "cmdtpPesquisaProduto": BLL.RegistroProduto.Filtros.TipoPesquisa = "PRODUTO"; break;
                    case "cmdtpPesquisaDepartamento": BLL.RegistroProduto.Filtros.TipoPesquisa = "DEPARTAMENTO"; break;
                    case "cmdtpPesquisaSecao": BLL.RegistroProduto.Filtros.TipoPesquisa = "SECAO"; break;
                    case "cmdtpPesquisaLinha": BLL.RegistroProduto.Filtros.TipoPesquisa = "LINHA"; break;
                    case "cmdtpPesquisaData": BLL.RegistroProduto.Filtros.TipoPesquisa = "DATA"; break;
                    case "cmdtpPesquisaFabricante": BLL.RegistroProduto.Filtros.TipoPesquisa = "FABRICANTE"; break;
                    case "cmdtpPesquisaMes": BLL.RegistroProduto.Filtros.TipoPesquisa = "MES"; break;
                    case "cmdtpPesquisaProdutoGestor": BLL.RegistroProduto.Filtros.TipoPesquisa = "PRODUTOGESTOR"; break;

                }
                ((Button)sender).IsEnabled = false;
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.RegistroProduto.Select();
                Mouse.OverrideCursor = Cursors.Arrow;
                ((Button)sender).IsEnabled = true;
            }
            catch (Exception ex)
            {
                ((Button)sender).IsEnabled = true;
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            Mouse.OverrideCursor = Cursors.Arrow;

        }
        */


        private void dtPickerCadIni_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.RegistroProduto.Filtros.DataInicial = dtPickerCadIni.SelectedDate.Value;
        }
        private void dtPickerCadFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.RegistroProduto.Filtros.DataFinal = dtPickerCadFim.SelectedDate.Value;
        }
        private void BllFaturamento_OnList(object sender, PropertyChangedEventArgs e)
        {
            DataGridFaturamentoOperacional.ItemsSource = BLL.RegistroProduto.ViewData;
            LblTotalVolume.Content = BLL.RegistroProduto.TotalVolume.ToString("#,##0.00");
            LblItens.Content = BLL.RegistroProduto.ViewData.Count();
            LblCusto.Content = BLL.RegistroProduto.TotalValorCustoPadrao.ToString("#,##0.00");
        }
        private void cmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
            if (cmbDepartamento.SelectedItem != null)
            {
                BLL.RegistroProduto.Filtros.Departamento = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
            }
        }
        private void cmbSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                BLL.RegistroProduto.Filtros.Secao = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;
            }
        }
        private void cmbLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLinha.SelectedItem != null)
            {
                BLL.RegistroProduto.Filtros.Linha = ((Pag_Net.Bll.Cadastros.Linha)cmbLinha.SelectedItem).CdProdutoLinha;
            }
        }
        private void cmbDepartamento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbDepartamento.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
                cmbSecao.ItemsSource = BLL.Cadastros.ProdutosComplementos.Secao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }
            else
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = "";
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
                cmbSecao.ItemsSource = BLL.Cadastros.ProdutosComplementos.Secao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }

        }
        private void cmbSecao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }

            if (cmbLinha.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;

            }
        }
        private void cmbFabricante_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.RegistroProduto.Filtros.Fabricante = ((Pag_Net.Bll.Cadastros.UVWFabricante)cmbFabricante.SelectedItem).CdFabricante;
        }
        private void txtdescricaoProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.RegistroProduto.Filtros.DescricaoProduto = txtdescricaoProduto.Text;
        }
        private void txtcodigoproduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.RegistroProduto.Filtros.ProdutosCodigoLista = txtcodigoproduto.Text;
        }
        private void DataGridFaturamentoOperacional_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void CMBProdutoGestor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.RegistroProduto.Filtros.SeqProdutoGestor = ((Pag_Net.Bll.Cadastros.UVWProdutoGestor)CMBProdutoGestor.SelectedItem).SeqProdutoGestor;
        }
        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.RegistroProduto.Filtros.SeqTipoRegistroProduto = Convert.ToInt32(Util.TiposGetSeq(cmbTipo.SelectedItem).ToString());
        }
        private void CMBTipoPesquisa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {

                DataGridFaturamentoOperacional.ItemsSource = null;
                int TipoPesquisa = CMBTipoPesquisa.SelectedIndex;
                switch (TipoPesquisa)
                {
                    case 0: BLL.RegistroProduto.Filtros.TipoPesquisa = "PRODUTO"; break;
                    case 1: BLL.RegistroProduto.Filtros.TipoPesquisa = "DEPARTAMENTO"; break;
                    case 2: BLL.RegistroProduto.Filtros.TipoPesquisa = "SECAO"; break;
                    case 3: BLL.RegistroProduto.Filtros.TipoPesquisa = "LINHA"; break;
                    case 4: BLL.RegistroProduto.Filtros.TipoPesquisa = "PRODUTOGESTOR"; break;
                    case 5: BLL.RegistroProduto.Filtros.TipoPesquisa = "FABRICANTE"; break;
                    case 6: BLL.RegistroProduto.Filtros.TipoPesquisa = "EMPRESA"; break;
                    case 7: BLL.RegistroProduto.Filtros.TipoPesquisa = "DATA"; break;
                    case 8: BLL.RegistroProduto.Filtros.TipoPesquisa = "MES"; break;
                }
                this.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void Select()
        {

            Mouse.OverrideCursor = Cursors.Wait;
            try
            {


                Mouse.OverrideCursor = Cursors.Wait;
                BLL.RegistroProduto.Select();
                Mouse.OverrideCursor = Cursors.Arrow;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            Mouse.OverrideCursor = Cursors.Arrow;


        }
        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            this.Select();
        }
    }
}
