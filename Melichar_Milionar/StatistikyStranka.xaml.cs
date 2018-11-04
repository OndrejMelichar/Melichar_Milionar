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
using XAMLUserControl;

namespace Melichar_Milionar
{
    /// <summary>
    /// Interakční logika pro StatistikyStranka.xaml
    /// </summary>
    public partial class StatistikyStranka : Page
    {
        private Frame hlavniFrame;

        public StatistikyStranka()
        {
            InitializeComponent();
        }

        public StatistikyStranka(Frame hlavniFrame) : this()
        {
            this.hlavniFrame = hlavniFrame;
            this.vykresliStatistiku();
        }



        private void vykresliStatistiku()
        {
            Souborovator souborovator = new Souborovator();
            List<Hrac> hraci = this.seradHrace(souborovator.NactiHrace());
            List<string> castky = new List<string>() {"0", "1 000", "2 000", "3 000", "5 000", "10 000", "20 000", "40 000", "80 000", "160 000", "320 000", "640 000", "1 250 000", "2 500 000", "5 000 000", "10 000 000" };

            foreach(Hrac hrac in hraci)
            {
                ObalUserControl uc = new ObalUserControl();
                uc.jmenoTextBlock.Text = hrac.Jmeno;
                uc.skoreTextBlock.Text = castky[hrac.Skore] + " Kč";
                statistikyStackPanel.Children.Add(uc);

            }
        }

        private List<Hrac> seradHrace(List<Hrac> neserazeniHraci)
        {
            Hrac[] hraci = neserazeniHraci.ToArray();

            for (int i = 0; i < hraci.Length - 1; i++) //selection sort
            {
                int pivot = i;

                for (int j = i + 1; j < hraci.Length; j++)
                {
                    if (hraci[j].Skore > hraci[pivot].Skore) {
                        pivot = j;
                    }
                }

                Hrac pom = hraci[pivot];
                hraci[pivot] = hraci[i];
                hraci[i] = pom;
            }

            return new List<Hrac>(hraci);
        }

        private void zpetButton_Click(object sender, RoutedEventArgs e)
        {
            hlavniFrame.Navigate(new Menu(hlavniFrame));
        }
    }
}
