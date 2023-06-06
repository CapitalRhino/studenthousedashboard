using Models;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    public class UserRepositoryFake : IUserRepository
    {
        private List<User> users;
        private int currentId;
        public UserRepositoryFake() 
        {
            users = new List<User>();
            currentId = 1;
        }

        public User CreateUser(string name, string password, UserRole role)
        {
            User user = new User(currentId, name, password, role);
            users.Add(user);
            currentId++;
            return user;
        }

        public void DisableUser(int id)
        {
            User user = users.First(x => x.ID == id);
            user.Name = $"Deleted User {user.ID}";
            user.Password = "0";
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            return users.First(x => x.ID == id);
        }

        public User GetUserByName(string userName)
        {
            return users.FirstOrDefault(x => x.Name == userName);
        }

        public List<User> GetUsersByPage(int p, int c)
        {
            return users.GetRange(p + c, c);
        }

        public void UpdateUser(int id, string name, string password, UserRole role)
        {
            User user = users.First(x => x.ID == id);
            user.Name = name;
            user.Password = password;
            user.Role = role;
        }
    }
}
