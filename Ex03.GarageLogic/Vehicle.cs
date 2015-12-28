using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_Id;
        private float m_PercentageEnergyLeft;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public enum eNumOfWheels
        {
            Motorcycle = 2,
            Car = 4,
            Track = 12
        }

        protected Vehicle(string i_ModelName, string i_Id, List<Wheel> i_Wheels)
        {
            r_ModelName = i_ModelName;
            r_Id = i_Id;
            m_Wheels = i_Wheels;
            m_PercentageEnergyLeft = 100;
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
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

        public float PercentageEnergyLeft
        {
            get
            {
                return m_PercentageEnergyLeft;
            }

            set
            {
                m_PercentageEnergyLeft = value;
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
            StringBuilder wheelsDetails = new StringBuilder(), details = new StringBuilder();

            foreach (Wheel wheel in m_Wheels)
            {
                wheelsDetails.Append(string.Format("Wheel #{0}:\n\tManufacturer: {1}\n\tMaximum Air Pressure: {2}\n\tCurrent Air Pressure: {3}\n", i++, wheel.Manufacturer, wheel.MaxAirPressure, wheel.CurrentAirPressure));
            }

            details.AppendLine(string.Format("ID: {0}", r_Id));
            details.AppendLine(string.Format("Model Name: {0}", r_ModelName));
            details.AppendLine(string.Format("Percentae Energy left: {0}", m_PercentageEnergyLeft));
            details.Append(string.Format("{0}", wheelsDetails.ToString()));

            return details.ToString();
        }
    }
}
