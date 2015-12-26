using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private Electric m_ElectricProperties;

        public ElectricCar(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, eDoors i_NumOfDoors, eColor i_Color, float i_RemainingBatteryTime)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_NumOfDoors, i_Color)
        {
            m_ElectricProperties = new Electric(2.8f, i_RemainingBatteryTime);
        }

        public override string ToString()
        {
            return m_ElectricProperties.ToString();
        }
    }
}
