using Funktion;
using Model;
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
    /// Interaction logic for WindowSignUp.xaml
    /// </summary>
    public partial class WindowSignUp : Window
    {
        FitnessFunction func = new FitnessFunction();
        public MainWindow Main
        {
            get; set;
        }
        public WindowSignUp(MainWindow main)
        {
            InitializeComponent();
            Main = main;
            this.DataContext = func;
        }

        public WindowSignUp()
        {
            InitializeComponent();
            this.DataContext = func;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Failed to open LogIn", ex.Message);
            }
        }

        private void btnOpret_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach(User user in func.UserOversigt)
                {
                    if(user.Name == tbUserName.Text && user.Email == tbEmail.Text)
                    {
                        throw new Exception("User already Exists");
                    }
                }
                func.OpretUser(tbUserName.Text, tbUserName.Text, tbEmail.Text);
                func.LogIn(tbUserName.Text, tbPassword.Text);
                Main.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed at Button Opret", ex.Message);
            }
        }
    }
}
