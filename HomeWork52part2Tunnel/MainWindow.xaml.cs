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

namespace HomeWork52part2Tunnel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void UpdateColor(object sender)
        {
 
             if (sender is Button)
             {
                  Button btn = (Button)sender;
                  if (btn.Name == mainButton.Name)
                  {
                      btn.Background = Brushes.Red;
                  }
                  else
                  {
                      btn.Background = Brushes.Green;
                  }
             }
             else if (sender is StackPanel)
             {
                  StackPanel pnl = (StackPanel)sender;
                  pnl.Background = Brushes.Plum;
             }
             else
             {
                  Background = Brushes.Salmon;
             }
      
        }
  
        private void Button_Click_1(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show("Button1");
            UpdateColor(sender);
            

        }

 
        private void Panel_Click(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show("panel Inner");
            UpdateColor(sender);
           

        }
        private void Panel_Click2(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show("Panel Outer");
            UpdateColor(sender);
            e.Handled = true;
        }

        private void outter_PreviewKeyDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("mainButton");
            UpdateColor(sender);

        }

        private void inner_PreviewKeyDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("small Button click");
            UpdateColor(sender);
        }

     }
}
