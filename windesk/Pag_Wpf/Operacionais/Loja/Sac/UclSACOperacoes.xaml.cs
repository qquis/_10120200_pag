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
using Pag_Net.Bll.Sac;

namespace Pag_Wpf.Operacionais.Loja.Sac
{
    /// <summary>
    /// Interaction logic for UclSACOperacoes.xaml
    /// </summary>
    public partial class UclSACOperacoes : UserControl
    {
        bllOperacaoSac _OperacoesSac;
        public modelSistemaUsuario  _MyConnection { get; set; }
        public UclSACOperacoes(modelSistemaUsuario _myConnection)
        {
            InitializeComponent();
            _MyConnection = _myConnection;
            dtPickerIni.SelectedDate = DateTime.Now;
            dtPickerFim.SelectedDate = DateTime.Now;
            _OperacoesSac = new bllOperacaoSac(_MyConnection);
            FillCmbTipoOperacaoSac();
            fillOperadores();
            fillECF();

        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            FillOperacoesSac();
        }
        private void fillOperadores()
        {
            cmbOperadores.ItemsSource = Pag_Net.Bll.Tables.bllTbOperadores.GetList(_MyConnection);
        }
        private void fillECF()
        {
            cmbECF.ItemsSource = Pag_Net.Bll.Tables.bllTbECF.GetList(_MyConnection); cmbECF.SelectedIndex = 0;
        }
        public void FillOperacoesSac()
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DateTime? _dtini = dtPickerIni.SelectedDate.Value;
                DateTime? _dtfim = dtPickerFim.SelectedDate.Value;

                int? _cdoperador = null;
                int? _ecf = null;
                int? _cupomFiscal = null;

                if (cmbOperadores.Text != "") _cdoperador = Convert.ToInt32(((TbOperadores)cmbOperadores.SelectedItem).CdOperador.ToString());
                if (cmbECF.Text != "") _ecf = Convert.ToInt32(((TbECF)cmbECF.SelectedItem).ECF.ToString());
                if (txtNumeroCupomFiscal.Text != "") _cupomFiscal = Convert.ToInt32(txtNumeroCupomFiscal.Text);

                int? _tipooperacao = 0;
                if (cmbTipoOperacaoSac.Text != "") _tipooperacao = Convert.ToInt32(Pag_Net.Bll.Util.TiposGetSeq(cmbTipoOperacaoSac.SelectedItem));

                _OperacoesSac.Select(_ecf, _cupomFiscal, _dtini, _dtfim, _cdoperador, _tipooperacao);
                _OperacoesSac.SelectDevolucao(_ecf, _cupomFiscal, _dtini, _dtfim, _cdoperador, _tipooperacao);

                _OperacoesSac.SelectPos(_ecf, _cupomFiscal, 3, null, _dtini, _dtfim, _cdoperador, null, null);

                DataGridOperacoesSac.ItemsSource = _OperacoesSac.TbOperacaoSac;
                DataGridOperacoesDevolucaoProduto.ItemsSource = _OperacoesSac.ItemsDevolvidos;
                DataGridPgtos.ItemsSource = _OperacoesSac.PosList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Mouse.OverrideCursor = x;
        }
        public void FillCmbTipoOperacaoSac()
        {
            Pag_Net.Bll.Tables.BllTbTipos _tipos = new Pag_Net.Bll.Tables.BllTbTipos(_MyConnection);

            cmbTipoOperacaoSac.ItemsSource = _tipos.GetList("TbOperacaoSac", "TipoOperacaoSac");
        }
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {

            //SACPOSLanca x = new SACPOSLanca(_MyConnection, null, null);
            //x.ShowDialog();
        }
        private void BtnPOS_Click(object sender, RoutedEventArgs e)
        {
            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                //MessageBox.Show(((TbCuponsPagamentos)DataGridPgtos.SelectedItem).CupomFiscal.ToString());
                if (((TbCuponsPagamentos)DataGridPgtos.SelectedItem).DescricaoFinalizadora == "POS")
                {
                    Operacionais.Varejo.SACPOSLanca _form = new Varejo.SACPOSLanca(_MyConnection, ((TbCuponsPagamentos)DataGridPgtos.SelectedItem));
                    _form.ShowDialog();
                    FillOperacoesSac();

                }
                else
                {
                    throw new Exception("Tipo de Lançamento diferente de POS");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Mouse.OverrideCursor = x;
        }
    }
}
