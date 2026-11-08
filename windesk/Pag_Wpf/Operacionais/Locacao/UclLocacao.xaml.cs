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
using System.Data;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace Pag_Wpf.Operacionais.Locacao
{
    /// <summary>
    /// Interaction logic for UclLocacao.xaml
    /// </summary>
    public partial class UclLocacao : UserControl
    {
        private modelSistemaUsuario MyConnect;
        private string FormularioMenu = "m2910";
        public Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao ContratoLocacaoSelecionado;



        private Pag_Net.Bll.Operacionais.Locacao.Collection BLL;
        public UclLocacao(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            BLL = new Pag_Net.Bll.Operacionais.Locacao.Collection(MyConnect);
            DTPCAD_FIM.SelectedDate = DateTime.Now;
            DTPCAD_INI.SelectedDate = DateTime.Now;
            CHKDataCadastro.IsChecked = false;
            DTPCAD_INI.IsEnabled = false;
            DTPCAD_FIM.IsEnabled = false;
            CMBOperacao.ItemsSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, FormularioMenu);
            CMBOperacao.SelectedIndex = 0;
        }

        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CMDIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrmContrato Frm = new FrmContrato(MyConnect, null);
                Frm.ShowDialog();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Contratos.Select();
                DTGContratos.ItemsSource = BLL.Contratos.ViewData;
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
            {
                DTPCAD_INI.IsEnabled = false;
                DTPCAD_FIM.IsEnabled = false;
            }

        }

        private void DTPCAD_FIM_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DTPCAD_INI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                this.ContratoLocacaoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao;
                UTEmpresa.Text = ContratoLocacaoSelecionado.Empresa.ToString();
                UTCadastro.Text = ContratoLocacaoSelecionado.DataContrato.ToShortDateString();
                UTDataFinal.Text = ContratoLocacaoSelecionado.DataFim.ToShortDateString();
                UTDataInicio.Text = ContratoLocacaoSelecionado.DataInicio.ToShortDateString();

                DTGParcelas.ItemsSource = null;

                FillParticipantes();
                FillRubricas();
                FillFaturamento();
                FillAtivoImobilizado();
                

                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch(Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);

            }
        }
        private void FillParticipantes()
        {
            BLL.Participantes.Parametros.SeqContrato = ContratoLocacaoSelecionado.SeqContrato;
            BLL.Participantes.Select();
            DTGContratoParticipante.ItemsSource = BLL.Participantes.ViewData;
        }
        private void FillRubricas()
        {
            BLL.Rubricas.Parametros.SeqContrato = ContratoLocacaoSelecionado.SeqContrato;
            BLL.Rubricas.Select();
            DTGContratoRubricas.ItemsSource = BLL.Rubricas.ViewData;

        }

        private void FillFaturamento()
        {
            BLL.Composicao.Parametros.SeqContrato = ContratoLocacaoSelecionado.SeqContrato;
            BLL.Composicao.Select();
            DTGContratoFaturamento.ItemsSource = BLL.Composicao.ViewData;

        }

        private void FillAtivoImobilizado()
        {
            BLL.Ativo.Parametros.SeqContrato = ContratoLocacaoSelecionado.SeqContrato;
            BLL.Ativo.Select();
            DTGAtivoImobilizado.ItemsSource = BLL.Ativo.ViewData;
        }



        private void CMDAtivoEditarItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Administrativo.UVWContratoParticipante ContratoParticipante = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Administrativo.UVWContratoParticipante;
                Pag_Wpf.Administracao.FrmContratoParticipante frm = new Administracao.FrmContratoParticipante(MyConnect, ContratoParticipante);
                frm.ShowDialog();
                FillParticipantes();
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);

            }
        }

        private void CMDAtivoEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao ContratoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao;
                FrmContrato Frm = new FrmContrato(MyConnect, ContratoSelecionado);
                Frm.ShowDialog();
            }

            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDAtivoEditarRubrica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoRubricas RubricaSelecionada = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoRubricas;
                FrmContratoLocacaoRubrica Form = new FrmContratoLocacaoRubrica(MyConnect, RubricaSelecionada);
                Form.ShowDialog();
                FillRubricas();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDIncluirContratoFaturamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmContratoLocacaoFaturamento frm = new frmContratoLocacaoFaturamento(MyConnect, this.ContratoLocacaoSelecionado, null);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void CMDDetalheParcelas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DTGParcelas.ItemsSource = null;
                Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFaturamento item = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoFaturamento;
                BLL.Parcelas.Parametros.SeqContrato = item.SeqContratoLocacaoFaturamento;
                BLL.Parcelas.Select();
                DTGParcelas.ItemsSource = BLL.Parcelas.ViewData; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CMDGerarParcelas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Parcelas.Parametros.SeqContrato = this.ContratoLocacaoSelecionado.SeqContrato;
                BLL.Parcelas.Insert();
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("Parcelas Geradas com Sucesso");
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }

        }

        private void CMDIncluirAtivoImobilizado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.ContratoLocacaoSelecionado.SeqContrato == 0)
                {
                    MessageBox.Show("Favor Selecionar o Contrato");
                    return;
                }
                
                
                Pag_Wpf.Cadastro.FrmLocalizaAtivoImobilizado frm = new Cadastro.FrmLocalizaAtivoImobilizado(MyConnect);
                frm.ShowDialog();
                int SeqAtivoImobilizado = frm.SeqAtivoImobilizadoSelecionado;
                if (SeqAtivoImobilizado != 0)
                {
                    Cursor = Cursors.Wait;
                    BLL.Ativo.Parametros.SeqAtivoImobilizado = SeqAtivoImobilizado;
                    BLL.Ativo.Parametros.SeqContrato = ContratoLocacaoSelecionado.SeqContrato;
                    BLL.Ativo.Insert();
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Ativo Incluido com sucesso");
                    FillAtivoImobilizado();
                }
                frm.Dispose();
                

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);

            }
        }

        private void CMDExcluirAtivoImobilizado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.ContratoLocacaoSelecionado.SeqContrato == 0)
                {
                    MessageBox.Show("Favor Selecionar o Contrato");
                    return;
                }

                if (MessageBox.Show("Confirma a exclusão do Ativo do Contrato?", "PAG", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoAtivo ContratoLocacaoAtivoSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacaoAtivo;
                    Cursor = Cursors.Wait;
                    BLL.Ativo.Parametros.SeqAtivoImobilizado = ContratoLocacaoAtivoSelecionado.SeqAtivoImobilizado;
                    BLL.Ativo.Parametros.SeqContrato = ContratoLocacaoSelecionado.SeqContrato;
                    BLL.Ativo.Delete();
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Ativo Excluido com sucesso");
                    FillAtivoImobilizado();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);

            }
        }


    }
}
