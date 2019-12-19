using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Camp22HomeWork
{
    public class Camp
    {
        public  int Id { get;set; }
        public int Latitude{ get;set; }
        public int Logitude { get;  set; }
        public int NumberOfPeople { get;  set; }
        public int NumberOfTents { get;  set; }
        public int NumberOfFleshLights { get; set; }
        public static int lastCampId = 0;
        public Camp(int latitude,int logitude,int numberOfPeople,
            int numberOfTents,int numberOfFleshLights)
        {
            lastCampId++;
            Latitude = latitude;
            Logitude = logitude;
            NumberOfPeople = numberOfPeople;
            NumberOfTents = numberOfTents;
            NumberOfFleshLights = numberOfFleshLights;
            Id = lastCampId;
        }
        public Camp(int a, int b)    
        {
            lastCampId++;
            Id = lastCampId;
        }
        public Camp()
        {

        }
        public override string ToString()
        {
            return $"Camp N={Id}, Camp coordinated Y={Latitude} , X={Logitude}," +
                $"Number Of People in the camp = {NumberOfPeople} , Number of tents in the camp = " +
                $"{NumberOfTents} , Number of Fleshlights = {NumberOfFleshLights}";
        }
        public static bool operator == (Camp c1, Camp c2)
        {
            if (c1.Id == c2.Id)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Camp c1, Camp c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
            {
                return true;
            }
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }
            return c1.Id == c2.Id;
        }
        public static bool operator >(Camp c1, Camp c2)
        {
            if (c1 == c2)
            {
                return false;
            }
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }
            return c1.NumberOfPeople > c2.NumberOfPeople;
        }
        public static bool operator <(Camp c1, Camp c2)
        {
            if (c1 == c2)
            {
                return false;
            }
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }
            return c1.NumberOfPeople < c2.NumberOfPeople;
        }
        public override bool Equals(object obj)
        {
            Camp camp2 = (Camp)obj;
            if(camp2.Id == Id)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            
            return this.Id;
        }
        public static Camp operator +(Camp c1,Camp c2)
        {
            Camp c3 = new Camp();
            c3.NumberOfPeople = c1.NumberOfPeople + c2.NumberOfPeople;
            c3.NumberOfTents = c1.NumberOfTents + c2.NumberOfTents;
            c3.NumberOfFleshLights = c1.NumberOfFleshLights + c2.NumberOfFleshLights;
            lastCampId++;
            c3.Id = lastCampId;
            return c3;
        }
        public void SerializeXmlToFaile(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Camp));
            string path = @"C:\test\" + fileName;
            using (FileStream fs = new FileStream(path,FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, this);
                Console.WriteLine("write to Xml -file successful");
            }
        }
        public static Camp DeSerializeXmlFaileToCamp(string fileName)
        {
            Camp c3 = new Camp();
            XmlSerializer ser = new XmlSerializer(typeof(Camp));
            string path = @"C:\test\" + fileName;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                c3 = (Camp)ser.Deserialize(fs);
                Console.WriteLine("read from Xml-file completed successfully");
            }
            return c3;
        }
        //just an example. how works json 
        public void SerializeJsonToFaile(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(this, options);
            string path = @"C:/test/" + fileName;
            //  string json = JsonSerializer.Serialize<Camp>(this);
            //  Console.WriteLine(json);
            File.WriteAllText(path, jsonString);
            Console.WriteLine("write to Json-file successful");
            
        }
        public static Camp DeSerializeJsonFaileToCamp(string fileName)
        {
           
            string path = @"C:/test/" + fileName;
            string stringJson = File.ReadAllText(path);
            Console.WriteLine("json" + stringJson);
           Camp c3 = JsonSerializer.Deserialize<Camp>(stringJson);
            Console.WriteLine("read from Json-file completed successfully");
            
            return c3;
        }
    }
}
