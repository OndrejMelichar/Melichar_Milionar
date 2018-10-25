using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Melichar_Milionar
{
    /// <summary>
    /// Interakční logika pro HraStranka.xaml
    /// </summary>
    public partial class HraStranka : Page
    {
        private Frame hlavniFrame;

        public HraStranka()
        {
            InitializeComponent();
        }

        public HraStranka(Frame hlavniFrame) : this() //volá instanci bez parametru   (ještě base)
        {
            this.hlavniFrame = hlavniFrame;
        }

        private void moznostAButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "A";
        }

        private void moznostBButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "B";
        }

        private void moznostCButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "C";
        }

        private void moznostDButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "D";
        }
    }
}
