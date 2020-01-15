using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30_SQLite2
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryDAO cd = new CountryDAO();
            cd.SqlConnectionOpen();
            var result = cd.GetCountryAndItsCapitalCityName(1);
            var res = cd.GetCountryAndItsCapitalCityDDetails(3);
            var res2 = cd.GetCountryAndItsCapitalCityName("Israel");
            var res3 = cd.GetCountryAndItsCapitalCityDDetails("Latvia");
            Dictionary<Country, string> dictRes = cd.LiteraCountryName('L');
            cd.SqlConnectionClose();
            Console.WriteLine(result);
            Console.WriteLine(res);
            Console.WriteLine(res2);
            Console.WriteLine(res3);
            foreach(KeyValuePair<Country,string> KeyValue in dictRes)
            {
                Console.WriteLine($":{KeyValue.Key} {KeyValue.Value}");
            }
            Console.ReadLine();
        }
    }
}
