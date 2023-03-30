using BCrypt.Net;
using StudentHouseDashboard.Models;
using StudentHouseDashboard.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
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
        public User? AuthenticatedUser(string name, string password)
        {
            List<User> users = userRepository.GetAllUsers();
            User user = users.Find(x => x.Name == name);
            if (user == null)
            {
                return null;
            }
            else
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
                else return null;
            }
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
