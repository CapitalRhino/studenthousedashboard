using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class AnnouncementManager
    {
        private IAnnouncementRepository announcementRepository;
        public AnnouncementManager(IAnnouncementRepository announcementRepository)
        {
            this.announcementRepository = announcementRepository;
        }
        public List<Announcement> GetAllAnnouncements()
        {
            return announcementRepository.GetAllAnnouncements();
        }
        public Announcement GetAnnouncementById(int id)
        {
            return announcementRepository.GetAnnouncementById(id);
        }
        public List<Announcement> GetAnnouncementsByPage(int p = 0, int c = 10)
        {
            return announcementRepository.GetAnnouncementsByPage(p, c);
        }
        public void CreateAnnouncement(string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky)
        {
            announcementRepository.CreateAnnouncement(title, description, author, publishDate, isImportant, isSticky);
        }
        public void UpdateAnnouncement(int id, string title, string description, bool isImportant, bool isSticky)
        {
            description += $"{Environment.NewLine}{Environment.NewLine}Updated: {DateTime.Now.ToString("g")}";
            announcementRepository.UpdateAnnouncement(id, title, description, isImportant, isSticky);
        }
        public void DeleteAnnouncement(int id)
        {
            announcementRepository.DeleteAnnouncement(id);
        }
        public List<Announcement> SearchAnnouncements(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new List<Announcement>();
            }
            else
            {
                var match = Regex.Match(query, "(?<=date:)[0-9]{4}-[0-9]{2}-[0-9]{2}");
                DateTime date;
                if (DateTime.TryParse(match.Groups[0].Value, out date))
                {
                    query = Regex.Replace(query, "date:[0-9]{4}-[0-9]{2}-[0-9]{2}", "");
                    if (string.IsNullOrEmpty(query))
                    {
                        return announcementRepository.GetAllAnnouncements().Where(x => x.PublishDate.Date == date.Date).ToList();
                    }
                    else return announcementRepository.SearchAnnouncement(query).Where(x => x.PublishDate.Date == date.Date).ToList();
                }
                else return announcementRepository.SearchAnnouncement(query);
            }
        }
    }
}
