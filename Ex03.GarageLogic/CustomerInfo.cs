using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CustomerInfo
    {
        private string m_Owner;
        private string m_Phone;
        private eCarStatusInGarage m_Status = eCarStatusInGarage.InWork;

        public CustomerInfo(string i_Owner, string i_Phone)
        {
            m_Owner = i_Owner;
            m_Phone = i_Phone;
        }

        internal enum eCarStatusInGarage
        {
            InWork,
            Fixed,
            Paid
        }

        public eCarStatusInGarage Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }
    }
}
