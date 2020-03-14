using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork49ComboBox
{
   public class Country : INotifyPropertyChanged
    {
       public string Name { get; set; }
       public string Capital { get; set; }
       public string PathToImg { get; set; }

        public Country()
        {
        }

        public Country(string name, string capital, string pathToImg)
        {
            this.Name = name;
            this.Capital = capital;
            this.PathToImg = pathToImg;
        }
        public static Country[] GetCountries()
        {
            var result = new[] {
               new  Country() {Name="Israel", Capital = "Jerusalim", PathToImg = "Resources/israel.png"},
                new  Country() {Name="Latvia", Capital = "Riga" ,PathToImg="Resources/latvia.png"},
                new  Country() {Name="Czech", Capital = "Praga", PathToImg="Resources/czech.png"}
        };
            return result;
        }

        public override string ToString()
        {
            return $"{Name}, {Capital}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
