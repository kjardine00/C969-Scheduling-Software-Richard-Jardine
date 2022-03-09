using System;
using System.Data;
using System.Drawing;
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
                AppointmentStartDateTimePicker.Value = selectedAppointment.AptStart.ToLocalTime();
                AppointmentEndDateTimePicker.Value = selectedAppointment.AptEnd.ToLocalTime();

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

        private static bool aptHasConflict(DateTime startTime, DateTime endTime)
        {
            Appointment_DataProcedures AptData = new Appointment_DataProcedures();

            bool hasConlict = false; 

            foreach (DataRow Apt in AptData.CreateAppointmentTable().Rows)
            {
                if (startTime < Convert.ToDateTime(Apt["End Time"]) && endTime > Convert.ToDateTime(Apt["Start Time"]))
                {
                    hasConlict = true;
                    return hasConlict;
                }
            }
            return hasConlict;
        }

        private static bool aptIsOutsideBusinessHours (DateTime startTime, DateTime endTime)
        {
            Appointment_DataProcedures AptData = new Appointment_DataProcedures();

            startTime = startTime.ToLocalTime();
            endTime = endTime.ToLocalTime();

            DateTime businessStart = DateTime.Today.AddHours(8); // 8am
            DateTime businessEnd = DateTime.Today.AddHours(17); // 5pm

            if (startTime.TimeOfDay > businessStart.TimeOfDay && startTime.TimeOfDay < businessEnd.TimeOfDay &&
                endTime.TimeOfDay > businessStart.TimeOfDay && endTime.TimeOfDay < businessEnd.TimeOfDay)
            {
                return false;
            }
            return true;
        }

        private void AppointmentSaveBtn_Click(object sender, EventArgs e)
        {
            bool allFieldshaveText = true;

            Appointment_DataProcedures data = new Appointment_DataProcedures();

            DateTime startTime = AppointmentStartDateTimePicker.Value.ToUniversalTime();
            DateTime endTime = AppointmentEndDateTimePicker.Value.ToUniversalTime();

            Appointment appointmentToSave = new Appointment(
                        Convert.ToInt32(AppointmentIdText.Text),
                        AppointmentTitleText.Text,
                        Convert.ToInt32(AppointmentUserIDPickList.SelectedItem),
                        Convert.ToInt32(AppointmentCustomerPickList.SelectedItem),
                        AppointmentTypeText.Text,
                        startTime,
                        endTime);

            if (string.IsNullOrEmpty(AppointmentTitleText.Text))
            {
                allFieldshaveText = false;
                AppointmentTitleText.BackColor = Color.Salmon;
            }
            if (string.IsNullOrEmpty(AppointmentTypeText.Text))
            {
                allFieldshaveText = false;
                AppointmentTypeText.BackColor = Color.Salmon;
            }

            if (allFieldshaveText == true)
            {
                try
                {
                    if(aptHasConflict(startTime, endTime))
                    {
                        throw new appointmentException();
                    }
                    else
                    {
                        try
                        {
                            if (aptIsOutsideBusinessHours(startTime, endTime))
                                {
                                throw new appointmentException();
                                }
                            else
                            {
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
                        }
                        catch (appointmentException ex) { ex.businessHours(); }
                        {

                        }
                    }
                }
                catch (appointmentException ex) { ex.appOverlap(); }
                {

                }
            }
        }

        class appointmentException : ApplicationException
        {
            public void businessHours()
            {
                MessageBox.Show("Appointments must be within normal business hours. (8am - 5pm)");
            }

            public void appOverlap()
            {
                MessageBox.Show("Your appointment conflicts with an already present appointment");
            }
        }
    
        private void AppointmentCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
