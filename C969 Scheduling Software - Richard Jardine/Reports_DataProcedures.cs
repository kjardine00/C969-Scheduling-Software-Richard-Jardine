using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    class Reports_DataProcedures
    {
        private string connectionString = "Host=localhost; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        DataTable reportsDashboard = new DataTable();

        public DataTable GetAppointmentsByType()
        {
            DataTable reportsDashboard = new DataTable();

            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return reportsDashboard;
        }

        public DataTable GetConsultantSchedulesRadio()
        {
            DataTable reportsDashboard = new DataTable();

            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return reportsDashboard;
        }

        public DataTable GetCustomerCount()
        {
            DataTable reportsDashboard = new DataTable();

            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return reportsDashboard;
        }
    }
}
