using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTrack : Track
    {
        private Fuel m_FuelProperties;

        public FuelTrack(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_MaxCarringWeight, i_CarriesDangerousMaterials)
        {
            m_FuelProperties = new Fuel(160, Fuel.eFuelType.Soler);
        }

        public override string ToString()
        {
            return m_FuelProperties.ToString();
        }
    }
}
