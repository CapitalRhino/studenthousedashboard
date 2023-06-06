using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Models;
using Logic;
using System.Security.Claims;
using Data;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User MyUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string? returnUrl)
        {
            var userManager = new UserManager(new UserRepository());
            User? user = userManager.AuthenticatedUser(MyUser.Name, MyUser.Password);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                claims.Add(new Claim("id", user.ID.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                // ViewData["confirm"] = $"Welcome, {MyUser.Name}! {MyUser.ID}, {MyUser.Password}, {MyUser.Role}";
                if (!String.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToPage("Announcements");
                }
            }
            else
            {
                ModelState.AddModelError("InvalidCredentials", "The supplied username and/or password is invalid");
                return Page();
            }
        }
    }
}
