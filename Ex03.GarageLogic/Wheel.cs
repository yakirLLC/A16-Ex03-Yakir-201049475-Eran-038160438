using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_Manufacturer;
        private readonly float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public void Inflate(float i_AirToInflate)
        {
            if (m_CurrentAirPressure + i_AirToInflate <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToInflate;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), m_MaxAirPressure, m_CurrentAirPressure);
            }
        }
    }
}
