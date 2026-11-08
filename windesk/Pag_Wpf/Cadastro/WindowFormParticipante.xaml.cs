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
using System.Data;
using Pag_Net.Bll;
using Pag_Net.Models;
using System.IO;


namespace Pag_Wpf.Cadastro
{
    /// <summary>
    /// Interaction logic for WindowFormParticipante.xaml
    /// </summary>
    public partial class WindowFormParticipante : Window
    {
        public Pag_Net.Bll.Cadastros.Participante BLL;
        public modelSistemaUsuario MyConnect;
        public WindowFormParticipante(modelSistemaUsuario __myConnect, int __cdParticipante)
        {
            InitializeComponent();
            try
            {
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Cadastros.Participante(__myConnect, __cdParticipante);
                UclLabelNome.Text = BLL.Informacoes.Nome;
                UclLabelCdParticipante.Text = BLL.Informacoes.CdParticipante.ToString();
                UclLabelDocumento.Text = BLL.Informacoes.Documento;
                UclLabelDocumentoNumero.Text = BLL.Informacoes.Informacao;
                UclLabelTipoEntidade.Text = BLL.Informacoes.TipoEntidade;
                UclLabelCategoria.Text = BLL.Informacoes.DescricaoCategoria;
                DTGEnderecos.ItemsSource = BLL.Enderecos;
                DTGParticipanteERP.ItemsSource = BLL.ERP;
                DTGParticipanteEmpresa.ItemsSource = BLL.Empresas;

                ImgParticipante.Source = null;
                string linkImage = @"\\SRVAPLIC\SPOOL\IMAGEPAG\" + BLL.Informacoes.LinkImage.ToString();
                linkImage = linkImage.Trim();

                if (File.Exists(linkImage))
                {
                    BitmapImage bm = new BitmapImage(new Uri(linkImage, UriKind.RelativeOrAbsolute));
                    ImgParticipante.Source = bm;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void CHKDataCadastro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CMDSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
