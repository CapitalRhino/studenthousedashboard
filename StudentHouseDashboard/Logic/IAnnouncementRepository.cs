using Models;

namespace Logic
{
    public interface IAnnouncementRepository
    {
        public List<Announcement> GetAllAnnouncements();
        public Announcement GetAnnouncementById(int id);
        public List<Announcement> GetAnnouncementsByPage(int p, int c);
        public void CreateAnnouncement(string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky);
        public void UpdateAnnouncement(int id, string title, string description, bool isImportant, bool isSticky);
        public void DeleteAnnouncement(int id);
        public List<Announcement> SearchAnnouncement(string query);
    }
}
