using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        //// ctor
        public ElectricEngine(float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity) {}

        //// methods
        public override void FillEnergy(float i_EnergyAmountToFill)
        { //// i_EnergyToFill is receiving in minutes
            float EnergyToFillInHours = minutesConvertToHours(i_EnergyAmountToFill);
            if (base.AvailableEnergyStatus < EnergyToFillInHours)
            {
                throw new ValueOutOfRangeException(Constants.k_ChargingAction, i_EnergyAmountToFill, base.AvailableEnergyStatus, Constants.k_ToMuchFuelMessage);
            }
            else
            { //// filling energy was a success!!
                base.CurrentEnergyStatus += i_EnergyAmountToFill;
            }
        }

        public float minutesConvertToHours (float i_Minutes)
        { //// this function convert minutes to hours in float values
            return ((i_Minutes * Constants.k_PercentToMultiply) / Constants.k_MinutesPerHour);
        }

        public override string EngineInformation()
        {
            string correntEnergyLevelMessage;
            string maxEnergyLevelMessage;
            string TypeEnergyMessage;
            correntEnergyLevelMessage = "Corrent Energy Level " + CurrentEnergyStatus.ToString() + " Hours";
            maxEnergyLevelMessage = "Max Energy Level " + MaxEnergyCapacity.ToString() + " Hours";
            TypeEnergyMessage = "Energy Engine ";
            string fuelEngineInformation = string.Format("{0}\n{1}\n{2}", correntEnergyLevelMessage, maxEnergyLevelMessage, TypeEnergyMessage);
            return fuelEngineInformation;
         
        }
    }

}
