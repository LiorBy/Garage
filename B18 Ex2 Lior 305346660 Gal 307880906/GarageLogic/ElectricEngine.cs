using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity) {}

        public override void FillEnergy(float i_EnergyToFill)
        {
            float EnergyToFillInHours = minutesConvertToHours(i_EnergyToFill);
            if (base.AvailableEnergyStatus < i_EnergyToFill)
            {
                throw new ValueOutOfRangeException(Constants.k_ChargingAction, i_EnergyToFill, base.AvailableEnergyStatus, Constants.k_ToMuchFuelMessege);
            }
            else
            {
                base.CurrentEnergyStatus += i_EnergyToFill;
            }
        }

        //// this function convert minutes to hours in float values
        public float minutesConvertToHours (float i_Minutes)
        {
            return ((i_Minutes * Constants.k_PercentToMultiply) / Constants.k_MinutesPerHour);
        }

    }

}
