using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork31_SQLite
{
    class Class
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int NumberOfStudens { get; set; }
        public int NumberOfVIP { get; set; }
        public double AgeAverage { get; set; }
        public string MostPopularCity { get; set; }
        public int OldestVIP { get; set; }
        public int YoungestVIP { get; set; }
        public Class() { }

        public Class(int id, int code, int numberOfStudens, 
            int numberOfVIP, int ageAverage, string mostPopularCity, 
            int oldestVIP, int youngestVIP)
        {
            Id = id;
            Code = code;
            NumberOfStudens = numberOfStudens;
            NumberOfVIP = numberOfVIP;
            AgeAverage = ageAverage;
            MostPopularCity = mostPopularCity;
            OldestVIP = oldestVIP;
            YoungestVIP = youngestVIP;
        }

        public override string ToString()
        {
            return $"{Id} {Code} {NumberOfStudens} {NumberOfVIP} {AgeAverage} " +
                $"{MostPopularCity} {OldestVIP} {YoungestVIP}";
        }
        public static bool operator ==(Class c1, Class c2)
        {
            if (c1 == null && c2 == null)
            {
                return false;
            }
            if (c1 == null || c2 == null)
            {
                return false;
            }
            if (c1.Id == c2.Id)
            {
                return true;
            }
            else return false;
        }
        public static bool operator !=(Class c1, Class c2)
        {
            return !(c1 == c2);
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override bool Equals(object obj)
        {
            Class c = obj as Class;
            return (this.Id == c.Id);
        }
    }
}
