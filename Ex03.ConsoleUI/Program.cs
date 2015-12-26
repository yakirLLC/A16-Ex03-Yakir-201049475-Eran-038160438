using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public enum eNumOfWheels
        {
            Motorcycle = 2,
            Car = 4,
            Track = 12
        }

        public Dictionary<string, CustomerInfo> AddVehiclesToGarage()
        {
            int vehicleIndex, engineCapacity;
            string modelName, id;
            float percentageEnergyLeft, maxCarringWeight;
            bool stopAdddingVehicles = false, isCarringDangerousMaterials;
            Motorcycle.eLicenseType licenseType;
            Car.eDoors doors;
            Car.eColor color;
            VehiclesCreator vc = new VehiclesCreator();

            while (!stopAdddingVehicles)
            {
                Console.WriteLine("Please choose vehicle index type:");
                foreach (VehiclesCreator.eVehicleType vehicleType in Enum.GetValues(typeof(VehiclesCreator.eVehicleType)))
                {
                    Console.WriteLine("{0}. {1}", (int)vehicleType, (VehiclesCreator.eVehicleType)vehicleType);
                }

                vehicleIndex = IntParseInput();
                GetVehicleDetails(out id, out modelName, out percentageEnergyLeft);
                switch (vehicleIndex)
                {
                    case 1:
                    case 2: 
                        GetMotorcycleProperties(out engineCapacity, out licenseType);
                        break;
                    case 3:
                    case 4:
                        GetCarProperties(out color, out doors);
                        break;
                    case 5:
                        GetTrackProperties(out maxCarringWeight, out isCarringDangerousMaterials);
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
    }
}
