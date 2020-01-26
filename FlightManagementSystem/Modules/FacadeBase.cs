using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Modules
{
    public abstract class FacadeBase
    {
        protected IAirLineDAO _airLineDAO;
        private AirLineDAOMSSQL __airLineDAO;
        protected ICountryDAO _countryDAO;
        protected ICustomerDAO _customerDAO;
        protected IFlightDAO _flightDAO;
        protected ITicketDAO _ticketDAO;
        public FacadeBase()
        {
            __airLineDAO = new AirLineDAOMSSQL();
            __airLineDAO.SQLConnectionOpen();
            _airLineDAO = __airLineDAO;

            _countryDAO = new CountryDAOMSSQL();
            _customerDAO = new CustomerDAOMSSQL();
            _flightDAO = new FlightDAOMSSQL();
            _ticketDAO = new TicketDAOMSSQL();

        }

        ~FacadeBase()
        {
            __airLineDAO.SQLConnectionClose();
        }
    }
}
