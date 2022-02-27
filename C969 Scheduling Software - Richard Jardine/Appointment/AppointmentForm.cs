using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm(bool newApt, int aptID)
        {
            InitializeComponent();
            LoadCustomerPicker();

            int AppointmentID = 0;

            Appointment_DataProcedures data = new Appointment_DataProcedures();

            if (newApt == true)
            {
                AppointmentHeader.Text = "New Appointment";
                AppointmentID = aptID;
            }
            else
            {
                AppointmentHeader.Text = "Update Appointment";

                Appointments selectedAppointment = data.UpdatedAptList(aptID);

                AppointmentID = selectedAppointment.AptID;
                AppointmentTitleText.Text = selectedAppointment.AptTitle;
                AppointmentUserIDText.Text = selectedAppointment.AptUserID.ToString();
                AppointmentTypeText.Text = selectedAppointment.AptType;
                AppointmentStartDateTimePicker.Value = selectedAppointment.AptStart;
                AppointmentEndDateTimePicker.Value = selectedAppointment.AptEnd;

                foreach (string name in data.GetCustomerNameList())
                {
                    if (name == selectedAppointment.AptCustomer)
                    {
                        int index = data.GetCustomerNameList().IndexOf(name);

                        AppointmentCustomerPickList.SelectedIndex = index;
                    }
                }
            }
        }

        private void LoadCustomerPicker()
        {
            Appointment_DataProcedures data = new Appointment_DataProcedures();

            AppointmentCustomerPickList.DataSource = data.GetCustomerNameList();
        }

        private void AppointmentSaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void AppointmentCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
