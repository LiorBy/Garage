using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public Dictionary <string, VehicleInTheGarage> m_MyGarage;

        VehicleInTheGarage createdVehicle;
        Engine createdEngine;

        public Garage()
        {
            m_MyGarage = new Dictionary<string, VehicleInTheGarage>();
        }

        public void AddNewVehicle (string i_LicenseNumberForNewVehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            createdVehicle = new VehicleInTheGarage(i_OwnerName, i_OwnerPhoneNumber);
            m_MyGarage.Add(i_LicenseNumberForNewVehicle, createdVehicle);
        }

        public void AddNewCarCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_MaxEnergyLevel, float i_CurrentEnergyLevel, Vehicles.Car.eColorOfCar i_CarColor, int i_NumberOfDoors, Engine.eFuelType i_EnergyType)
        {
            m_MyGarage.TryGetValue(i_LicenseNumberForNewVehicle, out createdVehicle);
            if (i_EnergyType == Engine.eFuelType.Electricity)
            {
                createdEngine = new ElectricEngine(i_MaxEnergyLevel);
            }
            else
            {
                createdEngine = new FuelEngine(i_MaxEnergyLevel, i_EnergyType);
            }

            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle.m_Vehicle = new Vehicles.Car(i_VehicleModel, i_LicenseNumberForNewVehicle, i_NumberOfDoors, i_CarColor, createdEngine);
        }

        public void AddNewMotorcycleCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_MaxEnergyLevel, float i_CurrentEnergyLevel, Vehicles.Motorcycle.eLicenseType i_MotorcycleLicenseType, int i_EngineCapacitiyCC, Engine.eFuelType i_EnergyType)
        {
            m_MyGarage.TryGetValue(i_LicenseNumberForNewVehicle, out createdVehicle);
            if (i_EnergyType == Engine.eFuelType.Electricity)
            {
                createdEngine = new ElectricEngine(i_MaxEnergyLevel);
            }
            else
            {
                createdEngine = new FuelEngine(i_MaxEnergyLevel, i_EnergyType);
            }

            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle.m_Vehicle = new Vehicles.Motorcycle(i_VehicleModel, i_LicenseNumberForNewVehicle, i_MotorcycleLicenseType, i_EngineCapacitiyCC, createdEngine);
        }

        public void AddNewTruckCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_MaxEnergyLevel, float i_CurrentEnergyLevel, bool i_CoolerTrunk, float i_TrunkCapacity, Engine.eFuelType i_EnergyType)
        {
            m_MyGarage.TryGetValue(i_LicenseNumberForNewVehicle, out createdVehicle);
            if (i_EnergyType == Engine.eFuelType.Electricity)
            {
                createdEngine = new ElectricEngine(i_MaxEnergyLevel);
            }
            else
            {
                createdEngine = new FuelEngine(i_MaxEnergyLevel, i_EnergyType);
            }
            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle.m_Vehicle = new Vehicles.Truck(i_VehicleModel, i_LicenseNumberForNewVehicle, i_CoolerTrunk, i_TrunkCapacity, createdEngine);
        }

        public void RemoveVehicle(string i_LicenseNumberForNewVehicle)
        {
            m_MyGarage.Remove(i_LicenseNumberForNewVehicle);
        }

        public bool LicenseNumberExist(string i_LicenseNumberToSearch)
        {
            return (m_MyGarage.ContainsKey(i_LicenseNumberToSearch));
        }

        public bool IsItAFuelEngine(string i_LicenseNumberToSearch)
        {
            const bool v_ItIsAFuelEngine = true;
            VehicleInTheGarage m_GetEngineType;
            m_MyGarage.TryGetValue(i_LicenseNumberToSearch, out m_GetEngineType);
            object FuelEngineTypeIs = typeof(Ex03.GarageLogic.FuelEngine);
            createdEngine= (m_GetEngineType.m_Vehicle.VehicleEngine);
            object MyEngineTypeToCompare= createdEngine.GetType();
            if (FuelEngineTypeIs == MyEngineTypeToCompare)
            {
                return (v_ItIsAFuelEngine);
            }
            else
            {
                return (!v_ItIsAFuelEngine);
            }
        }

        public void FillingEnergyInTheVehicle (float i_LittersToFill, Ex03.GarageLogic.Engine.eFuelType i_FuelTypeToFill, string i_LicenseNumberOfTheVehicle)
        {
            VehicleInTheGarage vehicleToFill;
            m_MyGarage.TryGetValue(i_LicenseNumberOfTheVehicle, out vehicleToFill);
            vehicleToFill.m_Vehicle.FillingEnergyAction(i_LittersToFill, i_FuelTypeToFill);
        }

        public void UpdateVehicleStatus(string i_LicenseNumberForNewVehicle, char i_VehicleNewStatusAsChar)
        {
            VehicleInTheGarage.eVehicleStatus GetStatusFromChar;
            m_MyGarage.TryGetValue(i_LicenseNumberForNewVehicle, out createdVehicle);
            if (i_VehicleNewStatusAsChar == Constants.k_InProgress)
            {
                GetStatusFromChar = VehicleInTheGarage.eVehicleStatus.InProgress;
            }
            else if (i_VehicleNewStatusAsChar == Constants.k_WaitingToGetPayment)
            {
                GetStatusFromChar = VehicleInTheGarage.eVehicleStatus.WaitingToGetPayment;
            }
            else
            { //// (i_VehicleNewStatusAsChar == Constants.k_PaidAndReadyToGo)
                GetStatusFromChar = VehicleInTheGarage.eVehicleStatus.PaidAndReadyToGo;
            }

            createdVehicle.UpdateVehicleStatus = GetStatusFromChar;
        }

        public void InflateAirInWheels(string i_LicenseNumberOfTheVehicle)
        {
            VehicleInTheGarage vehicleToFill;
            m_MyGarage.TryGetValue(i_LicenseNumberOfTheVehicle, out vehicleToFill);
            vehicleToFill.m_Vehicle.InflateAllWheels();
        }
    }
}
