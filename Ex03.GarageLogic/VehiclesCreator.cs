using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        private FuelCar m_FuelCar;
        private ElectricCar m_ElectricCar;
        private FuelMotorcycle m_FuelMotorcycle;
        private ElectricMotorcycle m_ElectricMotorcycle;
        private FuelTrack m_FuelTrack;

        private enum eVehicleType
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelTrack
        }

        public FuelCar CreateFuelCar(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_MaxFuelAmount, Fuel.eFuelType i_FuelType)
        {
            return new FuelCar(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_NumOfDoors, i_Color, i_MaxFuelAmount, i_FuelType);
        }

        public ElectricCar CreateElectricCar(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_MaxBatteryTime, float i_RemainingBatteryTime)
        {
            return new  ElectricCar(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_NumOfDoors, i_Color, i_MaxBatteryTime, i_RemainingBatteryTime);
        }

        public FuelMotorcycle CreateFuelMotorcycle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, Motorcycle.eLicenseType i_LicenseType, float i_MaxFuelAmount, Fuel.eFuelType i_FuelType)
        {
            return new FuelMotorcycle(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_EngineCapacity, i_LicenseType, i_MaxFuelAmount, i_FuelType);
        }

        public ElectricMotorcycle CreateElectricMotorcycle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, Motorcycle.eLicenseType i_LicenseType, float i_MaxBatteryTime, float i_RemainingBatteryTime)
        {
            return new ElectricMotorcycle(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_EngineCapacity, i_LicenseType, i_MaxBatteryTime, i_RemainingBatteryTime);
        }

        public FuelTrack CreateFuelTrack(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials, float i_MaxFuelAmount, Fuel.eFuelType i_FuelType)
        {
            return new FuelTrack(i_ModelName, i_Id, i_EnergyLeft, i_Wheels, i_MaxCarringWeight, i_CarriesDangerousMaterials, i_MaxFuelAmount, i_FuelType);
        }
    }
}
