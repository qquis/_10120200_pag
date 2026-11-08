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

namespace Pag_Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for UclButton.xaml
    /// </summary>
    public partial class UclButton : UserControl
    {
        
        public UclButton()
        {
            InitializeComponent();
        }
        public double UclButtonMaxWidth
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("UclButtonMaxWidth", typeof(double), typeof(UclButton), new UIPropertyMetadata(16d));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public static readonly DependencyProperty TextProperty =
          DependencyProperty.Register("Text", typeof(string), typeof(UclButton), new UIPropertyMetadata(""));


        public ImageBrush ImageNoClick
        {
            get { return (ImageBrush)GetValue(ImagePropertyNoClick); }
            set { SetValue(ImagePropertyNoClick, value); }
       }

        public static readonly DependencyProperty ImagePropertyNoClick =
           DependencyProperty.Register("ImageNoClick", typeof(ImageBrush), typeof(UclButton), new UIPropertyMetadata(null));

       
        
        public ImageBrush ImageClick
        {
            get { return (ImageBrush)GetValue(ImagePropertyClick); }
            set { SetValue(ImagePropertyClick, value); }
        }

        public static readonly DependencyProperty ImagePropertyClick =
           DependencyProperty.Register("ImageClick", typeof(ImageBrush), typeof(UclButton), new UIPropertyMetadata(null));


        public event RoutedEventHandler Click;

        void onButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
                this.Click(this, e);
        }

    }

}   