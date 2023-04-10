using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHouseDashboard.Managers;
using StudentHouseDashboard.Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class AnnouncementsModel : PageModel
    {
        public AnnouncementManager AnnouncementManager { get; set; }
        public void OnGet(int? p, int? c)
        {
            AnnouncementManager = new AnnouncementManager();
            if (p == null || p < 1)
            {
                p = 1;
            }
            ViewData.Add("announcements", AnnouncementManager.GetAnnouncementsByPage(p - 1, c));
            ViewData.Add("page", p);
            ViewData.Add("allCount", AnnouncementManager.GetAllAnnouncements().Count());
        }
    }
}
