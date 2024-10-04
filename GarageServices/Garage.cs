using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1._0.Vehicles;

namespace Garage1._0.GarageServices
{
    // Generisk class där alla vår fordon kan parkera, avsluta parkering, leta up och
    // lista alla fordon... KeyNote! --> glöm inte att ärva from vehicle klassen
    internal class Garage<T> : IEnumerable<T>, IHandler<T> where T : Vehicle
    {
         
        private int capacitet { get; set; }
        private int nrOfVehicles { get; set; }
        private T[] vehicles { get; set; }// vår privata Array för att hantera fordon istället för List<Véhicle>

        public Garage(int capacitet)
        {
            this.capacitet = capacitet;
            vehicles = new T[capacitet];
            nrOfVehicles = 0;
        }
        public bool Parkera(T vehicle)
        {
            // Kolla om vi har utrymme kvar i garaget baserat på kapaciteten.
            if (nrOfVehicles < capacitet)
            {                
                vehicles[nrOfVehicles] = vehicle;
                nrOfVehicles++; // Ökar räknaren efter att ha parkerat fordonet.
                return true;
            }
            return false;
            // OBS! Behöver bli bättre på namngivning – det här är lite förvirrande och svårt att följa
            // även för mig. Keynote for future --->
            // Exempel: byt till "antal" eller "ledigaPlatser" istället för nrOfVehicles.
        }

        public bool AvslutaParkering(string regNumber)
        {
            for (int i = 0; i < nrOfVehicles; i++)
            {
                if (vehicles[i].RegNumber == regNumber)
                {
                    vehicles[i] = vehicles[nrOfVehicles - 1]; // Ersätt med sista fordonet
                    vehicles[nrOfVehicles - 1] = default(T);  // Nollställ sista platsen
                    nrOfVehicles--;                           // Minska antalet fordon


                    //KeyNote: Arrayen blir osorterad när sista fordonet flyttas till den borttagna platsen.
                    //         Justera om ordning är viktig.

                    return true; 
                }
            }
            return false; // Fordonet hittades inte
        }              

        // Här söker vi efter fordon baserat på färg och antal hjul.
        // Vi använder null-kontroll för att tillåta sökning på en eller flera egenskaper.
        public T[] SökFordon(string color = null, int? nrOfWheels = null)
        {
            return vehicles
                .Where(v => v != null &&
                            // Om färg anges, kontrollera att den matchar,vi använder StringComparison.OrdinalIgnoreCase
                            // för att göra sökningnen case-insensitive.
                            (color == null || v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&                            
                            (!nrOfWheels.HasValue || v.NrOfWheels == nrOfWheels))
                            // Om antal hjul anges, kontrollera att det matchar.
                .ToArray();
        }
        public void FordonList()
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Console.WriteLine(vehicle.GetInfo());
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < nrOfVehicles; i++)
            {
                yield return (T)vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return vehicles.GetEnumerator();
        }
    }

}
