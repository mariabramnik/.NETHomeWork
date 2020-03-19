using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HomeWork52part3BuyTicket
{
    //make the button 'Buy ticket' Disabled
    public class MyCommand : ICommand
    {
        bool canExecute;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return AppCommands.flagPurchasePossible;           
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("First Log In");
            MainWindow.loginWindow.Show();
            
        }

    }

    public static class AppCommands
    {
        private static ICommand anyCommand = new MyCommand();
        public static bool flagPurchasePossible = true;

        public static ICommand AnyCommand
        {
            get { return anyCommand; }
        }
    }
}
