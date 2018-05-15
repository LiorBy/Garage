using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        //// members
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;                                   //// max 20 digits
        private float m_EnergyPercent;
        private List<Wheel> m_VehicleWheels = new List<Wheel>();
        private Engine m_EngineOfTheVehicle;

        //// methods
        public Vehicle(string i_ModelName, string i_LicenseNumber, int i_NumberOfWheels, Engine i_Engine, float i_MaxAirPressure, string i_WheelModel)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleWheels.Capacity = i_NumberOfWheels;
            m_EngineOfTheVehicle = i_Engine;
            EnergyLevel = i_Engine.CurrentEnergyStatus;
            CreateWheels(i_MaxAirPressure, i_WheelModel);
        }

        //// Create wheels with random models :-)
        private void CreateWheels(float i_MaxAirPressure, string i_WheelModel)
        {
           
            foreach (Wheel wheel in m_VehicleWheels)
            {
                m_VehicleWheels.Add(new Wheel(i_WheelModel, i_MaxAirPressure));
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

        public void InflateAllWheels()
        {
            foreach (Wheel wheel in m_VehicleWheels)
            {
                float MissingPSIToInflate = wheel.AvailableAirPressure;
                wheel.InflateWheel(MissingPSIToInflate);
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

        private float EnergyLevel
        {
            get { return m_EnergyPercent; }
            set
            {
                m_EnergyPercent = (value * Constants.k_PercentToMultiply / m_EngineOfTheVehicle.MaxEnergyCapacity);
            }
        }

        public Engine VehicleEngine
        {
            get { return m_EngineOfTheVehicle; }
        }

        //public void FillingEnergyAction (float i_AmountOfEnergyToFill, Engine.eFuelType i_FuelTypeToFill)
        //{
        //    m_EngineOfTheVehicle.FillEnergy(i_AmountOfEnergyToFill, i_FuelTypeToFill);
        //}
    }
}
