using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel
    {
        private readonly float r_MaxFuelAmount;
        private float m_CurrentFuelAmount;
        private eFuelType m_Fuel;

        internal enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public Fuel(float i_MaxFuelAmount, eFuelType i_FuelType)
        {
            m_CurrentFuelAmount = r_MaxFuelAmount = i_MaxFuelAmount;
            m_Fuel = i_FuelType;
        }

        public void FillTank(float i_FuelToFill, eFuelType i_FuelType)
        {
            if (i_FuelType.Equals(m_Fuel))
            {
                if (m_CurrentFuelAmount + i_FuelToFill <= r_MaxFuelAmount)
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
                throw new ValueOutOfRangeException(new Exception(), r_MaxFuelAmount, m_CurrentFuelAmount);
            }
        }
    }
}
