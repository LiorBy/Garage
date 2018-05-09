using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber; //// max 20 digits
        private float m_EnergyLevel;
        private List<Wheel> m_VehicleWheels = new List<Wheel>();

        public Vehicle(string i_ModerName, string i_LicenseNumber, int i_NumberOfWheels)
        {
            r_ModelName = i_ModerName;
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleWheels.Capacity = i_NumberOfWheels;
        }

        public abstract void CreateWheels(int i_NumberOfWheels);
       
        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public float EnergyLevel
        {
            get { return m_EnergyLevel; }

            set
            {
                m_EnergyLevel = value;
            }
        }
    }
}
