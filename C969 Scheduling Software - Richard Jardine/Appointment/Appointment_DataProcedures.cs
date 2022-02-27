using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public class Appointment_DataProcedures
    {
        private string connectionString = "Host=localhost; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        DataTable appointmentDashboard = new DataTable();

        public DataTable CreateAppointmentTable()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            DataTable appointmentDashboard = new DataTable();

            if (!appointmentDashboard.Columns.Contains("AptID")) { appointmentDashboard.Columns.Add("AptID", typeof(int)); }
            if (!appointmentDashboard.Columns.Contains("Title")) { appointmentDashboard.Columns.Add("Title", typeof(string)); }
            if (!appointmentDashboard.Columns.Contains("User ID")) { appointmentDashboard.Columns.Add("User ID", typeof(string)); }
            if (!appointmentDashboard.Columns.Contains("Customer")) { appointmentDashboard.Columns.Add("Customer", typeof(string)); }
            if (!appointmentDashboard.Columns.Contains("Type")) { appointmentDashboard.Columns.Add("Type", typeof(string)); }
            if (!appointmentDashboard.Columns.Contains("Start Time")) { appointmentDashboard.Columns.Add("Start Time", typeof(DateTime)); }
            if (!appointmentDashboard.Columns.Contains("End Time")) { appointmentDashboard.Columns.Add("End Time", typeof(DateTime)); }

            try
            {
                conn.Open();

                string query = "SELECT appointment.appointmentId, " +
                    "appointment.title, " +
                    "appointment.userId, " +
                    "customer.customerName, " +
                    "appointment.type, " +
                    "appointment.start, " +
                    "appointment.end " +
                    "FROM appointment " +
                    "INNER JOIN customer ON appointment.customerId = customer.customerId;";


                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointmentDashboard.Rows.Add(
                            reader["appointmentId"],
                            reader["title"],
                            reader["userId"],
                            reader["customerName"],
                            reader["type"],
                            reader["start"],
                            reader["end"]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return appointmentDashboard;
        }

        public Appointments UpdatedAptList(int selectedID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            Appointments selectedApt = null;

            try
            {
                conn.Open();

                string query = "SELECT appointment.appointmentId, " +
                    "appointment.title, " +
                    "appointment.userId, " +
                    "customer.customerName, " +
                    "appointment.type, " +
                    "appointment.start, " +
                    "appointment.end " +
                    "FROM appointment " +
                    "INNER JOIN customer " +
                    "ON appointment.customerId = customer.customerId " +
                    "WHERE appointmentId = @ID";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@ID", selectedID);

                using ( MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        selectedApt = new Appointments(
                            Convert.ToInt32(reader["appointmentId"]),
                            reader["title"].ToString(),
                            Convert.ToInt32(reader["userId"]),
                            reader["customerName"].ToString(),
                            reader["type"].ToString(),
                            Convert.ToDateTime(reader["start"]),
                            Convert.ToDateTime(reader["end"]));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return selectedApt;
        }


        public List<string> GetCustomerNameList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            List<string> CustomerList = new List<string>();

            try
            {
                conn.Open();

                string query = "SELECT customerName FROM customer";

                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerList.Add(reader["customerName"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                conn.Close();
            }
            return CustomerList;
        }
    }
}
