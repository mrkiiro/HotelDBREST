using ModelLib.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        private const string URI = "http://localhost:50935/api/Facilitet";


        static void Main(string[] args)
        {
            List<Facilitet> facilitets = getAllFacilities();

            Console.WriteLine("Følgende faciliteter eksistere i databasen.");

            foreach (var f in facilitets)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine();

            Console.WriteLine("Type in the name of a new facility you want to create");
            createNewFacility(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Følgende faciliteter eksistere i databasen.");
            foreach (var f in getAllFacilities())
            {
                Console.WriteLine(f);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        public static List<Facilitet> getAllFacilities()
        {
            List<Facilitet> facilities = new List<Facilitet>();

            using (HttpClient myClient = new HttpClient())
            {
                Task<string> resultString = myClient.GetStringAsync(URI);
                facilities = JsonConvert.DeserializeObject<List<Facilitet>>(resultString.Result);
            }

            return facilities;
        }

        public static bool createNewFacility(string Name)
        {
            using (HttpClient myclient = new HttpClient())
            {
                Facilitet f = new Facilitet() {Navn = Name};

                string jsonString = JsonConvert.SerializeObject(f);
                StringContent content = new StringContent(jsonString, Encoding.ASCII, "application/json");

                Task<HttpResponseMessage> response = myclient.PostAsync(URI, content);

                return response.Result.IsSuccessStatusCode;
            }
        }
    }
}
