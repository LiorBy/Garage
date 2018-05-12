using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Constants
    {
        public const int k_MaxCharsLicenseNumber = 20;
        //// WHEELS NUMBER
        public const int k_MotorcycleNumberOfWheels = 2;
        public const int k_TruckNumberOfWheels = 12;
        public const int k_CarNumberOfWheels = 4;
        //// AIR PRUSSERE
        public const int k_MaxMotorcycleAirPressure = 30;
        public const int k_MaxCarAirPressure = 32;
        public const int k_MaxTruckAirPressure = 28;
        //// FUEL TANK
        public const int k_MotorcycleFuelTackCapacity = 6;
        public const int k_CarFuelTackCapacity = 45;
        public const int k_TruckFuelTankCapacity = 115;
        //// BATTERY HOURS
        public const float k_MotorcycleBatteryMaxHours = 1.8F;
        public const float k_CarBatteryMaxHours = 3.2F;
        //////////////////////////////////////
        //// ENGINE TYPE
        public const int k_Fuel_Engine = 1;
        public const int k_Electric_Engine = 2;

        //// ERROR MESSEGES REASONS
        public const string k_ToMuchPsiMessege = "PSI in the whell";
        public const string k_ToMuchFuelMessege = "Liters of fuel in the tank";
        public const string k_ToMuchHoursToChargeMessege = "Liters of fuel in the tank";
        public const string k_WrongFuelMessege = "Wrong type of fuel, please choose ";

        //// ACTIONS
        public const string k_FillingFuelAction = "fill";
        public const string k_ChargingAction = "charge";

        //// CALCULATE VALUES
        public const float k_MinutesPerHour = 60;
        public const float k_PercentToMultiply = 100;


    }
}
