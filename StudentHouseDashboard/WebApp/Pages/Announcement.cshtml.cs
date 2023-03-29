using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHouseDashboard.Managers;

namespace WebApp.Pages
{
    public class AnnouncementModel : PageModel
    {
        public void OnGet(int id)
        {
            UserManager userManager = new UserManager();
            ViewData.Add("user", userManager.GetUserById(id));
        }
    }
}
