using System.Globalization;

using Garage1._0.GarageServices;
using Garage1._0.Vehicles;
using System;

namespace Garage1._0.UserInterface
{
    public class ConsolUI<T> : IUI where T : Vehicle
    {
        private readonly IHandler<T> handler;

        public ConsolUI(IHandler<T> handler)
        {
            this.handler = handler;
        }

        public void HuvudMeny()
        {
            bool isActive = true;
            while (isActive)
            {
                Console.WriteLine("Välj från en av alternativen i listan!"
                    + "\n1. Parkera Fordon"
                    + "\n2. Avsluta din parkering"
                    + "\n3. Lista alla fordon"
                    + "\n4. Sök Fordon"
                    + "\n5. Avsluta");

                switch (Console.ReadLine())
                {
                    case "1":
                        Parkera();
                        break;
                    case "2":
                        AvslutaParkering();
                        break;
                    case "3":
                        FordonList();
                        break;
                    case "4":
                        SökFordon();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Fel inmatning! Försök igen.");
                        break;
                }
            }
        }

        public void Parkera()
        {
            Console.WriteLine("Ange typ av fordon (t.ex. Bil, Motorcykel, Flygplan):");
            string typ = Console.ReadLine().ToLower();

            Console.WriteLine("Ange märke (Brand):");
            string brand = Console.ReadLine();

            Console.WriteLine("Ange registreringsnummer:");
            string regNumber = Console.ReadLine();

            Console.WriteLine("Ange färg:");
            string color = Console.ReadLine();

            Console.WriteLine("Ange antal hjul:");
            int nrOfWheels;
            while (!int.TryParse(Console.ReadLine(), out nrOfWheels))
            {
                Console.WriteLine("Ogiltigt antal hjul, försök igen:");
            }

            Vehicle vehicle = null;

            // Skapa fordon baserat på användarens val
            switch (typ)
            {
                case "bil":
                    vehicle = new Car(brand, regNumber, color, nrOfWheels, "Bensin");
                    break;
                case "motorcykel":
                    vehicle = new Motorcycle(brand, regNumber, color, nrOfWheels, 1200);
                    break;
                case "flygplan":
                    vehicle = new Airplane(brand, regNumber, color, nrOfWheels, 6);
                    break;
                default:
                    Console.WriteLine("Ogiltig fordonstyp.");
                    return; // Avbryt om ogiltig typ anges
            }

            // Försök att parkera fordonet
            if (handler.Parkera((T)vehicle))
            {
                Console.WriteLine("Fordonet har parkerats.");
            }
            else
            {
                Console.WriteLine("Tyvärr så är garaget fullt.");
            }
        }

        public void AvslutaParkering()
        {
            Console.WriteLine("Ange registreringsnummer för att avsluta parkering:");
            string regNumber = Console.ReadLine();

            if (handler.AvslutaParkering(regNumber))
            {
                Console.WriteLine("Fordonet togs bort.");
            }
            else
            {
                Console.WriteLine("Fordonet hittades inte.");
            }
        }

        public void FordonList()
        {
            Console.WriteLine("Alla typer av fordon i garaget:");
            handler.FordonList();
        }

        public void SökFordon()
        {
            Console.WriteLine("Ange färg:");
            string color = Console.ReadLine();

            Console.WriteLine("Ange antal hjul:");
            string wheelsInput = Console.ReadLine();
            int? nrOfWheels = string.IsNullOrWhiteSpace(wheelsInput) ? (int?)null : int.Parse(wheelsInput);

            var vehicles = handler.SökFordon(color, nrOfWheels);
            if (vehicles.Length > 0)
            {
                Console.WriteLine("Fordon som matchar sökkriterierna:");
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle.GetInfo());
                }
            }
            else
            {
                Console.WriteLine("Inga fordon hittades.");
            }
        }
    }
}
