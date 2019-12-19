using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp22HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Camp c1 = new Camp(123, 345, 10, 10, 10);
            Camp c2 = new Camp(123, 345, 20, 20, 20);
            if(c1 > c2)
            {
                Console.WriteLine("first camp is larger than the second");
            }
            else
            {
                Console.WriteLine("second camp is larger than the first");
            }
            if(c1 == c2)
            {
                Console.WriteLine("first camp is equal to the second");
            }
            else
            {
                Console.WriteLine("first camp is not equal to the second");
            }
            if(c1.Equals(c2))
            {
                Console.WriteLine("first camp is equal to the second");
            }
            else
            {
                Console.WriteLine("first camp is not equal to the second");
            }
            Console.WriteLine(c1);            
            Camp c3 = c1 + c2;
            c3.Latitude = 456;
            c3.Logitude = 765;
            Console.WriteLine(c3);
            Console.WriteLine(c1);
            c1.SerializeXmlToFaile("camp.xml");
            Camp c4 = Camp.DeSerializeXmlFaileToCamp("camp.xml");
            Console.WriteLine($"c1 HashCode = {c1.GetHashCode()}");
            Console.WriteLine($"c4 HashCode = {c4.GetHashCode()}");
            if (c1 == c4 && c1.GetHashCode() == c4.GetHashCode())
            {
                Console.WriteLine("Serializing and deserializing did not change the camp");
            }
            else
            {
                Console.WriteLine("Serializing and deserializing changed the camp");
            }
            c4.SerializeJsonToFaile("campJson.json");
            Camp c6 = Camp.DeSerializeJsonFaileToCamp("campJson.json");
            Console.WriteLine(c6);
            Console.ReadLine();
        }
    }
}
