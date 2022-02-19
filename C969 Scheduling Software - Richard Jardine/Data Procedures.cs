using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    class Data_Procedures
    {
        private string connectionString = "Host=localhost; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";

        public bool verifyUser(User userInfo)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            string dbUsername = " ";
            string dbPassword = " ";

            try
            {
                conn.Open();

                MySqlCommand checkUserName = conn.CreateCommand();
                checkUserName.CommandText = "SELECT userName FROM user WHERE userName = @username";
                checkUserName.Parameters.AddWithValue("@username", userInfo.UserName);
                dbUsername = checkUserName.ExecuteScalar().ToString();

                MySqlCommand checkPassword = conn.CreateCommand();
                checkPassword.CommandText = "SELECT password FROM user WHERE BINARY password = @password AND userName = @username";
                checkPassword.Parameters.AddWithValue("@password", userInfo.UserPassword);
                checkPassword.Parameters.AddWithValue("@username", userInfo.UserName);
                dbPassword = checkPassword.ExecuteScalar().ToString();

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
    }
}
