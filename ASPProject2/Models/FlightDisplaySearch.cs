using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject2.Models
{
    public class FlightDisplaySearch
    {
        public int id { get; set; }
        public string AirlineName { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public string DepartureTime { get; set; }
        public string LandingTime { get; set; }
        public string Status { get; set; }

        public FlightDisplaySearch(int id, string airlineName, string originCity, string destinationCity, string departureTime, string landingTime, string status)
        {
            this.id = id;
            AirlineName = airlineName;
            OriginCity = originCity;
            DestinationCity = destinationCity;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            Status = status;
        }
        public FlightDisplaySearch() { }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
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
    }
}