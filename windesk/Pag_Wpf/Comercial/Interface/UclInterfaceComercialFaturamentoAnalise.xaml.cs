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
    /// Interaction logic for UclInterfaceComercialFaturamentoAnalise.xaml
    /// </summary>
    public partial class UclInterfaceComercialFaturamentoAnalise : UserControl
    {
          private Pag_Net.Bll.Comercial.CollectionClass _BLL;
        private modelSistemaUsuario _MyConnect;
        public UclInterfaceComercialFaturamentoAnalise(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            _MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Comercial.CollectionClass(__myConnect);

            CMBDepartamento.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Departamento;
            CMBSecao.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Secao;
            CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            CMBInterfaceInfo.ItemsSource = _BLL.Interface.Cadastro.ViewData;
            CMBInterfaceInfo.SelectedIndex = 0;


            dtPickerCadIni.SelectedDate = DateTime.Now;
            dtPickerCadFim.SelectedDate = DateTime.Now;
            CMBTipoPesquisa.SelectedIndex = 0;
            _BLL.Interface.FaturamentoItens.Filtros.TipoRelatorio = "PRODUTO";

        }

        private void CMBTipoPesquisa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                int TipoPesquisa = CMBTipoPesquisa.SelectedIndex;
                switch (TipoPesquisa)
                {
                    case 0: _BLL.Interface.FaturamentoItens.Filtros.TipoRelatorio = "PRODUTO"; break;
                    case 1: _BLL.Interface.FaturamentoItens.Filtros.TipoRelatorio = "FABRICANTE"; break;
                    case 2: _BLL.Interface.FaturamentoItens.Filtros.TipoRelatorio = "CLIENTE"; break;
                    case 3: _BLL.Interface.FaturamentoItens.Filtros.TipoRelatorio = "VENDEDOR"; break;
                }
                CMDBuscar_Click(null, null);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DTGInterfaceFaturamentoAnaliseProduto.ItemsSource = null;
                _BLL.Interface.FaturamentoItens.Select();
                DTGInterfaceFaturamentoAnaliseProduto.ItemsSource = _BLL.Interface.FaturamentoItens.ViewData;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void dtPickerCadIni_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Interface.FaturamentoItens.Filtros.DataInicial = dtPickerCadIni.SelectedDate.Value;


        }
        private void dtPickerCadFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Interface.FaturamentoItens.Filtros.DataFinal = dtPickerCadFim.SelectedDate.Value;
        }
        private void CHKProdutosAtivos_Click(object sender, RoutedEventArgs e)
        {
            //_BLL.List.Filtros.StatusProduto = true;
        }
        private void CMBDepartamento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CMBDepartamento.SelectedItem != null)
            {
                _BLL.Interface.FaturamentoItens.Filtros.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento;
                CMBSecao.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Secao;
                CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            }
            else
            {
                _BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = "";
                _BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
                CMBSecao.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Secao;
                CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            }
        }
        private void CMBSecao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CMBSecao.SelectedItem != null)
            {
                _BLL.Interface.FaturamentoItens.Filtros.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao.ToString();
                CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            }
            if (CMBLinha.SelectedItem != null)
            {
                _BLL.Interface.FaturamentoItens.Filtros.CdProdutoSecao = "";
                CMBLinha.ItemsSource = _BLL.Cadastros.ProdutosComplementos.Linha;
            }

        }
        private void CMBDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = "";
            if (CMBDepartamento.SelectedItem != null)
            {
                _BLL.Interface.FaturamentoItens.Filtros.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento.ToString();
            }
        }
        private void CMBSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
            if (CMBSecao.SelectedItem != null)
            {
                _BLL.Interface.FaturamentoItens.Filtros.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao.ToString();
            }
        }
        private void CMBLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBLinha.SelectedItem != null)
            {
                _BLL.Interface.FaturamentoItens.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha.ToString();
            }
        }
        private void TXTCODIGOS_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.Interface.FaturamentoItens.Filtros.ProdutoLista = TXTCODIGOS.Text.ToString().Trim();
        }
        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.Interface.FaturamentoItens.Filtros.Descricao = TXTDESCRICAO.Text.ToString().TrimEnd().TrimStart();
        }
        private void CMBInterfaceInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.Interface.FaturamentoItens.Filtros.SeqInterfaceInfo = ((Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfo)CMBInterfaceInfo.SelectedItem).SeqInterfaceInfo;

        }
        private void chkSelecionado_Click(object sender, RoutedEventArgs e)
        {
            Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoInfoArquivos obj = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoInfoArquivos;
            if (obj.Selecionado)
            {
                obj.Selecionado = false;
            }
            else
            {
                obj.Selecionado = true;
            }
        }

    }
}
