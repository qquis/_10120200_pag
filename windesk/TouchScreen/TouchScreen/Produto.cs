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
using System.IO;

namespace ExemploTecladoVirtual
{
    /// <summary>
    /// Interaction logic for Azul.xaml
    /// </summary>
    public partial class Azul : Window
    {
        public Azul()
        {
            InitializeComponent();
        }

        public void Gravar()
        {
            try
            {
                StreamWriter arquivo = new StreamWriter("produto.txt", true, Encoding.UTF8);
                arquivo.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), Ultimo.Text);
                arquivo.Close();
            }
            catch { }
               //Pagina2 p = new Pagina2() { Nome = Ultimo.Text };
               //p.Show();
            this.Close();
        }
    }
}
