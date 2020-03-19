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

namespace HomeWork52part3BuyTicket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static LoginToken<Customer> token { get; set; }
        public static string userName { get; set; }
        public static  LoginWindow loginWindow;
        public Flight flight;

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
            loginWindow = new LoginWindow();
            loginWindow.ButtonSubmitClicked += LoginWindow_SubmitButtonClicked;
            InitializeComponent();
            //AppCommands.AnyCommand.CanExecuteChanged += MyEventHandler;
            
        }
        //when the сгыещьук logged in successfully
        private void LoginWindow_SubmitButtonClicked(object sender, EventArgs e)
        {
            textBlockuserName.Text = token.User.userName;
            textBlockuserName.Visibility = Visibility;
            BuyMyTicket();
        }

        private void BuyMyTicket()
        {
            bool ticketAlreadyPurchased = false;
            FlyingCenterSystem fs = FlyingCenterSystem.Instance;
            ILoggedInCustomerFacade iCustomerFS = fs.GetFacade<ILoggedInCustomerFacade>();
            IList<Ticket> listTickets = iCustomerFS.GetAllMyTickets(token);
            foreach(Ticket ticket in listTickets)
            {
                if(ticket.flightId == flight.id)
                {
                    MessageBox.Show("You have already bought a ticket for this flight");
                    ticketAlreadyPurchased = true;
                }
            }
            if(ticketAlreadyPurchased == false)
            {
                Ticket myTicket = iCustomerFS.PurchaseTicket(token, flight);
                ticketIsPurchase.Visibility = Visibility;
                TextBlockTicketId.Text = "Ticket Id : " + myTicket.id.ToString();
                TextBlockFlightIdNumber.Text = "Flight Id : " + myTicket.flightId.ToString();
                TextBlockCustomer.Text = "Customer : " + token.User.firstName + " " + token.User.lastName;
                TextBlockTicketId.Visibility = Visibility;
                TextBlockFlightIdNumber.Visibility = Visibility;
                TextBlockCustomer.Visibility = Visibility;
                BuyTicket.Visibility = Visibility.Hidden;
                TextBlockFlightRemTicket.Text = (Int32.Parse(TextBlockFlightRemTicket.Text) - 1).ToString();

            }

        }
        //display flight details
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
                        flight = iAnonym.GetFlightById(number);
                        myFl.FlightId = flight.id;
                        myFl.LandingTime = flight.landingTime;
                        myFl.DepartureTime = flight.departureTime;
                        myFl.RemainingTickets = flight.remainingTickets;
                        if(myFl.RemainingTickets == 0)
                        {
                            AppCommands.flagPurchasePossible = false;
                            //BuyTicket.IsEnabled = false;
                        }
                        else
                        {
                            AppCommands.flagPurchasePossible = true;
                           
                        }
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
                    BuyTicket.Visibility = Visibility;
                    // give to xaml this object
                    this.DataContext = myFl;
                }
            }
            catch
            {
                MessageBox.Show("Sorry,this flight is not exist in  our FlightSystem");
            }

        }

        private void Ticket_Buy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
