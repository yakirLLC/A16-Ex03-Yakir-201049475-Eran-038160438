using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CustomerInfo
    {
        private string m_Owner;
        private string m_Phone;
        private eVehicleStatusInGarage m_Status = eVehicleStatusInGarage.InWork;

        public CustomerInfo(string i_Owner, string i_Phone)
        {
            m_Owner = i_Owner;
            m_Phone = i_Phone;
        }

        public enum eVehicleStatusInGarage
        {
            InWork = 1,
            Fixed,
            Paid
        }

        public string OwnerName
        {
            get
            {
                return m_Owner;
            }

            set
            {
                m_Owner = value;
            }
        }

        public string Phone
        {
            get
            {
                return m_Phone;
            }

            set
            {
                m_Phone = value;
            }
        }

        public eVehicleStatusInGarage Status
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

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();

            details.AppendLine(string.Format("Owner Name: {0}", m_Owner));
            details.AppendLine(string.Format("Phone: {0}", m_Phone));
            details.Append(string.Format("Vehicle Status: {0}", m_Status.ToString()));

            return details.ToString();
        }
    }
}
