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

namespace Pag_Wpf.Sistema
{
    /// <summary>
    /// Interaction logic for UclSistemaAcessos.xaml
    /// </summary>
    public partial class UclSistemaAcessos : UserControl
    {
        private modelSistemaUsuario MyConnect;
        private string FormularioMenu = "m2411";

        private Pag_Net.Bll.Sistemas.UVWSistemaFormulario FormularioSelecionado;

        public Pag_Net.Bll.Sistemas.CollectionAcesso BLL;

        public UclSistemaAcessos(modelSistemaUsuario __myConnect)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Sistemas.CollectionAcesso(MyConnect);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                BLL.Formularios.Parametros.Descricao = "";
                if (TXTFormulario.Text != "")
                {
                    BLL.Formularios.Parametros.Descricao = TXTFormulario.Text;
                }
                BLL.Formularios.Select();
                DTGSistemaProcessosFormularios.ItemsSource = BLL.Formularios.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDDetalhe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DTGSistemaAcessos.ItemsSource = null;
                Mouse.OverrideCursor = Cursors.Wait;
                FormularioSelecionado = ((FrameworkElement)sender).DataContext as Pag_Net.Bll.Sistemas.UVWSistemaFormulario;
                BLL.Acessos.Parametros.Cd_Form_Proc = FormularioSelecionado.Cd_Form_Proc;
                BLL.Acessos.Select();
                DTGSistemaAcessos.ItemsSource = BLL.Acessos.ViewData;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.FormularioSelecionado == null)
                {
                    MessageBox.Show("Favor selecionar um formulário");
                }
                else
                {
                    frmSistemaAcessos frm = new frmSistemaAcessos(MyConnect, FormularioSelecionado);
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
