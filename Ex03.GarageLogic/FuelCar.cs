using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private Fuel m_FuelProperties;

        public FuelCar(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, eDoors i_NumOfDoors, eColor i_Color, float i_MaxFuelAmount, Fuel.eFuelType i_FuelType)
            : base(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_NumOfDoors, i_Color)
        {
            m_FuelProperties = new Fuel(i_MaxFuelAmount, i_FuelType);
        }
    }
}
