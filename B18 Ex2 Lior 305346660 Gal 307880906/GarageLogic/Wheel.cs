using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ModelName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressure;

        public Wheel(string i_ModelName, float i_MaxAirPressure)
        {
            r_ModelName = i_ModelName;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public bool InflateWheel(float i_AirToFill)
        {
            bool pressureIsOK = true;

            if (r_MaxAirPressure - m_CurrentAirPressure < i_AirToFill)
            {
                pressureIsOK = false;
            }
            else
            {
                m_CurrentAirPressure += i_AirToFill;
            }
            return pressureIsOK;
        }



    }
}
