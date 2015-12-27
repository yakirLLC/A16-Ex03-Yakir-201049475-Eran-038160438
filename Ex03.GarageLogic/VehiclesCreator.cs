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

        public FuelCar CreateFuelCar(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_CurrentEnergy)
        {
            return new FuelCar(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_NumOfDoors, i_Color, i_CurrentEnergy);
        }

        public ElectricCar CreateElectricCar(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, Car.eDoors i_NumOfDoors, Car.eColor i_Color, float i_RemainingBatteryTime)
        {
            return new  ElectricCar(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_NumOfDoors, i_Color, i_RemainingBatteryTime);
        }

        public FuelMotorcycle CreateFuelMotorcycle(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, ref List<Wheel> i_Wheels, int i_EngineCapacity, Motorcycle.eLicenseType i_LicenseType, float i_CurrentEnergy)
        {
            return new FuelMotorcycle(i_ModelName, i_Id, i_PercentageEnergyLeft, ref i_Wheels, i_EngineCapacity, i_LicenseType, i_CurrentEnergy);
        }

        public ElectricMotorcycle CreateElectricMotorcycle(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, int i_EngineCapacity, Motorcycle.eLicenseType i_LicenseType, float i_RemainingBatteryTime)
        {
            return new ElectricMotorcycle(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_EngineCapacity, i_LicenseType, i_RemainingBatteryTime);
        }

        public FuelTrack CreateFuelTrack(string i_ModelName, string i_Id, float i_PercentageEnergyLeft, List<Wheel> i_Wheels, float i_MaxCarringWeight, bool i_CarriesDangerousMaterials, float i_CurrentEnergy)
        {
            return new FuelTrack(i_ModelName, i_Id, i_PercentageEnergyLeft, i_Wheels, i_MaxCarringWeight, i_CarriesDangerousMaterials, i_CurrentEnergy);
        }
    }
}
