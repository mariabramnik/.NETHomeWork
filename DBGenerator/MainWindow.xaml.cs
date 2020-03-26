using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;
using FlightManagementSystem.Modules.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace DBGenerator
{

  
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variables to read from the textbox how much you need to add to the database
        int countryNum = 0;
        int customersNum = 0;
        int numAirLineCompanies = 0;
        int myTicketCount = 0;
        int flightsNum = 0;

        private static List<Country> allMyCountries = new List<Country>();      
        private static List<string> listAirLine = new List<string>();
        private static List<FlightStatus> listFlightsStatuses = new List<FlightStatus>();
        private static Dictionary<string, AirLineCompany> dictComp = new Dictionary<string, AirLineCompany>();
        private static List<Customer> listCustomers = new List<Customer>();

        public static Random rand = new Random();
        public static Random rand1 = new Random();
        public static Random rand2 = new Random();

        //counter that shows how much has already been created
        static int countCountries = 0;
        static int countCustomers = 0;
        static int countAirLineCompanies = 0;
        static int countFlights = 0;
        static int countTickets = 0;

        static BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
            this.CountriesTextBox.PreviewTextInput += new TextCompositionEventHandler(CountriesTextBox_PreviewTextInput);
            this.CustomersTextBox.PreviewTextInput += new TextCompositionEventHandler(CustomersTextBox_PreviewTextInput);
            this.AirlineTextBox.PreviewTextInput += new TextCompositionEventHandler(AirlineTextBox_PreviewTextInput);
            this.FlightsPerCompany.PreviewTextInput += new TextCompositionEventHandler(FlightsPerCompany_PreviewTextInput);
            this.TicketsPerCustomersTextBox.PreviewTextInput += new TextCompositionEventHandler(TicketsPerCustomersTextBox_PreviewTextInput);
            

        }
        //we control that only numbers are allowed.Numbers can be entered in a range.
        private void CountriesTextBox_PreviewTextInput(object sender,TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
                MessageBox.Show("Please,only numbers");
            }
            else
            {
                e.Handled = !IsValidNumberOfCountries(((TextBox)sender).Text + e.Text);
                if (e.Handled)
                {
                    MessageBox.Show("Please,only numbers from 1 to 220");
                }
            }
        }
        private bool IsValidNumberOfCountries(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 220;
        }
        private bool IsValidNumberOfCustomers(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 1000;
        }
        private void CustomersTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
                MessageBox.Show("Please,only numbers");
            }
            else
            {
                e.Handled = !IsValidNumberOfCustomers(((TextBox)sender).Text + e.Text);
                if (e.Handled)
                {
                    MessageBox.Show("Please,only numbers from 1 to 1000");
                }
            }
        }
        private void AirlineTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
                MessageBox.Show("Please,only numbers");
            }
            else
            {
                e.Handled = !IsValidNumberOfAirLinesCompanies(((TextBox)sender).Text + e.Text);
                if(e.Handled)
                {
                    MessageBox.Show("Please,only numbers from 1 to 12");
                }
            }
        }
        private bool IsValidNumberOfAirLinesCompanies(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 12;
        }

        private void FlightsPerCompany_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
        private void TicketsPerCustomersTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        //generate credit card number
        private string CreditCardNumber()
        {
            string res = "";          
            for(int i = 0; i < 16; i++)
            {
                int num = rand.Next(0, 9);
                res += num.ToString();
            }
            return res;
        }
        //generate password
        private string GeneratePassword()
        {
            string str = "";
            string res = "";
            for (int i = 0; i < 3; i++)
            {
                int num = rand.Next(0, 9);
                res += num.ToString();
            }
            for(int i = 0; i < 3; i++)
            {
                int cNum = rand.Next(97, 122);
                str = Convert.ToString(cNum, 16);
                string hexStr = "0x" + str;
            //    int hex = Int32.Parse(hexStr);
                char c = ((char)cNum);
                res += c;
            }
            return res;
        }
        //for button "Replace"
        private void WorkerCreating()
        {
            worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }
        //for button "Add"
        private void Add_WorkerCreating()
        {
            worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_Add_DoWork;
            worker.ProgressChanged += worker_Add_ProgressChanged;
            worker.RunWorkerAsync();
        }
        //for button "Replace"
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            //progressBarTextBox.Text = (string)e.UserState;
            progressBarTextBoxCountries.Text = countCountries.ToString() + $" countries from {countryNum} created";
            progressBarTextBoxFlights.Text = countFlights.ToString() + $" flights from {flightsNum} created ";
            progressBarTextBoxAirLineComp.Text = countAirLineCompanies.ToString() + $" airline companies from {numAirLineCompanies} created";
            progressBarTextBoxTickets.Text = countTickets.ToString() + $" tickets from {myTicketCount} created";
            progressBarTextBoxCustomers.Text = countCustomers.ToString() + $" customers from {customersNum}created";
        }
        //for button "Add" .The button "Add' does not allow you to add a Country or Airline.
        private void worker_Add_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AirlineTextBox.Text = "0";
            AirlineTextBox.IsReadOnly = true;
            CountriesTextBox.Text = "0";
            CountriesTextBox.IsReadOnly = true;
            pbStatus.Value = e.ProgressPercentage;
            //progressBarTextBox.Text = (string)e.UserState;
           // progressBarTextBoxCountries.Text = countCountries.ToString() + $" countries from {countryNum} created";
            progressBarTextBoxFlights.Text = countFlights.ToString() + $" flights from {flightsNum} created ";
            //progressBarTextBoxAirLineComp.Text = countAirLineCompanies.ToString() + $" airline companies from {numAirLineCompanies} created";
            progressBarTextBoxTickets.Text = countTickets.ToString() + $" tickets from {myTicketCount} created";
            progressBarTextBoxCustomers.Text = countCustomers.ToString() + $" customers from {customersNum}created";
        }


        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {         
            AirlineTextBox.IsReadOnly = false;          
            CountriesTextBox.IsReadOnly = false;
            MessageBox.Show("All Done");
    
        }
        //for button "Replace"
        private void worker_DoWork(object sender,DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            LoginService ls = new LoginService();
            LoginToken<Administrator> ltAdmin = null;
            bool res = ls.TryAdminLogin("9999", "admin", out ltAdmin);
            if (res == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                //ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                //iAirlineCompanyFS.GetAllFlights();
                ILoggedInAdministratorFacade iAdminFS = fs.GetFacade<ILoggedInAdministratorFacade>();
                iAdminFS.RemoveAllFromDB(ltAdmin);
                worker.ReportProgress(15);
                GenerateCountries(ltAdmin, iAdminFS);
                GenerateCustomers(ltAdmin, iAdminFS);
                worker.ReportProgress(45);
                GenerateAirLineCompanies(ltAdmin, iAdminFS);
                worker.ReportProgress(60);
                GenerateFlightStatuses(ltAdmin, iAdminFS);
                worker.ReportProgress(75);
                GenerateFlightsPerCompany();
                worker.ReportProgress(90);
                GenerateTicketsPerCustomer();
                worker.ReportProgress(100);
            }
            else
            {
                // MessageBox.Show("I haven't entered to the FlightSystem as adim", "Info", MessageBoxButton.OK);
            }
            worker.ReportProgress(100, "Done processsing.");
        }

        //for button "Add" 
        private void worker_Add_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            LoginService ls = new LoginService();
            LoginToken<Administrator> ltAdmin = null;
            bool res = ls.TryAdminLogin("9999", "admin", out ltAdmin);
            if (res == true)
            {
                countFlights = 0;
                countCustomers = 0;
                countTickets = 0;
               
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
               //ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
               //iAirlineCompanyFS.GetAllFlights();
                 ILoggedInAdministratorFacade iAdminFS = fs.GetFacade<ILoggedInAdministratorFacade>();
                //iAdminFS.RemoveAllFromDB(ltAdmin);
                if (allMyCountries.Count == 0)
                {
                    AllMyCountries(ltAdmin, iAdminFS);
                }
                if (listAirLine.Count == 0)
                {
                    AllMyAirLineCompanies(ltAdmin, iAdminFS);
                }
                if (listFlightsStatuses.Count == 0)
                {
                    AllMyFlightStatuses(ltAdmin, iAdminFS);
                }
                if(listCustomers.Count == 0)
                {
                    AllMyCustomers(ltAdmin, iAdminFS);
                }
                 worker.ReportProgress(15);             
                 GenerateCustomers(ltAdmin, iAdminFS);
                 worker.ReportProgress(45);
                 GenerateFlightsPerCompany();
                 worker.ReportProgress(75);
                 GenerateTicketsPerCustomer();
                 worker.ReportProgress(100);
            }
            else
            {
                // MessageBox.Show("I haven't entered to the FlightSystem as adim", "Info", MessageBoxButton.OK);
            }
            worker.ReportProgress(100, "Done processsing.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            countryNum = Int32.Parse(CountriesTextBox.Text);
            customersNum = Int32.Parse(CustomersTextBox.Text);
            numAirLineCompanies = Int32.Parse(AirlineTextBox.Text);
            myTicketCount = Int32.Parse(TicketsPerCustomersTextBox.Text);
            flightsNum = Int32.Parse(FlightsPerCompany.Text);
            WorkerCreating();
        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {      
            customersNum = Int32.Parse(CustomersTextBox.Text);
            myTicketCount = Int32.Parse(TicketsPerCustomersTextBox.Text);
            flightsNum = Int32.Parse(FlightsPerCompany.Text);
            countryNum = 0;
            numAirLineCompanies = 0;
            Add_WorkerCreating();
        }
        //for button "Add" Get all airlines, all customers ,all countries and flightstatuses from the DB. 
        // use them to create new flights and tickets.
        private void AllMyCountries(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {

            allMyCountries = (List<Country>)iAdminFS.GetAllCountries();

        }
        private void AllMyAirLineCompanies(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {
            IList<AirLineCompany> listAirLineComp = new List<AirLineCompany>();
            listAirLineComp = iAdminFS.GetAllAirLineCompanies();         
            foreach(AirLineCompany comp in listAirLineComp)
            {
                listAirLine.Add(comp.airLineName);
                dictComp.Add(comp.airLineName, comp);
            }   
        }
        private void AllMyFlightStatuses(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {
            listFlightsStatuses = (List<FlightStatus>)iAdminFS.GetFlightStatuses();
        }

        private void AllMyCustomers(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {
            listCustomers = (List<Customer>)iAdminFS.GetAllCustomers(ltAdmin);
        }
        private void GenerateCountries(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {
            string baseUrl = "https://restcountries.eu/rest/v2/all/";
            string queryFilter = "?fields=name";
            //string searchTerm = "IL";
            HttpClient http = new HttpClient();
            string url = baseUrl + queryFilter;
            HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<CountryAPI> countries = new List<CountryAPI>();
            countries = JsonConvert.DeserializeObject<List<CountryAPI>>(responseBody);
            int count = 0;
            foreach (CountryAPI cntr in countries)
            {
                cntr.name = cntr.name.Replace("'", "");
                Country country = new Country(0, cntr.name);
                int newCountryId = iAdminFS.CreateCountry(ltAdmin, country);
                allMyCountries.Add(new Country(newCountryId, country.countryName));
                countCountries++;
                if (++count == countryNum)
                {
                    break;
                }
                int cntrCountries = (int)(15 + 15.0 / (double)(countryNum) * countCountries + 0.5);
                worker.ReportProgress(cntrCountries);
                Thread.Sleep(60);
            }
        }
        private void GenerateCustomers(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {
            string url = "https://api.randomuser.me";
            HttpClient http = new HttpClient();
            List<Person> listPerson = new List<Person>();
            for (int i = 0; i < customersNum; i++)
            {
                HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Person person = JsonConvert.DeserializeObject<Person>(responseBody);
                listPerson.Add(person);
            }
            foreach (Person pers in listPerson)
            {
                char[] liters = new char []{ 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
                    'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
                int indexRand1 = rand2.Next(0, 25);
                Customer customer = new Customer();
                customer.id = 0;
                customer.firstName = pers.results[0].name.first;
                customer.firstName = customer.firstName.Replace("'", "");
                customer.lastName = pers.results[0].name.last;
                customer.lastName = customer.lastName + liters[indexRand1].ToString();
                customer.lastName = customer.lastName.Replace("'", "");
                customer.userName = pers.results[0].login.username;
                customer.password = pers.results[0].login.password;
                customer.address = pers.results[0].location.street.name + " " +
                pers.results[0].location.street.number + " " +
                pers.results[0].location.city;
                customer.address = customer.address.Replace("'", "");
                customer.phoneNo = pers.results[0].phone;
                customer.creditCardNumber = CreditCardNumber();
                int newCustomerId = iAdminFS.CreateNewCustomer(ltAdmin, customer);
                countCustomers++;
                customer.id = newCustomerId;
                listCustomers.Add(customer);
                int cntrCustomers = (int)(30 + 15.0 / (double)(customersNum) * countCustomers + 0.5);
                worker.ReportProgress(cntrCustomers);
                Thread.Sleep(60);
            }

        }
        private void GenerateAirLineCompanies(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {
            string url = "https://en.wikipedia.org/wiki/List_of_airlines_of_France";
            /*Task task = WriteWebRequestSizeAsync(url);
            while (!task.Wait(100))
            {
                //Console.Write(".");
            }*/
            int franceId = 0;
            HttpClient http = new HttpClient();
            HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            responseBody = responseBody.Substring(responseBody.IndexOf("Scheduled Airlines", 0));
             responseBody = responseBody.Substring(responseBody.IndexOf("<tbody>", 0));
            string airCompHtml = responseBody;
            string strTest = "\\/<>*&#...";
            for (int i = 0; i < numAirLineCompanies; i++)
            {
                airCompHtml = airCompHtml.Substring(airCompHtml.IndexOf("<tr>", 0));
                airCompHtml = airCompHtml.Substring(airCompHtml.IndexOf("title=", 0) + 7);
                string airCompName = airCompHtml.Substring(0, airCompHtml.IndexOf(">", 0) - 1);
                if (airCompName.IndexOfAny(strTest.ToCharArray()) == -1)
                {
                    listAirLine.Add(airCompName);
                }
                else
                {
                    i--;
                }
            }
            Country countryFr = iAdminFS.GetCountryByName(ltAdmin, "France");
            if (countryFr is null)
            {
                Country france = new Country(0, "France");
                franceId = iAdminFS.CreateCountry(ltAdmin, france);
            }
            else
            {
                franceId = countryFr.id;
            }
            foreach (string airLineName in listAirLine)
            {
                AirLineCompany company = new AirLineCompany();
                company.airLineName = airLineName;
                company.countryCode = franceId;
                string name = airLineName.ToLower();
                name.Replace(" ", "");
                name.Replace("-", "");
                company.userName = name + "Admin";
                company.password = GeneratePassword();
                company.id = 0;
                int newAirLineId = iAdminFS.CreateNewairLine(ltAdmin, company);
                countAirLineCompanies++;
                company.id = newAirLineId;
                dictComp.Add(company.airLineName, company);

                int cntrAirLines = (int)(45 + 15.0 / (double)(numAirLineCompanies) * countAirLineCompanies + 0.5);
                worker.ReportProgress(cntrAirLines);
                Thread.Sleep(60);
            }
        }
        private void GenerateFlightStatuses(LoginToken<Administrator> ltAdmin, ILoggedInAdministratorFacade iAdminFS)
        {
            FlightStatus flStatus1 = new FlightStatus(0, "panding");
            int id1 = iAdminFS.CreateFlightStatus(ltAdmin, flStatus1);
            FlightStatus flStatus2 = new FlightStatus(0, "landing");
            int id2 = iAdminFS.CreateFlightStatus(ltAdmin, flStatus2);
            FlightStatus flStatus3 = new FlightStatus(0, "flying");
            int id3 = iAdminFS.CreateFlightStatus(ltAdmin, flStatus3);          
            listFlightsStatuses.Add(new FlightStatus(id1, "panding"));
            listFlightsStatuses.Add(new FlightStatus(id2, "landing"));
            listFlightsStatuses.Add(new FlightStatus(id3, "flying"));

        }
        private void GenerateFlightsPerCompany()
        {
            int airLineCompaniesNum = dictComp.Count();
            int allMyCountriesCount = allMyCountries.Count();
            String[] arrComp = listAirLine.ToArray();
            for (int i = 0; i < flightsNum; i++)
            {
                int randComp = rand.Next(0, airLineCompaniesNum - 1);
                string name = arrComp[randComp];
                AirLineCompany currentCompany = dictComp[name];
                LoginService ls = new LoginService();
                LoginToken<AirLineCompany> ltAirLine = null;
                bool res = ls.TryAirLineLogin(currentCompany.password, currentCompany.userName, out ltAirLine);
                if (res == true)
                {
                    FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                    ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                    Flight flight = new Flight();
                    flight.id = 0;
                    flight.airLineCompanyId = currentCompany.id;
                    int randOriginCountry = rand.Next(0, allMyCountriesCount - 1);
                    int randDestCountry = rand.Next(0, allMyCountriesCount - 1);
                    Country[] arrCountries = allMyCountries.ToArray();
                    flight.originCountryCode = arrCountries[randOriginCountry].id;
                    flight.destinationCountryCode = arrCountries[randDestCountry].id;
                    int randRemainingTickets = rand.Next(50, 800);
                    flight.remainingTickets = randRemainingTickets;
                    FlightStatus flSt = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine,"panding");
                    flight.flightStatusId = flSt.id;
                    DateTime depart = ReturnRandomDateDepart();
                    DateTime landing = ReturnRandomDateLanding(depart);  
                    flight.departureTime = depart;
                    flight.landingTime = landing;
                    iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                    countFlights++;
                    int cntrFlights = (int)(60 + 15.0 / (double)(flightsNum) * countFlights + 0.5);
                    worker.ReportProgress(cntrFlights);
                    Thread.Sleep(60);
                }
            }
        }
        private DateTime ReturnRandomDateDepart()
        {
            DateTime dt = DateTime.Now;
            int month = dt.Month;
            DateTime dtNow = new DateTime(2020, month, 1, 00, 00, 00);
            int randMonthsDepart = rand.Next(1, 8);
            int randDaysDepart = rand.Next(1, 30);
            int randHoursDepart = rand.Next(0, 22);
            DateTime dtCurr = new DateTime(dtNow.Year, dtNow.Month + randMonthsDepart, dtNow.Day + randDaysDepart, dtNow.Hour + randHoursDepart, 00, 00);

            return dtCurr;
        }
        private DateTime ReturnRandomDateLanding(DateTime depart)
        {
            int departhours = depart.Hour;
            int diff = 24 - departhours;
            int randHours = rand1.Next(1, diff);
            int randMinutes = rand1.Next(0, 59);
            DateTime landingTime = new DateTime(depart.Year, depart.Month, depart.Day, depart.Hour + randHours, randMinutes, 00);
      
            return landingTime;
        }
        private void GenerateTicketsPerCustomer()
        {
            int custCount = listCustomers.Count;
            Customer[] arrCust = listCustomers.ToArray();
            
            for (int i = 0; i < myTicketCount; i++)
            {
                bool flagThisTicketAlreadyExists = false;
                int ranCust = rand1.Next(1, custCount - 1);
                Customer currCustomer = arrCust[ranCust];
                LoginService ls = new LoginService();
                LoginToken<Customer> ltCustomer = null;
                bool res = ls.TryCustomerLogin(currCustomer.password, currCustomer.userName, out ltCustomer);
                if (res == true)
                {
                    FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                    ILoggedInCustomerFacade iCustomerFS = fs.GetFacade<ILoggedInCustomerFacade>();
                    Ticket ticket = new Ticket();
                    ticket.id = 0;
                    ticket.customerId = currCustomer.id;
                    Dictionary<Flight, int> dictFlights = iCustomerFS.GetAllFlightsVacancy(ltCustomer);
                    int flightsCount = dictFlights.Count;
                    List<int> idFlightsList = new List<int>();
                    foreach(KeyValuePair<Flight,int>valuePair in dictFlights)
                    {
                        idFlightsList.Add(valuePair.Value);
                    }
                    int[] arrId = idFlightsList.ToArray();
                    int randFlights = rand.Next(1, flightsCount );
                    int randId = arrId[randFlights];
                    ticket.flightId = randId;
                    IList<Ticket>listTickets = iCustomerFS.GetAllMyTickets(ltCustomer);
                    foreach(Ticket myticket in listTickets)
                    {
                        if(myticket.flightId == randId)
                        {
                            i--;
                            flagThisTicketAlreadyExists = true;
                        }
                    }
                    if (flagThisTicketAlreadyExists == false)
                    {
                        Flight currFlight = iCustomerFS.GetFlightByIdFlight(ltCustomer, randId);
                        iCustomerFS.PurchaseTicket(ltCustomer, currFlight);
                        countTickets++;
                        int cntrTickets = (int)(75 + 15.0 / (double)(myTicketCount) * countTickets + 0.5);
                        worker.ReportProgress(cntrTickets);
                        Thread.Sleep(60);
                    }


                }
            }
        }

    }
}
