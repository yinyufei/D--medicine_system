using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medicine_system.classinfo
{
    class SellInfo
    {
        private string SellID;
        public string aSellID
        {
            get { return SellID; }
            set { SellID = value; }
        }
        private string MedicineID;
        public string aMedicineID
        {
            get { return MedicineID; }
            set { MedicineID = value; }
        }
        private string EmployID;
        public string aEmployID
        {
            get { return EmployID; }
            set { EmployID = value; }
        }
        private int SellCount;
        public int aSellCount
        {
            get { return SellCount; }
            set { SellCount = value; }
        }
        private DateTime SellTime;
        public DateTime aSellTime
        {
            get { return SellTime; }
            set { SellTime = value; }
        }
        private double SellPay;
        public double aSellPay
        {
            get { return SellPay; }
            set { SellPay = value; }
        }
        private double SellOnePrice;
        public double aSellOnePrice
        {
            get { return SellOnePrice; }
            set { SellOnePrice = value; }
        }
        private int Flag;
        public int aFlag
        {
            get { return Flag; }
            set { Flag = value; }
        }
    }
}
