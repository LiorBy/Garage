using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateNewVehicle
    {
        private static Engine createdEngine;
        private static Vehicle createdVehicle;

        public static void AddNewCarCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_CurrentEnergyLevel, Car.eColorOfCar i_CarColor, int i_NumberOfDoors, char i_EnergyType, string i_OwnerName, string i_OwnerPhoneNumber, string i_WheelsModel, float i_CurrentWheelsPSI)
        {
            
            if (i_EnergyType == Constants.k_Electric)
            {
                createdEngine = new ElectricEngine(Constants.k_CarBatteryMaxHours);
            }
            else
            {
                createdEngine = new FuelEngine(Constants.k_CarFuelTankCapacity, FuelEngine.eFuelType.Octan98);
            }

            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle = new Car(i_VehicleModel, i_LicenseNumberForNewVehicle, i_NumberOfDoors, i_CarColor, createdEngine, i_WheelsModel);
            Garage.AddNewVehicle(i_LicenseNumberForNewVehicle, i_OwnerName, i_OwnerPhoneNumber, createdVehicle);
        }

        public static void AddNewMotorcycleCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_CurrentEnergyLevel, Motorcycle.eLicenseType i_MotorcycleLicenseType, int i_EngineCapacitiyCC, char i_EnergyType, string i_OwnerName, string i_OwnerPhoneNumber, string i_WheelsModel, float i_CurrentWheelsPSI)
        {
            if (i_EnergyType == Constants.k_Electric)
            {
                createdEngine = new ElectricEngine(Constants.k_MotorcycleBatteryMaxHours);
            }
            else
            {
                createdEngine = new FuelEngine(Constants.k_MotorcycleFuelTackCapacity, FuelEngine.eFuelType.Octan96);
            }

            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle = new Motorcycle(i_VehicleModel, i_LicenseNumberForNewVehicle, i_MotorcycleLicenseType, i_EngineCapacitiyCC, createdEngine, i_WheelsModel);
            Garage.AddNewVehicle(i_LicenseNumberForNewVehicle, i_OwnerName, i_OwnerPhoneNumber, createdVehicle);
        }

        public static void AddNewTruckCompleteInformation(string i_LicenseNumberForNewVehicle, string i_VehicleModel, float i_CurrentEnergyLevel, bool i_CoolerTrunk, float i_TrunkCapacity, string i_OwnerName, string i_OwnerPhoneNumber, string i_WheelsModel, float i_CurrentWheelsPSI)
        {
            createdEngine = new FuelEngine(Constants.k_TruckFuelTankCapacity, FuelEngine.eFuelType.Soler);          
            createdEngine.CurrentEnergyStatus = i_CurrentEnergyLevel;
            createdVehicle = new Truck(i_VehicleModel, i_LicenseNumberForNewVehicle, i_CoolerTrunk, i_TrunkCapacity, createdEngine, i_WheelsModel);
            Garage.AddNewVehicle(i_LicenseNumberForNewVehicle, i_OwnerName, i_OwnerPhoneNumber, createdVehicle);
        }
    }
}
