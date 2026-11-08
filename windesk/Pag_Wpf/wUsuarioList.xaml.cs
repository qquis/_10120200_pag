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


namespace Pag_Wpf
{
    /// <summary>
    /// Interaction logic for wUsuarioList.xaml
    /// </summary>
    public partial class wUsuarioList : Window
    {
        public wUsuarioList()
        {
            InitializeComponent();


            DataTable x = new DataTable();
            
            
            

            DataColumn r1 = new DataColumn ("NOME",Type.GetType("System.String"));
            x.Columns.Add(r1);

            x.Rows.Add("ELIAS");

            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.ItemsSource = x.DefaultView;



            




        }
    }
}
