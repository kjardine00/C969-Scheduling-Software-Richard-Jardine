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
        BindingSource CustomerDashboard = new BindingSource();
        BindingSource AppointmentDashboard = new BindingSource();
        BindingSource ReportsDashboard = new BindingSource();

        public static int CustIDCount;

        public Dashboard()
        {
            InitializeComponent();
            MainScreen_Load();
        }

        private void MainScreen_Load()
        {
            Customer_DataProcedures data = new Customer_DataProcedures();
            CustomerDGV.DataSource = data.CreateCustomerTable();
        }

        private void AddNewCustBtn_Click(object sender, EventArgs e)
        {
            new CustomerForm(true, CustIDCount).ShowDialog();
        }

        private void UpdateCustBtn_Click(object sender, EventArgs e)
        {
            Customer_DataProcedures data = new Customer_DataProcedures();

            if (CustomerDGV.SelectedRows.Count > 0)
            {
                string selectedCustID = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
                
                int selectedCustIDint = Convert.ToInt32(selectedCustID);

                new CustomerForm(false, selectedCustIDint).ShowDialog();
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

                DialogResult deletePartDialogResult = MessageBox.Show("Are you sure you would like to delete Customer ID: " + selectedCustID + "?", "Delete Part", MessageBoxButtons.YesNo);

                if (deletePartDialogResult == DialogResult.Yes)
                {
                    
                }
                else
                {
                    // do nothing
                }
                
            }
            else
            {
                MessageBox.Show("Please select a Customer you would like to Delete.");
            }
        }

        private void AddNewAppointmentBtn_Click(object sender, EventArgs e)
        {

        }

        private void UpdateAppointmentBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteAppointmentBtn_Click(object sender, EventArgs e)
        {

        }

        private void AllAppointmentsRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ByWeekRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ByMonthRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AppointmentsByTypeRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ConsultantSchedulesRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CustomerCountRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GenerateReportBtn_Click(object sender, EventArgs e)
        {

        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
