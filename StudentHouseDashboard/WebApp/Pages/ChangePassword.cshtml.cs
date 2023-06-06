using Data;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Current password is required.")]
        public string Password { get; set; }
        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; }
        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("NewPassword", ErrorMessage = "Confirmation field not matching. Check your new password for mistakes.")]
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            UserManager userManager = new UserManager(new UserRepository());
            User user = userManager.GetUserById(int.Parse(User.FindFirstValue("id")));
            if (NewPassword == null)
            {
                ViewData["confirm"] = "New password not entered. Password not changed.";
                return;
            }
            if (NewPassword != ConfirmPassword)
            {
                ViewData["confirm"] = "Password fields do not match. Password not changed.";
                return;
            }
            if (BCrypt.Net.BCrypt.Verify(Password, user.Password))
            {
                NewPassword = BCrypt.Net.BCrypt.HashPassword(NewPassword);
                userManager.UpdateUser(user.ID, user.Name, NewPassword, user.Role);
                ViewData["confirm"] = "Password successfully changed.";
            }
            else
            {
                ViewData["confirm"] = "Current password is not correct. Password not changed.";
            }
        }
    }
}
