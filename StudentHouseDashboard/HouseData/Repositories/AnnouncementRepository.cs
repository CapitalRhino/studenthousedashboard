using StudentHouseDashboard.Managers;
using StudentHouseDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouseDashboard.Repositories
{
    public class AnnouncementRepository
    {
        public AnnouncementRepository() { }
        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();
            UserManager userManager = new UserManager();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Announcements;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Announcement announcement = new Announcement(Convert.ToInt32(reader["ID"]),
                        userManager.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (bool)reader["IsImportant"],
                        (bool)reader["IsSticky"]);
                    CommentRepository commentRepository = new CommentRepository();
                    announcement.Comments = commentRepository.GetAllCommentsOnAnnouncement(announcement.ID);
                    // ID, Name, Password, Role
                    announcements.Add(announcement);
                }
                conn.Close();
            }
            return announcements;
        }
        public List<Announcement> GetAnnouncementsByPage(int? p, int? c)
        {
            List<Announcement> announcements = new List<Announcement>();
            UserManager userManager = new UserManager();
            if (c == null || c < 0)
            {
                c = 10;
            }
            if (p == null || p < 0)
            {
                p = 0;
            }
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Announcements ORDER BY ID OFFSET @start ROWS FETCH NEXT @count ROWS ONLY;";
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.AddWithValue("@start", p * c);
                sqlCommand.Parameters.AddWithValue("@count", c);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    announcements.Add(new Announcement(Convert.ToInt32(reader["ID"]),
                        userManager.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (bool)reader["IsImportant"],
                        (bool)reader["IsSticky"]));
                }

            }
            return announcements;
        }
        public bool CreateAnnouncement(string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "INSERT INTO Announcements (Author, Description, Title, PublishDate, IsImportant, IsSticky) VALUES (@author, @desc, @title, @date, @important, @sticky);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@author", author.ID);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", publishDate);
                cmd.Parameters.AddWithValue("@important", isImportant);
                cmd.Parameters.AddWithValue("@sticky", isSticky);
                int writer = cmd.ExecuteNonQuery();

                if (writer == 1)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool UpdateAnnouncement(int id, string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "UPDATE Announcements " +
                    "SET Author = @author, Description = @desc, Title = @title, PublishDate = @date, IsImportant = @important, IsSticky = @sticky " +
                    "WHERE Id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@author", author.ID);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", publishDate);
                cmd.Parameters.AddWithValue("@important", isImportant);
                cmd.Parameters.AddWithValue("@sticky", isSticky);
                cmd.Parameters.AddWithValue("@id", id);
                int writer = cmd.ExecuteNonQuery();

                if (writer == 1)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool DeleteAnnouncement(int id)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "DELETE FROM Announcements WHERE Id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int writer = cmd.ExecuteNonQuery();

                if (writer == 1)
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
