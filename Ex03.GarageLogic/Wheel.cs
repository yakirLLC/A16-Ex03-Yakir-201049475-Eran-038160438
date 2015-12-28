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

        public enum eMaxAirPressure
        {
            Car = 29,
            Motorcycle = 32,
            Track = 34
        }

        public Wheel(string i_Manufacturer, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            if (i_CurrentAirPressure <= i_MaxAirPressure)
            {
                r_Manufacturer = i_Manufacturer;
                m_MaxAirPressure = i_MaxAirPressure;
                m_CurrentAirPressure = i_CurrentAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception, i_MaxAirPressure, 0.1f);
            }
        }

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
