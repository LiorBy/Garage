using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Ex03.GarageLogic.Vehicles
{
    public class Car : Vehicle
    {
       public enum eColorOfCar
        {
            Grey,
            Blue,
            White,
            Black
        }

        private readonly eColorOfCar r_ColorOfTheCar;
        private readonly int r_NumberOfDoors; //// Can be 2, 3, 4 or 5...
        
        public Car(string i_ModelName, string i_LicenseNumber, int i_NumberOfDoors, eColorOfCar i_ColorOfTheCar, Engine i_CarEngine) : 
            base(i_ModelName, i_LicenseNumber, Constants.CarNumberOfWheels, i_CarEngine, Constants.MaxCarAirPressure) 
        {
            r_NumberOfDoors = i_NumberOfDoors;
            i_ColorOfTheCar = r_ColorOfTheCar;
        }

        public int NumberOfDoors
        {
            get { return r_NumberOfDoors; }
        }

        public eColorOfCar ColorOfTheCar
        {
            get { return r_ColorOfTheCar; }
        }
    }
}
