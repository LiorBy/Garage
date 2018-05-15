using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Ex03.GarageLogic
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
        
        public Car(string i_ModelName, string i_LicenseNumber, int i_NumberOfDoors, eColorOfCar i_ColorOfTheCar, Engine i_CarEngine,string i_WheelModel) : 
            base(i_ModelName, i_LicenseNumber, Constants.k_CarNumberOfWheels, i_CarEngine, Constants.k_MaxCarAirPressure, i_WheelModel) 
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
