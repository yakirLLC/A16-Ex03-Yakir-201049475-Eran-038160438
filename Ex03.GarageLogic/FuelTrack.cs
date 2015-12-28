using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTrack : Track
    {
        private Fuel m_FuelProperties;

        public FuelTrack(string i_ModelName, string i_Id, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials, float i_CurrentEnergy)
            : base(i_ModelName, i_Id, i_Wheels, i_MaxCarringWeight, i_CarriesDangerousMaterials)
        {
            int maxEnergy = 160;

            if (i_CurrentEnergy <= maxEnergy)
            {
                m_FuelProperties = new Fuel(maxEnergy, i_CurrentEnergy, Fuel.eFuelType.Soler);
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
