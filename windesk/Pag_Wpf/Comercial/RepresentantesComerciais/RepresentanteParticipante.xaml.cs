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
using System.Windows.Shapes;
using Pag_Net.Models;

namespace Pag_Wpf.Comercial.RepresentantesComerciais
{
    /// <summary>
    /// Interaction logic for RepresentanteParticipante.xaml
    /// </summary>
    public partial class RepresentanteParticipantes : Window
    {
        
        Pag_Net.Bll.Comercial.CollectionClass _BLL;
        public RepresentanteParticipantes(modelSistemaUsuario __myConnect, Pag_Net.Bll.Comercial.UVWRepresentantes __representanteSelecionado)
        {
            InitializeComponent();
            _BLL = new Pag_Net.Bll.Comercial.CollectionClass(__myConnect);
            LBLREPRESENTANTESELECIONADO_CODIGO.Content = __representanteSelecionado.CdRepresentante.ToString();
            LBLREPRESENTANTESELECIONADO_NOME.Content = __representanteSelecionado.Descricao.ToString();
            Pag_Net.Bll.Cadastros.Participantes Participantes = new Pag_Net.Bll.Cadastros.Participantes(__myConnect);
            Participantes.Filtros.CdErpTipo = "FORNECEDOR";
            Participantes.Select();
            DTGParticipante.ItemsSource = Participantes.ViewData;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdEfetivar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBLPARTICIPANTESELECIONADO_CODIGO.Content.ToString().Trim() == "")
                {
                    MessageBox.Show("Selecione um Participante");
                    return;
                }
                _BLL.RepresentanteParticipante.Insert(Convert.ToInt32(LBLREPRESENTANTESELECIONADO_CODIGO.Content.ToString()), Convert.ToInt32(LBLPARTICIPANTESELECIONADO_CODIGO.Content.ToString().Trim()));
                MessageBox.Show("Associação concluída com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na associação Representante x Participante:" + ex.Message.ToString());
            }

        }
    }
}
