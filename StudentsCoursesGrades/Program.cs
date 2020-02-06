using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCoursesGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = 0;
            string str1 = "UPDATE Courses SET Courses.AVG_GRADE = B.AVG_COURSES  FROM Courses INNER JOIN (SELECT AVG(Grades.GRADE) as AVG_COURSES,Grades.COURSE_ID FROM Grades  GROUP BY COURSE_ID)B ON Courses.Id = B.COURSE_ID ";
            string str2 = "Update Courses SET Courses.HIGHEST_GRADE = B.HIGH_GRADE FROM COURSES INNER JOIN(SELECT MAX(Grades.Grade) as HIGH_GRADE,Grades.COURSE_ID FROM Grades GROUP BY COURSE_ID)B ON Courses.ID = B.COURSE_ID;";
            string str3 = "Update Courses SET Courses.NUM_OF_STUDENTS = B.NUM_OF_STUDENTS FROM COURSES INNER JOIN(SELECT COUNT(*) as NUM_OF_STUDENTS,Grades.COURSE_ID FROM Grades GROUP BY COURSE_ID)B ON Courses.ID = B.COURSE_ID";
            string str4 = "SELECT MAX(C.NUMBER_OF_STUDENTS)FROM(SELECT * FROM Courses INNER JOIN (SELECT COUNT(*) as NUMBER_OF_STUDENTS,Grades.COURSE_ID FROM Grades GROUP BY COURSE_ID)B ON Courses.ID = B.COURSE_ID)C";
            string str5 = "SELECT top 1 C.COURSE_ID,C.COURSES_AVG_GRADE FROM (SELECT * FROM Courses INNER JOIN (SELECT AVG(Grades.GRADE) as COURSES_AVG_GRADE,Grades.COURSE_ID FROM Grades  GROUP BY COURSE_ID)B ON Courses.Id = B.COURSE_ID)C GROUP BY C.COURSE_ID, C.COURSES_AVG_GRADE ORDER BY C.COURSES_AVG_GRADE DESC";
            string str6 = "SELECT top 1 B.STUDENT_ID FROM (SELECT Count(*) as St_Count, Grades.STUDENT_ID FROM Grades Group by STUDENT_ID)B ORDER BY St_Count DESC";
            string str7 = "SELECT C.STUDENT_ID FROM(SELECT top 1 COUNT(B.STUDENT_ID) as RECEIVED_HIGHEST_GRADE_COUNT,B.STUDENT_ID FROM (SELECT * FROM Grades INNER JOIN Courses ON Grades.COURSE_ID = Courses.ID WHERE Grades.GRADE = Courses.HIGHEST_GRADE)B GROUP BY B.STUDENT_ID order by RECEIVED_HIGHEST_GRADE_COUNT DESC)C";
            string str8 = "SELECT top 1 COUNT(Students.LAST_NAME) as COUNT_NAME,Students.LAST_NAME FROM Students GROUP BY Students.LAST_NAME ORDER BY COUNT_NAME DESC";
            string str9 = "SELECT * FROM Courses";
            using (SqlConnection con = new SqlConnection(@"Data Source=BRAMNIK-PC;Initial Catalog=StudentsCoursesGrades;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(str1, con))
                {
                    com.ExecuteNonQuery();

                }
                using (SqlCommand com = new SqlCommand(str2, con))
                {
                    com.ExecuteNonQuery();
                }
                using (SqlCommand com = new SqlCommand(str3, con))
                {
                    com.ExecuteNonQuery();
                }
                using (SqlCommand com = new SqlCommand(str9, con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine("Id = {0}", reader[0]);
                            Console.WriteLine("Name = {0}", reader["NAME"]);
                            Console.WriteLine("Hours = {0}", reader["HOURS"]);
                            Console.WriteLine("AVG-Grade = {0}", reader["AVG_GRADE"]);
                            Console.WriteLine("Number of Students = {0}", reader["NUM_OF_STUDENTS"]);
                            Console.WriteLine("Highest Grade = {0}", reader["HIGHEST_GRADE"]);
                            Console.WriteLine("__________________________________________________");
                        }
                    }
                }
                Console.WriteLine("******************************************************************");
                using (SqlCommand com = new SqlCommand(str4, con))
                {
                    res = Convert.ToInt32(com.ExecuteScalar());
                    Console.WriteLine($"Maximum number of students in the course = {res}");
                }
                Console.WriteLine("******************************************************************");

                using (SqlCommand com = new SqlCommand(str5, con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id of the course where the avg grade is the highest = {0}", reader[0]);
                            Console.WriteLine("Avg grade = {0}", reader[1]);
                     
                        }
                    }
                }
                Console.WriteLine("******************************************************************");
                using (SqlCommand com = new SqlCommand(str6, con))
                {
                    res = Convert.ToInt32(com.ExecuteScalar());
                    Console.WriteLine($"id of the student who is registered for the largest number of courses = {res}");
                }
                Console.WriteLine("******************************************************************");
                using (SqlCommand com = new SqlCommand(str7, con))
                {
                    res = Convert.ToInt32(com.ExecuteScalar());
                    Console.WriteLine($"id of the student who is received the highest grade the most times = {res}");
                }
                Console.WriteLine("******************************************************************");
                using (SqlCommand com = new SqlCommand(str8, con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();
                        
                            Console.WriteLine("Count = ", reader[0]);
                            Console.WriteLine("Last Name = {0}", reader["LAST_NAME"]);

                    }
                }
                Console.WriteLine("******************************************************************");
            }
            Console.ReadLine();
        }
       
    }
}
