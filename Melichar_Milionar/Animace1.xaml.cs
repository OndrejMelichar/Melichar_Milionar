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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Melichar_Milionar
{
    /// <summary>
    /// Interakční logika pro Animace1.xaml
    /// </summary>
    public partial class Animace1 : UserControl
    {
        public Animace1()
        {
            InitializeComponent();
            Loaded += AnimatingControl_Loaded;
        }

        private void AnimatingControl_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (this.FindResource("sbAnimateImage") as Storyboard);
            sb.Begin();
        }
    }
}
