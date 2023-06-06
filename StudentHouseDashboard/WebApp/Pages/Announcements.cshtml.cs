using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class AnnouncementsModel : PageModel
    {
        public AnnouncementManager AnnouncementManager { get; set; }
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementsModel(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public void OnGet(int? p, int? c) // page, count
        {
            AnnouncementManager = new AnnouncementManager(_announcementRepository);
            if (!(p < 0))
            {
                p = 1;
            }
            if (!(c < 1))
            {
                c = 10;
            }
            ViewData.Add("announcements", AnnouncementManager.GetAnnouncementsByPage(p.Value - 1, c.Value));
            ViewData.Add("page", p);
            ViewData.Add("count", c);
            ViewData.Add("allCount", AnnouncementManager.GetAllAnnouncements().Count);
        }
        public void OnGetSearch(string s) // search
        {
            AnnouncementManager = new AnnouncementManager(_announcementRepository);
            ViewData.Add("announcements", AnnouncementManager.SearchAnnouncements(s));
        }
    }
}
