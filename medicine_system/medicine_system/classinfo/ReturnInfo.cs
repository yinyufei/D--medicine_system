using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medicine_system.classinfo
{
    class ReturnInfo
    {
        private string ReturnID;
        public string aReturnID
        {
            get { return ReturnID; }
            set { ReturnID = value; }
        }
        private string SellID;
        public string aSellID
        {
            get { return SellID; }
            set { SellID = value; }
        }
        private string EmployID;
        public string aEmployID
        {
            get { return EmployID; }
            set { EmployID = value; }
        }
        private double ReturnPay;
        public double aReturnPay
        {
            get { return ReturnPay; }
            set { ReturnPay = value; }
        }
        private DateTime ReturnDate;
        public DateTime aReturnDate
        {
            get { return ReturnDate; }
            set { ReturnDate = value; }
        }
        private int ReturnCount;
        public int aReturnCount
        {
            get { return ReturnCount; }
            set { ReturnCount = value; }
        }
        private double ReturnOnePrice;
        public double aReturnOnePrice
        {
            get { return ReturnOnePrice; }
            set { ReturnOnePrice = value; }
        }

    }
}

