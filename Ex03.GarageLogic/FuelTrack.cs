using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTrack : Track
    {
        private Fuel m_FuelProperties;

        public FuelTrack(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials, float i_CurrentEnergy)
            : base(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_MaxCarringWeight, i_CarriesDangerousMaterials)
        {
            if (i_CurrentEnergy <= 160)
            {
                m_FuelProperties = new Fuel(160, i_CurrentEnergy, Fuel.eFuelType.Soler);
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 160f, 0.1f);
            }
        }

        public override string ToString()
        {
            return m_FuelProperties.ToString();
        }
    }
}
