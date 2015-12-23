using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel
    {
        private readonly float m_MaxFuelAmount;
        private float m_CurrentFuelAmount;
        private eFuelType m_Fuel;

        private enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public Fuel(float i_MaxFuelAmount, eFuelType i_FuelType)
        {
            m_CurrentFuelAmount = m_MaxFuelAmount = i_MaxFuelAmount;
            m_Fuel = i_FuelType;
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
