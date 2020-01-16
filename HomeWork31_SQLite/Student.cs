using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork31_SQLite
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string AddressCity { get; set; }
        public string VIP { get; set; }
        public int Class_id { get; set; }
        public Student() { }

        public Student(int id, string name, int age, string addressCity, string vIP, int class_id)
        {
            Id = id;
            Name = name;
            Age = age;
            AddressCity = addressCity;
            VIP = vIP;
            Class_id = class_id;
        }
        public override string ToString()
        {
            return $"{Id} {Name} {Age} {AddressCity} {VIP} {Class_id}";
        }
        public static bool operator==(Student s1,Student s2)
        {
            if (s1 == null && s2 == null)
            {
                return false;
            }
            if (s1 == null || s2 == null)
            {
                return false;
            }
            if (s1.Id == s2.Id)
            {
                return true;
            }
            else return false;
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override bool Equals(object obj)
        {
            Student s = obj as Student;
            return (this.Id == s.Id);
        }
    }
}
