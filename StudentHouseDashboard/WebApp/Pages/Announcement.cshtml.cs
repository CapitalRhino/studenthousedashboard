using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Models;
using Data;

namespace WebApp.Pages
{
    [Authorize]
    public class AnnouncementModel : PageModel
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementModel(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public void OnGet(int id)
        {
            AnnouncementManager announcementManager = new AnnouncementManager(_announcementRepository);
            ViewData.Add("announcement", announcementManager.GetAnnouncementById(id));
        }
    }
}
