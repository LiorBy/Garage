using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    
    public abstract class Engine
    {
        private float r_CurrentEnergyStatus;
        private readonly float r_MaxEnergyCapacity;
        private float r_AvailableEnergyToFill;

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
                /////// this is the set for AvailableEnergyStatus
                r_AvailableEnergyToFill = r_MaxEnergyCapacity - r_CurrentEnergyStatus;
            }
        }

        public float AvailableEnergyStatus
        {
            get { return r_AvailableEnergyToFill; }
            ////set
            ////{
            ////    r_AvailableEnergyToFill = r_MaxEnergyCapacity - r_CurrentEnergyStatus;
            ////}
        }


        public float MaxEnergyCapacity
        {
            get { return r_MaxEnergyCapacity; }
        }

        public Type EngineType
        {
            get { return GetType(); }
        }

        ////public abstract void FillEnergy<T>(T i_detalis);
        public abstract void FillEnergy(float i_EnergyToFill);


    }

    
}
