using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private readonly int r_EngineCapacity;
        private readonly eLicenseType r_LicenseType;

        public enum eLicenseType
        {
            A = 1,
            A1,
            A4,
            C
        }

        protected Motorcycle(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType)
            : base(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels)
        {
            this.Wheels = i_Wheels;
            r_EngineCapacity = i_EngineCapacity;
            r_LicenseType = i_LicenseType;
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.Append(base.ToString());
            details.Append(string.Format(@"Engine Capacity: {0}
                                         License Type: {1}
                                         ", r_EngineCapacity, (eLicenseType)r_LicenseType));

            return details.ToString();
        }
    }
}
