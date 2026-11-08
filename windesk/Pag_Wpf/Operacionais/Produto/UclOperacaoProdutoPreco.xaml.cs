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

namespace Pag_Wpf.Operacionais.Produto
{
    /// <summary>
    /// Interaction logic for UclOperacaoProdutoPreco.xaml
    /// </summary>
    public partial class UclOperacaoProdutoPreco : UserControl
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Operacionais.Produto.Precos BLL;
        private string  FormularioMenu = "m2312";
        private bool _StatusFill = false;
        public UclOperacaoProdutoPreco(modelSistemaUsuario _myConnect)
        {
            try
            {
                InitializeComponent();

                MyConnect = _myConnect;
                BLL = new Pag_Net.Bll.Operacionais.Produto.Precos(MyConnect);
                //BLL.PropertyChanged += new PropertyChangedEventHandler(ProdutoOperacaoPreco_OnList);
                cmbFabricante.ItemsSource = BLL.Cadastros.Fabricante.ViewData;
                cmbDepartamento.ItemsSource = BLL.Cadastros.ProdutosComplementos.Departamento;
                cmbSecao.ItemsSource = BLL.Cadastros.ProdutosComplementos.Secao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
                if (BLL.Cadastros.ProdutosComplementos.Departamento.Count() < 2)
                {
                    cmbDepartamento.SelectedIndex = 0;
                    cmbDepartamento.IsEnabled = false;
                }
                if (BLL.Cadastros.ProdutosComplementos.Secao.Count() < 2)
                {
                    cmbSecao.SelectedIndex = 0;
                    cmbSecao.IsEnabled = false;
                }
                CmbOperacao.ItemsSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, FormularioMenu);


                if (CmbOperacao.Items.Count == 2)
                {
                    CmbOperacao.SelectedIndex = 2; ; // OPERCAO LOJA PADRAO
                }
                else
                {
                    CmbOperacao.SelectedIndex = 0;
                }

                DTPDataAplicacao.SelectedDate = DateTime.Now;
                DTPCustoInicial.SelectedDate = DateTime.Now;
                DTPCustoFinal.SelectedDate = DateTime.Now;
                CHKDataCustoInicial.IsChecked = true;


                BLL.DataCustoInicial = Convert.ToDateTime("01/01/1999");
                BLL.DataCustoFinal = Convert.ToDateTime("31/12/2030");

                CHKDataCustoInicial.IsChecked = false;
                DTPCustoInicial.IsEnabled = false;
                DTPCustoFinal.IsEnabled = false;

                Mouse.OverrideCursor = Cursors.Wait;
                CMDAtualizar_Click(null, null);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Filtrar()
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (_StatusFill)
                {
                    BLL.Produtos();
                    DataGridProdutoPreco.ItemsSource = BLL.SelectProdutoList;
                    LBLMARGEM_MEDIA.Content = BLL.ProdutosMargemMedia.ToString("0.00");
                    LBLQTDE_ITENS.Content = BLL.ProdutosTotalFiltrado.ToString();
                }
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CmbOperacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Pag_Net.Models.TbSysTbOperacoes)CmbOperacao.SelectedItem).CdOperacao == 0)
            {
                MessageBox.Show("Seleção Obrigatória");
                CmbOperacao.SelectedIndex = 1;
            }

            if (CmbOperacao.SelectedItem != null)
            {
                BLL.CdOperacao = ((Pag_Net.Models.TbSysTbOperacoes)CmbOperacao.SelectedItem).CdOperacao;
            }
        }
        private void cmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDepartamento.SelectedItem != null)
            {
                BLL.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
                Filtrar();
            }
        }
        private void cmbSecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                BLL.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;
                Filtrar();
            }
        }
        private void cmbLinha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLinha.SelectedItem != null)
            {
                BLL.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)cmbLinha.SelectedItem).CdProdutoLinha;
                Filtrar();
            }
        }
        private void cmbFabricante_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.CdFabricante = ((Pag_Net.Bll.Cadastros.UVWFabricante)cmbFabricante.SelectedItem).CdFabricante;
            Filtrar();
        }
        private void cmbDepartamento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbDepartamento.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoDepartamentoSelecionado = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento.ToString();
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = "";
                cmbSecao.ItemsSource = BLL.Cadastros.ProdutosComplementos.Secao;
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }
        }
        private void cmbSecao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao.ToString();
                cmbLinha.ItemsSource = BLL.Cadastros.ProdutosComplementos.Linha;
            }
        }

        private void txtcodigoproduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtcodigoproduto.Text != "")
                {
                    BLL.CdProduto = Convert.ToInt32(txtcodigoproduto.Text);
                }
                else
                {
                    BLL.CdProduto = 0;
                }
                Filtrar();
            }
            catch
            {
                txtcodigoproduto.Text = "";
                MessageBox.Show("Código Produto Inválido");
            }
        }

        private void txtcodigoprodutoBlue_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtcodigoprodutoBlue.Text != "")
                {
                    BLL.CdProdutoBlueSoft = Convert.ToInt32(txtcodigoprodutoBlue.Text);
                }
                else
                {
                    BLL.CdProdutoBlueSoft = 0;
                }
                Filtrar();
            }
            catch
            {
                txtcodigoprodutoBlue.Text = "";
                MessageBox.Show("Código Produto BlueSoft Inválido");
            }
        }

        private void txtdescricaoProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            BLL.Descricao = txtdescricaoProduto.Text.ToUpper();
            Filtrar();
        }

        private void ProdutoOperacaoPreco_OnList(object sender, PropertyChangedEventArgs e)
        {
            //DataGridProdutoPreco.ItemsSource = BLL.ViewData;
        }
        private void DataGridProdutoPreco_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                int cdProduto = Convert.ToInt32(((TextBlock)RowColumn.Content).Text);
                BLL.Embalagens(cdProduto);
                DataGridEmbalagemPreco.ItemsSource = BLL.SelectEmbalagensList;
                //DataGridEmbalagemCB.ItemsSource = BLL.GetCodigoBarra(cdProduto, "");
            }
            catch (Exception)
            {
                DataGridEmbalagemPreco.ItemsSource = null;

            }
        }

        private void CmdEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (BLL.SelectProdutoList == null)
                {
                    MessageBox.Show("Selecione uma lista antes de editar");
                    Mouse.OverrideCursor = Cursors.Arrow;
                    return;
                }



                OperacaoPrecoAplicacao form = new OperacaoPrecoAplicacao(BLL, MyConnect);
                form.IndexSelFabricante = cmbFabricante.SelectedIndex;
                form.IndexSelDepartamento = cmbDepartamento.SelectedIndex;
                form.IndexSelSecao = cmbSecao.SelectedIndex;
                form.IndexSelLinha = cmbLinha.SelectedIndex;
                form.IndexSelCdOperacao = CmbOperacao.SelectedIndex;
                form.DataAplicacao = DTPDataAplicacao.SelectedDate.Value;
                System.Windows.Forms.DialogResult Result = form.ShowDialog();
                if (Result == System.Windows.Forms.DialogResult.OK)
                {

                    Mouse.OverrideCursor = Cursors.Wait;
                    CMDAtualizar_Click(null, null);
                }
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Filtrar();
                DataGridProdutoPreco.ItemsSource = BLL.SelectProdutoList;
                //form.Dispose();
                //form = null;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                _StatusFill = false;
                LBLAplicacaoSelecionada.Content = DTPDataAplicacao.Text;
                LBLOperacaoSelecionada.Content = ((Pag_Net.Models.TbSysTbOperacoes)CmbOperacao.SelectedItem).DescricaoOperacao;
                cmbFabricante.SelectedIndex = 0;
                cmbSecao.SelectedIndex = 0;
                cmbDepartamento.SelectedIndex = 0;
                cmbLinha.SelectedIndex = 0;
                txtcodigoproduto.Text = "";
                txtdescricaoProduto.Text = "";
                BLL.CdProduto = 0;
                BLL.CdProdutoDepartamento = "";
                BLL.CdProdutoSecao = "";
                BLL.CdProdutoLinha = "";
                BLL.Descricao = "";

                BLL.CdOperacao = ((Pag_Net.Models.TbSysTbOperacoes)CmbOperacao.SelectedItem).CdOperacao;
                BLL.DataAplicacao = DTPDataAplicacao.SelectedDate.Value;
                _StatusFill = true;
                BLL.Select();

                BLL.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
                BLL.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;

                BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao.ToString();


                Filtrar();
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void DTPDataAplicacao_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CMImportar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Confirma Importação - Os preços validos para hoje serão sobrescritos com os preços do ERP?", "PAG - Importação de Preços", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    Pag_Net.Bll.Operacionais.Produto.UspInterfaceImportaProdutoPreco.Importar(MyConnect);
                    CMDAtualizar_Click(null, null);
                    MessageBox.Show("Importação concluida com sucesso!");
                    Mouse.OverrideCursor = Cursors.Arrow;

                }
            }
            catch (Exception EX)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("Erro:" + EX.Message);
            }

        }

        private void CMDAplicar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Confirma Aplicação?", "PAG - Aplicação de Preços", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    Pag_Net.Bll.Operacionais.Produto.UspProdutoPrecoAplicacao.Aplicacao(MyConnect);
                    CMDAtualizar_Click(null, null);
                    MessageBox.Show("Aplicação concluída com sucesso!");
                    Mouse.OverrideCursor = Cursors.Arrow;

                }
            }
            catch (Exception EX)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("Erro:" + EX.Message);
            }
        }

        private void DTPCustoInicial_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.DataCustoInicial = DTPCustoInicial.SelectedDate.Value;
        }

        private void DTPCustoFinal_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.DataCustoFinal = DTPCustoFinal.SelectedDate.Value;
        }

        private void CHKDataCustoInicial_Click(object sender, RoutedEventArgs e)
        {
            if (CHKDataCustoInicial.IsChecked.Value)
            {
                DTPCustoInicial.IsEnabled = true;
                DTPCustoFinal.IsEnabled = true;
                BLL.DataCustoInicial = DTPCustoInicial.SelectedDate.Value;
                BLL.DataCustoFinal = DTPCustoInicial.SelectedDate.Value;
            }
            else
            {
                DTPCustoInicial.IsEnabled = false;
                DTPCustoFinal.IsEnabled = false;
                BLL.DataCustoInicial = Convert.ToDateTime("01/01/1999");
                BLL.DataCustoFinal = Convert.ToDateTime("31/12/2030");
            }
        }




        private void CHKAlteracaoPendente_Click(object sender, RoutedEventArgs e)
        {

            if (CHKAlteracaoPendente.IsChecked.Value)
            {
                BLL.AlteracoesPendentes = true;
            }
            else
            {
                BLL.AlteracoesPendentes = false;
            }
        }

        private void CHKDataCustoInicial_Checked(object sender, RoutedEventArgs e)
        {

        }


    }
}
