using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementSystem.Models;

namespace FlightManagementSystem.Modules
{
   public class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
   {
        public void CreateNewairLine(LoginToken<Administrator> token, AirLineCompany comp)
        {
            _airLineDAO.Add(comp);
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            _customerDAO.Add(customer);
        }

        public void RemoveAirLine(LoginToken<Administrator> token, AirLineCompany comp)
        {
            _airLineDAO.Remove(comp);
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            _customerDAO.Remove(customer);
        }

        public void UpdateAirLineDetails(LoginToken<Administrator> token, AirLineCompany comp)
        {
            _airLineDAO.Update(comp);
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            _customerDAO.Update(customer);
        }
    }
}
