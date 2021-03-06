﻿using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Modules
{
    public interface IFlightDAO : IBasic<Flight>
    {
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        List<Flight> GetFlightsByCustomer(Customer customer);
        List<Flight> GetFlightsByDepartureTime(DateTime datetime);
        List<Flight> GetFlightsByDestinationCountry(Country country);
        List<Flight> GetFlightsByLandingTime(DateTime datetime);
        List<Flight> GetFlightsByOriginCountryCode(Country country);

    }
}
