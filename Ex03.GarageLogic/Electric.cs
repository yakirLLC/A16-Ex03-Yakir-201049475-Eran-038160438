using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : Engine
    {
        public Electric(float i_MaxBatteryTime, float i_CurrentEnergy)
            :base(i_MaxBatteryTime, i_CurrentEnergy)
        { }

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
