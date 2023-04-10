using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHouseDashboard.Managers;
using StudentHouseDashboard.Models;

namespace WebApp.Pages
{
    [Authorize]
    public class AnnouncementModel : PageModel
    {
        public void OnGet(int id)
        {
            AnnouncementManager announcementManager = new AnnouncementManager();
            ViewData.Add("announcement", announcementManager.GetAllAnnouncements().Where(x => x.ID == id).First());
        }
    }
}
