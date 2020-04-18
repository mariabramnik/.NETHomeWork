using FlightManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientConsole2
{
    class ClassTest
    {
        private const string URLGetAllAirLines = "http://aspproject220200418062456.azurewebsites.net/api/anonyme/allcompanies";
        private const string URLGetAllFlightsVacancy = "http://aspproject220200418062456.azurewebsites.net/api/anonyme/flightsvacancy";
        private const string URLGetAllCountries = "http://aspproject220200418062456.azurewebsites.net/api/anonyme/allcountries";
        private const string URLAddAirLineCompany = "http://aspproject220200418062456.azurewebsites.net/api/administrator/addairline";       
        private const string URLGetAllFlightsOfMyCompany = "http://aspproject220200418062456.azurewebsites.net/api/airline/flights";        
        private const string URLPurchaseTicket = "http://aspproject220200418062456.azurewebsites.net/api/customer/purchaseticket";

        public  void GetAllAirLines()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URLGetAllAirLines);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<AirLineCompany>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.Write("{0} ", d.airLineName);
                    Console.Write("{0} ", d.countryCode);
                    Console.Write("{0} ", d.id);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            //Console.ReadLine();
        }
        public void GetFlightsVacancy()
        {
            List<Flight> listFlights = new List<Flight>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URLGetAllFlightsVacancy);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<Flight>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                var content = response.Content.ReadAsStringAsync().Result;
                // read as first type
                //var X = JsonConvert.DeserializeObject<IEnumerable<Flight>>(content);
                var dataObjects = JsonConvert.DeserializeObject<Dictionary<string, int>>(content);
                //var dataObjects = JsonConvert.DeserializeObject<Dictionary<IEnumerable<Flight>, int>>(content);
                foreach (KeyValuePair<string,int>keyValue in dataObjects)                   
                {
                    string[] arr = keyValue.Key.Split(',');
                    Flight fl = new Flight
                    {
                        id = Int32.Parse(arr[0]),
                        airLineCompanyId = Int32.Parse(arr[1]),
                        originCountryCode = Int32.Parse(arr[2]),
                        destinationCountryCode = Int32.Parse(arr[3]),
                        departureTime = DateTime.Parse(arr[4]),
                        landingTime = DateTime.Parse(arr[5]),
                        remainingTickets = Int32.Parse(arr[6]),
                        flightStatusId = Int32.Parse(arr[7]),
                    };
                    listFlights.Add(fl);
   
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.
            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            foreach(Flight d in listFlights)
            {

                 Console.Write("{0} ", d.id);
                 Console.Write("{0} ", d.airLineCompanyId);
                 Console.Write("{0} ", d.originCountryCode);
                 Console.Write("{0} ", d.destinationCountryCode);
                 Console.Write("{0} ", d.departureTime);
                 Console.Write("{0} ", d.landingTime);
                 Console.Write("{0} ", d.remainingTickets);
                Console.Write("{0} ", d.flightStatusId);
                Console.WriteLine();
            }
            client.Dispose();
            //Console.ReadLine();
        }

        public void AddAirLine(AirLineCompany comp)
        {
            HttpClient client_post = new HttpClient();
            client_post.BaseAddress = new Uri(URLAddAirLineCompany);
            client_post.DefaultRequestHeaders.Accept.Clear();
            client_post.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes("admin:9999")); //("Username:Password")  
            client_post.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

            var response_post = client_post.PostAsJsonAsync("", comp).Result;
            Console.WriteLine(response_post);
            Console.ReadLine();
        }

        public void GetAllCountries()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URLGetAllCountries);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Country>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.Write("{0} ", d.id);
                    Console.Write("{0} ", d.countryName);
                    
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            
        }

        public void GetAllFlightsOfMyCompany()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URLGetAllFlightsOfMyCompany);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes("hop!Admin:204vuc")); //("Username:Password")  
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Flight>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.Write("{0} ", d.id);
                    Console.Write("{0} ", d.airLineCompanyId);
                    Console.Write("{0} ", d.originCountryCode);
                    Console.Write("{0} ", d.destinationCountryCode);
                    Console.Write("{0} ", d.departureTime);
                    Console.Write("{0} ", d.landingTime);
                    Console.Write("{0} ", d.remainingTickets);
                    Console.Write("{0} ", d.flightStatusId);

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            Console.ReadLine();
        }

        public void PurchaseTicket(Flight flight)
        {
            HttpClient client_post = new HttpClient();
            client_post.BaseAddress = new Uri(URLPurchaseTicket);
            client_post.DefaultRequestHeaders.Accept.Clear();
            client_post.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes("smallmouse194:hayden")); //("Username:Password")  
            client_post.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

            var response_post = client_post.PostAsJsonAsync("", flight).Result;
            Console.WriteLine(response_post);
            Console.ReadLine();
        }

        public int EnterOnlyNumber(string str)
        {
            int num = 0;
            bool res = false;
            res = int.TryParse(str, out num);
            while (res == false)
            {
                Console.WriteLine("Enter only number");
                str = Console.ReadLine();
                res = int.TryParse(str, out num);
            }

            return num;
        }
    }
}
