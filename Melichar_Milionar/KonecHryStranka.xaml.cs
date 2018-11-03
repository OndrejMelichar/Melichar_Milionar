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
    /// Interakční logika pro KonecHryStranka.xaml
    /// </summary>
    public partial class KonecHryStranka : Page
    {
        private Frame hlavniFrame;

        public KonecHryStranka()
        {
            InitializeComponent();
        }

        public KonecHryStranka(Frame hlavniFrame) : this()
        {
            this.hlavniFrame = hlavniFrame;
        }

        private void pokracovatButton_Click(object sender, RoutedEventArgs e)
        {
            Hrac hrac = new Hrac();
            hrac.Jmeno = jmenoTextBox.Text;

            if (hrac.Jmeno.Length == 0)
            {
                hrac.Jmeno = "Bezejmenný";
            }

            hrac.Skore = App.Uroven;
            hrac.Datum = DateTime.Now.ToString("dd. MM. yyyy hh:mm:ss");

            Souborovator souborovator = new Souborovator();
            souborovator.UlozHrace(hrac);

            hlavniFrame.Navigate(new Menu(hlavniFrame));
        }
    }
}
