using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationHomeWork21
{
   public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person() { }
        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }
        public override string ToString()
        {
            return $"Age : {Age} , Name: {Name}";
        }
        //very easy way, suitable for public access modifiers
        public static void SerializeAPerson(string fileName, Person p)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Person));
            string path = @"C:\test\" + fileName;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, p);

            }
        }
        public static void SerializePersonArray(string fileName, Person[] pers)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Person[]));
            string path = @"C:\test\" + fileName;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, pers);

            }
        }
        public static Person DeserializePerson(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Person));
            string path = @"C:\test\" + fileName;
            Person p = new Person();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                p = (Person)ser.Deserialize(fs);
            }
            return p;
        }
        public static Person[] DeserializePersonArray(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Person[]));
            string path = @"C:\test\" + fileName;
            Person[] pers;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                pers = (Person[])ser.Deserialize(fs) as Person[];
            }
            return pers;
        }
    }
}
