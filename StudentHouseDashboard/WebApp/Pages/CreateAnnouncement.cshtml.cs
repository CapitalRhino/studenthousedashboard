using Data;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class CreateAnnouncementModel : PageModel
    {
        [BindProperty]
        public Announcement Announcement { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            AnnouncementManager announcementManager = new AnnouncementManager(new AnnouncementRepository());
            UserManager userManager = new UserManager(new UserRepository());
            User user = userManager.GetUserById(int.Parse(User.FindFirstValue("id")));
            announcementManager.CreateAnnouncement(Announcement.Title, Announcement.Description, user, DateTime.Now, Announcement.IsImportant, Announcement.IsSticky);
            return RedirectToPage("Announcements");
        }
    }
}
