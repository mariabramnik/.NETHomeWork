using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;
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

namespace HomeWork50Part3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public MainWindow() 
        {
            InitializeComponent();
            FlyingCenterSystem fs = FlyingCenterSystem.Instance;
            IAnonymousUserFacade iAnonym = fs.GetFacade<IAnonymousUserFacade>();
            Dictionary<Flight, int> dictAllFlightsVacancy = iAnonym.GetAllFlightsVacancy();
            List<Flight> listFl = new List<Flight>();
            IList<AirLineCompany> listAirLine = iAnonym.GetAllAirLineCompanies();
            foreach(KeyValuePair<Flight,int> valuePair in dictAllFlightsVacancy)
            {
                listFl.Add(valuePair.Key);
                
            }
            
            myListBox.ItemsSource = listFl;
            // myListBox.ItemsSource = listAirLine;

        }

    }
}
