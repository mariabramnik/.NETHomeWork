using ASPProject2.Models;
using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject2.Controllers
{
    public class MyHelper
    {
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
            City[] arrCities = listCities.ToArray();
            fl.OriginCity = arrCities[0].city;
            Country destinationCountry = anonymeFacade.GetCountryById(flight.destinationCountryCode);
            string destinationCountryName = destinationCountry.countryName;
            List<City> listCities2 = (List<City>)anonymeFacade.GetAllByCountry(destinationCountryName);
            City[] arrCities2 = listCities2.ToArray();
            fl.DestinationCity = arrCities2[0].city;
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
    }
}