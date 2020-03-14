
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

namespace HomeWork49ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Country[] countries = Country.GetCountries();
            myComboBox.ItemsSource = countries;
            myComboBox1.ItemsSource = countries;
            this.myComboBox1.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);


        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            //string text = this.myComboBox1.Text;
            //MessageBox.Show(text);
            myComboBox1.Background = Brushes.Red;




        }
    }
}
