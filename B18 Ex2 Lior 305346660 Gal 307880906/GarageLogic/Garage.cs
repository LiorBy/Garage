using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private static Dictionary <string, VehicleInTheGarage> m_MyGarage = new Dictionary<string, VehicleInTheGarage>();

        public static void AddNewVehicle (string i_LicenseNumberForNewVehicle, string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_VehicleToReadyToInsert)
        {
            VehicleInTheGarage createdVehicle;
            createdVehicle = new VehicleInTheGarage(i_OwnerName, i_OwnerPhoneNumber, i_VehicleToReadyToInsert);
            m_MyGarage.Add(i_LicenseNumberForNewVehicle, createdVehicle);
        }

        public Dictionary<string, VehicleInTheGarage> AllVehiclesInTheGarage
        {
            get { return m_MyGarage; }
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
            Engine createdEngine;
            const bool v_ItIsAFuelEngine = true;
            VehicleInTheGarage m_GetEngineType;
            m_MyGarage.TryGetValue(i_LicenseNumberToSearch, out m_GetEngineType);
            object FuelEngineTypeIs = typeof(Ex03.GarageLogic.FuelEngine);
            createdEngine= (m_GetEngineType.Vehicle.VehicleEngine);
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

        public void FillingEnergyInTheVehicle (float i_LittersToFill, FuelEngine.eFuelType i_FuelTypeToFill, string i_LicenseNumberOfTheVehicle)
        {
            VehicleInTheGarage vehicleToFill;
            m_MyGarage.TryGetValue(i_LicenseNumberOfTheVehicle, out vehicleToFill);
            vehicleToFill.Vehicle.FillingEnergyAction(i_LittersToFill, i_FuelTypeToFill);
        }

        public void UpdateVehicleStatus(string i_LicenseNumberForNewVehicle, char i_VehicleNewStatusAsChar)
        {
            VehicleInTheGarage createdVehicle;
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

            createdVehicle.StatusInTheGarage = GetStatusFromChar;
        }

        public void InflateAirInWheels(string i_LicenseNumberOfTheVehicle)
        {
            VehicleInTheGarage vehicleToFill;
            m_MyGarage.TryGetValue(i_LicenseNumberOfTheVehicle, out vehicleToFill);
            vehicleToFill.Vehicle.InflateAllWheels();
        }
    }
}
