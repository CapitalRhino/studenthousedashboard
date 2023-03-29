using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHouseDashboard.Managers;

namespace WebApp.Pages
{
    public class AnnouncementsModel : PageModel
    {
        public AnnouncementManager AnnouncementManager { get; set; }
        public UserManager UserManager { get; set; }
        public void OnGet(int? p, int? c)
        {
            UserManager = new UserManager();
            ViewData.Add("users", UserManager.GetUsersByPage(p, c));
            ViewData.Add("page", p);
            ViewData.Add("allCount", UserManager.GetAllUsers().Count());
        }
    }
}
