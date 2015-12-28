using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex02.ConsoleUtils;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        private GarageFunctionality m_GarageFunctionality = new GarageFunctionality();

        public static void Main()
        {
            int menuOption;
            Program run = new Program();

            Console.WriteLine("Welcome to the garage!");
            PrintGarageOptions();
            while ((menuOption = IntParseInput()) != 8)
            {
                switch (menuOption)
                {
                    case 1:
                        run.AddVehiclesToGarage();
                        break;
                    case 2:
                        run.ShowVehiclesInGarage();
                        break;
                    case 3:
                        run.ChangeVehicleStatusInGarage();
                        break;
                    case 4:
                        run.InflateWheelsToMax();
                        break;
                    case 5:
                        run.FillGas();
                        break;
                    case 6:
                        run.ChargeEnergy();
                        break;
                    case 7:
                        Screen.Clear();
                        run.ShowFullVehicleProperties();
                        Console.ReadLine();
                        Screen.Clear();
                        break;
                }
                PrintGarageOptions();
            }
        }

        public static void PrintGarageOptions()
        {
            StringBuilder menu = new StringBuilder();

            menu.AppendLine("1. Enter a new vehicle");
            menu.AppendLine("2. View vehicles IDs in the garage");
            menu.AppendLine("3. Change vehicle status");
            menu.AppendLine("4. Inflate wheels to max");
            menu.AppendLine("5. Fill vehicle with fuel");
            menu.AppendLine("6. Charge vehicle with energy");
            menu.AppendLine("7. View full deatils for a vehicle");
            menu.AppendLine("8. Exit");
            Console.WriteLine(menu.ToString());
        }

        public void AddVehiclesToGarage()
        {
            int engineCapacity;
            string modelName, id, ownerName, ownerPhone;
            float maxCarringWeight, currentEnergyLeft;
            bool stopAdddingVehicles = false, isCarringDangerousMaterials;
            VehiclesCreator.eVehicleType vehicleIndex;
            Motorcycle.eLicenseType licenseType;
            Car.eDoors doors;
            Car.eColor color;
            List<Wheel> wheels;
            CustomerInfo ci;
            VehiclesCreator vc = new VehiclesCreator();

            while (!stopAdddingVehicles)
            {
                Console.WriteLine("Please choose vehicle index type:");
                PrintEnumAsMenu<VehiclesCreator.eVehicleType>();
                vehicleIndex = (VehiclesCreator.eVehicleType)IntParseInput();
                GetCustomerInfo(out ownerName, out ownerPhone);
                ci = new CustomerInfo(ownerName, ownerPhone);
                GetVehicleDetails(out id, out modelName);
                switch (vehicleIndex)
                {
                    case VehiclesCreator.eVehicleType.FuelMotorcycle:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Motorcycle);
                        GetMotorcycleProperties(out engineCapacity, out licenseType);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateFuelMotorcycle(modelName, id, wheels, engineCapacity, licenseType, currentEnergyLeft), ci);
                        }
                        catch(ValueOutOfRangeException voorex)
                        {
                            Console.WriteLine(voorex.Message);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle with id {0} already exists, status is set to In Work.", id);
                        }

                        break;
                    case VehiclesCreator.eVehicleType.ElectricMotorcycle:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Motorcycle);
                        GetMotorcycleProperties(out engineCapacity, out licenseType);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Electric);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateElectricMotorcycle(modelName, id, wheels, engineCapacity, licenseType, currentEnergyLeft), ci);
                        }
                        catch (ValueOutOfRangeException voorex)
                        {
                            Console.WriteLine(voorex.Message);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle with id {0} already exists, status is set to In Work.", id);
                        }

                        break;
                    case VehiclesCreator.eVehicleType.FuelCar:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Car);
                        GetCarProperties(out color, out doors);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateFuelCar(modelName, id, wheels, doors, color, currentEnergyLeft), ci);
                        }
                        catch (ValueOutOfRangeException voorex)
                        {
                            Console.WriteLine(voorex.Message);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle with id {0} already exists, status is set to In Work.", id);
                        }

                        break;
                    case VehiclesCreator.eVehicleType.ElectricCar:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Car);
                        GetCarProperties(out color, out doors);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Electric);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateElectricCar(modelName, id, wheels, doors, color, currentEnergyLeft), ci);
                        }
                        catch (ValueOutOfRangeException voorex)
                        {
                            Console.WriteLine(voorex.Message);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle with id {0} already exists, status is set to In Work.", id);
                        }

                        break;
                    case VehiclesCreator.eVehicleType.FuelTrack:
                        GetWheelsDeatils(out wheels, Vehicle.eNumOfWheels.Track);
                        GetTrackProperties(out maxCarringWeight, out isCarringDangerousMaterials);
                        GetCurrentEnergy(out currentEnergyLeft, Engine.eEngineType.Fuel);
                        try
                        {
                            m_GarageFunctionality.AddVehicle(vc.CreateFuelTrack(modelName, id, wheels, maxCarringWeight, isCarringDangerousMaterials, currentEnergyLeft), ci);
                        }
                        catch (ValueOutOfRangeException voorex)
                        {
                            Console.WriteLine(voorex.Message);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Vehicle with id {0} already exists, status is set to In Work.", id);
                        }

                        break;
                }

                Console.WriteLine("Would you like to enter another vehicle(yes/no)?");
                stopAdddingVehicles = !GetYesNoAnswer(Console.ReadLine());
            }
        }

        public void GetVehicleDetails(out string o_Id, out string o_ModelName)
        {
            Console.WriteLine("Please Enter Your Vehicle ID:");
            o_Id = Console.ReadLine();
            Console.WriteLine("Please Enter Your Model Name:");
            o_ModelName = Console.ReadLine();
        }

        public static int IntParseInput()
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

        public static int IntParseInput(int i_MaxNumberToAccept)
        {
            bool formatError = false;
            int input = 0;

            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input > i_MaxNumberToAccept)
                    {
                        throw new ValueOutOfRangeException(new Exception(), i_MaxNumberToAccept, 1);
                    }
                }
                catch(ValueOutOfRangeException voorex)
                {
                    Console.WriteLine(voorex.Message);
                    formatError = true;
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

        public static void PrintEnumAsMenu<T>() where T : struct, IConvertible
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine("{0}. {1}", Convert.ToInt32(value), (T)value);
            }
        }

        public static float FloatParseInput()
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

        public static bool GetYesNoAnswer(string i_Answer)
        {
            while (!i_Answer.Equals("yes") && !i_Answer.Equals("no"))
            {
                Console.WriteLine("Please enter yes or no as an answer.");
                i_Answer = Console.ReadLine();
            }

            return i_Answer.Equals("yes");
        }

        public static void GetWheelsDeatils(out List<Wheel> o_Wheels, Vehicle.eNumOfWheels i_NumOfWheels)
        {
            string manufacturer;
            float currentAirPressure, maxAirPressure = 29;
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
                try
                {
                    wheel = new Wheel(manufacturer, maxAirPressure, currentAirPressure);
                    o_Wheels.Add(wheel);
                }
                catch (ValueOutOfRangeException voorex)
                {
                    Console.WriteLine(voorex.Message);
                }
            }
        }

        public static void GetMotorcycleProperties(out int o_EngineCapacity, out Motorcycle.eLicenseType o_LicenseType)
        {
            Console.WriteLine("Please Enter engine capacity:");
            o_EngineCapacity = IntParseInput();
            Console.WriteLine("Please choose license type:");
            PrintEnumAsMenu<Motorcycle.eLicenseType>();
            o_LicenseType = (Motorcycle.eLicenseType)IntParseInput();
        }

        public static void GetCarProperties(out Car.eColor o_Color, out Car.eDoors o_Doors)
        {
            Console.WriteLine("Please choose Car Color:");
            PrintEnumAsMenu<Car.eColor>();
            o_Color = (Car.eColor)IntParseInput();
            Console.WriteLine("Please choose amount of doors:");
            PrintEnumAsMenu<Car.eDoors>();
            o_Doors = (Car.eDoors)IntParseInput();
        }

        public static void GetTrackProperties(out float o_MaxCarringWeight, out bool o_CarriesDangerousMaterials)
        {
            Console.WriteLine("Please Enter maximum carring weight:");
            o_MaxCarringWeight = FloatParseInput();
            Console.WriteLine("Please enter yes or no for carring dangerous materials:");
            o_CarriesDangerousMaterials = GetYesNoAnswer(Console.ReadLine());
        }

        public static void GetCustomerInfo(out string o_OwnerName, out string o_OwnerPhone)
        {
            Console.WriteLine("Please Enter the Vehicle's owner name:");
            o_OwnerName = Console.ReadLine();
            Console.WriteLine("Please Enter the Vehicle's owner phone number:");
            o_OwnerPhone = Console.ReadLine();
        }

        public static void GetCurrentEnergy(out float o_CurrentEnergy, Engine.eEngineType i_EnergyType)
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

        public void ShowVehiclesInGarage()
        {
            bool isFilter;
            LinkedList<string> idList = new LinkedList<string>();
            CustomerInfo.eVehicleStatusInGarage status;

            Console.WriteLine("Would you like to filter by vehicle status(yes/no)?");
            isFilter = GetYesNoAnswer(Console.ReadLine());
            if (isFilter)
            {
                Console.WriteLine("Choose Status:");
                PrintEnumAsMenu<CustomerInfo.eVehicleStatusInGarage>();
                status = (CustomerInfo.eVehicleStatusInGarage)IntParseInput();
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

        public static string GetVehicleId()
        {
            Console.WriteLine("Please Enter vehicle ID:");

            return Console.ReadLine();
        }

        public void ChangeVehicleStatusInGarage()
        {
            string vehicleId;
            CustomerInfo.eVehicleStatusInGarage status;

            vehicleId = GetVehicleId();
            Console.WriteLine("Please choose Status:");
            PrintEnumAsMenu<CustomerInfo.eVehicleStatusInGarage>();
            status = (CustomerInfo.eVehicleStatusInGarage)IntParseInput();
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

        public void FillGas()
        {
            float fuelToFill;
            string vehicleId;
            bool exceptionFound;
            Fuel.eFuelType fuelType;

            vehicleId = GetVehicleId();
            do
            {
                try
                {
                    exceptionFound = false;
                    Console.WriteLine("Please Enter fuel type:");
                    PrintEnumAsMenu<Fuel.eFuelType>();
                    fuelType = (Fuel.eFuelType)IntParseInput();
                    Console.WriteLine("Please Enter amount of fuel to fill:");
                    fuelToFill = FloatParseInput();
                    m_GarageFunctionality.FillGas(vehicleId, fuelType, fuelToFill);
                }
                catch (ValueOutOfRangeException voorex)
                {
                    exceptionFound = true;
                    Console.WriteLine(voorex.Message);
                }
                catch (ArgumentException aex)
                {
                    exceptionFound = true;
                    Console.WriteLine(aex.Message);
                }
            }
            while (exceptionFound);
        }

        public void ChargeEnergy()
        {
            float energyToCharge;
            string vehicleId;
            bool exceptionFound;

            vehicleId = GetVehicleId();
            do
            {
                try
                {
                    exceptionFound = false;
                    Console.WriteLine("Please Enter amount of energy to charge:");
                    energyToCharge = FloatParseInput();
                    m_GarageFunctionality.ChargeEnergy(vehicleId, energyToCharge);
                }
                catch (ValueOutOfRangeException voorex)
                {
                    exceptionFound = true;
                    Console.WriteLine(voorex.Message);
                }
            }
            while (exceptionFound);
        }

        public void ShowFullVehicleProperties()
        {
            string vehicleId;

            vehicleId = GetVehicleId();
            Console.WriteLine(m_GarageFunctionality.GetFullDetails(vehicleId));
        }
    }
}
