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
    public class Appointments
    {
        public int AptID { get; set; }
        public string AptTitle { get; set; }
        public int AptUserID { get; set; }
        public string AptCustomer { get; set; }
        public string AptType { get; set; }
        public DateTime AptStart { get; set; }
        public DateTime AptEnd { get; set; }

        public Appointments(int AppointmentID, string AppointmentTitle, int AppointmentUserID, string AppointmentCustomer, string AppointmentType, DateTime AppointmentStart, DateTime AppointmentEnd)
        {
            AptID = AppointmentID;
            AptTitle = AppointmentTitle;
            AptUserID = AppointmentUserID;
            AptCustomer = AppointmentCustomer;
            AptType = AppointmentType;
            AptStart = AppointmentStart;
            AptEnd = AppointmentEnd;
        }
    }
}
