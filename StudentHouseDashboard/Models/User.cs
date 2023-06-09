using System.ComponentModel.DataAnnotations;

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

        [Required]
        [StringLength(255)]
        public string Name
        {
            get; set;
        }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(int.MaxValue, MinimumLength = 4)]
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