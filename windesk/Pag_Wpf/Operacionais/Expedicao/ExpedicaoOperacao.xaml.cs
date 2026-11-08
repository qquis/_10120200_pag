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

namespace Pag_Wpf.Operacionais.Expedicao
{
    /// <summary>
    /// Interaction logic for ExpedicaoOperacao.xaml
    /// </summary>
    public partial class ExpedicaoOperacao : Page
    {
        public ExpedicaoOperacao()
        {
            InitializeComponent();
        }

        private void CMDExpedicaoOperacaoRecebimentoLancamento_Click(object sender, RoutedEventArgs e)
        {
            ExpedicaoOperacaoRecebimentoLancamento form = new ExpedicaoOperacaoRecebimentoLancamento();
            form.ShowDialog();
        }
    }
}
