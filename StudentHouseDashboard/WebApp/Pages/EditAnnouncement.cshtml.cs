using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class EditAnnouncementModel : PageModel
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public EditAnnouncementModel(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        [BindProperty]
        public Announcement Announcement { get; set; }
        public void OnGet(int id)
        {
            AnnouncementManager announcementManager = new AnnouncementManager(_announcementRepository);
            if (id != null)
            {
                Announcement announcement = announcementManager.GetAnnouncementById(id);
                if (announcement.Author.ID == int.Parse(User.FindFirstValue("id")) || User.IsInRole("ADMIN"))
                {
                    ViewData["announcement"] = announcement;
                }
            }
        }
        public IActionResult OnPost()
        {
            AnnouncementManager announcementManager = new AnnouncementManager(_announcementRepository);
            announcementManager.UpdateAnnouncement(Announcement.ID, Announcement.Title, Announcement.Description, Announcement.IsImportant, Announcement.IsSticky);
            return RedirectToPage("Announcements");
        }
    }
}
