using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public enum eEngineType
        {
            Fuel,
            Electric
        }

        protected Engine(float i_MaxEnergy, float i_CurrentEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
        }

        internal float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                m_CurrentEnergy = value;
            }
        }

        internal float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.Append(base.ToString());
            details.Append(string.Format(@"Maximum Energy: {0}
                                         Current Amount Of Energy: {1}
                                         ", r_MaxEnergy, m_CurrentEnergy));

            return details.ToString();
        }
    }
}
