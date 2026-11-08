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
using System.ComponentModel;

namespace Pag_Wpf.Cadastro
{
    /// <summary>
    /// Interaction logic for ProdutoCategoria.xaml
    /// </summary>
    public partial class UclProdutoCategoria : UserControl
    {
        private Pag_Net.Bll.Cadastros.Produto _BLL;
        private modelSistemaUsuario _MyConnect;
        public UclProdutoCategoria(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            _MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Cadastros.Produto(__myConnect);
            
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _BLL.Categoria.Select();
                DTGCategoria.ItemsSource = _BLL.Categoria.ViewData;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProdutoCategoria form = new ProdutoCategoria(_MyConnect, new Pag_Net.Bll.Cadastros.VWProdutoCategoria());
                form.ShowDialog();
                CMDBuscar_Click(null, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
        }

        private void CMDEditar_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                Pag_Net.Bll.Cadastros.VWProdutoCategoria UVWCategoriaSelecionada = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Cadastros.VWProdutoCategoria;
                ProdutoCategoria form = new ProdutoCategoria(_MyConnect, UVWCategoriaSelecionada);
                form.ShowDialog();
                CMDBuscar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
        }


    }
}
