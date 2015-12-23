using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private string m_Id;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;
        private CustomerInfo m_Customer;
    }
}
