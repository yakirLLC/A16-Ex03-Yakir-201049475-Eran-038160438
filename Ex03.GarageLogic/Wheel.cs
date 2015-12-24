using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_Manufacturer, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxAirPressure = m_CurrentAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToInflate)
        {
            if (m_CurrentAirPressure + i_AirToInflate <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToInflate;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), r_MaxAirPressure, m_CurrentAirPressure);
            }
        }
    }
}
