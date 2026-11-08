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
using Pag_Net.Bll.SitefLog;
using Pag_Net.Models;

namespace Pag_Wpf.Operacionais.Varejo
{
    /// <summary>
    /// Interaction logic for LogSitef.xaml
    /// </summary>
    public partial class LogSitef : Page
    {
        private Pag_Net.Models.modelSistemaUsuario _MyConnection;
        private bllSitefLogs _LogSitefBll;
        public LogSitef(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            _MyConnection = _myConnect;
            _LogSitefBll = new bllSitefLogs(_MyConnection);
            cmbOperadores.ItemsSource = _LogSitefBll.Operadores;
            cmbECF.ItemsSource = _LogSitefBll.Ecfs;
            dtPickerIni.SelectedDate = DateTime.Now;
            dtPickerFim.SelectedDate = DateTime.Now;

        }
        private void cmdTransacaoRelacionada_Click(object sender, RoutedEventArgs e)
        {

            Cursor x = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            TbSitefLogs _tbsiteflogselecionado = ((FrameworkElement)sender).DataContext as TbSitefLogs;
            _LogSitefBll.FiltroEcf = new TbECF(_tbsiteflogselecionado.Ecf);
            _LogSitefBll.FiltroCupomFiscal = _tbsiteflogselecionado.CupomFiscal.ToString();
            _LogSitefBll.FiltroValorIni = _tbsiteflogselecionado.Valor.ToString();
            _LogSitefBll.FiltroValorFim = _tbsiteflogselecionado.Valor.ToString();


            DataGridTransacaoRelacionada.ItemsSource = _LogSitefBll.ListSitefAssociados;
            Mouse.OverrideCursor = x;
            
        }
        private void cmdImprimeTransacoes_Click(object sender, RoutedEventArgs e)
        {
            TbSitefLogs _tbsiteflogselecionado = ((FrameworkElement)sender).DataContext as TbSitefLogs;
            _LogSitefBll.FiltroEcf = new TbECF(_tbsiteflogselecionado.Ecf);
            _LogSitefBll.FiltroCupomFiscal = _tbsiteflogselecionado.CupomFiscal.ToString();
            Pag_Wpf.ReportViewForm Reportv = new ReportViewForm(_LogSitefBll.ListSitefAssociados, "Pag_Wpf.ReportForm.rptTbSitefLog.rdlc", "datasettbsiteflog");
            Reportv.ShowDialog();
        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            SetFiltros();
            try
            {
                DataGridLogSitef.ItemsSource = _LogSitefBll.ListSitefLogs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na busca das informações: " + ex.Message.ToString());
            }
            
        }
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {


        }
        private void SetFiltros()
        {
            _LogSitefBll.FiltroDataEmissaoIni = dtPickerIni.SelectedDate.Value;
            _LogSitefBll.FiltroDataEmissaoFim = dtPickerFim.SelectedDate.Value;
            _LogSitefBll.FiltroEcf = ((TbECF)cmbECF.SelectedItem);
            _LogSitefBll.FiltroCupomFiscal = txtNumeroCupomFiscal.Text;
            _LogSitefBll.FiltroOperador =  ((TbOperadores)cmbOperadores.SelectedItem);
            _LogSitefBll.FiltroValorIni = txtvlPgtoIni.Text;
            _LogSitefBll.FiltroValorFim = txtvlPgtoFim.Text;
            _LogSitefBll.FiltroEstadoTransacao = cmbEstadoTransacao.Text;
        }
    }
}
