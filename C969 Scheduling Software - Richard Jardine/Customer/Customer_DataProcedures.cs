using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace C969_Scheduling_Software___Richard_Jardine
{
    class Customer_DataProcedures
    {
        private static readonly string connectionString = "Host=localhost; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";
       
        public DataTable CreateCustomerTable()
        {
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

                string query = 
                    "SELECT customer.customerId, " +
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

            Customer selectedCust = null;

            try
            {
                conn.Open();

                string query = 
                    "SELECT customer.customerId, " +
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

        public void DeleteCustomer(int selectedCustID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            DataTable customerDashboard = new DataTable();

            try
            {
                conn.Open();

                string query = 
                    "DELETE FROM customer " +
                    "WHERE customerId = @customerId ";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@customerId", selectedCustID);

                string query2 = 
                    "DELETE FROM address " +
                    "WHERE addressId = " +
                    "(SELECT addressId FROM customer WHERE customerId = @customerId) ";

                MySqlCommand command2 = new MySqlCommand(query2, conn);
                command2.Parameters.AddWithValue("@customerId", selectedCustID);

                string query3 = 
                    "DELETE FROM city " +
                    "WHERE cityId = " +
                    "(SELECT cityId FROM address WHERE addressId = " +
                    "(SELECT addressId FROM customer WHERE customerId = @customerId));";

                MySqlCommand command3 = new MySqlCommand(query3, conn);
                command3.Parameters.AddWithValue("@customerId", selectedCustID);

                string query4 = 
                    "DELETE FROM country WHERE countryId = " +
                    "(SELECT countryId FROM city WHERE cityId = " +
                    "(SELECT cityId FROM address WHERE addressId = " +
                    "(SELECT addressId FROM customer WHERE customerId = @customerId)));";

                MySqlCommand command4 = new MySqlCommand(query4, conn);
                command4.Parameters.AddWithValue("@customerId", selectedCustID);

                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public void SaveNewCustomer(Customer customerToBeSaved)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            Admin_DataProcedures data = new Admin_DataProcedures();

            int custID = 0;
            int addressID = 0;
            int cityID = 0;
            int countryID = 0;

            custID = data.CreateNewID("customer");
            addressID = data.CreateNewID("address");
            cityID = data.CreateNewID("city");
            countryID = data.CreateNewID("country");

            try
            {
                conn.Open();

                string query =
                    "INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdateBy) " +
                    "VALUES (@ID, @custName, @AddressID, 1, NOW(), 'SystemAdd', 'SystemAdd');";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@ID", custID);
                command.Parameters.AddWithValue("@custName", customerToBeSaved.CustName);
                command.Parameters.AddWithValue("@AddressID", addressID);

                string query2 =
                    "INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                    "VALUES (@AddressID, @Address1, @address2, @cityID, @postalCode, @phone, NOW(), 'SystemAdd', 'SystemAdd');";

                MySqlCommand command2 = new MySqlCommand(query2, conn);
                command2.Parameters.AddWithValue("@AddressID", addressID);
                command2.Parameters.AddWithValue("@Address1", customerToBeSaved.CustAddress1);
                command2.Parameters.AddWithValue("@address2", customerToBeSaved.CustAddress2);
                command2.Parameters.AddWithValue("@cityID", cityID);
                command2.Parameters.AddWithValue("@postalCode", customerToBeSaved.CustPostalCode);
                command2.Parameters.AddWithValue("@phone", customerToBeSaved.CustPhone);

                string query3 =
                    "INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdateBy) " +
                    "VALUES (@cityId, @city, @countyId, Now(), 'SystemAdd', 'SystemAdd');";

                MySqlCommand command3 = new MySqlCommand(query3, conn);
                command3.Parameters.AddWithValue("@cityId", cityID);
                command3.Parameters.AddWithValue("@city", customerToBeSaved.CustCity);
                command3.Parameters.AddWithValue("@countyId", countryID);

                string query4 =
                    "INSERT INTO country (countryId, country, createDate, createdBy, lastUpdateBy) " +
                    "VALUES (@countyId, @country, Now(), 'SystemAdd', 'SystemAdd');";

                MySqlCommand command4 = new MySqlCommand(query4, conn);
                command4.Parameters.AddWithValue("@countyId", countryID);
                command4.Parameters.AddWithValue("@country", customerToBeSaved.CustCountry);

                command4.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public void SaveUpdatedCustomer(Customer customerToBeSaved)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = 
                    "UPDATE customer " +
                    "SET customerName = @customerName " +
                    "WHERE customerId = @currentCustomerId";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@customerName", customerToBeSaved.CustName);
                command.Parameters.AddWithValue("@currentCustomerId", customerToBeSaved.CustID);

                string query2 =
                    "UPDATE address " +
                    "SET address = @address, address2 = @address2, postalCode = @postalCode, phone = @phone " +
                    "WHERE addressId = " +
                    "(SELECT addressId FROM customer WHERE customerId = @custID)";

                MySqlCommand command2 = new MySqlCommand(query2, conn);
                command2.Parameters.AddWithValue("@address", customerToBeSaved.CustAddress1);
                command2.Parameters.AddWithValue("@address2", customerToBeSaved.CustAddress2);
                command2.Parameters.AddWithValue("@postalCode", customerToBeSaved.CustPostalCode);
                command2.Parameters.AddWithValue("@phone", customerToBeSaved.CustPhone);
                command2.Parameters.AddWithValue("@custID", customerToBeSaved.CustID);

                string query3 =
                    "UPDATE city " +
                    "SET city = @city " +
                    "WHERE cityId = " +
                    "(SELECT cityId FROM address WHERE addressId = " +
                    "(SELECT addressId FROM customer WHERE customerId = @custID));";

                MySqlCommand command3 = new MySqlCommand(query3, conn);
                command3.Parameters.AddWithValue("@city", customerToBeSaved.CustCity);
                command3.Parameters.AddWithValue("@custID", customerToBeSaved.CustID);

                string query4 =
                    "INSERT INTO country " +
                    "SET country = @country " +
                    "WHERE countryId = " +
                    "(SELECT countryId FROM city WHERE cityId = " +
                    "(SELECT cityId FROM address WHERE addressId = " +
                    "(SELECT addressId FROM customer WHERE customerId = @custID)));";

                MySqlCommand command4 = new MySqlCommand(query4, conn);
                command4.Parameters.AddWithValue("@country", customerToBeSaved.CustCountry);
                command4.Parameters.AddWithValue("@custID", customerToBeSaved.CustID);

                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
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
