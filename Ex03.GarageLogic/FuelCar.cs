using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class FuelCar : Car
    {
        private Fuel m_FuelProperties;

        public FuelCar(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_CurrentEnergy)
            : base(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_NumOfDoors, i_Color)
        {
            if (i_CurrentEnergy <= 42)
            {
                m_FuelProperties = new Fuel(42, i_CurrentEnergy, Fuel.eFuelType.Octan98);
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 42f, 0.1f);
            }
        }

        public override string ToString()
        {
            return m_FuelProperties.ToString();
        }
    }
}
