using FitnessAppAlone.View;
using Funktion;
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

namespace FitnessAppAlone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FitnessFunction func = new FitnessFunction();
        //WindowSignUp signUp;
        public MainWindow()
        {
            //signUp = new WindowSignUp();
            InitializeComponent();
            this.DataContext = func;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowSignUp sign = new WindowSignUp();
                sign.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Failed to Open signup", ex.Message);
            }
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
