using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public class Customer
    {
        public int CustID { get; set; }
        public string CustName { get; set; }
        public string CustAddress1 { get; set; }
        public string CustAddress2 { get; set; }
        public string CustCity { get; set; }
        public string CustCountry { get; set; }
        public string CustPostalCode { get; set; }
        public string CustPhone { get; set; }

        public Customer(int CID, string CName, string CAddress1, string CAddress2, string CCity, string CCountry, string CPostalCode, string CPhone)
        {
            CustID = CID;
            CustName = CName;
            CustAddress1 = CAddress1;
            CustAddress2 = CAddress2;
            CustCity = CCity;
            CustCountry = CCountry;
            CustPostalCode = CPostalCode;
            CustPhone = CPhone;
        }
    }
}
