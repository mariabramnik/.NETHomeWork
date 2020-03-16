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

namespace HomeWork51part2GetFlight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //class for comfortable display information
        public class MyFlight
        {
            public int FlightId { get; set; }
            public string AirLinecompName { get; set; }
            public string OriginCountryName { get; set; }
            public string DestCountryName { get; set; }
            public DateTime DepartureTime { get; set; }
            public DateTime LandingTime { get; set; }
            public int RemainingTickets { get; set; }
            public string FlightStatus { get; set; }
        }

        public MainWindow()
        {
            
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyFlight myFl = new MyFlight();
                int number;
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                IAnonymousUserFacade iAnonym = fs.GetFacade<IAnonymousUserFacade>();
                string text = myTextBox.Text;
                if (text == "")
                {
                    MessageBox.Show("Enter flight number");
                }
                else
                {
                    bool res = Int32.TryParse(text, out number);
                    if (res == true)
                    {
                        Flight flight = iAnonym.GetFlightById(number);
                        myFl.FlightId = flight.id;
                        myFl.LandingTime = flight.landingTime;
                        myFl.DepartureTime = flight.departureTime;
                        myFl.RemainingTickets = flight.remainingTickets;
                        IList<Country> listCountries = iAnonym.GetAllCountries();
                        IList<AirLineCompany> listAirLine = iAnonym.GetAllAirLineCompanies();
                        IList<FlightStatus> listFlightStatus = iAnonym.GetFlightStatuses();
                        foreach (Country country in listCountries)
                        {
                            if (country.id == flight.destinationCountryCode)
                            {
                                myFl.DestCountryName = country.countryName;
                            }
                            if (country.id == flight.originCountryCode)
                            {
                                myFl.OriginCountryName = country.countryName;
                            }
                        }
                        foreach (AirLineCompany comp in listAirLine)
                        {
                            if (flight.airLineCompanyId == comp.id)
                            {
                                myFl.AirLinecompName = comp.airLineName;
                            }
                        }
                        foreach (FlightStatus fl in listFlightStatus)
                        {
                            if (fl.id == flight.flightStatusId)
                            {
                                myFl.FlightStatus = fl.statusName;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Sorry,enter flight number, only digits");
                        myTextBox.Text = "";
                        myFl = null;
                    }

                }
                if (!(myFl is null))
                {
                    // make the column names visible
                    IdTextBlock.Visibility = Visibility;
                    AirLineTextBlock.Visibility = Visibility;
                    OrigCountryTextBlock.Visibility = Visibility;
                    DestCountryTextBlock.Visibility = Visibility;
                    DepTimeTextBlock.Visibility = Visibility;
                    LandTimeTextBlock.Visibility = Visibility;
                    RemTicketTextBlock.Visibility = Visibility;
                    FlightStatusTextBlock.Visibility = Visibility;
                    // give to xaml this object
                    this.DataContext = myFl;
                }
            }
            catch           
            {
                MessageBox.Show("Sorry,this flight is not exist in  our FlightSystem");
            }

        }
    }
}
