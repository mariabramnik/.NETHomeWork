using FlightManagementSystem.Models;
using FlightManagementSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using StackExchange.Redis;
using System.Text.Json;
using System.Net;
using System.Diagnostics;

namespace ASPProject2
{
    public class AnonymeController : ApiController
    {
        
        AnonymousUserFacade anonymeFacade = new AnonymousUserFacade();
        private ConnectionMultiplexer redis;
        private static IDatabase dbRedis;

        public AnonymeController()
        {
            redis = ConnectionMultiplexer.Connect("localhost,allowAdmin=true");
            var endpoints = redis.GetEndPoints();
            var server = redis.GetServer(endpoints[0]);
            server.FlushAllDatabases();

            dbRedis = redis.GetDatabase();
            List<Flight>result = (List<Flight>)anonymeFacade.GetAllFlights();
            foreach (Flight flight in result)
            {
                string redisvalueJson = JsonSerializer.Serialize<Flight>(flight);
                dbRedis.StringSet(flight.id.ToString(),redisvalueJson);
            }
        }


        [HttpGet]
        [Route("api/anonyme/allflights")]
        public IHttpActionResult GetAllFlights()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Flight> result = new List<Flight>();
            try
            {
                result = (List<Flight>)anonymeFacade.GetAllFlights();

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            stopwatch.Stop();
            int millisek = (int)stopwatch.ElapsedMilliseconds;
            return Ok(result);
        }
        [HttpGet]
        [Route("api/anonyme/allflightsredis")]
        public IHttpActionResult GetAllFlightsRedis()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Flight> result = new List<Flight>();
            try
            {
                
                EndPoint endPoint = redis.GetEndPoints().First();
                RedisKey[] keys = redis.GetServer(endPoint).Keys(pattern: "*").ToArray();
                foreach (RedisKey key in keys)
                {
                    string value = dbRedis.StringGet(key);
                    Flight restoredFlight = JsonSerializer.Deserialize<Flight>(value);
                    result.Add(restoredFlight);
                }
  
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            stopwatch.Stop();
            int millisek = (int)stopwatch.ElapsedMilliseconds;
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
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
            stopwatch.Stop();
            int millisek = (int)stopwatch.ElapsedMilliseconds;
            return Ok(flight);
        }

        [HttpGet]
        [Route("api/anonyme/flightredis/{id}")]
        public IHttpActionResult GetFlightByIdRedis(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Flight flight = new Flight();
            try
            {
                string res = dbRedis.StringGet(id.ToString());
                flight = JsonSerializer.Deserialize<Flight>(res);
            }
            catch (FlightNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            stopwatch.Stop();
            int millisek = (int)stopwatch.ElapsedMilliseconds;
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