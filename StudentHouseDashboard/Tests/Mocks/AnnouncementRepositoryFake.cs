using Logic;
using Models;
using System.Data;

namespace Tests.Mocks
{
    public class AnnouncementRepositoryFake : IAnnouncementRepository
    {
        private List<Announcement> announcements;
        private int currentId;

        public AnnouncementRepositoryFake()
        {
            announcements = new List<Announcement>();
            currentId = 1;
        }

        public void CreateAnnouncement(string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky)
        {
            announcements.Add(new Announcement(currentId, author, description, title, publishDate, isImportant, isSticky));
            currentId++;
        }

        public void DeleteAnnouncement(int id)
        {
            announcements.RemoveAt(id--);
        }

        public List<Announcement> GetAllAnnouncements()
        {
            return announcements;
        }

        public Announcement GetAnnouncementById(int id)
        {
            return announcements.FirstOrDefault(x => x.ID == id);
        }

        public List<Announcement> GetAnnouncementsByPage(int p, int c)
        {
            return announcements.GetRange(p + c, c);
        }

        public List<Announcement> SearchAnnouncement(string query)
        {
            return announcements.Where(x => x.Title.Contains(query) || x.Description.Contains(query)).ToList();
        }

        public void UpdateAnnouncement(int id, string title, string description, bool isImportant, bool isSticky)
        {
            Announcement announcement = announcements.First(x => x.ID == id);
            announcement.Title = title;
            announcement.Description = description;
            announcement.IsImportant = isImportant;
            announcement.IsSticky = isSticky;
        }
    }
}
