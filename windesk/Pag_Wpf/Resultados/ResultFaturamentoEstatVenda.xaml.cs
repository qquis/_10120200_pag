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

namespace Pag_Wpf.Resultados
{
    /// <summary>
    /// Interaction logic for ResultFaturamentoEstatVenda.xaml
    /// </summary>
    public partial class ResultFaturamentoEstatVenda : Page
    {
        private string _TipoPesquisa = "EM";
        public bllPackageConnection MyConnection { get; set; }
        public ResultFaturamentoEstatVenda(bllPackageConnection myConnection)
        {
            InitializeComponent();
            MyConnection = myConnection;

            try
            {

                cmbFabricante.ItemsSource = Pag_Net.Bll.Tables.bllTbFabricante.GetList(myConnection); cmbFabricante.SelectedIndex = 0;
                cmbVendedor.ItemsSource = Pag_Net.Bll.Tables.bllTbVendedor.GetList(myConnection); cmbVendedor.SelectedIndex = 0;
                cmbEquipeVendas.ItemsSource = Pag_Net.Bll.Tables.bllTbEquipe.GetList(myConnection); cmbEquipeVendas.SelectedIndex = 0;
                cmbArea.ItemsSource = Pag_Net.Bll.Tables.bllTbArea.GetList(myConnection); cmbArea.SelectedIndex = 0;
                cmbEmpresa.ItemsSource = Pag_Net.Bll.Tables.bllTbEmpresas.GetList(myConnection);
                cmbEmpresa.SelectedIndex = 0;


                DeptoComboboxFill();
                cmbDepartamento.SelectedIndex = 0;
                SecaoComboboxFill();
                cmbSecao.SelectedIndex = 0;
                LinhaComboboxFill();
                cmbLinha.SelectedIndex = 0;

                dtPickerCadIni.SelectedDate = DateTime.Now;//Convert.ToDateTime("01/11/2011"); 
                dtPickerCadFim.SelectedDate = DateTime.Now;//Convert.ToDateTime("05/11/2011"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na abertura do Formulário: " + ex.Message.ToString());
            }

            
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                StatusPag("Buscando informações...");
                Pag_Net.Bll.Tables.bllTbOperacaoFaturamento x = new Pag_Net.Bll.Tables.bllTbOperacaoFaturamento(MyConnection);




                double? vltotal_ini = null;
                double? vltotal_fim = null;

                decimal? vlmargem_ini = null;
                decimal? vlmargem_fim = null;

                if (txtValorTotalIni.Text.TrimEnd() != "") { vltotal_ini = Convert.ToDouble(txtValorTotalIni.Text); }
                if (txtValorTotalFim.Text.TrimEnd() != "") { vltotal_fim = Convert.ToDouble(txtValorTotalFim.Text); }

                if (txtMargemIni.Text.TrimEnd() != "") { vlmargem_ini = Convert.ToDecimal(txtMargemIni.Text.TrimEnd()); }
                if (txtMargemFim.Text.TrimEnd() != "") { vlmargem_fim = Convert.ToDecimal(txtMargemFim.Text.TrimEnd()); }




                ModelTbOperacaoFaturamento[] _lista = x.GetList(_TipoPesquisa,
                            chkEmbalagemFornecedor.IsChecked.Value,
                            dtPickerCadIni.SelectedDate.Value,
                            dtPickerCadFim.SelectedDate.Value,
                            ((ModelTbEmpresas)cmbEmpresa.SelectedItem).DescricaoEmpresa.ToString().TrimEnd(),
                            txtFNomeCliente.Text.TrimEnd(),
                            ((ModelTbVendedor)cmbVendedor.SelectedItem).NomeVendedor.ToString(),
                            txtdescricaoProduto.Text.TrimEnd(),
                            txtcodigoproduto.Text.Trim(),
                            ((ModelTbEquipe)cmbEquipeVendas.SelectedItem).DescricaoEquipe.ToString(),
                            ((ModelTbArea)cmbArea.SelectedItem).DescricaoArea.ToString().TrimEnd(),
                            ((ModelTbFabricante)cmbFabricante.SelectedItem).DescricaoFabricante.ToString(),
                            ((ModelTbLinha)cmbLinha.SelectedItem).DescricaoLinha.ToString(),
                            ((ModelTbSecao)cmbSecao.SelectedItem).DescricaoSecao.ToString(),
                            ((ModelTbDepartamento)cmbDepartamento.SelectedItem).DescricaoDepartamento.ToString(),
                            vltotal_ini,
                            vltotal_fim,
                            null,
                            null,
                            vlmargem_ini,
                            vlmargem_fim,
                            chkMargemItem.IsChecked.Value);

                double _vltotalVenda = 0;
                double _vltotalVolume = 0;
                double _vltotalCusto = 0;
                double _vlMargem = 0;


                foreach (ModelTbOperacaoFaturamento item in _lista)
                {
                    _vltotalVenda = Convert.ToDouble(item.Venda.ToString()) + _vltotalVenda;
                    _vltotalVolume = Convert.ToDouble(item.Volume.ToString()) + _vltotalVolume;
                    _vltotalCusto = Convert.ToDouble(item.Custo.ToString()) + _vltotalCusto;
                }

                if (_vltotalVenda > 0)
                {
                    _vlMargem = ((_vltotalVenda - _vltotalCusto) / _vltotalVenda) * 100;
                }

                LblVolume.Content = _vltotalVenda.ToString("#,###,##0.0");
                LblVenda.Content = _vltotalVenda.ToString("#,###,##0.00");
                LblCusto.Content = _vltotalCusto.ToString("#,###,##0.00");
                LblMargem.Content = _vlMargem.ToString("#,###,##0.00");
                LblRegistros.Content = _lista.Count().ToString();



                DataGridFaturamentoOperacional.ItemsSource = _lista;

                StatusPag();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro na busca das informações: " + ex.Message.ToString());
            }

        }

