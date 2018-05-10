using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEngineType
    {
        // first option
        ////fuelEngine = Constants.Fuel_Engine,
        ////electricEngine = Constants.Electric_Engine
        // second option
        //// FUEL_ENGINE = 1,
        //// ELECTRIC_ENGINE = 2
        // third option
        FUEL_ENGINE,
        ELECTRIC_ENGINE
    }

    public abstract class Engine
    {
        //// ////////////////
        ////   //////////////////////////////// UPDATE THE FIRST LETTER OF THE PARAMETERS
        private readonly eEngineType r_EngineType;
        private float r_CurrentEnergyStatus = 0;
        private readonly float r_MaxEnergyCapacity;

        public Engine(eEngineType i_EngineType, float i__MaxEnergyCapacity)
        {
            r_EngineType = i_EngineType;
            r_MaxEnergyCapacity = i__MaxEnergyCapacity;
        }

        public eEngineType WhatIsTheEngineType
        {
             get { return r_EngineType; }
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
