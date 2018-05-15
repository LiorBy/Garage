using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    
    public abstract class Engine
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler,
            Electricity
        }
        ////  members
        private float r_CurrentEnergyStatus = 0;
        private readonly float r_MaxEnergyCapacity = 0;
        private float r_AvailableEnergyToFill = 0;

        //// methods
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
        public abstract void FillEnergy(float i_EnergyToFill, eFuelType i_EnergyType);
    }   
}
