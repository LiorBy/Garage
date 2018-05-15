using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_CoolerTrunk;
        private readonly float r_TrunkCapacity;

        public Truck(string i_ModelName, string i_LicenseNumber, bool i_CoolerTrunk, float i_TrunkCapacity, Engine i_TruckEngine, string i_WheelModel) :
            base(i_ModelName, i_LicenseNumber, Constants.k_TruckNumberOfWheels, i_TruckEngine, Constants.k_MaxTruckAirPressure,i_WheelModel)
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

        public override string UniqueVehicleInfo()
        {
            string coolerTrunkInfo;
            if(r_CoolerTrunk)
            {
                coolerTrunkInfo = "The Trunk Of The Truck is Cooler";
            }
            else
            {
                coolerTrunkInfo = "The Trunk Of The Truck isn't Cooler";
            }
            string trunkCapacityInfo = "Truck Trunk Capacity: " + r_TrunkCapacity.ToString();
            return string.Format("{0}\n{1}", coolerTrunkInfo, trunkCapacityInfo);
           
        }
    }
}



