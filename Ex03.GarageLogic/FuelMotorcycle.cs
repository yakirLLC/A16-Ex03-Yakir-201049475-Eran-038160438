using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private Fuel m_FuelProperties;

        public FuelMotorcycle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_EngineCapacity, i_LicenseType)
        {
            m_FuelProperties = new Fuel(6, Fuel.eFuelType.Octan96);
        }

        public override string ToString()
        {
            return m_FuelProperties.ToString();
        }
    }
}
