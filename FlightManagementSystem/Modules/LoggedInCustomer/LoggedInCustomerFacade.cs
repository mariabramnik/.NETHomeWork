
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementSystem.Models;

namespace FlightManagementSystem.Modules
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            _ticketDAO.Remove(ticket);
        }

        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            int id = token.User.id;
            return _ticketDAO.GetFlightsByCustomer(id);
            
        }

        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            Ticket ticket = new Ticket(token.User.id, flight.id);
            _ticketDAO.Add(ticket);
            Flight fl = _flightDAO.GetFlightById(flight.id);
            fl.remainingTickets = fl.remainingTickets - 1;
            _flightDAO.Update(fl);
            return ticket;
        }
    }
}
