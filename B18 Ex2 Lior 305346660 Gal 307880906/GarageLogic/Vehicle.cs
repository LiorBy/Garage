using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
       
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber; //// max 20 digits
        private float m_EnergyLevel;
        private List<Wheel> m_VehicleWheels = new List<Wheel>();
        private Engine m_EngineOfTheCar;
        public Vehicle(string i_ModelName, string i_LicenseNumber, int i_NumberOfWheels)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleWheels.Capacity = i_NumberOfWheels;
            CreateWheels(i_NumberOfWheels);
        }

        private void CreateWheels(int i_NumberOfWheels)
        {
            Random rand = new Random();
            foreach (Wheel wheel in m_VehicleWheels)
            {
                int randomNumber = rand.Next(Wheel.WheelsModeList.Count);
                string randomModelWheel = Wheel.WheelsModeList[randomNumber];
                m_VehicleWheels.Add(new Wheel(randomModelWheel, Constants.MaxCarAirPressure));
            }
        }
        public List<Wheel> VehicleWheelsList
        {
            get { return m_VehicleWheels; }
            set
            {
                m_VehicleWheels = value;
            }
        }
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
