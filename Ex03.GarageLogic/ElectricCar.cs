using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private Electric m_ElectricProperties;

        public ElectricCar(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, eDoors i_NumOfDoors, eColor i_Color, float i_RemainingBatteryTime)
            : base(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_NumOfDoors, i_Color)
        {
            if (i_RemainingBatteryTime <= 2.8f)
            {
                m_ElectricProperties = new Electric(2.8f, i_RemainingBatteryTime);
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 2.8f, 0.1f);
            }
        }

        public override string ToString()
        {
            return m_ElectricProperties.ToString();
        }
    }
}
