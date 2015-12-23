using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;
        private enum eLicenseType
        {
            A,
            A1,
            A4,
            C
        }
    }
}
