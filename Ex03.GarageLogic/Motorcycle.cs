using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private readonly int r_EngineCapacity;
        private readonly eLicenseType r_LicenseType;

        internal enum eLicenseType
        {
            A,
            A1,
            A4,
            C
        }

        public Motorcycle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels)
        {
            if (i_Wheels.Count == 2 || i_Wheels.Count == 3)
            {
                r_EngineCapacity = i_EngineCapacity;
                r_LicenseType = i_LicenseType;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 3, 2);
            }
        }
    }
}
