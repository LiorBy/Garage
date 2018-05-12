using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private readonly float r_TriedToFill;
        ////private readonly float r_MinValue;
        private readonly float r_AvailableCapaxity;


        // maybe need to return the inner exception////////////
        ////   public ValueOutOfRangeException(
        ////   Exception i_InnerException,
        public ValueOutOfRangeException(
            string i_ActionToDo,
            float i_TriedToFill,
            float i_AvailableCapacity,
            string i_WhatWeTriedToFill)
            : base (
                  string.Format("An error occured while trying to {0} {1} {2}, please try to fill 0 - {3} ",
                      i_ActionToDo, i_TriedToFill, i_WhatWeTriedToFill, i_AvailableCapacity))
        {
            r_TriedToFill = i_TriedToFill;
            r_AvailableCapaxity = i_AvailableCapacity;
        }
    }
}
