using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.Login;
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

namespace HomeWork50Part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool flag = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            LoginService ls = new LoginService();
            ILoginToken iloginToken;
            try
            {
                bool res = ls.TryLogin(txtPassword.Password.ToString(), txtUsername.Text, out iloginToken);
                if (res == false)
                {
                    MainWin.Background = Brushes.Red;
                }
                else
                {
                    MainWin.Background = Brushes.Green;
                }
            }
            catch(Exception ex)
            {
                MainWin.Background = Brushes.Red;
            }
 
            

        }
    }
}
