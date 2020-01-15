using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;

namespace HomeWork30_SQLite
{
    class CountryDAO : ICountryDAO
    {
       public Dictionary<Country, CapitalCity> mapCountryCapitalCity = new Dictionary<Country, CapitalCity>();
        public Dictionary<int, Country> mapIdCountry = new Dictionary<int, Country>();
        public Dictionary<string, Country> mapNameCountry = new Dictionary<string, Country>();
        public List<string> listCountryName = new List<string>();
        public void CreateMap()
        {
            using (SQLiteConnection con = new SQLiteConnection("Data source = C:\\Users\\Bramnik\\MashaDBLite3.db; Version = 3;"))
            {
                con.Open();
                using (SQLiteCommand com = new SQLiteCommand("SELECT * FROM Country JOIN CapitalCity ON Country.CapitalCity_id = CapitalCity.Id", con))
                {
                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Country country = new Country
                            {
                                Id = reader.GetInt32(0),
                                Name = (string)reader["NameC"],
                                Size_Km = reader.GetInt32(3),
                                Bith_Year = reader.GetInt32(4),
                                CapitalCity_id = reader.GetInt32(5),
                            };
                            mapIdCountry.Add(country.Id, country);
                            mapNameCountry.Add(country.Name, country);
                            listCountryName.Add(country.Name);
                            CapitalCity capCity = new CapitalCity
                            {
                                Id = reader.GetInt32(5),
                                Name = (string)reader["Name"],
                                NumCitizens = reader.GetInt32(7),
                                Country_id = reader.GetInt32(8),

                            };
                            mapCountryCapitalCity.Add(country, capCity);
                        }
                    }
                }
          

     
                con.Close();
                
            }


        }
        public object GetCountryAndItsCapitalCityName(int MyId)
        {
            
            Country myC = mapIdCountry[MyId];
            CapitalCity myCapCity = mapCountryCapitalCity[myC];
            var result = new { myC, myCapCity.Name };
            return result;
        }
        public object GetCountyAndItsCapitalCityDDetails(int MyId)
        {
            Country myC = mapIdCountry[MyId];
            CapitalCity myCapCity = mapCountryCapitalCity[myC];
            var result = new { myC, myCapCity };
            return result;
        }
        public object GetCountyAndItsCapitalCityName(string countryName)
        {
            Country mc = mapNameCountry[countryName];
            CapitalCity myCapCity = mapCountryCapitalCity[mc];
            var result = new { mc, myCapCity.Name };
            return result;

        }
        public object GetCountyAndItsCapitalCityDDetails(string countryName)
        {
            Country mc = mapNameCountry[countryName];
            CapitalCity myCapCity = mapCountryCapitalCity[mc];
            var result = new { mc, myCapCity };
            return result;
        }
        public Dictionary<Country,string> LiteraCountryName(char x)
        {
            Dictionary<Country, string> dictResult = new Dictionary<Country, string>();
            foreach(string countryName in listCountryName)
            {
                if(countryName[0] == x)
                {
                    Country mc = mapNameCountry[countryName];
                    CapitalCity myCapCity = mapCountryCapitalCity[mc];
                    dictResult.Add(mc, myCapCity.Name);                    
                }              
            }
            return dictResult;
        }
    }
}
