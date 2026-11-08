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
    /// Interaction logic for UclFaturamentoData.xaml
    /// </summary>
    public partial class UclFaturamentoData : UserControl
    {
        private modelSistemaUsuario MyConnection;
        private string FormularioMenu = "m2411";

        public Pag_Net.Bll.Operacionais.Analise.Consulta BLL;
        public UclFaturamentoData(modelSistemaUsuario __myConnection)
        {
            InitializeComponent();
            MyConnection = __myConnection;


            BLL = new Pag_Net.Bll.Operacionais.Analise.Consulta(MyConnection);

            fillgrafico();

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

            cmbVendedor.ItemsSource = BLL.Cadastros.Vendedores.ViewData;
            CMBProdutoGestor.ItemsSource = BLL.Cadastros.Gestor.ViewData;

            dtPickerCadIni.SelectedDate = DateTime.Now.Date;
            dtPickerCadFim.SelectedDate = DateTime.Now.Date;

            BLL.Faturamento.PropertyChanged += new PropertyChangedEventHandler(BllFaturamento_OnList);

            optTipoVolumeEmbalagemEstoque.IsChecked = true;

            OptTodos.IsChecked = true;
            BLL.Faturamento.Filtros.TipoPesquisa = "DATA";
            Mouse.OverrideCursor = Cursors.Wait;
            BLL.Faturamento.Select();
            fillgrafico();
            Mouse.OverrideCursor = Cursors.Arrow;

        }
        private void Select(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                switch (((UserControl)sender).Name.Trim())
                {

                    case "CMDBuscarFaturamentoDiario": BLL.Faturamento.Filtros.TipoPesquisa = "DATA"; break;
                    case "CMDBuscarFaturamentoMensal": BLL.Faturamento.Filtros.TipoPesquisa = "MES"; break;

                }
                // ((Button)sender).IsEnabled = false;
                BLL.Faturamento.Select();
                fillgrafico();
                //((Button)sender).IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            Mouse.OverrideCursor = Cursors.Arrow;

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
            DataGridFaturamentoOperacional.ItemsSource = BLL.Faturamento.ViewData;
            LblFaturamentoLiquido.Content = BLL.Faturamento.TotalFaturamentoLiquido.ToString("#,##0.00");
            LblFaturamentoLiquidoMargem.Content = BLL.Faturamento.TotalFaturamentoLiquidoMargem.ToString("#,##0.00");
            LblMargemLiquida.Content = BLL.Faturamento.TotalMargemLiquida.ToString("#,##0.00");
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
        private void fillgrafico()
        {


            List<KeyValuePair<string, double>> l1 = new List<KeyValuePair<string, double>>();
            List<KeyValuePair<string, double>> l2 = new List<KeyValuePair<string, double>>();
            if (BLL.Faturamento.ViewData == null)
            {
                l1.Add(new KeyValuePair<string, double>(DateTime.Now.ToShortDateString(), 1));
                l2.Add(new KeyValuePair<string, double>(DateTime.Now.ToShortDateString(), 1));
            }
            else
            {
                foreach (Pag_Net.Bll.Operacionais.Analise.FaturamentoItem i in BLL.Faturamento.ViewData)
                {
                    l1.Add(new KeyValuePair<string, double>(i.Descricao.Substring(0, 2), i.FaturamentoLiquido));
                    l2.Add(new KeyValuePair<string, double>(i.Descricao.Substring(0, 2), i.MargemFaturamentoLiquido));
                }
            }
            var dataSourceList = new List<List<KeyValuePair<string, double>>>();
            dataSourceList.Add(l1);
            dataSourceList.Add(l2);
            mcChart.DataContext = dataSourceList;

        }
        private void CMBProdutoGestor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Faturamento.Filtros.SeqProdutoGestor = ((Pag_Net.Bll.Cadastros.UVWProdutoGestor)CMBProdutoGestor.SelectedItem).SeqProdutoGestor;
        }


    }
}
