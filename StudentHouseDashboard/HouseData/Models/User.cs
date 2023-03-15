using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class User
    {
        public User(int username, UserRole role)
        {
            Username = username;
            Role = role;
        }

        public int Username
        {
            get;set;
        }

        public UserRole Role
        {
            get;set;
        }
    }
}