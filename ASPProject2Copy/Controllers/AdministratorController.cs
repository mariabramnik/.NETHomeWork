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
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.CreateNewairLine(token, airline);


            }
            catch (AirLineCompanyAlreadyExistException e)
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
        [Route("api/administrator/updateairline")]
        public IHttpActionResult UpdateAirline([FromBody] AirLineCompany airline)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.UpdateAirLineDetails(token, airline);


            }
            catch (AirLineCompanyNotExistException e)
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
        [Route("api/administrator/removeairline")]
        public IHttpActionResult RemoveAirline([FromBody] AirLineCompany airline)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.RemoveAirLine(token, airline);

            }
            catch (AirLineCompanyNotExistException e)
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
        [Route("api/administrator/addcustomer")]
        public IHttpActionResult AddCustomer([FromBody] Customer customer)
        {
            try
            {
                LoginToken<Administrator> token = GetLoginToken();
                adminFacade.CreateNewCustomer(token, customer);
            }
            catch (CustomerAlreadyExistException e)
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
        [Route("api/administrator/updatecustomer")]
        public IHttpActionResult UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();

                adminFacade.UpdateCustomerDetails(token,customer);


            }
            catch (CustomerNotExistException e)
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
        [Route("api/administrator/removecustomer")]
        public IHttpActionResult RemoveCustomer([FromBody] Customer customer)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();

                adminFacade.RemoveCustomer(token, customer);


            }
            catch (CustomerNotExistException e)
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
        [Route("api/administrator/addcountry")]
        public IHttpActionResult AddCountry([FromBody] Country country)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();

                adminFacade.CreateCountry(token, country);


            }
            catch (CountryAlredyExistException e)
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
        [Route("api/administrator/addflightstatus")]
        public IHttpActionResult AddFlightStatus([FromBody] FlightStatus flightstatus)
        {
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();

                adminFacade.CreateFlightStatus(token, flightstatus);


            }
            catch (FlightStatusAlreadyExistException e)
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

        [HttpGet]
        [Route("api/administrator/airlinebyid/{id}")]
        public IHttpActionResult GetAirLineById([FromUri]int id)
        {
            AirLineCompany comp = new AirLineCompany();
            try
            {
                // where do i get the facade?
                // 2
                //AdminFacade facade = (AdminFacade)Request.Properties["facade"];
                // where do i get the token?
                LoginToken<Administrator> token = GetLoginToken();

                 comp = adminFacade.GetAirLineCompanyById(token, id);


            }
            catch (AirLineCompanyNotExistException e)
            {
                // return error of 400 family bad request? 
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                // error 500 -- sql exception
            }
            return Ok(comp);
        }
    }
}