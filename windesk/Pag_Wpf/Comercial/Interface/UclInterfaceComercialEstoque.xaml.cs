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


namespace Pag_Wpf.Comercial.Interface
{
    /// <summary>
    /// Interaction logic for UclInterfaceComercialEstoque.xaml
    /// </summary>
    public partial class UclInterfaceComercialEstoque : UserControl
    {
        private Pag_Net.Bll.Comercial.CollectionClass _BLL;
        private modelSistemaUsuario _MyConnect;
        public UclInterfaceComercialEstoque(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            _MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Comercial.CollectionClass(__myConnect);

            CMBDepartamento.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Departamento;
            CMBSecao.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Secao;
            CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            CMBInterfaceInfo.ItemsSource = _BLL.Interface.Cadastro.ViewData;
            CMBInterfaceInfo.SelectedIndex = 0;
            
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _BLL.Interface.Estoque.Select();
                DTGProdutos.ItemsSource = _BLL.Interface.Estoque.ViewData;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void DTPCAD_INI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //_BLL.List.Filtros.DataCadastroInicial = DTPCAD_INI.SelectedDate.Value;
        }
        private void DTPCAD_FIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //_BLL.List.Filtros.DataCadastroFinal = DTPCAD_FIM.SelectedDate.Value;
        }
        private void CHKProdutosAtivos_Click(object sender, RoutedEventArgs e)
        {
            //_BLL.List.Filtros.StatusProduto = true;
        }
        private void CMBDepartamento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CMBDepartamento.SelectedItem != null)
            {
                _BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento.ToString();
                _BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
                CMBSecao.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Secao;
                CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            }
        }
        private void CMBSecao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CMBSecao.SelectedItem != null)
            {
                _BLL.Interface.Estoque.Filtros.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao.ToString();
                CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            }

        }
        private void CMBDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Interface.Estoque.Filtros.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento.ToString();
        }
        private void CMBLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Interface.Estoque.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha.ToString();
        }
        private void TXTCODIGOS_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.Interface.Estoque.Filtros.ProdutoLista = TXTCODIGOS.Text.ToString().Trim();
        }
        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.Interface.Estoque.Filtros.Descricao = TXTDESCRICAO.Text.ToString().TrimEnd().TrimStart();
        }

        private void cmdInterfaceEstoqueInfoItemDetalhe_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Pag_Net.Bll.Comercial.Interface.UVWInterfaceEstoqueInfoItemPosicao Selecao = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.Interface.UVWInterfaceEstoqueInfoItemPosicao;
                _BLL.Interface.EstoqueDetalhes.Filtros.ProdutoLista = Selecao.CdProduto.ToString();
                _BLL.Interface.EstoqueDetalhes.Select();
                DTGInterfaceEstoqueInfoItem.ItemsSource = _BLL.Interface.EstoqueDetalhes.ViewData;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMBInterfaceInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Interface.Estoque.Filtros.SeqInterfaceInfo = ((Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfo)CMBInterfaceInfo.SelectedItem).SeqInterfaceInfo;
        }
    }
}
