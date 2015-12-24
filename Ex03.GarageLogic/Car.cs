using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private readonly eDoors r_NumOfDoors;
        private eColor m_Color;

        internal enum eColor
        {
            Red,
            Blue,
            Black,
            White
        }

        internal enum eDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        protected Car(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, eDoors i_NumOfDoors, eColor i_Color)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels)
        {
            if (i_Wheels.Count == 4)
            {
                r_NumOfDoors = i_NumOfDoors;
                m_Color = i_Color;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 4, 4);
            }
        }
    }
}
