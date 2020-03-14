using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //class for comfortable display information
        public class MyFlight
        {
            public int Id { get; set; }
            public string AirLinecompName { get; set; }
            public string OriginCountryName { get; set; }
            public string DestCountryName { get; set; }
            public DateTime DepartureTime { get; set; }
            public DateTime LandingTime { get; set; }
            public int RemainingTickets { get; set; }
            public string FlightStatus { get; set; }
        }
        ObservableCollection<Flight> flights = new ObservableCollection<Flight>();

        public MainWindow() 
        {
            InitializeComponent();
            FlyingCenterSystem fs = FlyingCenterSystem.Instance;
            IAnonymousUserFacade iAnonym = fs.GetFacade<IAnonymousUserFacade>();
            Dictionary<Flight, int> dictAllFlightsVacancy = iAnonym.GetAllFlightsVacancy();
            // ObservableCollection<Flight> listFl = new ObservableCollection<Flight>();
            List<MyFlight> listFl = new List<MyFlight>();
            IList<Country> listCountry = iAnonym.GetAllCountries();
            IList<FlightStatus> listFlStatus = iAnonym.GetFlightStatuses();
            IList<AirLineCompany> listAirLine = iAnonym.GetAllAirLineCompanies();
            foreach(KeyValuePair<Flight,int> valuePair in dictAllFlightsVacancy)
            {
                MyFlight myfl = new MyFlight();
                myfl.Id = valuePair.Key.id;
                myfl.DepartureTime = valuePair.Key.departureTime;
                myfl.LandingTime = valuePair.Key.landingTime;
                myfl.RemainingTickets = valuePair.Key.remainingTickets;
                int airLinecompId = valuePair.Key.airLineCompanyId;
                foreach(AirLineCompany comp in  listAirLine)
                {
                    if(comp.id == airLinecompId)
                    {
                        myfl.AirLinecompName = comp.airLineName;
                    }
                }
                int originCountryId = valuePair.Key.originCountryCode;
                int destCountryId = valuePair.Key.destinationCountryCode;
                foreach(Country country in listCountry)
                {
                    if(country.id == originCountryId)
                    {
                        myfl.OriginCountryName = country.countryName;
                    }
                    if (country.id == destCountryId)
                    {
                        myfl.DestCountryName = country.countryName;
                    }
                }
                foreach(FlightStatus status in listFlStatus)
                {
                    if(status.id == valuePair.Key.flightStatusId)
                    {
                        myfl.FlightStatus = status.statusName;
                    }
                }
                listFl.Add(myfl);
            }
            
            this.myListBox.ItemsSource = listFl;

        }

    }
}
