using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Models;
using Data;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User MyUser { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var userManager = new UserManager(new UserRepository());
            if (userManager.CreateUser(MyUser.Name, BCrypt.Net.BCrypt.HashPassword(MyUser.Password), MyUser.Role) != null)
            {
                ViewData["confirm"] = $"Successfully registered {MyUser.Name}!";
            }
        }
    }
}
