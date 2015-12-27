using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        private GarageFunctionality m_GarageFunctionality = new GarageFunctionality();

        public void AddVehiclesToGarage()
        {
            int engineCapacity;
            string modelName, id, ownerName, ownerPhone;
            float percentageEnergyLeft, maxCarringWeight, currentEnergyLeft;
            bool stopAdddingVehicles = false, isCarringDangerousMaterials;
            GarageFunctionality.eVehicleType vehicleIndex;
            Motorcycle.eLicenseType licenseType;
            Car.eDoors doors;
            Car.eColor color;
            List<Wheel> wheels;
            CustomerInfo ci;
            VehiclesCreator vc = new VehiclesCreator();

            while (!stopAdddingVehicles)
            {
                Console.WriteLine("Please choose vehicle index type:");
                foreach (VehiclesCreator.eVehicleType vehicleType in Enum.GetValues(typeof(VehiclesCreator.eVehicleType)))
                {
                    Console.WriteLine("{0}. {1}", (int)vehicleType, (VehiclesCreator.eVehicleType)vehicleType);
                }

                vehicleIndex = (GarageFunctionality.eVehicleType)IntParseInput();
                GetCustomerInfo(out ownerName, out ownerPhone);
                ci = new CustomerInfo(ownerName, ownerPhone);
                GetVehicleDetails(out id, out modelName, out percentageEnergyLeft);
                switch (vehicleIndex)
                {
                    case GarageFunctionality.eVehicleType.FuelMotorcycle:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Motorcycle);
                        GetMotorcycleProperties(out engineCapacity, out licenseType);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateFuelMotorcycle(modelName, id, percentageEnergyLeft, wheels, engineCapacity, licenseType, currentEnergyLeft), ci);
                        }
                        catch(ArgumentException)
                        {
                            Console.WriteLine("Vehicle already exists, status is set to In Work.");
                        }
                        break;
                    case GarageFunctionality.eVehicleType.ElectricMotorcycle:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Motorcycle);
                        GetMotorcycleProperties(out engineCapacity, out licenseType);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Electric);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateElectricMotorcycle(modelName, id, percentageEnergyLeft, wheels, engineCapacity, licenseType, currentEnergyLeft), ci);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle already exists, status is set to In Work.");
                        }
                        break;
                    case GarageFunctionality.eVehicleType.FuelCar:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Car);
                        GetCarProperties(out color, out doors);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateFuelCar(modelName, id, percentageEnergyLeft, wheels, doors, color, currentEnergyLeft), ci);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle already exists, status is set to In Work.");
                        }
                        break;
                    case GarageFunctionality.eVehicleType.ElectricCar:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Car);
                        GetCarProperties(out color, out doors);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Electric);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateElectricCar(modelName, id, percentageEnergyLeft, wheels, doors, color, currentEnergyLeft), ci);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle already exists, status is set to In Work.");
                        }
                        break;
                    case GarageFunctionality.eVehicleType.FuelTrack:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Track);
                        GetTrackProperties(out maxCarringWeight, out isCarringDangerousMaterials);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateFuelTrack(modelName, id, percentageEnergyLeft, wheels, maxCarringWeight, isCarringDangerousMaterials, currentEnergyLeft), ci);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle already exists, status is set to In Work.");
                        }
                        break;
                }
                Console.WriteLine("Would you like to enter another vehicle(yes/no)?");
                stopAdddingVehicles = !GetYesNoAnswer(Console.ReadLine());
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

        public bool GetYesNoAnswer(string i_Answer)
        {
            while (!i_Answer.Equals("yes") && !i_Answer.Equals("no"))
            {
                Console.WriteLine("Please enter yes or no as an answer.");
                i_Answer = Console.ReadLine();
            }

            return i_Answer.Equals("yes");
        }

        public void GetWheelsDeatils(out List<Wheel> o_Wheels, Vehicle.eNumOfWheels i_NumOfWheels)
        {
            string manufacturer;
            float currentAirPressure, maxAirPressure =29;
            Wheel wheel;

            o_Wheels = new List<Wheel>();
            Console.WriteLine("Please Enter wheels manufacturer:");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Please Enter wheels current air pressure:");
            currentAirPressure = FloatParseInput();
            switch ((int)i_NumOfWheels)
            {
                case 2:
                    maxAirPressure = 32;
                    break;
                case 4:
                    maxAirPressure = 29;
                    break;
                case 12:
                    maxAirPressure = 34;
                    break;
            }
            for (int i = 0; i < (int)i_NumOfWheels; i++)
            {
                wheel = new Wheel(manufacturer, maxAirPressure, currentAirPressure);
                o_Wheels.Add(wheel);
            }
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
            Console.WriteLine("Please Enter maximum carring weight:");
            o_MaxCarringWeight = FloatParseInput();
            Console.WriteLine("Please enter yes or no for carring dangerous materials:");
            o_CarriesDangerousMaterials = GetYesNoAnswer(Console.ReadLine());
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

        public void PrintVehicleStatusTypeMenu()
        {
            foreach (CustomerInfo.eCarStatusInGarage vehicleStatus in Enum.GetValues(typeof(CustomerInfo.eCarStatusInGarage)))
            {
                Console.WriteLine("{0}. {1}", (int)vehicleStatus, (CustomerInfo.eCarStatusInGarage)vehicleStatus);
            }
        }

        public void ShowVehiclesInGarage()
        {
            bool isFilter;
            LinkedList<string> idList = new LinkedList<string>();
            CustomerInfo.eCarStatusInGarage status;

            Console.WriteLine("Would you like to filter by vehicle status(yes/no)?");
            isFilter = GetYesNoAnswer(Console.ReadLine());
            if (isFilter)
            {
                Console.WriteLine("Choose Status:");
                PrintVehicleStatusTypeMenu();
                status = (CustomerInfo.eCarStatusInGarage)IntParseInput();
                idList = m_GarageFunctionality.ReturnVehiclesId(status);
            }
            else
            {
                idList = m_GarageFunctionality.ReturnVehiclesId();
            }

            Console.WriteLine("Vehicles ID List:");
            foreach (string id in idList)
            {
                Console.WriteLine(id);
            }
        }

        public string GetVehicleId()
        {
            Console.WriteLine("Please Enter vehicle ID:");

            return Console.ReadLine();
        }

        public void ChangeVehicleStatusInGarage()
        {
            string vehicleId;
            CustomerInfo.eCarStatusInGarage status;

            vehicleId = GetVehicleId();
            Console.WriteLine("Please choose Status:");
            PrintVehicleStatusTypeMenu();
            status = (CustomerInfo.eCarStatusInGarage)IntParseInput();
            m_GarageFunctionality.UpdateVehicleStatus(vehicleId, status);
            Console.WriteLine(" Vehicle with ID {0} was set to {1}.", vehicleId, status.ToString());
        }

        public void InflateWheelsToMax()
        {
            string vehicleId;

            vehicleId = GetVehicleId();
            m_GarageFunctionality.InflateWheelsToMax(vehicleId);
            Console.WriteLine(" All wheels were inflated to max in vehicle with ID of {0}.", vehicleId);
        }
    }
}
