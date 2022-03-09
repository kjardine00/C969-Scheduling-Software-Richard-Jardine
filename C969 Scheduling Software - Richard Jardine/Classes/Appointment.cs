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
    public class Appointment
    {
        public int AptID { get; set; }
        public string AptTitle { get; set; }
        public int AptUserID { get; set; }
        public int AptCustID { get; set; }
        public string AptType { get; set; }
        public DateTime AptStart { get; set; }
        public DateTime AptEnd { get; set; }

        public Appointment(int AppointmentID, string AppointmentTitle, int AppointmentUserID, int AppointmentCustID, string AppointmentType, DateTime AppointmentStart, DateTime AppointmentEnd)
        {
            AptID = AppointmentID;
            AptTitle = AppointmentTitle;
            AptUserID = AppointmentUserID;
            AptCustID = AppointmentCustID;
            AptType = AppointmentType;
            AptStart = AppointmentStart;
            AptEnd = AppointmentEnd;
        }
    }
}
