using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel : Engine
    {
        private readonly eFuelType r_Fuel;

        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public eFuelType FuelType
        {
            get
            {
                return r_Fuel;
            }
        }

        public Fuel(float i_MaxFuelAmount, float i_CurrentEnergy, eFuelType i_FuelType)
            :base(i_MaxFuelAmount, i_CurrentEnergy)
        {
            r_Fuel = i_FuelType;
        }

        public void FillTank(float i_FuelToFill, eFuelType i_FuelType)
        {
            if (i_FuelType.Equals(r_Fuel))
            {
                if (this.CurrentEnergy + i_FuelToFill <= this.MaxEnergy)
                {
                    this.CurrentEnergy += i_FuelToFill;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), this.MaxEnergy, this.CurrentEnergy);
            }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.Append(base.ToString());
            details.Append(string.Format(@"Fuel Type: {0}
                                         ", (eFuelType)r_Fuel));

            return details.ToString();
        }
    }
}
