using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInTheGarage
    {
        public enum eVehicleStatus
        {
            InProgress,
            WaitingToGetPayment,
            PaidAndReadyToGo,
            AllStatus
                ///////////////////////////////////////////////////
        }

        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        public Vehicle m_Vehicle;
        eVehicleStatus m_VehicleStatusInTheGarage;

        public VehicleInTheGarage(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatusInTheGarage = eVehicleStatus.InProgress;
        }

        public string SearchLicenseNumber
        {
            get { return m_Vehicle.LicenseNumber; }
        }

        public string OwnerName
        {
            get { return r_OwnerName; }      
        }

        public eVehicleStatus UpdateVehicleStatus
        {
            get { return m_VehicleStatusInTheGarage; }
            set { m_VehicleStatusInTheGarage = value; }
        }

        ////public eVehicleStatus ConvertVehicleStatusFromChar(char i_VehicleNewStatusAsChar)
        ////{
        ////    if (i_VehicleNewStatusAsChar == Constants.k_InProgress)
        ////    {
                
        ////    }
        ////    else if (i_VehicleNewStatusAsChar == Constants.k_WaitingToGetPayment)
        ////    {
        ////    }
        ////    else
        ////    { //// (i_VehicleNewStatusAsChar == Constants.k_PaidAndReadyToGo)

        ////    }
        ////}

    }
}
