using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateNewVehicle
    {
        private static Engine createdEngine;
        private static Vehicle createdVehicle;

        public static void AddNewCarCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_MaxEnergyLevel, float i_CurrentEnergyLevel, Vehicles.Car.eColorOfCar i_CarColor, int i_NumberOfDoors, Engine.eFuelType i_EnergyType, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            
            if (i_EnergyType == Engine.eFuelType.Electricity)
            {
                createdEngine = new ElectricEngine(i_MaxEnergyLevel);
            }
            else
            {
                createdEngine = new FuelEngine(i_MaxEnergyLevel, i_EnergyType);
            }

            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle = new Vehicles.Car(i_VehicleModel, i_LicenseNumberForNewVehicle, i_NumberOfDoors, i_CarColor, createdEngine);
            Garage.AddNewVehicle(i_LicenseNumberForNewVehicle, i_OwnerName, i_OwnerPhoneNumber, createdVehicle);
        }

        public static void AddNewMotorcycleCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_MaxEnergyLevel, float i_CurrentEnergyLevel, Vehicles.Motorcycle.eLicenseType i_MotorcycleLicenseType, int i_EngineCapacitiyCC, Engine.eFuelType i_EnergyType, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            if (i_EnergyType == Engine.eFuelType.Electricity)
            {
                createdEngine = new ElectricEngine(i_MaxEnergyLevel);
            }
            else
            {
                createdEngine = new FuelEngine(i_MaxEnergyLevel, i_EnergyType);
            }

            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle = new Vehicles.Motorcycle(i_VehicleModel, i_LicenseNumberForNewVehicle, i_MotorcycleLicenseType, i_EngineCapacitiyCC, createdEngine);
            Garage.AddNewVehicle(i_LicenseNumberForNewVehicle, i_OwnerName, i_OwnerPhoneNumber, createdVehicle);
        }

        public static void AddNewTruckCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_MaxEnergyLevel, float i_CurrentEnergyLevel, bool i_CoolerTrunk, float i_TrunkCapacity, Engine.eFuelType i_EnergyType, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            if (i_EnergyType == Engine.eFuelType.Electricity)
            {
                createdEngine = new ElectricEngine(i_MaxEnergyLevel);
            }
            else
            {
                createdEngine = new FuelEngine(i_MaxEnergyLevel, i_EnergyType);
            }

            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle = new Vehicles.Truck(i_VehicleModel, i_LicenseNumberForNewVehicle, i_CoolerTrunk, i_TrunkCapacity, createdEngine);
            Garage.AddNewVehicle(i_LicenseNumberForNewVehicle, i_OwnerName, i_OwnerPhoneNumber, createdVehicle);
        }
    }
}
