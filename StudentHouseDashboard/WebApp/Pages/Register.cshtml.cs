using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

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
            User? result = null;
            try
            {
                result = userManager.CreateUser(MyUser.Name, BCrypt.Net.BCrypt.HashPassword(MyUser.Password), MyUser.Role);
            }
            catch (ArgumentException)
            {
                ViewData["confirm"] = "An error has occurred. Try a different username.";
            }
            finally
            {
                if (result != null)
                {
                    ViewData["confirm"] = $"Successfully registered {MyUser.Name}!";
                }
            }
        }
    }
}
