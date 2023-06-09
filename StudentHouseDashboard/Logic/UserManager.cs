using Models;

namespace Logic
{
    public class UserManager
    {
        private readonly IUserRepository userRepository;
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }
        public List<User> GetUsersByPage(int p = 0, int c = 10)
        {
            return userRepository.GetUsersByPage(p, c);
        }
        public User? AuthenticatedUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Name or password should not be empty!");
            }
            List<User> users = userRepository.GetAllUsers();
            User? user = users.Find(x => x.Name == name);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }
        public bool UserExists(string name)
        {
            return userRepository.GetUserByName(name) != null;
        }
        public User CreateUser(string name, string password, UserRole role)
        {
            if (UserExists(name))
            {
                throw new ArgumentException("User with given username already exists!");
            }
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Name or password should not be empty!");
            }
            return userRepository.CreateUser(name, password, role);
        }
        public void UpdateUser(int id, string name, string password, UserRole role)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Name or password should not be empty!");
            }
            userRepository.UpdateUser(id, name, password, role);
        }
        public void DisableUser(int id)
        {
            userRepository.DisableUser(id);
        }
    }
}
