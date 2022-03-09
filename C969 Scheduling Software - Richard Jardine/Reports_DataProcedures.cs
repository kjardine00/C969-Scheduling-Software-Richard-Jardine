using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

        public List<Appointment> GetAppointmentsList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            string query =
                "SELECT appointmentId, " +
                    "title, " +
                   "userId, " +
                    "customerId, " +
                    "type, " +
                    "start, " +
                    "end " +
                    "FROM appointment;";

            List<Appointment> appointments = new List<Appointment>();

            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment newAppointment = new Appointment(
                            Convert.ToInt32(reader["appointmentId"]),
                            reader["title"].ToString(),
                            Convert.ToInt32(reader["userId"]),
                            Convert.ToInt32(reader["customerId"]),
                            reader["type"].ToString(),
                            Convert.ToDateTime(reader["start"]).ToLocalTime(),
                            Convert.ToDateTime(reader["end"]).ToLocalTime());

                        appointments.Add(newAppointment);
                    }
                    reader.Close();
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return appointments;
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
