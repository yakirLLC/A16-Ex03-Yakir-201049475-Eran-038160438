using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric
    {
        private readonly float r_MaxBatteryTime;
        private float m_RemainingBatteryTime;

        public Electric(float i_MaxBatteryTime, float i_RemainingBatteryTime)
        {
            r_MaxBatteryTime = i_MaxBatteryTime;
            m_RemainingBatteryTime = i_RemainingBatteryTime;
        }

        public void ChargeBattery(float i_HoursToAddToTheBattery)
        {
            if (m_RemainingBatteryTime + i_HoursToAddToTheBattery <= r_MaxBatteryTime)
            {
                m_RemainingBatteryTime += i_HoursToAddToTheBattery;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), r_MaxBatteryTime, m_RemainingBatteryTime);
            }
        }
    }
}
