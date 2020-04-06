using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ASPProject2.Controllers
{
    [BasicAuthentication]
    public class CustomerController : ApiController
    {
        LoggedInCustomerFacade customerFacade = new LoggedInCustomerFacade();

        private LoginToken<Customer> GetLoginToken()
        {
            // with authentication
            LoginToken<Customer> token = (LoginToken<Customer>)Request.Properties["token"];
            return token;

            // without authentication
            //return new LoginToken<Administrator>(); // fill with sample data 
        }

        [HttpGet]
        [Route("api/customer/myflights")]
        public IHttpActionResult GetMyFlights()
        {
            List<Flight> result = new List<Flight>();
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Customer> token = GetLoginToken();
                result = (List<Flight>)customerFacade.GetAllMyFlights(token);
            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/customer/purchaseticket")]
        public IHttpActionResult PurchaseTicket([FromBody] Flight flight)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Customer> token = GetLoginToken();
                customerFacade.PurchaseTicket(token,flight);
            }
            catch (TicketAlreadyExistException e)
            {
                // return error of 400 family bad request? 
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/customer/removeticket")]
        public IHttpActionResult RemoveTicket([FromBody] Flight flight)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Customer> token = GetLoginToken();
                customerFacade.PurchaseTicket(token, flight);
            }
            catch (TicketNotExistException e)
            {
                // return error of 400 family bad request? 
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok();
        }

    }
}