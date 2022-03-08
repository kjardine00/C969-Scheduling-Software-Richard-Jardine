using System;
using System.Data;
using System.Windows.Forms;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public partial class Dashboard : Form
    {
        private DataTable AppointmentDashboard = new DataTable();
        private DataTable CustomerDashboard = new DataTable();

        public Dashboard(int UserID)
        {
            InitializeComponent();
            CustomerDashboard_Load();
            AppointmentDashboard_Load();

            Admin_DataProcedures AdminData = new Admin_DataProcedures();

            

            if (UserID != 0)
            {
                int AptIdReminder = AdminData.CheckForAptReminder(UserID);

                if(AptIdReminder != 0)
                {
                    string AptIdTitle = AdminData.GetAptTitle(AptIdReminder);

                    MessageBox.Show("You have the Appointment '" + AptIdReminder.ToString() + ": " + AptIdTitle + "' in the next 15 minutes.", "Reminder");
                }
            }
        }

        private void CustomerDashboard_Load()
        {
            Customer_DataProcedures customerData = new Customer_DataProcedures();
            CustomerDashboard = customerData.CreateCustomerTable();
            CustomerDGV.DataSource = CustomerDashboard;
        }

        private void AppointmentDashboard_Load()
        {
            Appointment_DataProcedures appointmentData = new Appointment_DataProcedures();
            AppointmentDashboard = appointmentData.CreateAppointmentTable();
            AppointmentDGV.DataSource = AppointmentDashboard;
        }

        private void AddNewCustBtn_Click(object sender, EventArgs e)
        {
            Admin_DataProcedures data = new Admin_DataProcedures();
            new CustomerForm(true, data.CreateNewID("customer")).ShowDialog();
            CustomerDashboard_Load();
        }

        private void UpdateCustBtn_Click(object sender, EventArgs e)
        {
            Customer_DataProcedures data = new Customer_DataProcedures();

            if (CustomerDGV.SelectedRows.Count > 0)
            {
                string selectedCustID = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
                
                int selectedCustIDint = Convert.ToInt32(selectedCustID);

                new CustomerForm(false, selectedCustIDint).ShowDialog();

                CustomerDashboard_Load();
            }
            else
            {
                MessageBox.Show("Please select a Customer you would like to Update.");
            }
        }

        private void DeleteCustBtn_Click(object sender, EventArgs e)
        {
            Customer_DataProcedures data = new Customer_DataProcedures();

            if (CustomerDGV.SelectedRows.Count > 0)
            {
                string selectedCustID = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
                int selectedCustIDint = Convert.ToInt32(selectedCustID);

                DialogResult deleteCustDialogResult = MessageBox.Show("Are you sure you would like to delete Customer ID: " + selectedCustID + "?", "Delete Part", MessageBoxButtons.YesNo);

                if (deleteCustDialogResult == DialogResult.Yes)
                {
                    data.DeleteCustomer(selectedCustIDint);
                }
                else
                {
                    // do nothing
                }
                CustomerDashboard_Load();
            }
            else
            {
                MessageBox.Show("Please select a Customer you would like to Delete.");
            }

        }

        private void AddNewAppointmentBtn_Click(object sender, EventArgs e)
        {
            Admin_DataProcedures data = new Admin_DataProcedures();
            new AppointmentForm(true, data.CreateNewID("appointment")).ShowDialog();
            AppointmentDashboard_Load();
        }

        private void UpdateAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (AppointmentDGV.SelectedRows.Count > 0)
            {
                string selectedAptID = AppointmentDGV.SelectedRows[0].Cells[0].Value.ToString();

                int selectedAptIDint = Convert.ToInt32(selectedAptID);

                new AppointmentForm(false, selectedAptIDint).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Appointment you would like to Update.");
            }
            AppointmentDashboard_Load();
        }

        private void DeleteAppointmentBtn_Click(object sender, EventArgs e)
        {
            Appointment_DataProcedures data = new Appointment_DataProcedures();

            if (CustomerDGV.SelectedRows.Count > 0)
            {
                string selectedAptID = AppointmentDGV.SelectedRows[0].Cells[0].Value.ToString();
                int selectedCustIDint = Convert.ToInt32(selectedAptID);

                DialogResult deleteAptDialogResult = MessageBox.Show("Are you sure you would like to delete Appointment ID: " + selectedAptID + "?", "Delete Part", MessageBoxButtons.YesNo);

                if (deleteAptDialogResult == DialogResult.Yes)
                {
                    data.DeleteAppointment(selectedCustIDint);
                }
                else
                {
                    // do nothing
                }
                AppointmentDashboard_Load();
            }
            else
            {
                MessageBox.Show("Please select a Customer you would like to Delete.");
            }
        }

        private void AllAppointmentsRadio_CheckedChanged(object sender, EventArgs e)
        {
            AppointmentDashboard_Load();
        }

        private void ByWeekRadio_CheckedChanged(object sender, EventArgs e)
        {
            Appointment_DataProcedures appointmentData = new Appointment_DataProcedures();

            DateTime weekStart = DateTime.Now;
            DateTime weekEnd = DateTime.Now.AddDays(7);

            AppointmentDashboard = appointmentData.GetAppointmentsByDateRange(weekStart, weekEnd);

            AppointmentDGV.DataSource = AppointmentDashboard;
        }

        private void ByMonthRadio_CheckedChanged(object sender, EventArgs e)
        {
            Appointment_DataProcedures appointmentData = new Appointment_DataProcedures();

            DateTime monthStart = DateTime.Now;
            DateTime monthEnd = DateTime.Now.AddMonths(1);

            AppointmentDashboard = appointmentData.GetAppointmentsByDateRange(monthStart, monthEnd);

            AppointmentDGV.DataSource = AppointmentDashboard;
        }

        private void GenerateReportBtn_Click(object sender, EventArgs e)
        {
            Reports_DataProcedures reportsData = new Reports_DataProcedures();
            

            if (AppointmentsByTypeRadio.Checked == true)
            {
                ReportsDGV.DataSource = reportsData.GetAppointmentsByType();
            }
            if (ConsultantSchedulesRadio.Checked == true)
            {
                ReportsDGV.DataSource = reportsData.GetConsultantSchedulesRadio();
            }
            if (CustomerCountRadio.Checked == true)
            {
                ReportsDGV.DataSource = reportsData.GetCustomerCount();
            }
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
