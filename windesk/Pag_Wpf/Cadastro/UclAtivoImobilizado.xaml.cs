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

namespace Pag_Wpf.Cadastro
{
    /// <summary>
    /// Interaction logic for UclAtivoImobilizado.xaml
    /// </summary>
    public partial class UclAtivoImobilizado : UserControl
    {
        private Pag_Net.Bll.Cadastros.Imobilizado BLL;
        private modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Cadastros.UVWAtivoImobilizado AtivoImobilizadoSelecionado;



        public UclAtivoImobilizado(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Cadastros.Imobilizado(__myConnect);
            
            CMBEmpresa.ItemsSource = BLL.Empresa.ViewData;
            if (BLL.Empresa.ViewData.Count() == 1)
                CMBEmpresa.SelectedIndex = 0;

            CMBTipo.ItemsSource = Pag_Net.Bll.Util.TiposGet(__myConnect.Tipos, "TbAtivoImobilizado", "SeqTipoAtivo");
            MyConnect = __myConnect;
            CHKDataCadastro.IsChecked = false;

            DTPCAD_INI.IsEnabled = false;
            DTPCAD_FIM.IsEnabled = false;
            DTPCAD_INI.SelectedDate = Convert.ToDateTime("01/01/1900");
            DTPCAD_FIM.SelectedDate = Convert.ToDateTime("31/12/2060");

        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Ativos.Select();
                DTGAtivoImobilizado.ItemsSource = BLL.Ativos.ViewData;
                UclLabelTextCodigo.Text = "";
                UclLabelTextDescricao.Text = "";


                UclLabelTextEmpresa.Text = "";
                UclLabelTextTipo.Text = "";
                UclLabelTextCadastro.Text = "";
                UclLabelTextValorAquisicao.Text = "";
                UclLabelTextValorReposicao.Text = "";
                UclLabelTextDataAquisicao.Text = "";
                UclLabelTextDocumentoFiscal.Text = "";
                UclLabelTextCodigoProduto.Text = "";
                UclLabelTextCodigoBarra.Text = "";
                DTGAtivoImobilizadoComponente.ItemsSource = null;
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
                BLL.Ativos.Parametros.DataCadastro = Convert.ToDateTime("01/01/1900");
                BLL.Ativos.Parametros.DataCadastroFim = Convert.ToDateTime("31/12/2060");
            }
        }

        private void DTPCAD_INI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Ativos.Parametros.DataCadastro = DTPCAD_INI.SelectedDate.Value;
        }

        private void DTPCAD_FIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BLL.Ativos.Parametros.DataCadastroFim = DTPCAD_FIM.SelectedDate.Value;
        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {
            AtivoImobilizadoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Cadastros.UVWAtivoImobilizado;
            UclLabelTextCodigo.Text = AtivoImobilizadoSelecionado.SeqAtivoImobilizado.ToString();
            UclLabelTextDescricao.Text = AtivoImobilizadoSelecionado.Descricao.ToString();
            UclLabelTextEmpresa.Text = AtivoImobilizadoSelecionado.Empresa.ToString();
            UclLabelTextTipo.Text = AtivoImobilizadoSelecionado.Tipo.ToString();
            UclLabelTextCadastro.Text = AtivoImobilizadoSelecionado.Cadastro.ToShortDateString();
            UclLabelTextValorAquisicao.Text = AtivoImobilizadoSelecionado.ValorAquisicao.ToString("0.00");
            UclLabelTextValorReposicao.Text = AtivoImobilizadoSelecionado.ValorReposicao.ToString("0.00");
            UclLabelTextDataAquisicao.Text = AtivoImobilizadoSelecionado.DataAquisicao.ToShortDateString();
            UclLabelTextDocumentoFiscal.Text = AtivoImobilizadoSelecionado.SeqDocumentoFiscal.ToString();
            UclLabelTextCodigoProduto.Text = AtivoImobilizadoSelecionado.CdProduto.ToString();
            UclLabelTextCodigoBarra.Text = AtivoImobilizadoSelecionado.CodigoBarra.ToString();
            DTGAtivoImobilizadoComponente.ItemsSource = BLL.Componentes(AtivoImobilizadoSelecionado.SeqAtivoImobilizado);
            BLL.Informacao.Parametros.SeqAtivoImobilizado = AtivoImobilizadoSelecionado.SeqAtivoImobilizado;
            BLL.Informacao.Select();
            DTGAtivoImobilizadoInformacoes.ItemsSource = BLL.Informacao.ViewData;


        }
        private void CMDIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrmAtivoImobilizado frm = new FrmAtivoImobilizado(MyConnect, 0,0, "INCLUIR");
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CMDAtivoEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AtivoImobilizadoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Cadastros.UVWAtivoImobilizado;
                UclLabelTextCodigo.Text = AtivoImobilizadoSelecionado.SeqAtivoImobilizado.ToString();
                UclLabelTextDescricao.Text = AtivoImobilizadoSelecionado.Descricao.ToString();
                FrmAtivoImobilizado frm = new FrmAtivoImobilizado(MyConnect, AtivoImobilizadoSelecionado.SeqAtivoImobilizado, AtivoImobilizadoSelecionado.SeqAtivoComponente, "EDITAR");
                frm.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDAtivoItemIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UclLabelTextCodigo.Text.ToString() == "")
                {
                    MessageBox.Show("Selecione um Ativo");
                    return;
                }

                if (AtivoImobilizadoSelecionado.SeqAtivoComponente > 0)
                {

                    MessageBox.Show("Não é possível incluir item em Item de Ativo!");
                    return;

                }

                int SeqAtivoImobilizado = Convert.ToInt32(UclLabelTextCodigo.Text.ToString());

                FrmAtivoImobilizado frm = new FrmAtivoImobilizado(MyConnect, 0, AtivoImobilizadoSelecionado.SeqAtivoImobilizado, "INCLUIR");
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void CHKComponente_Click(object sender, RoutedEventArgs e)
        {
            if (CHKComponente.IsChecked.Value)
            {
                BLL.Ativos.Parametros.SelecionaTipoComponentes = true;
            }
            else
            {
                BLL.Ativos.Parametros.SelecionaTipoComponentes = false;

            }
        }

        private void CMBEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BLL.Ativos.Parametros.CdEmpresa = ((Pag_Net.Bll.Cadastros.UVWEmpresa)CMBEmpresa.SelectedValue).CdEmpresa; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMBTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BLL.Ativos.Parametros.SeqTipoAtivo = ((Pag_Net.Models.TbSysTbTipos)CMBTipo.SelectedValue).SeqTipo;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDAtivoEditarItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Cadastros.UVWAtivoImobilizado AtivoSelecionadoItem =  ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Cadastros.UVWAtivoImobilizado;
                FrmAtivoImobilizado frm = new FrmAtivoImobilizado(MyConnect, AtivoSelecionadoItem.SeqAtivoImobilizado, AtivoSelecionadoItem.SeqAtivoComponente, "EDITAR");
                frm.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDAtivoEditarInformacao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Cadastros.UVWAtivoImobilizadoInformacao AtivoImobilizadoInformacaoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Cadastros.UVWAtivoImobilizadoInformacao;
                FrmAtivoImobilizadoInformacao frm = new FrmAtivoImobilizadoInformacao(MyConnect, AtivoImobilizadoInformacaoSelecionado.SeqAtivoImobilizado, AtivoImobilizadoInformacaoSelecionado.CdTipoInformacao);
                frm.ShowDialog();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
