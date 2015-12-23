using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Track : Vehicle
    {
        private readonly float m_MaxCarringWeight;
        private bool m_CarriesDangerousMaterials;

        public Track(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels)
        {
            if (i_Wheels.Count == 4)
            {
                m_MaxCarringWeight = i_MaxCarringWeight;
                m_CarriesDangerousMaterials = i_CarriesDangerousMaterials;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 4, 4);
            }
        }
    }
}
