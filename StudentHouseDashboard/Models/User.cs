using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models
{
    public class User
    {

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
            get; set;
        }

        public string Name
        {
            get; set;
        }

        [DataType(DataType.Password)]
        public string Password
        {
            get; set;
        }
        public UserRole Role
        {
            get; set;
        }
        public override string ToString()
        {
            return $"{ID}: {Name} ({Role})";
        }
    }
}