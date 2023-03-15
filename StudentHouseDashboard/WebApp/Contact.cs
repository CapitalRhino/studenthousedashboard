using System.ComponentModel.DataAnnotations;

namespace WebApp
{
    public class Contact
    {
        public Contact()
        {
            
        }
        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
