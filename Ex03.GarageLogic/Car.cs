using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private readonly eDoors r_NumOfDoors;
        private eColor m_Color;

        public enum eColor
        {
            Red,
            Blue,
            Black,
            White
        }

        public enum eDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        protected Car(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, eDoors i_NumOfDoors, eColor i_Color)
            : base(i_ModelName, i_Id, i_PercentageEnergyLeft, ref i_Wheels)
        {
            i_Wheels = new List<Wheel>(4);
            foreach (Wheel wheel in i_Wheels)
            {
                wheel.MaxAirPressure = 29;
            }

            r_NumOfDoors = i_NumOfDoors;
            m_Color = i_Color;
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.Append(base.ToString());
            details.Append(string.Format(@"Amount of doors: {0}
                                         Color: {1}
                                         ", (eDoors)r_NumOfDoors, (eColor)m_Color));

            return details.ToString();
        }
    }
}
