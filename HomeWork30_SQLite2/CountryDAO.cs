using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace HomeWork30_SQLite2
{
    class CountryDAO : ICountryDAO
    {
        static SQLiteConnection con;
        public void SqlConnectionOpen()
        {
            con = new SQLiteConnection("Data source = C:\\Users\\Bramnik\\MashaDBLite3.db; Version = 3;");
            con.Open();
        }
        public void SqlConnectionClose()
        {
            con.Close();
        }
        public object GetCountryAndItsCapitalCityName(int Id)
        {
            
            using (SQLiteCommand com = new SQLiteCommand($"SELECT c.Id,c.NameC,c.Size_Km,c.Bith_Year,cc.Id,cc.Name FROM Country c JOIN CapitalCity cc ON c.CapitalCity_id = cc.Id WHERE c.Id = {Id}", con))
            {
                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Country country = new Country
                        {
                            Id = reader.GetInt32(0),
                            Name = (string)reader["NameC"],
                            Size_Km = reader.GetInt32(2),
                            Bith_Year = reader.GetInt32(3),
                            CapitalCity_id = reader.GetInt32(4),
                        };
                        string capitalCityName = (string)reader["Name"];
                        var res = new
                        {
                            country,
                            capitalCityName,
                        };
                        return res;
                    }
                }
            }
            return null;
        }

        public object GetCountryAndItsCapitalCityDDetails(int Id)
        {
            using (SQLiteCommand com = new SQLiteCommand($"SELECT * FROM Country c JOIN CapitalCity cc ON c.CapitalCity_id = cc.Id WHERE c.Id = {Id}", con))
            {
                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country country = new Country
                        {
                            Id = reader.GetInt32(0),
                            Name = (string)reader["NameC"],
                            Size_Km = reader.GetInt32(2),
                            Bith_Year = reader.GetInt32(3),
                            CapitalCity_id = reader.GetInt32(4),
                        };
                        CapitalCity capitalCity = new CapitalCity
                        {
                            Id = reader.GetInt32(5),
                            Name = (string)reader["Name"],
                            NumCitizens = reader.GetInt32(7),
                            Country_id = reader.GetInt32(8),
                        };
                        var res = new
                        {
                            country,
                            capitalCity,
                        };
                        return res;
                    }
                }
            }
            return null;
        }

        public object GetCountryAndItsCapitalCityDDetails(string countryName)
        {
            using (SQLiteCommand com = new SQLiteCommand($"SELECT * FROM Country c JOIN CapitalCity cc ON c.CapitalCity_id = cc.Id WHERE c.NameC = '{countryName}'", con))
            {
                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country country = new Country
                        {
                            Id = reader.GetInt32(0),
                            Name = (string)reader["NameC"],
                            Size_Km = reader.GetInt32(2),
                            Bith_Year = reader.GetInt32(3),
                            CapitalCity_id = reader.GetInt32(4),
                        };
                        CapitalCity capitalCity = new CapitalCity
                        {
                            Id = reader.GetInt32(5),
                            Name = (string)reader["Name"],
                            NumCitizens = reader.GetInt32(7),
                            Country_id = reader.GetInt32(8),
                        };
                        var res = new
                        {
                            country,
                            capitalCity,
                        };
                        return res;
                    }
                }
            }
            return null;
        }

        public object GetCountryAndItsCapitalCityName(string countryName)
        {
            using (SQLiteCommand com = new SQLiteCommand($"SELECT c.Id,c.NameC,c.Size_Km,c.Bith_Year,cc.Id,cc.Name FROM Country c JOIN CapitalCity cc ON c.CapitalCity_id = cc.Id WHERE c.NameC='{countryName}'", con))
            {
                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country country = new Country
                        {
                            Id = reader.GetInt32(0),
                            Name = (string)reader["NameC"],
                            Size_Km = reader.GetInt32(2),
                            Bith_Year = reader.GetInt32(3),
                            CapitalCity_id = reader.GetInt32(4),
                        };
                        string capitalCityName = (string)reader["Name"];
                        var res = new
                        {
                            country,
                            capitalCityName,
                        };
                        return res;
                    }
                }
            }
            return null;
        }

        public Dictionary<Country, string> LiteraCountryName(char x)
        {
            Dictionary<Country, string> myDict = new Dictionary<Country, string>();
            using (SQLiteCommand com = new SQLiteCommand($"SELECT c.Id,c.NameC,c.Size_Km,c.Bith_Year,cc.Id,cc.Name FROM Country c JOIN CapitalCity cc ON c.CapitalCity_id = cc.Id WHERE c.NameC LIKE '{x}%'", con))
            {
                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country country = new Country
                        {
                            Id = reader.GetInt32(0),
                            Name = (string)reader["NameC"],
                            Size_Km = reader.GetInt32(2),
                            Bith_Year = reader.GetInt32(3),
                            CapitalCity_id = reader.GetInt32(4),
                        };
                        string capitalCityName = (string)reader["Name"];
                        myDict.Add(country, capitalCityName);
                       
                    }
                }
                return myDict;
            }
            
        }
    }
}
