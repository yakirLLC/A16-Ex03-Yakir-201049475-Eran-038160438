using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Fuel
    {
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;
        private eFuelType m_Fuel;
        private enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public void FillTank()
        {
        }
    }
}
