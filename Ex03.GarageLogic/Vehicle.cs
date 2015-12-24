using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_Id;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels)
        {
            r_ModelName = i_ModelName;
            r_Id = i_Id;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string Id
        {
            get
            {
                return r_Id;
            }
        }
    }
}
