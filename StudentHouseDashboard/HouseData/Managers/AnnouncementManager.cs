using StudentHouseDashboard.Models;
using StudentHouseDashboard.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouseDashboard.Managers
{
    public class AnnouncementManager
    {
        private AnnouncementRepository announcementRepository;
        public AnnouncementManager()
        {
            announcementRepository = new AnnouncementRepository();
        }
        public List<Announcement> GetAllAnnouncements()
        {
            return announcementRepository.GetAllAnnouncements();
        }
        public List<Announcement> GetAnnouncementsByPage(int? p, int? c)
        {
            return announcementRepository.GetAnnouncementsByPage(p, c);
        }
        public bool CreateAnnouncement(string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky)
        {
            return announcementRepository.CreateAnnouncement(title, description, author, publishDate, isImportant, isSticky);
        }
        public bool UpdateAnnouncement(int id, string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky)
        {
            return announcementRepository.UpdateAnnouncement(id, title, description, author, publishDate, isImportant, isSticky);
        }
        public bool DeleteAnnouncement(int id)
        {
            return announcementRepository.DeleteAnnouncement(id);
        }
    }
}
