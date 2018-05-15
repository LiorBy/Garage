using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private readonly bool r_CoolerTrunk;
        private readonly float r_TrunkCapacity;

        public Truck(string i_ModelName, string i_LicenseNumber, bool i_CoolerTrunk, float i_TrunkCapacity, Engine i_TruckEngine) :
            base(i_ModelName, i_LicenseNumber, Constants.k_TruckNumberOfWheels, i_TruckEngine, Constants.k_MaxTruckAirPressure)
        {
            r_CoolerTrunk = i_CoolerTrunk;
            r_TrunkCapacity = i_TrunkCapacity;
        }
        
        public bool CoolerTrunk
        {
            get { return r_CoolerTrunk; }
        }

        public float TrunkCapacity
        {
            get { return r_TrunkCapacity; }
        }
    }
}



