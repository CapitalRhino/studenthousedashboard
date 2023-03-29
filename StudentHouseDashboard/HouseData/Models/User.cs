using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class User
    {
        private int id;
        private string name;
        private string password;
        private UserRole role;

        public User(int id, string name, string password, UserRole role)
        {
            ID = id;
            Name = name;
            Password = password;
            Role = role;
        }
        public User()
        {
            
        }
        public int ID
        {
            get; private set;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        [PasswordPropertyText(true)]
        public string Password
        {
            get => password;
            set => password = value;
        }
        public UserRole Role
        {
            get => role;
            set => role = value;
        }
    }
}