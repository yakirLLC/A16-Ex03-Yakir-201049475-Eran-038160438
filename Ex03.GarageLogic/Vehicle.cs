using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_Id;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        protected Vehicle(string i_ModelName, string i_Id, float i_EnergyLeft, List<Wheel> i_Wheels)
        {
            r_ModelName = i_ModelName;
            r_Id = i_Id;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
        }

        public Engine EngineType
        {
            get
            {
                return m_Engine;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string Id
        {
            get
            {
                return r_Id;
            }
        }

        protected void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void FillEnergy(Engine i_Engine, Fuel.eFuelType i_FuelType, float i_EnergyToFill)
        {
            if (i_FuelType == (i_Engine as Fuel).FuelType)
            {
                if (i_Engine.CurrentEnergy + i_EnergyToFill <= i_Engine.MaxEnergy && i_Engine != null)
                {
                    i_Engine.CurrentEnergy += i_EnergyToFill;
                }
                else
                {
                    throw new ValueOutOfRangeException(new Exception(), i_Engine.MaxEnergy, 0.1f);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void FillEnergy(Engine i_Engine, float i_EnergyToFill)
        {
            if (i_Engine.CurrentEnergy + i_EnergyToFill <= i_Engine.MaxEnergy)
            {
                i_Engine.CurrentEnergy += i_EnergyToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), i_Engine.MaxEnergy, 0.1f);
            }
        }

        public override string ToString()
        {
            int i = 1;
            float percentageEnergyLeft;
            string details;
            StringBuilder wheelsDetails = new StringBuilder();

            foreach (Wheel wheel in m_Wheels)
            {
                wheelsDetails.Append(string.Format("Wheel #{0}:\n\tManufacturer: {1}\n\tMaximum Air Pressure: {2}\n\tCurrent Air Pressure: {3}\n", i++, wheel.Manufacturer, wheel.MaxAirPressure, wheel.CurrentAirPressure));
            }

            percentageEnergyLeft = m_Engine.CurrentEnergy * 100 / m_Engine.MaxEnergy;
            details = string.Format(@"ID: {0}
                                    Model Name: {1}
                                    Energy left: {2}
                                    {3}
                                    Maximum Energy: {4}
                                    % Energy Left: {5}%
                                    ", r_Id, r_ModelName, m_EnergyLeft, wheelsDetails, m_Engine.MaxEnergy, percentageEnergyLeft);

            return details;
        }
    }
}
