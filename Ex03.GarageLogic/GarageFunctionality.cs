﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageFunctionality
    {
        private Dictionary<string, CustomerInfo> m_VehiclesInGarageById = new Dictionary<string, CustomerInfo>();
        private LinkedList<Vehicle> m_Vehicles = new LinkedList<Vehicle>();

        public void AddVehicle(Vehicle i_VehicleToAdd, CustomerInfo i_CustomerInfo)
        {
            try
            {
                m_VehiclesInGarageById.Add(i_VehicleToAdd.Id, i_CustomerInfo);
                m_Vehicles.AddLast(i_VehicleToAdd);
            }
            catch(ArgumentException)
            {
                i_CustomerInfo.Status = CustomerInfo.eVehicleStatusInGarage.InWork;
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

        public LinkedList<string> ReturnVehiclesId(CustomerInfo.eVehicleStatusInGarage i_VehicleStatus)
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

        public void UpdateVehicleStatus(string i_Id, CustomerInfo.eVehicleStatusInGarage i_NewVehicleStatus)
        {
            m_VehiclesInGarageById[i_Id].Status = i_NewVehicleStatus;
        }

        public void InflateWheelsToMax(string i_Id)
        {
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.Id.Equals(i_Id))
                {
                    foreach (Wheel wheel in vehicle.Wheels)
                    {
                        wheel.InflateToMax();
                    }

                    break;
                }
            }
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
                    customerDetails.AppendLine(string.Format("Full Details for vehicle with ID {0}:\n", i_Id));
                    customerDetails.AppendLine(m_VehiclesInGarageById[i_Id].ToString());
                    customerDetails.Append(vehicle.ToString());
                    break;
                }
            }

            return customerDetails.ToString();
        }
    }
}
