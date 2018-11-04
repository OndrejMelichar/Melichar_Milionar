﻿using System;
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
        private Random random = new Random();
        private Otazkovator otazkovator = new Otazkovator();
        private List<Path> listUrovni;

        public HraStranka()
        {
            InitializeComponent();

            this.dalsiOtazka();
        }

        public HraStranka(Frame hlavniFrame) : this() //volá instanci bez parametru
        {
            this.hlavniFrame = hlavniFrame;
            this.listUrovni = new List<Path>(new Path[] { zvyrazneni15Path, zvyrazneni14Path, zvyrazneni13Path, zvyrazneni12Path, zvyrazneni11Path, zvyrazneni10Path, zvyrazneni9Path, zvyrazneni8Path, zvyrazneni7Path, zvyrazneni6Path, zvyrazneni5Path, zvyrazneni4Path, zvyrazneni3Path, zvyrazneni2Path, zvyrazneni1Path });
            App.NapovedaA = true;
        }



        private void dalsiOtazka()
        {
            Otazka otazka = this.otazkovator.VytvorOtazku(App.Uroven);

            if (otazka != null)
            {
                List<string> randomizovaneOdpovedi = this.otazkovator.RandomizujOdpovedi(otazka.Odpovedi);

                otazkaTextBlock.Text = otazka.TextOtazky;
                moznostAButton.Content = randomizovaneOdpovedi[0];
                moznostBButton.Content = randomizovaneOdpovedi[1];
                moznostCButton.Content = randomizovaneOdpovedi[2];
                moznostDButton.Content = randomizovaneOdpovedi[3];

                this.obnovTlacitkaMoznosti();
            } else
            {
                //došly otázky
            }
        }



        private void vyhodnotOdpoved(int zvolenaMoznost)
        {
            if (zvolenaMoznost == this.otazkovator.IndexSpravneOdpovedi)
            {
                if (App.Uroven < this.listUrovni.Count)
                {
                    App.Uroven++;
                    this.listUrovni[App.Uroven - 1].Opacity = 1;
                    this.listUrovni[App.Uroven - 2].Opacity = 0;

                    this.dalsiOtazka();
                }
            } else
            {
                hlavniFrame.Navigate(new KonecHryStranka(hlavniFrame));
            }
        }





        private void napovedaAButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.NapovedaA == true)
            {
                List<Button> tlacitka = new List<Button>() { moznostAButton, moznostBButton, moznostCButton, moznostDButton };

                int nahodnyIndex;

                while (true)
                {
                    nahodnyIndex = this.random.Next(4);

                    if (nahodnyIndex != this.otazkovator.IndexSpravneOdpovedi)
                    {
                        break;
                    }
                }

                foreach (Button tlacitko in tlacitka)
                {
                    if ((tlacitka.IndexOf(tlacitko) != this.otazkovator.IndexSpravneOdpovedi) && (tlacitka.IndexOf(tlacitko) != nahodnyIndex))
                    {
                        App.NapovedaA = false;

                        tlacitko.IsEnabled = false;
                        tlacitko.Opacity = 0.2;
                        napovedaAButton.IsEnabled = false;
                        napovedaAButton.Opacity = 0.2;
                    }
                }
            }
        }

        private void obnovTlacitkaMoznosti()
        {
            List<Button> tlacitka = new List<Button>() { moznostAButton, moznostBButton, moznostCButton, moznostDButton };

            foreach (Button tlacitko in tlacitka)
            {
                tlacitko.IsEnabled = true;
                tlacitko.Opacity = 1;
            }
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

        private void ukoncitHruButton_Click(object sender, RoutedEventArgs e)
        {

        }

        

    }
}
