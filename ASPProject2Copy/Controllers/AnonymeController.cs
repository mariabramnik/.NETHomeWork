using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ASPProject2
{
    public class AnonymeController : ApiController
    {
        AnonymousUserFacade anonymeFacade = new AnonymousUserFacade();

        [HttpGet]
        [Route("api/anonyme/tickets")]
        public IHttpActionResult GetAllFlights()
        {
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetAllFlights();

            }
            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/companies")]
        public IHttpActionResult GetAllAirLineCompanies()
        {
            List<AirLineCompany> result = new List<AirLineCompany>();
            try
            {
                result = (List<AirLineCompany>)anonymeFacade.GetAllAirLineCompanies();

            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/flightsvacancy")]
        public IHttpActionResult GetFlightsVacancy()
        {
            Dictionary<Flight,int> result = new Dictionary<Flight,int>();
            try
            {
                result = anonymeFacade.GetAllFlightsVacancy();

            }
            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/flight/{id}")]
        public IHttpActionResult GetFlightById(int id)
        {
            Flight flight =  new Flight();
            try
            {
               flight =  anonymeFacade.GetFlightById(id);
            }
            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(flight);
        }

        [HttpGet]
        [Route("api/anonyme/flights/{id}")]
        public IHttpActionResult GetFlightsByOriginCountry(int id)
        {
            List<Flight> result = new List<Flight>();
            try
            {
               result = (List<Flight>)anonymeFacade.GetFlightsByOriginCountry(id);

            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/flights/{id}")]
        public IHttpActionResult GetFlightsByDestinationCountry(int id)
        {
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByDesinationCountry(id);

            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/flights/{departuredate}")]
        public IHttpActionResult GetFlightsByDepartureDate(DateTime departureDate)
        {
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByDepartureDate(departureDate);

            }

            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/flights/{landingdate}")]
        public IHttpActionResult GetFlightsByLandingDate(DateTime landingDate)
        {
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByLandingDate(landingDate);

            }
            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(result);
        }
    }
}