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
        public override void FillEnergy(float i_EnergyToFill, eFuelType i_EnergyType = eFuelType.Electricity)
        { //// i_EnergyToFill is receiving in minutes
            float EnergyToFillInHours = minutesConvertToHours(i_EnergyToFill);
            if (base.AvailableEnergyStatus < EnergyToFillInHours)
            {
                throw new ValueOutOfRangeException(Constants.k_ChargingAction, i_EnergyToFill, base.AvailableEnergyStatus, Constants.k_ToMuchFuelMessage);
            }
            else
            { //// filling energy was a success!!
                base.CurrentEnergyStatus += i_EnergyToFill;
            }
        }

        public float minutesConvertToHours (float i_Minutes)
        { //// this function convert minutes to hours in float values
            return ((i_Minutes * Constants.k_PercentToMultiply) / Constants.k_MinutesPerHour);
        }
    }
}
