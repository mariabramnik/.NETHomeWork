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

namespace HomeWork51Colors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random rand = new Random();
        public static string[] colorArr = new string[] { "Red", "Green", "Blue", "Yellow","Indigo","Khaki","Lavender","Orchid","Orange","Tomato" };
        public MainWindow()
        {
            InitializeComponent();
                 Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int indexRand = rand.Next(0, 9);
                        string colorRand = colorArr[indexRand];
                        UpdateColor(colorRand);
                        Thread.Sleep(400);
                    }
                });
            
        }

        private void UpdateColor(string color)
        {
                Action a = () =>
                {
                    myBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
                };
                Dispatcher.Invoke(a);
           
               
        }
    }
}
