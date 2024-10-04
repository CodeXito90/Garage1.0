using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1._0.Vehicles;

namespace Garage1._0.GarageServices
{// Ansvarig för att abstrahera och hantera 
 // funktionaliteten mellan UI och Garage-klassen.
    public class GarageHandler<T> : IHandler<T> where T : Vehicle
    {
        // Vi börjar med skapa ett privat garageobjekt som hanterar våra fordon
        private Garage<T> garage;

        public GarageHandler(int capacity)// Ctor som sätter garagets kapacitet
        {
            garage = new Garage<T>(capacity);
        }

        
        public bool Parkera(T vehicle)
        {
            
            bool sucess = garage.Parkera(vehicle);
            return sucess;
        }

        // Avslutar parkeringen av ett fordon baserat på regnummer och returnerar
        // en bool om operationen lyckades
        public bool AvslutaParkering(string regNumber)
        {
            bool sucess = garage.AvslutaParkering(regNumber);
            return sucess;
        }

        public void FordonList()
        {
            foreach (var vehicle in garage)
            {
                Console.WriteLine(vehicle.GetInfo());
            }
        }

        // Söker fordon baserat på färg och antal hjul, returnerar en
        // array med matchande fordon
        public T[] SökFordon(string color = null, int? nrOfWheels = null)
        {                             
            return garage.SökFordon(color, nrOfWheels);
        }

        // Möjliggör iteration över garage-klassen med en enumerator
        public IEnumerator<T> GetEnumerator()
        {
            return garage.GetEnumerator();
        }   // KeyNote: IEnumerable gör att vi kan använda foreach på garage
    }

}


