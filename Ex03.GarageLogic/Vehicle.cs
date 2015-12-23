using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private readonly string m_ModelName;
        private readonly string m_Id;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels)
        {
            m_ModelName = i_ModelName;
            m_Id = i_Id;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
        }
    }
}
