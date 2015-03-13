using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medicine_system.classinfo
{
    class CompanyInfo
    {
        private string CompanyID;
        public string aCompanyID
        {
            get { return CompanyID; }
            set { CompanyID = value; }
        }
        private string CompanyName;
        public string aCompanyName
        {
            get { return CompanyName; }
            set { CompanyName = value; }
        }
        private string CompanyDirector;
        public string aCompanyDirector
        {
            get { return CompanyDirector; }
            set { CompanyDirector = value; }
        }
        private string CompanyPhone;
        public string aCompanyPhone
        {
            get { return CompanyPhone; }
            set { CompanyPhone = value; }
        }
        private string CompanyAddress;
        public string aCompanyAddress
        {
            get { return CompanyAddress; }
            set { CompanyAddress = value; }
        }
        private string DirectorPhone;
        public string aDirectorPhone
        {
            get { return DirectorPhone; }
            set { DirectorPhone = value; }
        }

    }
}
