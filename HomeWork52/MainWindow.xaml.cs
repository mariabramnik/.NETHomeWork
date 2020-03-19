using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HomeWork52
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
                 btn.Background = Brushes.Red;
             }
             else if(sender is StackPanel)
             {
                 StackPanel panel = (StackPanel)sender;
                 panel.Background = Brushes.Plum;
             }
             else
             {
                 Background = Brushes.Salmon;
             }
 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                MessageBox.Show("Main Button click starts bubbling");
                UpdateColor(sender);
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
     
            MessageBox.Show("Button1 stops bubbling");
            UpdateColor(sender);
            e.Handled = true;

        }

        private void Windows_Click3(object sender, RoutedEventArgs e)
        {
  
            MessageBox.Show("Windows_Click");
            UpdateColor(sender);

        }
        
        private void Panel_Click(object sender, RoutedEventArgs e)
        {

             MessageBox.Show("panel Inner");
             UpdateColor(sender);

        }
        private void Panel_Click2(object sender, RoutedEventArgs e)
        {
 
             MessageBox.Show("Panel Outer");
             UpdateColor(sender);

        }

    }
}
