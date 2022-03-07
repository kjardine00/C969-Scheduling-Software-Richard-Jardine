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
        public int custID = 0;
        private bool newAppointment = false;

        public AppointmentForm(bool newApt, int aptID)
        {
            InitializeComponent();
            LoadPickers();

            Appointment_DataProcedures AptData = new Appointment_DataProcedures();
            Admin_DataProcedures Admindata = new Admin_DataProcedures();

            newAppointment = newApt;

            if (newApt == true)
            {
                AppointmentHeader.Text = "New Appointment";
                AppointmentIdText.Text = Admindata.CreateNewID("appointment").ToString();
            }
            else
            {
                AppointmentHeader.Text = "Update Appointment";

                Appointment selectedAppointment = AptData.GetSelectedApt(aptID);

                AppointmentIdText.Text = selectedAppointment.AptID.ToString();
                AppointmentTitleText.Text = selectedAppointment.AptTitle;
                AppointmentTypeText.Text = selectedAppointment.AptType;
                AppointmentStartDateTimePicker.Value = selectedAppointment.AptStart;
                AppointmentEndDateTimePicker.Value = selectedAppointment.AptEnd;

                custID = selectedAppointment.AptCustID;

                foreach (int name in AptData.GetCustomerIdList())
                {
                    if (name == selectedAppointment.AptCustID)
                    {
                        int index = AptData.GetCustomerIdList().IndexOf(name);

                        AppointmentCustomerPickList.SelectedIndex = index;
                    }
                }

                foreach (int name in AptData.GetUserIdList())
                {
                    if (name == selectedAppointment.AptCustID)
                    {
                        int index = AptData.GetUserIdList().IndexOf(name);

                        AppointmentUserIDPickList.SelectedIndex = index;
                    }
                }
            }
        }

        private void LoadPickers()
        {
            Appointment_DataProcedures data = new Appointment_DataProcedures();

            AppointmentCustomerPickList.DataSource = data.GetCustomerIdList();
            AppointmentUserIDPickList.DataSource = data.GetUserIdList();
        }

        private void AppointmentSaveBtn_Click(object sender, EventArgs e)
        {
            Appointment_DataProcedures data = new Appointment_DataProcedures();

            Appointment appointmentToSave = new Appointment(
                Convert.ToInt32(AppointmentIdText.Text),
                AppointmentTitleText.Text,
                Convert.ToInt32(AppointmentUserIDPickList.SelectedItem),
                Convert.ToInt32(AppointmentCustomerPickList.SelectedItem), // This isn't working
                //AppointmentCustomerPickList.Text,
                AppointmentTypeText.Text,
                AppointmentStartDateTimePicker.Value,
                AppointmentEndDateTimePicker.Value);

            if (newAppointment == true)
            {
                data.SaveNewAppointment(appointmentToSave);
            }
            else
            {
                data.SaveUpdatedAppointment(appointmentToSave);
            }
            Close();
        }

        private void AppointmentCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
