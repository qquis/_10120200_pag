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
    /// Interaction logic for UclLabelText.xaml
    /// </summary>
    public partial class UclLabelText : UserControl
    {
        public UclLabelText()
        {
            InitializeComponent();
        }



        // Using a DependencyProperty as the backing store for ImageWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("UclLabelWidth", typeof(double), typeof(UclLabelText), new UIPropertyMetadata(16d));


        public double UclLabelWidth
        {
            get { return (double)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }



        public static readonly DependencyProperty TextWidthProperty =
            DependencyProperty.Register("UclTextWidth", typeof(double), typeof(UclLabelText), new UIPropertyMetadata(16d));


        public double UclTextWidth
        {
            get { return (double)GetValue(TextWidthProperty); }
            set { SetValue(TextWidthProperty, value); }
        }




        public static readonly DependencyProperty TextProperty =
              DependencyProperty.Register("Text", typeof(string), typeof(UclLabelText), new UIPropertyMetadata(""));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(UclLabelText), new UIPropertyMetadata(""));
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }


    }
}
