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
        private readonly string connectionString = "Server=127.0.0.1; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";

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
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting appointment list: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return appointments;
        }

        public List<Customer> GetCustomerList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            string query = "SELECT customer.customerId, " +
                "customer.customerName, " +
                "address.address, " +
                "address.address2, " +
                "city.city, " +
                "country.country, " +
                "address.postalCode, " +
                "address.phone " +
                "FROM(((customer INNER JOIN address ON customer.addressId = address.addressId) " +
                "INNER JOIN city ON address.cityId = city.cityId ) " +
                "INNER JOIN country ON city.countryId = country.countryId );";

            List<Customer> CustomerList = new List<Customer>();

            try
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer newCustomer = new Customer(
                        Convert.ToInt32(reader["customerId"]),
                        reader["customerName"].ToString(),
                        reader["address"].ToString(),
                        reader["address2"].ToString(),
                        reader["city"].ToString(),
                        reader["country"].ToString(),
                        reader["postalCode"].ToString(),
                        reader["phone"].ToString());

                        CustomerList.Add(newCustomer);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting customer list: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return CustomerList;
        }
    }
}
