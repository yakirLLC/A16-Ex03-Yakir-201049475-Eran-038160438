using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public Wheel(string i_Manufacturer, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_MaxAirPressure = m_CurrentAirPressure = i_MaxAirPressure;
        }

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

        public void InflateToMax()
        {
            if (m_CurrentAirPressure < m_MaxAirPressure)
            {
                m_CurrentAirPressure = m_MaxAirPressure;
            }
        }
    }
}
