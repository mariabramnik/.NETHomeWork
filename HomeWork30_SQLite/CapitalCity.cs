using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30_SQLite
{
    class CapitalCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumCitizens { get; set; }
        public int Country_id { get; set; }
        public CapitalCity(int id, string name,int numCitizens,int country_id)
        {
            this.Id = id;
            this.Name = name;
            this.NumCitizens = numCitizens;
            this.Country_id = country_id;
        }
        public CapitalCity() { }

        public override string ToString()
        {
            return $"{Id} , {Name} , {NumCitizens}, {Country_id}";
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            CapitalCity c = obj as CapitalCity;
            if (c == null)
            {
                return false;
            }
            return this.Id == c.Id;
        }
        public static bool operator == (CapitalCity c1, CapitalCity c2)
        {
            if (c1 == null && c2 == null)
            {
                return true;
            }
            if (c1 == null || c2 == null)
            {
                return false;
            }
            return (c1.Id == c2.Id);
        }
        public static bool operator !=(CapitalCity c1, CapitalCity c2)
        {

            return !(c1 == c2);
        }
    }
}
