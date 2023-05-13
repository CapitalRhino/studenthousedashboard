using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class CreateAnnouncementModel : PageModel
    {
        [BindProperty]
        public Announcement Announcement { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            AnnouncementManager announcementManager = new AnnouncementManager();
            UserManager userManager = new UserManager();
            User user = userManager.GetUserById(int.Parse(User.FindFirstValue("id")));
            announcementManager.CreateAnnouncement(Announcement.Title, Announcement.Description, user, DateTime.Now, Announcement.IsImportant, Announcement.IsSticky);
            RedirectToPage("Announcements");
        }
    }
}
