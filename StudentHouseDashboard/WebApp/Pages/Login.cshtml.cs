using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHouseDashboard.Models;
using StudentHouseDashboard.Managers;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User MyUser { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var userManager = new UserManager();

            foreach (var item in userManager.GetAllUsers())
            {
                if (item.Name == MyUser.Name && BCrypt.Net.BCrypt.Verify(MyUser.Password, item.Password))
                {
                    MyUser = item;
                    ViewData["confirm"] = $"Welcome, {MyUser.Name}! {MyUser.ID}, {MyUser.Password}, {MyUser.Role}";
                }
            }
            
        }
    }
}
