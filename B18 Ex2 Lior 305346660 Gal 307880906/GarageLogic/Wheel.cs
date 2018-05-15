using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
namespace Ex03.GarageLogic
{
    public class Wheel
    { 

        //// members
        private readonly string r_ModelName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressure;
        private float m_AvailableAirPressure = 0;

        //// methods
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
                m_AvailableAirPressure = r_MaxAirPressure - m_CurrentAirPressure;
            }
        }

        public float AvailableAirPressure
        {
            get { return m_AvailableAirPressure; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void InflateWheel(float i_AirToFill)
        {
            if ((m_AvailableAirPressure < i_AirToFill) || (i_AirToFill <= 0))
            {
                throw new ValueOutOfRangeException(Constants.k_InflateAction, i_AirToFill, m_AvailableAirPressure, Constants.k_ToMuchPsiMessage);
            }
            else
            {
                m_CurrentAirPressure += i_AirToFill;
            }
        }

        


    }
}
