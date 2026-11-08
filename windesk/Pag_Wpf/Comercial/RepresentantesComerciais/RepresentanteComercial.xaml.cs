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

namespace Pag_Wpf.Comercial.RepresentantesComerciais
{
    /// <summary>
    /// Interaction logic for RepresentanteComercial.xaml
    /// </summary>
    public partial class RepresentanteComercial : Page

    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Comercial.CollectionClass _BLL;
        private Pag_Net.Bll.Comercial.UVWRepresentantes RepresentanteSelecionado;
        public RepresentanteComercial(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Comercial.CollectionClass(__myConnect);
        }
        private void cmdBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AtualizarRepresentante();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
        }

        public void AtualizarRepresentante()
        {
                DTGRepresentantesComerciais.ItemsSource = null;
                DTGFabricantes.ItemsSource = null;
                DTGParticipantes.ItemsSource = null;

                _BLL.Representante.List.Select();
                DTGRepresentantesComerciais.ItemsSource = _BLL.Representante.List.ViewData;
        }
        public void AtualizarFabricante(int cdRepresentante)
        {
            DTGFabricantes.ItemsSource = null;
            _BLL.RepresentanteFabricantes.List.Filtros.CdRepresentante = cdRepresentante;
            _BLL.RepresentanteFabricantes.List.Select();
            DTGFabricantes.ItemsSource = _BLL.RepresentanteFabricantes.List.ViewData;
        }
        public void AtualizarParticipante(int cdRepresentante)
        {
            DTGParticipantes.ItemsSource = null;
            _BLL.RepresentanteParticipante.List.Filtros.CdRepresentante = cdRepresentante;
            _BLL.RepresentanteParticipante.List.Select();
            DTGParticipantes.ItemsSource = _BLL.RepresentanteParticipante.List.ViewData;
        }

        private void cmdRepresentanteDetalhes_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            _BLL.RepresentanteFabricantes.List.Filtros.CdRepresentante = 0;
            _BLL.RepresentanteParticipante.List.Filtros.CdRepresentante = 0;
            RepresentanteSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.UVWRepresentantes;
            AtualizarFabricante(RepresentanteSelecionado.CdRepresentante);
            AtualizarParticipante(RepresentanteSelecionado.CdRepresentante);

            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void cmdInserirRepresentanteSelecionado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Wpf.Comercial.RepresentantesComerciais.Representantes x = new Representantes(MyConnect);
                x.ShowDialog();
                AtualizarRepresentante();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Digite um nome de Representante." + ex.Message.ToString());
            }
        }
        private void cmdInserirFabricanteSelecionado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RepresentanteFabricante x = new RepresentanteFabricante(MyConnect, RepresentanteSelecionado);
                x.ShowDialog();
                AtualizarFabricante(RepresentanteSelecionado.CdRepresentante);
            }
            catch (Exception)
            {
                MessageBox.Show("Carregue a lista de Representante em seguida clique no botão Detalhes.");
            }
        }
        private void cmdInserirParticipanteSelecionado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RepresentanteParticipantes x = new RepresentanteParticipantes(MyConnect, RepresentanteSelecionado);
                x.ShowDialog();
                AtualizarParticipante(RepresentanteSelecionado.CdRepresentante);
            }
            catch (Exception)
            {
                MessageBox.Show("Carregue a lista de Representante em seguida clique no botão Detalhes.","Aviso");
            }
        }
        
        private void cmdExcluirRepresentanteSelecionado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Comercial.UVWRepresentantes RepresentanteSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.UVWRepresentantes;
                _BLL.Representante.Delete(RepresentanteSelecionado.Descricao);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na exclusão -- " + ex.Message.ToString());
            }
        }
        private void cmdExcluirFabricanteSelecionado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Comercial.UVWRepresentanteFabricanteList FabricanteSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.UVWRepresentanteFabricanteList;
                _BLL.RepresentanteFabricantes.Delete(RepresentanteSelecionado.CdRepresentante, FabricanteSelecionado.CdFabricante);
                AtualizarFabricante(RepresentanteSelecionado.CdRepresentante);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na exclusão:" + ex.Message.ToString());
            }
        }
        private void cmdExcluirParticipanteSelecionado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pag_Net.Bll.Comercial.UVWRepresentanteParticipanteList ParticipanteSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Comercial.UVWRepresentanteParticipanteList;
                _BLL.RepresentanteParticipante.Delete(RepresentanteSelecionado.CdRepresentante, ParticipanteSelecionado.CdParticipante);
                AtualizarParticipante(RepresentanteSelecionado.CdRepresentante);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na exclusão -- " + ex.Message.ToString());
            }
        }

        private void TXTDescricao_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BLL.Representante.List.Filtros.Descricao = TXTDescricao.Text.ToString().TrimStart().TrimEnd();
        }
    }
}
