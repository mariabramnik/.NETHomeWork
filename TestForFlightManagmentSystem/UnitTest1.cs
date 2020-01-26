using System;
using FlightManagementSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightManagementSystem.Modules.Login;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.FlyingCenterSystem;

namespace TestForFlightManagmentSystem
{
    [TestClass]
    public class UnitTest1
    {
        // Successfull authorization.This User is AirlaineCompany. 
        [TestMethod]
        public void TryLogin_TRUE_Returned()
        {
            string password = "aaaaaa1";
            string userName = "ElAlAdmin";

            LoginService ls = new LoginService();
            bool actual = ls.TryLogin(password, userName);
            Assert.IsTrue(actual);
        }
        // Successfull authorization.This User is Customer.
        [TestMethod]         
        public void TryLogin_TRUE_Returned2()
        {
            string password = "Inna34";
            string userName = "InnaK";

            LoginService ls = new LoginService();
            bool actual = ls.TryLogin(password, userName);
            Assert.IsTrue(actual);
        }
        // Not Successfull authorization.
        [TestMethod]
        public void TryLogin_FALSE_Returned()
        {
            string password = "Inna11";
            string userName = "Inna23";
            bool actual = true;
            try
            {
                LoginService ls = new LoginService();
                ls.TryLogin(password, userName);
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                {
                    actual = false;
                }
            }
            Assert.IsFalse(actual);
        }
        //User is founded.This is Customer,but the password is incorrect
        [TestMethod]
        public void TryLogin_FALSE_Returned2()
        {
            string password = "Inna";
            string userName = "InnaK";
            bool actual = true;
            try
            {
                LoginService ls = new LoginService();
                ls.TryLogin(password, userName);
            }
            catch (Exception ex)
            {
                if (ex is WrongPasswordException)
                {
                    actual = false;
                }
            }
            Assert.IsFalse(actual);
        }
        //User is founded.This is AirLineCompany,but the password is incorrect
        [TestMethod]
        public void TryLogin_FALSE_Returned3()
        {
            string password = "Inna11";
            string userName = "ElAlAdmin";
            bool actual = true;
            try
            {
                LoginService ls = new LoginService();
                ls.TryLogin(password, userName);
            }
            catch (Exception ex)
            {
                if (ex is WrongPasswordException)
                {
                    actual = false;
                }
            }
            Assert.IsFalse(actual);
        }
        // :---------------------------------;
        [TestMethod]
        public void ADD_AIRLINECOMPANY()
        {
            LoginService ls = new LoginService();
            LoginToken<Administrator> ltAdmin = null;
            bool res = ls.TryAdminLogin("9999", "admin", out ltAdmin);
            if (res == true)
            {
                FlyingCenterSystem fs = FlyingCenterSystem.Instance;
                //ILoggedInAirLineFacade iAirlineCompanyFS = fs.GetFacade<ILoggedInAirLineFacade>();
                //iAirlineCompanyFS.GetAllFlights();
                ILoggedInAdministratorFacade iAdminFS = fs.GetFacade<ILoggedInAdministratorFacade>();
                AirLineCompany airLineComp = new AirLineCompany();
                airLineComp.airLineName = "BramnikAirLine";
                airLineComp.userName = "BramnikAdmin";
                airLineComp.password = "bramnik";
                airLineComp.countryCode = 1;

                iAdminFS.CreateNewairLine(ltAdmin, airLineComp);
            }
        }

    }
}
