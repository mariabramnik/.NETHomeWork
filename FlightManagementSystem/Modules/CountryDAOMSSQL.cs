﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementSystem.Models;

namespace FlightManagementSystem.Modules
{
    class CountryDAOMSSQL : ICountryDAO
    {
        public Dictionary<int, Country> idCountriesDict = new Dictionary<int, Country>();
        public Dictionary<string, Country> nameCountriesDict = new Dictionary<string, Country>();
        static SqlConnection con = new SqlConnection(@"Data Source=BRAMNIK-PC;Initial Catalog=FlightManagementSystem;Integrated Security=True");
        public void SQLConnectionOpen()
        {
            con.Open();
            DictionaryFilling();
        }

        private void DictionaryFilling()
        {
            string str = "SELECT * FROM Countries";
            SqlCommand cmd = new SqlCommand(str, con);
            Country country;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        country = new Country
                        {
                            id = (int)reader["ID"],
                            countryName = (string)reader["COUNTRY_NAME"],

                        };
                        idCountriesDict.Add(country.id, country);
                        nameCountriesDict.Add(country.countryName, country);
                    }
                }
            }
        }

        public void SQLConnectionClose()
        {
            con.Close();
        }
        public void Add(Country ob)
        {
            int id = ob.id;
            string countryName = ob.countryName;
            if (idCountriesDict.ContainsKey(id))
            {
                throw new CountryAlredyExistException("Such Country already exist");
            }
            string str = string.Format($"INSERT INTO Countries VALUES({id},'{countryName}')");            
            
            using (SqlCommand cmd = new SqlCommand(str, con))              
            {
                cmd.ExecuteNonQuery();
            }
            idCountriesDict.Add(id, ob);
            nameCountriesDict.Add(countryName, ob);
            
        }

        public Country Get(int id)
        {
            /*
           
            Country country = null;
            string str = $"SELECT * FROM Countries WHERE ID = {id}";
            SqlCommand cmd = new SqlCommand(str, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            { 
                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        country = new Country
                        {
                            id = (int)reader["ID"],
                            countryName = (string)reader["COUNTRY_NAME"],
                        };
                    }

                }          
            }
            if(country is null)
            {
                throw new CountryNotExistException("This Country not found");
            }
            
            return country;
            */
            Country country = null;
            if (idCountriesDict.ContainsKey(id))
            {
                country = idCountriesDict[id];
                
            }

            return country;
        }

        public Country GetByName(string name)
        {
            /*
            
            Country country = null;
            string str = $"SELECT * FROM Countries WHERE COUNTRY_NAME = {name}";
            SqlCommand cmd = new SqlCommand(str, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                
                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        country = new Country
                        {
                            id = (int)reader["ID"],
                            countryName = (string)reader["COUNTRY_NAME"],
                        };
                    }                  
                }       
            }
            if (country is null)
            {
                throw new CountryNotExistException("This Country not found");
            }
           
            return country;
            */
            Country country = null;
            if (nameCountriesDict.ContainsKey(name))
            {
                country = nameCountriesDict[name];

            }
            return country;
        }

        public List<Country> GetAll()
        {
            /*
           
            List<Country> countriesList = new List<Country>();
            string str = $"SELECT * FROM Countries";
            SqlCommand cmd = new SqlCommand(str, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                   while( reader.Read())
                    {
                        Country country = new Country
                        {
                            id = (int)reader["ID"],
                            countryName = (string)reader["COUNTRY_NAME"],
                        };
                    countriesList.Add(country);
                    }
  
            }
          
            return countriesList;
            */
            List<Country> countries = new List<Country>();
            foreach (Country country in idCountriesDict.Values)
            {              
                countries.Add(country);
            }
            return countries;
        }
      
        public void Remove(Country ob)
        {
            int id = ob.id;
            string countryName = ob.countryName; 
            if (!idCountriesDict.ContainsKey(id))
            {
                throw new CountryNotExistException("Such Country not exist");
            }
            string str = string.Format($"DELETE FROM Countries WHERE ID = {id})");           
            
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                cmd.ExecuteNonQuery();
            }
            idCountriesDict.Remove(id);
            nameCountriesDict.Remove(countryName);
            
        }

        public void Update(Country ob)
        {
            int id = ob.id;
            if (!idCountriesDict.ContainsKey(id))
            {
                throw new CountryNotExistException("Such Country not exist");
            }
            Country oldCountry = Get(id);
            string oldCountryName = oldCountry.countryName;
            string countryName = ob.countryName;
            string str = string.Format($"UPDATE Countries SET COUNTRY_NAME = {countryName} WHERE ID = {id}");
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                cmd.ExecuteNonQuery();
            }
            idCountriesDict.Remove(id);
            nameCountriesDict.Remove(oldCountryName);
            idCountriesDict.Add(id,ob);
            nameCountriesDict.Add(countryName, ob);
            
        }
    }
}
