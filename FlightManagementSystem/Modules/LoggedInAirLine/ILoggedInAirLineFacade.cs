﻿using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Modules
{
   public interface ILoggedInAirLineFacade
    {
        List<Ticket> GetAllTickets(LoginToken<AirLineCompany> token);
        IList<Flight> GetAllFlights(LoginToken<AirLineCompany> token);
        void CancelFlight(LoginToken<AirLineCompany> token, Flight flight);
        void CreateFlight(LoginToken<AirLineCompany>token, Flight flight);
        void UpdateFlight(LoginToken<AirLineCompany> token, Flight flight);
        void ChangeMyPassword(LoginToken<AirLineCompany> token, string oldPassword, string newPassword);
        void ModifyAirLineDetails(LoginToken<AirLineCompany> token, AirLineCompany airline);


    }
}
