using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        public enum eVehicleType
        {
            FuelMotorcycle = 1,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            FuelTrack
        }

        public FuelCar CreateFuelCar(string i_ModelName, string i_Id, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_CurrentEnergy)
        {
            FuelCar vehicle;

            try
            {
                vehicle = new FuelCar(i_ModelName, i_Id, i_Wheels, i_NumOfDoors, i_Color, i_CurrentEnergy);
            }
            catch (ValueOutOfRangeException voorex)
            {
                vehicle = null;
                throw voorex;
            }

            return vehicle;
        }

        public ElectricCar CreateElectricCar(string i_ModelName, string i_Id, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_RemainingBatteryTime)
        {
            ElectricCar vehicle;

            try
            {
                vehicle = new ElectricCar(i_ModelName, i_Id, i_Wheels, i_NumOfDoors, i_Color, i_RemainingBatteryTime);
            }
            catch (ValueOutOfRangeException voorex)
            {
                vehicle = null;
                throw voorex;
            }

            return vehicle;
        }

        public FuelMotorcycle CreateFuelMotorcycle(string i_ModelName, string i_Id, List<Wheel> i_Wheels, int i_EngineCapacity, Motorcycle.eLicenseType i_LicenseType, float i_CurrentEnergy)
        {
            FuelMotorcycle vehicle;

            try
            {
                vehicle = new FuelMotorcycle(i_ModelName, i_Id, i_Wheels, i_EngineCapacity, i_LicenseType, i_CurrentEnergy);
            }
            catch (ValueOutOfRangeException voorex)
            {
                vehicle = null;
                throw voorex;
            }
            
            return vehicle;
        }

        public ElectricMotorcycle CreateElectricMotorcycle(string i_ModelName, string i_Id, List<Wheel> i_Wheels, int i_EngineCapacity, Motorcycle.eLicenseType i_LicenseType, float i_RemainingBatteryTime)
        {
            ElectricMotorcycle vehicle;

            try
            {
                vehicle = new ElectricMotorcycle(i_ModelName, i_Id, i_Wheels, i_EngineCapacity, i_LicenseType, i_RemainingBatteryTime);
            }
            catch (ValueOutOfRangeException voorex)
            {
                vehicle = null;
                throw voorex;
            }

            return vehicle;
        }

        public FuelTrack CreateFuelTrack(string i_ModelName, string i_Id, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials, float i_CurrentEnergy)
        {
            FuelTrack vehicle;

            try
            {
                vehicle = new FuelTrack(i_ModelName, i_Id, i_Wheels, i_MaxCarringWeight, i_CarriesDangerousMaterials, i_CurrentEnergy);
            }
            catch (ValueOutOfRangeException voorex)
            {
                vehicle = null;
                throw voorex;
            }

            return vehicle;
        }
    }
}
