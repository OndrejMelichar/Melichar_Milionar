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
        private Otazkovator otazkovator = new Otazkovator();
        private Frame hlavniFrame;
        private int indexSpravneOdpovedi;
        private int uroven = 1;

        public HraStranka()
        {
            InitializeComponent();

            this.dalsiOtazka();
        }

        public HraStranka(Frame hlavniFrame) : this() //volá instanci bez parametru
        {
            this.hlavniFrame = hlavniFrame;
        }



        private void dalsiOtazka()
        {
            Otazka otazka = this.otazkovator.VytvorOtazku(this.uroven);

            if (otazka != null)
            {
                List<string> randomizovaneOdpovedi = this.randomizujOdpovedi(otazka.Odpovedi);
                pomoc.Content = this.indexSpravneOdpovedi;

                otazkaTextBlock.Text = otazka.TextOtazky;
                moznostAButton.Content = randomizovaneOdpovedi[0];
                moznostBButton.Content = randomizovaneOdpovedi[1];
                moznostCButton.Content = randomizovaneOdpovedi[2];
                moznostDButton.Content = randomizovaneOdpovedi[3];
            } else
            {
                pomoc.Content = "došly otázky";
            }
        }

        private void vyhodnotOdpoved(int zvolenaMoznost)
        {
            if (zvolenaMoznost == this.indexSpravneOdpovedi)
            {
                this.uroven++;
                this.dalsiOtazka();
            }
        }

        private List<string> randomizujOdpovedi(List<string> razeneOdpovedi)
        {
            List<string> randomizovaneOdpovedi = new List<string>();

            bool poprve = true;
            int randomIndex = 0;
            while (razeneOdpovedi.Count > 0)
            {
                randomIndex = this.random.Next(0, razeneOdpovedi.Count);
                randomizovaneOdpovedi.Add(razeneOdpovedi[randomIndex]);
                razeneOdpovedi.RemoveAt(randomIndex);

                if (poprve && randomIndex == 0)
                {
                    this.indexSpravneOdpovedi = randomizovaneOdpovedi.Count - 1;
                    poprve = false;
                }
            }

            return randomizovaneOdpovedi;
        }



        private void moznostAButton_Click(object sender, RoutedEventArgs e)
        {
            this.vyhodnotOdpoved(0);
        }

        private void moznostBButton_Click(object sender, RoutedEventArgs e)
        {
            this.vyhodnotOdpoved(1);
        }

        private void moznostCButton_Click(object sender, RoutedEventArgs e)
        {
            this.vyhodnotOdpoved(2);
        }

        private void moznostDButton_Click(object sender, RoutedEventArgs e)
        {
            this.vyhodnotOdpoved(3);
        }
    }
}
