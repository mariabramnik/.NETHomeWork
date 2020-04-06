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
    public class AirLineController : ApiController
    {
        LoggedInAirlineFacade airlineFacade = new LoggedInAirlineFacade();

        private LoginToken<AirLineCompany> GetLoginToken()
        {
            // with authentication
            LoginToken<AirLineCompany> token = (LoginToken<AirLineCompany>)Request.Properties["token"];
            return token;

            // without authentication
            //return new LoginToken<Administrator>(); // fill with sample data 
        }
   

    [HttpPost]
    [Route("api/airline/addflight")]
    public IHttpActionResult AddFlight([FromBody] Flight flight)
    {
        try
        {
            // where do i get the facade?
            // 2
            //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
            // where do i get the token?
            LoginToken<AirLineCompany> token = GetLoginToken();
            airlineFacade.CreateFlight(token,flight);


        }
        catch (FlightAlreadyExistException e)
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
    [Route("api/airline/updateflight")]
    public IHttpActionResult UpdateAirline([FromBody] Flight flight)
    {
        try
        {
            // where do i get the facade?
            // 2
            //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
            // where do i get the token?
            LoginToken<AirLineCompany> token = GetLoginToken();
            airlineFacade.UpdateFlight(token,flight);


        }
        catch (FlightNotExistException e)
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
    [Route("api/airline/removeflight")]
    public IHttpActionResult RemoveAirline([FromBody] Flight flight)
    {
        try
        {
            // where do i get the facade?
            // 2
            //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
            // where do i get the token?
            LoginToken<AirLineCompany> token = GetLoginToken();

            airlineFacade.CancelFlight(token, flight);

        }
        catch (FlightNotExistException e)
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
        [Route("api/airline/changepassword")]
        public IHttpActionResult ChangePassword([FromBody] string oldPassword,string newPassword)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<AirLineCompany> token = GetLoginToken();
                airlineFacade.ChangeMyPassword(token, oldPassword, newPassword);

            }
    
            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok();
        }
        [HttpGet]
        [Route("api/airline/flights")]
        public IHttpActionResult GetAllFlights()
        {
            List<Flight> result = new List<Flight>();
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<AirLineCompany> token = GetLoginToken();
                result = (List<Flight>)airlineFacade.GetAllAirLineCompaniesFlights(token);

            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("api/airline/tickets")]
        public IHttpActionResult GetAllTickets()
        {
            List<Ticket> result = new List<Ticket>();
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<AirLineCompany> token = GetLoginToken();
                result = (List<Ticket>)airlineFacade.GetAllTicketsByAirLine(token);

            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }
    }
}