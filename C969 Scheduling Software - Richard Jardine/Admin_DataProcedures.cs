using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            catch (System.Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        public int GetCurrentUserID(User currentUser)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();

            MySqlCommand getUserID = conn.CreateCommand();
            getUserID.CommandText = "SELECT userId FROM user WHERE userName = @username";
            getUserID.Parameters.AddWithValue("@username", currentUser.UserName);
            int currentUserId = Convert.ToInt32(getUserID.ExecuteScalar());

            conn.Close();

            return currentUserId;
        }

        public int CheckForAptReminder(int UserID)
        {
            DataTable CheckApts = new DataTable();

            MySqlConnection conn = new MySqlConnection(connectionString);

            DateTime timeAway = DateTime.Now.AddMinutes(15);

            if (!CheckApts.Columns.Contains("AptID")) { CheckApts.Columns.Add("AptID", typeof(int)); }
            if (!CheckApts.Columns.Contains("Start Time")) { CheckApts.Columns.Add("Start Time", typeof(DateTime)); }

            try
            {
                conn.Open();

                string query = "SELECT appointmentId, start FROM appointment WHERE userId = @userId;";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@userId", UserID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CheckApts.Rows.Add(
                            reader["appointmentId"],
                            reader["start"]);
                    }
                }

                foreach (DataRow row in CheckApts.Rows)
                {
                    DateTime utcStart = Convert.ToDateTime(row["Start Time"]);
                    row["Start Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcStart);

                    if (utcStart.ToLocalTime() < timeAway && utcStart.ToLocalTime() > DateTime.Now)
                    {
                        return Convert.ToInt32(row["AptId"]);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return 0;
        }

        public string GetAptTitle(int AptID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            string aptTitle = "";

            try
            {
                conn.Open();

                string query = "SELECT title FROM appointment WHERE appointmentId = @aptID;";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@aptID", AptID);

                aptTitle = command.ExecuteScalar().ToString();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return aptTitle;
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
