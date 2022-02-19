using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool UserActive { get; set; }

        public User(string _username, string _password)
        {
            UserName = _username;
            UserPassword = _password;
        }

    }
}
