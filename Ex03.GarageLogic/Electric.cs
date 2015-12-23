using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric
    {
        private float m_RemainingBatteryTime;
        private readonly float m_MaxBatteryTime;

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
