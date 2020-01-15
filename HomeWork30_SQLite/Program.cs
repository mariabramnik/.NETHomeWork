using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryDAO cd = new CountryDAO();
            cd.CreateMap();
            var result = cd.GetCountryAndItsCapitalCityName(1);
            var res = cd.GetCountyAndItsCapitalCityDDetails(2);
            var res1 = cd.GetCountyAndItsCapitalCityName("Israel");
            var res2 = cd.GetCountyAndItsCapitalCityDDetails("Latvia");
            Dictionary<Country, string> dictRes = cd.LiteraCountryName('L');
            Console.WriteLine(result);
            Console.WriteLine(res);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            foreach(KeyValuePair<Country,string> KeyValue in dictRes)
            {
                Console.WriteLine($"List : { KeyValue.Key}  {KeyValue.Value}");
            }
            Console.ReadLine();
        }
    }
}
