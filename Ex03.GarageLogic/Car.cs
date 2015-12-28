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
            Red = 1,
            Blue,
            Black,
            White
        }

        public enum eDoors
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        protected Car(string i_ModelName, string i_Id, List<Wheel> i_Wheels, eDoors i_NumOfDoors, eColor i_Color)
            : base(i_ModelName, i_Id, i_Wheels)
        {
            this.Wheels = i_Wheels;
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

            details.AppendLine(base.ToString());
            details.AppendLine(string.Format("Amount of doors: {0}", ((eDoors)r_NumOfDoors).ToString()));
            details.Append(string.Format("Color: {0}", ((eColor)m_Color).ToString()));

            return details.ToString();
        }
    }
}
