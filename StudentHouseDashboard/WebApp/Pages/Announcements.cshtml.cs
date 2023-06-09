using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

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
        public void OnGetFilter(string s, bool asc, bool imp) // search, ascending/descending order, isImportant
        {
            AnnouncementManager = new AnnouncementManager(_announcementRepository);
            List<Announcement> announcements = new List<Announcement>();
            if (!string.IsNullOrEmpty(s))
            {
                announcements = AnnouncementManager.SearchAnnouncements(s);
            }
            else
            {
                announcements = AnnouncementManager.GetAllAnnouncements();
            }

            if (imp)
            {
                announcements = announcements.Where(x => x.IsImportant).ToList();
            }

            if (asc)
            {
                announcements = announcements.OrderBy(x => x.PublishDate).ToList();
            }
            else
            {
                announcements = announcements.OrderByDescending(x => x.PublishDate).ToList();
            }
            ViewData.Add("announcements", announcements);
        }
    }
}
