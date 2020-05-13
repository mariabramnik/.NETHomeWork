using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject2.Models
{
    public class FlightDisplay
    {
        public int id { get; set; }
        public string AirlineName { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public string DepartureTime { get; set; }
        public string LandingTime { get; set; }
        public string Status { get; set; }

        public FlightDisplay(int id, string airlineName, string originCity, string destinationCity, string departureTime, string landingTime, string status)
        {
            this.id = id;
            AirlineName = airlineName;
            OriginCity = originCity;
            DestinationCity = destinationCity;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            Status = status;
        }
        public FlightDisplay() { }


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
    }
    
}