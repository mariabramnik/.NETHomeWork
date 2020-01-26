using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Modules
{
    public interface ILoggedInAdministratorFacade 
    {
        void CreateNewairLine(LoginToken<Administrator>token,AirLineCompany comp);
        void CreateNewCustomer(LoginToken<Administrator> token, Customer customer);
        void RemoveAirLine(LoginToken<Administrator> token, AirLineCompany comp);
        void RemoveCustomer(LoginToken<Administrator> token, Customer customer);
        void UpdateAirLineDetails(LoginToken<Administrator> token, AirLineCompany comp);
        void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer);
    }
}
