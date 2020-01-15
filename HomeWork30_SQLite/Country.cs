using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30_SQLite
{
    class Country
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size_Km{get;set;}
        public int Bith_Year { get; set; }
        public int CapitalCity_id { get; set; }
        public Country(int id,string name,int size_km,int bith_year,int capitalCity_id)
        {
            this.Id = id;
            this.Name = name;
            this.Size_Km = size_km;
            this.Bith_Year = bith_year;
            this.CapitalCity_id = capitalCity_id;
        }
        public Country() { }
        public override string ToString()
        {
            return $"{Id} , {Name} , {Size_Km}, {Bith_Year}, {CapitalCity_id}";
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override bool Equals(object obj)
        {
  
            Country c = obj as Country;
    
            return this.Id == c.Id;
        }
        public static bool operator ==(Country c1, Country c2)
        {
            if(c1 == null && c2 == null)
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
        public static bool operator !=(Country c1, Country c2)
        {

            return !(c1 == c2);
        }
    }
}