        private void TipoPesquisa_Click(object sender, RoutedEventArgs e)
        {
            List<Button> _list = new List<Button>();

            _list.Add(cmdtpPesquisaEmpresa);
            _list.Add(cmdtpPesquisaDepartamento);
            _list.Add(cmdtpPesquisaSecao);
            _list.Add(cmdtpPesquisaLinha);

            _list.Add(cmdtpPesquisaEquipe);
            _list.Add(cmdtpPesquisaVendedor);
            _list.Add(cmdtpPesquisaArea);

            _list.Add(cmdtpPesquisaData);
            _list.Add(cmdtpPesquisaPedidoCupom);   

            _list.Add(cmdtpPesquisaFabricante);
            _list.Add(cmdtpPesquisaProduto);

            _list.Add(cmdtpPesquisaCliente);

            foreach (Button i in _list)
            {
                i.Foreground = Brushes.Black;

            }
            ((Button)sender).Foreground = Brushes.Blue;
            switch (((Button)sender).Name.Trim())
            {
                case "cmdtpPesquisaEmpresa": _TipoPesquisa = "EM"; break;
                case "cmdtpPesquisaProduto": _TipoPesquisa = "PD"; break;
                case "cmdtpPesquisaDepartamento": _TipoPesquisa = "DP"; break;
                case "cmdtpPesquisaSecao": _TipoPesquisa = "SC"; break;
                case "cmdtpPesquisaLinha": _TipoPesquisa = "LN"; break;
                case "cmdtpPesquisaEquipe": _TipoPesquisa = "EQ"; break;
                case "cmdtpPesquisaVendedor": _TipoPesquisa = "VE"; break;
                case "cmdtpPesquisaArea": _TipoPesquisa = "AR"; break;
                case "cmdtpPesquisaData": _TipoPesquisa = "DT"; break;
                case "cmdtpPesquisaPedidoCupom": _TipoPesquisa = "PE"; break;
                case "cmdtpPesquisaFabricante": _TipoPesquisa = "FA"; break;
                case "cmdtpPesquisaCliente": _TipoPesquisa = "CL"; break;
            }

        }

        public void StatusPag()
        {
            StatusPag("");

        }
        public void StatusPag(string message)
        {
            Pag_Wpf.MainWindow x = new MainWindow();
            x.StatusPagMain("");
            Mouse.OverrideCursor = Cursors.Arrow;
            if (message != "")
            {
                Mouse.OverrideCursor = Cursors.Wait;
                x.StatusPagMain(message);
            }
            x.Close();
        }


        public void DeptoComboboxFill()
        {
            if (cmbDepartamento.Items.Count <= 0)
            {
                cmbDepartamento.ItemsSource = Pag_Net.Bll.Tables.bllTbDepartamento.GetList(MyConnection); cmbDepartamento.SelectedIndex = 0;
            }
            
        }

        public void SecaoComboboxFill()
        {
            cmbSecao.ItemsSource = Pag_Net.Bll.Tables.bllTbSecao.GetList(MyConnection, ((ModelTbDepartamento)cmbDepartamento.SelectedItem).CodigoDepartamento);
 
        }

        public void LinhaComboboxFill()
        {
            cmbLinha.ItemsSource = Pag_Net.Bll.Tables.bllTbLinha.GetList(MyConnection, cmbDepartamento.SelectedItem != null? ((ModelTbDepartamento)cmbDepartamento.SelectedItem).CodigoDepartamento : "",  cmbSecao.SelectedItem != null? ((ModelTbSecao)cmbSecao.SelectedItem).CodigoSecao: "" );

        }

        private void cmbDepartamento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbDepartamento.SelectedItem != null) SecaoComboboxFill();
        }

        private void cmbSecao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbSecao.SelectedItem != null)
            {
                LinhaComboboxFill();
            }
        }


    }
}
