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

        public void AddVehicle(string i_VehicleId, CustomerInfo i_CustomerInfo, eVehicleType i_VehicleType)
        {
            try
            {
                Vehicle vehicle;

                m_VehiclesInGarageById.Add(i_VehicleId, i_CustomerInfo);
                //switch (i_VehicleType)
                //{
                //    case eVehicleType.FuelCar:
                //        vehicle = new FuelCar();
                //        break;
                //    case eVehicleType.ElectricCar:
                //        vehicle = new ElectricCar();
                //        break;
                //    case eVehicleType.FuelMotorcycle:
                //        vehicle = new FuelMotorcycle();
                //        break;
                //    case eVehicleType.ElectricMotorcycle:
                //        vehicle = new ElectricMotorcycle();
                //        break;
                //    case eVehicleType.FuelTrack:
                //        vehicle = new FuelTrack();
                //        break;
                //}
            }
            catch(ArgumentException aex)
            {
                
            }
        }
    }
}
