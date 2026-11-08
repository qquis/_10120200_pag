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

namespace Pag_Wpf.Cadastro
{
    /// <summary>
    /// Interaction logic for UclProduto.xaml
    /// </summary>
    public partial class UclProduto : UserControl
    {
        private Pag_Net.Bll.Cadastros.Produto _BLL;
        private modelSistemaUsuario _MyConnect;
        public UclProduto(modelSistemaUsuario __myConnect)
        {

            InitializeComponent();
            _MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Cadastros.Produto(_MyConnect);

            CMBDepartamento.ItemsSource = _BLL.Complementos.Departamento;
            CMBSecao.ItemsSource = _BLL.Complementos.Secao;
            CMBLinha.ItemsSource = _BLL.Complementos.Linha;
            CMBProdutoGestor.ItemsSource = _BLL.Gestor.ViewData;
            CMBCategoria.ItemsSource = _BLL.Categoria.ViewData;

            DTPCAD_INI.SelectedDate = DateTime.Now;
            DTPCAD_FIM.SelectedDate = DateTime.Now;
            CHKDataCadastro.IsChecked = false;
            CHKDataCadastro_Click(null, null);
            

            CHKProdutosAtivos.IsChecked = true;
            _BLL.List.Filtros.StatusProduto = true;
        }
        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _BLL.List.Select();
                DTGProdutos.ItemsSource = _BLL.List.ViewData;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void CHKDataCadastro_Click(object sender, RoutedEventArgs e)
        {
            if (CHKDataCadastro.IsChecked.Value)
            {
                DTPCAD_INI.IsEnabled = true;
                DTPCAD_FIM.IsEnabled = true;
            }
            else
            {
                DTPCAD_INI.IsEnabled = false;
                DTPCAD_FIM.IsEnabled = false;
            }
            _BLL.List.Filtros.DataCadastro = CHKDataCadastro.IsChecked.Value;

        }
        private void DTPCAD_INI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.List.Filtros.DataCadastroInicial = DTPCAD_INI.SelectedDate.Value;
        }
        private void DTPCAD_FIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.List.Filtros.DataCadastroFinal = DTPCAD_FIM.SelectedDate.Value;
        }
        private void CHKProdutosAtivos_Click(object sender, RoutedEventArgs e)
        {
            if (CHKProdutosAtivos.IsChecked.Value)
            {
                _BLL.List.Filtros.StatusProduto = true;
            }
            else
            {
                _BLL.List.Filtros.StatusProduto = false;
            }
        }
        private void CMBDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.List.Filtros.CdProdutoDepartamento = "";
            if (CMBDepartamento.SelectedItem != null)
            {
                _BLL.List.Filtros.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento;
            }
        }
        private void CMBSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBSecao.SelectedItem != null)
            {
                _BLL.List.Filtros.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao;
            }
        }
        private void CMBLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBLinha.SelectedItem != null)
            {
                _BLL.List.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha;
            }
        }
        private void TXTCODIGOS_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.List.Filtros.Codigos = TXTCODIGOS.Text.ToString().Trim();
        }
        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.List.Filtros.Descricao = TXTDESCRICAO.Text.ToString().TrimEnd().TrimStart();
        }
        private void CMBDepartamento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CMBDepartamento.SelectedItem != null)
            {
                _BLL.Complementos.CdProdutoDepartamentoSelecionado = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento.ToString();
                CMBSecao.ItemsSource = _BLL.Complementos.Secao;
                CMBLinha.ItemsSource = _BLL.Complementos.Linha;
            }
            else
            {
                _BLL.Complementos.CdProdutoDepartamentoSelecionado = "";
                _BLL.Complementos.CdProdutoSecaoSelecionada = "";
                CMBSecao.ItemsSource = _BLL.Complementos.Secao;
                CMBLinha.ItemsSource = _BLL.Complementos.Linha;
            }
        }
        private void CMBSecao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CMBSecao.SelectedItem != null)
            {
                _BLL.Complementos.CdProdutoSecaoSelecionada = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao.ToString();
                CMBLinha.ItemsSource = _BLL.Complementos.Linha;
            }

            if (CMBLinha.SelectedItem != null)
            {
                _BLL.Complementos.CdProdutoSecaoSelecionada = "";
                CMBLinha.ItemsSource = _BLL.Complementos.Linha;

            }

        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {
            

            Mouse.OverrideCursor = Cursors.Wait;
            try
            {


                Pag_Net.Bll.Cadastros.UVWProduto UVWProdutoConteudoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Cadastros.UVWProduto;

                _BLL.Conteudo.CdProduto = UVWProdutoConteudoSelecionado.CdProduto;
                _BLL.Conteudo.Select();
                UclLabelTextCodigo.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).CdProduto.ToString();
                UclLabelTextDescricao.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).Descricao.ToString();
                UclLabelTextCategoria.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).CategoriaDescricao.ToString();
                UclLabelTextLinha.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).LinhaDescricao.ToString();
                UclLabelTextSecao.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).SecaoDescricao.ToString();
                UclLabelTextDepartamento.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).DepartamentoDescricao.ToString();
                UclLabelTextEmbalagemCompra.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).EmbalagemCompra.ToString();
                UclLabelTextEmbalagemEstoque.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).EmbalagemEstoque.ToString();
                UclLabelTextEmbalagemCompraQtdeUnitaria.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).EmbalagemCompraQtdeUnitaria.ToString();
                UclLabelTextGestor.Text = ((Pag_Net.Bll.Cadastros.UVWProdutoConteudo)_BLL.Conteudo.ViewData[0]).GestorDescricao.ToString();

                _BLL.Embalagens.CdProduto = UVWProdutoConteudoSelecionado.CdProduto;
                _BLL.Embalagens.Select();
                DTGProdutosEmbalagens.ItemsSource = _BLL.Embalagens.ViewData;


                _BLL.CodigoBarra.CdProduto = UVWProdutoConteudoSelecionado.CdProduto;
                _BLL.CodigoBarra.Embalagem = "";
                _BLL.CodigoBarra.Select();
                DTGProdutosEmbalagensCodigoBarra.ItemsSource = _BLL.CodigoBarra.ViewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = Cursors.Arrow;

        }



        private void CMDProdutoCategoriaEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_BLL.Conteudo.CdProduto.ToString() != "" || _BLL.Conteudo.CdProduto.ToString() != "0")
                {
                    ProdutoRelacaoCategoria Form = new ProdutoRelacaoCategoria(_MyConnect, _BLL.Conteudo.CdProduto.ToString());
                    Form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecione um item!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um item (" + ex.Message.ToString() + ")");
            }
        }



        private void CMDLinhaEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_BLL.Conteudo.CdProduto.ToString() != "" || _BLL.Conteudo.CdProduto.ToString() != "0")
                {
                    ProdutoRelacaoLinha Form = new ProdutoRelacaoLinha(_MyConnect, _BLL.Conteudo.CdProduto.ToString());
                    Form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecione um item!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um item (" + ex.Message.ToString() + ")");
            }
        }

        private void CMDGestorEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_BLL.Conteudo.CdProduto.ToString() != "" || _BLL.Conteudo.CdProduto.ToString() != "0")
                {
                    ProdutoRelacaoGestor Form = new ProdutoRelacaoGestor(_MyConnect, _BLL.Conteudo.CdProduto.ToString());
                    Form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecione um item!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um item (" + ex.Message.ToString() + ")");
            }
        }

        private void CMBProdutoGestor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.List.Filtros.SeqProdutoGestor = ((Pag_Net.Bll.Cadastros.UVWProdutoGestor)CMBProdutoGestor.SelectedItem).SeqProdutoGestor;

        }

        private void CMBCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.List.Filtros.SeqProdutoCategoria = ((Pag_Net.Bll.Cadastros.VWProdutoCategoria)CMBCategoria.SelectedItem).SeqProdutoCategoria;
            
        }

    }
}
