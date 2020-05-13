using ASPProject2.Models;
using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ASPProject2.Controllers
{
    public class PageController : Controller
    {
        FlyingCenterSystem fs = FlyingCenterSystem.Instance;
        public static  Random ran = new Random();
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Departure()
        {
            // get anonymous facade
            
            List<FlightDisplay> listFlightdisplay = new List<FlightDisplay>();
            List<Flight> result = new List<Flight>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();

                result = (List<Flight>)anonymeFacade.GetFlightsByDepartureTime12Hours();
                foreach(Flight flight in result)
                {
                    FlightDisplay flightDisplay = new FlightDisplay();
                    flightDisplay.id = flight.id;
                    int airLineId = flight.airLineCompanyId;
                    AirLineCompany comp = anonymeFacade.GetAirLineById(airLineId);
                    flightDisplay.AirlineName = comp.airLineName;
                    Country originCountry = anonymeFacade.GetCountryById(flight.originCountryCode);
                    string originCountryName = originCountry.countryName;
                    List<City> listCities = (List<City>)anonymeFacade.GetAllByCountry(originCountryName);
                    City[] arrCities = listCities.ToArray();
                    flightDisplay.OriginCity = arrCities[0].city;
                    Country destinationCountry = anonymeFacade.GetCountryById(flight.destinationCountryCode);
                    string destinationCountryName = destinationCountry.countryName;
                    List<City> listCities2 = (List<City>)anonymeFacade.GetAllByCountry(destinationCountryName);
                    City[] arrCities2 = listCities2.ToArray();
                    flightDisplay.DestinationCity = arrCities2[0].city;
                    flightDisplay.DepartureTime = flight.departureTime.ToString("HH:mm");
                    flightDisplay.LandingTime = flight.landingTime.ToString("HH:mm");
                    flightDisplay.Status = "ON TIME";              
                    listFlightdisplay.Add(flightDisplay);
                }
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
           
            int size = listFlightdisplay.Count;
            if (size > 0)
            {
                int num1 = ran.Next(0, size - 1);
                int num2 = ran.Next(0, size - 1);
                FlightDisplay[] arrFlightDisplay = listFlightdisplay.ToArray();
                arrFlightDisplay[num1].Status = "DELAYED";
                arrFlightDisplay[num2].Status = "DELAYED";
                listFlightdisplay = arrFlightDisplay.ToList<FlightDisplay>();
            }
            ViewBag.FlightDisplay = listFlightdisplay;
            return View();
        }


        public ActionResult Landing()
        {
            DateTime nowTime = DateTime.Now;
            List<FlightDisplay> listFlightdisplay = new List<FlightDisplay>();
            List<Flight> result = new List<Flight>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                result = (List<Flight>)anonymeFacade.GetFlightsByLandingTime12Hours();
                List<Flight> resultCopy = new List<Flight>();
                resultCopy = result.GetRange(0, result.Count);

                foreach (Flight flight in resultCopy)
                {               
                    if (flight.departureTime > nowTime)
                    {
                        result.Remove(flight);
                    }
                }
                foreach (Flight flight in result)
                {       
                    FlightDisplay flightDisplay = new FlightDisplay();
                    flightDisplay.id = flight.id;
                    int airLineId = flight.airLineCompanyId;
                    AirLineCompany comp = anonymeFacade.GetAirLineById(airLineId);
                    flightDisplay.AirlineName = comp.airLineName;
                    Country originCountry = anonymeFacade.GetCountryById(flight.originCountryCode);
                    string originCountryName = originCountry.countryName;
                    List<City> listCities = (List<City>)anonymeFacade.GetAllByCountry(originCountryName);
                    City[] arrCities = listCities.ToArray();
                    flightDisplay.OriginCity = arrCities[0].city;
                    Country destinationCountry = anonymeFacade.GetCountryById(flight.destinationCountryCode);
                    string destinationCountryName = destinationCountry.countryName;
                    List<City> listCities2 = (List<City>)anonymeFacade.GetAllByCountry(destinationCountryName);
                    City[] arrCities2 = listCities2.ToArray();
                    flightDisplay.DestinationCity = arrCities2[0].city;
                    flightDisplay.DepartureTime = flight.departureTime.ToString("HH:mm");
                    flightDisplay.LandingTime = flight.landingTime.ToString("HH:mm");
                    
                    TimeSpan diff1 = nowTime.Subtract(flight.landingTime);
                    var mydiff = flight.landingTime - nowTime;
                    int diff = mydiff.Minutes;
                    if(diff < 15 && diff > 0)
                    {
                        flightDisplay.Status = "Landing";
                    }
                    else if(diff > 15 && diff < 120)
                    {
                        flightDisplay.Status = "Final";
                    }
                    else if(diff == 0 ||  diff < 0)
                    {
                        flightDisplay.Status = "Landed";
                    }
                    else if(diff > 120)
                    {
                        flightDisplay.Status = "Not Final";
                    }
                  
                        listFlightdisplay.Add(flightDisplay);
       
                }
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
            
            int size = listFlightdisplay.Count;
            if (size > 0)
            {
                int num1 = ran.Next(0, size - 1);
                int num2 = ran.Next(0, size - 1);
                FlightDisplay[] arrFlightDisplay = listFlightdisplay.ToArray();
                arrFlightDisplay[num1].Status = "DELAYED";
                arrFlightDisplay[num2].Status = "DELAYED";
                listFlightdisplay = arrFlightDisplay.ToList<FlightDisplay>();
                
            }
            ViewBag.FlightDisplay = listFlightdisplay;
            return View();
            
        }
        public ActionResult Search()
        {
            return View();
        }
 
        public ActionResult SearchById(int ? id)
        {
         
                List<int> idList = new List<int>();
                List<Flight> result = new List<Flight>();
                try
                {
                    IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                    result = (List<Flight>)anonymeFacade.GetAllFlights();
                    foreach (Flight flight in result)
                    {
                        idList.Add(flight.id);
                    }

                }
                catch (Exception e)
                {
                    //return InternalServerError(e);
                }
                if(id != null)
                {
                    bool flag = false;
                    Flight fl = null;
                    try
                    {
                        IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                        fl = anonymeFacade.GetFlightById((int)id);
                    }
                    catch (Exception e)
                    {
                     //return InternalServerError(e);
                    }

                    FlightDisplaySearch flight = null;
                    flight = FromFlightToFlightDysplaySearch(fl);
                    ViewBag.flight = flight;
                    if (!(fl is null))
                    {
                        flag = true;
                    }
                    ViewBag.flag = flag;
                
                }
                ViewBag.idList = idList;
                return View();
        }

        public FlightDisplaySearch FromFlightToFlightDysplaySearch(Flight flight)
        {
            DateTime nowTime = DateTime.Now;
            FlyingCenterSystem fs = FlyingCenterSystem.Instance;
            IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
            FlightDisplaySearch fl = new FlightDisplaySearch();
            fl.id = flight.id;
            int airLineId = flight.airLineCompanyId;
            AirLineCompany comp = anonymeFacade.GetAirLineById(airLineId);
            fl.AirlineName = comp.airLineName;
            Country originCountry = anonymeFacade.GetCountryById(flight.originCountryCode);
            string originCountryName = originCountry.countryName;
            List<City> listCities = (List<City>)anonymeFacade.GetAllByCountry(originCountryName);
            if (listCities.Count > 0)
            {
                City[] arrCities = listCities.ToArray();
                fl.OriginCity = arrCities[0].city;
            }
            else
            {
                fl.OriginCity = originCountryName;
            }
        
            Country destinationCountry = anonymeFacade.GetCountryById(flight.destinationCountryCode);
            string destinationCountryName = destinationCountry.countryName;
            List<City> listCities2 = (List<City>)anonymeFacade.GetAllByCountry(destinationCountryName);
            if (listCities2.Count > 0)
            {
                City[] arrCities2 = listCities2.ToArray();
                fl.DestinationCity = arrCities2[0].city;
            }
            else
            {
                fl.DestinationCity = destinationCountryName;
            }
            fl.DepartureTime = flight.departureTime.ToString("MM/dd/yyyy HH:mm");
            fl.LandingTime = flight.landingTime.ToString("MM/dd/yyyy HH:mm");

            TimeSpan diff1 = nowTime.Subtract(flight.landingTime);
            var mydiff = flight.landingTime - nowTime;
            int diff = mydiff.Minutes;
            if (diff < 15 && diff > 0)
            {
                fl.Status = "Landing";
            }
            else if (diff > 15 && diff < 120)
            {
                fl.Status = "Final";
            }
            else if (diff == 0 || diff < 0)
            {
                fl.Status = "Landed";
            }
            else if (diff > 120)
            {
                fl.Status = "Not Final";
            }
            return fl;
        }

        public ActionResult SearchByAirline(int ? id)
        {
            List<AirLineCompany> airlineList = new List<AirLineCompany>();
            List<Flight> result = new List<Flight>();
            bool flag = false;
            List<FlightDisplaySearch> flightsListDisplay = new List<FlightDisplaySearch>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                airlineList = (List<AirLineCompany>)anonymeFacade.GetAllAirLineCompanies();
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
            if (id != null)
            {
                
                AirLineCompany company = null;
                try
                {
                    IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                    company = anonymeFacade.GetAirLineById((int)id);
                    result = (List<Flight>)anonymeFacade.GetAllFlightsByAirLineCompanies(company);
                }
                catch (Exception e)
                {
                    //return InternalServerError(e);
                }
                if(result.Count > 0)
                {
                    foreach(Flight fl in result)
                    {
                        FlightDisplaySearch flDispSearch = new FlightDisplaySearch();
                        flDispSearch = FromFlightToFlightDysplaySearch(fl);
                        flightsListDisplay.Add(flDispSearch);
                    }
                }           
               // ViewBag.flightsListDisplay = flightsListDisplay;
                if (flightsListDisplay.Count > 0)
                {
                    flag = true;
                    ViewBag.flightsListDisplay = flightsListDisplay;
                }
            }
            ViewBag.flag = flag;
            ViewBag.airlineList = airlineList;
            return View();
        }

        public ActionResult SearchByOriginCountry(int? id)
        {
            List<Country> countryList = new List<Country>();
            List<Flight> result = new List<Flight>();
            bool flag = false;
            List<FlightDisplaySearch> flightsListDisplay = new List<FlightDisplaySearch>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                countryList = (List<Country>)anonymeFacade.GetAllCountries();
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
            if (id != null)
            {

               // Country country = null;
                try
                {
                    IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                   // country = anonymeFacade.GetCountryById((int)id);
                    result = (List<Flight>)anonymeFacade.GetFlightsByOriginCountry((int)id);
                }
                catch (Exception e)
                {
                    //return InternalServerError(e);
                }
                if (result.Count > 0)
                {
                    foreach (Flight fl in result)
                    {
                        FlightDisplaySearch flDispSearch = new FlightDisplaySearch();
                        flDispSearch = FromFlightToFlightDysplaySearch(fl);
                        flightsListDisplay.Add(flDispSearch);
                    }
                }
                // ViewBag.flightsListDisplay = flightsListDisplay;
                if (flightsListDisplay.Count > 0)
                {
                    flag = true;
                    ViewBag.flightsListDisplay = flightsListDisplay;
                }
            }
            ViewBag.flag = flag;
            ViewBag.countryList = countryList;
            return View();
        }

        public ActionResult SearchByDestinationCountry(int? id)
        {
            List<Country> countryList = new List<Country>();
            List<Flight> result = new List<Flight>();
            bool flag = false;
            List<FlightDisplaySearch> flightsListDisplay = new List<FlightDisplaySearch>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                countryList = (List<Country>)anonymeFacade.GetAllCountries();
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
            if (id != null)
            {

                // Country country = null;
                try
                {
                    IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                    // country = anonymeFacade.GetCountryById((int)id);
                    result = (List<Flight>)anonymeFacade.GetFlightsByDesinationCountry((int)id);
                }
                catch (Exception e)
                {
                    //return InternalServerError(e);
                }
                if (result.Count > 0)
                {
                    foreach (Flight fl in result)
                    {
                        FlightDisplaySearch flDispSearch = new FlightDisplaySearch();
                        flDispSearch = FromFlightToFlightDysplaySearch(fl);
                        flightsListDisplay.Add(flDispSearch);
                    }
                }
                // ViewBag.flightsListDisplay = flightsListDisplay;
                if (flightsListDisplay.Count > 0)
                {
                    flag = true;
                    ViewBag.flightsListDisplay = flightsListDisplay;
                }
            }
            ViewBag.flag = flag;
            ViewBag.countryList = countryList;
            return View();
        }

        public ActionResult SearchAlreadytakenOff()
        {
            List<FlightDisplaySearch> listFlightdisplay = new List<FlightDisplaySearch>();
            List<Flight> result = new List<Flight>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                result = (List<Flight>)anonymeFacade.GetFlightsAlreadyTakenOff();
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
            if(result.Count > 0)
            {
                foreach (Flight fl in result)
                {
                    FlightDisplaySearch flDispSearch = new FlightDisplaySearch();
                    flDispSearch = FromFlightToFlightDysplaySearch(fl);
                    listFlightdisplay.Add(flDispSearch);
                }
            }
            ViewBag.listFlightdisplay = listFlightdisplay;
            return View();
        }

        public ActionResult SearchNotTakenOffYet()
        {
            List<FlightDisplaySearch> listFlightdisplay = new List<FlightDisplaySearch>();
            List<Flight> result = new List<Flight>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                result = (List<Flight>)anonymeFacade.GetFlightsNotTakenOffYet();
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
            if (result.Count > 0)
            {
                foreach (Flight fl in result)
                {
                    FlightDisplaySearch flDispSearch = new FlightDisplaySearch();
                    flDispSearch = FromFlightToFlightDysplaySearch(fl);
                    listFlightdisplay.Add(flDispSearch);
                }
            }
            ViewBag.listFlightdisplay = listFlightdisplay;
            return View();
        }

        public ActionResult AllFlights()
        {
            List<FlightDisplaySearch> listFlightdisplay = new List<FlightDisplaySearch>();
            List<Flight> result = new List<Flight>();
            try
            {
                IAnonymousUserFacade anonymeFacade = fs.GetFacade<IAnonymousUserFacade>();
                result = (List<Flight>)anonymeFacade.GetAllFlights();
            }
            catch (Exception e)
            {
                //return InternalServerError(e);
            }
            if (result.Count > 0)
            {
                foreach (Flight fl in result)
                {
                    FlightDisplaySearch flDispSearch = new FlightDisplaySearch();
                    flDispSearch = FromFlightToFlightDysplaySearch(fl);
                    listFlightdisplay.Add(flDispSearch);
                }
            }
            ViewBag.listFlightdisplay = listFlightdisplay;
            return View();
        }

    }
}