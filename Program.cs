using Garage1._0.GarageServices;
using Garage1._0.UserInterface;
using Garage1._0.Vehicles;

namespace Garage1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GarageHandler<Car> garageHandler = new GarageHandler<Car>(10); // Skapa ett garage för bara bilar

            var garage = new Garage<Vehicle>(10); // Skapa ett garage för alla fordon med max kapacitet 10
            var ui = new ConsolUI<Vehicle>(garage);
            ui.HuvudMeny();

        }
    }
}
