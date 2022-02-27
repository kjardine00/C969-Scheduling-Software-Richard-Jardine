﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    class Customer_DataProcedures
    {
        private string connectionString = "Host=localhost; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        DataTable customerDashboard = new DataTable();

        public bool VerifyUser(User userInfo)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                MySqlCommand checkUserName = conn.CreateCommand();
                checkUserName.CommandText = "SELECT userName FROM user WHERE userName = @username";
                checkUserName.Parameters.AddWithValue("@username", userInfo.UserName);
                string dbUsername = checkUserName.ExecuteScalar().ToString();

                MySqlCommand checkPassword = conn.CreateCommand();
                checkPassword.CommandText = "SELECT password FROM user WHERE BINARY password = @password AND userName = @username";
                checkPassword.Parameters.AddWithValue("@password", userInfo.UserPassword);
                checkPassword.Parameters.AddWithValue("@username", userInfo.UserName);
                string dbPassword = checkPassword.ExecuteScalar().ToString();
                return true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        public DataTable CreateCustomerTable()
        {
            Dashboard.CustIDCount = 1;

            MySqlConnection conn = new MySqlConnection(connectionString);

            DataTable customerDashboard = new DataTable();

            if (!customerDashboard.Columns.Contains("ID")) { customerDashboard.Columns.Add("ID", typeof(int)); }
            if (!customerDashboard.Columns.Contains("Name")) { customerDashboard.Columns.Add("Name", typeof(string)); }
            if (!customerDashboard.Columns.Contains("Address 1")) { customerDashboard.Columns.Add("Address 1", typeof(string)); }
            if (!customerDashboard.Columns.Contains("Address 2")) { customerDashboard.Columns.Add("Address 2", typeof(string)); }
            if (!customerDashboard.Columns.Contains("City")) { customerDashboard.Columns.Add("City", typeof(string)); }
            if (!customerDashboard.Columns.Contains("Country")) { customerDashboard.Columns.Add("Country", typeof(string)); }
            if (!customerDashboard.Columns.Contains("Postal Code")) { customerDashboard.Columns.Add("Postal Code", typeof(string)); }
            if (!customerDashboard.Columns.Contains("Phone")) { customerDashboard.Columns.Add("Phone", typeof(string)); }

            try
            {
                conn.Open();

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

                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerDashboard.Rows.Add(
                            reader["customerId"], 
                            reader["customerName"], 
                            reader["address"], 
                            reader["address2"], 
                            reader["city"], 
                            reader["country"], 
                            reader["postalCode"], 
                            reader["phone"]);
                        Dashboard.CustIDCount++;
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

            return customerDashboard;
        }

        public Customer UpdatedCustList(int SelectedID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            DataTable customerDashboard = new DataTable();

            Customer selectedCust = null;

            try
            {
                conn.Open();

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
                    "INNER JOIN country ON city.countryId = country.countryId ) " +
                    "WHERE customerId = @ID";
               
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@ID", SelectedID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        selectedCust = new Customer(
                            Convert.ToInt32(reader["customerId"]), 
                            reader["customerName"].ToString(), 
                            reader["address"].ToString(), 
                            reader["address2"].ToString(), 
                            reader["city"].ToString(), 
                            reader["country"].ToString(), 
                            reader["postalCode"].ToString(), 
                            reader["phone"].ToString()
                            );
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            return selectedCust;
        }

        public void DeleteCustomer()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            DataTable customerDashboard = new DataTable();

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
        }
    }
}