using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public class Reports_DataProcedures
    {
        private readonly string connectionString = "Host=localhost; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";

        public DataTable reportsDashboard = new DataTable();

        public DataTable GetAppointmentsByType()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            reportsDashboard.Clear();

            try
            {
                conn.Open();

                string query =
                    "SELECT " +
                    "appointment.type, " +
                    "appointment.appointmentId, " +
                    "appointment.title, " +
                    "customer.customerName, " +
                    "appointment.userId, " +
                    "appointment.start, " +
                    "appointment.end " +
                    "FROM appointment " +
                    "INNER JOIN customer ON customer.customerId = appointment.customerId " +
                    "ORDER BY appointment.type;";

                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(reportsDashboard);
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
            MySqlConnection conn = new MySqlConnection(connectionString);

            reportsDashboard.Clear();

            try
            {
                conn.Open();

                string query = 
                    "SELECT user.userId, " +
                    "user.userName, " +
                    "appointment.appointmentId, " +
                    "appointment.title, " +
                    "appointment.customerId, " +
                    "appointment.type, " +
                    "appointment.start, " +
                    "appointment.end " +
                    "FROM appointment " +
                    "INNER JOIN user ON appointment.userId = user.userId " +
                    "ORDER BY user.userId; ";

                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(reportsDashboard);
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
            MySqlConnection conn = new MySqlConnection(connectionString);

            reportsDashboard.Clear();

            try
            {
                conn.Open();

                string query = "SELECT COUNT(customerId) FROM customer; ";

                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(reportsDashboard);
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
