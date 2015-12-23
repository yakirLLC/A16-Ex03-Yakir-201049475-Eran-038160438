using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        public void Inflate(float i_AirToInflate)
        {
            try
            {
                if (m_CurrentAirPressure + i_AirToInflate <= m_MaxAirPressure)
                {
                    m_CurrentAirPressure += i_AirToInflate;
                }
                else
                {
                    throw;
                }
            }
            catch
            {
            }
        }
    }
}
