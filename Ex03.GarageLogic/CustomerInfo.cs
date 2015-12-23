using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CustomerInfo
    {
        private string m_Owner;
        string m_Phone;
        eCarStatusInGarage m_Status;
        private enum eCarStatusInGarage
        {
            InWork,
            Fixed,
            Paid
        }
    }
}
