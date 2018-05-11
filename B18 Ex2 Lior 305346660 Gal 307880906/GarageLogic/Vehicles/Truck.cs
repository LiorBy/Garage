using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_CoolerTrunk;
        private readonly float r_TrunkCapacity = Constants.TruckFuelTankCapacity;

        public Truck(string i_ModelName, string i_LicenseNumber,bool i_CoolerTruck) :
            base(i_ModelName, i_LicenseNumber,Constants.TruckNumberOfWheels)
        {
            i_CoolerTruck = r_CoolerTrunk;
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
