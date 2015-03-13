using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medicine_system.classinfo
{
    class MedicineInfo
    {
        private string MedicineID;
        public string aMedicineID
        {
            get { return MedicineID; }
            set { MedicineID = value; }
        }
        private string MedicineName;
        public string aMedicineName
        {
            get { return MedicineName; }
            set { MedicineName = value; }
        }
        private string ProduceCompany;
        public string aProduceCompany
        {
            get { return ProduceCompany; }
            set { ProduceCompany = value; }
        }
        private int MedicineCount;
        public int aMedicineCount
        {
            get { return MedicineCount; }
            set { MedicineCount = value; }
        }
        private int AlarmCount;
        public int aAlarmCount
        {
            get { return AlarmCount; }
            set { AlarmCount = value; }
        }
        private double InPrice;
        public double aInPrice
        {
            get { return InPrice; }
            set { InPrice = value; }
        }
        private double OutPrice;
        public double aOutPrice
        {
            get { return OutPrice; }
            set { OutPrice = value; }
        }
        private string Type;
        public string aType
        {
            get { return Type; }
            set { Type = value; }
        }
        private string Unit;
        public string aUnit
        {
            get { return Unit; }
            set { Unit = value; }
        }
        private string Time;
        public string aTime
        {
            get { return Time; }
            set { Time = value; }
        }
        private int Flag;
        public int aFlag
        {
            get { return Flag; }
            set { Flag = value; }
        }

    }
}