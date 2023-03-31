using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHouseDashboard.Managers;

namespace WebApp.Pages
{
    [Authorize]
    public class AnnouncementsModel : PageModel
    {
        public AnnouncementManager AnnouncementManager { get; set; }
        public UserManager UserManager { get; set; }
        public void OnGet(int? p, int? c)
        {
            UserManager = new UserManager();
            if (p == null || p < 1)
            {
                p = 1;
            }
            ViewData.Add("users", UserManager.GetUsersByPage(p - 1, c));
            ViewData.Add("page", p);
            ViewData.Add("allCount", UserManager.GetAllUsers().Count());
        }
    }
}
