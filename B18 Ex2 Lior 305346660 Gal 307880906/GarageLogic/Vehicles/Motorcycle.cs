using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            B1,
            B2  
        }

        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, eLicenseType i_LicenseType, int i_EngineCapacity, Engine i_MotorcycleEngine) :
            base(i_ModelName, i_LicenseNumber, Constants.MotorcycleNumberOfWheels, i_MotorcycleEngine, Constants.MaxMotorcycleAirPressure)
        {
            i_LicenseType = r_LicenseType;
            i_EngineCapacity = r_EngineCapacity;
        }

        public eLicenseType LicenseType
        {
            get { return r_LicenseType; }
        }

        public int EngineCapacity
        {
            get { return r_EngineCapacity; }
        }






    }
}
