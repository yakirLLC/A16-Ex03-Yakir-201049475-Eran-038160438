using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class FuelCar : Car
    {
        private Fuel m_FuelProperties;

        public FuelCar(string i_ModelName, string i_Id, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_CurrentEnergy)
            : base(i_ModelName, i_Id, i_Wheels, i_NumOfDoors, i_Color)
        {
            int maxEnergy = 42;

            if (i_CurrentEnergy <= maxEnergy)
            {
                this.PercentageEnergyLeft = i_CurrentEnergy * 100 / maxEnergy;
                m_FuelProperties = new Fuel(maxEnergy, i_CurrentEnergy, Fuel.eFuelType.Octan98);
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), maxEnergy, 0.1f);
            }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.AppendLine(base.ToString());
            details.Append(m_FuelProperties.ToString());

            return details.ToString();
        }
    }
}
