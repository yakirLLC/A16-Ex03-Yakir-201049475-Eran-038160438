using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private Fuel m_FuelProperties;

        public FuelMotorcycle(string i_ModelName, string i_Id, List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType, float i_CurrentEnergy)
            : base(i_ModelName, i_Id, i_Wheels, i_EngineCapacity, i_LicenseType)
        {
            int maxEnergy = 6;

            if (i_CurrentEnergy <= maxEnergy)
            {
                this.PercentageEnergyLeft = i_CurrentEnergy * 100 / maxEnergy;
                m_FuelProperties = new Fuel(maxEnergy, i_CurrentEnergy, Fuel.eFuelType.Octan96);
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
            details.Append(m_FuelProperties.ToString());

            return details.ToString();
        }
    }
}
