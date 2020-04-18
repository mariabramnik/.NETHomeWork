using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ASPProject2.Controllers
{
    [BasicAirlineAuthentication]
    public class AirLineController : ApiController
    {
        LoggedInAirlineFacade airlineFacade = new LoggedInAirlineFacade();

        private LoginToken<AirLineCompany> GetLoginToken()
        {
            // with authentication
            LoginToken<AirLineCompany> token = (LoginToken<AirLineCompany>)Request.Properties["token"];
            return token;

        }
   

    [HttpPost]
    [Route("api/airline/addflight")]
    public IHttpActionResult AddFlight([FromBody] Flight flight)
    {
        try
        {
            LoginToken<AirLineCompany> token = GetLoginToken();
            flight.id = airlineFacade.CreateFlight(token,flight);

        }
        catch (FlightAlreadyExistException e)
        {
            return BadRequest(e.Message);
             
        }
        catch (Exception e)
        {

            return InternalServerError(e);
        }
        return CreatedAtRoute("GetFlightById", new { flight.id }, flight);
    }

    [HttpPut]
    [Route("api/airline/updateflight")]
    public IHttpActionResult UpdateFlight([FromBody] Flight flight)
    {
        try
        {
            LoginToken<AirLineCompany> token = GetLoginToken();
            airlineFacade.UpdateFlight(token,flight);
        }
        catch (FlightNotExistException e)
        {

            return NotFound();
        }
        catch (Exception e)
        {
            return InternalServerError(e);
        }

            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
    }
    [HttpDelete]
    [Route("api/airline/removeflight")]
    public IHttpActionResult RemoveFlight([FromBody] Flight flight)
    {
        try
        {
            LoginToken<AirLineCompany> token = GetLoginToken();
            airlineFacade.CancelFlight(token, flight);
        }
        catch (FlightNotExistException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return InternalServerError(e);
        }
        return Ok();
    }
        [HttpGet]
        [Route("api/airline/flightbyid/{id}", Name = "GetFlightById")]
        public IHttpActionResult GetFlightById([FromUri]int id)
        {
            Flight flight = new Flight();
            try
            {
                LoginToken<AirLineCompany> token = GetLoginToken();
                flight = airlineFacade.GetFlightByID(token, id);
            }
            catch (FlightNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(flight);
        }
        /*
                [HttpPost]
                [Route("api/airline/changepassword")]
                public IHttpActionResult ChangePassword(string oldPassword,string newPassword)
                {
                    try
                    {
                        LoginToken<AirLineCompany> token = GetLoginToken();
                        airlineFacade.ChangeMyPassword(token, oldPassword, newPassword);
                    }  
                    catch (Exception e)
                    {
                        return InternalServerError(e);
                    }
                    return Ok();
                }
        */
        [HttpPost]
        [Route("api/airline/changepassword")]
        public IHttpActionResult ChangePassword([FromBody]ChangePassword changePass)
        {
            try
            {
                LoginToken<AirLineCompany> token = GetLoginToken();
                airlineFacade.ChangeMyPassword(token, changePass.oldPassword, changePass.newPassword);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
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
                LoginToken<AirLineCompany> token = GetLoginToken();
                result = (List<Flight>)airlineFacade.GetAllAirLineCompaniesFlights(token);
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

        [HttpGet]
        [Route("api/airline/tickets")]
        public IHttpActionResult GetAllTickets()
        {
            List<Ticket> result = new List<Ticket>();
            try
            {
                LoginToken<AirLineCompany> token = GetLoginToken();
                result = (List<Ticket>)airlineFacade.GetAllTicketsByAirLine(token);
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
    }
}