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

namespace HomeWork48WPF
{

    public partial class MainWindow : Window
    {
        // sugar flags
        public static bool flag1 = false;
        public static bool flag2 = false;
        public static bool flag3 = false;
        public static bool flag4 = false;
        public static double price = 4.0;
        public MainWindow()
        {
            InitializeComponent();
    
        }
        //determine the amount of sugar
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {         
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn == radio1)
            {
                flag1 = true;
                
            }
            if (radioBtn == radio2)
            {
                flag2 = true;
                price = price + 0.2;
            }
            if (radioBtn == radio3)
            {
                flag3 = true;
                price = price + 0.4;
            }
            if (radioBtn == radio4)
            {
                flag4 = true;
                price = price + 0.6;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn1.Background = Brushes.White;
            CheckSugar(btn1);
            if (flag1 != false || flag2 != false || flag3 != false || flag4 != false)
            {
                TaskWindow taskWindow = new TaskWindow();
                var uriImageSource = new Uri(@"/HomeWork48WPF;component/coffeeblack.png", UriKind.RelativeOrAbsolute);
                taskWindow.foto.Source = new BitmapImage(uriImageSource);
                
                string result = String.Format("{0:C}", price);
                taskWindow.myPrice.Text = taskWindow.myPrice.Text + result;
                taskWindow.Show();
                Application.Current.MainWindow.Close();
                
            }
        }
        private void CheckSugar(Button btn)
        {
            if(flag1 == true)
            {
                MessageBox.Show("Coffee "  + btn.Content.ToString()+ " and  " + radio1.Content.ToString() + ".  Do you agree? ");
     
            }
            if (flag2 == true)
            {
                MessageBox.Show("Coffee " + btn.Content.ToString() + " and " + radio2.Content.ToString() + ".  Do you agree? ");
            
            }
            if (flag3 == true)
            {
                MessageBox.Show("Coffee " +  btn.Content.ToString() + " and " + radio3.Content.ToString() + ".  Do you agree? ");
             
            }
            if (flag4 == true)
            {
                MessageBox.Show("Coffee " + btn.Content.ToString() + " and " + radio4.Content.ToString() + ".  Do you agree? ");
          
            }
           if( flag1 == false && flag2 == false && flag3 == false && flag4 == false)
            {
                MessageBox.Show("Choose how much sugar you want");
                btn1.Background = (Brush)(new BrushConverter().ConvertFrom("#d5e0f2")); 
                btn2.Background = (Brush)(new BrushConverter().ConvertFrom("#d5e0f2")); 
                btn3.Background = (Brush)(new BrushConverter().ConvertFrom("#d5e0f2")); 
                btn4.Background = (Brush)(new BrushConverter().ConvertFrom("#d5e0f2"));//"#d5e0f2";
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btn2.Background = Brushes.White;
            CheckSugar(btn2);
            if (flag1 != false || flag2 != false || flag3 != false || flag4 != false)
            {
                TaskWindow taskWindow = new TaskWindow();
                var uriImageSource = new Uri(@"/HomeWork48WPF;component/coffeemilk.png", UriKind.RelativeOrAbsolute);
                taskWindow.foto.Source = new BitmapImage(uriImageSource);
                string result = String.Format("{0:C}", price);
                taskWindow.myPrice.Text = taskWindow.myPrice.Text + result;
                taskWindow.Show();
                Application.Current.MainWindow.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btn3.Background = Brushes.White;
            CheckSugar(btn3);
            if (flag1 != false || flag2 != false || flag3 != false || flag4 != false)
            {
                TaskWindow taskWindow = new TaskWindow();
                var uriImageSource = new Uri(@"/HomeWork48WPF;component/coffeelatte.png", UriKind.RelativeOrAbsolute);
                taskWindow.foto.Source = new BitmapImage(uriImageSource);
                string result = String.Format("{0:C}", price);
                taskWindow.myPrice.Text = taskWindow.myPrice.Text + result;
                taskWindow.Show();
                Application.Current.MainWindow.Close();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            btn4.Background = Brushes.White;
            CheckSugar(btn4);
            if (flag1 != false || flag2 != false || flag3 != false || flag4 != false)
            {
                TaskWindow taskWindow = new TaskWindow();
                var uriImageSource = new Uri(@"/HomeWork48WPF;component/coffeecappuccino.png", UriKind.RelativeOrAbsolute);
                taskWindow.foto.Source = new BitmapImage(uriImageSource);
                string result = String.Format("{0:C}", price);
                taskWindow.myPrice.Text = taskWindow.myPrice.Text + result;
                taskWindow.Show();
                Application.Current.MainWindow.Close();
            }
        }
 
    }
}
