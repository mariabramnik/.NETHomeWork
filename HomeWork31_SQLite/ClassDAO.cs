using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace HomeWork31_SQLite
{
    class ClassDAO
    {
        public Dictionary<Class, List<Student>> dictClassStudents = new Dictionary<Class, List<Student>>();
        static SQLiteConnection con = new SQLiteConnection("Data source = C:\\Users\\Bramnik\\MashaDBLite4.db; Version = 3;MultipleActiveResultSets=True");
        public void SQLiteConnectionOpen()
        {
            con.Open();
        }
        public void SQLiteConnectionClose()
        {
            con.Close();
        }
        public void UpdateClassNumberOfStudent()
        {
            using (SQLiteCommand com = new SQLiteCommand("UPDATE Class SET NumberOfStudents = (SELECT Count(*) FROM Student WHERE Class_id = Class.Id) ", con))
            {
                com.ExecuteNonQuery();
            }
        }
        public void UpdateClassNumberOfVIP()
        {
            using (SQLiteCommand com = new SQLiteCommand("UPDATE Class SET NumberOfVIP = (SELECT Count(*) FROM Student WHERE Student.VIP = 'Yes' AND Class_id = Class.Id)", con))
            {
                com.ExecuteNonQuery();
            }
        }
        public void UpdateClassAgeAverage()
        {
            using (SQLiteCommand com = new SQLiteCommand("UPDATE Class SET AgeAverage = (SELECT AVG(Age) FROM Student WHERE Class_id = Class.Id)", con))
            {
                com.ExecuteNonQuery();
            }
        }
        public void UpdateClassMostPopularCity()
        {
            using (SQLiteCommand com = new SQLiteCommand("UPDATE Class SET MostPopularCity = (SELECT AddressCity FROM (SELECT AddressCity, MAX(counted) FROM (SELECT *, AddressCity, count(*) AS counted FROM Student GROUP BY AddressCity HAVING Student.Class_id = Class.Id)))", con))
            {
                com.ExecuteNonQuery();
            }
        }
        public void UpdateClassOldestVIP()
        {
            using (SQLiteCommand com = new SQLiteCommand("Update Class SET OldestVIP = (SELECT max(Age)FROM Student WHERE Student.VIP='Yes' AND Class_id = Class.Id)", con))
            {
                com.ExecuteNonQuery();
            }
        }
        public void UpdateClassYoungestVIP()
        {
            using (SQLiteCommand com = new SQLiteCommand("Update Class SET YoungestVIP = (SELECT min(Age)FROM Student WHERE  Student.VIP='Yes' AND Class_id = Class.Id)", con))
            {
                com.ExecuteNonQuery();
            }
        }

        public Dictionary<Class, List<Student>> GetMapClassToStudentsDictionary()
        {
            List<Class> listClass = new List<Class>();
            List<Student> listCurrent = new List<Student>();

            using (SQLiteCommand com = new SQLiteCommand("Select * FROM Class", con))
            {
                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Class c = new Class
                        {
                            Id = reader.GetInt32(0),
                            Code = reader.GetInt32(1),
                            NumberOfStudens = reader.GetInt32(2),
                            NumberOfVIP = reader.GetInt32(3),
                            AgeAverage = reader.GetDouble(4),
                            MostPopularCity = reader.GetString(5),
                            OldestVIP = reader.GetInt32(6),
                            YoungestVIP = reader.GetInt32(7)

                        };
                        listClass.Add(c);

                    }
                }
            }
            foreach (Class c in listClass)
            {
                using (SQLiteCommand com2 = new SQLiteCommand($"SELECT* FROM Student WHERE Class_id = {c.Id}", con))
                {
                    using (SQLiteDataReader reader2 = com2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {

                            Student s = new Student
                            {
                                Id = reader2.GetInt32(0),
                                Name = (string)reader2["Name"],
                                Age = reader2.GetInt32(2),
                                AddressCity = (string)reader2["AddressCity"],
                                VIP = (string)reader2["VIP"],
                                Class_id = reader2.GetInt32(5)
                            };
                            listCurrent.Add(s);
                        }
                        dictClassStudents.Add(c, listCurrent);
                        listCurrent = new List<Student>();


                    }

                }
            }

            return dictClassStudents;
        }
        public List<Student> GetStudentFromClass(int myId)
        {
            Class c;
            List<Student> listRes = new List<Student>();
            using (SQLiteCommand com = new SQLiteCommand($"Select * FROM Class WHERE Id = {myId}", con))
            {
          
                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         c = new Class
                        {
                            Id = reader.GetInt32(0),
                            Code = reader.GetInt32(1),
                            NumberOfStudens = reader.GetInt32(2),
                            NumberOfVIP = reader.GetInt32(3),
                            AgeAverage = reader.GetDouble(4),
                            MostPopularCity = reader.GetString(5),
                            OldestVIP = reader.GetInt32(6),
                            YoungestVIP = reader.GetInt32(7)

                        };
                        listRes = dictClassStudents[c];
                    }
                }
            }
            return listRes;
        }
    }
}