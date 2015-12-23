using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eDoors m_NumOfDoors;

        private enum eColor
        {
            Red,
            Blue,
            Black,
            White
        }

        private enum eDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }
    }
}
