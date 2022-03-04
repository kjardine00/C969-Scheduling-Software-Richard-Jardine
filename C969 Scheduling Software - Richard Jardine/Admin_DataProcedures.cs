using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    class Admin_DataProcedures
    {
        private string connectionString = "Host=localhost; Port=3306; Database=client_schedule; Username=sqlUser; Password=Passw0rd!";

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

        private static int NewID(List<int> idList)
        {
            int highestID = 0;

            foreach (int id in idList)
            {
                if (id > highestID)
                {
                    highestID = id;
                }
            }
            return highestID + 1;
        }

        public int CreateNewID(string table)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();


            string query = $"SELECT {table + "Id"} FROM {table}";
            MySqlCommand command = new MySqlCommand(query, conn);

            MySqlDataReader reader = command.ExecuteReader();
            List<int> idList = new List<int>();

            while (reader.Read())
            {
                idList.Add(Convert.ToInt32(reader[0]));
            }

            reader.Close();
            conn.Close();

            return NewID(idList);
        }
    }
}
