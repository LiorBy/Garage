using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    
    public abstract class Engine
    {
        private float r_CurrentEnergyStatus ;
        private readonly float r_MaxEnergyCapacity;

        public Engine(float i_MaxEnergyCapacity)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
        }

        public float CurrentEnergyStatus
        {
            get { return r_CurrentEnergyStatus; }
            set
            {
                r_CurrentEnergyStatus = value;
            }
        }

        public float MaxEnergyCapacity
        {
            get { return r_MaxEnergyCapacity; }
        }




    }

    
}
