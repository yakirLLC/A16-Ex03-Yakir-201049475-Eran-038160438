using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private Electric m_ElectricProperties;

        public ElectricMotorcycle(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType, float i_RemainingBatteryTime)
            : base(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_EngineCapacity, i_LicenseType)
        {
            if (i_RemainingBatteryTime <= 2.4f)
            {
                m_ElectricProperties = new Electric(2.4f, i_RemainingBatteryTime);
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 2.4f, 0.1f);
            }
        }

        public override string ToString()
        {
            return m_ElectricProperties.ToString();
        }
    }
}
