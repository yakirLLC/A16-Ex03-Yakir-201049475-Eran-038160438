using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private Electric m_ElectricProperties;

        public ElectricMotorcycle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType, float i_RemainingBatteryTime)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_EngineCapacity, i_LicenseType)
        {
            m_ElectricProperties = new Electric(2.4f, i_RemainingBatteryTime);
        }

        public override string ToString()
        {
            return m_ElectricProperties.ToString();
        }
    }
}
