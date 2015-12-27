using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        private GarageFunctionality m_GarageFunctionality = new GarageFunctionality();

        public enum eNumOfWheels
        {
            Motorcycle = 2,
            Car = 4,
            Track = 12
        }

        public void AddVehiclesToGarage()
        {
            int vehicleIndex, engineCapacity;
            string modelName, id, ownerName, ownerPhone;
            float percentageEnergyLeft, maxCarringWeight, currentEnergyLeft;
            bool stopAdddingVehicles = false, isCarringDangerousMaterials;
            Motorcycle.eLicenseType licenseType;
            Car.eDoors doors;
            Car.eColor color;
            List<Wheel> wheels = new List<Wheel>();
            CustomerInfo ci;
            VehiclesCreator vc = new VehiclesCreator();

            while (!stopAdddingVehicles)
            {
                Console.WriteLine("Please choose vehicle index type:");
                foreach (VehiclesCreator.eVehicleType vehicleType in Enum.GetValues(typeof(VehiclesCreator.eVehicleType)))
                {
                    Console.WriteLine("{0}. {1}", (int)vehicleType, (VehiclesCreator.eVehicleType)vehicleType);
                }

                vehicleIndex = IntParseInput();
                GetCustomerInfo(out ownerName, out ownerPhone);
                ci = new CustomerInfo(ownerName, ownerPhone);
                GetVehicleDetails(out id, out modelName, out percentageEnergyLeft);
                switch (vehicleIndex)
                {
                    case 1:
                        GetMotorcycleProperties(out engineCapacity, out licenseType);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        m_GarageFunctionality.AddVehicle(vc.CreateFuelMotorcycle(modelName, id, percentageEnergyLeft, ref wheels, engineCapacity, licenseType, currentEnergyLeft), ci);
                        break;
                    case 2: 
                        GetMotorcycleProperties(out engineCapacity, out licenseType);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Electric);
                        break;
                    case 3:
                        GetCarProperties(out color, out doors);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        break;
                    case 4:
                        GetCarProperties(out color, out doors);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Electric);
                        break;
                    case 5:
                        GetTrackProperties(out maxCarringWeight, out isCarringDangerousMaterials);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        break;
                }
                
            }
        }

        public void GetVehicleDetails(out string o_Id, out string o_ModelName, out float o_PercentageEnergyLeft)
        {
            Console.WriteLine("Please Enter Your Vehicle ID:");
            o_Id = Console.ReadLine();
            Console.WriteLine("Please Enter Your Model Name:");
            o_ModelName = Console.ReadLine();
            Console.WriteLine("Please Enter the vehicle's remaining energy left in percentage:");
            o_PercentageEnergyLeft = FloatParseInput();
        }

        public int IntParseInput()
        {
            bool formatError = false;
            int input = 0;

            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format error, please enter an integer value.");
                    formatError = true;
                }
            }
            while (formatError);

            return input;
        }

        public float FloatParseInput()
        {
            bool formatError = false;
            float input = 0;

            do
            {
                try
                {
                    input = float.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format error, please enter a float value.");
                    formatError = true;
                }
            }
            while (formatError);

            return input;
        }

        public void GetMotorcycleProperties(out int o_EngineCapacity, out Motorcycle.eLicenseType o_LicenseType)
        {
            Console.WriteLine("Please Enter engine capacity:");
            o_EngineCapacity = IntParseInput();
            Console.WriteLine("Please choose license type:");
            foreach (Motorcycle.eLicenseType licenseType in Enum.GetValues(typeof(Motorcycle.eLicenseType)))
            {
                Console.WriteLine("{0}. {1}", (int)licenseType, (Motorcycle.eLicenseType)licenseType);
            }

            o_LicenseType = (Motorcycle.eLicenseType)IntParseInput();
        }

        public void GetCarProperties(out Car.eColor o_Color, out Car.eDoors o_Doors)
        {
            Console.WriteLine("Please choose Car Color:");
            foreach (Car.eColor color in Enum.GetValues(typeof(Car.eColor)))
            {
                Console.WriteLine("{0}. {1}", (int)color, (Motorcycle.eLicenseType)color);
            }

            o_Color = (Car.eColor)IntParseInput();
            Console.WriteLine("Please choose amount of doors:");
            foreach (Car.eDoors doors in Enum.GetValues(typeof(Car.eDoors)))
            {
                Console.WriteLine("{0}. {1}", (int)doors, (Car.eDoors)doors);
            }

            o_Doors = (Car.eDoors)IntParseInput();
        }

        public void GetTrackProperties(out float o_MaxCarringWeight, out bool o_CarriesDangerousMaterials)
        {
            string dangerousMaterials;

            Console.WriteLine("Please Enter maximum carring weight:");
            o_MaxCarringWeight = FloatParseInput();
            Console.WriteLine("Please enter yes or no for carring dangerous materials:");
            dangerousMaterials = Console.ReadLine();
            o_CarriesDangerousMaterials = dangerousMaterials.Equals("yes");
        }

        public void GetCustomerInfo(out string o_OwnerName, out string o_OwnerPhone)
        {
            Console.WriteLine("Please Enter the Vehicle's owner name:");
            o_OwnerName = Console.ReadLine();
            Console.WriteLine("Please Enter the Vehicle's owner phone number:");
            o_OwnerPhone = Console.ReadLine();
        }

        public void GetCurrentEnergy(out float o_CurrentEnergy, Engine.eEngineType i_EnergyType)
        {
            if (i_EnergyType.Equals(Engine.eEngineType.Fuel))
            {
                Console.WriteLine("Please Enter current fuel amount in Liters:");
            }
            else
            {
                Console.WriteLine("Please Enter current Battery time left in Hours:");
            }

            o_CurrentEnergy = FloatParseInput();
        }
    }
}
