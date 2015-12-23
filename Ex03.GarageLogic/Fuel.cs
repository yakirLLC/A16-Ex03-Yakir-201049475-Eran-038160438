using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Fuel
    {
        private float m_CurrentFuelAmount;
        private readonly float m_MaxFuelAmount;
        private eFuelType m_Fuel;
        private enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public void FillTank(float i_FuelToFill, eFuelType i_FuelType)
        {
            if (i_FuelType.Equals(m_Fuel))
            {
                if (m_CurrentFuelAmount + i_FuelToFill <= m_MaxFuelAmount)
                {
                    m_CurrentFuelAmount += i_FuelToFill;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), m_MaxFuelAmount, m_CurrentFuelAmount);
            }
        }
    }
}
