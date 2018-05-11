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

        public static List<string> WheelsModeList
        {
            get { return r_ListOfWheelsModels; }
        }


    }
}
