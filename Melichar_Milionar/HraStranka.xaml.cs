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
        private Random random = new Random();

        private Frame hlavniFrame;

        public HraStranka()
        {
            InitializeComponent();

            this.dalsiOtazka(1);
        }

        public HraStranka(Frame hlavniFrame) : this() //volá instanci bez parametru
        {
            this.hlavniFrame = hlavniFrame;
        }



        private void dalsiOtazka(int uroven)
        {
            Otazkovator otazkovator = new Otazkovator();
            Otazka otazka = otazkovator.VytvorOtazku(uroven);
            List<string> randomizovaneOdpovedi = this.randomizujOdpovedi(otazka.Odpovedi);

            otazkaTextBlock.Text = otazka.TextOtazky;
            moznostAButton.Content = randomizovaneOdpovedi[0];
            moznostBButton.Content = randomizovaneOdpovedi[1];
            moznostCButton.Content = randomizovaneOdpovedi[2];
            moznostDButton.Content = randomizovaneOdpovedi[3];
        }

        private List<string> randomizujOdpovedi(List<string> razeneOdpovedi)
        {
            List<string> randomizovaneOdpovedi = new List<string>();

            int randomIndex = 0;
            while (razeneOdpovedi.Count > 0)
            {
                randomIndex = this.random.Next(0, razeneOdpovedi.Count);
                randomizovaneOdpovedi.Add(razeneOdpovedi[randomIndex]);
                razeneOdpovedi.RemoveAt(randomIndex);
            }

            return randomizovaneOdpovedi;
        }



        private void moznostAButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "A";
            this.dalsiOtazka(1);
        }

        private void moznostBButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "B";
            this.dalsiOtazka(1);
        }

        private void moznostCButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "C";
            this.dalsiOtazka(1);
        }

        private void moznostDButton_Click(object sender, RoutedEventArgs e)
        {
            pomoc.Content = "D";
            this.dalsiOtazka(1);
        }
    }
}
