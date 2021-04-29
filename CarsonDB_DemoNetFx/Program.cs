using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsonDB;
using Newtonsoft.Json;

namespace CarsonDB_DemoNetFx
{
    class Program
    {
        static void Main(string[] args)
        {
            var animal = new Animal(@"C:\AVImark");
            var animals = animal.AnimalList();

            var ap = new Appointment();
            var appointments = ap.AppointmentList();

            var client = new Client();
            var clients = client.ClientList();

            var data = new
            {
                clients,
                appointments,
                animals
            };

            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(jsonData);

            var clients1st = client.RecordsChangedSinceLastSnapshot<Client.ClientData>();
            Console.WriteLine($"Total Clients Retrieved 1st: {clients1st.Count}");

            var clients2nd = client.RecordsChangedSinceLastSnapshot<Client.ClientData>();
            Console.WriteLine($"Total Clients Retrieved 2nd: {clients2nd.Count}");

            /*Console.WriteLine("Listing Animals:");
            foreach (var a in animals)
            {
                Console.WriteLine($"Name: {a.AnimalName} ");
            }
            Console.WriteLine("Listing Clients:");
            foreach (var c in clients)
            {
                Console.WriteLine($"Client First Name: {c.ClientFirst} Last Name: {c.ClientLast} ");
            }
            Console.WriteLine("Listing Appointments:");
            foreach (var a in aps)
            {
                Console.WriteLine($"Client: {a.AppointmentClient} MadeBy: {a.AppointmentMadeBy} ");
            }*/
            Console.ReadLine();
        }
    }
}
