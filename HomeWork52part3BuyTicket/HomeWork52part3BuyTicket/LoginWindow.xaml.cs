using FlightManagementSystem.Models;
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
using System.Windows.Shapes;

namespace HomeWork52part3BuyTicket
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>

        public partial class LoginWindow : Window
        {
            public static bool flag = false;
            public LoginWindow()
            {
                InitializeComponent();
            }
            public event EventHandler ButtonSubmitClicked;
            private void btnSubmit_Click(object sender, RoutedEventArgs e)
            {

                LoginService ls = new LoginService();
                ILoginToken iloginToken;
                try
                {
                //if such user is not found
                    bool res = ls.TryLogin(txtPassword.Password.ToString(), txtUsername.Text, out iloginToken);
                    if (res == false)
                    {
                        loginWindow.Background = Brushes.Red;
                    }
                    //if the user exist
                    else
                    {
                        loginWindow.Background = Brushes.Green;
                        MessageBox.Show("Hello  " + txtUsername.Text + "!");                                  
                        LoginToken<Customer> token = (LoginToken<Customer>) iloginToken;
                        string name = token.User.userName;
                        MainWindow.token = token;
                        MainWindow.userName = name; 
                    //show this customer in the main window using the event
                       if(ButtonSubmitClicked != null)
                        {
                            ButtonSubmitClicked(this, EventArgs.Empty);
                        }
                    this.Close();
                }
                }
                catch (Exception ex)
                {
                    loginWindow.Background = Brushes.Red;
                }



            }
        }
    }

