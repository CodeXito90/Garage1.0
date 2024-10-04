using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Garage1._0.Vehicles
{
    // Här implementerar vi vår Vehicle fordonklass, Subklasserna därefter
    // kommer ärva från Vehicle och kommer ha sina unika egenskaper tillagda
    public abstract class Vehicle : IVehicle
    {
        public string Brand { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }

        public Vehicle(string brand, string regNumber, string color, int nrOfWheels)
        {
            Brand = brand;
            RegNumber = regNumber;
            Color = color;
            NrOfWheels = nrOfWheels;
        }
        public abstract string GetInfo();
    }

    public class Car : Vehicle
    {
        public string BränsleTyp { get; set; }
        public Car(string brand, string regNumber, string color, int nrOfWheels, string bränsleTyp)
            : base(brand, regNumber, color, nrOfWheels)
        {
            BränsleTyp = bränsleTyp;
        }

        public override string GetInfo()
        {
            return $"Car: {Brand}, RegNumber: {RegNumber}, Color: {Color}, NrOfWheels: {NrOfWheels}, Bränsletyp: {BränsleTyp} ";
        }
    }

    public class Airplane : Vehicle
    {
        public int AntalMotor { get; set; }
        public Airplane(string brand, string regNumber, string color, int nrOfWheels, int antalMotor)
            : base(brand, regNumber, color, nrOfWheels)
        {
            AntalMotor = antalMotor;
        }
        public override string GetInfo()
        {
            return $"Airplane: {Brand}, RegNumber: {RegNumber}, Color: {Color}, nrOfWheels: {NrOfWheels}, antalMotor: {AntalMotor}";
        }
    }

    public class Motorcycle : Vehicle
    {
        //Average CC on bikes are about 400cc - 1000cc. Lightweight bikes feature 50cc - 350cc 
        public int CC { get; set; }
        public Motorcycle(string brand, string regNumber, string color, int nrOfWheels, int cc)
            : base(brand, regNumber, color, nrOfWheels)
        {
            CC = cc;
        }
        public override string GetInfo()
        {
            return $"Motorcycle: {Brand}, RegNumber: {RegNumber}, Color: {Color}, nrOfWheels: {NrOfWheels}, CC: {CC}";
        }
    }

    public class Båt : Vehicle 
    {
        public int Lenght {  get; set; }

        public Båt(string brand, string regNumber, string color, int nrOfWheels, int lenght)
            : base(brand, regNumber, color, nrOfWheels )
        {
            Lenght = lenght;
        }

        public override string GetInfo()
        {
            return $"Båt: {Brand}, RegNumber: {RegNumber}, Color: {Color}, nrOfWheels: {NrOfWheels}, Lenght: {Lenght} ";
        }
    }
}

