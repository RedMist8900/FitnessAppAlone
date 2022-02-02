using Funktion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitnessAppAlone.View
{
    /// <summary>
    /// Interaction logic for WindowMainInterface.xaml
    /// </summary>
    public partial class WindowMainInterface : Window
    {
        FitnessFunction func = new FitnessFunction();
        public WindowMainInterface()
        {
            InitializeComponent();
        }
    }
}
