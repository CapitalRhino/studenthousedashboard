using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public User GetUserByName(string userName);
        public List<User> GetUsersByPage(int p, int c);
        public User CreateUser(string name, string password, UserRole role);
        public void UpdateUser(int id, string name, string password, UserRole role);
        public void DisableUser(int id);
    }
}
