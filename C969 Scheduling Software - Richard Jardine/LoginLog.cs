using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public class LoginLog
    {
        public static void TrackUserLogins(int UserID)
        {
                string path = "log.text";
                string entry = $"Successfull Login Entry: UserID = {UserID} TimeStamp = {DateTime.Now}" + Environment.NewLine;

                File.AppendAllText(path, entry);
        }
    }
}
