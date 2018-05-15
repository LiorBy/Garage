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
        //// members
        private readonly eFuelType r_FuelType;

        //// ctor
        public FuelEngine(float i_MaxEnergyCapacity, eFuelType i_FuelType) : base(i_MaxEnergyCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void VerifyFuelType(float i_EnergyToFill, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(Constants.k_WrongFuelMessage + i_FuelType);
            }
            else
            {
                FillEnergy(i_EnergyToFill);
            }
        }

        public override string EngineInformation()
        {
            string correntEnergyLevelMessage;
            string maxEnergyLevelMessage;
            string TypeEnergyMessage;
            correntEnergyLevelMessage = "Corrent Energy Level " + CurrentEnergyStatus.ToString() + " Liters";
            maxEnergyLevelMessage = "Max Energy Level " + MaxEnergyCapacity.ToString() + " Liters";
            TypeEnergyMessage = "Fuel Type: " + r_FuelType.ToString();
            string fuelEngineInformation = string.Format("{0}\n{1}\n{2}", correntEnergyLevelMessage, maxEnergyLevelMessage, TypeEnergyMessage);
            return fuelEngineInformation;
        }
        ////public override void FillEnergy(float i_EnergyToFill)
        ////{
        ////    if ((AvailableEnergyStatus < i_EnergyToFill) || (i_EnergyToFill < 0))
        ////    {
        ////        throw new ValueOutOfRangeException(Constants.k_FillingFuelAction, i_EnergyToFill, AvailableEnergyStatus, Constants.k_ToMuchFuelMessage);
        ////    }
        ////    else
        ////    { //// filling energy was a success!!
        ////        base.CurrentEnergyStatus += i_EnergyToFill;
        ////    }
        ////}

        public override void FillEnergy(float i_EnergyAmountToFill)
        {           
            if ((base.AvailableEnergyStatus < i_EnergyAmountToFill) || (i_EnergyAmountToFill < 0))
            {
                throw new ValueOutOfRangeException(Constants.k_FillingFuelAction, i_EnergyAmountToFill, base.AvailableEnergyStatus, Constants.k_ToMuchFuelMessage);
            }
            else
            { //// filling energy was a success!!
                base.CurrentEnergyStatus += i_EnergyAmountToFill;
            }
        }
    }
}
