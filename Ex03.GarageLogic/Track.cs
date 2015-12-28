using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Track : Vehicle
    {
        private readonly float r_MaxCarringWeight;
        private bool m_CarriesDangerousMaterials;

        protected Track(string i_ModelName, string i_Id, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials)
            : base(i_ModelName, i_Id, i_Wheels)
        {
            r_MaxCarringWeight = i_MaxCarringWeight;
            m_CarriesDangerousMaterials = i_CarriesDangerousMaterials;
            foreach (Wheel wheel in i_Wheels)
            {
                wheel.MaxAirPressure = 34;
            }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.AppendLine(base.ToString());
            details.AppendLine(string.Format("Maximum Carring Weight: {0}", r_MaxCarringWeight));
            details.Append(string.Format("Is Carring Dangerous Materials: {0}", m_CarriesDangerousMaterials.ToString()));

            return details.ToString();
        }
    }
}
