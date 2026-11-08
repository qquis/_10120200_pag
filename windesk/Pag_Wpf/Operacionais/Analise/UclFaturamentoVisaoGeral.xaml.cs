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
    /// Interaction logic for UclFaturamentoVisaoGeral.xaml
    /// </summary>
    public partial class UclFaturamentoVisaoGeral : UserControl
    {
        public modelSistemaUsuario MyConnection;
        private string FormularioMenu = "m2412";

        public Pag_Net.Bll.Operacionais.Analise.Consulta BLL;
        public UclFaturamentoVisaoGeral(modelSistemaUsuario myConnection)
        {
            InitializeComponent();

            //CollectionsFill();
            //ScreenFill();
            BLL = new Pag_Net.Bll.Operacionais.Analise.Consulta(myConnection);
            MyConnection = myConnection;

            cmbOperacao.ItemsSource = Pag_Net.Bll.Operacoes.Get(MyConnection.Operacoes, FormularioMenu); 
            cmbOperacao.SelectedIndex = 0;

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


            CMBProdutoCategoria.ItemsSource = BLL.Cadastros.Categoria.ViewData;

            cmbVendedor.ItemsSource = BLL.Cadastros.Vendedores.ViewData;

            //cmbVendedor.DataContext = Pag_Net.Bll.Participante.List.Start(MyConnection, "VENDEDOR");

            //CMBProdutoGestor.ItemsSource = BLL.Cadastros.Gestor.ViewData;

            dtPickerCadIni.SelectedDate = DateTime.Now.Date;
            dtPickerCadFim.SelectedDate = DateTime.Now.Date;

            BLL.Faturamento.PropertyChanged += new PropertyChangedEventHandler(BllFaturamento_OnList);

            optTipoVolumeEmbalagemEstoque.IsChecked = true;
            OptTodos.IsChecked = true;
            //DataGridFaturamentoOperacional.Columns[0].Visibility = Visibility.Hidden;

            CMBTipoPesquisa.SelectedIndex = 0;
        }

        private void dtPickerCadIni_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.DataInicial = dtPickerCadIni.SelectedDate.Value;
        }
        private void dtPickerCadFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.DataFinal = dtPickerCadFim.SelectedDate.Value;
        }
        private void BllFaturamento_OnList(object sender, PropertyChangedEventArgs e)
        {
            LblTotalVolume.Content = BLL.Faturamento.TotalVolume.ToString("#,##0.00");
            LblTotalItens.Content = BLL.Faturamento.TotalItens.ToString("#,##0");
            LblCusto.Content = BLL.Faturamento.TotalCusto.ToString("#,##0.00");
            
            LblFaturamentoLiquido.Content = BLL.Faturamento.TotalFaturamentoLiquido.ToString("#,##0.00");
            LblFaturamentoLiquidoMargem.Content = BLL.Faturamento.TotalFaturamentoLiquidoMargem.ToString("#,##0.00");
            LblMargemLiquida.Content = BLL.Faturamento.TotalMargemLiquida.ToString("#,##0.00");

            LblFaturamentoOperacional.Content = BLL.Faturamento.TotalFaturamentoOperacional.ToString("#,##0.00");
            LblFaturamentoOperacionalMargem.Content = BLL.Faturamento.TotalFaturamentoOperacionalMargem.ToString("#,##0.00");
            LblMargemOperacional.Content = BLL.Faturamento.TotalMargemOperacional.ToString("#,##0.00");
            LblCustoSubsidio.Content = BLL.Faturamento.TotalCustoSubsidio.ToString("#,##0.00");
            DataGridFaturamentoOperacional.ItemsSource = BLL.Faturamento.ViewData;
        }
        private void cmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
            if (cmbDepartamento.SelectedItem != null)
            {
                BLL.Faturamento.Filtros.Departamento = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
            }
        }
        private void cmbSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                BLL.Faturamento.Filtros.Secao = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;
            }
        }
        private void cmbLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLinha.SelectedItem != null)
            {
                BLL.Faturamento.Filtros.Linha = ((Pag_Net.Bll.Cadastros.Linha)cmbLinha.SelectedItem).CdProdutoLinha;
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
            BLL.Faturamento.Filtros.Fabricante = ((Pag_Net.Bll.Cadastros.UVWFabricante)cmbFabricante.SelectedItem).CdFabricante;
        }
        private void cmbVendedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.Vendedor = ((Pag_Net.Bll.Cadastros.UVWParticipantes)cmbVendedor.SelectedItem).CdParticipante;
        }
        private void txtFNomeCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.NomeCliente = txtFNomeCliente.Text;
        }
        private void optTipoVolumeEmbalagemCompra_Checked(object sender, RoutedEventArgs e)
        {
            if (optTipoVolumeEmbalagemCompra.IsChecked == true)
            {
                BLL.Faturamento.Filtros.EmbalagemFornecedor = true;
            }
            else
            {
                BLL.Faturamento.Filtros.EmbalagemFornecedor = false;
            }
        }
        private void optTipoVolumeEmbalagemEstoque_Checked(object sender, RoutedEventArgs e)
        {
            if (optTipoVolumeEmbalagemEstoque.IsChecked == true)
            {
                BLL.Faturamento.Filtros.EmbalagemFornecedor = false;
            }
            else
            {
                BLL.Faturamento.Filtros.EmbalagemFornecedor = true;
            }
        }
        private void OptFaturados_Checked(object sender, RoutedEventArgs e)
        {
            BLL.Faturamento.Filtros.StatusFaturamento = "FA";
        }
        private void OptEmAberto_Checked(object sender, RoutedEventArgs e)
        {
            BLL.Faturamento.Filtros.StatusFaturamento = "AB";
        }
        private void OptTodos_Checked(object sender, RoutedEventArgs e)
        {
            BLL.Faturamento.Filtros.StatusFaturamento = "TD";
        }
        private void txtdescricaoProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.DescricaoProduto = txtdescricaoProduto.Text;
        }
        private void txtcodigoproduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.ProdutosCodigoLista = txtcodigoproduto.Text;
        }
        private void txtNumerosPedidos_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.NumerosPedidos = txtNumerosPedidos.Text;
        }
        private void cmbOperacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.CdOperacao = ((Pag_Net.Models.TbSysTbOperacoes)cmbOperacao.SelectedItem).CdOperacao;
        }
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            if (BLL.Faturamento.ViewData == null)
            {
                MessageBox.Show("Não há dados para impressão!", "PAG");
            }
            else
            {
                Pag_Wpf.ReportViewForm ReportBrandao = new ReportViewForm(BLL.Faturamento.ViewData, "Pag_Wpf.ReportForm.rptTbFaturamento.rdlc", "DataSetTbFaturamento");

                ReportBrandao.ShowDialog();

            }
        }
        private void DataGridFaturamentoOperacional_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                Pag_Net.Bll.Operacionais.Analise.FaturamentoItem item = DataGridFaturamentoOperacional.SelectedItem as Pag_Net.Bll.Operacionais.Analise.FaturamentoItem;
                if (item != null)
                {


                    // DataGrid dataGrid = sender as DataGrid;
                    // DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                    // string x =  dataGrid.Columns[0].GetCellContent(row).
                    //int cdProduto = Convert.ToInt32(((TextBlock)RowColumn.Content).Text);




                    //LBLITEMFaturamentoBase.Content = item.FaturamentoBase.ToString("#,###,##0.00");
                    //LBLITEMFaturamento.Content = item.Faturamento.ToString("#,###,##0.00");
                    //LBLITEMFaturamentoBruto.Content = item.FaturamentoOperacional.ToString("#,###,##0.00");
                    //LBLITEMDescontosFinanceiros.Content = item.DescontosFinanceiros.ToString("#,###,##0.00");
                    //LBLITEMMargemBruta.Content = item.MargemFaturamentoBruto.ToString("#,###,##0.00");
                    //LBLITEMMargemFaturamento.Content = item.MargemFaturamento.ToString("#,###,##0.00");
                    //LBLITEMSubsidiosCorrentes.Content = item.SubsidiosCorrentes.ToString("#,###,##0.00");
                    //LBLITEMFaturamentoLiquido.Content = item.FaturamentoLiquido.ToString("#,###,##0.00");
                    //LBLITEMSubsdiosAplicados.Content = item.SubsidiosAplicados.ToString("#,###,##0.00");
                    //LBLITEMMargemFaturamentoLiquido.Content = item.MargemFaturamentoLiquido.ToString("#,###,##0.00");
                    //LBLITEMTicketMedio.Content = item.TicketMedio.ToString("#,###,##0.00");

                }
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CMBProdutoGestor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.SeqProdutoGestor = ((Pag_Net.Bll.Cadastros.UVWProdutoGestor)CMBProdutoGestor.SelectedItem).SeqProdutoGestor;
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
                    case 0: BLL.Faturamento.Filtros.TipoPesquisa = "PRODUTO"; break;
                    case 1: BLL.Faturamento.Filtros.TipoPesquisa = "DEPARTAMENTO"; break;
                    case 2: BLL.Faturamento.Filtros.TipoPesquisa = "SECAO"; break;
                    case 3: BLL.Faturamento.Filtros.TipoPesquisa = "LINHA"; break;
                    case 4: BLL.Faturamento.Filtros.TipoPesquisa = "PRODUTOGESTOR"; break;
                    case 5: BLL.Faturamento.Filtros.TipoPesquisa = "FABRICANTE"; break;
                    case 6: BLL.Faturamento.Filtros.TipoPesquisa = "CLIENTE"; break;
                    case 7: BLL.Faturamento.Filtros.TipoPesquisa = "VENDEDOR"; break;
                    //case 8: BLL.Faturamento.Filtros.TipoPesquisa = "EQUIPE"; break;
                    case 9: BLL.Faturamento.Filtros.TipoPesquisa = "EMPRESA"; break;
                    case 10: BLL.Faturamento.Filtros.TipoPesquisa = "DATA"; break;
                    case 11: BLL.Faturamento.Filtros.TipoPesquisa = "PEDIDOCUPOM"; break;
                    case 12: BLL.Faturamento.Filtros.TipoPesquisa = "CATEGORIA"; break;
                    case 13: BLL.Faturamento.Filtros.TipoPesquisa = "PRAZODEPAGAMENTO"; break;
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
                if (chkTipoProduto.IsChecked == true )
                {
                    BLL.Faturamento.Filtros.OperacoesComOutrosTiposDeProduto = 1;
                }
                else
                {
                    BLL.Faturamento.Filtros.OperacoesComOutrosTiposDeProduto = 0;
                }
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Faturamento.Select();
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

        private void CMBProdutoCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBProdutoCategoria.SelectedItem != null)
            {
                BLL.Faturamento.Filtros.SeqProdutoCategoria = ((Pag_Net.Bll.Cadastros.VWProdutoCategoria)CMBProdutoCategoria.SelectedItem).SeqProdutoCategoria;
            }
        }

        private void chkBlueSoft_Checked(object sender, RoutedEventArgs e)
        {
            if (chkBlueSoft.IsChecked == true)
            {
                BLL.Faturamento.Filtros.FvBlueSoft = 1;
            }
            else
            {
                BLL.Faturamento.Filtros.FvBlueSoft = 0;
            }
        
        
        }

        private void chkBlueSoft_Click(object sender, RoutedEventArgs e)
        {
            if (chkBlueSoft.IsChecked == true)
            {
                BLL.Faturamento.Filtros.FvBlueSoft = 1;
            }
            else
            {
                BLL.Faturamento.Filtros.FvBlueSoft = 0;
            }
        }

        private void CMDBuscar_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}

