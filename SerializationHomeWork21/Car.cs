using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

namespace SerializationHomeWork21
{
    //DataContract - this class makes it possible to work with non-public access modifiers
    //In Class Person serialization is implemented  using the class XmlSerializer
    [DataContract]
   class Car
    {
        [DataMember]
        public string Model{get;set;}
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        private int _codan;
        [DataMember]
        protected int _numberOfSeats;

        public Car()
        {

        }
        public Car(string fileName)
        {

        }
        public Car(string model,string brand,int year,string color,int codan,int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            _codan = codan;
            _numberOfSeats = numberOfSeats;

        }
        public int GetCodan()
        {
            return _codan;
        }

        public int GetNumberOfSeats()
        {
            return _numberOfSeats;
        }

        protected void ChangeNumberOfSeats(int newNum)
        {
            _numberOfSeats = newNum;
        }

        public override string ToString()
        {
            return $"Model = {Model} , Brand = {Brand} , Year = {Year} , Color = {Color}, Number of Seats = {GetNumberOfSeats()}";
        }
        // put the object in a file in xml-format
        public static void SerializeACar(string fileName, Car car)
        {
            string myUrl = @"C:\test\" + fileName;
            /*//example how to do the same otherwise
            // BinaryFormatter binformatter = new BinaryFormatter();
            XmlSerializer formatter = new XmlSerializer(typeof(Car));         
            using (FileStream fs = new FileStream(myUrl, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, car);
                Console.WriteLine("successful serialization");
            }
            */

            using (FileStream fs = new FileStream(myUrl, FileMode.OpenOrCreate))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Car));
                var settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\t"
                };
                //if we need to output to the console
                //System.Xml.XmlWriter xw = XmlWriter.Create(Console.Out);
                using (XmlWriter xw = XmlWriter.Create(fs, settings))
                {             
                    ser.WriteObject(xw, car);
                    Console.WriteLine("successful serialization");
                }
            }
        }
        public static void SerializeCarArray(string fileName, Car[] cars)
        {
            string myUrl = @"C:\test\" + fileName;
            using (FileStream fs = new FileStream(myUrl, FileMode.OpenOrCreate))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Car[]));            
                var settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\t"
                };
                using (XmlWriter xw = XmlWriter.Create(fs,settings))
                {
                    ser.WriteObject(xw, cars);
                    Console.WriteLine("successful serialization");
                }
            }
        }
        //From the xmlfile get the object
        public static Car DeserializeCar(string fileName)
        {
            Car deserializedCar;
            string myUrl = @"C:\test\" + fileName;
            using (FileStream fs = new FileStream(myUrl, FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Car));
                using (XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    deserializedCar = (Car)ser.ReadObject(reader, true);
                }                
            }
            return deserializedCar;
        }
        public static Car[] DeserializeCarArray(string fileName)
        {
            Car[] deserializedCars = new Car[3];
            string myUrl = @"C:\test\" + fileName;
            using (FileStream fs = new FileStream(myUrl, FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Car[]));
                using (XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    deserializedCars = (Car[])ser.ReadObject(reader, true);
                }
               // reader.Close();
            }
            return deserializedCars;
        }

        public bool CarCompare(string fileName)
        {
            Car car = DeserializeCar(fileName);
            if(car.Brand == Brand && car.Model == Model && car.Year == Year 
                && car.Color == Color && car._codan == GetCodan() 
                && car._numberOfSeats == GetNumberOfSeats())
            {
                return true;
            }
            return false;
        }


    }
}
