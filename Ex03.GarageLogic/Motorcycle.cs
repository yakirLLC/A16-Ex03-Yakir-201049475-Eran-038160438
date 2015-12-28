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

        protected Motorcycle(string i_ModelName, string i_Id, List<Wheel> i_Wheels, int i_EngineCapacity, eLicenseType i_LicenseType)
            : base(i_ModelName, i_Id, i_Wheels)
        {
            if (i_Wheels.Count == 2)
            {
                if (i_Wheels[0].MaxAirPressure == 32)
                {
                    this.Wheels = i_Wheels;
                    r_EngineCapacity = i_EngineCapacity;
                    r_LicenseType = i_LicenseType;
                }
                else
                {
                    throw new ValueOutOfRangeException(new Exception(), 32f, 32f);
                }
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 2f, 2f);
            }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.AppendLine(base.ToString());
            details.AppendLine(string.Format("Engine Capacity: {0}", r_EngineCapacity));
            details.Append(string.Format("License Type: {0}", ((eLicenseType)r_LicenseType)).ToString());

            return details.ToString();
        }
    }
}
