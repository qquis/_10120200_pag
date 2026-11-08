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
    /// Interaction logic for UclRegistroProdutoData.xaml
    /// </summary>
    public partial class UclRegistroProdutoData : UserControl
    {
        public modelSistemaUsuario MyConnection { get; set; }
        public Pag_Net.Bll.Operacionais.Analise.Consulta BLL;
        public UclRegistroProdutoData(modelSistemaUsuario myConnection)
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

            fillgrafico();
        }

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
            //LblTotalVolume.Content = BLL.RegistroProduto.TotalVolume.ToString("#,##0.00");
            //LblItens.Content = BLL.RegistroProduto.ViewData.Count();
            //LblCusto.Content = BLL.RegistroProduto.TotalValorCustoPadrao.ToString("#,##0.00");
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

        private void Select()
        {

            Mouse.OverrideCursor = Cursors.Wait;
            try
            {


                Mouse.OverrideCursor = Cursors.Wait;
                BLL.RegistroProduto.Select();
                fillgrafico();
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

        private void fillgrafico()
        {
            List<KeyValuePair<string, double>> l1 = new List<KeyValuePair<string, double>>();
            if (BLL.RegistroProduto.ViewData == null)
            {
                l1.Add(new KeyValuePair<string, double>(DateTime.Now.ToShortDateString(), 1));
            }
            else
            {
                foreach (Pag_Net.Bll.Operacionais.Analise.RegistroProdutoItem i in BLL.RegistroProduto.ViewData)
                {
                    l1.Add(new KeyValuePair<string, double>(i.Descricao, i.ValorCustoPadrao));
                }
            }
            var dataSourceList = new List<List<KeyValuePair<string, double>>>();
            dataSourceList.Add(l1);
            mcChart.DataContext = dataSourceList;
        }
        private void CMDBuscarFaturamentoDiario_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DataGridFaturamentoOperacional.ItemsSource = null;
                BLL.RegistroProduto.Filtros.TipoPesquisa = "DATA"; 
                this.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void CMDBuscarFaturamentoMensal_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {

                DataGridFaturamentoOperacional.ItemsSource = null;
                BLL.RegistroProduto.Filtros.TipoPesquisa = "MES";
                this.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

 


    }
}
