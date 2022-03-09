using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public class Appointment_DataProcedures
    {
        private readonly string connectionString = "Server=127.0.0.1; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";

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

                foreach (DataRow row in appointmentDashboard.Rows)
                {
                    DateTime utcStart = Convert.ToDateTime(row["Start Time"]);
                    DateTime utcEnd = Convert.ToDateTime(row["End Time"]);
                    row["Start Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcStart);
                    row["End Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcEnd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when creating appointments datatable: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return appointmentDashboard;
        }

        public Appointment GetSelectedApt(int selectedID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            Appointment selectedApt = null;

            try
            {
                conn.Open();

                string query = 
                    "SELECT appointment.appointmentId, " +
                    "appointment.title, " +
                    "appointment.userId, " +
                    "appointment.customerId, " +
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
                        selectedApt = new Appointment(
                            Convert.ToInt32(reader["appointmentId"]),
                            reader["title"].ToString(),
                            Convert.ToInt32(reader["userId"]),
                            Convert.ToInt32(reader["customerId"]),
                            reader["type"].ToString(),
                            Convert.ToDateTime(reader["start"]),
                            Convert.ToDateTime(reader["end"]));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting selected appointment: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return selectedApt;
        }

        public List<int> GetCustomerIdList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            List<int> CustomerIdList = new List<int>();
            
            try
            {
                conn.Open();

                string query = "SELECT customerId FROM customer";

                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerIdList.Add(Convert.ToInt32(reader["customerId"]));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting customer id list: " + ex);
            }
            finally 
            {
                conn.Close();
            }
            return CustomerIdList;
        }

        public List<int> GetUserIdList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            List<int> UserIdList = new List<int>();

            try
            {
                conn.Open();

                string query = "SELECT userId FROM user";

                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserIdList.Add(Convert.ToInt32(reader["userId"]));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting a list of User Id's: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return UserIdList;
        }

        public void DeleteAppointment(int appointmentId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "DELETE FROM appointment WHERE appointmentId = @appointmentId;";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@appointmentId", appointmentId);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when deleting selected appointment: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public void SaveNewAppointment(Appointment appointmentToBeSaved)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            Admin_DataProcedures data = new Admin_DataProcedures();
            int aptID = data.CreateNewID("appointment");

            try
            {
                conn.Open();

                string query =
                    "INSERT INTO appointment " +
                    "(appointmentId, title, userId, customerId, type, start, end, " +
                    "description, location, url, contact, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES " +
                    "(@appointmentId, @appointmenttitle, @userId, @customerId, @type, @start, @end, " +
                    "'not needed', 'not needed', 'not needed', 'not needed', NOW(), 'System', NOW(), 'System');";

                string format = "yyyy-MM-dd HH:mm:ss";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@appointmentId", appointmentToBeSaved.AptID);
                command.Parameters.AddWithValue("@appointmenttitle", appointmentToBeSaved.AptTitle);
                command.Parameters.AddWithValue("@userId", appointmentToBeSaved.AptUserID);
                command.Parameters.AddWithValue("@customerId", appointmentToBeSaved.AptCustID);
                command.Parameters.AddWithValue("@type", appointmentToBeSaved.AptType);
                command.Parameters.AddWithValue("@start", appointmentToBeSaved.AptStart.ToUniversalTime().ToString(format));
                command.Parameters.AddWithValue("@end", appointmentToBeSaved.AptEnd.ToUniversalTime().ToString(format));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when saving new appointment: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public void SaveUpdatedAppointment(Appointment appointmentToBeSaved)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            Admin_DataProcedures data = new Admin_DataProcedures();

            try
            {
                conn.Open();

                string query =
                    "UPDATE appointment " +
                    "SET appointmentId = @appointmentId, " +
                    "title = @title, " +
                    "userId = @userId, " +
                    "customerId = @customerId, " +
                    "type = @type, " +
                    "start = @start, " +
                    "end = @end)";

                string format = "yyyy-MM-dd HH:mm:ss";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@appointmentId", appointmentToBeSaved.AptID);
                command.Parameters.AddWithValue("@title", appointmentToBeSaved.AptTitle);
                command.Parameters.AddWithValue("@userId", appointmentToBeSaved.AptUserID);
                command.Parameters.AddWithValue("@customerId", appointmentToBeSaved.AptCustID);
                command.Parameters.AddWithValue("@type", appointmentToBeSaved.AptType);
                command.Parameters.AddWithValue("@start", appointmentToBeSaved.AptStart.ToUniversalTime().ToString(format));
                command.Parameters.AddWithValue("@end", appointmentToBeSaved.AptEnd.ToUniversalTime().ToString(format));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when updating selected appointment: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public static string DateFormatToString(DateTime date)
        {
            string DateToString = date.ToString("yyyy-MM-dd HH:mm:ss");

            return DateToString;
        }

        public DataTable GetAppointmentsByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable appointmentsByWeek = new DataTable();

            MySqlConnection conn = new MySqlConnection(connectionString);

            if (!appointmentsByWeek.Columns.Contains("AptID")) { appointmentsByWeek.Columns.Add("AptID", typeof(int)); }
            if (!appointmentsByWeek.Columns.Contains("Title")) { appointmentsByWeek.Columns.Add("Title", typeof(string)); }
            if (!appointmentsByWeek.Columns.Contains("User ID")) { appointmentsByWeek.Columns.Add("User ID", typeof(string)); }
            if (!appointmentsByWeek.Columns.Contains("Customer")) { appointmentsByWeek.Columns.Add("Customer", typeof(string)); }
            if (!appointmentsByWeek.Columns.Contains("Type")) { appointmentsByWeek.Columns.Add("Type", typeof(string)); }
            if (!appointmentsByWeek.Columns.Contains("Start Time")) { appointmentsByWeek.Columns.Add("Start Time", typeof(DateTime)); }
            if (!appointmentsByWeek.Columns.Contains("End Time")) { appointmentsByWeek.Columns.Add("End Time", typeof(DateTime)); }

            try
            {
                conn.Open();

                string query = 
                    "SELECT appointment.appointmentId, " +
                    "appointment.title, " +
                    "appointment.userId, " +
                    "customer.customerName, " +
                    "appointment.type, " +
                    "appointment.start, " +
                    "appointment.end " +
                    "FROM appointment " +
                    "INNER JOIN customer ON customer.customerId = appointment.customerId " +
                    "WHERE appointment.start >= @weekStart " +
                    "AND appointment.end <= @weekEnd " +
                    "ORDER BY start;";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@weekStart", DateFormatToString(startDate));
                command.Parameters.AddWithValue("@weekEnd", DateFormatToString(endDate));

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointmentsByWeek.Rows.Add(
                            reader["appointmentId"],
                            reader["title"],
                            reader["userId"],
                            reader["customerName"],
                            reader["type"],
                            reader["start"],
                            reader["end"]);
                    }
                }

                foreach (DataRow row in appointmentsByWeek.Rows)
                {
                    DateTime utcStart = Convert.ToDateTime(row["Start Time"]);
                    DateTime utcEnd = Convert.ToDateTime(row["End Time"]);
                    row["Start Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcStart);
                    row["End Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcEnd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting appointments by date range: " + ex);
            }
            finally
            {
                conn.Close();
            }

            return appointmentsByWeek;
        }
    }
}
