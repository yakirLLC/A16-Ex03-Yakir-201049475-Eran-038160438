using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private Fuel m_FuelProperties;

        public FuelMotorcycle(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, ref List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType, float i_CurrentEnergy)
            : base(i_ModelName, i_Id, i_PercentageEnergyLeft, ref i_Wheels, i_EngineCapacity, i_LicenseType)
        {
            if (i_CurrentEnergy <= 6)
            {
                m_FuelProperties = new Fuel(6, i_CurrentEnergy, Fuel.eFuelType.Octan96);
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 6f, 0.1f);
            }
        }

        public override string ToString()
        {
            return m_FuelProperties.ToString();
        }
    }
}
