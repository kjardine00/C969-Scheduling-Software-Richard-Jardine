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
    public partial class Dashboard : Form
    {
        private BindingSource CustomerDashboard = new BindingSource();
        //private BindingSource AppointmentDashboard = new BindingSource(); //These all do nothing need to figure out datetime filtering
        private BindingSource ReportsDashboard = new BindingSource();

        private DataTable AppointmentDashboard = new DataTable();

        public Dashboard()
        {
            InitializeComponent();
            MainScreen_Load();
        }

        private void MainScreen_Load()
        {
            Customer_DataProcedures customerData = new Customer_DataProcedures();
            CustomerDGV.DataSource = customerData.CreateCustomerTable();

            Appointment_DataProcedures appointmentData = new Appointment_DataProcedures();
            AppointmentDashboard = appointmentData.CreateAppointmentTable();
            AppointmentDGV.DataSource = AppointmentDashboard;

            AllAppointmentsRadio.Checked = true;
            ByWeekRadio.Checked = false;
            ByMonthRadio.Checked = false;
        }

        private void AddNewCustBtn_Click(object sender, EventArgs e)
        {
            Admin_DataProcedures data = new Admin_DataProcedures();
            new CustomerForm(true, data.CreateNewID("customer")).ShowDialog();
            MainScreen_Load();
        }

        private void UpdateCustBtn_Click(object sender, EventArgs e)
        {
            Customer_DataProcedures data = new Customer_DataProcedures();

            if (CustomerDGV.SelectedRows.Count > 0)
            {
                string selectedCustID = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
                
                int selectedCustIDint = Convert.ToInt32(selectedCustID);

                new CustomerForm(false, selectedCustIDint).ShowDialog();

                MainScreen_Load();
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
                MainScreen_Load();
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
            MainScreen_Load();
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
                MainScreen_Load();
            }
            else
            {
                MessageBox.Show("Please select a Customer you would like to Delete.");
            }
        }

        private void AllAppointmentsRadio_CheckedChanged(object sender, EventArgs e)
        {
            MainScreen_Load();
        }

        private void ByWeekRadio_CheckedChanged(object sender, EventArgs e)
        {
            Appointment_DataProcedures appointmentData = new Appointment_DataProcedures();

            string weekStart = DateTime.Today.AddDays(-1 * (int)DateTime.Today.DayOfWeek).ToString();
            string weekEnd = DateTime.Today.AddDays((int)DateTime.Today.DayOfWeek).ToString();



            AppointmentDashboard = appointmentData.CreateAppointmentTable().Select().Where(
                p => (Convert.ToDateTime(p["Start Time"]) >= Convert.ToDateTime(weekStart)) 
                && (Convert.ToDateTime(p["Start Time"]) <= Convert.ToDateTime(weekEnd))).CopyToDataTable();

            AppointmentDGV.DataSource = AppointmentDashboard;
        }

        private void ByMonthRadio_CheckedChanged(object sender, EventArgs e)
        {
            string monthStart = DateTime.Today.AddDays(-Convert.ToDouble(DateTime.Now.Day - 1)).ToString();
            string monthEnd = DateTime.Today.AddDays(-Convert.ToDouble(DateTime.Now.Day - 1)).AddMonths(1).AddDays(-1).ToString();

            //AppointmentDashboard.Filter = "Start Time >= #" + monthStart + "# and End Time <= #" + monthEnd + "#";
            //AppointmentDGV.Refresh();
            //This doesn't work
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
