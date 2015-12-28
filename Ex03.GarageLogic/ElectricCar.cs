using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private Electric m_ElectricProperties;

        public ElectricCar(string i_ModelName, string i_Id, List<Wheel> i_Wheels, eDoors i_NumOfDoors, eColor i_Color, float i_RemainingBatteryTime)
            : base(i_ModelName, i_Id, i_Wheels, i_NumOfDoors, i_Color)
        {
            float maxEnergy = 2.8f;

            if (i_RemainingBatteryTime <= maxEnergy)
            {
                this.PercentageEnergyLeft = i_RemainingBatteryTime * 100 / maxEnergy;
                m_ElectricProperties = new Electric(maxEnergy, i_RemainingBatteryTime);
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), maxEnergy, 0.1f);
            }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.AppendLine(base.ToString());
            details.Append(m_ElectricProperties.ToString());

            return details.ToString();
        }
    }
}
