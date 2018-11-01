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
    /// Interakční logika pro Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private Frame hlavniFrame;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(Frame hlavniFrame) : this()
        {
            this.hlavniFrame = hlavniFrame;


        }

        private void novaHraButton_Click(object sender, RoutedEventArgs e)
        {
            hlavniFrame.Navigate(new HraStranka(hlavniFrame));
        }

        private void statistikyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ukoncitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
