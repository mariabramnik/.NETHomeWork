using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationHomeWork21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------Car------------------------------");
            Car car1 = new Car("quashqai", "nissan", 2019, "red", 1342, 5);
            Car car2 = new Car("centra", "nissan", 2013, "blue", 23233, 5);
            Car car3 = new Car("zhuk", "nissan", 2014, "orange", 1222, 5);
            Car car4 = new Car("5", "mazda", 2015, "green", 7999, 5);
            Car[] cars = new Car[3] { car2, car3, car4 };
            Car.SerializeACar("car1.xml", car1);
            Car.SerializeCarArray("car.xml", cars);
            Car desirializedCar = Car.DeserializeCar("car1.xml");
            Console.WriteLine(String.Format("Model : {0} ,Brand: {1},Color: {2}, Year: {3}, Codan : {4}",
            desirializedCar.Model, desirializedCar.Brand,
            desirializedCar.Color, desirializedCar.Year, desirializedCar.GetCodan()));
            Car[] desirializedCars = Car.DeserializeCarArray("car.xml");
            foreach (Car c in desirializedCars)
            {
                Console.WriteLine(String.Format("Model : {0} ,Brand: {1},Color: {2}, Year: {3}, Codan : {4}",
                c.Model, c.Brand,
                c.Color, c.Year, c.GetCodan()));
            }
            bool res = car1.CarCompare("car1.xml");
            Console.WriteLine(res);
            Console.WriteLine("------------------------Person------------------------------");
            Person p1 = new Person(21, "masha");
            Person p2 = new Person(23, "max");
            Person p3 = new Person(25, "sem");
            Person[] pers = new Person[] { p1, p2, p3 };
            Person.SerializeAPerson("person.xml", p1);
            Person.SerializePersonArray("person1.xml",pers);
            Person p4 = Person.DeserializePerson("person.xml");
            Person[] persArr = Person.DeserializePersonArray("person1.xml");
            Console.WriteLine(p4);
            foreach (Person pp in persArr)
            {
                Console.WriteLine(pp);
            }
            Console.ReadLine();
        }
    }
}
