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
    public partial class Representantes : Window
    {
        
        Pag_Net.Bll.Comercial.CollectionClass _BLL;

        public Representantes(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            _BLL = new Pag_Net.Bll.Comercial.CollectionClass(__myConnect);
            //Pag_Net.Bll.Cadastros.Representantes Representantes = new Pag_Net.Bll.Cadastros.Representantes(__myConnect);
            //Representantes.Select();
            //DTGRepresentante.ItemsSource = Representantes.ViewData;
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdEfetivar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXTDESCRICAO.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("Digite um novo Representante.");
                    return;
                }
                
                _BLL.Representante.Insert(TXTDESCRICAO.Text.ToString().TrimEnd().TrimStart());
                MessageBox.Show("Cadastro concluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no Cadastramento de novo Representante:" + ex.Message.ToString());
            }

        }

        private void TXTDESCRICAO_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    
    }
}
