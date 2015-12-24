using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageFunctionality
    {
        private Dictionary<string, CustomerInfo> m_VehiclesInGarageById = new Dictionary<string, CustomerInfo>();
        private LinkedList<Vehicle> m_Vehicles = new LinkedList<Vehicle>();

        private enum eVehicleType
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelTrack
        }

        public void AddVehicle(Vehicle i_VehicleToAdd, CustomerInfo i_CustomerInfo)
        {
            try
            {
                m_VehiclesInGarageById.Add(i_VehicleToAdd.Id, i_CustomerInfo);
            }
            catch(ArgumentException aex)
            {
                
            }
        }
    }
}
