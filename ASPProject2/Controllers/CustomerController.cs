using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ASPProject2.Controllers
{
    [BasicCustomerAuthentication]
    public class CustomerController : ApiController
    {
        LoggedInCustomerFacade customerFacade = new LoggedInCustomerFacade();

        private LoginToken<Customer> GetLoginToken()
        {
            // with authentication
            LoginToken<Customer> token = (LoginToken<Customer>)Request.Properties["token"];
            return token;
        }

        [HttpGet]
        [Route("api/customer/myflights")]
        public IHttpActionResult GetMyFlights()
        {
            List<Flight> result = new List<Flight>();
            try
            {
                LoginToken<Customer> token = GetLoginToken();
                result = (List<Flight>)customerFacade.GetAllMyFlights(token);
                if (result.Count == 0)
                {
                    return NotFound();
                }
            }

            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/customer/purchaseticket")]
        public IHttpActionResult PurchaseTicket([FromBody] Flight flight)
        {
            Ticket ticket = new Ticket();
            try
            {
                LoginToken<Customer> token = GetLoginToken();
                ticket = customerFacade.PurchaseTicket(token,flight);
            }
            catch (TicketAlreadyExistException e)
            {

                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("api/customer/removeticket")]
        public IHttpActionResult RemoveTicket([FromBody] Ticket ticket)
        {
            try
            {
                LoginToken<Customer> token = GetLoginToken();
                customerFacade.RemoveTicket(token, ticket);
            }
            catch (TicketNotExistException e)
            {
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

    }
}