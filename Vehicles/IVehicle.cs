namespace Garage1._0.Vehicles
{
    public interface IVehicle
    {
        string Brand { get; set; }
        string RegNumber { get; set; }
        string Color { get; set; }
        int NrOfWheels { get; set; }
        string GetInfo();
    }
}