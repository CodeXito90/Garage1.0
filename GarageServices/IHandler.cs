using Garage1._0.Vehicles;

namespace Garage1._0.GarageServices
{
    public interface IHandler<T> where T : Vehicle
    {
        bool Parkera(T Vehicle);
        bool AvslutaParkering(string regNumber);
        void FordonList();
        IEnumerator<T> GetEnumerator();
        T[] SökFordon(string color = null, int? nrOfWheels = null);
      
    }
}