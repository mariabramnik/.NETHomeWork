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
        [Route("api/anonyme/allflights")]
        public IHttpActionResult GetAllFlights()
        {
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetAllFlights();

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/allcountries")]
        public IHttpActionResult GetAllCountries()
        {
            List<Country> result = new List<Country>();
            try
            {
                //result = (List<Country>)anonymeFacade.GetAllCountries();
                result = (List<Country>)anonymeFacade.GetAllCountriesByTemplate();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/anonyme/allcompanies")]
        public IHttpActionResult GetAllAirLineCompanies()
        {
            List<AirLineCompany> result = new List<AirLineCompany>();
            try
            {
                result = (List<AirLineCompany>)anonymeFacade.GetAllAirLineCompanies();

            }

            catch (Exception e)
            {
                return InternalServerError(e);
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
                return InternalServerError(e);
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

        [HttpGet]
        [Route("api/anonyme/flightsbyorigincountry/{id}")]
        public IHttpActionResult GetFlightsByOriginCountry(int id)
        {
            List<Flight> result = new List<Flight>();
            try
            {
               result = (List<Flight>)anonymeFacade.GetFlightsByOriginCountry(id);
               if(result.Count == 0)
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
        [Route("api/anonyme/flightsbydestincountry/{id}")]
        public IHttpActionResult GetFlightsByDestinationCountry(int id)
        {
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByDesinationCountry(id);
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
        [Route("api/anonyme/flightsbydepartdate/{departuredate}")]
        public IHttpActionResult GetFlightsByDepartureDate(string departureStr = "")
        {
            DateTime departureDate = DateTime.Parse(departureStr);
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByDepartureDate(departureDate);
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
        [Route("api/anonyme/flightsbydepartdate12hours")]
        public IHttpActionResult GetFlightsByDepartureDate12Hours()
        {
            
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByDepartureTime12Hours();
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
        [Route("api/anonyme/flightsbylandingdate")]
        public IHttpActionResult GetFlightsByLandingDate(string landingStr = "")
        {
            DateTime landingDate = DateTime.Parse(landingStr);
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByLandingDate(landingDate);
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
        [Route("api/anonyme/flightsbylandingdate12Hours")]
        public IHttpActionResult GetFlightsByLandingDate12Hours()
        {
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetFlightsByLandingTime12Hours();
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