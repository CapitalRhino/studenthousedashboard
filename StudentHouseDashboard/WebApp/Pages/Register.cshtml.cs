using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHouseDashboard.Managers;
using StudentHouseDashboard.Models;

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
            var userManager = new UserManager();
            if (userManager.CreateUser(MyUser.Name, BCrypt.Net.BCrypt.HashPassword(MyUser.Password), MyUser.Role))
            {
                ViewData["confirm"] = $"Successfully registered {MyUser.Name}!";
            }
        }
    }
}
