﻿using StudentHouseDashboard.Models;
using StudentHouseDashboard.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentHouseDashboard.Managers
{
    public class UserManager
    {
        private UserRepository userRepository;
        public UserManager()
        {
            userRepository = new UserRepository();
        }
        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }
        public List<User> GetUsersByPage(int? p, int? c)
        {
            return userRepository.GetUsersByPage(p, c);
        }
        public bool CreateUser(string name, string password, UserRole role)
        {
            return userRepository.CreateUser(name, password, role);
        }
        public void UpdateUser(int id, string name, string password, UserRole role)
        {
            userRepository.UpdateUser(id, name, password, role);
        }
        public void DisableUser(int id)
        {
            userRepository.DisableUser(id);
        }
    }
}