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
    /// Interaction logic for RepresentanteFabricante.xaml
    /// </summary>
    public partial class RepresentanteFabricante: Window
    {
        
        Pag_Net.Bll.Comercial.CollectionClass _BLL;
        public RepresentanteFabricante(modelSistemaUsuario __myConnect, Pag_Net.Bll.Comercial.UVWRepresentantes __representanteSelecionado)
        {
            InitializeComponent();
            _BLL = new Pag_Net.Bll.Comercial.CollectionClass(__myConnect);
            LBLREPRESENTANTESELECIONADO_CODIGO.Content = __representanteSelecionado.CdRepresentante.ToString();
            LBLREPRESENTANTESELECIONADO_NOME.Content = __representanteSelecionado.Descricao.ToString();

            Pag_Net.Bll.Comercial.RepresentanteFabricante FabricanteSelecionado = new Pag_Net.Bll.Comercial.RepresentanteFabricante(__myConnect);
            Pag_Net.Bll.Cadastros.Fabricante Fabricantes = new Pag_Net.Bll.Cadastros.Fabricante(__myConnect);
            DTGFabricantes.ItemsSource = Fabricantes.ViewData;
        }

        private void buttom_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdEfetivar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBLFABRICANTESELECIONADO_CODIGO.Content.ToString().Trim() == "")
                {
                    MessageBox.Show("Selecione um fabricante");
                    return;
                }
                _BLL.RepresentanteFabricantes.Insert(Convert.ToInt32(LBLREPRESENTANTESELECIONADO_CODIGO.Content.ToString()), LBLFABRICANTESELECIONADO_CODIGO.Content.ToString().Trim());
                MessageBox.Show("Associação concluída com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na associação Representante x Fabricante -- " + ex.Message.ToString());
            }

        }
    }
}
