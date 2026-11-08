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

namespace Pag_Wpf.Operacionais.Loja.Execucao
{
    /// <summary>
    /// Interaction logic for UclEtiquetaGondola.xaml
    /// </summary>
    public partial class UclEtiquetaGondola : UserControl
    {
        private Pag_Net.Bll.Operacionais.Varejo.Execucao.EtiquetaGondola _BLL;
        private modelSistemaUsuario _MyConnect;
        private int _NumeroMaximoEtiquetas;
        public UclEtiquetaGondola(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            _MyConnect = __myConnect;
            


            _BLL = new Pag_Net.Bll.Operacionais.Varejo.Execucao.EtiquetaGondola(_MyConnect);
            CMBDepartamento.ItemsSource = _BLL.Complementos.Departamento;
            CMBSecao.ItemsSource = _BLL.Complementos.Secao;
            CMBLinha.ItemsSource = _BLL.Complementos.Linha;

            if (_BLL.Complementos.Departamento.Count() <= 1)
            {
                CMBDepartamento.IsEnabled = false;
                CMBDepartamento.SelectedIndex = 0;
            }

            if (_BLL.Complementos.Secao.Count() <= 1)
            {
                CMBSecao.IsEnabled = false;
                CMBSecao.SelectedIndex = 0;
            }

            if (_BLL.Complementos.Linha.Count() <= 1)
            {
                CMBLinha.IsEnabled = false;
                CMBLinha.SelectedIndex = 0;
            }

            DTPCAD_INI.SelectedDate = DateTime.Now;
            DTPCAD_FIM.SelectedDate = DateTime.Now;
            CHKDataCadastro.IsChecked = false;
            CHKDataCadastro_Click(null, null);

            if (Util.GetValueParametro(_MyConnect, "NUM. MAX. ETIQUETAS GONDOLA", "m2111") != "")
            {
                _NumeroMaximoEtiquetas = Convert.ToInt32(Util.GetValueParametro(_MyConnect, "NUM. MAX. ETIQUETAS GONDOLA", "m2111"));
            }
            else
            {
                _NumeroMaximoEtiquetas = 10;
            }

            LBLNUMEROMAXIMOETIQUETAS.Content = _NumeroMaximoEtiquetas.ToString();
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
        private void CMBDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _BLL.List.Filtros.CdProdutoDepartamento = "";
            if (CMBDepartamento.SelectedItem != null)
            {
                _BLL.List.Filtros.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento.ToString();
            }
        }
        private void CMBSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBSecao.SelectedItem != null)
            {
                _BLL.List.Filtros.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao.ToString();
            }
        }
        private void CMBLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBLinha.SelectedItem != null)
            {
                _BLL.List.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha.ToString();
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
        private void TXTTRANSACOES_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.List.Filtros.SequenciaisProcessamentos = TXTTRANSACOES.Text.ToString().Trim();
        }
        private void CMDReport_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int INTContaEtiquetasImpressas = 0;

                List<Pag_Net.Bll.Operacionais.Varejo.Execucao.UVWEtiquetaGondola> EtiquetasAImprimir = new List<Pag_Net.Bll.Operacionais.Varejo.Execucao.UVWEtiquetaGondola>();
                if (DTGProdutos.ItemsSource == null)
                {
                    MessageBox.Show("Não há itens a serem impressos");
                    return;
                }
                foreach (Pag_Net.Bll.Operacionais.Varejo.Execucao.UVWEtiquetaGondola item in DTGProdutos.ItemsSource)
                {
                    if (item.ImpressaoPadrao)
                    {
                        EtiquetasAImprimir.Add(item);
                        INTContaEtiquetasImpressas += 1;
                        if (INTContaEtiquetasImpressas >= _NumeroMaximoEtiquetas)
                        {
                            break;
                        }
                    }
                }
                Pag_Net.Bll.Operacionais.Varejo.Execucao.EtiquetaGondola.Imprimir(EtiquetasAImprimir.ToArray());
                CMBDepartamento.SelectedIndex = 0; _BLL.List.Filtros.CdProdutoDepartamento = "";
                CMBSecao.SelectedIndex = 0; _BLL.List.Filtros.CdProdutoSecao = "";
                CMBLinha.SelectedIndex = 0; _BLL.List.Filtros.CdProdutoLinha = "";
                TXTCODIGOBARRA.Text = ""; _BLL.List.Filtros.CodigoBarra = "";
                TXTDESCRICAO.Text = ""; _BLL.List.Filtros.Descricao = "";
                TXTTRANSACOES.Text = ""; _BLL.List.Filtros.SequenciaisProcessamentos = "";
                TXTCODIGOS.Text = ""; _BLL.List.Filtros.Codigos = "";
                DTGProdutos.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CHKSelecioneImpressao_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            Pag_Net.Bll.Operacionais.Varejo.Execucao.UVWEtiquetaGondola obj = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Varejo.Execucao.UVWEtiquetaGondola;
            if (obj.ImpressaoPadrao)
            {
                obj.ImpressaoPadrao = false;
            }
            else
            {
                obj.ImpressaoPadrao = true;
            }
            Mouse.OverrideCursor = x;
        }
        private void TXTCODIGOBARRA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && TXTCODIGOBARRA.Text.Trim().Length > 0)
            {
                _BLL.List.Filtros.CodigoBarra = TXTCODIGOBARRA.Text.Trim().Replace("f", "").Replace("F", "");
                CMDBuscar_Click(null, null);
                CMDReport_Click(null, null);
            }
        }
        private void TXTCODIGOBARRA_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.List.Filtros.CodigoBarra = TXTCODIGOBARRA.Text.Trim().Replace("f", "").Replace("F", "");
        }
    }
}
