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

            foreach(Hrac hrac in hraci)
            {

            }
        }

        private List<Hrac> seradHrace(List<Hrac> neserazeniHraci)
        {
            List<Hrac> serazeniHraci = new List<Hrac>();



            return serazeniHraci;
        }
    }
}
