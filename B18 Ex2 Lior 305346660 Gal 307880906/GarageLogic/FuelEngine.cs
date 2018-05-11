using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine: Engine
    {
        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
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

      

    }
}
