using Models;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Exceptions;
using System.Reflection;

namespace Data
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        public AnnouncementRepository() { }
        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();
            UserRepository userRepository = new UserRepository();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Announcements;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Announcement announcement = new Announcement(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
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
        public Announcement GetAnnouncementById(int id)
        {
            UserRepository userRepository = new UserRepository();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Announcements WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                reader.Read();
                    Announcement announcement = new Announcement(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (bool)reader["IsImportant"],
                        (bool)reader["IsSticky"]);
                    CommentRepository commentRepository = new CommentRepository();
                    announcement.Comments = commentRepository.GetAllCommentsOnAnnouncement(announcement.ID);
                conn.Close();
                return announcement;
            }
        }
        public List<Announcement> GetAnnouncementsByPage(int p, int c)
        {
            List<Announcement> announcements = new List<Announcement>();
            UserRepository userRepository = new UserRepository();
            if (c == null)
            {
                throw new DatabaseOperationException("Get announcements: Invalid item count");
            }
            if (p == null)
            {
                throw new DatabaseOperationException("Get announcements: Invalid page number");
            }
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Announcements ORDER BY ID DESC OFFSET @start ROWS FETCH NEXT @count ROWS ONLY;";
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.AddWithValue("@start", p * c);
                sqlCommand.Parameters.AddWithValue("@count", c);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    announcements.Add(new Announcement(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (bool)reader["IsImportant"],
                        (bool)reader["IsSticky"]));
                }

            }
            return announcements;
        }
        public void CreateAnnouncement(string title, string description, User author, DateTime publishDate, bool isImportant, bool isSticky)
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
                if (writer != 1)
                {
                    throw new DatabaseOperationException("Database error: Announcement not created");
                }
            }
        }
        public void UpdateAnnouncement(int id, string title, string description, bool isImportant, bool isSticky)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "UPDATE Announcements " +
                    "SET Description = @desc, Title = @title, IsImportant = @important, IsSticky = @sticky " +
                    "WHERE Id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@important", isImportant);
                cmd.Parameters.AddWithValue("@sticky", isSticky);
                cmd.Parameters.AddWithValue("@id", id);
                int writer = cmd.ExecuteNonQuery();
                if (writer != 1)
                {
                    throw new DatabaseOperationException("Database error: Announcement not updated");
                }
            }
        }
        public void DeleteAnnouncement(int id)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "DELETE FROM Announcements WHERE Id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int writer = cmd.ExecuteNonQuery();
                if (writer != 1)
                {
                    throw new DatabaseOperationException("Database error: Announcement not deleted");
                }
            }
        }

        public List<Announcement> SearchAnnouncement(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new DatabaseOperationException("Search announements error: Search query is empty");
            }
            List<Announcement> announcements = new List<Announcement>();
            UserRepository userRepository = new UserRepository();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM Announcements ");
            string[] searchStrings = query.Trim().Split(' ');
            for (int i = 0; i < searchStrings.Length; i++)
            {
                if (i == 0)
                {
                    sql.Append($"WHERE Title LIKE @query{i} OR Description LIKE @query{i} ");
                }
                else
                {
                    sql.Append($"OR Title LIKE @query{i} OR Description LIKE @query{i} ");
                }
            }
            sql.Append(';');
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand(sql.ToString(), conn);
                for (int i = 0; i < searchStrings.Length; i++)
                {
                    sqlCommand.Parameters.AddWithValue($"@query{i}", $"%{searchStrings[i]}%");
                }
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    announcements.Add(new Announcement(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (bool)reader["IsImportant"],
                        (bool)reader["IsSticky"]));
                }
            }
            return announcements;
        }
    }
}
