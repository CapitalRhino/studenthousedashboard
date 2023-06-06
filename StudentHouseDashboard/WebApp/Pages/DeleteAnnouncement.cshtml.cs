using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class DeleteAnnouncementModel : PageModel
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public DeleteAnnouncementModel(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        [BindProperty]
        public int AnnouncementId { get; set; }
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
            announcementManager.DeleteAnnouncement(AnnouncementId);
            return RedirectToPage("Announcements");
        }
    }
}
