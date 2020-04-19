using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole2
{
    class Program
    {
        
        static void Main(string[] args)
        {

            ClassTest test = new ClassTest();
            // testing a method from AnonymeController
            //test.GetAllAirLines();

            /*
            Console.WriteLine("Enter AirLine name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter userName :");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string airlinePassword = Console.ReadLine();        
            test.GetAllCountries();
            Console.WriteLine("Enter CountryCode from current list : ");
            string code = Console.ReadLine();
            int airlineCountryCode = test.EnterOnlyNumber(code);

            AirLineCompany comp = new AirLineCompany
            {
                id = 0,
                airLineName = name,
                userName = username,
                password = airlinePassword,
                countryCode = airlineCountryCode
            };
         // testing a method from AdminController
            test.AddAirLine(comp);
*/
            // testing a method from AnonymeController
            //test.GetAllCountries();
            // Console.ReadLine();

            // testing a method from AirLineController
            // test.GetAllFlightsOfMyCompany();

         // testing a method from AnonymeController. return list of flights , 
         //from it cuctomer can select a flight and buy a ticket
            test.GetFlightsVacancy();
            Console.WriteLine("Choose one of the flights from the list :");
            Console.WriteLine("Enter Flights id:");
            string id = Console.ReadLine();
            int flId = test.EnterOnlyNumber(id);
            Console.WriteLine("Enter airLineCompanyId :");
            string airline = Console.ReadLine();
            int airLineId = test.EnterOnlyNumber(airline);
            //test.GetAllCountry();
            Console.WriteLine("Enter originCountryCode");
            string originCounry = Console.ReadLine();
            int myOriginCountryCode = test.EnterOnlyNumber(originCounry);
            Console.WriteLine("Enter destinationCountryCode");
            string destCountry = Console.ReadLine();
            int myDestCountryCode = test.EnterOnlyNumber(destCountry);
            Console.WriteLine("Enter departure time in format(Aug 10,2020)");
            string myDepartupeTime = Console.ReadLine();
            DateTime departureDate = DateTime.Parse(myDepartupeTime);
            Console.WriteLine("Enter landing time in format(Aug 10, 2020)");
            string myLandingTime = Console.ReadLine();
            DateTime landingDate = DateTime.Parse(myLandingTime);
            Console.WriteLine("Enter remaining tickets");
            string numRemainingTickets = Console.ReadLine();
            int myRemainingTickets = test.EnterOnlyNumber(numRemainingTickets);
            Console.WriteLine("Enter Flight Status code");
            string flightStatus = Console.ReadLine();
            int flightStatusCode = test.EnterOnlyNumber(flightStatus);

            Flight flight = new Flight
            {
                id = flId,
                airLineCompanyId = airLineId,
                originCountryCode = myOriginCountryCode,
                destinationCountryCode = myDestCountryCode,
                departureTime = departureDate,
                landingTime = landingDate,
                remainingTickets = myRemainingTickets,
                flightStatusId = flightStatusCode
            };
         //testing a method from CustomerController   
            test.PurchaseTicket(flight);

        }
      
    }
}
