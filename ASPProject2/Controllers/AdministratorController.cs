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
    [BasicAdminAuthentication]
    public class AdministratorController :  ApiController
    {
        // 1
        LoggedInAdministratorFacade adminFacade = new LoggedInAdministratorFacade();

        private LoginToken<Administrator> GetLoginToken()
        {
            // with authentication
            LoginToken<Administrator> token = (LoginToken<Administrator>)Request.Properties["token"];
            return token;

            // without authentication
            //return new LoginToken<Administrator>(); // fill with sample data 
        }
        [HttpPost]
        [Route("api/administrator/addairline")]
        public IHttpActionResult AddAirline([FromBody] AirLineCompany airline)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                airline.id = adminFacade.CreateNewairLine(token, airline);

            }
            catch (AirLineCompanyAlreadyExistException e)
            {
                
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return CreatedAtRoute("GetAirLineById", new {airline.id}, airline);
        }

        [HttpPut]
        [Route("api/administrator/updateairline")]
        public IHttpActionResult UpdateAirline([FromBody] AirLineCompany airline)
        {
            try
            {

                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.UpdateAirLineDetails(token, airline);

            }
            catch (AirLineCompanyNotExistException e)
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
        [Route("api/administrator/removeairline")]
        public IHttpActionResult RemoveAirline([FromBody] AirLineCompany airline)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.RemoveAirLine(token, airline);
            }
            catch (AirLineCompanyNotExistException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/administrator/addcustomer")]
        public IHttpActionResult AddCustomer([FromBody] Customer customer)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                customer.id = adminFacade.CreateNewCustomer(token, customer);
            }
            catch (CustomerAlreadyExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return CreatedAtRoute("GetCustomerById", new { customer.id }, customer);
        }

        [HttpPut]
        [Route("api/administrator/updatecustomer")]
        public IHttpActionResult UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.UpdateCustomerDetails(token,customer);
            }
            catch (CustomerNotExistException e)
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
        [Route("api/administrator/removecustomer")]
        public IHttpActionResult RemoveCustomer([FromBody] Customer customer)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.RemoveCustomer(token, customer);
            }
            catch (CustomerNotExistException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/administrator/addcountry")]
        public IHttpActionResult AddCountry([FromBody] Country country)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                country.id = adminFacade.CreateCountry(token, country);
                //country.id = adminFacade.CreateCountryByTemplate(token, country);
            }
            catch (CountryAlredyExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return CreatedAtRoute("GetCountryById", new { country.id }, country);
        }

        [HttpDelete]
        [Route("api/administrator/removecountry")]
        public IHttpActionResult RemoveCountry([FromBody] Country country)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.RemoveCountry(token, country);
               
            }
            catch (CountryNotExistException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("api/administrator/removecountrybytemplate")]
        public IHttpActionResult RemoveCountryByTemplate([FromBody] Country country)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.RemoveCountryByTemplate(token, country);

            }
            catch (CountryNotExistException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/administrator/updatecountry")]
        public IHttpActionResult UpdateCountry([FromBody] Country country)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.UpdateCountry(token, country);
            }
            catch (CustomerNotExistException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("api/administrator/updatecountrybytemplate")]
        public IHttpActionResult UpdateCountryByTemplate([FromBody] Country country)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.UpdateCountryByTemplate(token, country);
            }
            catch (CustomerNotExistException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("api/administrator/addcountrybytemplate")]
        public IHttpActionResult AddCountryByTemplate([FromBody] Country country)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                //country.id = adminFacade.CreateCountry(token, country);
                country.id = adminFacade.CreateCountryByTemplate(token, country);
            }
            catch (CountryAlredyExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return CreatedAtRoute("GetCountryById", new { country.id }, country);
        }

        [HttpPost]
        [Route("api/administrator/addflightstatus")]
        public IHttpActionResult AddFlightStatus([FromBody] FlightStatus flightstatus)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                flightstatus.id = adminFacade.CreateFlightStatus(token, flightstatus);
            }
            catch (FlightStatusAlreadyExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return CreatedAtRoute("GetCustomerById", new { flightstatus.id }, flightstatus);
        }

        [HttpGet]
        [Route("api/administrator/airlinebyid/{id}", Name = "GetAirLineById")]
        public IHttpActionResult GetAirLineById([FromUri]int id)
        {
            AirLineCompany comp = new AirLineCompany();
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                 comp = adminFacade.GetAirLineCompanyById(token, id);
            }
            catch (AirLineCompanyNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(comp);
        }
        [HttpGet]
        [Route("api/administrator/customerbyid/{id}", Name = "GetCustomerById")]
        public IHttpActionResult GetCustomerById([FromUri]int id)
        {
            Customer customer = new Customer();
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                customer = adminFacade.GetCustomerByid(token, id);
            }
            catch (AirLineCompanyNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(customer);
        }
        [HttpGet]
        [Route("api/administrator/flightstatusbyid/{id}", Name = "GetFlightStatusById")]
        public IHttpActionResult GetFlightStatusById([FromUri]int id)
        {
            FlightStatus flightstatus = new FlightStatus();
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                flightstatus = adminFacade.GetFlightStatusById(token, id);
            }
            catch (AirLineCompanyNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(flightstatus);
        }
        [HttpGet]
        [Route("api/administrator/countrybyid/{id}", Name = "GetCountryById")]
        public IHttpActionResult GetCountryById([FromUri]int id)
        {
            Country country = new Country();
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                country = adminFacade.GetCountry(token, id);
            }
            catch (AirLineCompanyNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(country);
        }
        [HttpGet]
        [Route("api/administrator/countrybyname/{name}")]
        public IHttpActionResult GetCountryByName([FromUri]string name)
        {
            Country country = new Country();
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                country = adminFacade.GetCountryByName(token, name);
            }
            catch (AirLineCompanyNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(country);
        }
        [HttpGet]
        [Route("api/administrator/customerbyusername/{username}")]
        public IHttpActionResult GetCustomerByUserName([FromUri]string username)
        {
            Customer customer = new Customer();
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                customer = adminFacade.GetCustomerByUserName(token, username);
            }
            catch (AirLineCompanyNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(customer);
        }
    }
}