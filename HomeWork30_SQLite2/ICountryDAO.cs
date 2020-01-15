using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30_SQLite2
{
    interface ICountryDAO
    {
        object GetCountryAndItsCapitalCityName(int Id);
        object GetCountryAndItsCapitalCityDDetails(int Id);
        object GetCountryAndItsCapitalCityName(string countryName);
        object GetCountryAndItsCapitalCityDDetails(string countryName);
        Dictionary<Country, string> LiteraCountryName(char x);
    }
}
