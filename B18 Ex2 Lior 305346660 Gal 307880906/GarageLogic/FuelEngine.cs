using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine: Engine
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        private readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxEnergyCapacity, eFuelType i_FuelType) : base(i_MaxEnergyCapacity)
        {
            i_FuelType = r_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void VerifyFuelType(float i_EnergyToFill, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(Constants.k_WrongFuelMessege + i_FuelType);
            }
            else
            {
                FillEnergy(i_EnergyToFill);
            }
        }

        public override void FillEnergy(float i_EnergyToFill)
        {
            if (base.AvailableEnergyStatus < i_EnergyToFill)
            {
                throw new ValueOutOfRangeException(Constants.k_FillingFuelAction, i_EnergyToFill, base.AvailableEnergyStatus, Constants.k_ToMuchFuelMessege);
            }
            else
            {
                base.CurrentEnergyStatus += i_EnergyToFill;
            }
        }
    }
}
