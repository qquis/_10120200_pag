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
using Pag_Net.Models;
using Pag_Net.Bll;
using Pag_Wpf.Cadastro;

namespace Pag_Wpf.Cadastros
{
    /// <summary>
    /// Interaction logic for UclParticipante.xaml
    /// </summary>
    public partial class UclParticipante : UserControl
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Cadastros.UspParticipante BLL;
        private string FormularioMenu = "m1200";

        public UclParticipante(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Cadastros.UspParticipante(MyConnect);
                CMBOperacao.ItemsSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, "m1200");
                CMBTipoParticipanteEmpresa.ItemsSource = Pag_Net.Bll.Util.TiposGet(MyConnect.Tipos, "TbParticipanteEmpresa", "SeqTipoParticipanteEmpresa");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Select();
                DTGParticipantes.ItemsSource = BLL.ViewData;
                
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
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
        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {

            Pag_Net.Bll.Cadastros.UVWParticipante UVWParticipanteSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Cadastros.UVWParticipante;
            WindowFormParticipante win = new WindowFormParticipante(MyConnect, UVWParticipanteSelecionado.CdParticipante);
            win.ShowDialog();

        }

        private void DTPCAD_FIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
                
        }

        private void DTPCAD_INI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CMDIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                FrmParticipanteIncluir frm = new FrmParticipanteIncluir(MyConnect);
                frm.ShowDialog();

               // Pag_Net.Bll.Cadastros.UspParticipante x = new Pag_Net.Bll.Cadastros.UspParticipante(MyConnect);
               // x.Parametros.Nome = "ELIAS DA SILVA";
               // x.Parametros.DataNascimento = Convert.ToDateTime("17/11/1980");
               // x.Parametros.Sexo = "M";
               // x.Parametros.SeqTipoDocumento = 2;
               // x.Parametros.Documento = "21814585885";
               // x.Insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }



        private void TXTCODIGO_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                FrmLocalizaParticipante frm = new FrmLocalizaParticipante(MyConnect);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.CdParticipanteSelecionado.ToString().Trim() != "")
                    {
                        TXTCODIGO.Text = frm.CdParticipanteSelecionado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TXTCODIGO_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXTCODIGO.Text.ToString().Trim() != "")
                {
                    BLL.Parametros.CdParticipante = Convert.ToInt32(TXTCODIGO.Text.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTNOME_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                BLL.Parametros.Nome = TXTNOME.Text.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMBTipoParticipanteEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BLL.Parametros.SeqTipoParticipanteEmpresa = ((Pag_Net.Models.TbSysTbTipos)CMBTipoParticipanteEmpresa.SelectedItem).SeqTipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CMBOperacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                BLL.Parametros.CdOperacao = ((Pag_Net.Models.TbSysTbOperacoes)CMBOperacao.SelectedItem).CdOperacao;
                BLL.Parametros.CdEmpresa = ((Pag_Net.Models.TbSysTbOperacoes)CMBOperacao.SelectedItem).CdEmpresa;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
