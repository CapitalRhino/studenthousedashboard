using Logic;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mocks;

namespace Tests
{
    [TestClass]
    public class AnnouncementManagerTest
    {
        [TestMethod]
        public void SearchEmptyRegexQueryTest()
        {
            // Arrange
            AnnouncementManager announcementManager = new AnnouncementManager(new AnnouncementRepositoryFake());

            // Act
            List<Announcement> result = announcementManager.SearchAnnouncements(string.Empty);

            // Assert
            CollectionAssert.AreEquivalent(new List<Announcement>(), result);
        }

        [TestMethod]
        public void SearchRegexWithDateQueryTest()
        {
            // Arrange
            AnnouncementManager announcementManager = new AnnouncementManager(new AnnouncementRepositoryFake());
            User user = new User(1, "user", "password", UserRole.TENANT);
            announcementManager.CreateAnnouncement("1", "", user, new DateTime(2000, 01, 01), false, false);
            announcementManager.CreateAnnouncement("2", "", user, new DateTime(2000, 01, 01), true, false);
            announcementManager.CreateAnnouncement("3", "", user, new DateTime(2000, 02, 02), false, false);

            // Act
            List<Announcement> expected = announcementManager.GetAllAnnouncements().Where(x => x.PublishDate == new DateTime(2000, 01, 01)).ToList();
            List<Announcement> result = announcementManager.SearchAnnouncements("date:2000-01-01");

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
