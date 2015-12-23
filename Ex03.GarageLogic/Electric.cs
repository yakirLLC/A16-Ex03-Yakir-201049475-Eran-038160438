using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric
    {
        private readonly float m_MaxBatteryTime;
        private float m_RemainingBatteryTime;

        public void ChargeBattery(float i_HoursToAddToTheBattery)
        {
            if (m_RemainingBatteryTime + i_HoursToAddToTheBattery <= m_MaxBatteryTime)
            {
                m_RemainingBatteryTime += i_HoursToAddToTheBattery;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), m_MaxBatteryTime, m_RemainingBatteryTime);
            }
        }
    }
}
