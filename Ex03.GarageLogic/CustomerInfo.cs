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

        private enum eCarStatusInGarage
        {
            InWork,
            Fixed,
            Paid
        }
    }
}
