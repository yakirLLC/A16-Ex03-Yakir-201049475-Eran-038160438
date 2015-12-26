using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class FuelCar : Car
    {
        private Fuel m_FuelProperties;

        public FuelCar(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_NumOfDoors, i_Color)
        {
            m_FuelProperties = new Fuel(42, Fuel.eFuelType.Octan98);
        }

        public override string ToString()
        {
            return m_FuelProperties.ToString();
        }
    }
}
