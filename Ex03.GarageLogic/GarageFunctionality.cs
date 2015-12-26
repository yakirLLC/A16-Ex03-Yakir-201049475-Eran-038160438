using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageFunctionality
    {
        private Dictionary<string, CustomerInfo> m_VehiclesInGarageById = new Dictionary<string, CustomerInfo>();
        private LinkedList<Vehicle> m_Vehicles = new LinkedList<Vehicle>();

        public enum eVehicleType
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
                m_Vehicles.AddLast(i_VehicleToAdd);
            }
            catch(ArgumentException)
            {
                i_CustomerInfo.Status = CustomerInfo.eCarStatusInGarage.InWork;
                throw new ArgumentException();
            }
        }

        public LinkedList<string> ReturnVehiclesId()
        {
            LinkedList<string> returnedIdLinkedList = new LinkedList<string>();

            foreach (Vehicle vehicle in m_Vehicles)
            {
                returnedIdLinkedList.AddLast(vehicle.Id);
            }

            return returnedIdLinkedList;
        }

        public LinkedList<string> ReturnVehiclesId(CustomerInfo.eCarStatusInGarage i_VehicleStatus)
        {
            LinkedList<string> returnedIdLinkedList = new LinkedList<string>();

            foreach (KeyValuePair<string, CustomerInfo> kvp in m_VehiclesInGarageById)
            {
                if (kvp.Value.Status.Equals(i_VehicleStatus))
                {
                    returnedIdLinkedList.AddLast(kvp.Key);
                }
            }

            return returnedIdLinkedList;
        }

        public void UpdateVehicleStatus(string i_Id, CustomerInfo.eCarStatusInGarage i_NewVehicleStatus)
        {
            m_VehiclesInGarageById[i_Id].Status = i_NewVehicleStatus;
        }

        public void FillGas(string i_Id, Fuel.eFuelType i_FuelType, float i_FuelToFill)
        {
            foreach (Vehicle vehicle in m_Vehicles)
            {
                try
                {
                    if (vehicle.Id.Equals(i_Id))
                    {
                        vehicle.FillEnergy(vehicle.EngineType, i_FuelType, i_FuelToFill);
                        break;
                    }
                }
                catch(ValueOutOfRangeException voorex)
                {
                    throw voorex;
                }
                catch(ArgumentException aex)
                {
                    throw aex;
                }
            }
        }

        public void ChargeEnergy(string i_Id, float i_EnergyToCharge)
        {
            foreach (Vehicle vehicle in m_Vehicles)
            {
                try
                {
                    if (vehicle.Id.Equals(i_Id))
                    {
                        vehicle.FillEnergy(vehicle.EngineType, i_EnergyToCharge);
                        break;
                    }
                }
                catch (ValueOutOfRangeException voorex)
                {
                    throw voorex;
                }
            }
        }

        public string GetFullDetails(string i_Id)
        {
            StringBuilder customerDetails = new StringBuilder();

            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.Id.Equals(i_Id))
                {
                    customerDetails.Append(string.Format(@"Owner Name: {0}
                                                         Phone: {1}
                                                         Vehicle Status: {2}
                                                         ", m_VehiclesInGarageById[i_Id].OwnerName, m_VehiclesInGarageById[i_Id].Phone, m_VehiclesInGarageById[i_Id].Status));
                    customerDetails.Append(vehicle.ToString());
                    break;
                }
            }

            return customerDetails.ToString();
        }
    }
}
