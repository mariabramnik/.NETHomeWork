﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementSystem.Models;

namespace FlightManagementSystem.Modules
{
    public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirLineFacade
    {
        public void CancelFlight(LoginToken<AirLineCompany> token, Flight flight)
        {
            _flightDAO.Remove(flight);
            List<Ticket>listTicket  = _ticketDAO.GetTicketsByFlight(flight.id);
            foreach(Ticket t in listTicket)
            {
                _ticketDAO.Remove(t);
            }
        }

        public void ChangeMyPassword(LoginToken<AirLineCompany> token, string oldPassword, string newPassword)
        {
           AirLineCompany comp = _airLineDAO.Get(token.User.id);           
            _airLineDAO.Update(comp);
        }

        public void CreateFlight(LoginToken<AirLineCompany> token, Flight flight)
        {
            _flightDAO.Add(flight);
        }

        public IList<Flight> GetAllFlights(LoginToken<AirLineCompany> token)
       {
            return _flightDAO.GetAll();
       }

        public List<Ticket> GetAllTickets(LoginToken<AirLineCompany> token)
        {
           return  _ticketDAO.GetAll();
        }

        public void ModifyAirLineDetails(LoginToken<AirLineCompany> token, AirLineCompany airline)
        {
            _airLineDAO.Update(airline);

        }

        public void UpdateFlight(LoginToken<AirLineCompany> token, Flight flight)
        {
            _flightDAO.Update(flight);
        }
    }
}
