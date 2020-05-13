using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;
using FlightManagementSystem.Modules.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject2.Controllers
{
    public class HomeController : Controller
    {
        
        FlyingCenterSystem fs = FlyingCenterSystem.Instance;
        public ActionResult Index()
        {
           // GenerateFlights12Hours();
            ViewBag.Title = "Home Page";

            return View();
        }
        public void GenerateFlights12Hours()
        {
            LoginService ls = new LoginService();
            LoginToken<AirLineCompany> ltAirLine = null;
            //1.
            bool res1 = ls.TryAirLineLogin("testPassword", "air corsicaAdmin", out ltAirLine);
            if (res1 == true)
            {
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(3);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(5);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Israel");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Latvia");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //2
            bool res2 = ls.TryAirLineLogin("264dxt", "air franceAdmin", out ltAirLine);
            if (res2 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(4);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(7);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Austria");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Brazil");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //3.
            bool res3 = ls.TryAirLineLogin("634ggh", "air guyane expressAdmin", out ltAirLine);
            if (res3 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(1);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(6);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Chile");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Canada");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //4
            bool res4 = ls.TryAirLineLogin("264dxt", "air franceAdmin", out ltAirLine);
            if (res4 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(4);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(7);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Cyprus");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Israel");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //5
            bool res5 = ls.TryAirLineLogin("075qpl", "corsair internationalAdmin", out ltAirLine);
            if (res5 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(7);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(10);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Denmark");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Estonia");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //6
            bool res6 = ls.TryAirLineLogin("876kbs", "french beeAdmin", out ltAirLine);
            if (res6 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(2);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(5);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "France");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Finland");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //7
            bool res7 = ls.TryAirLineLogin("204vuc", "hop!Admin", out ltAirLine);
            if (res7 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(8);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(11);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Germany");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Greece");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //8
            bool res8 = ls.TryAirLineLogin("136qru", "la compagnieAdmin", out ltAirLine);
            if (res8 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(3);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(10);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "India");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Italy");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //9
            bool res9 = ls.TryAirLineLogin("204vuc", "hop!Admin", out ltAirLine);
            if (res9 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(7);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(9);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Norway");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Latvia");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
            //10
            bool res10 = ls.TryAirLineLogin("013xtn", "st barth commuterAdmin", out ltAirLine);
            if (res10 == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                DateTime nowTime = DateTime.Now;
                DateTime departTime = nowTime.AddHours(8);
                //   DateTime departTime = new DateTime(2020, 4, 02, 21, 15, 00);
                //   DateTime landingTime = new DateTime(2020, 4, 03, 05, 05, 00);
                DateTime landingTime = nowTime.AddHours(12);
                Country country1 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Sweden");
                Country country2 = iAirlineCompanyFS.GetCountryByName(ltAirLine, "Georgia");
                FlightStatus flStatus = iAirlineCompanyFS.GetFlightStatusByName(ltAirLine, "panding");
                Flight flight = new Flight(0, ltAirLine.User.id, country1.id, country2.id, departTime, landingTime, 0);
                flight.flightStatusId = flStatus.id;
                flight.remainingTickets = 100;
                int id = iAirlineCompanyFS.CreateFlight(ltAirLine, flight);
                flight.id = id;
            }
        }
    }
}
