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
        public const int k_CarFuelTankCapacity = 45;
        public const int k_TruckFuelTankCapacity = 115;
        //// BATTERY HOURS
        public const float k_MotorcycleBatteryMaxHours = 1.8F;
        public const float k_CarBatteryMaxHours = 3.2F;
        //////////////////////////////////////
        //// ENGINE TYPE
        public const int k_Fuel_Engine = 1;
        public const int k_Electric_Engine = 2;

        //// ERROR MESSEGAS REASONS
        public const string k_ToMuchPsiMessage = "PSI in the whell";
        public const string k_ToMuchFuelMessage = "Liters of fuel in the tank";
        public const string k_ToMuchHoursToChargeMessage = "Liters of fuel in the tank";
        public const string k_WrongFuelMessage = "Wrong type of fuel, please choose ";

        //// ACTIONS
        public const string k_FillingFuelAction = "fill";
        public const string k_ChargingAction = "charge";
        public const string k_InflateAction = "inflate";

        //// CALCULATE VALUES
        public const float k_MinutesPerHour = 60;
        public const float k_PercentToMultiply = 100;

        //// VEHICLE STATUS
        public const char k_InProgress = '1';
        public const char k_WaitingToGetPayment = '2';
        public const char k_PaidAndReadyToGo = '3';

    }
}
