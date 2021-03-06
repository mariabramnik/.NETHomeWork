﻿using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Modules.Login
{
    public class LoginService : ILoginService
    {
        AirLineDAOMSSQL _airLineDAO;
        CustomerDAOMSSQL _customerDAO;
        public bool TryAdminLogin(string password, string userName, out LoginToken<Administrator> loginToken)
        {
            bool res = false;
            loginToken = null;
            if (password == 9999.ToString() && userName == "admin")
            {
                loginToken = new LoginToken<Administrator>();
                loginToken.User = new Administrator();
                res = true;
            }
            return res;
        }

        public bool TryAirLineLogin(string password, string userName, out LoginToken<AirLineCompany> loginToken)
        {
            bool res = false;
            loginToken = null;
            AirLineCompany comp = null;
            _airLineDAO = new AirLineDAOMSSQL();
            _airLineDAO.SQLConnectionOpen();
            Dictionary<string,AirLineCompany> CompanyByUserNameDict =  _airLineDAO.userNameCompanyDict;
            if (CompanyByUserNameDict.ContainsKey(userName))
            {
                comp = CompanyByUserNameDict[userName];
                if (comp.password != password)
                {
                    throw new WrongPasswordException("entered password is not correct");
                }
                else
                {
                    loginToken = new LoginToken<AirLineCompany>();
                    loginToken.User = comp;
                    res = true;
                }
            }
            _airLineDAO.SQLConnectionClose();
            return res;

        }

        public bool TryCustomerLogin(string password, string userName)
        {
            bool res = false;
            _customerDAO = new CustomerDAOMSSQL();
            _customerDAO.SQLConnectionOpen();
            Customer cust = _customerDAO.GetCustomerByUserName(userName);
            if(!(cust is null))
            {
                if(cust.password != password)
                {
                    throw new WrongPasswordException("entered password is not correct");
                }
                else
                {
                    res = true;
                }
            }
            _customerDAO.SQLConnectionClose();
            return res;
        }

        public bool TryLogin(string password, string userName)
        {
            bool res = false;
            LoginToken<Administrator> ltAdmin = null;
            res = TryAdminLogin(password, userName, out ltAdmin);
            if(res == false)
            {
                LoginToken<AirLineCompany> ltAirLineCompany = null;
                res = TryAirLineLogin(password, userName, out ltAirLineCompany);
                if (res == false)
                {

                    res = TryCustomerLogin(password, userName);
                    if (res == false)
                    {
                        throw new UserNotFoundException("Not Found");
                    }
                }               
            }

            return res;
        }

    }
}
