using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medicine_system.classinfo
{
    class OutInfo
    {
        private string OutID;
        public string aOutID
        {
            get { return OutID; }
            set { OutID = value; }
        }
        private string InID;
        public string aInID
        {
            get { return InID; }
            set { InID = value; }
        }
        private string EmployID;
        public string aEmployID
        {
            get { return EmployID; }
            set { EmployID = value; }
        }
        private DateTime OutDate;
        public DateTime aOutDate
        {
            get { return OutDate; }
            set { OutDate = value; }
        }
        private double OutPay;
        public double aOutPay
        {
            get { return OutPay; }
            set { OutPay = value; }
        }
        private double OutOnePrice;
        public double aOutOnePrice
        {
            get { return OutOnePrice; }
            set { OutOnePrice = value; }
        }
        private int OutCount;
        public int aOutCount
        {
            get { return OutCount; }
            set { OutCount = value; }
        }

    }
}
