using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace XAMLUserControl
{
    /// <summary> 
    /// Interaction logic for MyUserControl.xaml
    /// </summary> 

    public partial class ObalUserControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string Pokus;

        public ObalUserControl()
        {
            InitializeComponent();
        }

        public string pokus
        {
            get { return Pokus; }
            set { Pokus = value; }
        }
    }
}