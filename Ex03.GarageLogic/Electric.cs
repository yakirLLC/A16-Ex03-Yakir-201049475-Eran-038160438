using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : Engine
    {
        public Electric(float i_MaxBatteryTime, float i_RemainingBatteryTime)
            :base(i_MaxBatteryTime)
        {
            if (i_RemainingBatteryTime <= 2.8f)
            {
                this.CurrentEnergy = i_RemainingBatteryTime;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 2.8f, 0.1f);
            }
        }

        public void ChargeBattery(float i_HoursToAddToTheBattery)
        {
            if (this.CurrentEnergy + i_HoursToAddToTheBattery <= this.MaxEnergy)
            {
                this.CurrentEnergy += i_HoursToAddToTheBattery;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), this.MaxEnergy, this.CurrentEnergy);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
