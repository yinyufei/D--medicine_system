using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medicine_system.classinfo
{
    class InInfo
    {
        private string InID;
        public string aInID
        {
            get { return InID; }
            set { InID = value; }
        }
        private string MedicineID;
        public string aMedicineID
        {
            get { return MedicineID; }
            set { MedicineID = value; }
        }
        private string CompanyID;
        public string aCompanyID
        {
            get { return CompanyID; }
            set { CompanyID = value; }
        }
        private string EmployID;
        public string aEmployID
        {
            get { return EmployID; }
            set { EmployID = value; }
        }
        private double InOnePrice;
        public double aInOnePrice
        {
            get { return InOnePrice; }
            set { InOnePrice = value; }
        }
        private int InCount;
        public int aInCount
        {
            get { return InCount; }
            set { InCount = value; }
        }
        private DateTime InTime;
        public DateTime aInTime
        {
            get { return InTime; }
            set { InTime = value; }
        }
        private double InPay;
        public double aInPay
        {
            get { return InPay; }
            set { InPay = value; }
        }
        private DateTime ProduceTime;
        public DateTime aProduceTime
        {
            get { return ProduceTime; }
            set { ProduceTime = value; }
        }
        private int Flag;
        public int aFlag
        {
            get { return Flag; }
            set { Flag = value; }
        }
    }
}
