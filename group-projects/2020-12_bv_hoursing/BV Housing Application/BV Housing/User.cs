using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV_Housing
{
    public class User
    {
        private String name;
        private String username;
        private String password;

        public User(String name, String username, String password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
        }


        public String Name 
            { get { return this.name; } }
        public String Password
        { get { return this.password; }
            set { this.password = value; }
        }

        public String Username
        { get { return this.username; } }

    }

}
