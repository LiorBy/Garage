using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private static readonly List<string> r_ListOfWheelsModels =
         new List<string>(new[]
        {
           "Alessio (wheels)",
           "American Racing",
           "BBS Kraftfahrzeugtechnik",
           "Borrani",
           "Campagnolo",
           "Dayton Wire Wheels",
           "DUB Zane Edition",
           "Fondmetal",
           "Forgiato Wheels",
           "Fulcrum Wheels",
           "HRE Performance Wheels",
           "Impul",
           "Iochpe-Maxion",
           "Mercedes-AMG",
           "OZ Group",
           "Rays Engineering",
           "Ronal",
           "Rudge-Whitworth",
           "Topy Industries",
           "Vogue Tyre",
           "Weds",
           "WORK Wheels"
        });

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

        public static List<string> WheelsModeList
        {
            get { return r_ListOfWheelsModels; }
        }


    }
}
